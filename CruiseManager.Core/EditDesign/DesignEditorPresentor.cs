using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Core.EditDesign.ViewInterfaces;
using CruiseManager.Core.Models;
using CruiseManager.Core.SetupModels;
using CruiseManager.Core.ViewModel;
using FMSC.ORM.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.EditDesign
{
    public class DesignEditorPresentor : Presentor, ISaveHandler
    {
        public DesignEditorStratum _SampleGroups_SelectedStrata;
        private DesignEditorStratum _anyStratumOption;
        private CuttingUnitDO _anyUnitOption;
        List<ProductCode> _productCodes;

        public DesignEditorPresentor(IApplicationController applicationController)
        {
            this.ApplicationController = applicationController;
        }

        public List<string> CruiseMethods { get; set; }

        public DAL Database
        {
            get { return ApplicationController.Database; }
        }

        public DesignEditorDataContext DataContext { get; set; }

        public bool IsSupervisor { get { return ApplicationController.InSupervisorMode; } }

        public List<LoggingMethod> LoggingMethods { get; set; }

        public List<ProductCode> PrimaryProductCodes
        {
            get
            {
                if (_productCodes == null)
                {
                    _productCodes = ApplicationController.SetupService.GetProductCodes();
                }
                return _productCodes;
            }
        }

        public List<Region> Regions { get; set; }

        public DesignEditorStratum SampleGroups_SelectedStrata
        {
            get { return _SampleGroups_SelectedStrata; }
            set
            {
                _SampleGroups_SelectedStrata = value;
                if (value != null)
                {
                    DataContext.SampleGroups = new BindingList<DesignEditorSampleGroup>(
                        (from sg in DataContext.AllSampleGroups
                         where sg.Stratum.Stratum_CN == value.Stratum_CN
                         select sg).ToList());
                }
                else
                {
                    DataContext.SampleGroups = new BindingList<DesignEditorSampleGroup>(DataContext.AllSampleGroups);
                }
                View.UpdateSampleGroups(DataContext.SampleGroups);
            }
        }

        public IEnumerable<ProductCode> SecondaryProductCodes
        {
            get
            {
                yield return ProductCode.Empty;
                foreach (var pc in PrimaryProductCodes)
                {
                    yield return pc;
                }
            }
        }

        public List<UOMCode> UOMCodes { get; set; }

        public new IEditDesignView View
        {
            get { return (IEditDesignView)base.View; }
            set
            {
                base.View = value;
            }
        }

        public void AddCuttingUnit()
        {
            this.FilterCutttingUnits(_anyStratumOption);
            GetNewCuttingUnit();
        }

        public void AddStratum()
        {
            //this.FilterStrata(_anyUnitOption);
            GetNewStratum();
        }

        public bool CanDeleteTreeDefault(TreeDefaultValueDO tdv)
        {
            if (tdv.IsPersisted == false) { return true; }
            bool hasTreeCounts = this.Database.GetRowCount("CountTree", "WHERE TreeCount > 0 AND TreeDefaultValue_CN = @p1", tdv.TreeDefaultValue_CN) > 0;
            bool hasTrees = this.Database.GetRowCount("Tree", "WHERE TreeDefaultValue_CN = @p1", tdv.TreeDefaultValue_CN) > 0;
            return !(hasTreeCounts || hasTrees);
        }

        public bool CanEditCuttingUnitField(CuttingUnitDO unit, String fieldName)
        {
            if (unit.IsPersisted == false) { return true; }
            if (HasCruiseData(unit) == false) { return true; }
            if (IsSupervisor == true) { return true; }
            if (Strings.EDITABLE_UNIT_FILEDS.Contains(fieldName)) { return true; }
            return false;
        }

        public bool CanEditSampleGroupField(SampleGroupDO sampleGroup, String fieldName)
        {
            if (sampleGroup.IsPersisted == false) { return true; }
            if (HasCruiseData(sampleGroup) == false) { return true; }
            if (IsSupervisor == true) { return true; }
            if (Strings.EDITABLE_SG_FIELDS.Contains(fieldName))
            {
                return true;
            }
            return false;
        }

        public bool CanEditStratumField(StratumDO stratum, String fieldName)
        {
            if (IsSupervisor == true) { return true; }
            if (stratum.IsPersisted == false) { return true; }
            if (HasCruiseData(stratum) == false) { return true; }

            if (fieldName == "KZ3PPNT" && stratum.Method != "3PPNT")
            {
                return false;
            }
            if (Strings.EDITABLE_ST_FIELDS.Contains(fieldName))
            {
                return true;
            }
            return false;
        }

        public bool CanRemoveTreeDefault(SampleGroupDO sampleGroup, TreeDefaultValueDO tdv)
        {
            if (sampleGroup.IsPersisted == false || tdv.IsPersisted == false) { return true; }
            bool hasTreeCounts = this.Database.GetRowCount("CountTree", "WHERE TreeCount > 0 AND TreeDefaultValue_CN = @p1 AND SampleGroup_CN = @p2", tdv.TreeDefaultValue_CN, sampleGroup.SampleGroup_CN) > 0;
            bool hasTrees = this.Database.GetRowCount("Tree", "WHERE TreeDefaultValue_CN = @p1 AND SampleGroup_CN = @p2", tdv.TreeDefaultValue_CN, sampleGroup.SampleGroup_CN) > 0;
            return !(hasTreeCounts || hasTrees);
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

        public void DeleteSampleGroup(DesignEditorSampleGroup sampleGroup)
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

        public void DeleteStratum(DesignEditorStratum stratum)
        {
            if (!CanEditStratumField(stratum, null))
            {
                View.ShowMessage("Can not delete stratum because it contains cruise data");
                return;
            }

            DataContext.Strata.Remove(stratum);
            DataContext.DeletedStrata.Add(stratum);
            DataContext.AllStrata.Remove(stratum);
            DataContext.StrataFilterSelectionList.Remove(stratum);

            var mySampleGroups = (from sg in DataContext.AllSampleGroups
                                  where sg.Stratum == stratum
                                  select sg).ToList();
            foreach (var sg in mySampleGroups)
            {
                DataContext.AllSampleGroups.Remove(sg);
            }

            if (SampleGroups_SelectedStrata == stratum)
            {
                SampleGroups_SelectedStrata = DataContext.AllStrata.FirstOrDefault();
            }
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
            View.UpdateCuttingUnits(DataContext.CuttingUnits);
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
            View.UpdateStrata(DataContext.Strata);
        }

        public CuttingUnitDO GetNewCuttingUnit()
        {
            if (DataContext.AllCuttingUnits == null) { return null; }
            CuttingUnitDO newUnit = new CuttingUnitDO(this.Database);
            DataContext.AllCuttingUnits.Add(newUnit);
            //Data.CuttingUnits.Add(newUnit);
            DataContext.OnDataModified();
            //newUnit.DAL = Database;
            return newUnit;
        }

        public DesignEditorSampleGroup GetNewSampleGroup()
        {
            System.Diagnostics.Debug.Assert(DataContext.AllSampleGroups != null);

            if (SampleGroups_SelectedStrata == null)
            {
                throw new UserFacingException("Please Select Stratum", null);
            }

            var newSampleGroup = new DesignEditorSampleGroup(Database);
            newSampleGroup.Code = "<blank>";
            newSampleGroup.Stratum = SampleGroups_SelectedStrata;

            if (SampleGroups_SelectedStrata != null
                && SampleGroups_SelectedStrata.Method == CruiseDAL.Schema.CruiseMethods.FIXCNT)
            {
                newSampleGroup.UOM = "03";
            }
            else
            {
                newSampleGroup.UOM = DataContext.Sale.DefaultUOM;
            }

            newSampleGroup.CutLeave = "C";
            newSampleGroup.DefaultLiveDead = "L";
            DataContext.AllSampleGroups.Add(newSampleGroup);
            DataContext.SampleGroups.Add(newSampleGroup);
            DataContext.OnDataModified();
            return newSampleGroup;
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

        public bool HasCruiseData(CuttingUnitDO unit)
        {
            if (unit.CuttingUnit_CN == null) { return false; }
            return (Database.GetRowCount("Tree", "WHERE CuttingUnit_CN = @p1", unit.CuttingUnit_CN.Value) > 0)
                || (Database.GetRowCount("CountTree", "WHERE CuttingUnit_CN = @p1 AND TreeCount > 0", unit.CuttingUnit_CN.Value) > 0);
        }

        public bool HasCruiseData(StratumDO stratum)
        {
            if (stratum.Stratum_CN == null) { return false; }
            return (Database.GetRowCount("Tree", "WHERE Stratum_CN = @p1", stratum.Stratum_CN.Value) > 0)
                || (Database.GetRowCount("CountTree", "JOIN SampleGroup USING (SampleGroup_CN) WHERE Stratum_CN = @p1 AND TreeCount > 0", stratum.Stratum_CN.Value) > 0);
        }

        public bool HasCruiseData(SampleGroupDO sg)
        {
            if (sg.SampleGroup_CN == null) { return false; }
            return (Database.GetRowCount("Tree", "WHERE SampleGroup_CN = @p1", sg.SampleGroup_CN.Value) > 0)
                || (Database.GetRowCount("CountTree", "WHERE SampleGroup_CN = @p1 AND TreeCount > 0", sg.SampleGroup_CN.Value) > 0);
        }

        public void LoadSetup()
        {
            var setupServ = ApplicationController.SetupService;
            Regions = setupServ.GetRegions();
            CruiseMethods = this.ApplicationController.Database.GetCruiseMethods(this.DataContext.Sale.Purpose == "Recon");
            LoggingMethods = setupServ.GetLoggingMethods();
            UOMCodes = setupServ.GetUOMCodes();
        }

        public void SetFieldSetup(StratumDO stratum, Datastore database)
        {
            string setTreeFieldCommand = String.Format("INSERT INTO TreeFieldSetup (Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior) " +
            "Select {0} as Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior " +
            "FROM TreeFieldSetupDefault " +
            "WHERE Method = '{1}';", stratum.Stratum_CN, stratum.Method);

            string setLogFieldCommand = String.Format(@"INSERT OR IGNORE INTO LogFieldSetup (Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior)
            Select {0} as Stratum_CN, Field, FieldOrder, ColumnType, Heading, Width, Format, Behavior
            FROM LogFieldSetupDefault;",
            stratum.Stratum_CN);

            database.Execute(setTreeFieldCommand);
            database.Execute(setLogFieldCommand);
        }

        public bool ValidateData(ref StringBuilder errorBuilder)
        {
            System.Diagnostics.Debug.Assert(DataContext.CuttingUnits != null && DataContext.Strata != null && DataContext.SampleGroups != null);

            bool isValid = true;

            if (!DataContext.Sale.Validate())
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

            foreach (var sg in DataContext.AllSampleGroups)
            {
                string er;
                if (!sg.Validate(sg.Stratum, out er))
                {
                    errorBuilder.AppendLine(er);
                }
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

        protected void LoadDesignData()
        {
            this.DataContext = new DesignEditorDataContext();

            this.View.ShowWaitCursor();

            try
            {
                //initialize sale
                DataContext.Sale = Database.From<SaleVM>()
                    .Read().FirstOrDefault() ?? new SaleVM(Database);

                //initialize cuttingunits
                var units = Database.From<CuttingUnitDO>()
                    .Read().ToList();

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
                var strata = Database.From<DesignEditorStratum>()
                    .Read().ToList();

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
                var tdvList = Database.From<TreeDefaultValueDO>()
                    .Read().ToList();

                DataContext.AllTreeDefaults = new BindingList<TreeDefaultValueDO>(tdvList);

                //initialize sample groups
                var sampleGroups = Database.From<DesignEditorSampleGroup>()
                    .Read().ToList();

                DataContext.AllSampleGroups = new BindingList<DesignEditorSampleGroup>(sampleGroups);
                DataContext.SampleGroups = new BindingList<DesignEditorSampleGroup>(sampleGroups);

                foreach (SampleGroupDO sg in DataContext.AllSampleGroups)
                {
                    sg.TreeDefaultValues.Populate();
                }

                DataContext.HasUnsavedChanges = false;
            }
            finally
            {
                this.View.ShowDefaultCursor();
            }
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);
            this.LoadDesignData();
            this.LoadSetup();
        }

        void OnTreeDefaultsChanged(bool error)
        {
            View.UpdateSampleGroupTDVs(DataContext.AllTreeDefaults);
        }

        private bool SaveData()
        {
            Database.BeginTransaction();
            try
            {
                DataContext.Sale.Save();
                SaveUnits();
                SaveStrata();
                SaveSampleGroups();
                SaveTreeDefaults();

                Database.CommitTransaction();

                DataContext.HasUnsavedChanges = false;
                return true;
            }
            catch (FMSC.ORM.UniqueConstraintException ex)
            {
                Database.RollbackTransaction();
                throw new UserFacingException("Duplicate Entry Error", ex);
            }
            catch (Exception ex)
            {
                Database.RollbackTransaction();
                throw new UserFacingException("Error saving data, please check for errors and try saving again", ex);
            }
        }

        private void SaveSampleGroups()
        {
            foreach (SampleGroupDO sg in DataContext.AllSampleGroups)
            {
                if (sg.Code == "<blank>")
                {
                    sg.Code = " ";
                }
                sg.Save();
                sg.TreeDefaultValues.Save();
            }

            foreach (SampleGroupDO sg in DataContext.DeletedSampleGroups)
            {
                if (sg.IsPersisted)
                {
                    SampleGroupDO.RecutsiveDeleteSampleGroup(sg);
                }
            }

            DataContext.DeletedSampleGroups.Clear();
        }

        private void SaveStrata()
        {
            foreach (StratumDO st in DataContext.AllStrata)
            {
                bool isNewStratum = !st.IsPersisted;
                st.Save();
                st.CuttingUnits.Save();

                if (isNewStratum)
                {
                    SetFieldSetup(st, st.DAL);
                }
            }

            foreach (StratumDO st in DataContext.DeletedStrata)
            {
                if (st.IsPersisted)
                {
                    StratumDO.RecursiveDeleteStratum(st);
                }
            }
            DataContext.DeletedStrata.Clear();
        }

        private void SaveTreeDefaults()
        {
            foreach (TreeDefaultValueDO tdv in DataContext.AllTreeDefaults)
            {
                tdv.Save();
            }

            foreach (TreeDefaultValueDO tdv in DataContext.DeletedTreeDefaults)
            {
                if (tdv.IsPersisted)
                {
                    Database.Execute("DELETE FROM SampleGroupTreeDefaultValue WHERE TreeDefaultValue_CN = @p1", tdv.TreeDefaultValue_CN);
                    tdv.Delete();
                }
            }

            DataContext.DeletedTreeDefaults.Clear();
        }

        private void SaveUnits()
        {
            foreach (CuttingUnitDO unit in DataContext.AllCuttingUnits)
            {
                unit.Save();
            }

            foreach (CuttingUnitDO unit in DataContext.DeletedCuttingUnits)
            {
                if (unit.IsPersisted)
                {
                    CuttingUnitDO.RecursiveDelete(unit);
                }
            }
            DataContext.DeletedCuttingUnits.Clear();
        }

        #region ISaveHandler members

        public bool HasChangesToSave
        {
            get
            {
                return this.DataContext.HasUnsavedChanges;
            }
        }

        public bool HandleSave()
        {
            if (View != null)
            {
                View.EndEdits();
            }

            StringBuilder validationErrorBuilder = new StringBuilder();
            bool rtnVal = true; 
            if (!this.ValidateData(ref validationErrorBuilder))
            {
                this.View.ShowErrorMessage("Validation Errors Found",
                    validationErrorBuilder.ToString());
                rtnVal = false;
            }

            this.SaveData();

            return rtnVal;
        }

        #endregion ISaveHandler members
    }
}