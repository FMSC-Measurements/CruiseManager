using Backpack.SqlBuilder;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Components.ViewInterfaces;
using CruiseManager.Core.Constants;
using CruiseManager.Core.ViewModel;
using CruiseManager.Services;
using FMSC.ORM.Core.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace CruiseManager.Core.Components
{
    public class CreateComponentPresenter : Presentor
    {
        public static int MAX_COMPONENTS = 99;
        static int ROWID_SPACING = 200000;
        static int PLOT_ROW_SPACING = 1000;

        //private int _progressPercentage = 0;
        //private bool _showProgress = false;
        //private bool _lastOpperationSuccess = false;
        //private string _lastError = null;

        private string _masterPath;
        private bool _doesMasterExist;
        public int NumComponents { get; set; }

        public event ProgressChangedEventHandler ProgressChanged;

        private DAL _masterDAL;

        private DAL MasterDAL
        {
            get
            {
                return _masterDAL;
            }
            set
            {
                if (_masterDAL != null)
                {
                    if (value != null && _masterDAL.Path == value.Path)
                    { return; }//break out
                    else
                    {
                        _masterDAL.Dispose();
                    }
                }
                _masterDAL = value;
            }
        }

        public DAL ParentDB { get; }

        public new ICreateComponentView View
        {
            get { return (ICreateComponentView)base.View; }
            set { base.View = value; }
        }

        public CreateComponentPresenter(IDatabaseProvider databaseProvider)
        {
            ParentDB = databaseProvider.Database;

            InitializeState();
        }

        private void InitializeState()
        {
            _masterPath = GetMasterPath(ParentDB.Path);
            _doesMasterExist = File.Exists(_masterPath);
            if (_doesMasterExist)
            {
                MasterDAL = new DAL(_masterPath);
                NumComponents = (int)MasterDAL.GetRowCount(CruiseDAL.Schema.COMPONENT._NAME, null);
            }
        }

        public void MakeComponents(int numComponents)
        {
            this.MakeComponents(this.ParentDB, numComponents);
        }

        protected void MakeComponents(DAL parentDB, int numComponents)
        {
            numComponents = Math.Min(numComponents, MAX_COMPONENTS);

            //start up the progress bar
            int totalSteps = numComponents + 4;
            var stepCompleated = 0;
            RaiseProgressChanged(totalSteps, stepCompleated++);

            if (!_doesMasterExist)
            {
                //initialize a master component file
                //create a master component by creating a copy of the parent
                parentDB.CopyTo(_masterPath);
                MasterDAL = new DAL(_masterPath);
                SetRowIDs(MAX_COMPONENTS + 1, MasterDAL);

                ////clean the master file, any field data from the original file will be removed
                //ClearFieldData(masterDAL);
            }

            RaiseProgressChanged(totalSteps, stepCompleated++);/////////////////////////////////////////////////

            //insert component records into the master file
            List<ComponentDO> componentInfo = BuildMasterComponentTable(MasterDAL, numComponents);

            RaiseProgressChanged(totalSteps, stepCompleated++);/////////////////////////////////////////////////

            int curCompNum = 1;
            String saveDir = GetSaveDir(MasterDAL.Path);
            foreach (ComponentDO comp in componentInfo)
            {
                String compPath = string.Format("{0}\\{1}", saveDir, comp.FileName);//extrapolate the path of the comp file

                if (!File.Exists(compPath))
                {
                    CreateComponent(MasterDAL, curCompNum++, comp, compPath);
                }

                RaiseProgressChanged(totalSteps, stepCompleated++);//////////////////////////////////////////////
            }

            //create count record copies in the master for each component
            MasterDAL.Execute(SQL.MAKE_COUNTS_FOR_COMPONENTS);

            RaiseProgressChanged(totalSteps, stepCompleated++);/////////////////////////////////////////////////

            //add some meta data to the master
            GlobalsDO lastMergeEntry = new GlobalsDO(MasterDAL)
            {
                Block = "Comp",
                Key = "LastMerge",
                Value = string.Empty
            };
            lastMergeEntry.Save(OnConflictOption.Ignore);

            GlobalsDO numCompEntry = new GlobalsDO(MasterDAL)
            {
                Block = "Comp",
                Key = "ChildComponents",
                Value = numComponents.ToString()
            };
            numCompEntry.Save(OnConflictOption.Replace);

            RaiseProgressChanged(totalSteps, stepCompleated++, true);/////////////////////////////////////////////////
        }

        void RaiseProgressChanged(int totalSteps, int compleated, bool? done = false)
        {
            var percentDone = (compleated * 100) / (totalSteps * 100);
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(percentDone, done));
        }

        protected void CreateComponent(DAL masterDAL, int compNum, ComponentDO compInfo, String compPath)
        {
            //copy master to create component file
            masterDAL.CopyTo(compPath);
            var compDB = new DAL(compPath);

            try
            {
                compDB.BeginTransaction();
                compDB.Execute("DELETE FROM CountTree WHERE Component_CN IS NOT NULL;");
                compDB.Execute(SQL.CLEAR_FIELD_DATA);
                string command = string.Format("UPDATE CountTree Set Component_CN = {0};", compInfo.Component_CN);
                compDB.Execute(command);

                SetRowIDs(compNum, compDB);

                compDB.Execute("DELETE FROM Globals WHERE Block = 'Comp' AND Key = 'ChildComponents';");
                compDB.Execute("DELETE FROM Globals WHERE Block = 'Comp' AND Key = 'LastMerge';");

                compDB.CommitTransaction();
            }
            catch (Exception)
            {
                compDB.RollbackTransaction();
                try
                {
                    //component is probably jacked up, so delete it
                    System.IO.File.Delete(compDB.Path);
                }
                catch { } //may throw exception if file doesn't exist, but we can ignore that
            }
            finally
            {
                compDB.Dispose();
            }
        }

        private static void SetRowIDs(int fileNum, DAL fileDB)
        {
            //Set the starting rowID for each component
            fileDB.SetTableAutoIncrementStart("Tree", GetComponentRowIDStart(fileNum));
            fileDB.SetTableAutoIncrementStart("Log", GetComponentRowIDStart(fileNum));
            fileDB.SetTableAutoIncrementStart("TreeEstimate", GetComponentRowIDStart(fileNum));
            fileDB.SetTableAutoIncrementStart("Stem", GetComponentRowIDStart(fileNum));
            fileDB.SetTableAutoIncrementStart("Plot", fileNum * PLOT_ROW_SPACING);
        }

        //private static void ClearFieldData(DAL database)
        //{
        //    database.Execute(CSM.Utility.SQL.CLEAR_FIELD_DATA);
        //}

        //inserts Component Records into master
        private static List<ComponentDO> BuildMasterComponentTable(DAL masterDAL, int numComp)
        {
            var masterFileName = System.IO.Path.GetFileName(masterDAL.Path);
            var compList = new List<ComponentDO>();
            for (int i = 1; i <= numComp; i++)
            {
                String compFileName = GetCompFileName(masterFileName, i);
                var compInfo = masterDAL.From<ComponentDO>()
                    .Where("FileName = ?").Read(compFileName).FirstOrDefault();
                if (compInfo == null)
                {
                    compInfo = new ComponentDO(masterDAL);
                    compInfo.GUID = Guid.NewGuid().ToString();
                    compInfo.FileName = compFileName;
                    compInfo.Save();
                }

                compList.Add(compInfo);
            }
            return compList;
        }

        protected static int GetComponentRowIDStart(int compNum)
        {
            return compNum * ROWID_SPACING;
        }

        private static string GetCompFileName(string masterFileName, int compNum)
        {
            return masterFileName.Replace(".M.cruise", String.Format(".{0}.cruise", compNum));
        }

        private static string GetSaveDir(string parentPath)
        {
            return System.IO.Path.GetDirectoryName(parentPath);
        }

        private static string GetMasterPath(string parentPath)
        {
            if (parentPath.Contains(".M.cruise")) { return parentPath; }
            return parentPath.Replace(".cruise", ".M.cruise");
        }

        #region Presentor Members

        //protected override void OnViewLoad(EventArgs e)
        //{
        //}

        #endregion Presentor Members
    }
}