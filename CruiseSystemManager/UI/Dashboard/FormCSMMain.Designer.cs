﻿namespace CSM.UI.Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCSMMain));
            System.Windows.Forms.Button ExampleButton;
            this._viewContentPanel = new System.Windows.Forms.Panel();
            this._viewNavPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._recentFilesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new System.Windows.Forms.Panel();
            ExampleButton = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            this._viewNavPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(this._viewContentPanel);
            panel1.Controls.Add(this._viewNavPanel);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 24);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(3);
            panel1.Size = new System.Drawing.Size(752, 442);
            panel1.TabIndex = 1;
            // 
            // _viewContentPanel
            // 
            this._viewContentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_viewContentPanel.BackgroundImage")));
            this._viewContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._viewContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._viewContentPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._viewContentPanel.Location = new System.Drawing.Point(154, 3);
            this._viewContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this._viewContentPanel.Name = "_viewContentPanel";
            this._viewContentPanel.Size = new System.Drawing.Size(595, 436);
            this._viewContentPanel.TabIndex = 2;
            // 
            // _viewNavPanel
            // 
            this._viewNavPanel.BackColor = System.Drawing.Color.Transparent;
            this._viewNavPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._viewNavPanel.Controls.Add(ExampleButton);
            this._viewNavPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._viewNavPanel.Location = new System.Drawing.Point(3, 3);
            this._viewNavPanel.Name = "_viewNavPanel";
            this._viewNavPanel.Size = new System.Drawing.Size(151, 436);
            this._viewNavPanel.TabIndex = 1;
            // 
            // ExampleButton
            // 
            ExampleButton.AutoSize = true;
            ExampleButton.BackColor = System.Drawing.Color.Green;
            ExampleButton.Dock = System.Windows.Forms.DockStyle.Top;
            ExampleButton.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            ExampleButton.FlatAppearance.BorderSize = 2;
            ExampleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            ExampleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ExampleButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            ExampleButton.Location = new System.Drawing.Point(0, 0);
            ExampleButton.Name = "ExampleButton";
            ExampleButton.Size = new System.Drawing.Size(147, 34);
            ExampleButton.TabIndex = 1;
            ExampleButton.Text = "<Example Button>";
            ExampleButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ExampleButton.UseVisualStyleBackColor = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(752, 24);
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
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New Cruise";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.recentToolStripMenuItem.DropDown = this._recentFilesMenu;
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.recentToolStripMenuItem.Text = "Recent";
            // 
            // _recentFilesMenu
            // 
            this._recentFilesMenu.Name = "_recentFilesMenu";
            this._recentFilesMenu.Size = new System.Drawing.Size(61, 4);
            this._recentFilesMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this._recentFilesMenu_ItemClicked);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // FormCSMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 466);
            this.Controls.Add(panel1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormCSMMain";
            this.Text = "FormCSMMain";
            panel1.ResumeLayout(false);
            this._viewNavPanel.ResumeLayout(false);
            this._viewNavPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel _viewNavPanel;
        private System.Windows.Forms.Panel _viewContentPanel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip _recentFilesMenu;
    }
}