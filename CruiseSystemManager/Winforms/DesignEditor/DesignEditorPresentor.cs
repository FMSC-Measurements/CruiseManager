using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using System.ComponentModel;
using CruiseDAL;
using System.Windows.Forms;
using CSM.Utility.Setup;
using CSM.Logic;
using CSM.Utility;
using CSM.Models;
using CSM.Common;

namespace CSM.Winforms.DesignEditor
{
    public class DesignEditorPresentor : IPresentor, ISaveHandler
    {
        private CuttingUnitDO _anyUnitOption;
        private DesignEditorStratum _anyStratumOption;
        private DesignEditViewControl _view;
        
        public DesignEditorPresentor(IWindowPresenter windowPresenter)
        {
            this.WindowPresenter = windowPresenter;
            this.DataContext = new DesignEditorDataContext();
            if (Database != null)
            {
                UpdateView();
            }
            
            LoadSetup();
            
        }

        public DesignEditViewControl View 
        {
            get { return _view; }
            set
            {
                _view = value;
                if (value != null)
                {
                    _view.Presentor = this;
                    _view.BindSetup();
                    _view.BindData();
                }
            }
        }
        public IWindowPresenter WindowPresenter { get; set; }
        public DAL Database 
        { 
            get { return WindowPresenter.Database; }
        }
        public bool IsSupervisor { get { return WindowPresenter.AppState.InSupervisorMode; } }

        public DesignEditorDataContext DataContext { get; set; }

        public List<Region> Regions { get; set; }
        public List<string> CruiseMethods { get; set; }
        public List<ProductCode> ProductCodes { get; set; }
        public List<LoggingMethod> LoggingMethods { get; set; }
        public List<UOMCode> UOMCodes { get; set; }

        public StratumDO _SampleGroups_SelectedStrata;
        public StratumDO SampleGroups_SelectedStrata 
        {
            get { return _SampleGroups_SelectedStrata; }
            set
            {
                _SampleGroups_SelectedStrata = value;
                if (value != null)
                {
                    DataContext.SampleGroups = new BindingList<SampleGroupDO>((from sg in DataContext.AllSampleGroups
                                                                   where sg.Stratum.Stratum_CN == value.Stratum_CN
                                                                   select sg).ToList());
                }
                else
                {
                    DataContext.SampleGroups = new BindingList<SampleGroupDO>(DataContext.AllSampleGroups);
                }
                View.SampleGroupBindingSource.DataSource = DataContext.SampleGroups;
            }
        }


        void OnTreeDefaultsChanged(bool error)
        {
            View.SampleGroup_TDVBindingSource.DataSource = DataContext.AllTreeDefaults;
        }

        public void FilterCutttingUnits(StratumDO filterBy)
        {
            if (DataContext.AllCuttingUnits == null) { return; }
            if (filterBy.Code != "ANY")
            {
                List<CuttingUnitDO> units = (from cu in DataContext.AllCuttingUnits
                                             where cu.Strata.Contains(filterBy)
                                             select cu).ToList();
                DataContext.CuttingUnits = new BindingList<CuttingUnitDO>(units);
            }
            else
            {
                DataContext.CuttingUnits = DataContext.AllCuttingUnits;
                
            }
            View.CuttingUnitsBindingSource.DataSource = DataContext.CuttingUnits;
        }

        public void FilterStrata(CuttingUnitDO filterBy)
        {
            if (DataContext.AllStrata == null) { return; }
            if (filterBy.Code != "ANY")
            {
                var strata = (from st in DataContext.AllStrata
                                          where st.CuttingUnits.Contains(filterBy)
                                          select st).ToList();
                DataContext.Strata = new BindingList<DesignEditorStratum>(strata);
            }
            else
            {
                DataContext.Strata = DataContext.AllStrata;
                
            }
            View.StrataBindingSource.DataSource = DataContext.Strata;
        }

