using CruiseDAL;
using CruiseManager.Core.FileMaintenance;
using FMSC.ORM.Core.SQL;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components
{
    public class PrepareMergeWorker
    {
        public const string COMP_ALIAS = "comp";

        private class GuidRowID
        {
            [Field("Guid")]
            public Guid Guid { get; set; }

            [Field("RecID")]
            public long RecID { get; set; }
        }

        public static void DoWork(
            DAL master,
            IEnumerable<ComponentFile> components,
            IEnumerable<MergeTableCommandBuilder> commandBuilders,
            CancellationToken cancellation,
            IProgress<int> progress,
            IMergeLog log)
        {
            ExecuteMaintenanceScript(new AssignGuidsScript(), (DAL)null, components, log);
            ExecuteMaintenanceScript(new ConsolidateCountTreeScript(), master, components, log);

            MakeMergeTables(master, commandBuilders, cancellation, progress, log);
            PopulateMergeTables(master, components, commandBuilders, cancellation, progress, log);
            ProcessMergeTables(master, components, commandBuilders, cancellation, progress, log);
        }

        public static Task DoWorkAsync(
            DAL master,
            IEnumerable<ComponentFile> components,
            IEnumerable<MergeTableCommandBuilder> commandBuilders,
            CancellationToken cancellation,
            IProgress<int> progress,
            IMergeLog log)
        {
            return Task.Run(() => DoWork(master, components, commandBuilders, cancellation, progress, log));
        }

        private static void ExecuteMaintenanceScript(
            ISimpleSQLScript maintenanceScript,
            DAL master,
            IEnumerable<ComponentFile> components,
            IMergeLog log)
        {
            if (master != null && maintenanceScript.CheckCanExecute(master))
            {
                log?.PostStatus($"Applying {maintenanceScript.Name} To Master");
                maintenanceScript.Execute(master);
            }
            if (components != null)
            {
                foreach (var comp in components)
                {
                    if (maintenanceScript.CheckCanExecute(comp.Database))
                    {
                        log?.PostStatus($"Applying {maintenanceScript.Name} Fix To " + comp.FileName);
                        maintenanceScript.Execute(comp.Database);
                    }
                }
            }
        }

        public static void MakeMergeTables(
            DAL master,
            IEnumerable<MergeTableCommandBuilder> commandBuilders,
            CancellationToken cancellation,
            IProgress<int> progress,
            IMergeLog log)
        {
            log?.StartJob();
            var unitsOfWork = commandBuilders.Count();
            master.BeginTransaction();
            try
            {
                var i = 0;
                foreach (MergeTableCommandBuilder cmdBldr in commandBuilders)
                {
                    log?.PostStatus("Create " + cmdBldr.MergeTableName);

                    master.Execute("DROP TABLE IF EXISTS " + cmdBldr.MergeTableName + ";");
                    master.Execute(cmdBldr.MakeMergeTableCommand);
                    progress?.Report((++i * 100) / unitsOfWork);
                }

                master.CommitTransaction();
            }
            catch
            {
                master.RollbackTransaction();
                throw;
            }
        }


        public static void PopulateMergeTables(
            DAL master,
            IEnumerable<ComponentFile> components,
            IEnumerable<MergeTableCommandBuilder> commandBuilders,
            CancellationToken cancellation,
            IProgress<int> progress,
            IMergeLog log)
        {
            log?.StartJob();

            foreach (var comp in components)
            {
                PopulateMergeTables(master, comp, commandBuilders, cancellation, progress, log);
            }
            log?.EndJob();
        }

        public static void PopulateMergeTables(
            DAL master,
            ComponentFile comp,
            IEnumerable<MergeTableCommandBuilder> commandBuilders,
            CancellationToken cancellation,
            IProgress<int> progress,
            IMergeLog log)
        {
            var compNumber = comp.Component_CN;

            master.AttachDB(comp.Database, COMP_ALIAS); //may throw exception
            master.BeginTransaction();
            try
            {
                var unitsOfWork = commandBuilders.Count();
                var i = 0;
                foreach (var cmdBldr in commandBuilders)
                {
                    cancellation.ThrowIfCancellationRequested();

                    var comp_CN = (int)comp.Component_CN.Value;

                    master.Execute(cmdBldr.GetPopulateMergeTableCommand(comp_CN));
                    master.Execute(cmdBldr.GetPopulateDeletedRecordsCommand(comp_CN));
                    progress?.Report((++i * 100) / unitsOfWork);
                }

                master.CommitTransaction();
                log?.PostStatus("Imported Merge Info For Component #" + compNumber);
            }
            catch
            {
                master.RollbackTransaction();
                throw;
            }
            finally
            {
                master.DetachDB(COMP_ALIAS);
            }
        }



        public static void ProcessMergeTables(DAL master,
            IEnumerable<ComponentFile> components,
            IEnumerable<MergeTableCommandBuilder> commandBuilders,
            CancellationToken cancellation,
            IProgress<int> progress,
            IMergeLog log)
        {
            log?.StartJob();
            master.BeginTransaction();
            try
            {
                foreach (MergeTableCommandBuilder cmdBldr in commandBuilders)
                {
                    cancellation.ThrowIfCancellationRequested();
                    ProcessMergeTable(master, cmdBldr, components, log);
                }

                master.CommitTransaction();
                log?.EndJob();
            }
            catch
            {
                master.RollbackTransaction();
                throw;
            }
        }

        public static void ProcessMergeTable(DAL master,
            MergeTableCommandBuilder commandBuider,
            IEnumerable<ComponentFile> components,
            IMergeLog log)
        {
            log?.PostStatus("Processing " + commandBuider.MergeTableName);

            //run various comparisons
            ProcessComparisons(master, commandBuider);

            //ProcessInvalidMatchs(mergeDB, commandBuider);
            ProcessFullMatchs(master, commandBuider);
            SetPartialMatches(master, commandBuider);

            IdentifySiblingRecords(master, commandBuider);
            FindNaturalSiblingMatches(master, commandBuider);

            if (commandBuider.HasRowVersion)
            {
                SetMasterRowVersion(master, commandBuider);//master row version is used to determine which file has the changes in the case where the master can update the component.
            }

            if (commandBuider.MergeNewFromMaster)
            {
                ProcessMasterNew(master, commandBuider, components);//add merge records for records that are new on the master side
            }
        }

        public static void FindNaturalSiblingMatches(DAL mergeDB, MergeTableCommandBuilder cmdBldr)
        {
            List<MergeObject> naturalSiblings = mergeDB.Query<MergeObject>(
                "SELECT CompoundNaturalKey, NaturalSiblings FROM (" +
                "SELECT CompoundNaturalKey, group_concat(MergeRowID, ',') as NaturalSiblings, count(1) as size FROM " + cmdBldr.MergeTableName +
                " GROUP BY CompoundNaturalKey) WHERE size > 1;", (object[])null).ToList();

            string setNaturalSiblings = "UPDATE " + cmdBldr.MergeTableName + " SET NaturalSiblings = @p1 WHERE CompoundNaturalKey = @p2;";
            foreach (MergeObject groups in naturalSiblings)
            {
                mergeDB.Execute(setNaturalSiblings, groups.NaturalSiblings, groups.CompoundNaturalKey);
            }
        }

        public static void SetPartialMatches(DAL mergeDB, MergeTableCommandBuilder cmdBldr)
        {
            List<string> matchSources = new List<string>();
            if (cmdBldr.DoNaturalMatch)
            {
                matchSources.Add("SELECT MergeRowID, NaturalMatch AS PartialMatch FROM " + cmdBldr.MergeTableName +
                    " WHERE NaturalMatch IS NOT NULL AND MatchRowID IS NULL");
                //matchSources.Add("SELECT MergeRowID, NaturalMatch AS PartialMatch FROM " + cmdBldr.MergeTableName +
                //    " WHERE NaturalMatch IS NOT NULL AND (NaturalMatch != RowIDMatch OR NaturalMatch != GUIDMatch)");
            }
            if (cmdBldr.DoKeyMatch)
            {
                matchSources.Add("SELECT MergeRowID, RowIDMatch AS PartialMatch FROM " + cmdBldr.MergeTableName +
                    " WHERE RowIDMatch IS NOT NULL AND MatchRowID IS NULL");
            }
            if (cmdBldr.DoGUIDMatch)
            {
                matchSources.Add("SELECT MergeRowID, GUIDMatch AS PartialMatch FROM " + cmdBldr.MergeTableName +
                    " WHERE GUIDMatch IS NOT NULL AND MatchRowID IS NULL");
            }

            string selectPartialMatches = "SELECT MergeRowID, group_concat(PartialMatch, ',') AS PartialMatch FROM ( " +
                string.Join(" UNION ", matchSources.ToArray()) + " ) GROUP BY MergeRowID;";

            List<MergeObject> partialMatchs = mergeDB.Query<MergeObject>(selectPartialMatches, (object[])null).ToList();

            foreach (MergeObject mRec in partialMatchs)
            {
                mergeDB.Execute($"UPDATE {cmdBldr.MergeTableName} SET PartialMatch = @p1 WHERE MergeRowID = @p2;", 
                    mRec.PartialMatch, mRec.MergeRowID);
            }
        }

        public static void ProcessComparisons(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            if (cmdBldr.DoKeyMatch)
            {
                foreach (MergeObject item in master.Query<MergeObject>(cmdBldr.SelectRowIDMatches).ToList())
                {
                    master.Execute($"UPDATE {cmdBldr.MergeTableName} SET RowIDMatch = @p1 WHERE MergeRowID = @p2;", 
                        item.RowIDMatch, item.MergeRowID);
                }
            }

            if (cmdBldr.DoNaturalMatch)
            {
                foreach (MergeObject mRec in master.Query<MergeObject>(cmdBldr.SelectNaturalMatches).ToList())
                {
                    master.Execute($"UPDATE {cmdBldr.MergeTableName} SET NaturalMatch = @p1 WHERE MergeRowID = @p2;", 
                        mRec.NaturalMatch, mRec.MergeRowID);
                }
            }

            if (cmdBldr.HasGUIDKey)
            {
                var rowIDLookUp = new Dictionary<Guid, long>();
                foreach (var pair in master.Query<GuidRowID>($"Select {cmdBldr.ClientGUIDFieldName} AS Guid, {cmdBldr.ClientPrimaryKey.Name} AS RecID FROM main.{cmdBldr.ClientTableName} WHERE {cmdBldr.ClientGUIDFieldName} IS NOT NULL AND {cmdBldr.ClientGUIDFieldName} NOT LIKE '';", (object[])null))
                {
                    var guid = pair.Guid;
                    if (guid != Guid.Empty)
                    {
                        rowIDLookUp.Add(guid, pair.RecID);
                    }
                }

                foreach (var mrgRec in master.Query<GuidRowID>($"Select MergeRowID AS RecID, ComponentRowGUID AS Guid FROM {cmdBldr.MergeTableName} WHERE ComponentRowGUID IS NOT NULL;"))
                {
                    try
                    {
                        if (rowIDLookUp.ContainsKey(mrgRec.Guid))
                        {
                            var match = rowIDLookUp[mrgRec.Guid];

                            string setGuidMatch = $"UPDATE {cmdBldr.MergeTableName} SET GUIDMatch = {match} WHERE MergeRowID = {mrgRec.RecID};";
                            master.Execute(setGuidMatch);
                        }
                    }
                    catch { continue; }
                }

                //List <MergeObject> guidMatches = master.Query<MergeObject>(cmdBldr.SelectGUIDMatches);
                //this._workInCurrentJob += guidMatches.Count;
                //string setGuidMatch = "UPDATE " + cmdBldr.MergeTableName + " SET GUIDMatch = ? WHERE MergeRowID = ?;";
                //foreach (MergeObject mRec in guidMatches)
                //{
                //    CheckWorkerStatus();
                //    master.Execute(setGuidMatch, mRec.GUIDMatch, mRec.MergeRowID);
                //    this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
                //}
            }
        }

        //private void ProcessMissingRecords(DAL mergeDB, MergeTableCommandBuilder commandBuider)
        //{
        //    //check records in master against records in merge table, for missing matches
        //    //create merge record where component row id and component GUID is null
        //    List<MergeObject> missing = mergeDB.Query<MergeObject>(
        //            commandBuider.MissingRecords);

        //    this._workInCurrentJob += missing.Count;
        //    this.NotifyProgressChanged(this._progressInCurrentJob, false, "Processing Missing Records", null);

        //    string insertMissingCommand = String.Format("INSERT INTO Merge{0} (RowIDMatch, IsDeleted) VALUES (?, 1);", commandBuider.ClientTableName);
        //    foreach (MergeObject item in missing)
        //    {
        //        CheckWorkerStatus();
        //        mergeDB.Execute(insertMissingCommand, item.RowIDMatch);
        //        this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
        //    }
        //}

        public static void ProcessFullMatchs(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            List<MergeObject> matches = master.Query<MergeObject>(cmdBldr.SelectFullMatches).ToList();

            string setMatches = $"UPDATE {cmdBldr.MergeTableName} SET MatchRowID = @p1 WHERE MergeRowID = @p2;";
            foreach (MergeObject item in matches)
            {
                master.Execute(setMatches, cmdBldr.GetMatchRowID(item), item.MergeRowID);
            }
        }

        public static void IdentifySiblingRecords(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            List<string> matchSources = new List<string>();
            if (cmdBldr.DoNaturalMatch)
            {
                matchSources.Add("SELECT MergeRowID, NaturalMatch AS PartialMatch FROM " + cmdBldr.MergeTableName +
                    " WHERE NaturalMatch IS NOT NULL");
            }
            if (cmdBldr.DoKeyMatch)
            {
                matchSources.Add("SELECT MergeRowID, RowIDMatch AS PartialMatch FROM " + cmdBldr.MergeTableName +
                    " WHERE RowIDMatch IS NOT NULL");
            }
            if (cmdBldr.DoGUIDMatch)
            {
                matchSources.Add("SELECT MergeRowID, GUIDMatch AS PartialMatch FROM " + cmdBldr.MergeTableName +
                    " WHERE GUIDMatch IS NOT NULL");
            }

            string selectSiblings = "SELECT SiblingRecords FROM (SELECT PartialMatch , group_concat(MergeRowID, ',') as SiblingRecords, count(1) as size FROM ( " +
                string.Join(" UNION ", matchSources.ToArray()) + " )  GROUP BY PartialMatch) where size > 1;";

            var siblingsGroups = master.Query<MergeObject>(selectSiblings).ToArray();
            string setSiblingsformat = "UPDATE " + cmdBldr.MergeTableName + " SET SiblingRecords = ifnull(SiblingRecords, '') || @p1  WHERE MergeRowID in ({0});";
            foreach (MergeObject mRec in siblingsGroups)
            {
                string setSiblings = String.Format(setSiblingsformat, mRec.SiblingRecords);
                master.Execute(setSiblings, mRec.SiblingRecords);
            }

            //List<MergeObject> matchConflicts = master.Query<MergeObject>(cmdBldr.SelectSiblingRecords);

            //this._workInCurrentJob += matchConflicts.Count;
            //this.NotifyProgressChanged(this._progressInCurrentJob, false, "Processing Duplicate Match Conflicts", null);

            //string setMatchConflicts = "UPDATE " + cmdBldr.MergeTableName + " SET SiblingRecords = ? WHERE PartialMatch IS NOT NULL;";
            //foreach(MergeObject item in matchConflicts)
            //{
            //    CheckWorkerStatus();
            //    master.Execute(setMatchConflicts, item.SiblingRecords, item.PartialMatch);
            //    this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
            //}
        }

        public static void SetMasterRowVersion(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            string setMasterRowVersion = "UPDATE " + cmdBldr.MergeTableName + " SET MasterRowVersion = " +
                "(SELECT RowVersion FROM " + cmdBldr.ClientTableName + " AS client WHERE client.RowID = MatchRowID);";

            master.Execute(setMasterRowVersion);
        }

        public static void ProcessMasterNew(DAL master, MergeTableCommandBuilder cmdBldr, IEnumerable<ComponentFile> components)
        {
            foreach (ComponentFile comp in components)
            {
                foreach (MergeObject mRec in master.Query<MergeObject>(cmdBldr.SelectMissingMatches(comp), (object[])null))
                {
                    master.Execute($"INSERT INTO {cmdBldr.MergeTableName} (MatchRowID, ComponentID) VALUES (@p1,@p2);", 
                        mRec.MatchRowID, comp.Component_CN);
                }
            }
        }

    }
}