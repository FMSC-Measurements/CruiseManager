using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface IVolumeEq : IView
    {
        new VolumeEqPresenter ViewPresenter { get; set; }

        void UpdateVolumeDefaults();
        void UpdateVolumeEqs();
    }
}
