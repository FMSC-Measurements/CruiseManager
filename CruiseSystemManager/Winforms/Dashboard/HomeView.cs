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

namespace CSM.Winforms.Dashboard
{
    public partial class HomeView : UserControl, IView
    {
        public HomeView(ApplicationController applicationController )
        {
            this.ApplicationController = applicationController;
            InitializeComponent();

            this.NavCommands = new ViewCommand[]
            {
                this.ApplicationController.MakeViewCommand("Open File", this.ApplicationController.OpenFile),
                this.ApplicationController.MakeViewCommand("Create New Cruise", this.ApplicationController.CreateNewCruise)
            };

        }


        protected ApplicationController ApplicationController { get; set; }

        public IPresentor ViewPresenter { get { return null; } }

        public IEnumerable<ViewCommand> NavCommands
        {
            get;
            protected set;           
        }

        public IEnumerable<ViewCommand> UserCommands
        {
            get;
            protected set;            
        }
    }
}
