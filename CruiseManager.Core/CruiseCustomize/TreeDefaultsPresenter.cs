using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;
using CruiseManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class TreeDefaultsPresenter : ViewModelBase, ISaveHandler
    {
        private bool _isInitialized;
        private BindingList<TreeDefaultValueDO> _treeDefaults;

        public DAL Database { get; }
        protected IExceptionHandler ExceptionHandler { get; }

        public BindingList<TreeDefaultValueDO> TreeDefaults
        {
            get => _treeDefaults;
            set => SetProperty(ref _treeDefaults, value);
        }

        protected List<TreeDefaultValueDO> DeletedTreeDefaults { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                return TreeDefaults.Any(x => x.IsChanged || !x.IsPersisted)
                    || DeletedTreeDefaults.Any();
            }
        }

        public TreeDefaultsPresenter(IDatabaseProvider databaseProvider, IExceptionHandler exceptionHandler)
        {
            Database = databaseProvider.Database;
            ExceptionHandler = exceptionHandler;
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            if (_isInitialized) { return; }
            try
            {
                var treeDefaults = Database.From<TreeDefaultValueDO>().Query().ToList();
                
                DeletedTreeDefaults = new List<TreeDefaultValueDO>();
                TreeDefaults = new BindingList<TreeDefaultValueDO>(treeDefaults);
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

        public void DeleteTreeDefault(TreeDefaultValueDO tdv)
        {
            if(tdv == null) { throw new ArgumentNullException(nameof(tdv)); }
            DeletedTreeDefaults.Add(tdv);
            TreeDefaults.Remove(tdv);
        }

        public bool HandleSave()
        {
            var errorBuilder = new StringBuilder();
            return SaveTreeDefaults(ref errorBuilder);
        }

        private bool SaveTreeDefaults(ref StringBuilder errorBuilder)
        {
            if (!_isInitialized) { return true; }
            try
            {
                this.Database.BeginTransaction();
                foreach (TreeDefaultValueDO tdv in DeletedTreeDefaults)
                {
                    if (tdv.IsPersisted)
                    {
                        tdv.Delete();
                    }
                }
                foreach (TreeDefaultValueDO tdv in TreeDefaults)
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
                errorBuilder.AppendFormat("File save error. Tree Audit Rules was not saved. <Error details: {0}>", ex.ToString());
                this.Database.RollbackTransaction();
                return false;
            }
        }
    }
}