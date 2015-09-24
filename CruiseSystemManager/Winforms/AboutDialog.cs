using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.Winforms
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            this._versionNumLBL.Text = CruiseManager.Core.Constants.Version.VersionID;
        }

        private void _login_Click(object sender, EventArgs e)
        {
            FormSupervisorLogin view = new FormSupervisorLogin();
            view.Owner = this;
            view.ShowDialog();
        }


    }
}
