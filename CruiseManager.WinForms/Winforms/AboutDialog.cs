using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public partial class AboutDialog : Form
    {
        protected ApplicationControllerBase ApplicationController { get; set; }

        public AboutDialog(ApplicationControllerBase applicationController)
        {
            ApplicationController = applicationController;
            InitializeComponent();
            this._versionNumLBL.Text = CruiseManager.Core.Constants.Version.VersionID;
        }

        private void _login_Click(object sender, EventArgs e)
        {
            FormSupervisorLogin view = new FormSupervisorLogin(this.ApplicationController);
            view.ShowDialog(this);
        }


    }
}
