using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CruiseDAL.DataObjects;
using System.Threading;
using System.Diagnostics;
using CSM.Common;

namespace CSM.Logic.Components
{
    public class MergeSyncWorker : IWorker
    {
        private IDictionary<String, MergeTableCommandBuilder> CommandBuilders { get { return this.MergePresenter.CommandBuilders; } }

        public DAL Master { get; private set; }
        public IList<ComponentFileVM> Components { get; private set; }
        public MergeComponentsPresenter MergePresenter { get; set; }

        public MergeSyncWorker(MergeComponentsPresenter controller)
        {
            this.MergePresenter = controller; 
            this.Master = controller.MasterDB;
            this.Components = controller.ActiveComponents;

            System.Diagnostics.Debug.Assert(this.Master != null);
            System.Diagnostics.Debug.Assert(this.Components != null);
        }

        #region transaction and attach 

        private void AttachAll()
        {
            foreach (ComponentFileVM comp in this.Components)
            {
                string alias = "comp" + comp.Component_CN.Value.ToString();
                comp.DBAlias = alias;
                Master.AttachDB(comp.Database, alias);
            }
        }

        private void DetachAll()
        {
            foreach (ComponentFileVM comp in this.Components)
            {
                Master.DetachDB(comp.DBAlias);
            }
        }

        private void StartTransactionAll()
        {
            this.Master.BeginTransaction();
            foreach (ComponentFileVM comp in this.Components)
            {
                comp.Database.BeginTransaction();
            }
        }

        private void EndTransactionAll()
        {
            this.Master.EndTransaction();
            foreach (ComponentFileVM comp in this.Components)
            {
                comp.Database.EndTransaction();
            }
        }

        private void CancelTransactionAll()
        {
            this.Master.CancelTransaction();
            foreach (ComponentFileVM comp in this.Components)
            {
                comp.Database.CancelTransaction();
            }
        }
        #endregion

        #region core

