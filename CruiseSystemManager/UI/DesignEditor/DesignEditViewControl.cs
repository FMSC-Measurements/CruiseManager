﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using System.Collections;

namespace CSM.UI.DesignEditor
{
    public partial class DesignEditViewControl : UserControl
    {

        private DesignEditorPresentor _presentor;

        public DesignEditViewControl()
        {
            InitializeComponent();
            this.SalePurposeComboBox.DataSource = Utility.Constants.SALE_PURPOSE;
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
            this.SaleBindingSource.DataSource = Presentor.Data.Sale;

            this.SampleGroup_TDVBindingSource.DataSource = Presentor.Data.AllTreeDefaults;

            this.CuttingUnitsBindingSource.DataSource = Presentor.Data.CuttingUnits;
            this.StrataBindingSource.DataSource = Presentor.Data.Strata;
            this.SampleGroupBindingSource.DataSource = Presentor.Data.SampleGroups;
            //this.PlotBindingSource.DataSource = Presentor.Data.Plots;

            this.CuttingUnits_StrataSelectionBindingSource.DataSource = Presentor.Data.StrataFilterSelectionList;
            this.Strata_CuttingUnitsSelectionBindingSource.DataSource = Presentor.Data.CuttingUnitFilterSelectionList;
            this.SampleGroups_StrataSelectionBindingSource.DataSource = Presentor.Data.AllStrata;
            Strata_CuttingUnitBindingSource.DataSource = Presentor.Data.AllCuttingUnits;
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

        private void CuttingUnits_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = CuttingUnits_StrataSelectionBindingSource.Current as StratumDO;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            Presentor.FilterCutttingUnits(curStratum);
        }

        private void Strata_CuttingUnitsSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curUnit = Strata_CuttingUnitsSelectionBindingSource.Current as CuttingUnitDO;
            if (curUnit == null) { return; }
            if (curUnit.Code == "All") { curUnit = null; }
            Presentor.FilterStrata(curUnit);
        }