        public void AddCuttingUnit()
        {
            this.FilterCutttingUnits(_anyStratumOption);
            GetNewCuttingUnit();
        }

        public CuttingUnitDO GetNewCuttingUnit()
        {
            if (DataContext.AllCuttingUnits == null) { return null; }
            CuttingUnitDO newUnit = new CuttingUnitDO(this.Database);
            DataContext.AllCuttingUnits.Add(newUnit);
            //Data.CuttingUnits.Add(newUnit);
            DataContext.OnDataModified();
            newUnit.DAL = Database;
            return newUnit;
        }
        
        public void AddStratum()
        {
            //this.FilterStrata(_anyUnitOption);
            GetNewStratum();
        }

        public StratumDO GetNewStratum()
        {
            if (DataContext.AllStrata == null) { return null; }
            var newStratum = new DesignEditorStratum(Database);
            DataContext.AllStrata.Add(newStratum);
            //Data.Strata.Add(newStratum);
            DataContext.OnDataModified();
            DataContext.StrataFilterSelectionList.Add(newStratum);
            return newStratum;
        }
        
        public SampleGroupDO GetNewSampleGroup()
        {
            System.Diagnostics.Debug.Assert(DataContext.AllSampleGroups != null);

            if (SampleGroups_SelectedStrata == null)
            {
                throw new UserFacingException("Please Select Stratum", null);
            }

            var newSampleGroup = new SampleGroupDO(Database);
            newSampleGroup.Code = "<blank>";
            newSampleGroup.Stratum = SampleGroups_SelectedStrata;
            newSampleGroup.UOM = DataContext.Sale.DefaultUOM;
            newSampleGroup.CutLeave = "C";
            newSampleGroup.DefaultLiveDead = "L";
            DataContext.AllSampleGroups.Add(newSampleGroup);
            DataContext.SampleGroups.Add(newSampleGroup);
            DataContext.OnDataModified();
            return newSampleGroup;
        }

        public void DeleteCuttingUnit(CuttingUnitDO unit)
        {
            System.Diagnostics.Debug.Assert(DataContext != null);

            if (!CanEditCuttingUnitField(unit, null))
            {
                throw new UserFacingException("Can not delete unit because it contains cruise data", null);
            }

            DataContext.CuttingUnits.Remove(unit);
            DataContext.AllCuttingUnits.Remove(unit);
            DataContext.DeletedCuttingUnits.Add(unit);

            DataContext.CuttingUnitFilterSelectionList.Remove(unit);            
        }

        public void DeleteStratum(DesignEditorStratum stratum)
        {

            if (!CanEditStratumField(stratum, null))
            {
                MessageBox.Show("Can not delete stratum because it contains cruise data");
                return;
            }

            DataContext.Strata.Remove(stratum);
            DataContext.DeletedStrata.Add(stratum);
            DataContext.AllStrata.Remove(stratum);
            DataContext.StrataFilterSelectionList.Remove(stratum);

            var mySampleGroups = (from sg in DataContext.AllSampleGroups
                                  where sg.Stratum == stratum
                                  select sg).ToList();
            foreach (SampleGroupDO sg in mySampleGroups)
            {
                DataContext.AllSampleGroups.Remove(sg);
            }

            if (SampleGroups_SelectedStrata == stratum)
            {
                SampleGroups_SelectedStrata = DataContext.AllStrata.FirstOrDefault();
            }
        }

        public void DeleteSampleGroup(SampleGroupDO sampleGroup)
        {
            System.Diagnostics.Debug.Assert(DataContext.SampleGroups != null && DataContext.AllSampleGroups != null);

            if (!CanEditSampleGroupField(sampleGroup, null))
            {
                throw new UserFacingException("Can Not Delete Sample Group With Cruise Data", null);
            }

            DataContext.SampleGroups.Remove(sampleGroup);
            DataContext.AllSampleGroups.Remove(sampleGroup);
            DataContext.DeletedSampleGroups.Add(sampleGroup);
        }

