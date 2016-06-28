using System;
using System.ComponentModel;

namespace CruiseManager.Core.ViewModel
{
    public interface IWindow : IDisposable
    {
        string Text { get; set; }
        bool InvokeRequired { get; }

        event CancelEventHandler Closing;

        object Invoke(Delegate d);

        //void ShowWaitCursor();

        //void ShowDefaultCursor();
    }
}