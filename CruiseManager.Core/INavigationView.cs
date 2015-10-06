using CruiseManager.Core.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core
{
    public interface INavigationView : IView
    {
        IEnumerable<ViewNavigateCommand> NavCommands { get; set; }
    }
}
