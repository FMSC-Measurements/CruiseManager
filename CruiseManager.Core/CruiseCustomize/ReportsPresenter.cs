using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class ReportsPresenter : Presentor, ISaveHandler
    {
        private bool _isInitialized;

        public new ViewInterfaces.IReportsView View
        {
            get { return (IReportsView)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }
        public List<ReportsDO> Reports { get; set; }
        public List<ReportsDO> DeletedReports { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                View.EndEdit();
                return Reports.Any(x => x.IsChanged || !x.IsPersisted)
                    || DeletedReports.Any();
            }
        }

        public ReportsPresenter(IApplicationController appController)
            : base(appController)
        { }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);
            if (_isInitialized) { return; }
            try
            {
                DeletedReports = new List<ReportsDO>();
                this.Reports = ApplicationController.Database.From<ReportsDO>()
                    .Query().ToList();
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                if (!ApplicationController.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
            View.UpdateReports();
        }

        public bool HandleSave()
        {
            var errorBuilder = new StringBuilder();

            return SaveReports(ref errorBuilder);
        }

        private bool SaveReports(ref StringBuilder errorBuilder)
        {
            if (!_isInitialized) { return true; }
            try
            {
                this.Database.BeginTransaction();
                foreach (ReportsDO tdv in DeletedReports)
                {
                    if (tdv.IsPersisted)
                    {
                        tdv.Delete();
                    }
                }
                foreach (ReportsDO tdv in Reports)
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
                errorBuilder.AppendFormat("File save error. Summary reports was not saved. <Error details: {0}>", ex.ToString());
                this.Database.RollbackTransaction();
                return false;
            }
        }
    }
}