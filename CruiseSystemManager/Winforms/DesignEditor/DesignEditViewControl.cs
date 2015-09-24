using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using System.Collections;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;

namespace CruiseManager.Winforms.DesignEditor
{
    public partial class DesignEditViewControl : UserControl
    {

        private DesignEditorPresentor _presentor;

        protected ExceptionHandler ExceptionHandler { get; set; } 
        protected ApplicationController ApplicationController { get; set; }
        public WindowPresenter WindowPresenter { get; set; }



        public DesignEditViewControl(WindowPresenter windowPresenter, ApplicationController applicationController, ExceptionHandler exceptionHandler)
        {
            this.ExceptionHandler = exceptionHandler;
            this.WindowPresenter = windowPresenter;
            this.ApplicationController = applicationController;
            InitializeComponent();
            this.SalePurposeComboBox.DataSource = Strings.SALE_PURPOSE;
        }

        public DesignEditorPresentor Presentor
        {
            get { return _presentor; }
            set
            {
                _presentor = value;
            }
        }

        public void BindSetup()
        {
            
            this.RegionBindingSource.DataSource = Presentor.Regions;
            this.cruiseMethodBindingSource.DataSource = Presentor.CruiseMethods;
            this.LoggingMethodBindingSource.DataSource = Presentor.LoggingMethods;
            this._BS_ProductTypes.DataSource = Presentor.ProductCodes;
        }

        public void BindData()
        {
            this.SaleBindingSource.DataSource = Presentor.DataContext.Sale;

            this.SampleGroup_TDVBindingSource.DataSource = Presentor.DataContext.AllTreeDefaults;

            this.CuttingUnitsBindingSource.DataSource = Presentor.DataContext.CuttingUnits;
            this.StrataBindingSource.DataSource = Presentor.DataContext.Strata;
            this.SampleGroupBindingSource.DataSource = Presentor.DataContext.SampleGroups;
            //this.PlotBindingSource.DataSource = Presentor.Data.Plots;

            this.CuttingUnits_StrataSelectionBindingSource.DataSource = Presentor.DataContext.StrataFilterSelectionList;
            this.Strata_CuttingUnitsSelectionBindingSource.DataSource = Presentor.DataContext.CuttingUnitFilterSelectionList;
            this.SampleGroups_StrataSelectionBindingSource.DataSource = Presentor.DataContext.AllStrata;
            Strata_CuttingUnitBindingSource.DataSource = Presentor.DataContext.AllCuttingUnits;
        }

        public void ForceEndEdits()
        {
            //force focus away from any control that has focus, 
            //causing any control that has edited data to commit its data
            //this.Select(true, true);

            this.SaleBindingSource.EndEdit();
            this.CuttingUnitsBindingSource.EndEdit();
            this.StrataBindingSource.EndEdit();
            this.SampleGroupBindingSource.EndEdit();
        }

        #region cuttingUnitPage
        private void CuttingUnits_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = CuttingUnits_StrataSelectionBindingSource.Current as StratumDO;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            Presentor.FilterCutttingUnits(curStratum);
        }
        
        private void CuttingUnits_AddButton_Click(object sender, EventArgs e)
        {
            CuttingUnits_StrataSelectionBindingSource.Position = 0;//reset strata selection
            Presentor.AddCuttingUnit();
        }

