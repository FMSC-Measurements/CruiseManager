using CruiseManager.Core.App;
using CruiseManager.Services;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public partial class AboutDialog : Form
    {
        public INavigationService NavigationService { get; }

        public AboutDialog(INavigationService navigationService)
        {
            NavigationService = navigationService;
            InitializeComponent();
            this._versionNumLBL.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void _login_Click(object sender, EventArgs e)
        {
            NavigationService.ShowDialog(typeof(FormSupervisorLogin));
        }
    }
}