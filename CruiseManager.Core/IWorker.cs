﻿using System;

namespace CruiseManager.Core
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