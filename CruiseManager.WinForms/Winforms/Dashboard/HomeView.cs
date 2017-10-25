using CruiseManager.Core.App;
using CruiseManager.Core.ViewInterfaces;
using System.Runtime.InteropServices;

namespace CruiseManager.WinForms.Dashboard
{
    public partial class HomeView : UserControlView, IHomeView
    {
        public HomeView(ApplicationControllerBase applicationController)
        {
            InitializeComponent();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            versionNumber.Text = $"v.{version.Major}.{version.Minor:D2}.{version.Build:D2}";

            //this.UserCommands = new ViewCommand[]
            //{
            //    this.ApplicationController.MakeViewCommand("Open File", this.ApplicationController.OpenFile),
            //    this.ApplicationController.MakeViewCommand("Create New Cruise", this.ApplicationController.CreateNewCruise)
            //};
        }

        private void HomeView_Load(object sender, System.EventArgs e)
        {

        }
    }
}