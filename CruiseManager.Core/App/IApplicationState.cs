using System;

namespace CruiseManager.Core.App
{
    public interface IApplicationState
    {
        String[] RecentFiles { get; }

        void AddRecentFile(String path);

        void Save();
    }
}