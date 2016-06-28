using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface EditTemplateView : IView
    {
        void UpdateVolumeEqs();

        void UpdateFieldSetup();

        void UpdateTreeAudit();

        void UpdateTreeDefaults();

        void UpdateReports();
    }
}