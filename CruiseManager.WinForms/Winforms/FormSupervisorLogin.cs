using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using Microsoft.AppCenter.Analytics;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public partial class FormSupervisorLogin : Form
    {
        public FormSupervisorLogin(IApplicationController applicationController)
        {
            this.ApplicationController = applicationController;
            InitializeComponent();
        }

        protected IApplicationController ApplicationController { get; set; }

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
                    Analytics.TrackEvent(AnalyticsEvents.SUPERVISORLOGIN_SUCCESS);
                    MessageBox.Show("Success");
                }
                else
                {
                    ApplicationController.InSupervisorMode = false;
                    Analytics.TrackEvent(AnalyticsEvents.SUPERVISORLOGIN_FAIL);
                    MessageBox.Show("Password invalid");
                }
            }
        }
    }
}