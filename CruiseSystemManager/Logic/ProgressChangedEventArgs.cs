using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSM.Logic
{
    public class WorkerProgressChangedEventArgs : System.ComponentModel.ProgressChangedEventArgs
    {
        public WorkerProgressChangedEventArgs(int progress)
            : base(progress, null)
        { }

        public bool IsDone { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
    }
}
