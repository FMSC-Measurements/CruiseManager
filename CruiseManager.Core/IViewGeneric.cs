using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core
{
    public abstract class IView<T> : T, IView
    {
        public IPresentor ViewPresenter { get; set; }

        public IEnumerable<ViewCommand> NavCommands { get; set; }
        public IEnumerable<ViewCommand> UserCommands { get; set; }

    }
}
