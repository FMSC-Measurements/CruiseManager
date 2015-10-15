using System;
using System.Collections.Generic;
using CruiseDAL;
using System.Linq;
using System.ComponentModel;
using CruiseDAL.DataObjects;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using CruiseManager.Utility;
using FMSC.Utility.Collections;
using System.Threading;
using CruiseManager.Core.Models;
using CruiseManager.Core.SetupModels;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;

namespace CruiseManager.WinForms.CruiseWizard
{
    public class CruiseWizardPresenter 
    {
        private SaleDO _sale;
        private BindingListRedux<CuttingUnitDO> _cuttingUnits = new BindingListRedux<CuttingUnitDO>();
        private BindingListRedux<StratumVM> _strata = new BindingListRedux<StratumVM>();
        private List<string> _cruiseMethods = new List<string>();
        private List<LoggingMethod> _loggingMethods = new List<LoggingMethod>();
        private List<ProductCode> _productCodes = new List<ProductCode>();
        private List<UOMCode> _uomCodes = new List<UOMCode>();
        private List<TreeDefaultValueDO> _treeDefaults = new List<TreeDefaultValueDO>();
        private List<Region> _regions = new List<Region>();

        private FileInfo _templateFile;
        private bool _fileHasTemplate = false;
        private Thread _copyTemplateThread;
        private DAL _templateDatabase;
        private const int WAIT_COPY_TEMPLATE_TIMEOUT = 4;//seconds


        private bool _isFinished = false;//flag for indicating if the view is closing from the user cliking finish, or canceling
        protected DAL _database;


        #region Properties
        public WindowPresenter WindowPresenter { get; set; }
        protected ApplicationController ApplicationController { get; set; }
        public CruiseWizardView View { get; set; }

        public DAL Database 
        {
            get
            {
                return _database;
            }
            protected set
            {
                _database = value;
            }
        }

        #region cruise data properties

        public SaleDO Sale
        {
            get { return _sale; }
            set
            {
                _sale = value;                
            }
        }

        public BindingListRedux<CuttingUnitDO> CuttingUnits 
        {
            get { return _cuttingUnits; }
            set
            {
                if (_cuttingUnits != value)
                {
                    if (_cuttingUnits != null)
                    {
                        _cuttingUnits.ItemRemoved -= this.OnCuttingUnitRemoved;
                    }
                    if (value != null)
                    {
                        value.ItemRemoved += this.OnCuttingUnitRemoved;
                    }
                    _cuttingUnits = value;
                    View.UpdateCuttingUnits(value);
                }
            }
        }

        public BindingListRedux<StratumVM> Strata 
        {
            get { return _strata; }
            set
            {
                if (_strata != value)
                {
                    if (_strata != null)
                    {
                        _strata.ItemRemoved -= this.OnStratumRemoved;
                    }
                    if (value != null)
                    {
                        value.ItemRemoved += this.OnStratumRemoved;
                    }
                    _strata = value;
                    View.UpdateStrata(value);
                }
            }
        }

        public List<TreeDefaultValueDO> TreeDefaults
        {
            get { return _treeDefaults; }
            set
            {
                _treeDefaults = value;
                View.UpdateTreeDefaults(value);
            }
        }
        #endregion

        #region Setup properties
        public List<FileInfo> LocalTemplateFiles
        {
            get
            {
                return ApplicationController.GetTemplateFiles();
            }
        }

        public List<string> CruiseMethods 
        {
            get { return _cruiseMethods; }
            set
            {
                _cruiseMethods = value;
                View.UpdateCruiseMethods(value);
            }
        }

        public List<LoggingMethod> LoggingMethods 
        {
            get { return _loggingMethods; }
            set
            {
                _loggingMethods = value;
                View.UpdateLoggingMethods(value);
            }
        }

        public List<ProductCode> ProductCodes 
        {
            get { return _productCodes; }
            set
            {
                _productCodes = value;
                View.UpdateProduectCodes(value);
            }
        }

        public List<Region> Regions
        {
            get { return _regions; }
            set
            {
                _regions = value;
                //View.UpdateRegions(value);
            }
        }

        public List<UOMCode> UOMCodes 
        {
            get { return _uomCodes; }
            set
            {
                _uomCodes = value;
                View.UpdateUOMCodes(value);
            }
        }
        #endregion 
        #endregion 


        #region CTor 
        //TODO make testable constructor 

