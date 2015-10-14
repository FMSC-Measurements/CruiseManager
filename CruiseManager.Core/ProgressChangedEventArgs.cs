using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core
{
    public class WorkerProgressChangedEventArgs : System.ComponentModel.ProgressChangedEventArgs
    {
        public WorkerProgressChangedEventArgs() : base(0, null)
        { }

        public WorkerProgressChangedEventArgs(int progress)
            : base(progress, null)
        { }

        public bool IsDone { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
    }
}
