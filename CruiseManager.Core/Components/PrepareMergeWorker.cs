using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using System.Threading;
using CruiseManager.Core.FileMaintenance;

namespace CruiseManager.Core.Components
{


    public class PrepareMergeWorker : IDisposable, IWorker
    {
        public event EventHandler<WorkerProgressChangedEventArgs> ProgressChanged; 

        

        protected DAL MasterDB { get { return this.MergePresenter.MasterDB; } }
        protected IList<ComponentFileVM> Components { get { return this.MergePresenter.ActiveComponents; } }

        public MergeComponentsPresenter MergePresenter { get; set; }

        private IDictionary<String, MergeTableCommandBuilder> CommandBuilders { get { return this.MergePresenter.CommandBuilders; } }

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

            ThreadStart ts = new ThreadStart(this.DoWork);
            this._thread = new Thread(ts)
            {
                IsBackground = true,
                Name = "PrepareMergeWorker"
            };
            this._thread.Start();
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

        //private bool CheckFiles(ConsolidateCountTreeScript maintenanceScript)
        //{
        //    bool masterOK = !maintenanceScript.CheckCanExecute(this.MasterDB);
        //    bool componentsOK = true;
        //    foreach(ComponentFileVM comp in this.Components)
        //    {
        //        bool compOK = !maintenanceScript.CheckCanExecute(comp.Database);
        //        componentsOK = compOK && componentsOK;
        //    }
        //    return masterOK && componentsOK;
        //}

        private void PatchFiles(ConsolidateCountTreeScript maintenanceScript)
        {
            if (maintenanceScript.CheckCanExecute(this.MasterDB))
            {
                PostStatus("Applying CountTree Fix To Master");
                maintenanceScript.Execute(this.MasterDB);
            }
            foreach(ComponentFileVM comp in this.Components)
            {
                if (maintenanceScript.CheckCanExecute(comp.Database))
                {
                    PostStatus("Applying CountTree Fix To " + comp.FileName);
                    maintenanceScript.Execute(comp.Database);
                }
            }
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
            MasterDB.BeginMultiDBTransaction();
            try
            {
                foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
                {
                    PopulateMergeTable(this.MasterDB, cmdBldr, comp);
                }

                //PopulateMergeTable(this.MasterDB, this.CommandBuilders["Tree"], comp);
                //PopulateMergeTable(this.MasterDB, this.CommandBuilders["Log"], comp);
                //PopulateMergeTable(this.MasterDB, this.CommandBuilders["Stem"], comp);
                ////PopulateMergeTable(this.MasterDB, this.CommandBuilders["TreeEstimate"], comp);
                //PopulateMergeTable(this.MasterDB, this.CommandBuilders["Plot"], comp);
                MasterDB.CommitMultiDBTransaction();
                this.NotifyProgressChanged(this._progressInCurrentJob++, false, "Imported Merge Info For Component #" + comp.Component_CN.ToString(), null);
            }
            catch
            {
                MasterDB.RollbackMultiDBTransaction();
                throw;
            }
            finally
            {
                MasterDB.DetachDB("compDB");
            }
        }

        


        private void PopulateMergeTable(DAL masterDB ,MergeTableCommandBuilder table, ComponentFileVM comp)
        {
            CheckWorkerStatus();

            masterDB.ExecuteMultiDB(table.GetPopulateMergeTableCommand(comp));
            masterDB.ExecuteMultiDB(table.GetPopulateDeletedRecordsCommand(comp));
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
                //ProcessMergeTable(mergeDB, this.CommandBuilders["Tree"]);
                //ProcessMergeTable(mergeDB, this.CommandBuilders["Log"]);
                //ProcessMergeTable(mergeDB, this.CommandBuilders["Stem"]);
                ////ProcessMergeTable(mergeDB, this.CommandBuilders["TreeEstimate"]);
                //ProcessMergeTable(mergeDB, this.CommandBuilders["Plot"]);
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
            //set match row id on valid matches 
            

            //if (commandBuider.RecordsUniqueAccrossComponents)
            //{
            //    ProcessCrossComponentConflicts(mergeDB, commandBuider);
            //    IdentifySiblingRecords(mergeDB, commandBuider);
            //}            
            if (commandBuider.HasRowVersion)
            {
                SetMasterRowVersion(mergeDB, commandBuider);
            }
            //if (commandBuider.MergeNewFromComponent)
            //{
            //    SetIncomingPlaceholder(mergeDB, commandBuider);
            //}
            if (commandBuider.MergeNewFromMaster)
            {                
                ProcessMasterNew(mergeDB, commandBuider);
            }



        }