        private void SyncDesign()
        {
            AttachAll();
            Master.BeginTransaction();
            try
            {
                PullDesignChanges();
                PushDesignChanges();
                Master.EndTransaction();
            }
            catch
            {
                Master.CancelTransaction();
                throw;
            }
            finally
            {
                DetachAll();
            }
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

        public void PullDesignChanges()
        {
            foreach (ComponentFileVM comp in Components)
            {
                PullTreeDefaultInserts(comp);
                PullNewSampleGroups(comp);
                PullNewSampleGroupTreeDefaults(comp);
                PullNewTallyTable(comp);
                PullCountTreeChanges(comp);
            }
        }

        public void PushDesignChanges()
        {
            foreach (ComponentFileVM comp in Components)
            {                
                PushNewUnitRecords(comp);
                PushNewStratumRecords(comp);
                PushUnitStratumChanges(comp);
                PushNewSampleGroups(comp);
                PushTreeDefaultInserts(comp);
                PushSampleGroupTreeDefaultInserts(comp);   
                //TODO push tally table changes
            }
        }

        public void UpdateMaster()
        {
            foreach (ComponentFileVM comp in Components)
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

        public void UpdateComponents()
        {
            foreach (ComponentFileVM comp in Components)
            {
                PushComponentPlotUpdates(comp);
                PushComponentTreeUpdates(comp);
                PushComponentLogUpdates(comp);
                PushComponentStemUpdates(comp);
            }
        }
        #endregion


        #region pull new records

        public void PullNew(MergeTableCommandBuilder cmdBldr, ComponentFileVM comp)
        {
            StartJob("Pull New From " + cmdBldr.ClientTableName);
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                DataObject newFromComp = cmdBldr.ReadSingleRow(comp.Database, mRec.ComponentRowID.Value);
                Master.Insert(newFromComp, true, OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp, mRec.ComponentRowID.Value, cmdBldr);
            }

            EndJob();
        }


        public void PullNewTreeRecords(ComponentFileVM comp)
        {
            StartJob("Add New Trees");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Tree"];
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                TreeDO tree = comp.Database.ReadSingleRow<TreeDO>("Tree", mRec.ComponentRowID);
                Master.Insert(tree, true, OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp,  mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullNewLogRecords(ComponentFileVM comp)
        {
            StartJob("Add New Logs");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Log"];
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                LogDO log = comp.Database.ReadSingleRow<LogDO>("Log", mRec.ComponentRowID);
                Master.Insert(log, true, OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullNewStemRecords(ComponentFileVM comp)
        {
            StartJob("Add New Stems");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Stem"];
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                StemDO stem = comp.Database.ReadSingleRow<StemDO>("Stem", mRec.ComponentRowID);
                Master.Insert(stem, true, OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullNewPlotRecords(ComponentFileVM comp)
        {
            StartJob("Add Plots");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Plot"];
            List<MergeObject> mergeRecords = cmdBldr.ListNewRecords(Master, comp);

            foreach (MergeObject mRec in mergeRecords)
            {
                CheckWorkerStatus();
                PlotDO plot = comp.Database.ReadSingleRow<PlotDO>("Plot", mRec.ComponentRowID);
                Master.Insert(plot, true, OnConflictOption.Fail);
                this.ResetComponentRowVersion(comp, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }
            EndJob();
        }
        #endregion

        #region pull new design records 
        public void PullTreeDefaultInserts(ComponentFileVM comp)
        {
            StartJob("Pull TreeDefault Inserts");
            List<TreeDefaultValueDO> compTreeDefaults = comp.Database.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
            foreach (TreeDefaultValueDO tdv in compTreeDefaults)
            {
                CheckWorkerStatus();
                bool hasMatch = 0 < Master.GetRowCount("TreeDefaultValue", 
                    "WHERE Species = ? AND PrimaryProduct = ? AND LiveDead = ?", 
                    tdv.Species, tdv.PrimaryProduct, tdv.LiveDead);
                if (!hasMatch)
                {
                    if(Master.GetRowCount("TreeDefaultValue", "WHERE TreeDefaultValue_CN = ?", tdv.TreeDefaultValue_CN) == 0)
                    {
                        Master.Insert(tdv, true, OnConflictOption.Fail);
                    }
                    else
                    {
                        throw new NotImplementedException("TreeDefaultValue row conflict condition not implemented");
                        //Master.Insert(tdv, false, OnConflictOption.Fail);
                        //tdv.Save(); 
                    }
                }
            }

            EndJob();
        }

        public void PullNewSampleGroups(ComponentFileVM comp)
        {
            StartJob("Add New Sample Groups");

            List<SampleGroupDO> compSGList = comp.Database.Read<SampleGroupDO>("SampleGroup", null);
            foreach (SampleGroupDO sg in compSGList)
            {
                SampleGroupDO match = Master.ReadSingleRow<SampleGroupDO>("SampleGroup", "WHERE Code = ? AND Stratum_CN = ?", sg.Code, sg.Stratum_CN);
                if (match == null)
                {
                    SampleGroupDO newSG = new SampleGroupDO(Master);
                    newSG.SuspendEvents();
                    newSG.SetValues(sg);
                    newSG.Stratum_CN = sg.Stratum_CN;
                    newSG.ResumeEvents();

                    newSG.Save();
                    match = newSG;
                }
                if (sg.SampleGroup_CN != match.SampleGroup_CN)
                {
                    comp.Database.Execute("UPDATE SampleGroup SET SampleGroup_CN = ? WHERE SampleGroup_CN = ?;", match.SampleGroup_CN, sg.SampleGroup_CN); 
                }
            }


            EndJob();
        }

        public void PullNewSampleGroupTreeDefaults(ComponentFileVM comp)
        {
            StartJob("Update Sample Group Species Mappings");
            
            int? rowsAffected = Master.Execute("INSERT OR IGNORE INTO main.SampleGroupTreeDefaultValue " +
                "SELECT * FROM " + comp.DBAlias + ".SampleGroupTreeDefaultValue;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected"); 

            EndJob();
        }

        public void PullNewTallyTable(ComponentFileVM comp)
        {
            StartJob("Add New CountTree Records");
            List<TallyDO> compTallies = comp.Database.Read<TallyDO>("Tally", null);

            foreach (TallyDO tally in compTallies)
            {
                CheckWorkerStatus();
                TallyDO match = Master.ReadSingleRow<TallyDO>("Tally", "WHERE HotKey = ? AND Description = ?",
                    tally.Hotkey, tally.Description);

                if (match == null)
                {
                    match = new TallyDO(Master);
                    match.Hotkey = tally.Hotkey;
                    match.Description = tally.Description;
                    match.Save();
                }
            }


        }

        public void PullCountTreeChanges(ComponentFileVM comp)
        {
            StartJob("Add New CountTree Records");
            List<CountTreeDO> compCounts = comp.Database.Read<CountTreeDO>("CountTree", null);
            foreach (CountTreeDO count in compCounts)
            {
                CheckWorkerStatus();
                CountTreeDO match = Master.ReadSingleRow<CountTreeDO>("CountTree",
                    "WHERE SampleGroup_CN = ? " +
                    "AND ifnull(TreeDefaultValue_CN, 0) = ifnull(?, 0) " +
                    "AND CuttingUnit_CN = ? " +
                    "AND Component_CN = ?",
                    count.SampleGroup_CN,
                    count.TreeDefaultValue_CN,
                    count.CuttingUnit_CN,
                    comp.Component_CN);//use component cn from component record because component cn is not set when record is created by FScruiser

                if (match != null)
                {
                    match.TreeCount = count.TreeCount;
                    match.SumKPI = count.TreeCount;
                    match.Save();
                }
                else
                {
                    TallyDO tally = count.Tally;
                    TallyDO masterTally = Master.ReadSingleRow<TallyDO>("Tally", "WHERE HotKey = ?", tally.Hotkey);
                    if (masterTally == null)
                    {
                        //TODO unsupported 
                    }
                    else
                    {
                        count.Tally_CN = masterTally.Tally_CN;
                    }
                    if (count.Component_CN == null)
                    {

                        count.Component_CN = comp.Component_CN;
                        //Master.Execute("UPDATE " + comp.DBAlias + ".CountTree Set Component_CN = ? WHERE CountTree_CN = ?;", comp.Component_CN, count.CountTree_CN);
                    }
                    Master.Insert(count, false, OnConflictOption.Fail);
                }
            }
            EndJob();
        }


        #endregion

        #region push new design records
        public void PushNewUnitRecords(ComponentFileVM comp)
        {
            StartJob("Add New Units");

            int? rowsAffected = Master.Execute("INSERT OR IGNORE INTO " + comp.DBAlias + ".CuttingUnit " +
                "SELECT * FROM main.CuttingUnit;"); 



            EndJob();
        }

        public void PushNewStratumRecords(ComponentFileVM comp)
        {
            StartJob("Add New Strata");

            int? rowsAffected = Master.Execute("INSERT OR IGNORE INTO " + comp.DBAlias + ".Stratum " +
                "SELECT * FROM main.Stratum;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected"); 

            EndJob();
        }

        public void PushUnitStratumChanges(ComponentFileVM comp)
        {
            StartJob("Update Component Unit Strata Mappings");

            int? rowsAffected = Master.Execute("DELETE FROM " + comp.DBAlias + ".CuttingUnitStratum; " +
                "INSERT OR IGNORE INTO " + comp.DBAlias + ".CuttingUnitStratum " +
                "SELECT * FROM main.CuttingUnitStratum;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected"); 
            EndJob();
           
        }

        public void PushNewSampleGroups(ComponentFileVM comp)
        {
            StartJob("Push New SampleGroup Records");

            int? rowsAffected = Master.Execute("INSERT OR IGNORE INTO " + comp.DBAlias + ".SampleGroup " +
                "SELECT * FROM main.SampleGroup;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected"); 
            EndJob(); 
        }

        public void PushTreeDefaultInserts(ComponentFileVM comp)
        {
            StartJob("Push TreeDefaultValue Inserts");

            int? rowsAffected = Master.Execute("INSERT OR IGNORE INTO " + comp.DBAlias + ".TreeDefaultValue " +
                "SELECT * FROM main.TreeDefaultValue;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected");
            EndJob();
        }

        public void PushSampleGroupTreeDefaultInserts(ComponentFileVM comp)
        {
            StartJob("Push SampleGroupTreeDefault Inserts");

            int? rowsAffected = Master.Execute("INSERT OR IGNORE INTO " + comp.DBAlias + ".SampleGroupTreeDefaultValue " +
                "SELECT * FROM main.SampleGroupTreeDefaultValue;");

            PostStatus(rowsAffected.GetValueOrDefault(0).ToString() + " Rows Affected");
            EndJob();
        }



        #endregion

        #region Pull field data updates

        public void PullMasterTreeUpdates(ComponentFileVM comp)
        {

            StartJob("Update Master Trees");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Tree"];
            List<MergeObject> pullList = cmdBldr.ListMasterUpdates(Master, comp);

            foreach (MergeObject mRec in pullList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                TreeDO tree = comp.Database.ReadSingleRow<TreeDO>("Tree", mRec.ComponentRowID);
                Master.Update(tree, matchRowid, OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }
            
            EndJob();
           
        }

        public void PullMasterLogUpdates(ComponentFileVM comp)
        {
            StartJob("Update Master Logs");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Log"];
            List<MergeObject> pullList = cmdBldr.ListMasterUpdates(Master, comp);

            foreach (MergeObject mRec in pullList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                LogDO log = comp.Database.ReadSingleRow<LogDO>("Log", mRec.ComponentRowID);
                Master.Update(log, matchRowid, OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullMasterStemUpdates(ComponentFileVM comp)
        {
            StartJob("Update Master Stems");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Stem"];
            List<MergeObject> pullList = cmdBldr.ListMasterUpdates(Master, comp);

            foreach (MergeObject mRec in pullList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                StemDO stem = comp.Database.ReadSingleRow<StemDO>("Stem", mRec.ComponentRowID);
                Master.Update(stem, matchRowid, OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PullMasterPlotUpdates(ComponentFileVM comp)
        {
            StartJob("Update Master Plots");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Plot"];
            List<MergeObject> pullList = cmdBldr.ListMasterUpdates(Master, comp);
            foreach(MergeObject mRec in pullList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                PlotDO plot = comp.Database.ReadSingleRow<PlotDO>("Plot", mRec.ComponentRowID);
                Master.Update(plot, matchRowid, OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }
        #endregion

        #region push field data updates

        public void PushComponentTreeUpdates(ComponentFileVM comp)
        {
            StartJob("Update Component Trees");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Tree"];
            List<MergeObject> pushList = cmdBldr.ListComponentUpdates(Master, comp);
            foreach (MergeObject mRec in pushList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                TreeDO tree = Master.ReadSingleRow<TreeDO>("Tree", matchRowid);
                //TODO need to handle condition where MasterRowID is different from ComponentRowID
                comp.Database.Update(tree, mRec.ComponentRowID.Value, OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }
            EndJob();
        }

        public void PushComponentLogUpdates(ComponentFileVM comp)
        {
            StartJob("Update Component Logs");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Log"];
            List<MergeObject> pushList = cmdBldr.ListComponentUpdates(Master, comp);
            foreach (MergeObject mRec in pushList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                LogDO log = Master.ReadSingleRow<LogDO>("Log", matchRowid);
                comp.Database.Update(log, mRec.ComponentRowID.Value, OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }
            EndJob();
        }

        public void PushComponentStemUpdates(ComponentFileVM comp)
        {
            StartJob("Update Component Stems");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Stem"];
            List<MergeObject> pushList = cmdBldr.ListComponentUpdates(Master, comp);
            foreach (MergeObject mRec in pushList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                StemDO stem = Master.ReadSingleRow<StemDO>("Stem", matchRowid);
                comp.Database.Update(stem, mRec.ComponentRowID.Value, OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }

        public void PushComponentPlotUpdates(ComponentFileVM comp)
        {
            StartJob("Update Component Plots");
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders["Plot"];
            List<MergeObject> pushList = cmdBldr.ListComponentUpdates(Master, comp);
            foreach (MergeObject mRec in pushList)
            {
                CheckWorkerStatus();
                long matchRowid = mRec.MatchRowID.Value;
                PlotDO plot = Master.ReadSingleRow<PlotDO>("Plot", matchRowid);
                comp.Database.Update(plot, mRec.ComponentRowID.Value, OnConflictOption.Fail);
                this.ResetRowVersion(comp, matchRowid, mRec.ComponentRowID.Value, cmdBldr);
                IncrementProgress();
            }

            EndJob();
        }
        #endregion

        private void ResetComponentRowVersion(ComponentFileVM comp, long componentRowID, MergeTableCommandBuilder commBldr)
        {
            comp.Database.Execute("UPDATE " + commBldr.ClientTableName + " SET RowVersion = 0 WHERE RowID = ?;", componentRowID);
        }

        private void ResetRowVersion(ComponentFileVM comp, long masterRowID, long componentRowID, MergeTableCommandBuilder commBldr)
        {
            
            Master.Execute("UPDATE " + commBldr.ClientTableName + " SET RowVersion = 0 WHERE RowID = ?;", masterRowID);
            ResetComponentRowVersion(comp, componentRowID, commBldr);
        }

        #region Calculate work
        private long CountTotalMergeWork()
        {
            long total = CountUpdateActions();
            //total += CountUpdateComponentActions();
            total += CountAddRecordActions();
            return total; 
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

        //public long CountUpdateComponentActions(MergeTableCommandBuilder cmdBldr)
        //{
        //    return Master.GetRowCount(cmdBldr.MergeTableName, cmdBldr.FindMasterToCompUpdates);
        //}

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

        public long CountAddRecordActions(MergeTableCommandBuilder cmdBldr)
        {
            return Master.GetRowCount(cmdBldr.MergeTableName, cmdBldr.FindNewRecords);
        }
        #endregion

        #region 
        private string _currentJobName; 
        //private Stopwatch _stopwatch;

        private void StartJob(string name)
        {
            //if (_stopwatch != null) { _stopwatch.Stop(); }
            //_stopwatch = Stopwatch.StartNew();
            _currentJobName = name;
            this.PostStatus(name); 
            Debug.WriteLine("Started job component " + name);
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

        
        #endregion


        #region IWorker Members

        private object _threadLock = new object();
        private bool _isCanceled;
        private bool _isDone;
        private Thread _thread;
        private int _workInCurrentJob;
        private int _progressInCurrentJob; 

        public event EventHandler<WorkerProgressChangedEventArgs> ProgressChanged;

        public string ActionName { get { return "Merge"; } }

        public bool IsDone 
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
                    _isDone = value;
                }
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

        private int CalcPercentDone(int workDone)
        {
            return (_workInCurrentJob <= 0)? 0 : (int)(100 * (float)workDone / _workInCurrentJob);
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

        public void DoWork()
        {
            try
            {
                this.SyncDesign();
                this.SyncFieldData();
            }
            catch (CancelWorkerException e)
            {
                this.NotifyProgressChanged(0, false, "Canceleled", e);
                throw;
            }
            catch (Exception e)
            {
                this.NotifyProgressChanged(0, false, "Error:" + e.Message, e);
                throw;
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

        private void CheckWorkerStatus()
        {
            if (this.IsCanceled)
            { throw new CancelWorkerException(); }
        }

        protected void IncrementProgress()
        {
            this._progressInCurrentJob++;
            this.NotifyProgressChanged(this._progressInCurrentJob, false, null, null);
        }

        protected void PostStatus(string message)
        {
            this.NotifyProgressChanged(this._progressInCurrentJob, false, message, null); 
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

        #endregion
    }
}

/*
 * 
- push cutting unit inserts : TBT
- push cutting unit updates : N
- push stratum inserts : TBT 
- push stratum updates : N
- push new cutting unit/stratm mappings : TBT
- push removed cutting unit/stratm mappings : TBT
- push samplegroups inserts : TBT
- push samplegroup updates : N
- pull samplegroups inserts : TBT
- pull samplegroup updates : N
- match samplegroups : N
- push tree defaults inserts : TBT
- push tree default updates : N
- pull tree defaults inserts : TBT
- pull tree default updates : N
- match new tree defaults : N
- push new tree default/sg mappings : TBT
- push removed tree default/sg mappings : N 
- pull new tree default/sg mappings : TBT

- pull count tree inserts : TBT
- pull count tree updates : TBT
- push count tree inserts : NP
- push count tree updates : NP 

- pull plot inserts : TBT
- pull plot updates : TBT
- push plot inserts : NP
- push plot updates : TBT 


- pull tree inserts : TBT
- pull tree updates : TBT
- push tree inserts : NP
- push tree updates : TBT 

- pull stem inserts : TBT
- pull stem updates : TBT 
- push stem inserts : NP 
- push stem updates : TBT

- pull lot inserts : TBT
- pull log updates : TBT 
- push log inserts : NP
- push log updates : TBT
 * */
