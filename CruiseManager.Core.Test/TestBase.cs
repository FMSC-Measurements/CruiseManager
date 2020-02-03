using CruiseDAL;
using CruiseManager.Core.App;
using Moq;
using System.IO;
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

        public TestBase(ITestOutputHelper output)
        {
            Output = output;

            var testTempPath = TestTempPath;
            TouchDir(testTempPath);

            UserSettingsMock = new Mock<IUserSettings>();

            AppControllerMock = new Mock<IApplicationController>();

            AppControllerMock
                .Setup(x => x.UserSettings)
                .Returns(() => UserSettings);
            
        }

        public string TestTempPath
        {
            get
            {
                return _testTempPath ?? (_testTempPath = Path.Combine(Path.GetTempPath(), "TestTemp", this.GetType().FullName));
            }
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