        public CruiseWizardPresenter(CruiseWizardView View, WindowPresenter windowPresenter, ApplicationController applicationController, DAL database)
        {
            this.View = View;
            this.WindowPresenter = windowPresenter;
            this.ApplicationController = applicationController;
            View.Presenter = this;
            _database = database;

            LoadSetupData();//load tree defaults, product codes, etc.

            LoadCruiseData();//read data from existing file

            //See if the file contains a template file record 
            GlobalsDO record = this._database.ReadSingleRow<GlobalsDO>("Globals", "WHERE Block = 'CSM' AND KEY = 'TemplatePath'");

            if (record != null && !String.IsNullOrEmpty(record.Value))
            {
                this._fileHasTemplate = true; 
                this._templateFile = new FileInfo(record.Value);
                View.SetTemplatePathTextBox(record.Value, false);
            }

            if (this.CuttingUnits.Count == 0)
            {
                this.CuttingUnits.Add(GetNewCuttingUnit());
            }
        }


        #endregion// end ctor       

        //private static string GetTempPath()
        //{
        //    return Path.GetDirectoryName(Application.LocalUserAppDataPath) + "\\" + Strings.TEMP_FILENAME;
        //}



        //public void HandelLoad()
        //{
        //    string tempPath = Path.GetDirectoryName(Application.LocalUserAppDataPath) + "\\~temp.cruise";
        //    if (File.Exists(tempPath) &&
        //       (MessageBox.Show("Partialy created cruise file found, would you like to resume?", "?", MessageBoxButtons.YesNo) == DialogResult.Yes))
        //    {
        //        this.WindowPresenter.ShowWaitCursor();
        //        this._database = new DAL(tempPath);
        //        this.LoadCruiseData();
        //        GlobalsDO record = this._database.ReadSingleRow<GlobalsDO>("Globals", "WHERE Block = 'CSM' AND KEY = 'TemplatePath'");

        //        if (record != null && !String.IsNullOrEmpty(record.Value))
        //        {
        //            this._templateFile = new FileInfo(record.Value);
        //            View.SetTemplatePathTextBox(record.Value, false);
        //        }
        //    }
        //    else
        //    {
        //        this.WindowPresenter.ShowWaitCursor();
        //        this._database = new DAL(tempPath, true);
        //        this.Sale = new SaleDO(this._database);
        //    }

        //    if (this.CuttingUnits.Count == 0)
        //    {
        //        this.CuttingUnits.Add(GetNewCuttingUnit());
        //    }

        //    this.WindowPresenter.ShowDefaultCursor();
        //}

        

        
        //TODO test load methods 
        #region Load methods

        protected void LoadCruiseData()
        {
            this.Sale = this._database.ReadSingleRow<SaleVM>("Sale", null, null) ?? new SaleVM(this._database);
            this.CuttingUnits = new BindingListRedux<CuttingUnitDO>(this._database.Read<CuttingUnitDO>("CuttingUnit", null));

            CruiseMethods = new List<string>(CruiseMethodsDO.ReadCruiseMethodStr(this._database, this.Sale.Purpose == "Recon"));
            //this.CruiseMethods = this._database.Read<CruiseMethod>("CruiseMethods", null);
            this.TreeDefaults = this._database.Read<TreeDefaultValueDO>("TreeDefaultValue", null);


            List<StratumVM> stList = this._database.Read<StratumVM>("Stratum", null);
            foreach (StratumVM stratum in stList)
            {
                stratum.CuttingUnits.Populate();
                List<SampleGroupDO> sgList = this._database.Read<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", stratum.Stratum_CN.Value);
                foreach (SampleGroupDO sg in sgList)
                {
                    sg.TreeDefaultValues.Populate();
                }
                stratum.SampleGroups = sgList;
            }
            this.Strata = new BindingListRedux<StratumVM>(stList);
            
        }

        protected void LoadSetupData()
        {
            var setupServ = this.ApplicationController.SetupService;

            LoggingMethods = setupServ.GetLoggingMethods();
            UOMCodes = setupServ.GetUOMCodes();
            ProductCodes = setupServ.GetProductCodes();
            Regions = setupServ.GetRegions();
            //insert dummy forest, so that the comboboxes have a option when no forest is selected
            foreach (Region r in Regions)
            {
                r.Forests.Insert(0, new Forest() { Name = String.Empty });
            }
        }


