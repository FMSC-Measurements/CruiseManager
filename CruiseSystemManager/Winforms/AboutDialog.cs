using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSM.Logic;

namespace CSM.Winforms
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            this._versionNumLBL.Text = WindowPresenter.Version;
        }

        private void _login_Click(object sender, EventArgs e)
        {
            FormSupervisorLogin view = new FormSupervisorLogin();
            view.Owner = this;
            view.ShowDialog();
        }


    }
}
