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
using CSM.DataTypes;

namespace CSM.UI.DesignEditor
{
    public class DesignEditorPresentor : IPresentor
    {
        //private bool _isFileLoaded = false;
        //private string _fileName = null;
        private CuttingUnitDO _anyUnitOption;
        private StratumDO _anyStratumOption;

        private DesignEditViewControl _view;

        

        public DesignEditorPresentor(IWindowPresenter WindowPresenter)
        {
            this.Controller = WindowPresenter;
            this.Data = new DesignEditorData();
            if (DAL != null)
            {
                UpdateView();
            }
            
            LoadSetup();
            
        }

        public bool IsSupervisor { get { return Controller.AppState.InSupervisorMode; } }
        //public bool HasCruiseData { get; set; }

        public DesignEditorData Data { get; set; }
        //public bool IsFileLoded { get { return _isFileLoaded; } }
        //public string FileName { get { return _fileName; } }
        //public bool HasUnsavedChanges { get; set; }

    
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
        public IWindowPresenter Controller { get; set; }
        public DAL DAL 
        { 
            get { return Controller.Database; }
        }

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
                    Data.SampleGroups = new BindingList<SampleGroupDO>((from sg in Data.AllSampleGroups
                                                                   where sg.Stratum.Stratum_CN == value.Stratum_CN
                                                                   select sg).ToList());
                }
                else
                {
                    Data.SampleGroups = new BindingList<SampleGroupDO>(Data.AllSampleGroups);
                }
                View.SampleGroupBindingSource.DataSource = Data.SampleGroups;
            }
        }


        void OnTreeDefaultsChanged(bool error)
        {
            View.SampleGroup_TDVBindingSource.DataSource = Data.AllTreeDefaults;
        }


        public void FilterCutttingUnits(StratumDO filterBy)
        {
            if (Data.AllCuttingUnits == null) { return; }
            if (filterBy.Code != "ANY")
            {
                List<CuttingUnitDO> units = (from cu in Data.AllCuttingUnits
                                             where cu.Strata.Contains(filterBy)
                                             select cu).ToList();
                Data.CuttingUnits = new BindingList<CuttingUnitDO>(units);
            }
            else
            {
                Data.CuttingUnits = Data.AllCuttingUnits;
                
            }
            View.CuttingUnitsBindingSource.DataSource = Data.CuttingUnits;
        }


        internal void FilterStrata(CuttingUnitDO filterBy)
        {
            if (Data.AllStrata == null) { return; }
            if (filterBy.Code != "ANY")
            {
                List<StratumDO> strata = (from st in Data.AllStrata
                                          where st.CuttingUnits.Contains(filterBy)
                                          select st).ToList();
                Data.Strata = new BindingList<StratumDO>(strata);
            }
            else
            {
                Data.Strata = Data.AllStrata;
                
            }
            View.StrataBindingSource.DataSource = Data.Strata;
        }


        public void AddCuttingUnit()
        {
            this.FilterCutttingUnits(_anyStratumOption);
            GetNewCuttingUnit();
        }

        public CuttingUnitDO GetNewCuttingUnit()
        {
            if (Data.AllCuttingUnits == null) { return null; }
            CuttingUnitDO newUnit = new CuttingUnitDO(this.DAL);
            Data.AllCuttingUnits.Add(newUnit);
            //Data.CuttingUnits.Add(newUnit);
            Data.OnDataModified();
            newUnit.DAL = DAL;
            return newUnit;
        }

        public void DeleteCuttingUnit(CuttingUnitDO unit)
        {
            if(Data.AllCuttingUnits == null || Data.CuttingUnits == null) { return; }

            if (!CanEditCuttingUnitField(unit, null))
            {
                MessageBox.Show("Can not delete unit because it contains cruise data");
                return;
            }

            Data.CuttingUnits.Remove(unit);
            Data.AllCuttingUnits.Remove(unit);
            Data.CuttingUnitFilterSelectionList.Remove(unit);

            Data.DeletedCuttingUnits.Add(unit);

            //foreach (StratumDO st in unit.Strata)
            //{
            //    st.CuttingUnits.Remove(unit);
            //}

        }

        public void AddStratum()
        {
            //this.FilterStrata(_anyUnitOption);
            GetNewStratum();
        }

        public StratumDO GetNewStratum()
        {
            if (Data.AllStrata == null) { return null; }
            var newStratum = new StratumDO(DAL);
            Data.AllStrata.Add(newStratum);
            //Data.Strata.Add(newStratum);
            Data.OnDataModified();
            Data.StrataFilterSelectionList.Add(newStratum);
            return newStratum;
        }

        public void DeleteStratum(StratumDO stratum)
        {
            if(Data.Strata == null || Data.AllStrata == null || Data.AllSampleGroups == null) { return; }

            if(!CanEditStratumField(stratum, null))
            {
                MessageBox.Show("Can not delete stratum because it contains cruise data");
                return;
            }

            Data.Strata.Remove(stratum);
            Data.AllStrata.Remove(stratum);
            Data.StrataFilterSelectionList.Remove(stratum);
            Data.DeletedStrata.Add(stratum);

            var mySampleGroups = (from sg in Data.AllSampleGroups
                                 where sg.Stratum == stratum
                                 select sg).ToList();
            foreach (SampleGroupDO sg in mySampleGroups)
            {
                Data.AllSampleGroups.Remove(sg);
                //sg.Delete();
            }

            if (SampleGroups_SelectedStrata == stratum)
            {
                SampleGroups_SelectedStrata = Data.AllStrata.FirstOrDefault();
            }
        }

        //public void AddSampleGroup()
        //{
        //    if(Data.SampleGroups == null) { return; }
        //    Data.SampleGroups.Add(GetNewSampleGroup());
        //}

        public SampleGroupDO GetNewSampleGroup()
        {
            if (Data.AllSampleGroups == null) { return null; }
            if (SampleGroups_SelectedStrata == null) { return null; }
            var newSampleGroup = new SampleGroupDO(DAL);
            newSampleGroup.Code = "<blank>";
            newSampleGroup.Stratum = SampleGroups_SelectedStrata;
            newSampleGroup.UOM = Data.Sale.DefaultUOM;
            newSampleGroup.CutLeave = "C";
            newSampleGroup.DefaultLiveDead = "L";
            Data.AllSampleGroups.Add(newSampleGroup);
            Data.SampleGroups.Add(newSampleGroup);
            Data.OnDataModified();
            return newSampleGroup;
        }

        public void DeleteSampleGroup(SampleGroupDO sampleGroup)
        {
            if(Data.SampleGroups == null || Data.AllSampleGroups == null) { return; }

            if (!CanEditSampleGroupField(sampleGroup, null))
            {
                MessageBox.Show("Can not delete sample group because it contains cruise data");
                return;
            }

            Data.SampleGroups.Remove(sampleGroup);
            Data.AllSampleGroups.Remove(sampleGroup);
            Data.DeletedSampleGroups.Add(sampleGroup);
        }


        public void LoadSetup()
        {
            var setupServ = SetupService.GetHandle();
            Regions = setupServ.GetRegions();
            CruiseMethods = this.Controller.GetCruiseMethods(this.Data.Sale.Purpose == "Recon");
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
            Data.Sale = DAL.ReadSingleRow<SaleVM>("Sale", null, null);
            if (Data.Sale == null) { Data.Sale = new SaleVM(DAL); }

            //initialize cuttingunits 
            var units = DAL.Read<CuttingUnitDO>("CuttingUnit", null, null);
            foreach (CuttingUnitDO cu in units)
            {
                cu.Strata.Populate();
            }
            Data.AllCuttingUnits = new BindingList<CuttingUnitDO>(units);
            Data.CuttingUnits = new BindingList<CuttingUnitDO>(units);

            BindingList<CuttingUnitDO> filterUnits = new BindingList<CuttingUnitDO>(units.ToList());
            _anyUnitOption = new CuttingUnitDO();
            _anyUnitOption.Code = "ANY";
            filterUnits.Insert(0, _anyUnitOption);
            Data.CuttingUnitFilterSelectionList = filterUnits;

            

            //initialize strata
            var strata = DAL.Read<StratumDO>("Stratum", null, null);
            foreach (StratumDO st in strata)
            {
                st.CuttingUnits.Populate();
            }
            Data.AllStrata = new BindingList<StratumDO>(strata);
            Data.Strata = new BindingList<StratumDO>(strata);

            BindingList<StratumDO> filterStrata = new BindingList<StratumDO>(strata.ToList());
            _anyStratumOption = new StratumDO();
            _anyStratumOption.Code = "ANY";
            filterStrata.Insert(0, _anyStratumOption);
            Data.StrataFilterSelectionList = filterStrata;

            //initialize sample groups
            List<SampleGroupDO> sampleGroups = DAL.Read<SampleGroupDO>("SampleGroup", null, null);
            Data.AllSampleGroups = new BindingList<SampleGroupDO>(sampleGroups);
            Data.SampleGroups = new BindingList<SampleGroupDO>(sampleGroups);

            foreach (SampleGroupDO sg in Data.AllSampleGroups)
            {                
                sg.TreeDefaultValues.Populate();
            }
            
            //initialize TreeDefault
            List<TreeDefaultValueDO> tdvList = DAL.Read<TreeDefaultValueDO>("TreeDefaultValue", null, null);
            Data.AllTreeDefaults = new BindingList<TreeDefaultValueDO>(tdvList);



            //initialize plots
            //Data.AllPlots = new BindingList<PlotDO>(DAL.Read<PlotDO>("Plot", null, null));

            //check if there is any tree data
            //HasCruiseData = (DAL.GetRowCount("Tree", null, null) > 0);
            
            Data.HasUnsavedChanges = false;
            //_isFileLoaded = true;
            
            //stop wait cursor
            if (View != null)
            {
                View.Cursor = Cursors.Default;
            }
        }

        public bool HasCruiseData(CuttingUnitDO unit)
        {
            if (unit.CuttingUnit_CN == null) { return false; }
            return (DAL.GetRowCount("Tree", "WHERE CuttingUnit_CN = ?", unit.CuttingUnit_CN.Value) > 0) 
                || (DAL.GetRowCount("CountTree", "WHERE CuttingUnit_CN = ? AND TreeCount > 0", unit.CuttingUnit_CN.Value) > 0);           
        }

        public bool HasCruiseData(StratumDO stratum)
        {
            if (stratum.Stratum_CN == null) { return false; }
            return (DAL.GetRowCount("Tree", "WHERE Stratum_CN = ?", stratum.Stratum_CN.Value) > 0)
                || (DAL.GetRowCount("CountTree", "JOIN SampleGroup USING (SampleGroup_CN) WHERE Stratum_CN = ? AND TreeCount > 0", stratum.Stratum_CN.Value) > 0);  
        }

        public bool HasCruiseData(SampleGroupDO sg)
        {
            if (sg.SampleGroup_CN == null) { return false; }
            return (DAL.GetRowCount("Tree", "WHERE SampleGroup_CN = ?", sg.SampleGroup_CN.Value) > 0)
                || (DAL.GetRowCount("CountTree", "WHERE SampleGroup_CN = ? AND TreeCount > 0", sg.SampleGroup_CN.Value) > 0); 
        }

        public bool ValidateData(ref string error)
        {
            if (Data.CuttingUnits == null || Data.Strata == null || Data.SampleGroups == null) { return true; }
            bool isValid = true;

            bool v; //is item valid  
            isValid = Data.Sale.Validate();
            if(!isValid)
            {
                error += Data.Sale.Error; 
            }

            foreach (StratumDO st in Data.AllStrata)
            {
                v = st.Validate();
                isValid = v && isValid;
                if (!v)
                {
                    error += st.Error;
                }

            }

            foreach (CuttingUnitDO unit in Data.AllCuttingUnits)
            {
                v = unit.Validate();
                isValid = v && isValid;
                if (!v)
                {
                    error += unit.Error;
                }
            }

            
            foreach (SampleGroupDO sg in Data.AllSampleGroups)
            {
                v = sg.Validate();
                isValid = v && isValid;
                if(!v)
                {
                    error += sg.Error;
                }
                //isValid = sg.ValidatePProdOnTDVs(ref error) && isValid;
            }

            foreach (TreeDefaultValueDO tdv in Data.AllTreeDefaults)
            {
                v = tdv.Validate();
                isValid = v && isValid;
                if(!v)
                {
                    error += tdv.Error;
                }
            }

            return isValid;
        }

        public bool SaveData(ref string error)
        {
            if (DAL == null) { return true; }
            if (Data.CuttingUnits == null || Data.Strata == null || Data.SampleGroups == null) { return true; }

            if (View != null)
            {
                View.ForceEndEdits();
            }

            bool passedValidation = true;
            if (!this.ValidateData(ref error))
            {
                passedValidation = false;
            }



            Data.Sale.Save();

            try
            {
                foreach (CuttingUnitDO unit in Data.AllCuttingUnits)
                {
                    if (unit == null) { continue; }
                    SaveCuttingUnit(unit);
                }

                foreach (StratumDO st in Data.AllStrata)
                {
                    if (st == null) { continue; }
                    SaveStratum(st);
                }

                foreach (SampleGroupDO sg in Data.AllSampleGroups)
                {
                    if (sg == null) { continue; }
                    string er;
                    if (!SampleGroupDO.ValidateSetup(sg, sg.Stratum,out er))
                    {
                        error += er;
                        passedValidation = false;
                    }
                    else
                    {
                        SaveSampleGroup(sg);
                    }
                }

                foreach (TreeDefaultValueDO tdv in Data.AllTreeDefaults)
                {
                    tdv.Save();
                }

                foreach (CuttingUnitDO unit in Data.DeletedCuttingUnits)
                {
                    CuttingUnitDO.RecursiveDelete(unit);
                    //unit.Delete();
                }
                Data.DeletedCuttingUnits.Clear();

                foreach (SampleGroupDO sg in Data.DeletedSampleGroups)
                {
                    SampleGroupDO.RecutsiveDeleteSampleGroup(sg);
                    //sg.Delete();
                }
                Data.DeletedSampleGroups.Clear();

                foreach (StratumDO st in Data.DeletedStrata)
                {
                    StratumDO.RecursiveDeleteStratum(st);
                    //StratumDO.DeleteStratum(st.DAL, st);
                }
                Data.DeletedStrata.Clear();

                

                Data.HasUnsavedChanges = false;
            }
            catch (Exception)
            {
                //replace any existing error message, just because 
                error = "Error saving data, please check for errors and try saving again";
                //this.Controller.ShowSimpleErrorMessage();
                return false;
            }
            return passedValidation;
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

        //public void SaveAsTemplate(String fileName)
        //{
        //    DAL DestDB = new DAL(fileName);
        //    DestDB.Create();

        //    //DAL.DirectCopy(DestDB, "CuttingUnit", null, null);
        //    //DAL.DirectCopy(DestDB, "Stratum", null, null);
        //    //DAL.DirectCopy(DestDB, "CuttingUnitStratum", null, null);
        //    //DAL.DirectCopy(DestDB, "SampleGroup", null, null);
        //    //DAL.DirectCopy(DestDB, "TreeDefaultValue", null, OnConflictOption.Fail);
        //    //DAL.DirectCopy(DestDB, "SampleGroupTreeDefaultValue", null, null);
        //}

        //precondition:
        //All cutting units in stratum.CuttingUnits 
        //are saved
        public void SaveStratum(StratumDO stratum)
        {
            //if (CanEditStratumField(stratum, null) == false) { return false; }
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
            //if (CanEditSampleGroupField(sampleGroup, null) == false) { return false; }
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
            bool hasTreeCounts = this.Controller.Database.GetRowCount("CountTree", "WHERE TreeCount > 0 AND TreeDefaultValue_CN = ? AND SampleGroup_CN = ?") > 0;
            bool hasTrees = this.Controller.Database.GetRowCount("Tree", "WHERE TreeDefaultValue_CN = ? AND SampleGroup_CN = ?") > 0;
            return !(hasTreeCounts && hasTrees);
        }

        //public void OnDataModified()
        //{
        //    HasUnsavedChanges = true;
        //}

        public void HandleAppClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Data.HasUnsavedChanges)
            {
                var result = MessageBox.Show( "You Have Unsaved Data, Would You Like To Save Before Closing?", "Warning", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            string error = null;
                            if (!this.SaveData(ref error))
                            {
                                error = "Errors Detected\r\n" + error;
                                this.Controller.ShowSimpleErrorMessage(error);
                                e.Cancel = true;
                            }

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

        public void HandleSave()
        {
            string error = null;
            if (!this.SaveData(ref error))
            {
                error = "Errors Detected\r\n" + error;
                this.Controller.ShowSimpleErrorMessage(error);
            }
        }

        public bool CanHandleSave
        {
            get
            {
                return true;
            }
        }

        public bool CanHandleSaveAs
        {
            get
            {
                return true;
            }
        }

        private class TreeDefaultComparer : IEqualityComparer<TreeDefaultValueDO>
        {
            #region IEqualityComparer<TreeDefaultValueDO> Members

            public bool  Equals(TreeDefaultValueDO x, TreeDefaultValueDO y)
            {
 	            return ((x.PrimaryProduct == y.PrimaryProduct) && 
                    (x.Species == y.Species) && 
                    (x.LiveDead == y.LiveDead));
            }

            public int  GetHashCode(TreeDefaultValueDO obj)
            {
 	            return obj.PrimaryProduct.GetHashCode() ^ 3 + obj.Species.GetHashCode() ^ 2 + obj.LiveDead.GetHashCode();
            }

            #endregion
       }


        #region IDisposable Members

        public void Dispose()
        {
            return;
        }

        #endregion
    }
    public class DesignEditorData
    {
        private List<CuttingUnitDO> _ToBeDeletedCuttingUnits;
        private List<StratumDO> _ToBeDeletedStrata;
        private List<SampleGroupDO> _ToBeDeletedSampleGroups;
        private bool _hasUnsavedChanges = false;
        public bool HasUnsavedChanges
        {
            get
            {
                return _hasUnsavedChanges ||
                    (_ToBeDeletedCuttingUnits != null && _ToBeDeletedCuttingUnits.Count > 0) ||
                    (_ToBeDeletedSampleGroups != null && _ToBeDeletedSampleGroups.Count > 0) ||
                    (_ToBeDeletedStrata != null && _ToBeDeletedStrata.Count > 0);
            }
            set
            {
                _hasUnsavedChanges = value;
            }
        }

        private SaleDO _Sale;
        public SaleDO Sale
        {
            get { return _Sale; }
            set
            {
                //remove old proerty changed listener
                if (_Sale != null && !object.ReferenceEquals(_Sale, value))
                {
                    _Sale.PropertyChanged -= Sale_PropertyChanged;
                }
                //add a property changed listener 
                if (value != null && !object.ReferenceEquals(_Sale, value))
                {
                    value.PropertyChanged += new PropertyChangedEventHandler(Sale_PropertyChanged);
                }

                //View.SaleBindingSource.DataSource = value;
                _Sale = value;
            }
        }


        public BindingList<CuttingUnitDO> CuttingUnits { get; set; }
        public BindingList<StratumDO> Strata { get; set; }
        public BindingList<SampleGroupDO> SampleGroups { get; set; }
        public BindingList<PlotDO> Plots { get; set; }

        public List<CuttingUnitDO> DeletedCuttingUnits 
        {
            get
            {
                if (_ToBeDeletedCuttingUnits == null)
                {
                    _ToBeDeletedCuttingUnits = new List<CuttingUnitDO>();
                }
                return _ToBeDeletedCuttingUnits;
            }
        }
        public List<StratumDO> DeletedStrata 
        {
            get
            {
                if (_ToBeDeletedStrata == null)
                {
                    _ToBeDeletedStrata = new List<StratumDO>();
                }
                return _ToBeDeletedStrata;
            }

        }

        public List<SampleGroupDO> DeletedSampleGroups
        {
            get
            {
                if (_ToBeDeletedSampleGroups == null)
                {
                    _ToBeDeletedSampleGroups = new List<SampleGroupDO>();
                }
                return _ToBeDeletedSampleGroups;
            }
        }

        private BindingList<CuttingUnitDO> _AllCuttingUnits;
        public BindingList<CuttingUnitDO> AllCuttingUnits
        {
            get { return _AllCuttingUnits; }
            set
            {
                if (_AllCuttingUnits != null && !object.ReferenceEquals(_AllCuttingUnits, value))
                {
                    _AllCuttingUnits.ListChanged -= DataPropertyChanged;
                }
                if (value != null && !object.ReferenceEquals(_AllCuttingUnits, value))
                {
                    value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
                }

                _AllCuttingUnits = value;

                //View.Strata_CuttingUnitBindingSource.DataSource = AllCuttingUnits;
                //View.Plots_CuttingUnitSelectionBindingSource.DataSource = AllCuttingUnits;
            }
        }

        private BindingList<StratumDO> _AllStrata;
        public BindingList<StratumDO> AllStrata
        {
            get { return _AllStrata; }
            set
            {
                if (_AllStrata != null && !object.ReferenceEquals(_AllStrata, value))
                {
                    _AllStrata.ListChanged -= DataPropertyChanged;
                }
                if (value != null && !object.ReferenceEquals(_AllStrata, value))
                {
                    value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
                }

                _AllStrata = value;

                //View.Plots_StrataSelectionBindingSource.DataSource = AllStrata;
            }
        }

        public BindingList<SampleGroupDO> _AllSampleGroups;
        public BindingList<SampleGroupDO> AllSampleGroups
        {
            get { return _AllSampleGroups; }
            set
            {
                if (_AllSampleGroups != null && !object.ReferenceEquals(_AllSampleGroups, value))
                {
                    _AllSampleGroups.ListChanged -= DataPropertyChanged;
                }
                if (value != null && !object.ReferenceEquals(_AllSampleGroups, value))
                {
                    value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
                }

                _AllSampleGroups = value;
            }
        }

        //public BindingList<PlotDO> AllPlots { get; set; }

        public BindingList<CuttingUnitDO> CuttingUnitFilterSelectionList { get; set; }
        public BindingList<StratumDO> StrataFilterSelectionList { get; set; }



        private BindingList<TreeDefaultValueDO> _allTreeDefaults;
        public BindingList<TreeDefaultValueDO> AllTreeDefaults
        {
            get { return _allTreeDefaults; }
            set
            {
                if (_allTreeDefaults != null && !object.ReferenceEquals(_allTreeDefaults, value))
                {
                    _allTreeDefaults.ListChanged -= DataPropertyChanged;
                }
                if (value != null && !object.ReferenceEquals(_allTreeDefaults, value))
                {
                    value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
                }

                _allTreeDefaults = value;
            }
        }

        public void OnDataModified()
        {
            HasUnsavedChanges = true;
        }

        void Sale_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnDataModified();
        }

        void DataPropertyChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded)
            {
                OnDataModified();
            }
        }

       
    }
}
