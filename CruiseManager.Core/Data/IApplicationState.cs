using System;
using System.Collections.Generic;

namespace CruiseManager.Data
{
    public interface IApplicationState
    {
        bool InSupervisorMode { get; set; }

        IEnumerable<string> RecentFiles { get; }

        void AddRecentFile(string path);

        //void Save();
    }
}