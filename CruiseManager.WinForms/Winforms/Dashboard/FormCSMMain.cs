using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using CruiseManager.WinForms.CommandModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Dashboard
{
    public partial class FormCSMMain : Form, MainWindow
    {
        public FormCSMMain(ApplicationControllerBase applicationController)
        {
            this.ApplicationController = applicationController;
            InitializeComponent();

            this.ApplicationController.OpenFileCommand.BindTo(this.openToolStripMenuItem);
            this.ApplicationController.CreateNewCruiseCommand.BindTo(this.newToolStripMenuItem);
            this.ApplicationController.SaveCommand.BindTo(this.saveToolStripMenuItem);
            this.ApplicationController.SaveAsCommand.BindTo(this.saveAsToolStripMenuItem);

            var _aboutClickCommand = new BindableActionCommand("About", this.ApplicationController.WindowPresenter.ShowAboutDialog);
            _aboutClickCommand.BindTo(this.aboutToolStripMenuItem);
        }

        protected ApplicationControllerBase ApplicationController { get; set; }

        protected Panel ViewContentPanel { get { return this._viewContentPanel; } }
        protected Panel ViewNavPanel { get { return this._viewNavPanel; } }

        public void ClearActiveView()
        {
            //clear previous content from main view content panel
            foreach (Control c in this.ViewContentPanel.Controls)
            {
                c.Dispose();
            }
            this.ViewContentPanel.Controls.Clear();
        }

        public void SetActiveView(object view)
        {
            Control cView = view as Control;
            System.Diagnostics.Debug.Assert(cView != null);

            SetActiveView(cView);
        }

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

        public void SetUserCommands(IEnumerable<BindableCommand> userCommands)
        {
            this._userCommandPanel.SuspendLayout();
            this._userCommandPanel.Controls.Clear();
            if (userCommands == null || userCommands.Count() == 0) { return; }
            using (Graphics g = CreateGraphics())
            {
                foreach (BindableCommand command in userCommands)
                {
                    Button newButton = new UserCommandButton();

                    newButton.Dock = System.Windows.Forms.DockStyle.Bottom;
                    this._userCommandPanel.Controls.Add(newButton);

                    command.BindTo(newButton);
                }
            }
            this._userCommandPanel.ResumeLayout();
        }

        public void SetNavCommands(IEnumerable<BindableCommand> navCommands)
        {
            this._viewNavPanel.SuspendLayout();
            this._viewNavPanel.Controls.Clear();
            if (navCommands == null) { return; }
            using (Graphics g = CreateGraphics())
            {
                foreach (BindableCommand command in navCommands.Reverse())
                {
                    Panel spacer = new Panel()
                    {
                        Height = 1,
                        Dock = DockStyle.Top,
                        BackColor = this.BackColor
                    };

                    this._viewNavPanel.Controls.Add(spacer);

                    Button newButton = new NavigationButton();
                    newButton.Dock = System.Windows.Forms.DockStyle.Top;
                    this._viewNavPanel.Controls.Add(newButton);

                    command.BindTo(newButton);
                }
            }
            this._viewNavPanel.ResumeLayout();
        }

        public void DockView(UserControl view)
        {
            this.ViewContentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            this.ViewContentPanel.Controls.Add(view);
        }

        private void _recentFilesMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string path = e.ClickedItem.ToolTipText as string;
            if (!string.IsNullOrEmpty(path))
            {
                ApplicationController.OpenFile(path);
            }
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            _recentFilesMenu.Items.Clear();
            ToolStripMenuItem[] items = (from String path in ApplicationController.AppState.RecentFiles
                                         select new ToolStripMenuItem(Path.GetFileName(path)) { ToolTipText = path, }).ToArray();

            _recentFilesMenu.Items.AddRange(items);
        }
    }
}