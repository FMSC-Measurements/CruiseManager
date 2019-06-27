using CruiseManager.Core.CommandModel;
using CruiseManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CruiseManager.Core.ViewModel
{
    public interface IWindow : IDisposable
    {
        //bool InvokeRequired { get; }
        //object Invoke(Delegate d);

        event CancelEventHandler Closing;

        INavigationService NavigationService { get; }

        IDialogService DialogService { get; }

        void SetActiveView(IView view);

        void SetNavCommands(IEnumerable<BindableCommand> navCommands);
    }
}