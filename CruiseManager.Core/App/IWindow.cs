using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public interface IWindow
    {
        event EventHandler Closing;

        ViewContext ActiveViewContext { get; set; }

        void ViewContext_ActiveViewChanged();


    }
}
