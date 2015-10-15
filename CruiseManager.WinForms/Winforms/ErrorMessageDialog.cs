using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.WinForms
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


        public void ShowDialog(IWin32Window owner, String shortMessage, String detailedMessage)
        {
            this.Text = "Errors";
            this._textView.Text = detailedMessage;
            this._shortMessage.Text = shortMessage;
            this.ShowDialog(owner);
        }

        //public void ShowDialog(ICollection<IDataErrorInfo> listObj, String format, String caption)
        //{
        //    this.Text = caption;
        //    String[] lines = new String[listObj.Count];
        //    int counter = 0;
        //    foreach(IDataErrorInfo eInfo in listObj)
        //    {
        //        String objDesc;
        //        if (eInfo is IFormattable)
        //        {
        //            objDesc = ((IFormattable)eInfo).ToString(format, null);
        //        }
        //        else
        //        {
        //            objDesc = eInfo.ToString();
        //        }
        //        lines[counter] = objDesc + ": " + eInfo.Error;
        //    }
        //    this._textView.Lines = lines;

        //    this.ShowDialog();
        //}
    }
}
