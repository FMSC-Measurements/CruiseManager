using CruiseManager.Core.App;
using System.Collections.Generic;
using System.IO;

namespace CruiseManager.Services
{
    public class TemplateFileProvider
    {
        protected IPlatformHelper PlatformHelper { get; }

        IEnumerable<FileInfo> TemplateFiles => GetTemplateFiles();

        public TemplateFileProvider(IPlatformHelper platformHelper)
        {
            PlatformHelper = platformHelper;
        }

        public IEnumerable<FileInfo> GetTemplateFiles()
        {
            DirectoryInfo tDir = PlatformHelper.GetTemplateFolder();
            //filter all files ending in .cut

            return tDir.GetFiles("*" + Core.Constants.Strings.CRUISE_TEMPLATE_FILE_EXTENTION);
        }
    }
}
