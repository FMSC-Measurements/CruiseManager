using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using System.Collections.Generic;

namespace CruiseManager.Core.ViewModel
{
    public interface IContainerView : IView, INavigationService
    {
        IApplicationController ApplicationController { get; }

        IEnumerable<ViewNavigateCommand> ViewLinks { get; }

        IView ActiveView { get; set; }
    }
}