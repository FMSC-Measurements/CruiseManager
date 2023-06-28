using CruiseDAL;
using CruiseManager.WinForms.App;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CruiseManager.Winforms.Test.App
{
    public class WindowPresenterWinForms_Tests
    {
        [Fact]
        public void RealignTreeSpecies()
        {
            using(var db = new DAL())
            {
                WindowPresenterWinForms.RealignTreeSpecies(db, 0);
            }
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("something", "something")]
        [InlineData("something ", "something")]
        [InlineData("some thing ", "some thing")]
        [InlineData(@"some/thing", "something")]
        [InlineData(@"some*thing", "something")]
        [InlineData(@"some\thing", "something")]
        [InlineData(@"some[]thing", "something")]
        [InlineData(@"some()thing", "something")]
        public void SanatizePathPart(string part, string expected)
        {
            var result = WindowPresenterWinForms.SanitizePathPart(part);
            result.Should().Be(expected);
        }
    }
}
