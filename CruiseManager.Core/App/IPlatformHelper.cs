using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CruiseManager.Core.App
{
    public interface IPlatformHelper
    {
        DirectoryInfo GetTemplateFolder();

        string GetApplicationDirectory();
    }
}
