using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSM.UI
{
    public partial class FormSupervisorLogin : Form
    {
        public FormSupervisorLogin()
        {
            InitializeComponent();
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
                if (_pwTB.Text == Utility.R.Strings.SUPERVISOR_LOGIN)
                {
                    ApplicationState.GetHandle().InSupervisorMode = true;
                    MessageBox.Show("Success");
                }
                else
                {
                    ApplicationState.GetHandle().InSupervisorMode = false;
                    MessageBox.Show("Password invalid");
                }
            }
        }
    }
}
