using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL;
using CruiseDAL.DataObjects;

namespace CruiseManager.Winforms.CruiseWizard
{
    public partial class CuttingUnitsPage : UserControl, IPage
    {
        #region Constructer
        public CuttingUnitsPage(String Name, CruiseWizardView MasterView)
        {
            InitializeComponent();
            this.MasterView = MasterView;
            base.Name = Name;
        }
        #endregion

        #region Properties
        public CruiseWizardPresenter Presenter { get { return MasterView.Presenter; } }
        public CruiseWizardView MasterView { get; set; }
        #endregion 

        #region Initialization methods
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeBindings();
            this.CodeTextBox.TextBox.Focus();
        }


        public void InitializeBindings()
        {
            CuttingUnitBindingSource.DataSource = Presenter.CuttingUnits;
            LoggingMethodBindingSource.DataSource = Presenter.LoggingMethods;
        }
        #endregion


        #region Click Envent
        private void StrataButton_Click(object sender, EventArgs e)
        {
            Presenter.ShowStratum();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MasterView.Close();
        }
        #endregion

        private void CuttingUnitBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = Presenter.GetNewCuttingUnit();
        }


        #region IPage Members


        public bool HandleKeypress(System.Windows.Forms.Keys key)
        {
            if (key == System.Windows.Forms.Keys.F1)
            {
                CuttingUnitBindingSource.AddNew();
                this.CodeTextBox.TextBox.Focus();
                return true;
            }
            return false;
        }

        #endregion

        private void CuttingUnitBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CuttingUnitDO currentUnit = CuttingUnitBindingSource.Current as CuttingUnitDO;
            if (currentUnit == null)
            {
                this.tableLayoutPanel2.Enabled = false;
            }
            else
            {
                this.tableLayoutPanel2.Enabled = true;
                this.CodeTextBox.TextBox.Focus();
            }
        }


    }
}
