using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSM.Logic;
using System.IO;

namespace CSM.UI.Dashboard
{
    public partial class FormCSMMain : Form
    {
        
        public FormCSMMain(IWindowPresenter windowPresenter)
        {
            this.WindowPresenter = windowPresenter;
            InitializeComponent();

            var _openClickDispatcher = new NavOption(this.WindowPresenter.ShowOpenCruiseDialog, this.openToolStripMenuItem);
            var _newFileClickDispatcher = new NavOption(this.WindowPresenter.ShowCruiseWizardDiolog, this.newToolStripMenuItem);
            var _saveClickDispatcher = new NavOption(this.WindowPresenter.Save, this.saveAsToolStripMenuItem);
            var _aboutClickDispatcher = new NavOption(this.WindowPresenter.ShowAboutDialog, this.aboutToolStripMenuItem);
            var _saveAsClickDispatcher = new NavOption(this.WindowPresenter.SaveAs); 


            //this.openToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleOpenFileClick);
            //this.newToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleCreateCruiseClick);
            //this.saveToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleSaveClick);
            //this.aboutToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleAboutClick);
            //this.saveAsToolStripMenuItem.Click += new EventHandler(this.WindowPresenter.HandleSaveAsClick);
        }

        public IWindowPresenter WindowPresenter { get; set; }
        public Panel ViewContentPanel { get { return this._viewContentPanel; } }
        public Panel ViewNavPanel { get { return this._viewNavPanel; } }

        public void SetNavOptions(ICollection<NavOption> navOptions)
        {
            if (navOptions == null) { return; }
            this._viewNavPanel.Controls.Clear();
            foreach (NavOption clickDispatcher in navOptions)
            {
                Button newNavButton = new Button();
                newNavButton.AutoSize = true;
                newNavButton.BackColor = System.Drawing.Color.Green;
                newNavButton.Dock = System.Windows.Forms.DockStyle.Top;
                newNavButton.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
                newNavButton.FlatAppearance.BorderSize = 2;
                newNavButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                //newNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newNavButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newNavButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                newNavButton.Location = new System.Drawing.Point(0, 0);
                newNavButton.Size = new System.Drawing.Size(200, 35);
                newNavButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                newNavButton.UseVisualStyleBackColor = false;

                clickDispatcher.Bind(newNavButton);
                this._viewNavPanel.Controls.Add(newNavButton);
            }
        }

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
                WindowPresenter.OpenFile(path);
            }
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            _recentFilesMenu.Items.Clear();
            ToolStripMenuItem[] items = (from String path in WindowPresenter.RecentFiles
                                         select new ToolStripMenuItem(Path.GetFileName(path)) { ToolTipText = path, }).ToArray();

            _recentFilesMenu.Items.AddRange(items);
        }

        #region click hanlders
        public void HandleAboutClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowAboutDialog();
        }

        public void HandleOpenFileClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowOpenCruiseDialog();
        }

        public void HandleCreateCruiseClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowCruiseWizardDiolog();
        }

        public void HandleSaveClick(object sender, EventArgs e)
        {
            this.WindowPresenter.Save();
        }

        public void HandleSaveAsClick(object sender, EventArgs e)
        {
            this.WindowPresenter.SaveAs();
        }

        public void HandleEditViewCruiseClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowEditDesign();
        }

        public void HandleExportCruiseClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowDataEditor();
        }

        public void HandleManageComponensClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowManageComponentsLayout();
        }

        public void HandleEditWizardClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowEditWizard();
        }

        public void HandleCreateComponentsClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowCreateComponentsLayout();
        }

        public void HandleCruiseCustomizeClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowCustomizeCruiseLayout();
        }
        public void HandleHomePageClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowHomeLayout();
        }

        public void HandleReturnCruiseLandingClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowCruiseLandingLayout();
        }

        public void HandleImportTemplateClick(object sender, EventArgs e)
        {
            this.WindowPresenter.ShowImportTemplate();
        }
        #endregion

    }
}