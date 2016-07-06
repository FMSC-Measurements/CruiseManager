using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Components.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;

namespace CruiseManager.Core.Components
{
    public class MergeComponentsPresenter : Presentor
    {
        public MergeComponentsPresenter(ApplicationControllerBase applicationController)
            : base(applicationController)
        {
            InitializeMergeTableCommandBuilders();

            this.CurrentWorker = new PrepareMergeWorker(this);
            this.CurrentWorker.ProgressChanged += this.HandelPrepareProgressChanged;
        }

        public Dictionary<String, MergeTableCommandBuilder> CommandBuilders = new Dictionary<string, MergeTableCommandBuilder>();

        public new IMergeComponentView View
        {
            get { return (IMergeComponentView)base.View; }
            set { base.View = value; }
        }

        public DAL MasterDB { get { return ApplicationController.Database; } }
        public List<ComponentFileVM> ActiveComponents { get; set; }
        public List<ComponentFileVM> MissingComponents { get; set; }
        public List<ComponentFileVM> AllComponents { get; set; }

        public int NumComponents
        {
            get
            {
                try
                {
                    GlobalsDO info = MasterDB.ReadSingleRow<GlobalsDO>("Globals", "WHERE Block = 'Comp' AND Key = 'ChildComponents'");
                    return Convert.ToInt32(info.Value);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public long MasterTreeCount
        {
            get
            {
                return MasterDB.GetRowCount("Tree", null, null);
            }
        }

        public string LastMergeDate
        {
            get
            {
                return GetLastMergeDate(MasterDB);
            }
        }

        private IWorker _currentWorker;

        public bool IsWorkerReady
        {
            get
            {
                if (_currentWorker == null) { return false; }
                return !(_currentWorker.IsWorking || _currentWorker.IsDone);
            }
        }

        public IWorker CurrentWorker
        {
            get
            {
                return _currentWorker;
            }
            private set
            {
                if (_currentWorker != null)
                {
                    _currentWorker.ProgressChanged -= this.CurrentWorker_ProgressChanged;
                }
                if (value != null) { value.ProgressChanged += this.CurrentWorker_ProgressChanged; }
                _currentWorker = value;
                this.CurrentWorker_ProgressChanged(null, new WorkerProgressChangedEventArgs());
            }
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            this.FindComponents();
        }

        private void CurrentWorker_ProgressChanged(Object sender, WorkerProgressChangedEventArgs e)
        {
            if (View != null)
            {
                View.HandleProgressChanged(sender, e);
            }
        }

        private void InitializeMergeTableCommandBuilders()
        {
            List<MergeTableCommandBuilder> temp = new List<MergeTableCommandBuilder>();
            temp.Add(new MergeTableCommandBuilder(this.MasterDB, "Tree")
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
            temp.Add(new MergeTableCommandBuilder(this.MasterDB, "Log")
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
            temp.Add(new MergeTableCommandBuilder(this.MasterDB, "Stem")
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
            temp.Add(new MergeTableCommandBuilder(this.MasterDB, "Plot")
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

            foreach (MergeTableCommandBuilder cmdBldr in temp)
            {
                this.CommandBuilders.Add(cmdBldr.ClientTableName, cmdBldr);
            }
        }

        public void FindComponents()
        {
            string searchDir = System.IO.Path.GetDirectoryName(MasterDB.Path);
            this.FindComponents(searchDir);
        }

        public void FindComponents(string searchDir)
        {
            System.Diagnostics.Debug.Assert(MasterDB != null);
            this.MissingComponents = new List<ComponentFileVM>();
            this.ActiveComponents = new List<ComponentFileVM>();
            this.AllComponents = this.MasterDB.Read<ComponentFileVM>("Component", null);

            foreach (ComponentFileVM comp in this.AllComponents)
            {
                comp.FullPath = searchDir + "\\" + comp.FileName;

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
                if (UpdateMasterWorker.HasUnassignedGUIDs(comp.Database))
                {
                    UpdateMasterWorker.AssignGuids(comp.Database);
                }

                String[] errors;
                if (comp.Database.HasCruiseErrors(out errors))
                {
                    comp.Errors += string.Join("\r\n", errors);
                }
                return true;
            }
            catch (Exception e)
            {
                comp.Errors += e.Message;
                return false;
            }
        }

        private static string GetLastMergeDate(DAL dataBase)
        {
            //GlobalsDO globalData = dataBase.ReadSingleRow<GlobalsDO>("Globals", "WHERE Block = 'Comp' AND Key = 'LastMerge'");

            //if (globalData != null)
            //{
            //    return globalData.Value;
            //}
            return string.Empty;
        }

        private static void SetLastMergeDate(DAL db, string dateStr)
        {
            GlobalsDO data = new GlobalsDO(db)
            {
                Block = "Comp",
                Key = "LastMerge",
                Value = dateStr
            };
            data.Save(FMSC.ORM.Core.SQL.OnConflictOption.Replace);
        }

        private int GetCountSum(CountTreeDO masterCopy)
        {
            int countSum = 0;
            foreach (ComponentFileVM comp in this.ActiveComponents)
            {
                CountTreeDO compCount = comp.Database.ReadSingleRow<CountTreeDO>
                    ("CountTree", masterCopy.CountTree_CN);

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
            return this.MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + cmdBldr.FindConflictsFilter + ";");
        }

        public List<MergeObject> ListMatches(MergeTableCommandBuilder cmdBldr)
        {
            return this.MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + " WHERE " + cmdBldr.FindMatchesBase + ";");
        }

        public List<MergeObject> ListNew(MergeTableCommandBuilder cmdBldr)
        {
            return this.MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + cmdBldr.FindNewRecords + ";");
        }

        public List<MergeObject> ListDeleted(MergeTableCommandBuilder cmdBldr)
        {
            return this.MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + " WHERE IsDeleted = 1;");
        }

        public int GetNumConflicts()
        {
            long totalConflicts = 0;
            foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
            {
                totalConflicts += MasterDB.GetRowCount(cmdBldr.MergeTableName, cmdBldr.FindConflictsFilter);
            }

            //totalConflicts += MasterDB.GetRowCount("MergeTree", findConflictFilter);
            //totalConflicts += MasterDB.GetRowCount("MergeLog", findConflictFilter);
            //totalConflicts += MasterDB.GetRowCount("MergeStem", findConflictFilter);
            //totalConflicts += MasterDB.GetRowCount("MergePlot", findConflictFilter);
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

        #region Presentor Members

        //protected override void OnViewLoad(EventArgs e)
        //{
        //}

        #endregion Presentor Members

        #region IDisposable Members

        private bool _disposed;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && !_disposed)
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
                _disposed = true;
            }
        }

        #endregion IDisposable Members
    }
}