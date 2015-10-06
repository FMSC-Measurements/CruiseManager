using CruiseDAL;
using CruiseManager.Core.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class ViewContext
    {
        public ApplicationController ApplicationController { get; set; }

        //public DAL Database { get; set; }
        public ViewContext ParentContext { get; set; }

        public IWindow HostWindow { get; set; }

        public IView ActiveView { get; set; }

        public IEnumerable<ViewNavigateCommand> NavigationCommands { get; set; }

        public IEnumerable<ViewCommand> Commands { get; set; }

    }
}