        private void SampleGroups_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = SampleGroups_StrataSelectionBindingSource.Current as StratumDO;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            Presentor.SampleGroups_SelectedStrata = curStratum;
        }

        private void CuttingUnits_AddButton_Click(object sender, EventArgs e)
        {
            CuttingUnits_StrataSelectionBindingSource.Position = 0;
            Presentor.AddCuttingUnit();
        }

        private void CuttingUnits_DeleteButton_Click(object sender, EventArgs e)
        {
            var curCuttingUnit = CuttingUnitsBindingSource.Current as CuttingUnitDO;
            if (curCuttingUnit == null) { return; }
            Presentor.DeleteCuttingUnit(curCuttingUnit);
        }

        private void Strata_AddButton_Click(object sender, EventArgs e)
        {
            Strata_CuttingUnitsSelectionBindingSource.Position = 0;
            Presentor.AddStratum();
        }

        private void SampleGroups_DeleteButton_Click(object sender, EventArgs e)
        {
            var curSG = SampleGroupBindingSource.Current as SampleGroupDO;
            Presentor.DeleteSampleGroup(curSG);
        }

        private void Strata_DeleteButton_Click(object sender, EventArgs e)
        {
            var curST = StrataBindingSource.Current as StratumDO;
            if (curST == null) { return; }
            Presentor.DeleteStratum(curST);
        }

        private void SampleGroups_AddButton_Click(object sender, EventArgs e)
        {
            if (Presentor.SampleGroups_SelectedStrata == null)
            {
                MessageBox.Show("Please Select a Stratum");
            }
            else
            {
                Presentor.GetNewSampleGroup();
            }
        }



        private void CuttingUnitDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CuttingUnitDO unit = CuttingUnitsBindingSource[e.RowIndex] as CuttingUnitDO;
            if (unit == null) { return; }

            DataGridViewCell cell = null;
            try
            {
                cell = CuttingUnitDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String field = CuttingUnitDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                cell.ReadOnly = !Presentor.CanEditCuttingUnitField(unit, field);
            }
            catch
            {
                if (cell != null)
                {
                    cell.ReadOnly = true;
                }
            }
            
                
        }

        private void StrataDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            StratumDO stratum = StrataBindingSource[e.RowIndex] as StratumDO;
            if (stratum == null) { return; }

            DataGridViewCell cell = null;
            try
            {
                cell = StrataDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String field = StrataDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                cell.ReadOnly = !Presentor.CanEditStratumField(stratum, field);
            }
            catch
            {
                if (cell != null)
                {
                    cell.ReadOnly = true;
                }
            }
        }

        private void SampleGroupDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SampleGroupDO sg = SampleGroupBindingSource[e.RowIndex] as SampleGroupDO;
            if (sg == null) { return; }
            DataGridViewCell cell = null;
            try
            {
                cell = SampleGroupDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String field = SampleGroupDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                cell.ReadOnly = !Presentor.CanEditSampleGroupField(sg, field);
            }
            catch
            {
                if (cell != null)
                {
                    cell.ReadOnly = true;
                }
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

        private void StrataBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            OnSelectedStrataChanged();
        }

        private void OnSelectedStrataChanged()
        {
            var stratum = StrataBindingSource.Current as StratumDO;
            //make sure the currently selected stratum is not null
            if (stratum == null) { return; }
            //get the selection of cutting units in the stratum 
            stratum.CuttingUnits.Populate();
            //display the cutting units in the stratum
            Strata_CuttingUnitsGridView.SelectedItems = (IList)stratum.CuttingUnits;
        }

        private void _addSubPopBTN_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO newTDV = new TreeDefaultValueDO(Presentor.DAL);
            ApplicationState appState = ApplicationState.GetHandle();
            
            CSM.UI.CruiseWizard.FormAddTreeDefault dialog = new CSM.UI.CruiseWizard.FormAddTreeDefault(appState.SetupServ.GetProductCodes());
            if (dialog.ShowDialog(newTDV) == DialogResult.OK)
            {
                this.Presentor.Data.AllTreeDefaults.Add(newTDV);
                newTDV.Save();
            }
        }

        private void _editSubPopBtn_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO tdv = this.SampleGroup_TDVBindingSource.Current as TreeDefaultValueDO;
            if (tdv == null) { return; }
            TreeDefaultValueDO temp = new TreeDefaultValueDO(tdv);
            ApplicationState appState = ApplicationState.GetHandle();

            CSM.UI.CruiseWizard.FormAddTreeDefault dialog = new CSM.UI.CruiseWizard.FormAddTreeDefault(appState.SetupServ.GetProductCodes());
            if (dialog.ShowDialog(tdv) == DialogResult.OK)
            {
                tdv.Save();
            }
            else
            {
                tdv.SetValues(temp);
            }
        }

        private void StrataDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void CuttingUnitDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore
            //it would be nice to beable to handle a situation where the lookup value in a combobox column
            //isn't exactly the same as the cell's value. EX. stored value is "421 " but value in combobox is "421" and causes a data error. 

        }

        private void Strata_CuttingUnitsGridView_SelectionChanging(object sender, FMSC.Controls.SelectionChangingEventArgs e)
        {
            StratumDO st = this.StrataBindingSource.Current as StratumDO;
            if (e.IsRemoving == false) { return; } // we don't care if they are adding 
            if(st == null) { e.Cancel = true; return; }
            e.Cancel = !Presentor.CanEditStratumField(st, null);
        }

        private void SampleGroups_TDVGridView_SelectionChanging(object sender, FMSC.Controls.SelectionChangingEventArgs e)
        {
            SampleGroupDO sg = this.SampleGroupBindingSource.Current as SampleGroupDO;
            TreeDefaultValueDO tdv = e.Item as TreeDefaultValueDO;
            if (e.IsRemoving == false) { return; } // we don't care if they are adding 
            if (sg == null || tdv == null) { e.Cancel = true; return; }
            bool canRemove = Presentor.CanRemoveTreeDefault(sg, tdv);
            e.Cancel = !canRemove;
            if (!canRemove)
            {
                MessageBox.Show("Can't remove this species because it has tree data or tree counts.");
            }
            else
            {
                //TODO handle removal of tree default from sample group
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
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

        }

        private void SampleGroupDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        

       

        

        

    }
}