        //private void ProcessExistingMasterRecordsWithoutGuids(DAL mergeDB, MergeTableCommandBuilder commandBuider)
        //{
        //    List<MergeObject> matchs = mergeDB.Query<MergeObject>(
        //        commandBuider.SelectNaturalAndCNMatches);

        //    this._progressInCurrentJob = 0;
        //    this._workInCurrentJob = matchs.Count + 1;
        //    this.NotifyProgressChanged(this._progressInCurrentJob, false, "Processing Records Without GUIDs", null);

        //    String updateCommand = "UPDATE " + commandBuider.MergeTableName + " SET MasterRowID = ?, MasterRowVersion = ?  WHERE MergeRowID = ?;";
        //    foreach (MergeObject c in matchs)
        //    {
        //        CheckWorkerStatus();
        //        mergeDB.Execute(updateCommand, c.MasterRowID, c.MasterRowVersion, c.MergeRowID);
        //        this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
        //    }
        //}

        //private void ProcessExistingRecords(DAL mergeDB, MergeTableCommandBuilder commandBuider)
        //{
        //    //match records in master with records in component and set Master row id
        //    List<MergeObject> matches = mergeDB.Query<MergeObject>(
        //        commandBuider.SelectGUIDMatches);

        //    this._progressInCurrentJob = 0;
        //    this._workInCurrentJob = matches.Count + 1;
        //    this.NotifyProgressChanged(this._progressInCurrentJob, false, "Processing Existing Records", null);

        //    String updateCommand = String.Format("UPDATE {0} SET MasterRowID = ?, MasterRowVersion = ? WHERE MergeRowID = ?;", commandBuider.MergeTableName);
        //    foreach (MergeObject item in matches)
        //    {
        //        CheckWorkerStatus();
        //        mergeDB.Execute(updateCommand, item.MasterRowID, item.MasterRowVersion, item.MergeRowID);
        //        this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
        //    }
        //}

        //private void ProcessCrossComponentConflicts(DAL mergeDB, MergeTableCommandBuilder commandBuider)
        //{
        //    //check other merge records to see if there are any conflicts with other records being merged
        //    List<MergeObject> matches = mergeDB.Query<MergeObject>(
        //       commandBuider.NaturalCrossComponentConflictsCommand);

        //    this._workInCurrentJob += matches.Count;
        //    this.NotifyProgressChanged(this._progressInCurrentJob, false, "Processing  Cross Component Conflicts", null);

        //    String updateCommand = "UPDATE " + commandBuider.MergeTableName + " SET ComponentConflict = ? WHERE MergeRowID = ?;";
        //    foreach (MergeObject c in matches)
        //    {
        //        CheckWorkerStatus();
        //        mergeDB.Execute(updateCommand, c.ComponentConflict, c.MergeRowID);
        //        this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
        //    }
        //}

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
            foreach(MergeObject mRec in partialMatchs)
            {
                mergeDB.Execute(setPartialMatch, mRec.PartialMatch, mRec.MergeRowID);
            }
        }


        //private void ProcessMasterConflicts(DAL mergeDB, MergeTableCommandBuilder commandBuider)
        //{
        //    //check merge records agains master table for conflicts
        //    List<MergeObject> conflicts = mergeDB.Query<MergeObject>(
        //        commandBuider.MasterConflicts);

        //    this._progressInCurrentJob = 0;
        //    this._workInCurrentJob = conflicts.Count + 1;
        //    this.NotifyProgressChanged(this._progressInCurrentJob, false, "Processing Master Conflicts", null);

        //    String updateCommand = String.Format("UPDATE {0} SET MasterConflict = ? WHERE MergeRowID = ?;", commandBuider.MergeTableName);
        //    foreach (MergeObject item in conflicts)
        //    {
        //        CheckWorkerStatus();
        //        mergeDB.Execute(updateCommand, item.MasterConflict, item.MergeRowID);
        //        this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
        //    }
        //}

