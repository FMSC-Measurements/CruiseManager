using CruiseManager.Core.App;

namespace CruiseManager.Core.ViewModel
{
    public interface IPresentor //: IDisposable
    {
        //WindowPresenter WindowPresenter { get; }
        ApplicationControllerBase ApplicationController { get; }

        //event EventHandler<PresenterStatusChangedEventArgs> StatusChanged;

        IView View { get; set; }
    }
}