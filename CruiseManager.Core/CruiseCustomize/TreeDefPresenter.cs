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
    public class TreeDefPresenter : Presentor, ISaveHandler
    {
        private bool _isInitialized;

        public new ViewInterfaces.ITreeDef View
        {
            get { return (ViewInterfaces.ITreeDef)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }
        public List<TreeDefaultValueDO> TreeDefaults { get; set; }

        public List<TreeDefaultValueDO> DeletedTreeDefaults { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                return TreeDefaults.Any(x => x.IsChanged
                || !x.IsPersisted) || DeletedTreeDefaults.Any();
            }
        }

        public TreeDefPresenter(ApplicationControllerBase appController)
            : base(appController)
        { }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            if (_isInitialized) { return; }
            try
            {
                TreeDefaults = Database.From<TreeDefaultValueDO>().Query().ToList();
                DeletedTreeDefaults = new List<TreeDefaultValueDO>();
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
            }
            View.UpdateTreeDefaults();
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