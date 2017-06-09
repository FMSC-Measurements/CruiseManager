using CruiseManager.Core.App;
using System.ComponentModel;

namespace CruiseManager.Core.ViewModel
{
    public interface IPresentor //: INotifyPropertyChanged //: IDisposable
    {
        ApplicationControllerBase ApplicationController { get; }

        IView View { get; set; }
    }
}