using CruiseManager.WinForms.App;
using FluentAssertions;
using Xunit;

namespace CruiseManager.WinForms.Test
{
    public class SetupServiceTest
    {
        [Fact]
        public void GetCruiseMethodsTest()
        {
            var setupServ = new SetupService();
            var cruiseMethods = setupServ.GetCruiseMethods();

            cruiseMethods.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetLogFieldSetupsTest()
        {
            var setupServ = new SetupService();

            var logFields = setupServ.GetLogFieldSetups();
            logFields.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetLoggingMethodsTest()
        {
            var setupServ = new SetupService();

            var logMeths = setupServ.GetLoggingMethods();
            logMeths.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetProductCodesTest()
        {
            var setupServ = new SetupService();

            var prodCodes = setupServ.GetProductCodes();
            prodCodes.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetRegionsTest()
        {
            var setupServ = new SetupService();

            var regions = setupServ.GetRegions();
            regions.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetTreeFieldSetupsTest()
        {
            var setupServ = new SetupService();

            var treeFields = setupServ.GetTreeFieldSetups();
            treeFields.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetUOMCodesTest()
        {
            var setupServ = new SetupService();

            var uomCodes = setupServ.GetUOMCodes();
            uomCodes.Should().NotBeNullOrEmpty();
        }
    }
}