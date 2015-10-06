using CruiseManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CruiseManager.Core.CommandModel;
using CruiseManager.Winforms.Dashboard;
using System.Drawing;

namespace CruiseManager.Winforms
{
    public class NavigationView : UserControl, INavigationView, IHostView
    {
        private Panel _viewContentPanel;
        private Panel _leftCommandPanel;
        private Panel _viewNavPanel;
        private Panel _userCommandPanel;

        private IView _activeChildView;

        protected Panel ViewContentPanel { get { return this._viewContentPanel; } }
        protected Panel ViewNavPanel { get { return this._viewNavPanel; } }

        public IEnumerable<ViewNavigateCommand> NavCommands
        {
            get; set;
        }

        public IPresentor ViewPresenter
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IView ActiveChildView
        {
            get
            {
                return _activeChildView;
            }

            set
            {
                if(_activeChildView == value) { return; }
                _activeChildView = value;
                this.SetActiveView(value);
            }
        }

        public void ClearActiveView()
        {
            //clear previous content from main view content panel 
            foreach (Control c in this.ViewContentPanel.Controls)
            {
                c.Dispose();
            }
            this.ViewContentPanel.Controls.Clear();
        }

        //public void SetActiveView(object view)
        //{
        //    Control cView = view as Control;
        //    System.Diagnostics.Debug.Assert(cView != null);


        //    SetActiveView(cView);
        //}

        public void SetActiveView(IView view)
        {
            Control cView = view as Control;
            System.Diagnostics.Debug.Assert(cView != null);


            SetActiveView(cView);
        }

        public void SetActiveView(Control cView)
        {
            ClearActiveView();


            if (cView is IView)
            {
                //this.SetNavCommands(((IView)cView).NavCommands);
                //this.SetUserCommands(((IView)cView).UserCommands);
            }

            //dock new view 
            cView.Dock = DockStyle.Fill;
            cView.Parent = this.ViewContentPanel;
        }

        //public void DockView(UserControl view)
        //{
        //    this.ViewContentPanel.Controls.Clear();
        //    view.Dock = DockStyle.Fill;
        //    this.ViewContentPanel.Controls.Add(view);
        //}

        public void SetNavCommands(IEnumerable<ViewCommand> navCommands)
        {
            this._viewNavPanel.SuspendLayout();
            this._viewNavPanel.Controls.Clear();
            if (navCommands == null) { return; }
            using (Graphics g = CreateGraphics())
            {
                foreach (ViewCommand command in navCommands.Reverse())
                {
                    Button newButton = new NavigationButton();
                    newButton.Dock = System.Windows.Forms.DockStyle.Top;
                    this._viewNavPanel.Controls.Add(newButton);

                    command.BindTo(newButton);

                    Panel spacer = new Panel()
                    {
                        Height = 1,
                        Dock = DockStyle.Top,
                        BackColor = this.BackColor
                    };

                    this._viewNavPanel.Controls.Add(spacer);
                }
            }
            this._viewNavPanel.ResumeLayout();
        }

        public void SetUserCommands(IEnumerable<ViewCommand> userCommands)
        {
            this._userCommandPanel.SuspendLayout();
            this._userCommandPanel.Controls.Clear();
            if (userCommands == null || userCommands.Count() == 0) { return; }
            using (Graphics g = CreateGraphics())
            {
                foreach (ViewCommand command in userCommands)
                {
                    Button newButton = new UserCommandButton();

                    newButton.Dock = System.Windows.Forms.DockStyle.Bottom;
                    this._userCommandPanel.Controls.Add(newButton);

                    command.BindTo(newButton);
                }
            }
            this._userCommandPanel.ResumeLayout();
        }

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


        public void ShowWaitCursor()
        {
            this.Cursor = Cursors.WaitCursor;
        }

        public void ShowDefaultCursor()
        {
            this.Cursor = Cursors.Default;
        }

        private void InitializeComponent()
        {
            this._viewContentPanel = new System.Windows.Forms.Panel();
            this._leftCommandPanel = new System.Windows.Forms.Panel();
            this._viewNavPanel = new System.Windows.Forms.Panel();
            this._userCommandPanel = new System.Windows.Forms.Panel();
            this._leftCommandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _viewContentPanel
            // 
            this._viewContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._viewContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._viewContentPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._viewContentPanel.Location = new System.Drawing.Point(151, 0);
            this._viewContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this._viewContentPanel.Name = "_viewContentPanel";
            this._viewContentPanel.Size = new System.Drawing.Size(439, 445);
            this._viewContentPanel.TabIndex = 4;
            // 
            // _leftCommandPanel
            // 
            this._leftCommandPanel.BackColor = System.Drawing.Color.Gray;
            this._leftCommandPanel.Controls.Add(this._viewNavPanel);
            this._leftCommandPanel.Controls.Add(this._userCommandPanel);
            this._leftCommandPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._leftCommandPanel.Location = new System.Drawing.Point(0, 0);
            this._leftCommandPanel.Margin = new System.Windows.Forms.Padding(0);
            this._leftCommandPanel.Name = "_leftCommandPanel";
            this._leftCommandPanel.Size = new System.Drawing.Size(151, 445);
            this._leftCommandPanel.TabIndex = 5;
            // 
            // _viewNavPanel
            // 
            this._viewNavPanel.BackColor = System.Drawing.Color.Transparent;
            this._viewNavPanel.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::CruiseManager.Properties.Settings.Default, "App_NavFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._viewNavPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._viewNavPanel.Font = global::CruiseManager.Properties.Settings.Default.App_NavFont;
            this._viewNavPanel.Location = new System.Drawing.Point(0, 0);
            this._viewNavPanel.Margin = new System.Windows.Forms.Padding(0);
            this._viewNavPanel.MinimumSize = new System.Drawing.Size(150, 4);
            this._viewNavPanel.Name = "_viewNavPanel";
            this._viewNavPanel.Size = new System.Drawing.Size(151, 445);
            this._viewNavPanel.TabIndex = 4;
            // 
            // _userCommandPanel
            // 
            this._userCommandPanel.AutoSize = true;
            this._userCommandPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._userCommandPanel.BackColor = System.Drawing.Color.Transparent;
            this._userCommandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._userCommandPanel.Location = new System.Drawing.Point(0, 445);
            this._userCommandPanel.Margin = new System.Windows.Forms.Padding(0);
            this._userCommandPanel.Name = "_userCommandPanel";
            this._userCommandPanel.Size = new System.Drawing.Size(151, 0);
            this._userCommandPanel.TabIndex = 0;
            // 
            // NavigationView
            // 
            this.Controls.Add(this._viewContentPanel);
            this.Controls.Add(this._leftCommandPanel);
            this.Name = "NavigationView";
            this.Size = new System.Drawing.Size(590, 445);
            this._leftCommandPanel.ResumeLayout(false);
            this._leftCommandPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
