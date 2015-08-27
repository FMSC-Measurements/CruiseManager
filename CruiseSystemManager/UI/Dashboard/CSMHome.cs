using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSM.NavPages;

namespace CSM
{
    public partial class CSMHomeView : Form, IPagingView
    {
        private FileSetup fileSetupPage = null;
        private COConverterPage coConverterPage = null;

        public CSMHomePresenter Presenter { get; set; }
        

        #region Ctor
        public CSMHomeView(CSMHomePresenter presenter)
        {
            Presenter = presenter; 
            InitializeComponent();
            InitializePages();
        }
        #endregion 

        public void InitializePages()
        {
            fileSetupPage = new FileSetup(this, Presenter);
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
            Presenter.Shutdown();
        }
        #endregion



        public void GotoCoConverterPage()
        {
            ContentHost.Display(coConverterPage as Control);
        }


        #region IPagingView Members

        public void Display(string Name)
        {
            this.ContentHost.Display(Name);
        }

        public void Display(IPage Page)
        {
            this.ContentHost.Display(Page);
        }

        #endregion
    }


}
