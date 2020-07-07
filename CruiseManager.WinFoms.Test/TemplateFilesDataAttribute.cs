using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace CruiseManager.Winforms.Test
{
    public class TemplateFilesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var curDir = Directory.GetCurrentDirectory();
            var templatesDir = Path.Combine(curDir, "TemplateFiles");

            return Directory.GetFiles(templatesDir)
                .Select(x => new[] { x });
        }
    }
}
