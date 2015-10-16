using CruiseManager.Core.App;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.WinForms.App
{
    public class SetupService : SetupServiceBase
    {


        public SetupService() : base()
        { }


        protected override void ExtractStream(string fileName, Stream stream)
        {
            using (ZipFile zip = ZipFile.Read(Path))
            {
                if (zip.ContainsEntry(fileName) == false) { return; }
                ZipEntry entry = zip[fileName];
                entry.Extract(stream);
                stream.Position = 0;   // HACK for some reason the position is set to the end
            }
        }

        protected override void SaveStream(string fileName, MemoryStream stream)
        {
            using (ZipFile zip = ZipFile.Read(Path))
            {
                stream.Position = 0;
                var buff = stream.GetBuffer();
                if (zip.ContainsEntry(fileName) == false)
                {
                    zip.AddEntry(fileName, buff);
                }
                else
                {
                    zip.UpdateEntry(fileName, buff);
                }
                zip.Save();
            }
        }
    }
}
