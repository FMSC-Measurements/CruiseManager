using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ITallySetupView : IView
    {
        new TallySetupPresenter ViewPresenter { get; set; }

        void UpdateTallySetupView();

    }
}