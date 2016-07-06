using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ILogMatrixView : IView
    {
        new LogMatrixPresenter ViewPresenter { get; set; }

        void UpdateLogMatrix();
    }
}