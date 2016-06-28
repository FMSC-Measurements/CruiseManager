using CruiseManager.Core.App;

namespace CruiseManager.Core.ViewModel
{
    public interface IDialog
    {
        void Show(ApplicationControllerBase applicationController, ref IDialogDataContext dataContext);
    }
}