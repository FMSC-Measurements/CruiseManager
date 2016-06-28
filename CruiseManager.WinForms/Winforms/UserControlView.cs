using CruiseManager.Core.ViewModel;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms
{
    public class UserControlView : UserControl, IView
    {
        public virtual IPresentor ViewPresenter
        {
            get; protected set;
        }

        //#region abstract methods
        //public virtual void EndEdits()
        //{ }
        //#endregion

        #region message box methods

        public bool AskOKOrCancel(string message, string caption, bool defaultOption)
        {
            if (this.InvokeRequired)
            {
                return (bool)this.Invoke(new Func<string, string, bool, bool>(this.AskOKOrCancel),
                    message, caption, defaultOption);
            }
            else
            {
                MessageBoxDefaultButton defaultBtn = (defaultOption == true) ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2;

                DialogResult result = MessageBox.Show(this.TopLevelControl,
                    message, caption,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    defaultBtn);
                switch (result)
                {
                    case DialogResult.OK: { return true; }
                    case DialogResult.Cancel: { return false; }
                    default: { return defaultOption; }
                }
            }
        }

        public bool? AskYesNoCancel(string message, string caption)
        {
            return AskYesNoCancel(message, caption, true);
        }

        public bool? AskYesNoCancel(string message, string caption, bool? defaultOption)
        {
            if (this.InvokeRequired)
            {
                return (bool?)this.Invoke(new Func<string, string, bool?, bool?>(this.AskYesNoCancel),
                    message, caption, defaultOption);
            }
            else
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
        }

        public void ShowMessage(string message)
        {
            this.ShowMessage(message, null);
        }

        public void ShowMessage(string message, string caption)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string>(this.ShowMessage), message, caption);
            }
            else
            {
                MessageBox.Show(this, message, caption);
            }
        }

        public void ShowErrorMessage(String shortDiscription, String longDiscription)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string>(this.ShowErrorMessage), shortDiscription, longDiscription);
            }
            else
            {
                using (ErrorMessageDialog dialog = new ErrorMessageDialog())
                {
                    dialog.ShowDialog(this, shortDiscription, longDiscription);
                }
            }
        }

        #endregion message box methods

        public void ShowWaitCursor()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.ShowWaitCursor));
            }
            else
            {
                this.TopLevelControl.Cursor = Cursors.WaitCursor;
            }
        }

        public void ShowDefaultCursor()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.ShowDefaultCursor));
            }
            else
            {
                this.TopLevelControl.Cursor = Cursors.Default;
            }
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