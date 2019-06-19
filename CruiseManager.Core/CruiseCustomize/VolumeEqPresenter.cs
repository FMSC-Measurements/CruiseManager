using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;
using CruiseManager.Services;
using CruiseManager.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class VolumeEqPresenter : ViewModel.ViewModelBase, IViewLoadAware, ISaveHandler
    {
        private bool _isInitialized;
        private BindingList<VolumeEquationDO> _volumeEqs;

        protected IExceptionHandler ExceptionHandler { get; }
        public DAL Database { get; }
        
        public BindingList<VolumeEquationDO> VolumeEqs
        {
            get => _volumeEqs;
            set => SetProperty(ref _volumeEqs, value);
        }

        protected List<VolumeEquationDO> DeletedVolumeEqs { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                return VolumeEqs.Any(x => x.IsChanged || !x.IsPersisted)
                    || DeletedVolumeEqs.Any();
            }
        }

        public VolumeEqPresenter(IDatabaseProvider databaseProvider, IExceptionHandler exceptionHandler)
        {
            Database = databaseProvider.Database;
            ExceptionHandler = exceptionHandler;
        }

        public void OnViewLoad()
        {
            if (_isInitialized) { return; }
            try
            {
                var volumeEquations = Database.From<VolumeEquationDO>().Query().ToList();
                DeletedVolumeEqs = new List<VolumeEquationDO>();
                VolumeEqs = new BindingList<VolumeEquationDO>(volumeEquations);
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                if (!ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
        }

        public void DeleteVolumeEquation(VolumeEquationDO volEq)
        {
            if(volEq == null) { throw new ArgumentNullException(nameof(volEq)); }

            DeletedVolumeEqs.Add(volEq);
            VolumeEqs.Remove(volEq);
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