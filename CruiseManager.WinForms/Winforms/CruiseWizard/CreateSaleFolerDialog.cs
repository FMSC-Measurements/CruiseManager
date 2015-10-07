using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class CreateSaleFolerDialog : Form
    {
        public CreateSaleFolerDialog()
        {
            InitializeComponent();
        }

        public bool RememberSelection
        {
            get
            {
                return this.checkBox1.Checked;
            }
        }
    }
}
