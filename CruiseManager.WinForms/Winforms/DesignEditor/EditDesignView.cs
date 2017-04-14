using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Core.EditDesign;
using CruiseManager.Core.EditDesign.ViewInterfaces;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace CruiseManager.WinForms.EditDesign
{
    public partial class EditDesignView : UserControlView, IEditDesignView
    {
        public EditDesignView(WindowPresenter windowPresenter, DesignEditorPresentor viewPresenter)
        {
            this.ViewPresenter = viewPresenter;
            this.ViewPresenter.View = this;

            this.ExceptionHandler = viewPresenter.ApplicationController.ExceptionHandler;
            this.WindowPresenter = windowPresenter;
            InitializeComponent();
            this.SalePurposeComboBox.DataSource = Strings.SALE_PURPOSE;
        }

        public new DesignEditorPresentor ViewPresenter
        {
            get { return (DesignEditorPresentor)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        protected IExceptionHandler ExceptionHandler { get; set; }
        protected WindowPresenter WindowPresenter { get; set; }

        public void BindData()
        {
            this.SaleBindingSource.DataSource = ViewPresenter.DataContext.Sale;

            this.SampleGroup_TDVBindingSource.DataSource = ViewPresenter.DataContext.AllTreeDefaults;

            this.CuttingUnitsBindingSource.DataSource = ViewPresenter.DataContext.CuttingUnits;
            this.StrataBindingSource.DataSource = ViewPresenter.DataContext.Strata;
            this.SampleGroupBindingSource.DataSource = ViewPresenter.DataContext.SampleGroups;
            //this.PlotBindingSource.DataSource = Presentor.Data.Plots;

            this.CuttingUnits_StrataSelectionBindingSource.DataSource = ViewPresenter.DataContext.StrataFilterSelectionList;
            this.Strata_CuttingUnitsSelectionBindingSource.DataSource = ViewPresenter.DataContext.CuttingUnitFilterSelectionList;
            this.SampleGroups_StrataSelectionBindingSource.DataSource = ViewPresenter.DataContext.AllStrata;

            Strata_CuttingUnitBindingSource.DataSource = ViewPresenter.DataContext.AllCuttingUnits;
        }

        public void BindSetup()
        {
            this.RegionBindingSource.DataSource = ViewPresenter.Regions;
            this.cruiseMethodBindingSource.DataSource = ViewPresenter.CruiseMethods;
            this.LoggingMethodBindingSource.DataSource = ViewPresenter.LoggingMethods;
            this._BS_ProductTypes.DataSource = ViewPresenter.PrimaryProductCodes;
            secondaryProductDataGridViewTextBoxColumn.DataSource = ViewPresenter.SecondaryProductCodes.ToList();
        }

        public void EndEdits()
        {
            //force focus away from any control that has focus,
            //causing any control that has edited data to commit its data
            //this.Select(true, true);

            this.SaleBindingSource.EndEdit();
            this.CuttingUnitsBindingSource.EndEdit();
            this.StrataBindingSource.EndEdit();
            this.SampleGroupBindingSource.EndEdit();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            System.Diagnostics.Debug.Assert(ViewPresenter != null);
            this.BindSetup();//bind setup needs to be called before bind data, otherwise comboBoxes wont bind properly
            this.BindData();
        }

        #region cuttingUnitPage

        private void CuttingUnitDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > CuttingUnitsBindingSource.Count) { return; }
            try
            {
                var unit = CuttingUnitsBindingSource[e.RowIndex] as CuttingUnitDO;
                if (unit == null) { return; }
                var cell = CuttingUnitDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String fieldName = CuttingUnitDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                cell.ReadOnly = !ViewPresenter.CanEditCuttingUnitField(unit, fieldName);
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
            //it would be nice to be able to handle a situation where the lookup value in a combobox column
            //isn't exactly the same as the cell's value. EX. stored value is "421 " but value in combobox is "421" and causes a data error.
            System.Diagnostics.Debug.WriteLine(e.Exception, "DataGridViewDataError");
        }

        private void CuttingUnits_AddButton_Click(object sender, EventArgs e)
        {
            CuttingUnits_StrataSelectionBindingSource.Position = 0;//reset strata selection
            ViewPresenter.AddCuttingUnit();
        }

        private void CuttingUnits_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var curCuttingUnit = CuttingUnitsBindingSource.Current as CuttingUnitDO;
                if (curCuttingUnit == null) { return; }
                ViewPresenter.DeleteCuttingUnit(curCuttingUnit);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void CuttingUnits_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = CuttingUnits_StrataSelectionBindingSource.Current as StratumDO;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            ViewPresenter.FilterCutttingUnits(curStratum);
        }

        #endregion cuttingUnitPage

        #region Strata Page

        private void Strata_AddButton_Click(object sender, EventArgs e)
        {
            Strata_CuttingUnitsSelectionBindingSource.Position = 0;//reset cutting unit selection
            ViewPresenter.AddStratum();
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
                if (!ViewPresenter.CanEditStratumField(st, null))
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

        private void Strata_CuttingUnitsSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curUnit = Strata_CuttingUnitsSelectionBindingSource.Current as CuttingUnitDO;
            if (curUnit == null) { return; }
            if (curUnit.Code == "All") { curUnit = null; }
            ViewPresenter.FilterStrata(curUnit);
        }

        private void Strata_DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var curST = StrataBindingSource.Current as DesignEditorStratum;
                if (curST == null) { return; }
                ViewPresenter.DeleteStratum(curST);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
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
            if (e.RowIndex < 0 || e.RowIndex > StrataBindingSource.Count) { return; }
            try
            {
                var stratum = StrataBindingSource[e.RowIndex] as StratumDO;
                if (stratum == null) { return; }
                var cell = StrataDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String field = StrataDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                cell.ReadOnly = !ViewPresenter.CanEditStratumField(stratum, field);
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

        #endregion Strata Page

        #region SampleGroup Page

        public void UpdateCuttingUnits(object cuttingUnits)
        {
            this.CuttingUnitsBindingSource.DataSource = cuttingUnits;
        }

        public void UpdateSampleGroups(object samplegroups)
        {
            this.SampleGroupBindingSource.DataSource = samplegroups;
        }

        public void UpdateSampleGroupTDVs(object tdvs)
        {
            this.SampleGroup_TDVBindingSource.DataSource = tdvs;
        }

        public void UpdateStrata(object strata)
        {
            this.StrataBindingSource.DataSource = strata;
        }

        private void _addSubPopBTN_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO newTDV = WindowPresenter.ShowAddTreeDefault();
            if (newTDV != null)
            {
                this.ViewPresenter.DataContext.AllTreeDefaults.Add(newTDV);
            }
        }

        private void _deleteSubPopBTN_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO tdv = this.SampleGroup_TDVBindingSource.Current as TreeDefaultValueDO;
            if (tdv == null) { return; }
            try
            {
                ViewPresenter.DeleteTreeDefaultValue(tdv);
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
            {
                this.WindowPresenter.ShowEditTreeDefault(tdv);
            }
            //TreeDefaultValueDO temp = new TreeDefaultValueDO(tdv);
            //ApplicationState appState = ApplicationState.GetHandle();

            //try
            //{
            //    CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault dialog = new CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault(SetupService.Instance.GetProductCodes());
            //    if (dialog.ShowDialog(tdv) == DialogResult.OK)
            //    {
            //        try
            //        {
            //            tdv.Save();
            //        }
            //        catch (CruiseDAL.UniqueConstraintException ex)
            //        {
            //            throw new UserFacingException("Values Conflict With Existing Tree Default", ex);
            //        }
            //        catch (CruiseDAL.ConstraintException ex)
            //        {
            //            throw new UserFacingException("Invalid Values", ex);
            //        }
            //    }
            //    else
            //    {
            //        tdv.SetValues(temp);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.ExceptionHandler.Handel(ex);
            //}
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
                cell.ReadOnly = !ViewPresenter.CanEditSampleGroupField(sg, fieldName);
            }
            catch (IndexOutOfRangeException) { }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void SampleGroupDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > SampleGroupBindingSource.Count) { return; }
            try
            {
                SampleGroupDO sg = this.SampleGroupBindingSource[e.RowIndex] as SampleGroupDO;
                if (sg == null) { return; }
                String propName = this.SampleGroupDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                this.ViewPresenter.HandleSampleGroupValueChanged(sg, propName);
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void SampleGroupDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Exception, "DataGridViewDataErrror");
        }

        private void SampleGroups_AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                ViewPresenter.GetNewSampleGroup();
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
                var curSG = SampleGroupBindingSource.Current as DesignEditorSampleGroup;
                ViewPresenter.DeleteSampleGroup(curSG);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }

        private void SampleGroups_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = SampleGroups_StrataSelectionBindingSource.Current as DesignEditorStratum;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            ViewPresenter.SampleGroups_SelectedStrata = curStratum;
        }

        private void SampleGroups_TDVGridView_SelectionChanging(object sender, FMSC.Controls.SelectionChangingEventArgs e)
        {
            try
            {
                SampleGroupDO sg = this.SampleGroupBindingSource.Current as SampleGroupDO;
                TreeDefaultValueDO tdv = e.Item as TreeDefaultValueDO;
                if (e.IsRemoving == false) { return; } // we don't care if they are adding
                if (sg == null || tdv == null) { e.Cancel = true; return; }
                if (!ViewPresenter.CanRemoveTreeDefault(sg, tdv))
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

        #endregion SampleGroup Page
    }
}