using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using System.Collections.Generic;

namespace CruiseManager.Core.ViewModel
{
    public interface IContainerView : IView, INavigationService
    {
        ApplicationControllerBase ApplicationController { get; }

        IEnumerable<ViewNavigateCommand> ViewLinks { get; }

        IView ActiveView { get; set; }
    }
}