        public void DeleteTreeDefaultValue(TreeDefaultValueDO tdv)
        {
            if (!this.CanDeleteTreeDefault(tdv))
            {
                throw new UserFacingException("Can't Delete Species Because it has tree data or tree counts.", null);
            }

            this.DataContext.AllTreeDefaults.Remove(tdv);
            this.DataContext.DeletedTreeDefaults.Add(tdv);
        }


        public void LoadSetup()
        {
            var setupServ = SetupService.GetHandle();
            Regions = setupServ.GetRegions();
            CruiseMethods = this.WindowPresenter.GetCruiseMethods(this.DataContext.Sale.Purpose == "Recon");
            LoggingMethods = setupServ.GetLoggingMethods();
            UOMCodes = setupServ.GetUOMCodes();
            ProductCodes = setupServ.GetProductCodes();
        }

        /// <summary>
        /// gets called when a value gets changed on a sample group
        /// </summary>
        /// <param name="sg"></param>
        /// <param name="propName"></param>
        public void HandleSampleGroupValueChanged(SampleGroupDO sg, string propName)
        {
            if (sg == null) { return; }
            //if value changed was sampling frequency or insurance frequency, reset the sampler state
            if ((propName == CruiseDAL.Schema.SAMPLEGROUP.SAMPLINGFREQUENCY
                || propName == CruiseDAL.Schema.SAMPLEGROUP.INSURANCEFREQUENCY))
            {
                sg.SampleSelectorState = string.Empty;
            }

        }


        public void UpdateView()
        {
            //start wait cursor
            if (View != null)
            {
                View.Cursor = Cursors.WaitCursor;
            }
            
            //initialize sale
            DataContext.Sale = Database.ReadSingleRow<SaleVM>("Sale", null, null) ?? new SaleVM(Database);

            //initialize cuttingunits 
            var units = Database.Read<CuttingUnitDO>("CuttingUnit", null, null);
            foreach (CuttingUnitDO cu in units)
            {
                cu.Strata.Populate();
            }
            DataContext.AllCuttingUnits = new BindingList<CuttingUnitDO>(units);
            DataContext.CuttingUnits = new BindingList<CuttingUnitDO>(units);

            BindingList<CuttingUnitDO> filterUnits = new BindingList<CuttingUnitDO>(units.ToList());
            _anyUnitOption = new CuttingUnitDO();
            _anyUnitOption.Code = "ANY";
            filterUnits.Insert(0, _anyUnitOption);
            DataContext.CuttingUnitFilterSelectionList = filterUnits;

            

            //initialize strata
            var strata = Database.Read<DesignEditorStratum>("Stratum", null, null);
            foreach (StratumDO st in strata)
            {
                st.CuttingUnits.Populate();
            }
            DataContext.AllStrata = new BindingList<DesignEditorStratum>(strata);
            DataContext.Strata = new BindingList<DesignEditorStratum>(strata);

            BindingList<DesignEditorStratum> filterStrata = new BindingList<DesignEditorStratum>(strata.ToList());
            _anyStratumOption = new DesignEditorStratum();
            _anyStratumOption.Code = "ANY";
            filterStrata.Insert(0, _anyStratumOption);
            DataContext.StrataFilterSelectionList = filterStrata;

            //initialize TreeDefault
            List<TreeDefaultValueDO> tdvList = Database.Read<TreeDefaultValueDO>("TreeDefaultValue", null, null);
            DataContext.AllTreeDefaults = new BindingList<TreeDefaultValueDO>(tdvList);

            //initialize sample groups
            List<SampleGroupDO> sampleGroups = Database.Read<SampleGroupDO>("SampleGroup", null, null);
            DataContext.AllSampleGroups = new BindingList<SampleGroupDO>(sampleGroups);
            DataContext.SampleGroups = new BindingList<SampleGroupDO>(sampleGroups);

            foreach (SampleGroupDO sg in DataContext.AllSampleGroups)
            {                
                sg.TreeDefaultValues.Populate();
            }
            
            
            DataContext.HasUnsavedChanges = false;
            
            //stop wait cursor
            if (View != null)
            {
                View.Cursor = Cursors.Default;
            }
        }

