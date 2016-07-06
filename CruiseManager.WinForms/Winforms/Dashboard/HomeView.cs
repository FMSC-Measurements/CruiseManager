using CruiseManager.Core.App;
using CruiseManager.Core.ViewInterfaces;

namespace CruiseManager.WinForms.Dashboard
{
    public partial class HomeView : UserControlView, IHomeView
    {
        public HomeView(ApplicationControllerBase applicationController)
        {
            InitializeComponent();

            //this.UserCommands = new ViewCommand[]
            //{
            //    this.ApplicationController.MakeViewCommand("Open File", this.ApplicationController.OpenFile),
            //    this.ApplicationController.MakeViewCommand("Create New Cruise", this.ApplicationController.CreateNewCruise)
            //};
        }
    }
}