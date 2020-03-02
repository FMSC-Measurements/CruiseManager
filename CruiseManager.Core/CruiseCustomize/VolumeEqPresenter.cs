using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class VolumeEqPresenter : ViewModel.Presentor, ISaveHandler
    {
        private bool _isInitialized;

        public new ViewInterfaces.IVolumeEq View
        {
            get { return (ViewInterfaces.IVolumeEq)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }
        public List<VolumeEquationDO> VolumeEqs { get; set; }

        public List<VolumeEquationDO> DeletedVolumeEqs { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                return VolumeEqs.Any(x => x.IsChanged || !x.IsPersisted)
                    || DeletedVolumeEqs.Any();
            }
        }

        public VolumeEqPresenter(IApplicationController appController)
            : base(appController)
        { }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            if (_isInitialized) { return; }
            try
            {
                VolumeEqs = Database.From<VolumeEquationDO>().Query().ToList();
                DeletedVolumeEqs = new List<VolumeEquationDO>();
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                if (!ApplicationController.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
                View.UpdateVolumeEqs();
            }
        }

        public bool HandleSave()
        {
            var errorBuilder = new StringBuilder();
            return SaveVolumeEqs(ref errorBuilder);
        }

        private bool SaveVolumeEqs(ref StringBuilder errorBuilder)
        {
            if (!_isInitialized) { return true; }
            try
            {
                this.Database.BeginTransaction();
                foreach (VolumeEquationDO tdv in DeletedVolumeEqs)
                {
                    if (tdv.IsPersisted)
                    {
                        tdv.Delete();
                    }
                }
                foreach (VolumeEquationDO tdv in VolumeEqs)
                {
                    if (tdv.DAL == null)
                    {
                        tdv.DAL = this.Database;
                    }
                    tdv.Save();
                }
                this.Database.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                errorBuilder.AppendFormat("File save error. Volume Equations was not saved. <Error details: {0}>", ex.ToString());
                this.Database.RollbackTransaction();
                return false;
            }
        }
    }
}