using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using Logger;
using System.ComponentModel;
using System.Linq;

namespace CSM.Winforms.CruiseWizard
{
    public partial class StrataPage : UserControl, IPage
    {

        #region Ctor
        public StrataPage(string Name, CruiseWizardView MasterView)
        {
            this.MasterView = MasterView;
            InitializeComponent();
            base.Name = Name;
        }

        #region Ctor Helper methods

        private void InitializeBindings()
        {
            StrataBindingSource.DataSource = Presentor.Strata;
            CuttingUnitBindingSource.DataSource = Presentor.CuttingUnits;
            UpdateCruiseMethods(Presentor.CruiseMethods);
            MonthComboBox.DataSource = Enumerable.Range(1, 12).ToArray();
        }
        #endregion
        #endregion

        #region Properties
        public CruiseWizardView MasterView { get; set; }
        public CruiseWizardPresenter Presentor { get { return MasterView.Presenter; } }
        #endregion


        public void UpdateCruiseMethods(object value)
        {
            this.CruiseMethodBindingSource.DataSource = value;
        }

        #region Click Events
        private void CuttingUnitButton_Click(object sender, EventArgs e)
        {
            Presentor.ShowCuttingUnits();
        }

        private void SampleGroupButton_Click(object sender, EventArgs e)
        {
            StratumDO st = StrataBindingSource.Current as StratumDO;
            Presentor.ShowSampleGroups(st);
        }


        //uses the x,y position of mouse click to find what item was clicked on
        //and determins if the item click resulted in the item being removed
        //or added to the list of selected items
        //private void CuttingUnitListBox_MouseClick(object sender, MouseEventArgs e)
        //{
        //    var index = CuttingUnitListBox.IndexFromPoint(e.X, e.Y);

        //    //check for error value
        //    if (index < 0)
        //    {
        //        //filter out
        //        return;
        //    }

        //    var stratum = StrataBindingSource.Current as StratumDO;
        //    var cuttingUnit = CuttingUnitBindingSource[index] as CuttingUnitDO;

        //    if (stratum == null || cuttingUnit == null)
        //    {
        //        return;
        //    }

        //    if (CuttingUnitListBox.SelectedIndices.Contains(index))
        //    {

        //        stratum.CuttingUnits.Add(cuttingUnit);
        //    }
        //    else
        //    {
        //        stratum.CuttingUnits.Remove(cuttingUnit);
        //    }
        //}
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeBindings();
            if (Presentor.Strata.Count == 0)
            {
                StrataBindingSource.AddNew();
 
            }
            this.CodeTextBox.TextBox.Focus();
        }

        private void StrataBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = Presentor.GetNewStratum();
        }


        private void StrataBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var stratum = StrataBindingSource.Current as StratumDO;
            if (stratum == null)
            {
                this.tableLayoutPanel2.Enabled = false;
                return;
            }
            else
            {
                this.tableLayoutPanel2.Enabled = true;
                this.CodeTextBox.TextBox.Focus();
            }
            stratum.CuttingUnits.Populate();
            CuttingUnitGridView.SelectedItems = stratum.CuttingUnits;
        }



        private void YearComboBox_DropDown(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(YearComboBox.Text))
            //{
            //    YearComboBox.SelectedIndex = DateTime.Today.Year - 1900;
            //}
        }

        private void MethodComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string method = MethodComboBox.SelectedValue as string;
            if (string.IsNullOrEmpty(method)) { return; }
            if (method.StartsWith("F"))
            {
                _kzTB.Enabled = false;
                _kzTB.Text = "0";
                BAFTextBox.TextBox.Text = "0";
                BAFTextBox.TextBox.Enabled = false;
                FixedPlotSizeTextBox.TextBox.Enabled = true;
            }
            else if (method.StartsWith("P"))
            {
                _kzTB.Enabled = false;
                _kzTB.Text = "0";
                FixedPlotSizeTextBox.TextBox.Text = "0";
                BAFTextBox.TextBox.Enabled = true;
                FixedPlotSizeTextBox.TextBox.Enabled = false;
            }
            else if (method == "3PPNT")
            {
                _kzTB.Enabled = true;
                FixedPlotSizeTextBox.TextBox.Text = "0";
                BAFTextBox.TextBox.Enabled = true;
                FixedPlotSizeTextBox.TextBox.Enabled = false;
            }
            else
            {
                _kzTB.Enabled = false;
                _kzTB.Text = "0";
                BAFTextBox.TextBox.Text = "0";
                FixedPlotSizeTextBox.TextBox.Text = "0";
                BAFTextBox.TextBox.Enabled = false;
                FixedPlotSizeTextBox.TextBox.Enabled = false;
            }

        }


        #region IPage Members


        public bool HandleKeypress(System.Windows.Forms.Keys key)
        {
            if (key == System.Windows.Forms.Keys.F1)
            {
                StrataBindingSource.AddNew();
                this.CodeTextBox.TextBox.Focus();
                return true;
            }
            return false;
        }

        #endregion

        
    }
}
