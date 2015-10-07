using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class PlatformHelper
    {
        //public static PlatformHelper Instance { get; set; } 

        public abstract DirectoryInfo GetTemplateFolder();

        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
    }
}
