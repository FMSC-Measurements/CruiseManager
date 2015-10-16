using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class TreeAuditRulePresenter : Presentor, ISaveHandler
    {
        bool _isInitialized;

        public new CruiseCustomizeView View
        {
            get { return (CruiseCustomizeView)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }

        public bool HasChangesToSave
        {
            get
            {
                return TreeAudits.Any(x => x.HasChanges
                || x.IsPersisted
                || true);//x.TreeDefaultValues.)//TODO add HasChanges property to mapping collection
            }
        }

        public List<TreeAuditValueDO> TreeAudits { get; set; }
        public List<TreeDefaultValueDO> TreeDefaults { get; set; }

        public TreeAuditRulePresenter(ApplicationControllerBase appController)
            : base(appController)
        { }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            if (_isInitialized) { return; }
            try
            {
                TreeDefaults = this.Database.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
                TreeAudits = this.Database.Read<TreeAuditValueDO>("TreeAuditValue", "Order By Field");
                _isInitialized = true;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
            }
            this.View.UpdateTreeAudits();
            this.View.UpdateTreeDefaults();
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
                this.Database.EndTransaction();
                return true;
            }
            catch (Exception ex)
            {
                errorBuilder.AppendFormat("File save error. Tree Audit Rules was not saved. <Error details: {0}>", ex.ToString());
                this.Database.CancelTransaction();
                return false;
            }

        }
    }
}
