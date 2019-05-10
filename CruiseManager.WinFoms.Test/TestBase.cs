using System.IO;
using Xunit.Abstractions;

namespace CruiseManager.WinForms.Test
{
    public abstract class TestBase
    {
        protected readonly ITestOutputHelper Output;
        private string _testTempPath;

        public TestBase(ITestOutputHelper output)
        {
            Output = output;

            var testTempPath = TestTempPath;
            TouchDir(testTempPath);
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