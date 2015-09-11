using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSM.Common
{
    public interface IWorker
    {
        event EventHandler<WorkerProgressChangedEventArgs> ProgressChanged;

        string ActionName { get; }

        bool IsDone { get; }
        bool IsWorking { get; }

        bool IsCanceled { get; }

        void BeginWork();

        void Cancel();

        bool Wait();
    }
}
