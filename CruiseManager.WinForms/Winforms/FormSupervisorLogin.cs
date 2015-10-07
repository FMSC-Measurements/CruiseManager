using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
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
    public partial class FormSupervisorLogin : Form
    {
        public FormSupervisorLogin(ApplicationController applicationController)
        {
            this.ApplicationController = applicationController;
            InitializeComponent();
        }

        protected ApplicationController ApplicationController { get; set; }


        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult != DialogResult.Cancel && String.IsNullOrEmpty(_pwTB.Text))
            {
                e.Cancel = true;
            }
            else if (DialogResult == DialogResult.OK && !String.IsNullOrEmpty(_pwTB.Text))
            {
                if (_pwTB.Text == Strings.SUPERVISOR_LOGIN)
                {
                    ApplicationController.InSupervisorMode = true;
                    MessageBox.Show("Success");
                }
                else
                {
                    ApplicationController.InSupervisorMode = false;
                    MessageBox.Show("Password invalid");
                }
            }
        }
    }
}
