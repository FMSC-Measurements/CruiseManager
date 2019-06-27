using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public partial class FormSupervisorLogin : Form
    {
        IApplicationState ApplicationState { get; }

        protected FormSupervisorLogin()
        {
            InitializeComponent();
        }

        public FormSupervisorLogin(IApplicationState applicationState)
            : this()
        {
            ApplicationState = applicationState;
        }

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
                    ApplicationState.InSupervisorMode = true;
                    MessageBox.Show("Success");
                }
                else
                {
                    ApplicationState.InSupervisorMode = false;
                    MessageBox.Show("Password invalid");
                }
            }
        }
    }
}