using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core
{
    public interface IView
    {
        IPresentor ViewPresenter { get; }

        //IEnumerable<ViewCommand> NavCommands { get; }
        //IEnumerable<ViewCommand> UserCommands { get; }

        event EventHandler Load; 
    }
}

