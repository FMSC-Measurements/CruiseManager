using CruiseManager.Core.App;
using System;
using System.IO;
using System.Reflection;

namespace CruiseManager.WinForms.App
{
    public class SetupService : SetupServiceBase
    {
        public string STPinfoDir { get; }

        public SetupService() : base()
        {
            var codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var codeBasePath = Uri.UnescapeDataString(codeBaseUri);
            var directory = System.IO.Path.GetDirectoryName(codeBasePath);

            STPinfoDir = System.IO.Path.Combine(directory, "STPinfo");
        }

        protected override Stream GetStream(string fileName)
        {
            var path = Path.Combine(STPinfoDir, fileName);
            var stream = System.IO.File.OpenRead(path);
            stream.Position = 0;
            return stream;
        }
    }
}