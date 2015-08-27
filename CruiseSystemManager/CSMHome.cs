using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSystemManager.NavPages;

namespace CruiseSystemManager
{
    public partial class CSMHome : Form
    {
        public CSMHome()
        {
            InitializeComponent();
            InitializePages();
        }


        private FileSetup fileSetupPage = null;
        private COConverterPage coConverterPage = null;

        public void InitializePages()
        {
            fileSetupPage = new FileSetup(this);
            ContentHost.Add(fileSetupPage);
            coConverterPage = new COConverterPage();
            ContentHost.Add(coConverterPage);

            ContentHost.Display(fileSetupPage);
        }

        #region click events 
        private void fileSetup_Click(object sender, EventArgs e)
        {
            ContentHost.Display(fileSetupPage);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {

        }

        private void ProgramsButton_Click(object sender, EventArgs e)
        {

        }

        private void Help_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Shutdown();
        }
        #endregion

        public void StartCruiseWiz()
        {
            CruiseWizard wiz = new CruiseWizard();
            wiz.Show();
        }

        public void GotoCoConverterPage()
        {
            ContentHost.Display(coConverterPage);
        }

        public void Shutdown()
        {
            this.Close();
        }



     
    }


}
