using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public class LogAuditRuleView : UserControlView, ILogAuditView
    {
        public new LogAuditRulePresenter ViewPresenter
        {
            get { return (LogAuditRulePresenter)base.ViewPresenter; }
            set
            {
                base.ViewPresenter = value;
            }
        }

        public LogAuditRuleView(LogAuditRulePresenter presenter)
        {
            ViewPresenter = presenter;
        }

        protected override void OnViewPresenterChanging()
        {
            base.OnViewPresenterChanging();
            var presenter = ViewPresenter;
            if (presenter != null)
            {
                presenter.LogAuditsChanged -= ViewPresenter_LogAuditsChanged;
                presenter.LogAuditsModified -= ViewPresenter_LogAuditsModified;
            }
        }

        protected override void OnViewPresenterChanged()
        {
            base.OnViewPresenterChanged();
            var presenter = ViewPresenter;
            if (presenter != null)
            {
                presenter.LogAuditsChanged += ViewPresenter_LogAuditsChanged;
                presenter.LogAuditsModified += ViewPresenter_LogAuditsModified;
            }
        }

        private void ViewPresenter_LogAuditsModified(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewPresenter_LogAuditsChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}