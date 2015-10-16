using CruiseManager.Core.App;
using System.IO;
using System.Windows.Forms;

namespace CruiseManager.WinForms.App
{
    public class PlatformHelper : IPlatformHelper
    {
        public DirectoryInfo GetTemplateFolder()
        {
            string commonAppDir = Application.CommonAppDataPath;
            DirectoryInfo companyDir = System.IO.Directory.GetParent(commonAppDir);
            while (companyDir.Name != Application.CompanyName && companyDir.Parent != null)
            {
                companyDir = companyDir.Parent;
            }
            DirectoryInfo templateFolder = new DirectoryInfo(companyDir.FullName + "\\TemplateFiles");
            if (templateFolder.Exists == false) { templateFolder.Create(); }
            return templateFolder;
        }

        string IPlatformHelper.GetApplicationDirectory()
        {
            return PlatformHelper.GetApplicationDirectory();
        }

        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
    }
}
