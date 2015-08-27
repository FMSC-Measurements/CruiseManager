using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using CSM.Utility.Setup;

namespace CSM.UI.SetupEditor
{
    public partial class SetupView : Form, IView
    {

        public SetupPresenter Presenter { get; set; }
    
        public SetupView(SetupPresenter Presenter)
        {
            Presenter.View = this;
            this.Presenter = Presenter;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CruiseMethodBindingSource.DataSource = Presenter.CruiseMethods;

            ProductCodesBindingSource.DataSource = Presenter.ProductCodes;
            LoggingMethodsBindingSource.DataSource = Presenter.LoggingMethods;
            UOMCodesBindingSource.DataSource = Presenter.UOMCodes;

            TreeFieldOrderableAddRemoveWidget.DataSource = Presenter.AvalableTreeFieldSetups;
            TreeFieldOrderableAddRemoveWidget.SelectedItemsDataSource = Presenter.SelectedTreeFieldSetups;

            LogFieldOrderableAddRemoveWidget.DataSource = Presenter.AvalableLogFieldSetups;
            LogFieldOrderableAddRemoveWidget.SelectedItemsDataSource = Presenter.SelectedLogFieldSetups;

            RegionBindingSource.DataSource = Presenter.Regions;

        }

        private void CruiseMethodBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Presenter.CurrentCruiseMethod = (CruiseMethod)CruiseMethodBindingSource.Current;
        }
     

        public void UpdateCruiseMethodList()
        {
            CruiseMethodBindingSource.ResetBindings(false);
        }

        public void ResetFieldSelectors()
        {
            TreeFieldOrderableAddRemoveWidget.DataSource = Presenter.AvalableTreeFieldSetups;
            TreeFieldOrderableAddRemoveWidget.SelectedItemsDataSource = Presenter.SelectedTreeFieldSetups;     
            LogFieldOrderableAddRemoveWidget.DataSource = Presenter.AvalableLogFieldSetups;
            LogFieldOrderableAddRemoveWidget.SelectedItemsDataSource = Presenter.SelectedLogFieldSetups;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {      
            Presenter.Save();
        }


    }
}