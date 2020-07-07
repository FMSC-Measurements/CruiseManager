using System;
using System.IO;
using System.Reflection;
using Xunit.Abstractions;

namespace CruiseManager.WinForms.Test
{
    public abstract class TestBase
    {
        protected ITestOutputHelper Output { get; }
        public string TestFilesDir { get; }
        public string ProjectOutputDir { get; }
        public string TestTempPath { get; }

        public TestBase(ITestOutputHelper output)
        {
            Output = output;

            var testTempPath = TestTempPath =
                Path.Combine(Path.GetTempPath(), "TestTemp", this.GetType().FullName);

            TouchDir(testTempPath);

            var codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var codeBasePath = Uri.UnescapeDataString(codeBaseUri);
            var projectOutputDir = ProjectOutputDir = System.IO.Path.GetDirectoryName(codeBasePath);
            TestFilesDir = Path.Combine(projectOutputDir, "TestFiles");
        }

        public string GetCleanFile(string fileName)
        {
            var filePath = Path.Combine(TestTempPath, fileName);

            if (File.Exists(filePath))
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