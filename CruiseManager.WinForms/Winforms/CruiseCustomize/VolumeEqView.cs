using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.ComponentModel;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class VolumeEqView : CruiseManager.WinForms.UserControlView//, IVolumeEq
    {
        public VolumeEqView(WindowPresenter windowPresenter, VolumeEqPresenter viewPresenter)
        {
            this.WindowPresenter = windowPresenter;
            this.ViewPresenter = viewPresenter;
            ViewPresenter.View = this;
            InitializeComponent();
        }

        protected WindowPresenter WindowPresenter { get; set; }

        public new VolumeEqPresenter ViewPresenter
        {
            get { return ((VolumeEqPresenter)base.ViewPresenter); }
            set { base.ViewPresenter = value; }
        }

        public void UpdateVolumeDefaults()
        {
           // _BS_VolEquations.DataSource = ViewPresenter.VolumeDefaults;
        }

        //#region VolEq

        //private void _volEq_add_button_Click(object sender, EventArgs e)
        //{
        //    this._BS_VolEquations.Add(new VolumeEquationDO(this.ViewPresenter.Database));
        //}

        //private void _volEq_delete_button_Click(object sender, EventArgs e)
        //{
        //    VolumeEquationDO obj = this._BS_VolEquations.Current as VolumeEquationDO;
        //    if (obj != null)
        //    {
        //        obj.Delete();
        //        this._BS_VolEquations.Remove(obj);
        //    }
        //}

        //private void _volumeEQsDGV_VisibleChanged(object sender, EventArgs e)
        //{
        //    ViewPresenter.HandleVolumeEquLoad();
        //}

        public void updatevolumeeqs()
        {
            //_bs_volequations.datasource = viewpresenter.volumeeqs;
        }

        //#endregion VolEq
    }
}