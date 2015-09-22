using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSM.Winforms
{
    public partial class SettingsView : UserControl, IView
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void _BTN_browseDefaultCruiseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog(this);


            }
        }

        private void _BTN_browseTemplateFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowDialog(this);
            }
        }

        public void SaveSettings()
        {

        }

        public void RevertSettings()
        {

        }

        #region IView Members
        protected void InitializeView(IWindowPresenter windowPresenter)
        {
            this.WindowPresenter = windowPresenter;
        }

        public IWindowPresenter WindowPresenter { get; set; }

        public NavOption[] NavOptions
        {
            get { throw new NotImplementedException(); }
        }

        public NavOption[] ViewActions
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
