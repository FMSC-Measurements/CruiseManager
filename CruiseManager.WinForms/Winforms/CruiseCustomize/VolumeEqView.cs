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
    public partial class VolumeEqView : CruiseManager.WinForms.UserControlView, IVolumeEq
    {
        public VolumeEqView(VolumeEqPresenter viewPresenter, ISetupService setupService, IExceptionHandler exceptionHandler)
        {
            ExceptionHandler = exceptionHandler;
            SetupService = setupService;
            ViewPresenter = viewPresenter;
            viewPresenter.PropertyChanged += ViewPresenter_PropertyChanged;
            InitializeComponent();
        }

        private void ViewPresenter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            if(propertyName == nameof(VolumeEqPresenter.VolumeEqs))
            {
                UpdateVolumeEqs();
            }
        }

        protected IExceptionHandler ExceptionHandler { get; }
        protected ISetupService SetupService { get; }

        public new VolumeEqPresenter ViewPresenter
        {
            get { return (VolumeEqPresenter)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected void UpdateVolumeEqs()
        {
            _BS_VolEquations.DataSource = ViewPresenter.VolumeEqs;
        }

        private void _volEq_add_button_Click(object sender, System.EventArgs e)
        {
            VolumeEquationDO newTDV = this.ShowAddVolumeEq();
            if (newTDV != null)
            {
                this._BS_VolEquations.Add(newTDV);
            }
        }

        public VolumeEquationDO ShowAddVolumeEq()
        {
            VolumeEquationDO newTDV = new VolumeEquationDO(ViewPresenter.Database);

            return this.ShowEditVolumeEq(newTDV);
        }

        public VolumeEquationDO ShowEditVolumeEq(VolumeEquationDO tdv)
        {
            try
            {
                using (FormAddVolumeEqs dialog = new FormAddVolumeEqs(SetupService.GetProductCodes()))
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

        private void _volEq_delete_button_Click(object sender, EventArgs e)
        {
            VolumeEquationDO volEq = _BS_VolEquations.Current as VolumeEquationDO;
            if (volEq == null) { return; }
            ViewPresenter.DeleteVolumeEquation(volEq);

        }
    }
}