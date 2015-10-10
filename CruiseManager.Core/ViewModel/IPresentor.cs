using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.ViewModel
{
    public interface IPresentor //: IDisposable
    {
        //WindowPresenter WindowPresenter { get; }
        ApplicationController ApplicationController { get; }

        //event EventHandler<PresenterStatusChangedEventArgs> StatusChanged;

        IView View { get; set; }
    }
}
