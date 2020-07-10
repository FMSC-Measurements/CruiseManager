using Backpack.SqlBuilder;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.Components.CommandBuilders;
using FMSC.ORM.EntityModel.Support;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components
{
    /*
 *
 * Y = implemented, N = not implimented, NP =  not planned
 * - push cutting unit inserts : Y
 * - push cutting unit updates : N
 * - push stratum inserts : Y
 * - push stratum updates : N
 * - push new cutting unit/stratm mappings : Y
 * - push removed cutting unit/stratm mappings : Y
 * - push samplegroups inserts : Y
 * - push samplegroup updates : N
 * - pull samplegroups inserts : Y
 * - pull samplegroup updates : N
 * - match samplegroups : N
 * - push tree defaults inserts : Y
 * - push tree default updates : N
 * - pull tree defaults inserts : Y
 * - pull tree default updates : N
 * - match new tree defaults : N
 * - push new tree default/sg mappings : Y
 * - push removed tree default/sg mappings : N
 * - pull new tree default/sg mappings : Y

 * - pull count tree inserts : Y
 * - pull count tree updates : Y
 * - push count tree inserts : NP
 * - push count tree updates : NP

 * - pull plot inserts : Y
 * - pull plot updates : Y
 * - push plot inserts : NP
 * - push plot updates : Y

 * - pull tree inserts : Y
 * - pull tree updates : Y
 * - push tree inserts : NP
 * - push tree updates : Y

 * - pull stem inserts : Y
 * - pull stem updates : Y
 * - push stem inserts : NP
 * - push stem updates : Y

 * - pull lot inserts : Y
 * - pull log updates : Y
 * - push log inserts : NP
 * - push log updates : Y
 * */

    public class MergeSyncWorker
    {
        public const string COMP_ALIAS = "comp";

        #region move methods

        private static void MoveUnit(DAL database, string dbAlias, long fromUnit_CN, long toUnit_CN)
        {
            database.Execute(
$@"UPDATE {dbAlias}.CuttingUnit SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;
UPDATE {dbAlias}.CuttingUnitStratum SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;
UPDATE {dbAlias}.Plot SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;
UPDATE {dbAlias}.Tree SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;
UPDATE {dbAlias}.CountTree SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;", toUnit_CN, fromUnit_CN);
        }

        private static void MoveSt(DAL database, string dbAlias, long fromSt_CN, long toSt_CN)
        {
            database.Execute(
$@"UPDATE {dbAlias}.Stratum SET Stratum_CN = @p1 WHERE Stratum_CN = @p2;
UPDATE {dbAlias}.SampleGroup SET Stratum_CN = @p1 WHERE Stratum_CN = @p2;
UPDATE {dbAlias}.Plot SET Stratum_CN = @p1 WHERE Stratum_CN = @p2;
UPDATE {dbAlias}.CuttingUnitStratum SET Stratum_CN = @p1 WHERE Stratum_CN = @p2;
UPDATE {dbAlias}.Tree SET Stratum_CN = @p1 WHERE Stratum_CN = @p2;
UPDATE {dbAlias}.FixCNTTallyClass SET Stratum_CN = @p1 WHERE Stratum_CN = @p2;
UPDATE {dbAlias}.StratumStats SET Stratum_CN = @p1 WHERE Stratum_CN = @p2;", toSt_CN, fromSt_CN);
        }

        private static void MoveSg(DAL database, string dbAlias, long fromSG_CN, long toSG_CN)
        {
            database.Execute(
$@"UPDATE {dbAlias}.SampleGroup SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.SampleGroupTreeDefaultValue SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.CountTree SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.Tree SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.SamplerState SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.FixCNTTallyPopulation SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;", toSG_CN, fromSG_CN);
        }

        public static void MoveTDV(DAL database, string dbAlias, long fromTDV_CN, long toTDV_CN)
        {
            database.Execute(
$@"UPDATE {dbAlias}.TreeDefaultValue SET TreeDefaultValue_CN = @p1 WHERE TreeDefaultValue_CN = @p2;
UPDATE {dbAlias}.SampleGroupTreeDefaultValue SET TreeDefaultValue_CN = @p1 WHERE TreeDefaultValue_CN = @p2;
UPDATE {dbAlias}.CountTree SET TreeDefaultValue_CN = @p1 WHERE TreeDefaultValue_CN = @p2;
UPDATE {dbAlias}.Tree SET TreeDefaultValue_CN = @p1 WHERE TreeDefaultValue_CN = @p2;
UPDATE {dbAlias}.FixCNTTallyPopulation SET TreeDefaultValue_CN = @p1 WHERE TreeDefaultValue_CN = @p2;", toTDV_CN, fromTDV_CN);
        }

        #endregion move methods

        #region core

        public static void SyncDesign(DAL master, IEnumerable<ComponentFile> components, CancellationToken cancellation, IProgress<int> progress, IMergeLog log)
        {
            foreach (var comp in components)
            {
                cancellation.ThrowIfCancellationRequested();

                try
                {
                    PullDesignChanges(master, comp, progress, log);
                }
                catch (Exception e)
                {
                    comp.MergeException = e;
                }
            }

            foreach (var comp in components)
            {
                cancellation.ThrowIfCancellationRequested();
                if (comp.HasMergeError)
                { continue; }

                try
                {
                    PushDesignChanges(master, comp, progress, log);
                }
                catch (Exception e)
                {
                    comp.MergeException = e;
                }
            }
        }

        public static void PullDesignChanges(DAL master, ComponentFile comp, IProgress<int> progress, IMergeLog log)
        {
            log?.PostStatus($"Start Pull Design Component {comp.Component_CN}");
            AttachComponent(master, comp.Database);
            master.BeginTransaction();
            try
            {
                PullTreeDefault(master, progress, log);
                PullSampleGroup(master, progress, log);
                PullSampleGroupTreeDefault(master, progress, log);
                PullTally(master, progress, log);
                PullCountTree(master, comp.Component_CN.Value, progress, log);

                master.CommitTransaction();
                log?.PostStatus($"Pull Design Component {comp.Component_CN} Done");
            }
            catch (Exception e)
            {
                master.RollbackTransaction();
                log?.PostStatus($"Pull Design Component {comp.Component_CN} Failed");
                throw;
            }
            finally
            {
                DetachComponent(master);
            }
        }

        public static void PushDesignChanges(DAL master, ComponentFile comp, IProgress<int> progress, IMergeLog log)
        {
            log?.PostStatus($"Start Push Design Component {comp.Component_CN}");
            AttachComponent(master, comp.Database);
            master.BeginTransaction();
            try
            {
                PushCuttingUnit(master, progress, log);
                PushStratum(master, progress, log);
                PushCuttingUnitStratum(master, progress, log);
                PushSampleGroup(master, progress, log);
                PushTreeDefault(master, progress, log);
                PushSampleGroupTreeDefault(master, progress, log);
                PushCountTrees(master, comp.Component_CN.Value, progress, log);

                master.CommitTransaction();
                log?.PostStatus($"Pull Design Component {comp.Component_CN} Done");
            }
            catch (Exception e)
            {
                master.RollbackTransaction();
                log?.PostStatus($"Pull Design Component {comp.Component_CN} Failed");
                throw;
            }
            finally
            {
                DetachComponent(master);
            }
        }

        public static void SyncFieldData(DAL master, IEnumerable<ComponentFile> components, IDictionary<string, MergeTableCommandBuilder> commandBuilders, CancellationToken cancellation, IProgress<int> progress, IMergeLog log)
        {
            BeginTransactionAll();
            try
            {
                UpdateMaster(master, components, commandBuilders, cancellation, progress, log);
                UpdateComponents(master, components, commandBuilders, cancellation, progress, log);

                CommitTransactionAll();
            }
            catch
            {
                RollbackTransactionAll();
                throw;
            }

            void BeginTransactionAll()
            {
                master.BeginTransaction();
                foreach (var comp in components)
                {
                    comp.Database.BeginTransaction();
                }
            }

            void RollbackTransactionAll()
            {
                master.RollbackTransaction();
                foreach (var comp in components)
                {
                    comp.Database.RollbackTransaction();
                }
            }

            void CommitTransactionAll()
            {
                master.CommitTransaction();
                foreach (var comp in components)
                {
                    comp.Database.CommitTransaction();
                }
            }
        }

        public static void UpdateComponents(DAL master, IEnumerable<ComponentFile> components, IDictionary<string, MergeTableCommandBuilder> commandBuilders, CancellationToken cancellation, IProgress<int> progress, IMergeLog log)
        {
            var plotCmdBldr = commandBuilders["Plot"];
            var treeCmdBldr = commandBuilders["Tree"];
            var logCmdBldr = commandBuilders["Log"];
            //var stemCmdBldr = commandBuilders["Stem"];

            log?.StartJob();

            foreach (var comp in components)
            {
                if (comp.HasMergeError == true)
                { continue; }

                cancellation.ThrowIfCancellationRequested();
                PushComponentPlotUpdates(master, comp, plotCmdBldr, progress, log);

                cancellation.ThrowIfCancellationRequested();
                PushComponentTreeUpdates(master, comp, treeCmdBldr, progress, log);

                cancellation.ThrowIfCancellationRequested();
                PushComponentLogUpdates(master, comp, logCmdBldr, progress, log);

                //cancellation.ThrowIfCancellationRequested();
                //PushComponentStemUpdates(master, comp, stemCmdBldr, progress, log);
            }
            log?.EndJob();

        }

        public static void UpdateMaster(DAL master, IEnumerable<ComponentFile> components, IDictionary<string, MergeTableCommandBuilder> commandBuilders, CancellationToken cancellation, IProgress<int> progress, IMergeLog log)
        {
            var plotCommandBuilder = commandBuilders["Plot"];
            var treeCmdBldr = commandBuilders["Tree"];
            var logCmdBldr = commandBuilders["Log"];
            //var stemCmdBldr = commandBuilders["Stem"];

            log?.StartJob();

            foreach (var comp in components)
            {
                if (comp.HasMergeError == true)
                { continue; }

                cancellation.ThrowIfCancellationRequested();

                PullNewPlotRecords(master, comp, plotCommandBuilder, progress, log);
                PullMasterPlotUpdates(master, comp, plotCommandBuilder, progress, log);
                cancellation.ThrowIfCancellationRequested();

                PullNewTreeRecords(master, comp, treeCmdBldr, progress, log);
                PullMasterTreeUpdates(master, comp, treeCmdBldr, progress, log);
                cancellation.ThrowIfCancellationRequested();

                PullNewLogRecords(master, comp, logCmdBldr, progress, log);
                PullMasterLogUpdates(master, comp, logCmdBldr, progress, log);
                cancellation.ThrowIfCancellationRequested();

                //PullNewStemRecords(master, comp, stemCmdBldr, progress, log);
                //PullMasterStemUpdates(master, comp, stemCmdBldr, progress, log);
                //cancellation.ThrowIfCancellationRequested();
            }

            log?.EndJob();
        }

        #endregion core

        #region transaction and attach

        private static void AttachComponent(DAL master, DAL comp)
        {
            master.AttachDB(comp, COMP_ALIAS);
        }

        private static void DetachComponent(DAL master)
        {
            master.DetachDB(COMP_ALIAS);
        }

        

        #endregion transaction and attach

        #region pull new records

        //public void PullNew(MergeTableCommandBuilder cmdBldr, ComponentFileVM comp)
        //{
        //    StartJob("Pull New From " + cmdBldr.ClientTableName);
        //    var mergeRecords = cmdBldr.ListNewRecords(Master, comp);

        //    foreach (MergeObject mRec in mergeRecords)
        //    {
        //        CheckWorkerStatus();
        //        DataObject newFromComp = cmdBldr.ReadSingleRow(comp.Database, mRec.ComponentRowID.Value);
        //        Master.Insert(newFromComp, option: OnConflictOption.Fail);
        //        ResetComponentRowVersion(comp.Database, mRec.ComponentRowID.Value, cmdBldr);
        //    }

        //    EndJob("Pull New From " + cmdBldr.ClientTableName);
        //}

        public static void PullNewLogRecords(DAL master, ComponentFile comp, MergeTableCommandBuilder logCmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var mergeRecords = logCmdBldr.ListNewRecords(master, comp);
            var unitsOfWork = mergeRecords.Count();
            var i = 0;
            var compDB = comp.Database;
            foreach (MergeObject mRec in mergeRecords)
            {
                LogDO logRec = compDB.From<LogDO>()
                    .Where("rowid = @p1").Query(mRec.ComponentRowID).FirstOrDefault();
                master.Insert(logRec, option: OnConflictOption.Fail);
                ResetComponentRowVersion(compDB, mRec.ComponentRowID.Value, logCmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PullNewPlotRecords(DAL master, ComponentFile comp, MergeTableCommandBuilder plotCmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var mergeRecords = plotCmdBldr.ListNewRecords(master, comp);
            var unitsOfWork = mergeRecords.Count();
            var i = 0;
            foreach (MergeObject mRec in mergeRecords)
            {
                PlotDO plot = comp.Database.From<PlotDO>()
                    .Where("rowid = @p1").Query(mRec.ComponentRowID).FirstOrDefault();

                master.Insert(plot, option: OnConflictOption.Fail);
                ResetComponentRowVersion(comp.Database, mRec.ComponentRowID.Value, plotCmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }
            log?.EndJob();
        }

        public static void PullNewStemRecords(DAL master, ComponentFile comp, MergeTableCommandBuilder stemCmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var mergeRecords = stemCmdBldr.ListNewRecords(master, comp);
            var unitsOfWork = mergeRecords.Count();
            var i = 0;

            foreach (MergeObject mRec in mergeRecords)
            {
                StemDO stem = comp.Database.From<StemDO>()
                    .Where("rowid = @p1").Query(mRec.ComponentRowID).FirstOrDefault();

                master.Insert(stem, option: OnConflictOption.Fail);
                ResetComponentRowVersion(comp.Database, mRec.ComponentRowID.Value, stemCmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PullNewTreeRecords(DAL master, ComponentFile comp, MergeTableCommandBuilder treeCmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();
            var mergeRecords = treeCmdBldr.ListNewRecords(master, comp);
            var unitsOfWork = mergeRecords.Count();
            var i = 0;

            foreach (MergeObject mRec in mergeRecords)
            {
                TreeDO tree = comp.Database.From<TreeDO>()
                    .Where("rowid = @p1").Query(mRec.ComponentRowID).FirstOrDefault();
                master.Insert(tree, option: OnConflictOption.Fail);
                ResetComponentRowVersion(comp.Database, mRec.ComponentRowID.Value, treeCmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        #endregion pull new records

        #region pull new design records

        public static void PullTally(DAL master, IProgress<int> progress = null, IMergeLog log = null)
        {
            log?.StartJob();
            var compTallies = master.From<TallyDO>(new TableOrSubQuery($"{COMP_ALIAS}.Tally")).Query();

            foreach (TallyDO tally in compTallies)
            {
                TallyDO match = master.From<TallyDO>()
                    .Where("HotKey = @p1 AND Description = @p2")
                    .Query(tally.Hotkey, tally.Description).FirstOrDefault();

                if (match == null)
                {
                    match = new TallyDO()
                    {
                        Hotkey = tally.Hotkey,
                        Description = tally.Description,
                    };
                    master.Insert(match);
                    log?.PostStatus($"Added Tally {match.Tally_CN}");
                }
            }
            log?.EndJob();
        }

        public static void PullCountTree(DAL master, long component_cn, IProgress<int> progress = null, IMergeLog log = null)
        {
            log?.StartJob();
            var compCounts = master.From<CountTreeDO>(new TableOrSubQuery($"{COMP_ALIAS}.CountTree")).Query().ToArray();

            var unitsOfWork = compCounts.Length;
            var i = 0;
            foreach (CountTreeDO count in compCounts)
            {
                var compTally = master.From<TallyDO>(new TableOrSubQuery($"{COMP_ALIAS}.Tally"))
                    .Where("Tally_CN = @p1")
                    .Query(count.Tally_CN).FirstOrDefault();

                // try to read component count tree record from master
                CountTreeDO match = master.From<CountTreeDO>()
                    .Where("SampleGroup_CN = @p1 " +
                    "AND ifnull(TreeDefaultValue_CN, 0) = ifnull(@p2, 0) " +
                    "AND CuttingUnit_CN = @p3 " +
                    "AND Component_CN = @p4")
                    .Query(count.SampleGroup_CN,
                    count.TreeDefaultValue_CN,
                    count.CuttingUnit_CN,
                    component_cn).FirstOrDefault();
                //use component cn from component record because component cn is not set when record is created by FScruiser

                if (match != null)
                {
                    // update component count tree data
                    match.TreeCount = count.TreeCount;
                    match.SumKPI = count.SumKPI;
                    master.Update(match);
                }
                else
                {
                    // attempt to create a component count tree record in the master

                    // see if tally table entry exists matching the description and hotkey
                    TallyDO tally = master.Query<TallyDO>($"SELECT * FROM {COMP_ALIAS}.Tally WHERE Tally_CN = {count.Tally_CN};").FirstOrDefault();

                    TallyDO masterTally = master.From<TallyDO>().Where("Description = @p1 AND HotKey = @p2")
                        .Query(tally.Description, tally.Hotkey).FirstOrDefault();

                    // if not create one
                    if (masterTally == null)
                    {
                        masterTally = new TallyDO()
                        {
                            Description = tally.Description,
                            Hotkey = tally.Hotkey,
                        };
                        master.Insert(masterTally);
                        log?.PostStatus($"Tally added :{masterTally.Tally_CN}");
                    }

                    var newCount = new CountTreeDO()
                    {
                        CuttingUnit_CN = count.CuttingUnit_CN,
                        SampleGroup_CN = count.SampleGroup_CN,
                        TreeDefaultValue_CN = count.TreeDefaultValue_CN,
                        SumKPI = count.SumKPI,
                        TreeCount = count.TreeCount,
                        Component_CN = count.Component_CN ?? component_cn,
                        Tally_CN = masterTally.Tally_CN,
                    };
                    master.Insert(newCount, option: OnConflictOption.Fail);
                    log?.PostStatus($"CountTree added :{newCount.CountTree_CN}");
                }

                // see if there is a master count tree record match our count tree record
                // is is important because it is posible to add populations in fscruiser
                // and if a new tally setup was done to the component but not the master
                // we will need a master count tree record to push the new tally setup out to the other components
                var masterMatch = master.From<CountTreeDO>()
                    .Where("SampleGroup_CN = @p1 " +
                    "AND ifnull(TreeDefaultValue_CN, 0) = ifnull(@p2, 0) " +
                    "AND CuttingUnit_CN = @p3 " +
                    "AND Component_CN IS NULL")
                    .Query(count.SampleGroup_CN,
                    count.TreeDefaultValue_CN,
                    count.CuttingUnit_CN).FirstOrDefault();

                if (masterMatch == null)
                {
                    TallyDO tally = master.Query<TallyDO>($"SELECT * FROM {COMP_ALIAS}.Tally WHERE Tally_CN = {count.Tally_CN};").FirstOrDefault();

                    TallyDO masterTally = master.From<TallyDO>().Where("Description = @p1 AND HotKey = @p2")
                        .Query(tally.Description, tally.Hotkey).FirstOrDefault();

                    if (masterTally == null)
                    {
                        masterTally = new TallyDO()
                        {
                            Description = tally.Description,
                            Hotkey = tally.Hotkey,
                        };
                        master.Insert(masterTally);
                        log?.PostStatus($"Tally added :{masterTally.Tally_CN}");
                    }

                    masterMatch = new CountTreeDO()
                    {
                        Component_CN = null,
                        TreeCount = 0,
                        SumKPI = 0,

                        CuttingUnit_CN = count.CuttingUnit_CN,
                        SampleGroup_CN = count.SampleGroup_CN,
                        TreeDefaultValue_CN = count.TreeDefaultValue_CN,
                        Tally_CN = masterTally.Tally_CN,
                    };

                    master.Insert(masterMatch, option: OnConflictOption.Fail, keyValue: null);
                    log?.PostStatus($"Master CountTree added :{masterMatch.CountTree_CN}");
                }

                progress?.Report((++i * 100) / unitsOfWork);
            }
            log?.EndJob();
        }

        public static void PullSampleGroup(DAL master, IProgress<int> progress = null, IMergeLog log = null)
        {
            log?.StartJob();

            var compSGList = master.From<SampleGroupDO>(new TableOrSubQuery(COMP_ALIAS + ".SampleGroup"))
                .Query().ToArray();
            var unitsOfWork = compSGList.Length;
            var i = 0;
            foreach (SampleGroupDO sg in compSGList)
            {
                SampleGroupDO match = master.From<SampleGroupDO>()
                    .Where("Code = @p1 AND Stratum_CN = @p2")
                    .Query(sg.Code, sg.Stratum_CN).FirstOrDefault();

                if (match == null)
                {
                    var newSG = new SampleGroupDO()
                    {
                        Code = sg.Code,
                        Stratum_CN = sg.Stratum_CN,
                        BigBAF = sg.BigBAF,
                        BiomassProduct = sg.BiomassProduct,
                        CreatedBy = sg.CreatedBy,
                        CreatedDate = sg.CreatedDate,
                        CutLeave = sg.CutLeave,
                        DefaultLiveDead = sg.DefaultLiveDead,
                        Description = sg.Description,
                        InsuranceFrequency = sg.InsuranceFrequency,
                        KZ = sg.KZ,
                        MaxKPI = sg.MaxKPI,
                        MinKPI = sg.MinKPI,
                        PrimaryProduct = sg.PrimaryProduct,
                        SampleSelectorType = sg.SampleSelectorType,
                        SamplingFrequency = sg.SamplingFrequency,
                        SecondaryProduct = sg.SecondaryProduct,
                        SmallFPS = sg.SmallFPS,
                        TallyMethod = sg.TallyMethod,
                        UOM = sg.UOM,
                    };

                    var newSG_CN = (master.ExecuteScalar<int>($"SELECT count(*) FROM SampleGroup WHERE SampleGroup_CN = @p1;", sg.SampleGroup_CN) == 0)
                        ? sg.SampleGroup_CN
                        : (long?)null;

                    master.Insert(newSG, keyValue: newSG_CN);
                    match = newSG;
                    log?.PostStatus($"Sample Group added :{newSG.SampleGroup_CN}");
                }
                if (sg.SampleGroup_CN != match.SampleGroup_CN)
                {
                    var matchSG_CN = match.SampleGroup_CN.Value;
                    var compSG_CN = sg.SampleGroup_CN.Value;

                    // check comp and if there already has a SG with the CN of our match
                    if (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.SampleGroup WHERE SampleGroup_CN = @p1;", matchSG_CN)
                        > 0)
                    {
                        // to resolve the CN conflict we are going to move the conflicting record to the end of our table
                        var newSG_CN = master.ExecuteScalar<int>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'SampleGroup';");

                        // we also need to find the DO of the sample group we are displacing 
                        // so that we can update its CN value to the new CN
                        var toMoveSG = compSGList.Single(x => x.SampleGroup_CN == matchSG_CN);
                        toMoveSG.SampleGroup_CN = newSG_CN;

                        MoveSg(master, COMP_ALIAS, matchSG_CN, newSG_CN);
                        log?.PostStatus($"Sample Group swap :{matchSG_CN} -> {newSG_CN}");
                    }

                    // finaly move the comp SG CN value to match the master
                    MoveSg(master, COMP_ALIAS, compSG_CN, matchSG_CN);
                    log?.PostStatus($"Sample Group mismatch resolved :{compSG_CN} -> {matchSG_CN}");
                }

                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PullSampleGroupTreeDefault(DAL master, IProgress<int> progress = null, IMergeLog log = null)
        {
            log?.StartJob();

            int? rowsAffected = master.Execute("INSERT OR IGNORE INTO main.SampleGroupTreeDefaultValue " +
                "SELECT * FROM " + COMP_ALIAS + ".SampleGroupTreeDefaultValue;");

            log?.PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected");

            log?.EndJob();
        }

        public static void PullTreeDefault(DAL master, IProgress<int> progress = null, IMergeLog log = null)
        {
            log?.StartJob();
            var compTreeDefaults = master.From<TreeDefaultValueDO>(new TableOrSubQuery(COMP_ALIAS + ".TreeDefaultValue"))
                .Query().ToArray();
            var unitsOfWork = compTreeDefaults.Length;

            var i = 0;
            foreach (var tdv in compTreeDefaults)
            {
                var match = master.From<TreeDefaultValueDO>().Where("Species = @p1 AND PrimaryProduct = @p2 AND LiveDead = @p3")
                    .Query(tdv.Species, tdv.PrimaryProduct, tdv.LiveDead).FirstOrDefault();

                if (match == null)
                {
                    var newTDV = new TreeDefaultValueDO(master);
                    newTDV.SetValues(tdv);
                    master.Insert(newTDV, option: OnConflictOption.Fail);

                    match = newTDV;
                    log.PostStatus($"TDV added :{newTDV.TreeDefaultValue_CN}");
                }

                if (tdv.TreeDefaultValue_CN != match.TreeDefaultValue_CN)
                {
                    var matchTDV_CN = match.TreeDefaultValue_CN.Value;
                    var compTDB_CN = tdv.TreeDefaultValue_CN.Value;

                    if (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.TreeDefaultValue WHERE TreeDefaultValue_CN = @p1;", matchTDV_CN)
                        > 0)
                    {
                        // move the conflicting comp TDV to a new CN
                        var newTDV_CN = master.ExecuteScalar<int>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'TreeDefaultValue';");

                        var toMoveTDV = compTreeDefaults.FirstOrDefault(x => x.TreeDefaultValue_CN == matchTDV_CN);
                        if (toMoveTDV != null)
                        {
                            toMoveTDV.TreeDefaultValue_CN = newTDV_CN;
                        }

                        MoveTDV(master, COMP_ALIAS, matchTDV_CN, newTDV_CN);
                        log.PostStatus($"TDV swap :{matchTDV_CN} -> {newTDV_CN}");
                    }

                    // move component tdv to match the master tdv
                    MoveTDV(master, COMP_ALIAS, compTDB_CN, matchTDV_CN);
                    log.PostStatus($"TDV mismatch resolved :{compTDB_CN} -> {matchTDV_CN}");
                }

                progress?.Report((++i * 100) / unitsOfWork);
            }

            log.EndJob();
        }

        #endregion pull new design records

        #region push new design records

        public static void PushCountTrees(DAL master, long component_cn, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var countTrees = master.Query<CountTreeDO>("SELECT * FROM main.CountTree WHERE Component_CN IS NULL;").ToArray();
            var unitsOfWork = countTrees.Length;
            var i = 0;
            foreach (var ct in countTrees)
            {
                var mastCN = ct.CountTree_CN;

                var match = master.From<CountTreeDO>(new TableOrSubQuery($"{COMP_ALIAS}.CountTree"))
                    .Where("CuttingUnit_CN = @p1 AND SampleGroup_CN = @p2 AND ifnull(TreeDefaultValue_CN, 0) == ifnull(@p3, 0)")
                    .Query(ct.CuttingUnit_CN, ct.SampleGroup_CN, ct.TreeDefaultValue_CN)
                    .FirstOrDefault();

                if (match == null)
                {
                    // see if component has matching tally record
                    var tallyMatch = master.Query<TallyDO>($"SELECT * FROM {COMP_ALIAS}.Tally WHERE Tally_CN = @p1;", ct.Tally_CN).FirstOrDefault();

                    if (tallyMatch == null)
                    {
                        // get the full tally record from the master
                        var masterTally = master.Query<TallyDO>("SELECT * FROM main.Tally WHERE Tally_CN = @p1;", ct.Tally_CN).FirstOrDefault();

                        // insert tally record into the component
                        var newTally = new TallyDO()
                        {
                            Description = masterTally.Description,
                            Hotkey = masterTally.Hotkey,
                        };

                        var tally_CN = master.Insert(newTally, tableName: $"{COMP_ALIAS}.Tally");
                        tallyMatch = newTally;

                        log?.PostStatus($"Tally added :{tally_CN}");
                    }

                    var newCt = new CountTreeDO()
                    {
                        CuttingUnit_CN = ct.CuttingUnit_CN,
                        SampleGroup_CN = ct.SampleGroup_CN,
                        TreeDefaultValue_CN = ct.TreeDefaultValue_CN,
                        Tally_CN = tallyMatch.Tally_CN,
                        Component_CN = component_cn,
                    };

                    // insert the count tree record into the component
                    var newCt_cn = master.Insert(newCt, tableName: $"{COMP_ALIAS}.CountTree");
                    log?.PostStatus($"CountTree added :{newCt_cn}");

                }
                progress?.Report((++i * 100) / unitsOfWork);
            }
            log?.EndJob();
        }

        public static void PushSampleGroup(DAL master, IProgress<int> progress, IMergeLog log)
        {
            var compSGEntDisc = new EntityDescription(typeof(SampleGroupDO));
            compSGEntDisc.Source = new TableOrSubQuery($"{COMP_ALIAS}.SampleGroup");

            log?.StartJob();

            var sampleGroups = master.From<SampleGroupDO>().Query().ToArray();
            var unitsOfWork = sampleGroups.Length;
            var i = 0;
            foreach (var sg in sampleGroups)
            {
                var mastCN = sg.SampleGroup_CN;

                var match = master.From<SampleGroupDO>(new TableOrSubQuery($"{COMP_ALIAS}.SampleGroup"))
                    .Where("Code = @p1 AND Stratum_CN = @p2").Query(sg.Code, sg.Stratum_CN).FirstOrDefault();

                if (match == null)
                {
                    var newSG = new SampleGroupDO()
                    {
                        Code = sg.Code,
                        Stratum_CN = sg.Stratum_CN,
                        BigBAF = sg.BigBAF,
                        BiomassProduct = sg.BiomassProduct,
                        CreatedBy = sg.CreatedBy,
                        CreatedDate = sg.CreatedDate,
                        CutLeave = sg.CutLeave,
                        DefaultLiveDead = sg.DefaultLiveDead,
                        Description = sg.Description,
                        InsuranceFrequency = sg.InsuranceFrequency,
                        KZ = sg.KZ,
                        MaxKPI = sg.MaxKPI,
                        MinKPI = sg.MinKPI,
                        PrimaryProduct = sg.PrimaryProduct,
                        SampleSelectorType = sg.SampleSelectorType,
                        SamplingFrequency = sg.SamplingFrequency,
                        SecondaryProduct = sg.SecondaryProduct,
                        SmallFPS = sg.SmallFPS,
                        TallyMethod = sg.TallyMethod,
                        UOM = sg.UOM,
                    };

                    var sg_cn = (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.SampleGroup WHERE SampleGroup_CN = @p1", mastCN) == 0)
                        ? mastCN
                        : (long?)null;

                    var newSG_CN = master.Insert(newSG, tableName: $"{COMP_ALIAS}.SampleGroup", keyValue: sg_cn);
                    match = newSG;
                    log?.PostStatus($"SampleGroup added :{newSG_CN}");
                }

                var matchCN = match.SampleGroup_CN;
                if (matchCN != mastCN)
                {
                    if (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.SampleGroup WHERE SampleGroup_CN = @p1", mastCN) > 0)
                    {
                        var nextSg_CN = master.ExecuteScalar<long>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'SampleGroup';");

                        MoveSg(master, COMP_ALIAS, mastCN.Value, nextSg_CN);
                        log?.PostStatus($"SampleGroup swap :{mastCN} => {nextSg_CN}");
                    }

                    MoveSg(master, COMP_ALIAS, matchCN.Value, mastCN.Value);
                    log?.PostStatus($"SampleGroup mismatch resolved :{matchCN} => {mastCN}");
                }

                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PushStratum(DAL master, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();
            var strata = master.From<StratumDO>().Query().ToArray();
            var unitsOfWork = strata.Length;
            var i = 0;

            foreach (var st in strata)
            {
                var mastCN = st.Stratum_CN;
                var match = master.Query<StratumDO>($"SELECT * FROM {COMP_ALIAS}.Stratum WHERE Code = @p1;", st.Code).FirstOrDefault();

                if (match == null)
                {
                    var newSt = new StratumDO()
                    {
                        Code = st.Code,
                        BasalAreaFactor = st.BasalAreaFactor,
                        CreatedBy = st.CreatedBy,
                        CreatedDate = st.CreatedDate,
                        Description = st.Description,
                        FBSCode = st.FBSCode,
                        FixedPlotSize = st.FixedPlotSize,
                        Hotkey = st.Hotkey,
                        KZ3PPNT = st.KZ3PPNT,
                        Method = st.Method,
                        Month = st.Month,
                        SamplingFrequency = st.SamplingFrequency,
                        VolumeFactor = st.VolumeFactor,
                        Year = st.Year,
                        YieldComponent = st.YieldComponent,
                    };

                    // if we can try to give the stratum the same cn value otherwise we will fix it later
                    var st_cn = (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.Stratum WHERE Stratum_CN = @p1", mastCN) == 0)
                        ? mastCN
                        : (long?)null;
                    master.Insert(newSt, $"{COMP_ALIAS}.Stratum", keyValue: st_cn);
                    match = newSt;

                    log?.PostStatus($"Stratum added :{st_cn}");
                }

                var matchCN = match.Stratum_CN;
                if (match.Stratum_CN != mastCN)
                {
                    if (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.Stratum WHERE Stratum_CN = @p1", st.Stratum_CN) > 0)
                    {
                        var nextSt_CN = master.ExecuteScalar<long>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'Stratum';");

                        MoveSt(master, COMP_ALIAS, mastCN.Value, nextSt_CN);
                        log?.PostStatus($"Stratum swap :{mastCN} => {nextSt_CN}");
                    }

                    MoveSt(master, COMP_ALIAS, matchCN.Value, mastCN.Value);
                    log?.PostStatus($"Stratum mismatch resolved :{matchCN} => {mastCN}");
                }

                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PushCuttingUnit(DAL master, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var units = master.From<CuttingUnitDO>().Query().ToArray();
            var unitsOfWork = units.Length;
            var i = 0;
            foreach (var unit in units)
            {
                var mastCN = unit.CuttingUnit_CN;
                var match = master.From<CuttingUnitDO>(new TableOrSubQuery($"{COMP_ALIAS}.CuttingUnit"))
                    .Where("Code = @p1").Query(unit.Code).FirstOrDefault();

                if (match == null)
                {
                    var newUnit = new CuttingUnitDO()
                    {
                        Code = unit.Code,
                        Area = unit.Area,
                        CreatedBy = unit.CreatedBy,
                        CreatedDate = unit.CreatedDate,
                        Description = unit.Description,
                        LoggingMethod = unit.LoggingMethod,
                        PaymentUnit = unit.PaymentUnit,
                        Rx = unit.Rx,
                    };

                    var unit_CN = (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.CuttingUnit WHERE CuttingUnit_CN = @p1;", mastCN) == 0)
                        ? mastCN
                        : (long?)null;

                    master.Insert(newUnit, tableName: $"{COMP_ALIAS}.CuttingUnit", keyValue: unit_CN);

                    match = newUnit;
                    log?.PostStatus($"Unit added :{unit_CN}");
                }

                var matchCN = match.CuttingUnit_CN;
                if (matchCN != mastCN)
                {
                    if (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.CuttingUnit WHERE CuttingUnit_CN = @p1;", mastCN) > 0)
                    {
                        var nextCu_CN = master.ExecuteScalar<long>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'CuttingUnit';");

                        MoveUnit(master, COMP_ALIAS, mastCN.Value, nextCu_CN);
                        log?.PostStatus($"Unit swap :{mastCN} -> {nextCu_CN}");
                    }
                    MoveUnit(master, COMP_ALIAS, matchCN.Value, mastCN.Value);
                    log?.PostStatus($"Unit mismatch resolved :{matchCN} -> {mastCN}");
                }

                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PushSampleGroupTreeDefault(DAL master, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            int? rowsAffected = master.Execute("INSERT OR IGNORE INTO " + COMP_ALIAS + ".SampleGroupTreeDefaultValue " +
                "SELECT * FROM main.SampleGroupTreeDefaultValue;");

            log?.PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected");
            log?.EndJob();
        }

        public static void PushTreeDefault(DAL master, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var tdvs = master.From<TreeDefaultValueDO>().Query().ToArray();
            var unitsOfWork = tdvs.Length;
            var i = 0;

            foreach (var tdv in tdvs)
            {
                var mastCN = tdv.TreeDefaultValue_CN.Value;
                var match = master.From<TreeDefaultValueDO>(new TableOrSubQuery($"{COMP_ALIAS}.TreeDefaultValue"))
                    .Where("Species = @p1 AND PrimaryProduct = @p2 AND LiveDead = @p3")
                    .Query(tdv.Species, tdv.PrimaryProduct, tdv.LiveDead).FirstOrDefault();

                if (match == null)
                {
                    var newTDV = new TreeDefaultValueDO()
                    {
                        Species = tdv.Species,
                        PrimaryProduct = tdv.PrimaryProduct,
                        LiveDead = tdv.LiveDead,
                        AverageZ = tdv.AverageZ,
                        BarkThicknessRatio = tdv.BarkThicknessRatio,
                        ContractSpecies = tdv.ContractSpecies,
                        CreatedBy = tdv.CreatedBy,
                        CreatedDate = tdv.CreatedDate,
                        CullPrimary = tdv.CullPrimary,
                        CullSecondary = tdv.CullSecondary,
                        FIAcode = tdv.FIAcode,
                        FormClass = tdv.FormClass,
                        HiddenPrimary = tdv.HiddenPrimary,
                        HiddenSecondary = tdv.HiddenSecondary,
                        MerchHeightLogLength = tdv.MerchHeightLogLength,
                        MerchHeightType = tdv.MerchHeightType,
                        Recoverable = tdv.Recoverable,
                        ReferenceHeightPercent = tdv.ReferenceHeightPercent,
                        TreeGrade = tdv.TreeGrade,
                    };

                    var tdv_CN = (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.TreeDefaultValue WHERE TreeDefaultValue_CN = @p1;", mastCN) == 0)
                        ? tdv.TreeDefaultValue_CN
                        : (long?)null;

                    master.Insert(newTDV, tableName: $"{COMP_ALIAS}.TreeDefaultValue", keyValue: tdv_CN);
                    match = newTDV;
                    log?.PostStatus($"TDV added :{tdv_CN}");
                }

                var matchCN = match.TreeDefaultValue_CN.Value;
                if (matchCN != mastCN)
                {
                    if (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.TreeDefaultValue WHERE TreeDefaultValue_CN = @p1;", tdv.TreeDefaultValue_CN) > 0)
                    {
                        var nextTDV_CN = master.ExecuteScalar<long>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'TreeDefaultValue';");

                        MoveTDV(master, COMP_ALIAS, mastCN, nextTDV_CN);
                        log?.PostStatus($"TDV swap :{mastCN} -> {nextTDV_CN}");
                    }

                    MoveTDV(master, COMP_ALIAS, matchCN, mastCN);
                    log?.PostStatus($"TDV missmatch resolved :{matchCN} -> {mastCN}");
                }

                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PushCuttingUnitStratum(DAL master, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            int? rowsAffected = master.Execute("DELETE FROM " + COMP_ALIAS + ".CuttingUnitStratum; " +
                "INSERT OR IGNORE INTO " + COMP_ALIAS + ".CuttingUnitStratum " +
                "SELECT * FROM main.CuttingUnitStratum;");

            log?.PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected");
            log?.EndJob();
        }

        #endregion push new design records

        #region Pull field data updates

        public static void PullMasterLogUpdates(DAL master, ComponentFile comp, MergeTableCommandBuilder treeCmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var pullList = treeCmdBldr.ListMasterUpdates(master, comp);
            var unitsOfWork = pullList.Count();
            var i = 0;

            foreach (MergeObject mRec in pullList)
            {
                long matchRowid = mRec.MatchRowID.Value;
                LogDO logRec = comp.Database.From<LogDO>()
                    .Where("Log_CN = @p1")
                    .Read(mRec.ComponentRowID).FirstOrDefault();
                master.Update(logRec, keyValue: matchRowid, option: OnConflictOption.Fail);
                ResetRowVersion(master, comp, matchRowid, mRec.ComponentRowID.Value, treeCmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }
            log?.EndJob();
        }

        public static void PullMasterPlotUpdates(DAL master, ComponentFile comp, MergeTableCommandBuilder plotCmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();
            var pullList = plotCmdBldr.ListMasterUpdates(master, comp);
            var unitsOfWork = pullList.Count();
            var i = 0;
            foreach (MergeObject mRec in pullList)
            {
                long matchRowid = mRec.MatchRowID.Value;
                var plot = comp.Database.From<PlotDO>()
                    .Where("Plot_CN = @p1").Read(mRec.ComponentRowID).FirstOrDefault();

                master.Update(plot, keyValue: matchRowid, option: OnConflictOption.Fail);
                ResetRowVersion(master, comp, matchRowid, mRec.ComponentRowID.Value, plotCmdBldr);
                progress.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PullMasterStemUpdates(DAL master, ComponentFile comp, MergeTableCommandBuilder stemCmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var pullList = stemCmdBldr.ListMasterUpdates(master, comp);
            var unitsOfWork = pullList.Count();
            var i = 0;
            foreach (MergeObject mRec in pullList)
            {
                long matchRowid = mRec.MatchRowID.Value;
                StemDO stem = comp.Database.From<StemDO>()
                    .Where("Stem_CN = @p1")
                    .Read(mRec.ComponentRowID).FirstOrDefault();

                master.Update(stem, keyValue: matchRowid, option: OnConflictOption.Fail);
                ResetRowVersion(master, comp, matchRowid, mRec.ComponentRowID.Value, stemCmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PullMasterTreeUpdates(DAL master, ComponentFile comp, MergeTableCommandBuilder treeCmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();
            var pullList = treeCmdBldr.ListMasterUpdates(master, comp);
            var unitsOfWork = pullList.Count();
            var i = 0;

            foreach (MergeObject mRec in pullList)
            {
                long matchRowid = mRec.MatchRowID.Value;
                TreeDO tree = comp.Database.From<TreeDO>().Where("rowid = @p1")
                    .Query(mRec.ComponentRowID).FirstOrDefault();
                master.Update(tree, keyValue: matchRowid, option: OnConflictOption.Fail);
                ResetRowVersion(master, comp, matchRowid, mRec.ComponentRowID.Value, treeCmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        #endregion Pull field data updates

        #region push field data updates

        public static void PushComponentLogUpdates(DAL master, ComponentFile comp, MergeTableCommandBuilder cmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var pushList = cmdBldr.ListComponentUpdates(master, comp);
            var unitsOfWork = pushList.Count();
            var i = 0;
            foreach (MergeObject mRec in pushList)
            {
                long matchRowid = mRec.MatchRowID.Value;
                LogDO logRec = master.From<LogDO>()
                    .Where("Log_CN = @p1").Read(matchRowid).FirstOrDefault();

                comp.Database.Update(logRec, keyValue: mRec.ComponentRowID.Value, option: OnConflictOption.Fail);
                ResetRowVersion(master, comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }
            log?.EndJob();
        }

        public static void PushComponentPlotUpdates(DAL master, ComponentFile comp, MergeTableCommandBuilder cmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var pushList = cmdBldr.ListComponentUpdates(master, comp);
            var unitsOfWork = pushList.Count();
            var i = 0;
            foreach (MergeObject mRec in pushList)
            {
                long matchRowid = mRec.MatchRowID.Value;
                PlotDO plot = master.From<PlotDO>()
                    .Where("Plot_CN = @p1").Read(matchRowid).FirstOrDefault();

                comp.Database.Update(plot, keyValue: mRec.ComponentRowID.Value, option: OnConflictOption.Fail);
                ResetRowVersion(master, comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PushComponentStemUpdates(DAL master, ComponentFile comp, MergeTableCommandBuilder cmdBldr, IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();
            var pushList = cmdBldr.ListComponentUpdates(master, comp);
            var unitsOfWork = pushList.Count();
            var i = 0;
            foreach (MergeObject mRec in pushList)
            {
                long matchRowid = mRec.MatchRowID.Value;
                StemDO stem = master.From<StemDO>()
                    .Where("Stem_CN = @p1").Read(matchRowid).FirstOrDefault();

                comp.Database.Update(stem, keyValue: mRec.ComponentRowID.Value, option: OnConflictOption.Fail);
                ResetRowVersion(master, comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }

            log?.EndJob();
        }

        public static void PushComponentTreeUpdates(DAL master, ComponentFile comp, MergeTableCommandBuilder cmdBldr,  IProgress<int> progress, IMergeLog log)
        {
            log?.StartJob();

            var pushList = cmdBldr.ListComponentUpdates(master, comp);
            var unitsOfWork = pushList.Count();
            var i = 0;
            foreach (MergeObject mRec in pushList)
            {
                long matchRowid = mRec.MatchRowID.Value;
                TreeDO tree = master.From<TreeDO>().Where("Tree_CN = @p1")
                    .Read(matchRowid).FirstOrDefault();
                //TODO need to handle condition where MasterRowID is different from ComponentRowID
                comp.Database.Update(tree, keyValue: mRec.ComponentRowID.Value, option: OnConflictOption.Fail);
                ResetRowVersion(master, comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                progress?.Report((++i * 100) / unitsOfWork);
            }
            log?.EndJob();
        }

        #endregion push field data updates

        private static void ResetComponentRowVersion(DAL comp, long componentRowID, MergeTableCommandBuilder commBldr)
        {
            comp.Execute("UPDATE " + commBldr.ClientTableName + " SET RowVersion = 0 WHERE RowID = @p1;", componentRowID);
        }

        private static void ResetRowVersion(DAL master, ComponentFile comp, long masterRowID, long componentRowID, MergeTableCommandBuilder commBldr)
        {
            master.Execute("UPDATE " + commBldr.ClientTableName + " SET RowVersion = 0 WHERE RowID = @p1;", masterRowID);
            ResetComponentRowVersion(comp.Database, componentRowID, commBldr);
        }


        public static Task DoMergeAsync(DAL master, IEnumerable<ComponentFile> components, IDictionary<string, MergeTableCommandBuilder> commandBuilders, CancellationToken cancellation, IProgress<int> progress, IMergeLog log)
        {
            return Task.Run(() => DoMerge(master, components, commandBuilders, cancellation, progress, log));
        }

        public static void DoMerge(DAL master, IEnumerable<ComponentFile> components, IDictionary<string, MergeTableCommandBuilder> commandBuilders, CancellationToken cancellation, IProgress<int> progress, IMergeLog log)
        {
            SyncDesign(master, components, cancellation, progress, log);
            SyncFieldData(master, components, commandBuilders, cancellation, progress, log);
        }
    }
}