        private void CuttingUnits_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var curCuttingUnit = CuttingUnitsBindingSource.Current as CuttingUnitDO;
                if (curCuttingUnit == null) { return; }
                Presentor.DeleteCuttingUnit(curCuttingUnit);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }            
        }
        
        private void CuttingUnitDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var unit = CuttingUnitsBindingSource[e.RowIndex] as CuttingUnitDO;
                if (unit == null) { return; }
                var cell = CuttingUnitDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String fieldName = CuttingUnitDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                cell.ReadOnly = !Presentor.CanEditCuttingUnitField(unit, fieldName);
            }
            catch (IndexOutOfRangeException) { }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }

        }
        
        private void CuttingUnitDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore
            //it would be nice to beable to handle a situation where the lookup value in a combobox column
            //isn't exactly the same as the cell's value. EX. stored value is "421 " but value in combobox is "421" and causes a data error. 
            System.Diagnostics.Debug.WriteLine(e.Exception, "DataGridViewDataError");
        }
        #endregion


        #region Strata Page

        private void Strata_AddButton_Click(object sender, EventArgs e)
        {
            Strata_CuttingUnitsSelectionBindingSource.Position = 0;//reset cutting unit selection
            Presentor.AddStratum();
        }

        private void Strata_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var curST = StrataBindingSource.Current as DesignEditorStratum;
                if (curST == null) { return; }
                Presentor.DeleteStratum(curST);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void Strata_CuttingUnitsSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curUnit = Strata_CuttingUnitsSelectionBindingSource.Current as CuttingUnitDO;
            if (curUnit == null) { return; }
            if (curUnit.Code == "All") { curUnit = null; }
            Presentor.FilterStrata(curUnit);
        }

        private void Strata_CuttingUnitsGridView_SelectionChanging(object sender, FMSC.Controls.SelectionChangingEventArgs e)
        {
            try
            {
                //stratum is being removed from cutting unit             
                StratumDO st = this.StrataBindingSource.Current as StratumDO;
                if (e.IsRemoving == false) { return; } // we don't care if they are adding 
                if (st == null) { e.Cancel = true; return; }
                //see if that stratum can be edited
                if (!Presentor.CanEditStratumField(st, null))
                {
                    throw new UserFacingException("Stratum Can Not Be Removed", null);
                }
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
                e.Cancel = true; 
            }
        }

        private void StrataBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var stratum = StrataBindingSource.Current as StratumDO;
            //make sure the currently selected stratum is not null
            if (stratum == null) { return; }
            //get the selection of cutting units in the stratum 
            stratum.CuttingUnits.Populate();
            //display the cutting units in the stratum
            Strata_CuttingUnitsGridView.SelectedItems = (IList)stratum.CuttingUnits;
        }

        private void StrataDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var stratum = StrataBindingSource[e.RowIndex] as StratumDO;
                if (stratum == null) { return; }
                var cell = StrataDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String field = StrataDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                cell.ReadOnly = !Presentor.CanEditStratumField(stratum, field);
            }
            catch (IndexOutOfRangeException) { }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void StrataDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(e.Exception, "DataGridViewDataError");
        }
        #endregion

        #region SampleGroup Page

        private void SampleGroups_AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Presentor.GetNewSampleGroup();
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
            
        }

        private void SampleGroups_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var curSG = SampleGroupBindingSource.Current as SampleGroupDO;
                Presentor.DeleteSampleGroup(curSG);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void SampleGroups_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = SampleGroups_StrataSelectionBindingSource.Current as StratumDO;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            Presentor.SampleGroups_SelectedStrata = curStratum;
        }

        private void SampleGroups_TDVGridView_SelectionChanging(object sender, FMSC.Controls.SelectionChangingEventArgs e)
        {
            try
            {
                SampleGroupDO sg = this.SampleGroupBindingSource.Current as SampleGroupDO;
                TreeDefaultValueDO tdv = e.Item as TreeDefaultValueDO;
                if (e.IsRemoving == false) { return; } // we don't care if they are adding 
                if (sg == null || tdv == null) { e.Cancel = true; return; }
                if (!Presentor.CanRemoveTreeDefault(sg, tdv))
                {
                    throw new UserFacingException("Can't remove this species because it has tree data or tree counts.", null);
                }
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
                e.Cancel = false;
            }
        }

        private void SampleGroupDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SampleGroupDO sg = this.SampleGroupBindingSource[e.RowIndex] as SampleGroupDO;
                if (sg == null) { return; }
                String propName = this.SampleGroupDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                this.Presentor.HandleSampleGroupValueChanged(sg, propName);
            }
            catch (ArgumentOutOfRangeException) { }

        }

        private void _addSubPopBTN_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO newTDV = new TreeDefaultValueDO(Presentor.Database);
            ApplicationState appState = ApplicationState.GetHandle();
            try
            {
                CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault dialog = new CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault(SetupService.Instance.GetProductCodes());
                if (dialog.ShowDialog(newTDV) == DialogResult.OK)
                {
                    this.Presentor.DataContext.AllTreeDefaults.Add(newTDV);

                    newTDV.Save();
                }
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void _editSubPopBtn_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO tdv = this.SampleGroup_TDVBindingSource.Current as TreeDefaultValueDO;
            if (tdv == null) { return; }
            TreeDefaultValueDO temp = new TreeDefaultValueDO(tdv);
            ApplicationState appState = ApplicationState.GetHandle();

            try
            {
                CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault dialog = new CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault(SetupService.Instance.GetProductCodes());
                if (dialog.ShowDialog(tdv) == DialogResult.OK)
                {
                    try
                    {
                        tdv.Save();
                    }
                    catch (CruiseDAL.UniqueConstraintException ex)
                    {
                        throw new UserFacingException("Values Conflict With Existing Tree Default", ex);
                    }
                    catch (CruiseDAL.ConstraintException ex)
                    {
                        throw new UserFacingException("Invalid Values", ex);
                    }
                }
                else
                {
                    tdv.SetValues(temp);
                }
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void _deleteSubPopBTN_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO tdv = this.SampleGroup_TDVBindingSource.Current as TreeDefaultValueDO;
            if (tdv == null) { return; }
            try
            {
                Presentor.DeleteTreeDefaultValue(tdv);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void SampleGroupBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var sampleGroup = SampleGroupBindingSource.Current as SampleGroupDO;
            if (sampleGroup == null) { return; }
            if (sampleGroup.TreeDefaultValues.IsPopulated == false)
            {
                sampleGroup.TreeDefaultValues.Populate();
            }
            SampleGroups_TDVGridView.SelectedItems = sampleGroup.TreeDefaultValues;
        }

        private void SampleGroupDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var sg = SampleGroupBindingSource[e.RowIndex] as SampleGroupDO;
                if (sg == null) { return; }
                var cell = SampleGroupDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String fieldName = SampleGroupDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                cell.ReadOnly = !Presentor.CanEditSampleGroupField(sg, fieldName);
            }
            catch (IndexOutOfRangeException) { }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void SampleGroupDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Exception, "DataGridViewDataErrror");
        }
        #endregion

        //#region IView Members
        //protected void InitializeView(IWindowPresenter windowPresenter)
        //{
        //    this.WindowPresenter = windowPresenter;
        //    this.NavOptions = null; 
        //    this.ViewActions = null; 
        //}

        //public IWindowPresenter WindowPresenter { get; set; }

        //public NavOption[] NavOptions { get; protected set; } 

        //public NavOption[] ViewActions { get; protected set; 

        //#endregion
    }
}
