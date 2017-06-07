using CruiseDAL;
using CruiseManager.Core.FileMaintenance;
using FMSC.ORM.Core.SQL;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CruiseManager.Core.Components
{
    public class PrepareMergeWorker : IDisposable, IWorker
    {
        private class GuidRowID
        {
            [Field("Guid")]
            public Guid Guid { get; set; }

            [Field("RecID")]
            public long RecID { get; set; }
        }

        public event EventHandler<WorkerProgressChangedEventArgs> ProgressChanged;

        protected DAL MasterDB => MergePresenter.MasterDB;
        protected IList<ComponentFileVM> Components => MergePresenter.ActiveComponents;

        private IDictionary<String, MergeTableCommandBuilder> CommandBuilders => MergePresenter.CommandBuilders;
        public MergeComponentsPresenter MergePresenter { get; set; }

        public PrepareMergeWorker(MergeComponentsPresenter mergePresenter)
        {
            this.MergePresenter = mergePresenter;
        }

        public void BeginWork()
        {
            if (_thread != null && _thread.IsAlive)
            {
                throw new InvalidOperationException("Cancel or wait for current job to finish before starting again");
            }

            this._thread = new Thread(this.DoWork)
            {
                IsBackground = true,
                Name = "PrepareMergeWorker"
            };
            this._thread.Start();
        }

        /// <summary>
        /// Called throughout the work flow to determine if work needs to be halted
        /// </summary>
        /// <exception cref="CancelWorkerException"></exception>
        private void CheckWorkerStatus()
        {
            if (this.IsCanceled)
            { throw new CancelWorkerException(); }
        }

        protected void NotifyProgressChanged(int workDone, bool isDone, String message, Exception error)
        {
            if (isDone)
            {
                this.IsDone = true;
            }
            if (this.ProgressChanged != null)
            {
                int percentDone = (int)(100 * (float)workDone / _workInCurrentJob);
                System.Diagnostics.Debug.Assert(percentDone <= 100 && percentDone >= 0);

                WorkerProgressChangedEventArgs e = new WorkerProgressChangedEventArgs(percentDone)
                {
                    IsDone = isDone,
                    Error = error,
                    Message = message
                };
                this.ProgressChanged(this, e);
            }
        }

        public void DoWork()
        {
            this.IsDone = false;
            this.IsCanceled = false;

            ConsolidateCountTreeScript maintenanceScript = new FileMaintenance.ConsolidateCountTreeScript();

            this.PatchFiles(maintenanceScript);

            this.MakeMergeTables();
            this.PopulateMergeTables();
            this.ProcessMergeTables();

            this.IsDone = true;
            this.NotifyProgressChanged(this._workInCurrentJob, true, "Done", null);
        }

        private void PatchFiles(ConsolidateCountTreeScript maintenanceScript)
        {
            if (maintenanceScript.CheckCanExecute(this.MasterDB))
            {
                PostStatus("Applying CountTree Fix To Master");
                maintenanceScript.Execute(this.MasterDB);
            }
            foreach (ComponentFileVM comp in this.Components)
            {
                if (maintenanceScript.CheckCanExecute(comp.Database))
                {
                    PostStatus("Applying CountTree Fix To " + comp.FileName);
                    maintenanceScript.Execute(comp.Database);
                }
            }
        }

        protected void MakeMergeTables()
        {
            this._progressInCurrentJob = 0;
            //this._workInCurrentJob = this.CommandBuilders.Count;
            this.PostStatus("Start Make Merge Tables");
            MasterDB.BeginTransaction();
            try
            {
                foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
                {
                    MakeMergeTable(cmdBldr);
                }

                MasterDB.CommitTransaction();
            }
            catch
            {
                MasterDB.RollbackTransaction();
                throw;
            }
        }

        private void MakeMergeTable(MergeTableCommandBuilder table)
        {
            this.CheckWorkerStatus();
            StartJob("Create " + table.MergeTableName);

            MasterDB.Execute("DROP TABLE IF EXISTS " + table.MergeTableName + ";");
            MasterDB.Execute(table.MakeMergeTableCommand);

            EndJob();
        }

        public void PopulateMergeTables()
        {
            this._workInCurrentJob += this.Components.Count;
            foreach (ComponentFileVM comp in this.Components)
            {
                this.PopulateMergeTables(comp);
            }
        }

        private void PopulateMergeTables(ComponentFileVM comp)
        {
            MasterDB.AttachDB(comp.Database, "compDB"); //may throw exception
            MasterDB.BeginTransaction();
            try
            {
                foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
                {
                    PopulateMergeTable(this.MasterDB, cmdBldr, comp);
                }

                MasterDB.CommitTransaction();
                this.NotifyProgressChanged(this._progressInCurrentJob++, false, "Imported Merge Info For Component #" + comp.Component_CN.ToString(), null);
            }
            catch
            {
                MasterDB.RollbackTransaction();
                throw;
            }
            finally
            {
                MasterDB.DetachDB("compDB");
            }
        }

        private void PopulateMergeTable(DAL masterDB, MergeTableCommandBuilder table, ComponentFileVM comp)
        {
            CheckWorkerStatus();

            masterDB.Execute(table.GetPopulateMergeTableCommand(comp));
            masterDB.Execute(table.GetPopulateDeletedRecordsCommand(comp));
        }

        public void ProcessMergeTables()
        {
            this.ProcessMergeTables(this.MasterDB);
        }

        private void ProcessMergeTables(DAL mergeDB)
        {
            try
            {
                mergeDB.BeginTransaction();
                foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
                {
                    ProcessMergeTable(mergeDB, cmdBldr);
                }

                mergeDB.CommitTransaction();
            }
            catch
            {
                mergeDB.RollbackTransaction();
                throw;
            }
        }

        private void ProcessMergeTable(DAL mergeDB, MergeTableCommandBuilder commandBuider)
        {
            this.NotifyProgressChanged(this._progressInCurrentJob, false, "Processing " + commandBuider.MergeTableName, null);

            //run various comparisons
            ProcessComparisons(mergeDB, commandBuider);

            //ProcessInvalidMatchs(mergeDB, commandBuider);
            ProcessFullMatchs(mergeDB, commandBuider);
            SetPartialMatches(mergeDB, commandBuider);

            IdentifySiblingRecords(mergeDB, commandBuider);
            FindNaturalSiblingMatches(mergeDB, commandBuider);

            if (commandBuider.HasRowVersion)
            {
                SetMasterRowVersion(mergeDB, commandBuider);//master row version is used to determine which file has the changes in the case where the master can update the component.
            }

            if (commandBuider.MergeNewFromMaster)
            {
                ProcessMasterNew(mergeDB, commandBuider);//add merge records for records that are new on the master side
            }
        }

        private void FindNaturalSiblingMatches(DAL mergeDB, MergeTableCommandBuilder cmdBldr)
        {
            List<MergeObject> naturalSiblings = mergeDB.Query<MergeObject>(
                "SELECT CompoundNaturalKey, NaturalSiblings FROM (" +
                "SELECT CompoundNaturalKey, group_concat(MergeRowID, ',') as NaturalSiblings, count(1) as size FROM " + cmdBldr.MergeTableName +
                " GROUP BY CompoundNaturalKey) WHERE size > 1;");

            string setNaturalSiblings = "UPDATE " + cmdBldr.MergeTableName + " SET NaturalSiblings = ? WHERE CompoundNaturalKey = ?;";
            foreach (MergeObject groups in naturalSiblings)
            {
                mergeDB.Execute(setNaturalSiblings, groups.NaturalSiblings, groups.CompoundNaturalKey);
            }
        }

        private void SetPartialMatches(DAL mergeDB, MergeTableCommandBuilder cmdBldr)
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

            List<MergeObject> partialMatchs = mergeDB.Query<MergeObject>(selectPartialMatches);
            string setPartialMatch = "UPDATE " + cmdBldr.MergeTableName + " SET PartialMatch = ? WHERE MergeRowID = ?;";
            foreach (MergeObject mRec in partialMatchs)
            {
                mergeDB.Execute(setPartialMatch, mRec.PartialMatch, mRec.MergeRowID);
            }
        }

        private void ProcessComparisons(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            if (cmdBldr.DoKeyMatch)
            {
                CheckWorkerStatus();
                _workInCurrentJob += 1;

                string setKeyMatch = "UPDATE " + cmdBldr.MergeTableName + " SET RowIDMatch = ? WHERE MergeRowID = ?;";
                foreach (MergeObject item in master.Query<MergeObject>(cmdBldr.SelectRowIDMatches))
                {
                    master.Execute(setKeyMatch, item.RowIDMatch, item.MergeRowID);
                }

                this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
            }

            if (cmdBldr.DoNaturalMatch)
            {
                CheckWorkerStatus();
                _workInCurrentJob += 1;

                string setNatMatch = "UPDATE " + cmdBldr.MergeTableName + " SET NaturalMatch = ? WHERE MergeRowID = ?;";
                foreach (MergeObject mRec in master.Query<MergeObject>(cmdBldr.SelectNaturalMatches))
                {
                    master.Execute(setNatMatch, mRec.NaturalMatch, mRec.MergeRowID);
                }

                this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
            }

            if (cmdBldr.HasGUIDKey)
            {
                CheckWorkerStatus();
                _workInCurrentJob += 1;

                Dictionary<Guid, long> rowIDLookUp = new Dictionary<Guid, long>();
                foreach (var pair in master.Query<GuidRowID>($"Select {cmdBldr.ClientGUIDFieldName} AS Guid, {cmdBldr.ClientPrimaryKey.Name} AS RecID FROM main.{cmdBldr.ClientTableName} WHERE {cmdBldr.ClientGUIDFieldName} IS NOT NULL AND {cmdBldr.ClientGUIDFieldName} NOT LIKE '';"))
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

                this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);

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

        private void ProcessFullMatchs(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            List<MergeObject> matches = master.Query<MergeObject>(cmdBldr.SelectFullMatches);

            this._workInCurrentJob += matches.Count;

            string setMatches = "UPDATE " + cmdBldr.MergeTableName + " SET MatchRowID = ? WHERE MergeRowID = ?;";
            foreach (MergeObject item in matches)
            {
                CheckWorkerStatus();
                master.Execute(setMatches, cmdBldr.GetMatchRowID(item), item.MergeRowID);
                this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
            }
        }

        private void IdentifySiblingRecords(DAL master, MergeTableCommandBuilder cmdBldr)
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

            List<MergeObject> siblingsGroups = master.Query<MergeObject>(selectSiblings);
            string setSiblingsformat = "UPDATE " + cmdBldr.MergeTableName + " SET SiblingRecords = ifnull(SiblingRecords, '') || ?  WHERE MergeRowID in ({0});";
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

        private void SetMasterRowVersion(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            string setMasterRowVersion = "UPDATE " + cmdBldr.MergeTableName + " SET MasterRowVersion = " +
                "(SELECT RowVersion FROM " + cmdBldr.ClientTableName + " AS client WHERE client.RowID = MatchRowID);";

            master.Execute(setMasterRowVersion);
        }

        private void ProcessMasterNew(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            foreach (ComponentFileVM comp in this.Components)
            {
                string insertMissingMatch = "INSERT INTO " + cmdBldr.MergeTableName + " (MatchRowID, ComponentID) " +
                    "VALUES (?,?);";
                foreach (MergeObject mRec in master.Query<MergeObject>(cmdBldr.SelectMissingMatches(comp)))
                {
                    master.Execute(insertMissingMatch, mRec.MatchRowID, comp.Component_CN);
                }
            }
        }

        #region IDisposable Members

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._thread != null)
                {
                    if (this._thread.IsAlive)
                    {
                        this._thread.Abort();
                    }
                    this._thread = null;
                }

                this.MergePresenter = null;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        #endregion IDisposable Members

        #region IWorker Members

        private object _threadLock = new object();
        private bool _isCanceled;
        private bool _isDone;
        private Thread _thread;
        private int _workInCurrentJob = 1;
        private int _progressInCurrentJob;

        public string ActionName { get { return "Check Files"; } }

        public bool IsDone
        {
            get
            {
                lock (_threadLock)
                {
                    return _isDone;
                }
            }
            private set
            {
                lock (_threadLock)
                {
                    _isDone = value;
                }
            }
        }

        public bool IsWorking
        {
            get
            {
                if (_thread == null) { return false; }
                return _thread.IsAlive;
            }
        }

        public bool IsCanceled
        {
            get
            {
                lock (_threadLock)
                {
                    return _isCanceled;
                }
            }
            private set
            {
                lock (_threadLock)
                {
                    _isCanceled = value;
                }
            }
        }

        public void Cancel()
        {
            if (this._thread != null)
            {
                this.IsCanceled = true;
                if (!this._thread.Join(1000))
                {
                    this._thread.Abort();
                }
            }
        }

        public bool Wait()
        {
            if (this._thread != null)
            {
                this._thread.Join();
            }
            return this.IsDone;
        }

        private string _currentJobName;
        //private Stopwatch _stopwatch;

        private void StartJob(string name)
        {
            //if (_stopwatch != null) { _stopwatch.Stop(); }
            //_stopwatch = Stopwatch.StartNew();
            _currentJobName = name;
            this.PostStatus(name);
            System.Diagnostics.Debug.WriteLine("Started job component " + name);
        }

        private void EndJob()
        {
            //if (_stopwatch != null)
            //{
            //    _stopwatch.Stop();
            //    Debug.WriteLine("Ended job component " + _currentJobName + " in " + _stopwatch.ElapsedMilliseconds + "mSec");
            //}
            this.PostStatus(_currentJobName + ": done");
            _currentJobName = null;
        }

        protected void PostStatus(string message)
        {
            this.NotifyProgressChanged(this._progressInCurrentJob, false, message, null);
        }

        #endregion IWorker Members
    }
}