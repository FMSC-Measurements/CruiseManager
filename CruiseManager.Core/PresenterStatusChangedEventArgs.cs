using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core
{
    public enum PresenterStatus { Ready, Initializing, Working }

    public class PresenterStatusChangedEventArgs
    {
        public PresenterStatus Status { get; set; }
    }

}
