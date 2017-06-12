using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ITreeDef : IView
    {
        new TreeDefPresenter ViewPresenter { get; set; }

        void UpdateTreeDefaults();
    }
}
