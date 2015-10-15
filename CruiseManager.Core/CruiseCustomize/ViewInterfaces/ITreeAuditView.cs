using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ITreeAuditView : IView
    {
        new TreeAuditRulePresenter ViewPresenter { get; set; }

        void UpdateTreeAudits();
        void UpdateTreeDefaults();
    }
}