        private void ProcessComparisons(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            if (cmdBldr.DoKeyMatch)
            {
                List<MergeObject> keyMatches = master.Query<MergeObject>(cmdBldr.SelectRowIDMatches);                
                this._workInCurrentJob += keyMatches.Count;
                string setKeyMatch = "UPDATE " + cmdBldr.MergeTableName + " SET RowIDMatch = ? WHERE MergeRowID = ?;";
                foreach (MergeObject item in keyMatches)
                {
                    CheckWorkerStatus();
                    master.Execute(setKeyMatch, item.RowIDMatch, item.MergeRowID);
                    this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
                }
            }

            if (cmdBldr.DoNaturalMatch)
            {
                List<MergeObject> natMatches = master.Query<MergeObject>(cmdBldr.SelectNaturalMatches);
                this._workInCurrentJob += natMatches.Count;
                string setNatMatch = "UPDATE " + cmdBldr.MergeTableName + " SET NaturalMatch = ? WHERE MergeRowID = ?;";
                foreach(MergeObject mRec in natMatches)
                {
                    CheckWorkerStatus();
                    master.Execute(setNatMatch, mRec.NaturalMatch, mRec.MergeRowID);
                    this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
                }
            }

            if (cmdBldr.HasGUIDKey)
            {
                List<MergeObject> guidMatches = master.Query<MergeObject>(cmdBldr.SelectGUIDMatches);
                this._workInCurrentJob += guidMatches.Count;
                string setGuidMatch = "UPDATE " + cmdBldr.MergeTableName + " SET GUIDMatch = ? WHERE MergeRowID = ?;";
                foreach(MergeObject mRec in guidMatches)
                {
                    CheckWorkerStatus();
                    master.Execute(setGuidMatch, mRec.GUIDMatch, mRec.MergeRowID);
                    this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
                }
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

        //private void ProcessInvalidMatchs(DAL master, MergeTableCommandBuilder cmdBldr)
        //{
        //    string setConflict = "UPDATE " + cmdBldr.MergeTableName + 
        //        " SET MatchConflict = 'invalid match' " +
        //        "WHERE MergeRowID IN (" + cmdBldr.SelectInvalidMatchs +");";
        //    master.Execute(setConflict);
        //}

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

        //private void SetIncomingPlaceholder(DAL master, MergeTableCommandBuilder cmdBldr)
        //{
        //    List<MergeObject> incomming = master.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName +
        //        " WHERE MatchRowID IS NULL AND MatchConflict IS NULL" +
        //        " GROUP BY " + String.Join(", ", cmdBldr.ClientUniqueFieldNames) + 
        //        " ORDER BY ComponentID;");
        //    this._workInCurrentJob += incomming.Count;


        //    string setplaceHolder = "UPDATE " + cmdBldr.MergeTableName + " SET IncomingPlaceholder = ? WHERE MergeRowID = ?;";
        //    long placeHolderCounter = 0; 
        //    foreach (MergeObject mRec in incomming)
        //    {
        //        CheckWorkerStatus();
        //        master.Execute(setplaceHolder, placeHolderCounter++, mRec.MergeRowID);
        //        this.NotifyProgressChanged(this._progressInCurrentJob++, false, null, null);
        //    }
        //}

        private void ProcessMasterNew(DAL master, MergeTableCommandBuilder cmdBldr)
        {
            foreach (ComponentFileVM comp in this.Components)
            {
                List<MergeObject> missingMatches = master.Query<MergeObject>(cmdBldr.SelectMissingMatches(comp));
                string insertMissingMatch = "INSERT INTO " + cmdBldr.MergeTableName + " (MatchRowID, ComponentID) " +
                    "VALUES (?,?);";
                foreach (MergeObject mRec in missingMatches)
                {
                    master.Execute(insertMissingMatch, mRec.MatchRowID, comp.Component_CN);
                }
            }
        }

        private void CheckWorkerStatus()
        {
            if (this.IsCanceled) 
            { throw new CancelWorkerException();  }
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

        #endregion

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

        #endregion
    }

}
