using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface IReportsSumm : IView
    {
        new ReportsSummPresenter ViewPresenter { get; set; }
        void UpdateReports();

        void EndEdit();
    }
}
