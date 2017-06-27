using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface IReportsView : IView
    {
        void UpdateReports();

        void EndEdit();
    }
}