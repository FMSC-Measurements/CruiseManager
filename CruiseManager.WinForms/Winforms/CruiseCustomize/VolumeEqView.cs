using CruiseDAL.DataObjects;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseManager.WinForms.CruiseWizard;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class VolumeEqView : CruiseManager.WinForms.UserControlView, IVolumeEq
    {
        public VolumeEqView(VolumeEqPresenter viewPresenter)
        {
            ViewPresenter = viewPresenter;
            ViewPresenter.View = this;
            InitializeComponent();
        }

        public new VolumeEqPresenter ViewPresenter
        {
            get { return (VolumeEqPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public void UpdateVolumeEqs()
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
            VolumeEquationDO newTDV = new VolumeEquationDO(ViewPresenter.ApplicationController.Database);

            return this.ShowEditVolumeEq(newTDV);
        }

        public VolumeEquationDO ShowEditVolumeEq(VolumeEquationDO tdv)
        {
            try
            {
                using (FormAddVolumeEqs dialog = new FormAddVolumeEqs(ViewPresenter.ApplicationController.SetupService.GetProductCodes()))
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
                if (!ViewPresenter.ApplicationController.ExceptionHandler.Handel(ex))
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
            VolumeEquationDO tdv = _BS_VolEquations.Current as VolumeEquationDO;
            if (tdv == null) { return; }
            ViewPresenter.DeletedVolumeEqs.Add(tdv);
            _BS_VolEquations.Remove(tdv);
        }
    }
}