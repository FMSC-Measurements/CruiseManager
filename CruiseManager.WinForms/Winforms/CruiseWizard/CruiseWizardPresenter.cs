using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Models;
using CruiseManager.Core.SetupModels;
using FMSC.ORM.Core.SQL;
using FMSC.Utility.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseWizard
{
    public class CruiseWizardPresenter
    {
        private const int WAIT_COPY_TEMPLATE_TIMEOUT = 4;
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
        private bool _fileHasTemplate;
        private Thread _copyTemplateThread;
        private DAL _templateDatabase;

        private bool _isFinished;//flag for indicating if the view is closing from the user clicking finish, or canceling
        protected DAL _database;

        #region Properties

        public WindowPresenter WindowPresenter { get; set; }
        protected ApplicationControllerBase ApplicationController { get; set; }
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
                        _cuttingUnits.ItemRemoved -= OnCuttingUnitRemoved;
                    }
                    if (value != null)
                    {
                        value.ItemRemoved += OnCuttingUnitRemoved;
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
                        _strata.ItemRemoved -= OnStratumRemoved;
                    }
                    if (value != null)
                    {
                        value.ItemRemoved += OnStratumRemoved;
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
                //View.UpdateTreeDefaults(value);
            }
        }

        #endregion cruise data properties

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

        public IEnumerable<ProductCode> SecondaryProductCodes
        {
            get
            {
                yield return ProductCode.Empty;
                foreach (var pc in ProductCodes)
                {
                    yield return pc;
                }
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

        #endregion Setup properties

        #endregion Properties

        //TODO make testable constructor

        public CruiseWizardPresenter(CruiseWizardView View, WindowPresenter windowPresenter, ApplicationControllerBase applicationController, DAL database)
        {
            this.View = View;
            WindowPresenter = windowPresenter;
            ApplicationController = applicationController;
            View.Presenter = this;
            _database = database;

            LoadSetupData();//load tree defaults, product codes, etc.

            LoadCruiseData();//read data from existing file

            //See if the file contains a template file record
            var templatePath = _database.ReadGlobalValue("CSM", "TemplatePath");

            if (!String.IsNullOrEmpty(templatePath))
            {
                _fileHasTemplate = true;
                _templateFile = new FileInfo(templatePath);
                View.SetTemplatePathTextBox(templatePath, false);
            }

            if (CuttingUnits.Count == 0)
            {
                CuttingUnits.Add(GetNewCuttingUnit());
            }
        }

        //TODO test load methods

        #region Load methods

        protected void LoadCruiseData()
        {
            Sale = _database.From<SaleVM>().Read().FirstOrDefault() ?? new SaleVM(_database);
            CuttingUnits = new BindingListRedux<CuttingUnitDO>(_database.From<CuttingUnitDO>().Read().ToList());

            CruiseMethods = _database.GetCruiseMethods(Sale.Purpose == "Recon");
            //this.CruiseMethods = this._database.Read<CruiseMethod>("CruiseMethods", null);
            TreeDefaults = _database.From<TreeDefaultValueDO>().Read().ToList();

            var stList = _database.From<StratumVM>().Read().ToList();
            foreach (StratumVM stratum in stList)
            {
                stratum.CuttingUnits.Populate();
                var sgList = _database.From<SampleGroupDO>().Where("Stratum_CN = ?").Read(stratum.Stratum_CN).ToList();
                foreach (SampleGroupDO sg in sgList)
                {
                    sg.TreeDefaultValues.Populate();
                }
                stratum.SampleGroups = sgList;
            }
            Strata = new BindingListRedux<StratumVM>(stList);
        }

        protected void LoadSetupData()
        {
            var setupServ = ApplicationController.SetupService;

            LoggingMethods = setupServ.GetLoggingMethods();
            UOMCodes = setupServ.GetUOMCodes();
            ProductCodes = setupServ.GetProductCodes();
            Regions = setupServ.GetRegions();
            //insert dummy forest, so that the combo-boxes have a option when no forest is selected
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
            _database.WriteGlobalValue("CSM", "TemplatePath", template.FullName);

            try
            {
                _templateDatabase = new DAL(template.FullName);

                //only load FIX and PNT Cruise methods for Recon cruises
                CruiseMethods = _templateDatabase.GetCruiseMethods(Sale.Purpose == "Recon");
                _fileHasTemplate = true;
                StartAsynCopyTemplate(_templateDatabase);
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

        #endregion Load methods

        #region DO creation and deletion methods

        public CuttingUnitDO GetNewCuttingUnit()
        {
            var unit = new CuttingUnitDO(_database);
            return unit;
        }

        public void OnCuttingUnitRemoved(object sender, ItemRemovedEventArgs e)
        {
            var u = e.Item as CuttingUnitDO;
            if (u == null) return;
            DeleteCuttingUnit(u);
        }

        public StratumVM GetNewStratum()
        {
            var newStrata = new StratumVM(_database);
            newStrata.SampleGroups = new List<SampleGroupDO>();
            return newStrata;
        }

        public void OnStratumRemoved(object sender, ItemRemovedEventArgs e)
        {
            var s = e.Item as StratumDO;
            if (s == null) return;
            DeleteStratum(s);
        }

        public void DeleteCuttingUnit(CuttingUnitDO cu)
        {
            if (cu.IsPersisted)
            {
                CuttingUnitDO.RecursiveDelete(cu);
            }
        }

        public void DeleteStratum(StratumDO st)
        {
            if (st.IsPersisted)
            {
                StratumDO.RecursiveDeleteStratum(st);
            }
        }

        public void DeleteSampleGroup(SampleGroupDO sg)
        {
            if (sg.IsPersisted)
            {
                SampleGroupDO.RecutsiveDeleteSampleGroup(sg);
            }
        }

        public SampleGroupDO GetNewSampleGroup(StratumDO stratum, SampleGroupDO newSampleGroup)
        {
            if (newSampleGroup == null)
            {
                newSampleGroup = new SampleGroupDO(_database);
            }

            newSampleGroup.CutLeave = "C";
            newSampleGroup.DefaultLiveDead = "L";
            newSampleGroup.Code = "<Blank>";
            newSampleGroup.Stratum = stratum;

            if (stratum.Method == CruiseDAL.Schema.CruiseMethods.FIXCNT)
            {
                newSampleGroup.UOM = "03";
            }
            else
            {
                newSampleGroup.UOM = Sale.DefaultUOM;
            }

            return newSampleGroup;
        }

        public TreeDefaultValueDO GetNewTreeDefaultValue()
        {
            var tdv = new TreeDefaultValueDO(_database);
            return tdv;
        }

        #endregion DO creation and deletion methods

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
                var d = MessageBox.Show(View, "Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    switch (View.PageHost.CurrentPage.Name)
                    {
                        case "CuttingUnits":
                            {
                                SaveCuttingUnits(true);
                                break;
                            }
                        case "Strata":
                            {
                                SaveStrata(true);
                                break;
                            }
                        case "SampleGroups":
                            {
                                SaveSampleGroups(true);
                                break;
                            }
                    }
                    View.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion View lifeCycle

        #region page navigation methods

        public void HandleSalePageExit(string templatePath)
        {
            Sale.Validate();
            if (Sale.HasErrors())
            {
                MessageBox.Show(Sale.Error, "Warning", MessageBoxButtons.OK);
                return;
            }

            if (!_fileHasTemplate)
            {
                if (!string.IsNullOrEmpty(templatePath)
                    && File.Exists(templatePath))
                {
                    var template = new FileInfo(templatePath);
                    LoadTemplate(template);
                }
                else if (string.IsNullOrEmpty(templatePath))
                {
                    if (MessageBox.Show(View, "No Template selected.\r\nWould you like to continue?", "Continue?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (!File.Exists(templatePath))
                {
                    if (MessageBox.Show(View, "Template path is invalid.\r\nWould you like to continue?", "Continue?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            if (CruiseMethods.Count == 0)
            {
                CruiseMethods = DatabaseExtentions.GetCruiseMethods(null, Sale.Purpose == "Recon");
            }

            ShowCuttingUnits();
        }

        public void ShowSalesPage()
        {
            var e = new CancelEventArgs();
            OnLeavingCuttingUnits(e);
            if (e.Cancel) { return; }

            View.Display("Sale");
        }

        public void ShowCuttingUnits()
        {
            try
            {
                Sale.Save(OnConflictOption.Replace);
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
            var e = new CancelEventArgs();
            OnLeavingCuttingUnits(e);
            if (e.Cancel) { return; }

            View.Display("Strata");
        }

        protected void OnLeavingCuttingUnits(CancelEventArgs e)
        {
            string errorMsg;
            //display error message if strata data invalid

            if (AreCuttingUnitsValid(out errorMsg) == false)
            {
                MessageBox.Show(View, errorMsg, "Warning", MessageBoxButtons.OK);
                e.Cancel = true;
                return;
            }

            try
            {
                SaveCuttingUnits(false);
            }
            catch (FMSC.ORM.UniqueConstraintException)
            {
                MessageBox.Show(View, "Cutting Unit Error: Unit # already exists.");
                e.Cancel = true;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(View, ex.GetType().Name, "Error");
                e.Cancel = true;
                return;
            }
        }

        public void ShowSampleGroups(StratumDO stratum)
        {
            string errorMsg;
            if (AreStrataValid(out errorMsg) == false)
            {
                MessageBox.Show(View, errorMsg, "Warning", MessageBoxButtons.OK);
                return;
            }

            try
            {
                SaveStrata(false);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            WaitCopyTemplateDone();

            View.Display("SampleGroups");
            //if (stratum != null)
            //{
            //    View.sampleGroupPage.CurrentStratum = stratum;
            //}
        }

        #endregion page navigation methods

        #region validation methods

        protected bool AreCuttingUnitsValid(out string errorMsg)
        {
            bool allCUValid = true;
            errorMsg = "Unit Errors Found, ";
            //check has errors on all cutting units

            var dupUnitCodes = CuttingUnits
                .GroupBy(unit => unit.Code)
                .Where(grouping => grouping.Count() > 1)
                .Select(grouping => grouping.Key);

            if (dupUnitCodes.Count() > 0)
            {
                errorMsg += $"Duplicates in Cutting Unit Code(s): {String.Join(", ", dupUnitCodes.ToArray())}";
                allCUValid = false;
            }

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
            var errorSB = new System.Text.StringBuilder();
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
            }

            errorMsg = (!allSgValid) ? errorSB.ToString() : null;
            return allSgValid;
        }

        #endregion validation methods

        /// <summary>
        /// Start CopyTemplate thread
        /// </summary>
        /// <param name="templateDB">template db to copy</param>
        protected void StartAsynCopyTemplate(DAL templateDB)
        {
            try
            {
                _copyTemplateThread = new System.Threading.Thread((ParameterizedThreadStart)CopyTemplateData);
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
            CopyTemplateData((DAL)obj);
        }

        protected void CopyTemplateData(DAL templateDB)
        {
            _database.BeginTransaction();
            try
            {
                foreach (TreeDefaultValueDO tdv in templateDB.From<TreeDefaultValueDO>().Query())
                {
                    _database.Insert(tdv, OnConflictOption.Replace);
                }

                foreach (TreeAuditValueDO tav in templateDB.From<TreeAuditValueDO>().Query())
                {
                    _database.Insert(tav, OnConflictOption.Replace);
                }

                foreach (TreeDefaultValueTreeAuditValueDO map in templateDB.From<TreeDefaultValueTreeAuditValueDO>().Query())
                {
                    _database.Insert(map, OnConflictOption.Replace);
                }

                foreach (ReportsDO rpt in templateDB.From<ReportsDO>().Query())
                {
                    _database.Insert(rpt, OnConflictOption.Replace);
                }

                var crusemethods = templateDB.From<CruiseMethodsDO>();
                if (Sale.Purpose == "Recon")
                {
                    crusemethods.Where("Code = 'FIX' OR Code = 'PNT'");
                }

                foreach (CruiseMethodsDO cm in crusemethods.Query())
                {
                    _database.Insert(cm, OnConflictOption.Ignore);
                }

                foreach (VolumeEquationDO ve in templateDB.From<VolumeEquationDO>().Query())
                {
                    _database.Insert(ve, OnConflictOption.Ignore);
                }

                foreach (TreeFieldSetupDefaultDO tf in templateDB.From<TreeFieldSetupDefaultDO>().Query())
                {
                    _database.Insert(tf, OnConflictOption.Ignore);
                }

                foreach (LogFieldSetupDefaultDO lf in templateDB.From<LogFieldSetupDefaultDO>().Query())
                {
                    _database.Insert(lf, OnConflictOption.Ignore);
                }

                foreach (var lga in templateDB.From<LogGradeAuditRuleDO>().Query())
                {
                    _database.Insert(lga);
                }

                foreach (var lm in templateDB.From<LogMatrixDO>().Query())
                {
                    _database.Insert(lm, OnConflictOption.Ignore);
                }
                _database.CommitTransaction();
            }
            catch
            {
                _database.RollbackTransaction();
                throw;
            }

            TreeDefaults = _database.From<TreeDefaultValueDO>().Read().ToList();
        }

        /// <summary>
        /// helper method for Finish, executes database command that creates field set up entries from field setup defaults
        /// </summary>
        /// <param name="stratum"></param>
        /// <param name="database"></param>
        private void SetFieldSetup(StratumDO stratum, DAL database)
        {
            var setTreeFieldCommand = String.Format(@"INSERT OR IGNORE INTO TreeFieldSetup (Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior)
            Select {0} as Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior
            FROM TreeFieldSetupDefault
            WHERE Method = '{1}';", stratum.Stratum_CN, stratum.Method);

            var setLogFieldCommand = String.Format(@"INSERT OR IGNORE INTO LogFieldSetup (Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior)
            Select {0} as Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior
            FROM LogFieldSetupDefault;",
            stratum.Stratum_CN);

            database.Execute(setTreeFieldCommand);
            database.Execute(setLogFieldCommand);
        }

        public void Finish()
        {
            string errorMsg;
            if (AllSampleGroupValid(out errorMsg) == false)
            {
                MessageBox.Show(View, errorMsg, "Warning", MessageBoxButtons.OK);
                return;
            }

            try
            {
                View.Cursor = Cursors.WaitCursor;
                SaveSampleGroups(false);
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
            foreach (CuttingUnitDO c in CuttingUnits)
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
            foreach (StratumDO s in Strata)
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
            foreach (StratumVM s in Strata)
            {
                //s.DAL = myDatabase;
                //s.Save();

                //SetFieldSetup(s, myDatabase);

                //s.CuttingUnits.Save();

                //set the strata foreign key on all sample groups and save
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