using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.Winforms
{
    /// <summary>
    /// Error dialog that can display many lines 
    /// </summary>
    public partial class ErrorMessageDialog : Form
    {
        public ErrorMessageDialog()
        {
            InitializeComponent();
        }


        public void ShowDialog(String message, String caption)
        {
            this.Text = caption;
            this._textView.Text = message;
            this.ShowDialog();
        }

        public void ShowDialog(ICollection<IDataErrorInfo> listObj, String format, String caption)
        {
            this.Text = caption;
            String[] lines = new String[listObj.Count];
            int counter = 0;
            foreach(IDataErrorInfo eInfo in listObj)
            {
                String objDesc;
                if (eInfo is IFormattable)
                {
                    objDesc = ((IFormattable)eInfo).ToString(format, null);
                }
                else
                {
                    objDesc = eInfo.ToString();
                }
                lines[counter] = objDesc + ": " + eInfo.Error;
            }
            this._textView.Lines = lines;

            this.ShowDialog();
        }
    }
}
