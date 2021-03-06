﻿using CruiseManager.Core.App;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public partial class SettingsView : UserControl
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

        protected void InitializeView(WindowPresenter windowPresenter)
        {
            this.WindowPresenter = windowPresenter;
        }

        public WindowPresenter WindowPresenter { get; set; }

        //public NavOption[] NavOptions
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public NavOption[] ViewActions
        //{
        //    get { throw new NotImplementedException(); }
        //}

        #endregion IView Members
    }
}