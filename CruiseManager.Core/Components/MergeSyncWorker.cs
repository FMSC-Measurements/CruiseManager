using Backpack.SqlBuilder;
using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Support;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

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

    public class MergeSyncWorker : IWorker
    {
        public MergeSyncWorker(DAL master, IEnumerable<ComponentFileVM> comps, IDictionary<String, MergeTableCommandBuilder> commandBuilders)
        {
            CommandBuilders = commandBuilders;
            this.Master = master;
            this.Components = comps;

            System.Diagnostics.Debug.Assert(this.Master != null);
            System.Diagnostics.Debug.Assert(this.Components != null);
        }

        public MergeSyncWorker(MergeComponentsPresenter controller)
        {
            CommandBuilders = controller.CommandBuilders;
            this.Master = controller.MasterDB;
            this.Components = controller.ActiveComponents;

            System.Diagnostics.Debug.Assert(this.Master != null);
            System.Diagnostics.Debug.Assert(this.Components != null);
        }

        public const string COMP_ALIAS = "comp";

        public IEnumerable<ComponentFileVM> Components { get; private set; }
        public DAL Master { get; private set; }
        public MergeComponentsPresenter MergePresenter { get; set; }
        private IDictionary<String, MergeTableCommandBuilder> CommandBuilders { get; set; }

        #region move methods

        private void MoveUnit(DAL database, string dbAlias, long fromUnit_CN, long toUnit_CN)
        {
            database.Execute(
$@"UPDATE {dbAlias}.CuttingUnit SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;
UPDATE {dbAlias}.CuttingUnitStratum SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;
UPDATE {dbAlias}.Plot SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;
UPDATE {dbAlias}.Tree SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;
UPDATE {dbAlias}.CountTree SET CuttingUnit_CN = @p1 WHERE CuttingUnit_CN = @p2;", toUnit_CN, fromUnit_CN);
        }

        private void MoveSt(DAL database, string dbAlias, long fromSt_CN, long toSt_CN)
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

        private void MoveSg(DAL database, string dbAlias, long fromSG_CN, long toSG_CN)
        {
            database.Execute(
$@"UPDATE {dbAlias}.SampleGroup SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.SampleGroupTreeDefaultValue SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.CountTree SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.Tree SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.SamplerState SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;
UPDATE {dbAlias}.FixCNTTallyPopulation SET SampleGroup_CN = @p1 WHERE SampleGroup_CN = @p2;", toSG_CN, fromSG_CN);
        }

        public void MoveTDV(DAL database, string dbAlias, long fromTDV_CN, long toTDV_CN)
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

        public void SyncDesign()
        {
            var components = Components;
            foreach (var comp in components)
            {
                AttachComponent(comp.Database);
                Master.BeginTransaction();
                try
                {
                    PullDesignChanges(comp);
                    Master.CommitTransaction();
                }
                catch
                {
                    Master.RollbackTransaction();
                }
                finally
                {
                    DetachComponent();
                }
            }

            foreach (var comp in components)
            {
                AttachComponent(comp.Database);
                Master.BeginTransaction();
                try
                {
                    PushDesignChanges(comp);
                    Master.CommitTransaction();
                }
                catch
                {
                    Master.RollbackTransaction();
                }
                finally
                {
                    DetachComponent();
                }
            }
        }

        private void PullDesignChanges(ComponentFileVM comp)
        {
            PullTreeDefault();
            PullSampleGroup();
            PullSampleGroupTreeDefault();
            PullTally();
            PullCountTree(comp.Component_CN.Value);
        }

        public void PushDesignChanges(ComponentFileVM comp)
        {
            PushCuttingUnit();
            PushStratum();
            PushCuttingUnitStratum();
            PushSampleGroup();
            PushTreeDefault();
            PushSampleGroupTreeDefault();
            PushCountTrees(comp.Component_CN.Value);
        }

        public void SyncFieldData()
        {
            StartTransactionAll();
            try
            {
                this._workInCurrentJob += (int)this.CountTotalMergeWork();

                UpdateMaster();
                UpdateComponents();

                this.NotifyProgressChanged(this._progressInCurrentJob, true, "Done", null);
                this.EndTransactionAll();
            }
            catch
            {
                this.CancelTransactionAll();
                throw;
            }
        }

        public void UpdateComponents()
        {
            foreach (var comp in Components)
            {
                PushComponentPlotUpdates(comp);
                PushComponentTreeUpdates(comp);
                PushComponentLogUpdates(comp);
                PushComponentStemUpdates(comp);
            }
        }

        public void UpdateMaster()
        {
            foreach (var comp in Components)
            {
                PullNewPlotRecords(comp);
                PullMasterPlotUpdates(comp);

                PullNewTreeRecords(comp);
                PullMasterTreeUpdates(comp);

                PullNewLogRecords(comp);
                PullMasterLogUpdates(comp);

                PullNewStemRecords(comp);
                PullMasterStemUpdates(comp);
            }
        }

        #endregion core

        #region transaction and attach

        public void AttachComponent(DAL comp)
        {
            Master.AttachDB(comp, COMP_ALIAS);
        }

        public void DetachComponent()
        {
            Master.DetachDB(COMP_ALIAS);
        }

        private void CancelTransactionAll()
        {
            this.Master.RollbackTransaction();
            foreach (var comp in this.Components)
            {
                comp.Database.RollbackTransaction();
            }
        }

        private void EndTransactionAll()
        {
            Master.CommitTransaction();
            foreach (var comp in this.Components)
            {
                comp.Database.CommitTransaction();
            }
        }

        private void StartTransactionAll()
        {
            this.Master.BeginTransaction();
            foreach (var comp in this.Components)
            {
                comp.Database.BeginTransaction();
            }
        }

        #endregion transaction and attach

        #region pull new records

        public void PullNew(MergeTableCommandBuilder cmdBldr, ComponentFileVM comp)
        {
            StartJob("Pull New From " + cmdBldr.ClientTableName);
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                DataObject newFromComp = cmdBldr.ReadSingleRow(comp.Database, mRec.ComponentRowID.Value);
                Master.Insert(newFromComp, option: OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp.Database, mRec.ComponentRowID.Value, cmdBldr);
            }

            EndJob("Pull New From " + cmdBldr.ClientTableName);
        }

        public void PullNewLogRecords(ComponentFileVM comp)
        {
            var compDB = comp.Database;
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Log"];
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                LogDO log = compDB.From<LogDO>()
                    .Where("rowid = @p1").Query(mRec.ComponentRowID).FirstOrDefault();
                Master.Insert(log, option: OnConflictOption.Fail);
                this.ResetComponentRowVersion(compDB, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullNewPlotRecords(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Plot"];
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                PlotDO plot = comp.Database.From<PlotDO>()
                    .Where("rowid = @p1").Query(mRec.ComponentRowID).FirstOrDefault();

                Master.Insert(plot, option: OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp.Database, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }
            EndJob();
        }

        public void PullNewStemRecords(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Stem"];
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                StemDO stem = comp.Database.From<StemDO>()
                    .Where("rowid = @p1").Query(mRec.ComponentRowID).FirstOrDefault();

                Master.Insert(stem, option: OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp.Database, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullNewTreeRecords(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Tree"];
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                TreeDO tree = comp.Database.From<TreeDO>()
                    .Where("rowid = @p1").Query(mRec.ComponentRowID).FirstOrDefault();
                Master.Insert(tree, option: OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp.Database, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        #endregion pull new records

        #region pull new design records

        public void PullTally()
        {
            var master = Master;
            StartJob();
            var compTallies = master.From<TallyDO>(new TableOrSubQuery($"{COMP_ALIAS}.Tally")).Query();

            foreach (TallyDO tally in compTallies)
            {
                CheckWorkerStatus();
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
                }
            }
        }

        public void PullCountTree(long component_cn)
        {
            var master = Master;

            StartJob();
            var compCounts = master.From<CountTreeDO>(new TableOrSubQuery($"{COMP_ALIAS}.CountTree")).Query();
            foreach (CountTreeDO count in compCounts)
            {
                var compTally = master.From<TallyDO>(new TableOrSubQuery($"{COMP_ALIAS}.Tally"))
                    .Where("Tally_CN = @p1")
                    .Query(count.Tally_CN).FirstOrDefault();

                CheckWorkerStatus();
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
                        PostStatus($"Tally added :{masterTally.Tally_CN}");
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
                    PostStatus($"CountTree added :{newCount.CountTree_CN}");
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
                        PostStatus($"Tally added :{masterTally.Tally_CN}");
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
                    PostStatus($"Master CountTree added :{masterMatch.CountTree_CN}");
                }
            }
            EndJob();
        }

        public void PullSampleGroup()
        {
            var master = Master;
            StartJob();

            var compSGList = master.From<SampleGroupDO>(new TableOrSubQuery(COMP_ALIAS + ".SampleGroup"))
                .Query().ToArray();
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
                        DefaultLiveDead =sg.DefaultLiveDead,
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
                        UOM  = sg.UOM,
                    };

                    var newSG_CN = (master.ExecuteScalar<int>($"SELECT count(*) FROM SampleGroup WHERE SampleGroup_CN = @p1;", sg.SampleGroup_CN) == 0)
                        ? sg.SampleGroup_CN
                        : (long?)null;

                    master.Insert(newSG, keyValue: newSG_CN);
                    match = newSG;
                    PostStatus($"Sample Group added :{newSG.SampleGroup_CN}");
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
                        PostStatus($"Sample Group swap :{matchSG_CN} -> {newSG_CN}");
                    }

                    // finaly move the comp SG CN value to match the master
                    MoveSg(master, COMP_ALIAS, compSG_CN, matchSG_CN);
                    PostStatus($"Sample Group mismatch resolved :{compSG_CN} -> {matchSG_CN}");
                }
            }

            EndJob();
        }

        public void PullSampleGroupTreeDefault()
        {
            StartJob();

            int? rowsAffected = Master.Execute("INSERT OR IGNORE INTO main.SampleGroupTreeDefaultValue " +
                "SELECT * FROM " + COMP_ALIAS + ".SampleGroupTreeDefaultValue;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected");

            EndJob();
        }

        public void PullTreeDefault()
        {
            var master = Master;

            StartJob();
            var compTreeDefaults = master.From<TreeDefaultValueDO>(new TableOrSubQuery(COMP_ALIAS + ".TreeDefaultValue"))
                .Query().ToArray();

            foreach (TreeDefaultValueDO tdv in compTreeDefaults)
            {
                CheckWorkerStatus();

                var match = master.From<TreeDefaultValueDO>().Where("Species = @p1 AND PrimaryProduct = @p2 AND LiveDead = @p3")
                    .Query(tdv.Species, tdv.PrimaryProduct, tdv.LiveDead).FirstOrDefault();

                if (match == null)
                {
                    var newTDV = new TreeDefaultValueDO(master);
                    newTDV.SetValues(tdv);
                    master.Insert(newTDV, option: OnConflictOption.Fail);

                    match = newTDV;
                    PostStatus($"TDV added :{newTDV.TreeDefaultValue_CN}");
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
                        PostStatus($"TDV swap :{matchTDV_CN} -> {newTDV_CN}");
                    }

                    // move component tdv to match the master tdv
                    MoveTDV(master, COMP_ALIAS, compTDB_CN, matchTDV_CN);
                    PostStatus($"TDV mismatch resolved :{compTDB_CN} -> {matchTDV_CN}");
                }
            }

            EndJob();
        }

        #endregion pull new design records

        #region push new design records

        public void PushCountTrees(long component_cn)
        {
            StartJob();

            var master = Master;
            var countTrees = master.Query<CountTreeDO>("SELECT * FROM main.CountTree WHERE Component_CN IS NULL;").ToArray();
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

                        PostStatus($"Tally added :{tally_CN}");
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
                    PostStatus($"CountTree added :{newCt_cn}");

                }
            }
            EndJob();
        }

        public void PushSampleGroup()
        {
            var compAlias = COMP_ALIAS;
            var master = Master;
            var compSGEntDisc = new EntityDescription(typeof(SampleGroupDO));
            compSGEntDisc.Source = new TableOrSubQuery($"{compAlias}.SampleGroup");

            StartJob();

            var sampleGroups = master.From<SampleGroupDO>().Query().ToArray();
            foreach (var sg in sampleGroups)
            {
                var mastCN = sg.SampleGroup_CN;

                var match = master.From<SampleGroupDO>(new TableOrSubQuery($"{compAlias}.SampleGroup"))
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

                    var newSG_CN = master.Insert(newSG, tableName: $"{compAlias}.SampleGroup", keyValue: sg_cn);
                    match = newSG;
                    PostStatus($"SampleGroup added :{newSG_CN}");
                }

                var matchCN = match.SampleGroup_CN;
                if(matchCN != mastCN)
                {
                    if(master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.SampleGroup WHERE SampleGroup_CN = @p1", mastCN) > 0)
                    {
                        var nextSg_CN = master.ExecuteScalar<long>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'SampleGroup';");

                        MoveSg(master, COMP_ALIAS, mastCN.Value, nextSg_CN);
                        PostStatus($"SampleGroup swap :{mastCN} => {nextSg_CN}");
                    }

                    MoveSg(master, COMP_ALIAS, matchCN.Value, mastCN.Value);
                    PostStatus($"SampleGroup mismatch resolved :{matchCN} => {mastCN}");
                }
            }

            EndJob();
        }

        public void PushStratum()
        {
            StartJob();
            var master = Master;
            var strata = master.From<StratumDO>().Query().ToArray();

            foreach(var st in strata)
            {
                var mastCN = st.Stratum_CN;
                var match = master.Query<StratumDO>($"SELECT * FROM {COMP_ALIAS}.Stratum WHERE Code = @p1;", st.Code).FirstOrDefault();

                if(match == null)
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

                    PostStatus($"Stratum added :{st_cn}");
                }

                var matchCN = match.Stratum_CN;
                if(match.Stratum_CN != mastCN)
                {
                    if (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.Stratum WHERE Stratum_CN = @p1", st.Stratum_CN) > 0)
                    {
                        var nextSt_CN = master.ExecuteScalar<long>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'Stratum';");

                        MoveSt(master, COMP_ALIAS, mastCN.Value, nextSt_CN);
                        PostStatus($"Stratum swap :{mastCN} => {nextSt_CN}");
                    }

                    MoveSt(master, COMP_ALIAS, matchCN.Value, mastCN.Value);
                    PostStatus($"Stratum mismatch resolved :{matchCN} => {mastCN}");
                }
            }

            EndJob();
        }

        public void PushCuttingUnit()
        {
            StartJob();

            var master = Master;
            var units = master.From<CuttingUnitDO>().Query();
            foreach(var unit in units)
            {
                var mastCN = unit.CuttingUnit_CN;
                var match = master.From<CuttingUnitDO>(new TableOrSubQuery($"{COMP_ALIAS}.CuttingUnit"))
                    .Where("Code = @p1").Query(unit.Code).FirstOrDefault();

                if(match == null)
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
                    PostStatus($"Unit added :{unit_CN}");
                }

                var matchCN = match.CuttingUnit_CN;
                if(matchCN != mastCN)
                {
                    if(master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.CuttingUnit WHERE CuttingUnit_CN = @p1;", mastCN) > 0)
                    {
                        var nextCu_CN = master.ExecuteScalar<long>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'CuttingUnit';");

                        MoveUnit(master, COMP_ALIAS, mastCN.Value, nextCu_CN);
                        PostStatus($"Unit swap :{mastCN} -> {nextCu_CN}");
                    }
                    MoveUnit(master, COMP_ALIAS, matchCN.Value, mastCN.Value);
                    PostStatus($"Unit mismatch resolved :{matchCN} -> {mastCN}");
                }
            }

            EndJob();
        }

        public void PushSampleGroupTreeDefault()
        {
            StartJob();

            int? rowsAffected = Master.Execute("INSERT OR IGNORE INTO " + COMP_ALIAS + ".SampleGroupTreeDefaultValue " +
                "SELECT * FROM main.SampleGroupTreeDefaultValue;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected");
            EndJob();
        }

        public void PushTreeDefault()
        {
            StartJob();

            var master = Master;
            var tdvs = master.From<TreeDefaultValueDO>().Query();

            foreach (var tdv in tdvs)
            {
                var mastCN = tdv.TreeDefaultValue_CN.Value;
                var match = master.From<TreeDefaultValueDO>(new TableOrSubQuery($"{COMP_ALIAS}.TreeDefaultValue"))
                    .Where("Species = @p1 AND PrimaryProduct = @p2 AND LiveDead = @p3")
                    .Query(tdv.Species, tdv.PrimaryProduct, tdv.LiveDead).FirstOrDefault();

                if(match == null)
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
                    PostStatus($"TDV added :{tdv_CN}");
                }

                var matchCN = match.TreeDefaultValue_CN.Value;
                if (matchCN != mastCN)
                {
                    if (master.ExecuteScalar<int>($"SELECT count(*) FROM {COMP_ALIAS}.TreeDefaultValue WHERE TreeDefaultValue_CN = @p1;", tdv.TreeDefaultValue_CN) > 0)
                    {
                        var nextTDV_CN = master.ExecuteScalar<long>($"SELECT seq + 1 FROM {COMP_ALIAS}.sqlite_sequence WHERE name = 'TreeDefaultValue';");

                        MoveTDV(master, COMP_ALIAS, mastCN, nextTDV_CN);
                        PostStatus($"TDV swap :{mastCN} -> {nextTDV_CN}");
                    }

                    MoveTDV(master, COMP_ALIAS, matchCN, mastCN);
                    PostStatus($"TDV missmatch resolved :{matchCN} -> {mastCN}");
                }
            }

            EndJob();
        }

        public void PushCuttingUnitStratum()
        {
            StartJob();

            int? rowsAffected = Master.Execute("DELETE FROM " + COMP_ALIAS + ".CuttingUnitStratum; " +
                "INSERT OR IGNORE INTO " + COMP_ALIAS + ".CuttingUnitStratum " +
                "SELECT * FROM main.CuttingUnitStratum;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected");
            EndJob();
        }

        #endregion push new design records

        #region Pull field data updates

        public void PullMasterLogUpdates(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Log"];
            List<MergeObject> pullList = cmdBldr.ListMasterUpdates(Master, comp);

            foreach (MergeObject mRec in pullList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                LogDO log = comp.Database.From<LogDO>()
                    .Where("Log_CN = @p1")
                    .Read(mRec.ComponentRowID).FirstOrDefault();
                Master.Update(log, keyValue: matchRowid, option: OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullMasterPlotUpdates(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Plot"];
            List<MergeObject> pullList = cmdBldr.ListMasterUpdates(Master, comp);
            foreach (MergeObject mRec in pullList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                var plot = comp.Database.From<PlotDO>()
                    .Where("Plot_CN = @p1").Read(mRec.ComponentRowID).FirstOrDefault();

                Master.Update(plot, keyValue: matchRowid, option: OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullMasterStemUpdates(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Stem"];
            List<MergeObject> pullList = cmdBldr.ListMasterUpdates(Master, comp);

            foreach (MergeObject mRec in pullList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                StemDO stem = comp.Database.From<StemDO>()
                    .Where("Stem_CN = @p1")
                    .Read(mRec.ComponentRowID).FirstOrDefault();

                Master.Update(stem, keyValue: matchRowid, option: OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullMasterTreeUpdates(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Tree"];
            List<MergeObject> pullList = cmdBldr.ListMasterUpdates(Master, comp);

            foreach (MergeObject mRec in pullList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                TreeDO tree = comp.Database.From<TreeDO>().Where("rowid = @p1")
                    .Query(mRec.ComponentRowID).FirstOrDefault();
                Master.Update(tree, keyValue: matchRowid, option: OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        #endregion Pull field data updates

        #region push field data updates

        public void PushComponentLogUpdates(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Log"];
            List<MergeObject> pushList = cmdBldr.ListComponentUpdates(Master, comp);
            foreach (MergeObject mRec in pushList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                LogDO log = Master.From<LogDO>()
                    .Where("Log_CN = @p1").Read(matchRowid).FirstOrDefault();

                comp.Database.Update(log, keyValue: mRec.ComponentRowID.Value, option: OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }
            EndJob();
        }

        public void PushComponentPlotUpdates(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Plot"];
            List<MergeObject> pushList = cmdBldr.ListComponentUpdates(Master, comp);
            foreach (MergeObject mRec in pushList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                PlotDO plot = Master.From<PlotDO>()
                    .Where("Plot_CN = @p1").Read(matchRowid).FirstOrDefault();

                comp.Database.Update(plot, keyValue: mRec.ComponentRowID.Value, option: OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PushComponentStemUpdates(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Stem"];
            List<MergeObject> pushList = cmdBldr.ListComponentUpdates(Master, comp);
            foreach (MergeObject mRec in pushList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                StemDO stem = Master.From<StemDO>()
                    .Where("Stem_CN = @p1").Read(matchRowid).FirstOrDefault();

                comp.Database.Update(stem, keyValue: mRec.ComponentRowID.Value, option: OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PushComponentTreeUpdates(ComponentFileVM comp)
        {
            StartJob();
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Tree"];
            List<MergeObject> pushList = cmdBldr.ListComponentUpdates(Master, comp);
            foreach (MergeObject mRec in pushList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                TreeDO tree = Master.From<TreeDO>().Where("Tree_CN = @p1")
                    .Read(matchRowid).FirstOrDefault();
                //TODO need to handle condition where MasterRowID is different from ComponentRowID
                comp.Database.Update(tree, keyValue: mRec.ComponentRowID.Value, option: OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }
            EndJob();
        }

        #endregion push field data updates

        private void ResetComponentRowVersion(DAL comp, long componentRowID, MergeTableCommandBuilder commBldr)
        {
            comp.Execute("UPDATE " + commBldr.ClientTableName + " SET RowVersion = 0 WHERE RowID = @p1;", componentRowID);
        }

        private void ResetRowVersion(ComponentFileVM comp, long masterRowID, long componentRowID, MergeTableCommandBuilder commBldr)
        {
            Master.Execute("UPDATE " + commBldr.ClientTableName + " SET RowVersion = 0 WHERE RowID = @p1;", masterRowID);
            ResetComponentRowVersion(comp.Database, componentRowID, commBldr);
        }

        #region Calculate work

        public long CountAddRecordActions()
        {
            long total = 0;
            foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
            {
                total += CountAddRecordActions(cmdBldr);
            }
            return total;
            //long total = CountAddRecordActions("Tree");
            //total += CountAddRecordActions("Log");
            //total += CountAddRecordActions("Stem");
            //total += CountAddRecordActions("Plot");
            //return total;
        }

        //public long CountUpdateComponentActions(MergeTableCommandBuilder cmdBldr)
        //{
        //    return Master.GetRowCount(cmdBldr.MergeTableName, cmdBldr.FindMasterToCompUpdates);
        //}
        public long CountAddRecordActions(MergeTableCommandBuilder cmdBldr)
        {
            return Master.GetRowCount(cmdBldr.MergeTableName, cmdBldr.FindNewRecords);
        }

        public long CountUpdateActions()
        {
            long total = 0;
            foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
            {
                total += CountUpdateActions(cmdBldr);
            }
            return total;
            //long total = CountUpdateMasterActions("Tree");
            //total += CountUpdateMasterActions("Log");
            //total += CountUpdateMasterActions("Stem");
            //total += CountUpdateMasterActions("Plot");
            //return total;
        }

        public long CountUpdateActions(MergeTableCommandBuilder cmdBldr)
        {
            return Master.GetRowCount(cmdBldr.MergeTableName, "WHERE " + cmdBldr.FindMatchesBase);
        }

        private long CountTotalMergeWork()
        {
            long total = CountUpdateActions();
            //total += CountUpdateComponentActions();
            total += CountAddRecordActions();
            return total;
        }

        //public long CountUpdateComponentActions()
        //{
        //    long total = 0;
        //    foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
        //    {
        //        total += CountUpdateComponentActions(cmdBldr);
        //    }
        //    return total;
        //    //long total = CountUpdateComponentActions("Tree");
        //    //total += CountUpdateComponentActions("Log");
        //    //total += CountUpdateComponentActions("Stem");
        //    //total += CountUpdateComponentActions("Plot");
        //    //return total;
        //}

        #endregion Calculate work

        #region Job Mgmt

        //private Stopwatch _stopwatch;

        private void EndJob([CallerMemberName] string name = "")
        {
            //if (_stopwatch != null)
            //{
            //    _stopwatch.Stop();
            //    Debug.WriteLine("Ended job component " + _currentJobName + " in " + _stopwatch.ElapsedMilliseconds + "mSec");
            //}
            this.PostStatus(name + ": done");
        }

        private void StartJob([CallerMemberName] string name = "")
        {
            //if (_stopwatch != null) { _stopwatch.Stop(); }
            //_stopwatch = Stopwatch.StartNew();
            this.PostStatus("Starting" + name);
            Debug.WriteLine("Started job component " + name);
        }

        #endregion Job Mgmt

        #region IWorker Members

        private bool _isCanceled;
        private bool _isDone;
        private int _progressInCurrentJob;
        private Thread _thread;
        private object _threadLock = new object();
        private int _workInCurrentJob;

        public event EventHandler<WorkerProgressChangedEventArgs> ProgressChanged;

        public string ActionName { get { return "Merge"; } }

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

        public void BeginWork()
        {
            if (_thread != null && _thread.IsAlive)
            {
                throw new InvalidOperationException("Cancel or wait for current job to finish before starting again");
            }

            ThreadStart ts = new ThreadStart(this.DoWork);
            this._thread = new Thread(ts)
            {
                IsBackground = true,
                Name = "MergeSyncWorker"
            };
            this._thread.Start();
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

        public void DoWork()
        {
            try
            {
                Analytics.TrackEvent(AnalyticsEvents.MERGE_START,
                    new Dictionary<string, string>()
                    {
                        {"numComponents", Components.Count().ToString() },
                    });

                this.SyncDesign();
                this.SyncFieldData();
                Analytics.TrackEvent(AnalyticsEvents.MERGE_DONE);
            }
            catch (CancelWorkerException e)
            {
                Analytics.TrackEvent(AnalyticsEvents.MERGE_CANCEL);
                this.NotifyProgressChanged(0, false, "Canceleled", e);
                throw;
            }
            catch (Exception e)
            {
                Analytics.TrackEvent(AnalyticsEvents.MERGE_FAIL);
                Crashes.TrackError(e);
                this.NotifyProgressChanged(0, false, "Error:" + e.Message, e);
                throw;
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

        protected void IncrementProgress()
        {
            this._progressInCurrentJob++;
            this.NotifyProgressChanged(this._progressInCurrentJob, false, null, null);
        }

        protected void NotifyProgressChanged(int workDone, bool isDone, String message, Exception error)
        {
            if (isDone)
            {
                this.IsDone = true;
            }
            if (this.ProgressChanged != null)
            {
                int percentDone = CalcPercentDone(workDone);
                WorkerProgressChangedEventArgs e = new WorkerProgressChangedEventArgs(percentDone)
                {
                    IsDone = isDone,
                    Error = error,
                    Message = message
                };
                this.ProgressChanged(this, e);
            }
        }

        protected void PostStatus(string message)
        {
            this.NotifyProgressChanged(this._progressInCurrentJob, false, message, null);
        }

        private int CalcPercentDone(int workDone)
        {
            return (_workInCurrentJob <= 0) ? 0 : (int)(100 * (float)workDone / _workInCurrentJob);
        }

        private void CheckWorkerStatus()
        {
            if (this.IsCanceled)
            { throw new CancelWorkerException(); }
        }

        #endregion IWorker Members
    }
}