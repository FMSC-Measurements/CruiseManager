using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CruiseManager.Core.ViewModel
{
    public interface IWindow:IDisposable
    {
        string Text { get; set; }
        bool InvokeRequired { get; }

        event CancelEventHandler Closing;

        object Invoke(Delegate d);

        //void ShowWaitCursor();

        //void ShowDefaultCursor();

    }
}
