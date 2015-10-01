namespace CruiseManager.Winforms.Dashboard
{
    partial class FormCSMMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel panel1;
            //CruiseManager.Properties.Settings settings1 = new CruiseManager.Properties.Settings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCSMMain));
            this._viewContentPanel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._recentFilesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._leftCommandPanel = new System.Windows.Forms.Panel();
            this._userCommandPanel = new System.Windows.Forms.Panel();
            this._viewNavPanel = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this._leftCommandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(this._viewContentPanel);
            panel1.Controls.Add(this._leftCommandPanel);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 25);
            panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(824, 477);
            panel1.TabIndex = 1;
            // 
            // _viewContentPanel
            // 
            this._viewContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._viewContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._viewContentPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._viewContentPanel.Location = new System.Drawing.Point(151, 0);
            this._viewContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this._viewContentPanel.Name = "_viewContentPanel";
            this._viewContentPanel.Size = new System.Drawing.Size(673, 477);
            this._viewContentPanel.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(824, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newToolStripMenuItem.Text = "New Cruise";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.recentToolStripMenuItem.DropDown = this._recentFilesMenu;
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.recentToolStripMenuItem.Text = "Recent";
            // 
            // _recentFilesMenu
            // 
            this._recentFilesMenu.Name = "_recentFilesMenu";
            this._recentFilesMenu.OwnerItem = this.recentToolStripMenuItem;
            this._recentFilesMenu.Size = new System.Drawing.Size(61, 4);
            this._recentFilesMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._recentFilesMenu_ItemClicked);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.aboutToolStripMenuItem.Text = "About";
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
            this._leftCommandPanel.Size = new System.Drawing.Size(151, 477);
            this._leftCommandPanel.TabIndex = 3;
            // 
            // _userCommandPanel
            // 
            this._userCommandPanel.AutoSize = true;
            this._userCommandPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._userCommandPanel.BackColor = System.Drawing.Color.Transparent;
            this._userCommandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._userCommandPanel.Location = new System.Drawing.Point(0, 477);
            this._userCommandPanel.Margin = new System.Windows.Forms.Padding(0);
            this._userCommandPanel.Name = "_userCommandPanel";
            this._userCommandPanel.Size = new System.Drawing.Size(151, 0);
            this._userCommandPanel.TabIndex = 0;
            // 
            // _viewNavPanel
            // 
            this._viewNavPanel.BackColor = System.Drawing.Color.Transparent;
            this._viewNavPanel.DataBindings.Add(new System.Windows.Forms.Binding("Font", Properties.Settings.Default.App_NavFont, "App_NavFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._viewNavPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            //this._viewNavPanel.Font = settings1.App_NavFont;
            this._viewNavPanel.Location = new System.Drawing.Point(0, 0);
            this._viewNavPanel.Margin = new System.Windows.Forms.Padding(0);
            this._viewNavPanel.MinimumSize = new System.Drawing.Size(150, 4);
            this._viewNavPanel.Name = "_viewNavPanel";
            this._viewNavPanel.Size = new System.Drawing.Size(151, 477);
            this._viewNavPanel.TabIndex = 4;
            // 
            // FormCSMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 502);
            this.Controls.Add(panel1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormCSMMain";
            this.Text = "FormCSMMain";
            panel1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this._leftCommandPanel.ResumeLayout(false);
            this._leftCommandPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Panel _viewContentPanel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip _recentFilesMenu;
        private System.Windows.Forms.Panel _leftCommandPanel;
        private System.Windows.Forms.Panel _viewNavPanel;
        private System.Windows.Forms.Panel _userCommandPanel;
    }
}