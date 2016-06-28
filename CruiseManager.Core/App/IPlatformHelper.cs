using System.IO;

namespace CruiseManager.Core.App
{
    public interface IPlatformHelper
    {
        DirectoryInfo GetTemplateFolder();

        string GetApplicationDirectory();
    }
}