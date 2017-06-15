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
    public class ReportsSummPresenter : Presentor, ISaveHandler
    {
        private bool _isInitialized;

        public new ViewInterfaces.IReportsSumm View
        {
            get { return (IReportsSumm)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }
        public BindingList<ReportsDO> DefaultReports { get; set; }
        public List<ReportsDO> DeletedReports { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                View.EndEdit();
                return DefaultReports.Any(x => x.IsChanged
                || !x.IsPersisted) || DeletedReports.Any();
            }
        }

        public ReportsSummPresenter(ApplicationControllerBase appController)
            : base(appController)
        { }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);
            if (_isInitialized) { return; }
            try
            {
                List<ReportsDO> reports = ApplicationController.Database.From<ReportsDO>()
                    .Query().ToList();
                this.DefaultReports = new BindingList<ReportsDO>(reports);
                DeletedReports = new List<ReportsDO>();
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
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
                foreach (ReportsDO tdv in DefaultReports)
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