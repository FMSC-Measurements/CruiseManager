using CruiseManager.Core;
using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public class UserControlView : UserControl, IView
    {
        public IPresentor ViewPresenter
        {
            get; protected set; 
        }


        //#region abstract methods
        //public virtual void EndEdits()
        //{ }
        //#endregion

        #region message box methods
        public bool? AskYesNoCancel(string message, string caption)
        {
            return AskYesNoCancel(message, caption, true);
        }

        public bool? AskYesNoCancel(string message, string caption, bool? defaultOption)
        {
            MessageBoxDefaultButton defaultButton;
            switch (defaultOption)
            {
                case true:
                    { defaultButton = MessageBoxDefaultButton.Button1; break; }
                case false:
                    { defaultButton = MessageBoxDefaultButton.Button2; break; }
                case null:
                    { defaultButton = MessageBoxDefaultButton.Button3; break; }
                default:
                    { defaultButton = MessageBoxDefaultButton.Button1; break; }
            }
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, defaultButton);
            return (result == DialogResult.Cancel) ? (Nullable<bool>)null : (result == DialogResult.Yes) ? true : false;
        }

        public void ShowMessage(string message)
        {
            this.ShowMessage(message, null);
        }

        public void ShowMessage(string message, string caption)
        {
            MessageBox.Show(this, message, caption);
        }

        public void ShowErrorMessage(String shortDiscription, String longDiscription)
        {
            using (ErrorMessageDialog dialog = new ErrorMessageDialog())
            {
                dialog.ShowDialog(this, shortDiscription, longDiscription);
            }
        }


        #endregion


        public void ShowWaitCursor()
        {
            this.Cursor = Cursors.WaitCursor;
        }

        public void ShowDefaultCursor()
        {
            this.Cursor = Cursors.Default;
        }

        //public IEnumerable<ViewCommand> NavCommands
        //{
        //    get; protected set;
        //}

        //public IEnumerable<ViewCommand> UserCommands
        //{
        //    get; protected set;
        //}
    }
}
