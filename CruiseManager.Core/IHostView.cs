using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core
{
    public interface IHostView
    {
        IView ActiveChildView { get; set; }
    }
}
