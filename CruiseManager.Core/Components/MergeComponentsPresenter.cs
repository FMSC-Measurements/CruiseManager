using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Components.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManager.Core.Components
{
    /// <summary>
    /// Drives the view, Loads components and orchestrates the multiple steps in the merging process
    /// </summary>
    public class MergeComponentsPresenter : Presentor
    {
        #region Properties

        public Dictionary<String, MergeTableCommandBuilder> CommandBuilders { get; protected set; } = new Dictionary<string, MergeTableCommandBuilder>();

        public new IMergeComponentView View
        {
            get { return (IMergeComponentView)base.View; }
            set { base.View = value; }
        }

        public DAL MasterDB => ApplicationController?.Database;
        public List<ComponentFileVM> ActiveComponents { get; set; }
        public List<ComponentFileVM> MissingComponents { get; set; }
        public List<ComponentFileVM> AllComponents { get; set; }

        int _numComponents;

        public int NumComponents
        {
            get { return _numComponents; }
            set
            {
                SetValue(value, ref _numComponents);
            }
        }

        private long _masterTreeCount;

        public long MasterTreeCount
        {
            get { return _masterTreeCount; }
            set { SetValue(value, ref _masterTreeCount); }
        }

        private string _lastMergeDate;

        public string LastMergeDate
        {
            get { return _lastMergeDate; }
            set { SetValue(value, ref _lastMergeDate); }
        }

        #region CurrentWorker

        private IWorker _currentWorker;

        public IWorker CurrentWorker
        {
            get
            {
                return _currentWorker;
            }
            private set
            {
                OnCurrentWorkerChanging();
                _currentWorker = value;
                OnCurrentWorkerChanged();
            }
        }

        private void OnCurrentWorkerChanging()
        {
            var currentWorker = CurrentWorker;
            if (currentWorker != null)
            {
                currentWorker.ProgressChanged -= this.CurrentWorker_ProgressChanged;
            }
        }

        private void OnCurrentWorkerChanged()
        {
            var currentWorker = CurrentWorker;
            if (currentWorker != null)
            {
                currentWorker.ProgressChanged += this.CurrentWorker_ProgressChanged;
            }
            CurrentWorker_ProgressChanged(currentWorker, new WorkerProgressChangedEventArgs());
        }

        private void CurrentWorker_ProgressChanged(Object sender, WorkerProgressChangedEventArgs e)
        {
            if (View != null)
            {
                View.HandleProgressChanged(sender, e);
            }
        }

        #endregion CurrentWorker

        public bool IsWorkerReady
        {
            get
            {
                if (_currentWorker == null) { return false; }
                return !(_currentWorker.IsWorking || _currentWorker.IsDone);
            }
        }

        #endregion Properties

        public MergeComponentsPresenter(IApplicationController applicationController)
            : base(applicationController)
        {
            Initialize(applicationController.Database);
            InitializeMergeTableCommandBuilders();

            this.CurrentWorker = new PrepareMergeWorker(this);
            this.CurrentWorker.ProgressChanged += this.HandelPrepareProgressChanged;
        }

        void Initialize(DAL master)
        {
            try
            {
                var value = master.ReadGlobalValue("Comp", "ChildComponents");
                NumComponents = Convert.ToInt32(value);
            }
            catch
            {
                NumComponents = 0;
            }

            MasterTreeCount = MasterDB.GetRowCount("Tree", null, null);

            LastMergeDate = String.Empty;
        }

        /// <summary>
        /// Initializes some configuration information for each table that we will be merging
        /// Note there are some tables that we aren't setting up because we will be merging
        /// them using a more hands on method in the MergeSyncWorker
        /// </summary>
        private void InitializeMergeTableCommandBuilders()
        {
            AddCommandBuilder(new MergeTableCommandBuilder(this.MasterDB, "Tree")
            {
                DoGUIDMatch = true,
                DoKeyMatch = true,
                DoNaturalMatch = true,
                MergeChangesFromComponent = true,
                MergeChangesFromMaster = true,
                RecordsUniqueAccrossComponents = true,
                MergeNewFromComponent = true,
                MergeNewFromMaster = false,
                MergeDeletionsFromComponent = false
            });
            AddCommandBuilder(new MergeTableCommandBuilder(this.MasterDB, "Log")
            {
                DoGUIDMatch = true,
                DoKeyMatch = true,
                DoNaturalMatch = true,
                MergeChangesFromComponent = true,
                MergeChangesFromMaster = true,
                RecordsUniqueAccrossComponents = true,
                MergeNewFromComponent = true,
                MergeNewFromMaster = false,
                MergeDeletionsFromComponent = false
            });
            AddCommandBuilder(new MergeTableCommandBuilder(this.MasterDB, "Stem")
            {
                DoGUIDMatch = true,
                DoKeyMatch = true,
                DoNaturalMatch = true,
                MergeChangesFromComponent = true,
                MergeChangesFromMaster = true,
                RecordsUniqueAccrossComponents = true,
                MergeNewFromComponent = true,
                MergeNewFromMaster = false,
                MergeDeletionsFromComponent = false
            });
            AddCommandBuilder(new MergeTableCommandBuilder(this.MasterDB, "Plot")
            {
                DoGUIDMatch = true,
                DoKeyMatch = true,
                DoNaturalMatch = true,
                MergeChangesFromComponent = true,
                MergeChangesFromMaster = true,
                RecordsUniqueAccrossComponents = true,
                MergeNewFromComponent = true,
                MergeNewFromMaster = false,
                MergeDeletionsFromComponent = false
            });
        }

        void AddCommandBuilder(MergeTableCommandBuilder cmd)
        {
            CommandBuilders.Add(cmd.ClientTableName, cmd);
        }

        public void FindComponents()
        {
            string searchDir = System.IO.Path.GetDirectoryName(MasterDB.Path);
            this.FindComponents(searchDir);
        }

        public void FindComponents(string searchDir)
        {
            System.Diagnostics.Debug.Assert(MasterDB != null);
            MissingComponents = new List<ComponentFileVM>();
            ActiveComponents = new List<ComponentFileVM>();
            AllComponents = this.MasterDB.From<ComponentFileVM>().Read().ToList();

            foreach (ComponentFileVM comp in this.AllComponents)
            {
                comp.FullPath = System.IO.Path.Combine(searchDir, comp.FileName);

                if (InitializeComponent(comp))//try to initialize component, if initialization fails add to missing file list
                {
                    this.ActiveComponents.Add(comp);
                }
                else
                {
                    this.MissingComponents.Add(comp);
                }
            }

            if (View != null)
            { this.View.UpdateMergeInfoView(); }
        }

        private bool InitializeComponent(ComponentFileVM comp)
        {
            comp.ResetCounts();
            if (!System.IO.File.Exists(comp.FullPath))
            {
                comp.Errors = "File not found";
                return false;
            }

            try
            {
                comp.Database = new DAL(comp.FullPath);

                String[] errors;
                if (comp.Database.HasCruiseErrors(out errors))
                {
                    comp.Errors += string.Join("\r\n", errors);
                    //TODO return false?
                }

                //older files may not have GUIDs on records
                //check for and assign GUIDs to records that don't have them
                if (UpdateMasterWorker.HasUnassignedGUIDs(comp.Database))
                {
                    UpdateMasterWorker.AssignGuids(comp.Database);
                }

                //TODO anyway to test if file is readonly ?

                return true;
            }
            catch (Exception e)
            {
                comp.Errors += e.Message;
                return false;
            }
        }

        //private static string GetLastMergeDate(DAL dataBase)
        //{
        //    GlobalsDO globalData = dataBase.ReadSingleRow<GlobalsDO>("Globals", "WHERE Block = 'Comp' AND Key = 'LastMerge'");

        //    if (globalData != null)
        //    {
        //        return globalData.Value;
        //    }
        //    return string.Empty;
        //}

        //private static void SetLastMergeDate(DAL db, string dateStr)
        //{
        //    db.WriteGlobalValue("Comp", "LastMerge", dateStr);
        //}

        //TODO remove unused method
        private int GetCountSum(CountTreeDO masterCopy)
        {
            int countSum = 0;
            foreach (ComponentFileVM comp in this.ActiveComponents)
            {
                var compCount = comp.Database.From<CountTreeDO>()
                    .Where("CountTree_CN = @p1").Read(masterCopy.CountTree_CN).FirstOrDefault();

                countSum += (int)compCount.TreeCount;
            }
            return countSum;
        }

        public List<MergeObject> ListConflicts(String clientTableName)
        {
            System.Diagnostics.Debug.Assert(this.CommandBuilders.ContainsKey(clientTableName));
            MergeTableCommandBuilder cmdBldr = this.CommandBuilders[clientTableName];
            return this.ListConflicts(cmdBldr);
        }

        public List<MergeObject> ListConflicts(MergeTableCommandBuilder cmdBldr)
        {
            return this.MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + cmdBldr.FindConflictsFilter + ";", (object[])null).ToList();
        }

        public List<MergeObject> ListMatches(MergeTableCommandBuilder cmdBldr)
        {
            return this.MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + " WHERE " + cmdBldr.FindMatchesBase + ";", (object[])null).ToList();
        }

        public List<MergeObject> ListNew(MergeTableCommandBuilder cmdBldr)
        {
            return this.MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + cmdBldr.FindNewRecords + ";", (object[])null).ToList();
        }

        public List<MergeObject> ListDeleted(MergeTableCommandBuilder cmdBldr)
        {
            return this.MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + " WHERE IsDeleted = 1;", (object[])null).ToList();
        }

        public int GetNumConflicts()
        {
            long totalConflicts = 0;
            foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
            {
                totalConflicts += MasterDB.GetRowCount(cmdBldr.MergeTableName, cmdBldr.FindConflictsFilter);
            }

            return (int)totalConflicts;
        }

        private void HandelPrepareProgressChanged(Object sender, WorkerProgressChangedEventArgs e)
        {
            if (e.IsDone)
            {
                View.ShowPremergeReport();
                if (GetNumConflicts() == 0)
                {
                    this.CurrentWorker = new MergeSyncWorker(this);
                }
                else
                {
                    this.View.ShowMessage("Conflicts/Errors found\r\n Please Resolve Before Continuing", null);
                    //System.Windows.Forms.MessageBox.Show("Conflicts/Errors found\r\n Please Resolve Before Continuing");
                }
            }
        }

        public string ExplaneMergeRecord(MergeObject mRec)
        {
            string error = String.Empty;

            //if (mRec.ComponentConflict != null)
            //{
            //    error += "Conflict found with record in component " + mRec.ComponentConflictFileID + " ";
            //    if (mRec.ComponentConflict != mRec.ComponentRowID)
            //    { error += "possibly the same tree entered into different files "; }
            //    else
            //    { error += "possibly because field data from other components was not removed when component file was created "; }
            //}
            //if (mRec.MasterConflict != null)
            //{
            //    error += "Conflict found with record in Master ";
            //    if (mRec.MasterConflict == mRec.ComponentRowID)
            //    {
            //        error += "possibly because another copy of component file made initial merge of this record, please find original component file ";
            //    }
            //    else
            //    {
            //        error += "duplicate record ";
            //    }
            //}

            return error;
        }

        #region Presenter Members

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            this.FindComponents();
        }

        #endregion Presenter Members

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            var isDisposed = IsDisposed;
            base.Dispose(disposing);
            if (disposing && !isDisposed)
            {
                if (this.ActiveComponents != null)
                {
                    foreach (ComponentFileVM comp in this.ActiveComponents)
                    {
                        if (comp.Database != null)
                        {
                            comp.Database.Dispose();
                            comp.Database = null;
                        }
                    }
                }
            }
        }

        #endregion IDisposable Members
    }
}