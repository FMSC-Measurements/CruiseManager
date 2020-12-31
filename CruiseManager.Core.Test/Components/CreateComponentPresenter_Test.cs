using CruiseManager.Core.Components;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components
{
    public class CreateComponentPresenter_Test : TestBase
    {
        public CreateComponentPresenter_Test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("something.m.cruise", 1, "something.1.cruise")]
        [InlineData("something.M.cruise", 1, "something.1.cruise")]
        [InlineData("something.M.CRUISE", 1, "something.1.cruise")]
        public void GetCompFileName(string masterFileName, int compNum, string expected)
        {
            CreateComponentPresenter.GetCompFileName(masterFileName, compNum).Should().Be(expected);
        }

        [Theory]
        [InlineData("something.cruise", "something.M.cruise")]
        [InlineData("something.CRUISE", "something.M.cruise")]
        [InlineData("something.CRUISE ", "something.M.cruise")]

        [InlineData("something.m.cruise", "something.m.cruise")]
        [InlineData("something.M.CRUISE", "something.M.CRUISE")]
        [InlineData("something.M.CRUISE ", "something.M.CRUISE")]
        public void GetMasterPath(string filePath, string expected)
        {
            CreateComponentPresenter.GetMasterPath(filePath).Should().Be(expected);
        }
    }
}
