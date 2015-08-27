using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CSM.UI;
using System.IO;
using CSM.UI.Components;

namespace CSM.Logic
{
    public class CreateComponentPresenter : IPresentor
    {
        static int ROWID_SPACING = 200000;
        static int PLOT_ROW_SPACING = 1000;

        //private int _progressPercentage = 0;
        //private bool _showProgress = false; 
        //private bool _lastOpperationSuccess = false; 
        //private string _lastError = null; 

        private string _masterPath;
        private bool _doesMasterExist;
        public int NumComponents { get; set; }

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

        public DAL ParentDB { get { return Controller.Database; } }
        public CreateComponentView View { get; set; }
        

        public CreateComponentPresenter(IWindowPresenter controller)
        {
            this.Controller = controller;

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
            //start up the progress bar
            int totalSteps = numComponents + 4;
            View.InitializeAndShowProgress(totalSteps); 
  
            if (!_doesMasterExist)
            {
                //initialize a master component file
                //create a master component by creating a copy of the parent
                MasterDAL = parentDB.CopyTo(_masterPath);

                ////clean the master file, any field data from the original file will be removed
                //ClearFieldData(masterDAL);
            }

            View.StepProgressBar();/////////////////////////////////////////////////

            //insert component records into the master file
            List<ComponentDO> componentInfo = BuildMasterComponentTable(MasterDAL, numComponents);
       
            View.StepProgressBar();/////////////////////////////////////////////////

            int curCompNum = 1;
            String saveDir = GetSaveDir(MasterDAL.Path);
            foreach (ComponentDO comp in componentInfo)
            {
                String compPath = string.Format("{0}\\{1}", saveDir, comp.FileName);//extrapolate the path of the comp file

                if (!File.Exists(compPath))
                {
                    CreateComponent(MasterDAL, curCompNum++, comp, compPath);
                }

                View.StepProgressBar();//////////////////////////////////////////////
            }

            //create count record copies in the master for each component
            MasterDAL.Execute(CSM.Utility.SQL.MAKE_COUNTS_FOR_COMPONENTS);

            View.StepProgressBar();/////////////////////////////////////////////////

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

            View.StepProgressBar();/////////////////////////////////////////////////

            View.HideProgressBar();

        }

        protected void CreateComponent(DAL masterDAL, int compNum, ComponentDO compInfo, String compPath)
        {
            //copy master to create component file
            DAL compDB = masterDAL.CopyTo(compPath);

            try
            {
                compDB.BeginTransaction();
                compDB.Execute("DELETE FROM CountTree WHERE Component_CN IS NOT NULL;");
                string command = string.Format("UPDATE CountTree Set Component_CN = {0}, TreeCount = 0, SumKPI = 0;", compInfo.Component_CN);
                compDB.Execute(command);


                //Set the starting rowID for each component 
                compDB.SetTableAutoIncrementStart("Tree", GetComponentRowIDStart(compNum));
                compDB.SetTableAutoIncrementStart("Log", GetComponentRowIDStart(compNum));
                compDB.SetTableAutoIncrementStart("TreeEstimate", GetComponentRowIDStart(compNum));
                compDB.SetTableAutoIncrementStart("Stem", GetComponentRowIDStart(compNum));
                compDB.SetTableAutoIncrementStart("Plot", compNum * PLOT_ROW_SPACING);

                compDB.Execute("DELETE FROM Globals WHERE Block = 'Comp' AND Key = 'ChildComponents';");
                compDB.Execute("DELETE FROM Globals WHERE Block = 'Comp' AND Key = 'LastMerge';");


                compDB.EndTransaction();
            }
            catch (Exception)
            {
                compDB.CancelTransaction();
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



        //private static void ClearFieldData(DAL database)
        //{
        //    database.Execute(CSM.Utility.SQL.CLEAR_FIELD_DATA);
        //}

        //inserts Component Records into master 
        private static List<ComponentDO> BuildMasterComponentTable(DAL masterDAL, int numComp)
        {
            string masterFileName = System.IO.Path.GetFileName(masterDAL.Path);
            List<ComponentDO> compList = new List<ComponentDO>();
            for (int i = 1; i <= numComp; i++)
            {
                String compFileName = GetCompFileName(masterFileName, i);
                ComponentDO compInfo = masterDAL.ReadSingleRow<ComponentDO>("Component", "WHERE FileName = ?", compFileName);
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

        #region IPresentor Members

        public IWindowPresenter Controller { get; set; }

        public void UpdateView()
        {
            //if (View.InvokeRequired)
            //{
            //    View.Invoke(new Action(this.UpdateView));
            //}
            //else
            //{
            //    View.Update(this._showProgress, this._progressPercentage, this._lastOpperationSuccess, this._lastError);
            //}
            //do nothing 
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            
        }

        #endregion

        #region ISaveHandler Members

        public void HandleSave()
        {
            return; //nothing to save
        }

        public void HandleAppClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            return; //do nothing
        }

        public bool CanHandleSave
        {
            get
            {
                return false;
            }
        }

        #endregion

    }
}
