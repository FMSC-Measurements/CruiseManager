using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;
using CruiseManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class TreeAuditRulePresenter : ViewModelBase, ISaveHandler
    {
        bool _isInitialized;
        private List<TreeAuditValueDO> _treeAudits;
        private List<TreeDefaultValueDO> _treeDefaults;

        public DAL Database { get; }

        public bool HasChangesToSave
        {
            get
            {
                return TreeAudits.Any(x => x.IsChanged
                || !x.IsPersisted
                || x.TreeDefaultValues.HasChanges);//TODO add HasChanges property to mapping collection
            }
        }

        public List<TreeAuditValueDO> TreeAudits
        {
            get => _treeAudits;
            set => SetProperty(ref _treeAudits, value);
        }

        public List<TreeDefaultValueDO> TreeDefaults
        {
            get => _treeDefaults;
            set => SetProperty(ref _treeDefaults, value);
        }

        public TreeAuditRulePresenter(IDatabaseProvider databaseProvider)
        {
            Database = databaseProvider.Database;
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            if (_isInitialized) { return; }
            try
            {
                var treeDefaults = Database.From<TreeDefaultValueDO>().Read().ToList();
                var treeAudits = Database.From<TreeAuditValueDO>().OrderBy("Field").Read().ToList();

                TreeDefaults = treeDefaults;
                TreeAudits = treeAudits;

                _isInitialized = true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
            }
        }

        public bool HandleSave()
        {
            var errorBuilder = new StringBuilder();
            return SaveTreeAudits(ref errorBuilder);
        }

        private bool SaveTreeAudits(ref StringBuilder errorBuilder)
        {
            if (!_isInitialized) { return true; }
            try
            {
                this.Database.BeginTransaction();
                foreach (TreeAuditValueDO tav in TreeAudits)
                {
                    if (tav.DAL == null)
                    {
                        tav.DAL = this.Database;
                    }
                    tav.Save();
                    tav.TreeDefaultValues.Save();
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