        public bool HasCruiseData(CuttingUnitDO unit)
        {
            if (unit.CuttingUnit_CN == null) { return false; }
            return (Database.GetRowCount("Tree", "WHERE CuttingUnit_CN = ?", unit.CuttingUnit_CN.Value) > 0) 
                || (Database.GetRowCount("CountTree", "WHERE CuttingUnit_CN = ? AND TreeCount > 0", unit.CuttingUnit_CN.Value) > 0);           
        }

        public bool HasCruiseData(StratumDO stratum)
        {
            if (stratum.Stratum_CN == null) { return false; }
            return (Database.GetRowCount("Tree", "WHERE Stratum_CN = ?", stratum.Stratum_CN.Value) > 0)
                || (Database.GetRowCount("CountTree", "JOIN SampleGroup USING (SampleGroup_CN) WHERE Stratum_CN = ? AND TreeCount > 0", stratum.Stratum_CN.Value) > 0);  
        }

        public bool HasCruiseData(SampleGroupDO sg)
        {
            if (sg.SampleGroup_CN == null) { return false; }
            return (Database.GetRowCount("Tree", "WHERE SampleGroup_CN = ?", sg.SampleGroup_CN.Value) > 0)
                || (Database.GetRowCount("CountTree", "WHERE SampleGroup_CN = ? AND TreeCount > 0", sg.SampleGroup_CN.Value) > 0); 
        }

        public bool ValidateData(ref StringBuilder errorBuilder)
        {
            System.Diagnostics.Debug.Assert(DataContext.CuttingUnits != null && DataContext.Strata != null && DataContext.SampleGroups != null);

            bool isValid = true;

            if(!DataContext.Sale.Validate())
            {
                errorBuilder.AppendLine(DataContext.Sale.Error);
                isValid = false;
            }

            foreach (StratumDO st in DataContext.AllStrata)
            {
                if (!st.Validate())
                {
                    errorBuilder.AppendLine(st.Error);
                    isValid = false;
                }
            }

            foreach (CuttingUnitDO unit in DataContext.AllCuttingUnits)
            {
                if (!unit.Validate())
                {
                    errorBuilder.AppendLine(unit.Error);
                    isValid = false;
                }
            }
            
            foreach (SampleGroupDO sg in DataContext.AllSampleGroups)
            {
                if(!sg.Validate())
                {
                    errorBuilder.AppendLine(sg.Error);
                    isValid = false;
                }
                string er; 
                if (!SampleGroupDO.ValidateSetup(sg, sg.Stratum, out er))
                {
                    errorBuilder.AppendLine(er);
                    isValid = false;
                }
                //isValid = sg.ValidatePProdOnTDVs(ref error) && isValid;
            }

            foreach (TreeDefaultValueDO tdv in DataContext.AllTreeDefaults)
            {
                if (!tdv.Validate())
                {
                    errorBuilder.AppendLine(tdv.Error);
                    isValid = false;
                }
            }

            return isValid;
        }



