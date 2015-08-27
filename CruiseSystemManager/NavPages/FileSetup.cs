using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseSystemManager.NavPages
{
    public partial class FileSetup : UserControl
    {
        public CSMHome Owner { get; set; }//the form that our control is being displayed in

        public FileSetup(CSMHome Owner)
        {
            InitializeComponent();
            this.Owner = Owner;
        }

        private void menuRow3_ButtonClick(object sender, EventArgs e)
        {
            Owner.GotoCoConverterPage();
        }

        private void menuRow1_ButtonClick(object sender, EventArgs e)
        {
            Owner.StartCruiseWiz();
        }



    }
}