        public void LoadTemplate(FileInfo template)
        {
            //redundant condition checking 
            if (template.Exists == false) { return; } // template doesn't exist do nothing..
            if (_templateFile != null) { return; } //template already set, don't reload 
            if (_fileHasTemplate == true) { return; }

            _templateFile = template;

            //insert meta data containing location of template file
            string command = string.Format("INSERT OR REPLACE INTO Globals (Block, Key, Value) VALUES ('CSM', 'TemplatePath', '{0}');", template.FullName);
            this._database.Execute(command);


            try
            {
                _templateDatabase = new DAL(template.FullName);


                //only load FIX and PNT Cruise methods for Recon cruises 
                CruiseMethods = _templateDatabase.GetCruiseMethods(this.Sale.Purpose == "Recon");

                this.StartAsynCopyTemplate(_templateDatabase);
            }
            catch (Exception) 
            {
                MessageBox.Show("Error: Couldn't open template");
            }
            finally
            {
                if (_templateDatabase != null)
                {
                    _templateDatabase.Dispose();
                    _templateDatabase = null;
                }
            }
        }
        #endregion

        #region DO creation and deletion methods

        public CuttingUnitDO GetNewCuttingUnit()
        {
            CuttingUnitDO unit = new CuttingUnitDO(this._database);
            return unit;
        }

        public void OnCuttingUnitRemoved(object sender, ItemRemovedEventArgs e)
        {
            CuttingUnitDO u = e.Item as CuttingUnitDO;
            if (u == null) return;
            DeleteCuttingUnit(u);
        }

        public StratumVM GetNewStratum()
        {
            //because we want to store a list of samplegroups for each strata
            //lets create a list and store it in the Tag. 
            //the tag is a general term for a property on an object that is 
            // designed to attatche extera data to that object that, fufills 
            //an unexpected need. 

            StratumVM newStrata = new StratumVM(this._database);
            newStrata.SampleGroups = new List<SampleGroupDO>();
            return newStrata;
        }

        public void OnStratumRemoved(object sender, ItemRemovedEventArgs e)
        {
            StratumDO s = e.Item as StratumDO;
            if (s == null) return;            
            DeleteStratum(s);
        }

        public void DeleteCuttingUnit(CuttingUnitDO cu)
        {
            if (cu.IsPersisted)
            {
                //cu.Delete();
                CuttingUnitDO.RecursiveDelete(cu);
            }
        }

        public void DeleteStratum(StratumDO st)
        {
            if (st.IsPersisted)
            {
                //st.Delete();
                StratumDO.RecursiveDeleteStratum(st);
            }
        }

        public void DeleteSampleGroup(SampleGroupDO sg)
        {
            if (sg.IsPersisted)
            {
                //sg.Delete();
                SampleGroupDO.RecutsiveDeleteSampleGroup(sg);
            }
        }


        public SampleGroupDO GetNewSampleGroup(StratumDO stratum, SampleGroupDO newSampleGroup)
        {
            if (newSampleGroup == null)
            {
                newSampleGroup = new SampleGroupDO(this._database);
            }


            newSampleGroup.CutLeave = "C";
            newSampleGroup.DefaultLiveDead = "L";
            newSampleGroup.Code = "<Blank>";
            newSampleGroup.Stratum = stratum;
            newSampleGroup.UOM = Sale.DefaultUOM;
            return newSampleGroup;
        }

        public TreeDefaultValueDO GetNewTreeDefaultValue()
        {
            TreeDefaultValueDO tdv = new TreeDefaultValueDO(this._database);
            return tdv;
        }
        #endregion

        #region View lifeCycle

        public void OnViewLoad()
        {
            //View.UpdateSale(this.Sale);

        }