        private bool SaveData()
        {
            
            Database.BeginTransaction();            
            try
            {
                DataContext.Sale.Save();

                foreach (CuttingUnitDO unit in DataContext.AllCuttingUnits)
                {
                    SaveCuttingUnit(unit);
                }

                foreach (StratumDO st in DataContext.AllStrata)
                {
                    SaveStratum(st);
                }

                foreach (SampleGroupDO sg in DataContext.AllSampleGroups)
                {               
                    SaveSampleGroup(sg);                  
                }

                foreach (TreeDefaultValueDO tdv in DataContext.AllTreeDefaults)
                {
                    tdv.Save();
                }

                foreach (TreeDefaultValueDO tdv in DataContext.DeletedTreeDefaults)
                {
                    Database.Execute("DELETE FROM SampleGroupTreeDefaultValue WHERE TreeDefaultValue_CN = ?", tdv.TreeDefaultValue_CN);
                    tdv.Delete();
                }

                foreach (CuttingUnitDO unit in DataContext.DeletedCuttingUnits)
                {
                    CuttingUnitDO.RecursiveDelete(unit);
                }
                
                foreach (SampleGroupDO sg in DataContext.DeletedSampleGroups)
                {
                    SampleGroupDO.RecutsiveDeleteSampleGroup(sg);
                }

                foreach (StratumDO st in DataContext.DeletedStrata)
                {
                    StratumDO.RecursiveDeleteStratum(st);
                }

                Database.EndTransaction();

                DataContext.DeletedTreeDefaults.Clear();
                DataContext.DeletedStrata.Clear();
                DataContext.DeletedCuttingUnits.Clear();
                DataContext.DeletedSampleGroups.Clear();

                DataContext.HasUnsavedChanges = false;
                return true; 
            }
            catch (Exception ex)
            {
                Database.CancelTransaction();
                throw new UserFacingException("Error saving data, please check for errors and try saving again", ex);
            }
            
        }

        public void SetFieldSetup(StratumDO stratum, DAL database)
        {
            string setTreeFieldCommand = String.Format("INSERT INTO TreeFieldSetup (Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior) " +
            "Select {0} as Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior " +
            "FROM TreeFieldSetupDefault " +
            "WHERE Method = '{1}';", stratum.Stratum_CN, stratum.Method);

            string setLogFieldCommand = String.Format("INSERT INTO LogFieldSetup (Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior) " +
            "Select {0} as Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior " +
            "FROM TreeFieldSetupDefault " +
            "WHERE Method = '{1}';", stratum.Stratum_CN, stratum.Method);

            database.Execute(setTreeFieldCommand);
            database.Execute(setLogFieldCommand);
        }

        public void SaveCuttingUnit(CuttingUnitDO unit)
        {
            unit.Save();
        }

        //precondition:
        //All cutting units in stratum.CuttingUnits 
        //are saved
        public void SaveStratum(StratumDO stratum)
        {
            bool isNewStratum = !stratum.IsPersisted;
            stratum.Save();
            stratum.CuttingUnits.Save();

            if (isNewStratum)
            {
                SetFieldSetup(stratum, stratum.DAL);
            }
        }

        public void SaveSampleGroup(SampleGroupDO sampleGroup)
        {
            if (sampleGroup.Code == "<blank>")
            {
                sampleGroup.Code = " ";
            }
            sampleGroup.Save();
            sampleGroup.TreeDefaultValues.Save();
        }

        public bool CanEditCuttingUnitField(CuttingUnitDO unit, String fieldName)
        {
            if(unit.IsPersisted == false) { return true; }
            if (HasCruiseData(unit) == false) { return true; }
            if(IsSupervisor == true) { return true; }
            if (R.Strings.EDITABLE_UNIT_FILEDS.Contains(fieldName)) { return true; }
            return false;
        }

        public bool CanEditStratumField(StratumDO stratum, String fieldName)
        {
            if (fieldName == "KZ3PPNT" && stratum.Method != "3PPNT")
            {
                return false;
            }
            if (stratum.IsPersisted == false) { return true; }
            if (HasCruiseData(stratum) == false) { return true; }
            if (IsSupervisor == true) { return true; }
            
            if (R.Strings.EDITABLE_ST_FIELDS.Contains(fieldName))
            {
                return true;
            }
            return false;
            
        }

