using CruiseManager.Core.App;
using Microsoft.AppCenter.Crashes;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public partial class AboutDialog : Form
    {
        int _clickCount = 0;
        protected IApplicationController ApplicationController { get; set; }

        public AboutDialog(IApplicationController applicationController)
        {
            ApplicationController = applicationController;
            InitializeComponent();
            this._versionNumLBL.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void _login_Click(object sender, EventArgs e)
        {
            FormSupervisorLogin view = new FormSupervisorLogin(this.ApplicationController);
            view.ShowDialog(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var clickCount = _clickCount++;
            if(clickCount % 6 == 5)
            {
                Crashes.GenerateTestCrash();
            }
        }
    }
}