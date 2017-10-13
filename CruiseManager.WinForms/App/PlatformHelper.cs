using CruiseManager.Core.App;
using System;
using System.IO;
using System.Reflection;
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
            var codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var codeBasePath = Uri.UnescapeDataString(codeBaseUri);
            var directory = System.IO.Path.GetDirectoryName(codeBasePath);

            return directory;

            //return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }
    }
}