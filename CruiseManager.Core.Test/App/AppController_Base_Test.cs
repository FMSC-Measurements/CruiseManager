using CruiseManager.Core.App;
using Moq;
using Xunit.Abstractions;

namespace CruiseManager.Test.App
{
    public class AppController_Base_Test : TestBase
    {
        public AppController_Base_Test(ITestOutputHelper output) : base(output)
        {
            var mock = new Mock<ApplicationControllerBase>();

            AppControllerMock = mock;
        }

        public Mock<ApplicationControllerBase> AppControllerMock { get; }
    }
}