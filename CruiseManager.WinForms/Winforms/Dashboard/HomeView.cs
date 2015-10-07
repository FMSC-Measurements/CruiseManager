using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CruiseManager.Core.App;
using CruiseManager.Core;
using CruiseManager.App;
using CruiseManager.WinForms;

namespace CruiseManager.Winforms.Dashboard
{
    public partial class HomeView : UserControlView
    {
        public HomeView(ApplicationController applicationController )
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
