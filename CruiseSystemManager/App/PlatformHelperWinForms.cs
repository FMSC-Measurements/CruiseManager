using CruiseManager.Core.App;
using System.IO;
using System.Windows.Forms;

namespace CSM.App
{
    class PlatformHelperWinForms : PlatformHelper
    {
        public override DirectoryInfo GetTemplateFolder()
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
    }
}
