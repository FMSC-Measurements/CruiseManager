using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class UserSettings
    {
        public const int RECENT_FILE_LIST_SIZE = 10;

        public bool? CreateSaleFolder { get; set; }

        //public static UserSettings Instance { get; set; }

        public abstract string CruiseSaveLocation { get; set; }

        public abstract string TemplateSaveLocation { get; set; }

        public abstract string[] RecentFiles { get; }

        public abstract void AddRecentFile(String path);
    }
}
