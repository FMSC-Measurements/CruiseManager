using CruiseDAL.DataObjects;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseWizard
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

        #endregion Constructer

        #region Properties

        public CruiseWizardPresenter Presenter { get { return MasterView.Presenter; } }
        public CruiseWizardView MasterView { get; set; }

        #endregion Properties

        #region Initialization methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeBindings();
            this.CodeTextBox.Focus();
        }

        public void InitializeBindings()
        {
            CuttingUnitBindingSource.DataSource = Presenter.CuttingUnits;
            LoggingMethodBindingSource.DataSource = Presenter.LoggingMethods;
        }

        #endregion Initialization methods

        #region Click Envent

        private void StrataButton_Click(object sender, EventArgs e)
        {
            Presenter.ShowStratum();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MasterView.Close();
        }

        #endregion Click Envent

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
                this.CodeTextBox.Focus();
                return true;
            }
            return false;
        }

        #endregion IPage Members

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
                this.CodeTextBox.Focus();
            }
        }
    }
}