        /// <summary>
        /// Handles when the view is closing, allowing unsaved data to be stored
        /// </summary>
        /// <param name="e"></param>
        public void HandleViewClosing(CancelEventArgs e)
        {
            if (!_isFinished)
            {
                var d = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    switch (View.PageHost.CurrentPage.Name)
                    {
                        case "CuttingUnits":
                            {

                                this.SaveCuttingUnits(true);
                                break;
                            }
                        case "Strata":
                            {
                                this.SaveStrata(true);
                                break;
                            }
                        case "SampleGroups":
                            {
                                this.SaveSampleGroups(true);
                                break;
                            }
                    }
                    this.View.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region page navigation methods


        public void HandleSalePageExit(string templatePath)
        {
            this.Sale.Validate();
            if (this.Sale.HasErrors())
            {
                MessageBox.Show(this.Sale.Error, "Warning", MessageBoxButtons.OK);
                return;
            }


            if (!this._fileHasTemplate)
            {
                if( !string.IsNullOrEmpty(templatePath) 
                    && File.Exists(templatePath))
                {
                    FileInfo template = new FileInfo(templatePath);
                    this.LoadTemplate(template);
                }
                else if (string.IsNullOrEmpty(templatePath))
                {
                    if (MessageBox.Show("No Template selected.\r\nWould you like to continue?", "Continue?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (!File.Exists(templatePath))
                {
                    if (MessageBox.Show("Template path is invalid.\r\nWould you like to continue?", "Continue?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            

            if (CruiseMethods.Count == 0)
            {
                CruiseMethods = DatabaseExtentions.GetCruiseMethods(null, this.Sale.Purpose == "Recon");
            }

            this.ShowCuttingUnits();
        }
 
        public void ShowCuttingUnits()
        {
            try
            {
                this.Sale.Save(OnConflictOption.Replace);
            }
            catch
            {
                MessageBox.Show("error");
                return;
            }
            View.Display("CuttingUnits");
        }

        public void ShowStratum()
        {
            string errorMsg; 
            //display error message if strata data invalid
            if (AreCuttingUnitsValid(out errorMsg) == false)
            {
                MessageBox.Show(errorMsg, "Warning", MessageBoxButtons.OK); 
               return;
            }

            try
            {
                this.SaveCuttingUnits(false);
            }
            catch
            {
                MessageBox.Show("error");
                return;
            }

            View.Display("Strata");
        }

        public void ShowSampleGroups(StratumDO stratum)
        {
            string errorMsg;
            if (AreStrataValid(out errorMsg) == false)
            {
                //MessageBox.Show("Some strata contain errors, please fix before continuing", "Warning", MessageBoxButtons.OK);
                MessageBox.Show(errorMsg, "Warning", MessageBoxButtons.OK);
               return;
            }

            try
            {
                this.SaveStrata(false);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            this.WaitCopyTemplateDone();

            View.Display("SampleGroups");
            //if (stratum != null)
            //{
            //    View.sampleGroupPage.CurrentStratum = stratum;
            //}
        }

        #endregion 

        #region validateion methods
        protected bool AreCuttingUnitsValid(out string errorMsg)
        {
            bool allCUValid = true;
            errorMsg = "Unit Errors Found";
                                            //check has errors on all cutting units 
            foreach (CuttingUnitDO cu in CuttingUnits)
            {
                cu.Validate();              //call validate before we check for errors
                if (cu.HasErrors())
                {
                    allCUValid = false;     //set all valid flag to false
                    errorMsg += "\n  Unit = " + cu.Code;  //add unit code to error message
                    break;                  //and break out of the loop
                }
            }
            return allCUValid;
        }

        protected bool AreStrataValid(out string errorMsg)
        {
            bool allStValid = true;
            errorMsg = "Strata Errors Found";

            
            foreach (StratumDO st in Strata)
            {
                st.Validate();
                if (st.HasErrors())
                {
                    allStValid = false;
                    errorMsg += "\r\n  Stratum " + st.Code + ": " + st.Error; 
                }
                if (st.CuttingUnits.Count == 0)
                {
                    allStValid = false;
                    errorMsg += "\r\n Stratum " + st.Code + " needs Cutting Units";
                }
                if (st.Method == "3PPNT" && st.KZ3PPNT <= 0L)
                {
                    allStValid = false;
                    errorMsg += String.Format("\r\n Stratum {0} needs a KZ value greater than 0", st.Code);
                }
                if ((st.Method == "FIX" || st.Method == "FCM" || st.Method == "F3P") &&
                    st.FixedPlotSize <= 0.0f)
                {
                    allStValid = false;
                    errorMsg += String.Format("\r\n Stratum {0} should have Fixed Plot Size Greater than 0", st.Code);
                }
                if ((st.Method == "PNT" || st.Method == "PCM" || st.Method == "P3P" || st.Method == "3PPNT")
                    && st.BasalAreaFactor <= 0.0f)
                {
                    allStValid = false;
                    errorMsg += String.Format("\r\n Stratum {0} should have BAF greater than 0", st.Code);
                }  

                

            }
            return allStValid;
        }

        public bool AllSampleGroupValid(out string errorMsg)
        {
            bool allSgValid = true;
            System.Text.StringBuilder errorSB = new System.Text.StringBuilder();            
            errorSB.AppendLine("Sample Group Errors Found");

            foreach (StratumVM st in Strata)
            {
                IList<SampleGroupDO> sgList = st.SampleGroups;

                foreach (SampleGroupDO sg in sgList)
                {
                    string error;
                    if (!SampleGroupDO.ValidateSetup(sg, st, out error))
                    {
                        allSgValid = false;
                        errorSB.AppendLine(error);
                    }
                }


                //    sg.Validate();
                //    if(sg.HasErrors())
                //    {
                //        allSgValid = false;
                //        errorSB.AppendLine("Stratum = " + st.Code + " SG = " + sg.Code + sg.Error);
                //    }
                //    if (String.IsNullOrEmpty(sg.Code))
                //    {
                //        errorSB.AppendLine("Stratum = " + st.Code + " SG = " + sg.Code + " Code can't be empty");
                //        allSgValid = false;
                //    }
                //    if (sg.TreeDefaultValues.Count == 0)
                //    {
                //        errorSB.AppendLine("Stratum = " + st.Code + " SG = " + sg.Code + " No Tree Tree Defaults Selected");
                //    }
                //    string tmp = string.Empty; 
                //    if(!sg.ValidatePProdOnTDVs(ref tmp))
                //    {
                //        errorSB.AppendLine(tmp);
                //        allSgValid = false;
                //    }
                //}
            }


            errorMsg = (!allSgValid) ? errorSB.ToString() : null;
            return allSgValid;
        }
        #endregion

        


        /// <summary>
        /// Start CopyTemplate thread
        /// </summary>
        /// <param name="templateDB">template db to copy</param>
        protected void StartAsynCopyTemplate(DAL templateDB)
        {
            try
            {
                _copyTemplateThread = new System.Threading.Thread((ParameterizedThreadStart)this.CopyTemplateData);
                _copyTemplateThread.Start(templateDB);
            }
            catch
            {
                if (_copyTemplateThread != null)
                {
                    _copyTemplateThread.Abort();
                    _copyTemplateThread = null;
                }
                throw;
            }
        }

        /// <summary>
        /// Wait for CopyTemplate thread to end
        /// </summary>
        protected void WaitCopyTemplateDone()
        {
            if (_copyTemplateThread != null)
            {
                try
                {
                    if (_copyTemplateThread.Join(WAIT_COPY_TEMPLATE_TIMEOUT * 1000))
                    {

                    }
                    else
                    {
                        //TODO gracefully abort copy template, using abort flag
                        _copyTemplateThread.Join();
                    }
                }
                finally
                {
                    if (_templateDatabase != null)
                    {
                        _templateDatabase.Dispose();
                        _templateDatabase = null;
                    }
                    _copyTemplateThread = null;
                }
            }

        }


        //override for call by ParameterizedThreadStart
        private void CopyTemplateData(object obj)
        {
            this.CopyTemplateData((DAL)obj);
        }

        protected void CopyTemplateData(DAL templateDB)
        {

            //List<TreeAuditValueDO> treeAuditValues = templateDB.Read<TreeAuditValueDO>("TreeAuditValue", null);

            //foreach (TreeDefaultValueDO tdv in templateDB.Read<TreeDefaultValueDO>("TreeDefaultValue", null, null))
            //{
            //    tdv.TreeAuditValues.Populate();
            //    //tdv.DAL = null;
            //    TreeDefaults.Add(tdv);
            //}

            //foreach (TreeAuditValueDO tav in treeAuditValues)
            //{
            //    tav.DAL = _database;
            //    tav.Save();
            //}

            //foreach (TreeDefaultValueDO tdv in TreeDefaults)
            //{
            //    tdv.DAL = _database;
            //    tdv.Save();
            //    tdv.TreeAuditValues.Save();
            //}
            _database.Execute(@"
DELETE FROM TreeDefaultValue;
DELETE FROM TreeAuditValue;
DELETE FROM TreeDefaultValueTreeAuditValue;");//ensure that these tables are clean 
            _database.DirectCopy(templateDB, CruiseDAL.Schema.TREEDEFAULTVALUE._NAME, null, OnConflictOption.Fail);
            _database.DirectCopy(templateDB, CruiseDAL.Schema.TREEAUDITVALUE._NAME, null, OnConflictOption.Fail);
            _database.DirectCopy(templateDB, CruiseDAL.Schema.TREEDEFAULTVALUETREEAUDITVALUE._NAME, null, OnConflictOption.Fail);

            this.TreeDefaults = _database.Read<TreeDefaultValueDO>(CruiseDAL.Schema.TREEDEFAULTVALUE._NAME, null);

            _database.DirectCopy(templateDB, "Reports", null, OnConflictOption.Ignore);

            string CMselectCondition = null;
            if (this.Sale.Purpose == "Recon")
            {
                CMselectCondition = "Where Code = 'FIX' OR Code = 'PNT'";
            }
            _database.DirectCopy(templateDB, CruiseDAL.Schema.CRUISEMETHODS._NAME, CMselectCondition, OnConflictOption.Ignore);

            _database.DirectCopy(templateDB, CruiseDAL.Schema.VOLUMEEQUATION._NAME, null, OnConflictOption.Ignore);
            _database.DirectCopy(templateDB, CruiseDAL.Schema.TREEFIELDSETUPDEFAULT._NAME, null, OnConflictOption.Ignore);
            _database.DirectCopy(templateDB, CruiseDAL.Schema.LOGFIELDSETUPDEFAULT._NAME, null, OnConflictOption.Ignore);
            _database.DirectCopy(templateDB, CruiseDAL.Schema.TALLY._NAME, null, OnConflictOption.Ignore);
        }

       

        

        /// <summary>
        /// helper method for Finish, executes database command that creates field set up entries from field setup defaults
        /// </summary>
        /// <param name="stratum"></param>
        /// <param name="database"></param>
        private void SetFieldSetup(StratumDO stratum, DAL database)
        {
            string setTreeFieldCommand = String.Format(@"INSERT OR IGNORE INTO TreeFieldSetup (Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior)
            Select {0} as Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior 
            FROM TreeFieldSetupDefault 
            WHERE Method = '{1}';", stratum.Stratum_CN, stratum.Method);

            string setLogFieldCommand = String.Format(@"INSERT OR IGNORE INTO LogFieldSetup (Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior)
            Select {0} as Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior
            FROM LogFieldSetupDefault;",
            stratum.Stratum_CN);

            database.Execute(setTreeFieldCommand);
            database.Execute(setLogFieldCommand);
        }

        //private bool IsNewCruise()
        //{
        //    return Path.GetFileName(_database.Path) == Strings.TEMP_FILENAME;
        //}

        public void Finish()
        {
            string errorMsg;
            if (AllSampleGroupValid(out errorMsg) == false)
            {
                MessageBox.Show(errorMsg, "Warning", MessageBoxButtons.OK);
                return;
            }

            try
            {
                View.Cursor = Cursors.WaitCursor;
                this.SaveSampleGroups(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                View.Cursor = Cursors.Default;
            }
   
            
            View.DialogResult = DialogResult.OK;
            _isFinished = true;
            View.Close();

        }

        protected void SaveCuttingUnits(bool tryToSaveAll)
        {
            foreach (CuttingUnitDO c in this.CuttingUnits)
            {
                try
                {
                    c.Save();
                }
                catch
                {
                    if (!tryToSaveAll)
                    {
                        throw;
                    }
                }

            }
        }

        protected void SaveStrata(bool tryToSaveAll)
        {
            foreach (StratumDO s in this.Strata)
            {
                try
                {
                    bool isNewStratum = !s.IsPersisted;
                    s.Save();

                    if (isNewStratum)
                    {
                        SetFieldSetup(s, _database);
                    }

                    s.CuttingUnits.Save();
                }
                catch
                {
                    if (!tryToSaveAll)
                    {
                        throw;
                    }
                }
            }
        }

        protected void SaveSampleGroups(bool tryToSaveAll)
        {
            foreach (StratumVM s in this.Strata)
            {
                //s.DAL = myDatabase;
                //s.Save();

                //SetFieldSetup(s, myDatabase);

                //s.CuttingUnits.Save();

                //set the strata forgen key on all sample groups and save
                foreach (SampleGroupDO sg in s.SampleGroups)
                {
                    try
                    {
                        sg.Stratum = s;
                        string error;
                        if (!SampleGroupDO.ValidateSetup(sg, s, out error))
                        {
                            continue;
                        }

                        if (sg.Code == "<Blank>")
                        {
                            sg.Code = " ";
                        }
                        if (sg.DAL == null) { sg.DAL = _database; }
                        sg.Save();

                        //ensure all tree defaults in sampleGroup are save to the database
                        foreach (TreeDefaultValueDO tdv in sg.TreeDefaultValues)
                        {
                            if (tdv.IsPersisted == true) { continue; }
                            if (tdv.DAL == null) { tdv.DAL = _database; }//just in case, but should already be set
                            tdv.Save();
                        }

                        sg.TreeDefaultValues.Save();
                    }
                    catch
                    {
                        if (!tryToSaveAll)
                        {
                            throw;
                        }
                    }

                }
            }
        }

    }
}
