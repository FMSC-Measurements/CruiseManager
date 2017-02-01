﻿using CruiseManager.Core.App;
using System;
using System.Reflection;
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
            this._versionNumLBL.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void _login_Click(object sender, EventArgs e)
        {
            FormSupervisorLogin view = new FormSupervisorLogin(this.ApplicationController);
            view.ShowDialog(this);
        }
    }
}