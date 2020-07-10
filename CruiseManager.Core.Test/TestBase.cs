using CruiseDAL;
using CruiseManager.Core.App;
using Moq;
using System;
using System.IO;
using System.Reflection;
using Xunit.Abstractions;

namespace CruiseManager.Test
{
    public abstract class TestBase
    {
        protected readonly ITestOutputHelper Output;
        private string _testTempPath;
        protected Mock<IApplicationController> AppControllerMock { get; set; }
        protected Mock<IUserSettings> UserSettingsMock { get; set; }

        protected IApplicationController AppController => AppControllerMock.Object;
        protected IUserSettings UserSettings => UserSettingsMock.Object;

        public string TestFilesDir { get; }

        public string ProjectOutputDir { get; }

        public TestBase(ITestOutputHelper output)
        {
            Output = output;

            var testTempPath = TestTempPath = 
                Path.Combine(Path.GetTempPath(), "TestTemp", this.GetType().FullName);

            TouchDir(testTempPath);

            UserSettingsMock = new Mock<IUserSettings>();

            AppControllerMock = new Mock<IApplicationController>();

            AppControllerMock
                .Setup(x => x.UserSettings)
                .Returns(() => UserSettings);

            var codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var codeBasePath = Uri.UnescapeDataString(codeBaseUri);
            var projectOutputDir = ProjectOutputDir = System.IO.Path.GetDirectoryName(codeBasePath);
            TestFilesDir = Path.Combine(projectOutputDir, "TestFiles");
        }

        public string TestTempPath { get; }

        public string GetCleanFile(string fileName)
        {
            var filePath = Path.Combine(TestTempPath, fileName);

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return filePath;
        }

        public void TouchDir(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public void CleanUpFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}