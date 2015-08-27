using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSM
{
    public partial class EditorView : Form, IPagingView
    {
        public EditorView()
        {
            InitializeComponent();
        }

        #region IPagingView Members

        public void Display(string Name)
        {
            throw new NotImplementedException();
        }

        public void Display(IPage Page)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
