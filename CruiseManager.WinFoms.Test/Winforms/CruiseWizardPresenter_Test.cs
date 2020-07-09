using CruiseDAL;
using CruiseManager.WinForms.Test;
using FluentAssertions;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Winforms.Test.Winforms
{
    public class CruiseWizardPresenter_Test : TestBase
    {
        private string TemplateFileDir { get; }

        public CruiseWizardPresenter_Test(ITestOutputHelper output) : base(output)
        {
            TemplateFileDir = Path.Combine(ProjectOutputDir, "TemplateFiles");
        }

        [Theory]
        [TemplateFilesDataAttribute]
        public void CopyTemplateData_Test_With_AllTempaltes(string path)
        {
            using (var targetDB = new DAL())
            using (var tmpltFile = new DAL(path))
            {
                Output.WriteLine(path);
                tmpltFile.ExecuteScalar<int>("SELECT 1;");
                WinForms.CruiseWizard.CruiseWizardPresenter.CopyTemplateData(tmpltFile, targetDB, false, out var treeDefaults);

                treeDefaults.Should().NotBeEmpty();
            }
        }
    }
}