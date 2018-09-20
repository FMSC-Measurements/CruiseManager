using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CruiseManager.Test
{
    public class TestBase
    {
        protected ITestOutputHelper Output { get; }

        public TestBase(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}
