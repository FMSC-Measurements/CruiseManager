using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseManager.Data;
using CruiseManager.WinForms.CruiseWizard;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class TreeDefView : CruiseManager.WinForms.UserControlView, ITreeDefaultsView
    {
        public TreeDefView(TreeDefaultsPresenter viewPresenter, ISetupService setupService, IExceptionHandler exceptionHandler)
        {
            SetupService = setupService;
            ExceptionHandler = exceptionHandler;
            ViewPresenter = viewPresenter;
            viewPresenter.PropertyChanged += ViewPresenter_PropertyChanged;
            InitializeComponent();
        }

        private void ViewPresenter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            if(propertyName == nameof(TreeDefaultsPresenter.TreeDefaults))
            {
                UpdateTreeDefaults();
            }
        }

        protected ISetupService SetupService { get; }
        protected IExceptionHandler ExceptionHandler { get; }

        public new TreeDefaultsPresenter ViewPresenter
        {
            get { return (TreeDefaultsPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public void UpdateTreeDefaults()
        {
            _BS_treeDefaults.DataSource = ViewPresenter.TreeDefaults;
        }

        private void _addTDVButton_Click(object sender, System.EventArgs e)
        {
            TreeDefaultValueDO newTDV = this.ShowAddTreeDefault();
            if (newTDV != null)
            {
                this._BS_treeDefaults.Add(newTDV);
            }
        }

        private void _editTDVButton_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO tdv = this._BS_treeDefaults.Current as TreeDefaultValueDO;
            if (tdv == null) { return; }
            {
                this.ShowEditTreeDefault(tdv);
            }
        }

        public TreeDefaultValueDO ShowAddTreeDefault()
        {
            TreeDefaultValueDO newTDV = new TreeDefaultValueDO(ViewPresenter.Database);

            return this.ShowEditTreeDefault(newTDV);
        }

        public TreeDefaultValueDO ShowEditTreeDefault(TreeDefaultValueDO tdv)
        {
            try
            {
                using (FormAddTreeDefault dialog = new FormAddTreeDefault(SetupService.GetProductCodes()))
                {
                    if (dialog.ShowDialog(tdv) == DialogResult.OK)
                    {
                        return tdv;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                if (!ExceptionHandler.Handel(ex))
                {
                    throw;
                }
                else
                {
                    return null;
                }
            }
        }

        private void _deleteTDVBTN_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO tdv = _BS_treeDefaults.Current as TreeDefaultValueDO;
            if (tdv == null) { return; }
            ViewPresenter.DeleteTreeDefault(tdv);
        }
    }
}