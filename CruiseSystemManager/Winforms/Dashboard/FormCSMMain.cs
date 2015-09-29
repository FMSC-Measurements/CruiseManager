using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.App;
using CruiseManager.App;
using CruiseManager.Core;

namespace CruiseManager.Winforms.Dashboard
{
    public partial class FormCSMMain : Form, MainWindow 
    {
        
        public FormCSMMain(WindowPresenter windowPresenter, ApplicationController applicationController)
        {
            this.WindowPresenter = windowPresenter;
            this.ApplicationController = applicationController;
            InitializeComponent();

            

            this.ApplicationController.OpenFileCommand.BindTo(this.openToolStripMenuItem);
            this.ApplicationController.CreateNewCruiseCommand.BindTo(this.newToolStripMenuItem);

            var _aboutClickCommand = this.ApplicationController.MakeViewCommand("About", this.WindowPresenter.ShowAboutDialog);

            this.ApplicationController.SaveCommand.BindTo(this.saveToolStripMenuItem);
            this.ApplicationController.SaveAsCommand.BindTo(this.saveAsToolStripMenuItem);

            //var _openClickDispatcher = new CommandBinding(this.WindowPresenter.ShowOpenCruiseDialog, this.openToolStripMenuItem);
            //var _newFileClickDispatcher = new CommandBinding(this.WindowPresenter.ShowCruiseWizardDialog, this.newToolStripMenuItem);

            //var _saveClickDispatcher = new CommandBinding(ApplicationController.Instance.Save, this.saveToolStripMenuItem);
            //var _saveAsClickDispatcher = new CommandBinding(this.ApplicationController.SaveAs, this.saveAsToolStripMenuItem);
            //var _aboutClickDispatcher = new CommandBinding(this.WindowPresenter.ShowAboutDialog, this.aboutToolStripMenuItem);


            //this.openToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleOpenFileClick);
            //this.newToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleCreateCruiseClick);
            //this.saveToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleSaveClick);
            //this.aboutToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleAboutClick);
            //this.saveAsToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleSaveAsClick);
        }

        protected WindowPresenter WindowPresenter { get; set; }
        protected ApplicationController ApplicationController { get; set; }

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

        public void SetUserCommands(IEnumerable<ViewCommand> userCommands)
        {
            this._userCommandPanel.Controls.Clear();
            if(userCommands == null || userCommands.Count() == 0) { return;  }
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
        }

        public void SetNavCommands(IEnumerable<ViewCommand> navCommands)
        {
            this._viewNavPanel.Controls.Clear();
            if(navCommands == null) { return; }
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
        }


        //public void SetNavOptions(IEnumerable<ViewCommand> navOptions)
        //{
        //    if (navOptions == null) { return; }
        //    this._viewNavPanel.Controls.Clear();
        //    using (Graphics g = CreateGraphics())
        //    {
        //        foreach (CommandBinding clickDispatcher in navOptions.Reverse())
        //        {
        //            Button newNavButton = new Button();
        //            //newNavButton.AutoSize = true;
        //            newNavButton.BackColor = System.Drawing.Color.ForestGreen;

        //            newNavButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
        //            newNavButton.FlatAppearance.BorderSize = 0;
        //            newNavButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
        //            newNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //            newNavButton.Font = global::CruiseManager.Properties.Settings.Default.App_NavFont;
        //            newNavButton.ForeColor = System.Drawing.SystemColors.ControlText;
        //            //newNavButton.Location = new System.Drawing.Point(0, 0);
        //            //newNavButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
        //            newNavButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //            //newNavButton.Size = new System.Drawing.Size(0, 50);
        //            newNavButton.UseVisualStyleBackColor = false;
        //            newNavButton.Dock = System.Windows.Forms.DockStyle.Top;

        //            clickDispatcher.Bind(newNavButton);
        //            Size s = g.MeasureString(newNavButton.Text, newNavButton.Font, this._viewNavPanel.Width - 10).ToSize();
        //            newNavButton.Height = s.Height + 6;



        //            this._viewNavPanel.Controls.Add(newNavButton);
        //            Panel spacer = new Panel()
        //            {
        //                Height = 1,
        //                Dock = DockStyle.Top,
        //                BackColor = System.Drawing.Color.DimGray
        //            };

        //            this._viewNavPanel.Controls.Add(spacer);
        //        }
        //    }
        //}

        //public void AddNavButton(String text, EventHandler eventHandler)
        //{
        //    this.AddNavButton(text, eventHandler, true);
        //}

        //public void AddNavButton(String text, EventHandler eventHandler, bool enabled)
        //{

        //    Button newNavButton = new Button();
        //    newNavButton.AutoSize = true;
        //    newNavButton.BackColor = System.Drawing.Color.Green;
        //    newNavButton.Dock = System.Windows.Forms.DockStyle.Top;
        //    newNavButton.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
        //    newNavButton.FlatAppearance.BorderSize = 2;
        //    newNavButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
        //    //newNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //    newNavButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    newNavButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        //    newNavButton.Location = new System.Drawing.Point(0, 0);
        //    newNavButton.Size = new System.Drawing.Size(200, 35);
        //    newNavButton.Text = text;
        //    newNavButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //    newNavButton.UseVisualStyleBackColor = false;
        //    newNavButton.Click += eventHandler;
        //    newNavButton.Enabled = enabled;

        //    newNavButton.Parent = this._viewNavPanel;
        //}

        //public void ClearNavPanel()
        //{
        //    this.ViewNavPanel.Controls.Clear();
        //}

        public bool EnableSave
        {
            get
            {
                return this.saveToolStripMenuItem.Enabled;
            }
            set
            {
                this.saveToolStripMenuItem.Enabled = value;
            }
        }

        public bool EnableSaveAs
        {
            get
            {
                return this.saveAsToolStripMenuItem.Enabled;
            }
            set
            {
                this.saveAsToolStripMenuItem.Enabled = value;
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

        public void DockView(UserControl view)
        {
            this.ViewContentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            this.ViewContentPanel.Controls.Add(view);
        }

        private void _recentFilesMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string path = e.ClickedItem.ToolTipText as string; 
            if(!string.IsNullOrEmpty(path))
            {
                ApplicationController.OpenFile(path);
            }
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            _recentFilesMenu.Items.Clear();
            ToolStripMenuItem[] items = (from String path in ApplicationController.UserSettings.RecentFiles
                                         select new ToolStripMenuItem(Path.GetFileName(path)) { ToolTipText = path, }).ToArray();

            _recentFilesMenu.Items.AddRange(items);
        }
    }
}