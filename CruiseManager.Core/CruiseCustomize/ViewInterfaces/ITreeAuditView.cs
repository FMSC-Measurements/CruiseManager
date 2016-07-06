using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ITreeAuditView : IView
    {
        new TreeAuditRulePresenter ViewPresenter { get; set; }

        void UpdateTreeAudits();

        void UpdateTreeDefaults();
    }
}