        public bool CanEditSampleGroupField(SampleGroupDO sampleGroup, String fieldName)
        {

            if (sampleGroup.IsPersisted == false) { return true; }
            if (HasCruiseData(sampleGroup) == false) { return true; }
            if (IsSupervisor == true) { return true; }
            if (R.Strings.EDITABLE_SG_FIELDS.Contains(fieldName))
            {
                return true;
            }
            return false;
        }

        public bool CanRemoveTreeDefault(SampleGroupDO sampleGroup, TreeDefaultValueDO tdv)
        {
            if (sampleGroup.IsPersisted == false || tdv.IsPersisted == false) { return true; }
            bool hasTreeCounts = this.WindowPresenter.Database.GetRowCount("CountTree", "WHERE TreeCount > 0 AND TreeDefaultValue_CN = ? AND SampleGroup_CN = ?", tdv.TreeDefaultValue_CN, sampleGroup.SampleGroup_CN) > 0;
            bool hasTrees = this.WindowPresenter.Database.GetRowCount("Tree", "WHERE TreeDefaultValue_CN = ? AND SampleGroup_CN = ?", tdv.TreeDefaultValue_CN, sampleGroup.SampleGroup_CN) > 0;
            return !(hasTreeCounts && hasTrees);
        }

        public bool CanDeleteTreeDefault(TreeDefaultValueDO tdv)
        {
            if (tdv.IsPersisted == false) { return true; }
            bool hasTreeCounts = this.WindowPresenter.Database.GetRowCount("CountTree", "WHERE TreeCount > 0 AND TreeDefaultValue_CN = ?", tdv.TreeDefaultValue_CN) > 0;
            bool hasTrees = this.WindowPresenter.Database.GetRowCount("Tree", "WHERE TreeDefaultValue_CN = ?", tdv.TreeDefaultValue_CN) > 0;
            return !(hasTreeCounts && hasTrees);
        }

        #region ISaveHandler members
        public void HandleAppClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DataContext.HasUnsavedChanges)
            {
                var result = this.WindowPresenter.AskYesNoCancel("You Have Unsaved Data, Would You Like To Save Before Closing?", "Save Changes", DialogResult.Yes);
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            e.Cancel = !HandleSave();
                            return;
                        }
                    case DialogResult.No:
                        {
                            return;
                        }
                    case DialogResult.Cancel:
                        {
                            e.Cancel = true;
                            return;
                        }
                }
            }
        }

        public bool HandleSave()
        {
            AssertDataContextValid();//DEBUG only

            if (View != null)
            {
                View.ForceEndEdits();
            }

            StringBuilder validationErrorBuilder = new StringBuilder();
            bool rtnVal = true; 
            if (!this.ValidateData(ref validationErrorBuilder))
            {
                this.WindowPresenter.ShowSimpleErrorMessage("Validation Errors Found:\r\n" + validationErrorBuilder.ToString());
                rtnVal = false;
            }

            this.SaveData();

            return rtnVal;
            
        }

        public bool CanHandleSave
        {
            get
            {
                return true;
            }
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void AssertDataContextValid()
        {
            System.Diagnostics.Debug.Assert(Database != null);
            System.Diagnostics.Debug.Assert(
                DataContext.AllCuttingUnits != null
                && DataContext.AllStrata != null
                && DataContext.AllSampleGroups != null
                && DataContext.DeletedCuttingUnits != null
                && DataContext.DeletedSampleGroups != null
                && DataContext.DeletedStrata != null
                && DataContext.DeletedTreeDefaults != null);
            System.Diagnostics.Debug.Assert(
                !DataContext.AllCuttingUnits.Contains(null)
                && !DataContext.AllStrata.Contains(null)
                && !DataContext.AllSampleGroups.Contains(null)
                && !DataContext.DeletedCuttingUnits.Contains(null)
                && !DataContext.DeletedSampleGroups.Contains(null)
                && !DataContext.DeletedStrata.Contains(null)
                && !DataContext.DeletedTreeDefaults.Contains(null));
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            return;
        }

        #endregion
    }
    
}
