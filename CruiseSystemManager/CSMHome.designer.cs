namespace CruiseSystemManager
{
    partial class CSMHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSMHome));
            this.RootLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.ContentHost = new CruiseSystemManager.Controls.PageHost();
            this.SideBarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LogoButton = new System.Windows.Forms.Button();
            this.FileSetupButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ProgramsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.RootLayoutPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.SideBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootLayoutPanel
            // 
            this.RootLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(34)))), ((int)(((byte)(15)))));
            this.RootLayoutPanel.ColumnCount = 3;
            this.RootLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.RootLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RootLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.RootLayoutPanel.Controls.Add(this.ContentPanel, 1, 1);
            this.RootLayoutPanel.Controls.Add(this.SideBarPanel, 0, 0);
            this.RootLayoutPanel.Controls.Add(this.label1, 1, 0);
            this.RootLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.RootLayoutPanel.Name = "RootLayoutPanel";
            this.RootLayoutPanel.RowCount = 3;
            this.RootLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.RootLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RootLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.RootLayoutPanel.Size = new System.Drawing.Size(810, 508);
            this.RootLayoutPanel.TabIndex = 0;
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.Color.Snow;
            this.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RootLayoutPanel.SetColumnSpan(this.ContentPanel, 2);
            this.ContentPanel.Controls.Add(this.ContentHost);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(137, 64);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentPanel.Name = "ContentPanel";
            this.RootLayoutPanel.SetRowSpan(this.ContentPanel, 2);
            this.ContentPanel.Size = new System.Drawing.Size(673, 444);
            this.ContentPanel.TabIndex = 1;
            // 
            // ContentHost
            // 
            this.ContentHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentHost.Location = new System.Drawing.Point(0, 0);
            this.ContentHost.Name = "ContentHost";
            this.ContentHost.Size = new System.Drawing.Size(671, 442);
            this.ContentHost.TabIndex = 1;
            // 
            // SideBarPanel
            // 
            this.SideBarPanel.AutoSize = true;
            this.SideBarPanel.BackColor = System.Drawing.Color.DarkRed;
            this.SideBarPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SideBarPanel.BackgroundImage")));
            this.SideBarPanel.Controls.Add(this.LogoButton);
            this.SideBarPanel.Controls.Add(this.FileSetupButton);
            this.SideBarPanel.Controls.Add(this.SettingsButton);
            this.SideBarPanel.Controls.Add(this.ProgramsButton);
            this.SideBarPanel.Controls.Add(this.button1);
            this.SideBarPanel.Controls.Add(this.button2);
            this.SideBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideBarPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SideBarPanel.Location = new System.Drawing.Point(0, 0);
            this.SideBarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SideBarPanel.Name = "SideBarPanel";
            this.RootLayoutPanel.SetRowSpan(this.SideBarPanel, 3);
            this.SideBarPanel.Size = new System.Drawing.Size(137, 508);
            this.SideBarPanel.TabIndex = 3;
            // 
            // LogoButton
            // 
            this.LogoButton.AutoSize = true;
            this.LogoButton.BackColor = System.Drawing.Color.Transparent;
            this.LogoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LogoButton.BackgroundImage")));
            this.LogoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LogoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoButton.FlatAppearance.BorderSize = 0;
            this.LogoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.LogoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LogoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoButton.Location = new System.Drawing.Point(11, 3);
            this.LogoButton.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.LogoButton.Name = "LogoButton";
            this.LogoButton.Size = new System.Drawing.Size(118, 62);
            this.LogoButton.TabIndex = 0;
            this.LogoButton.UseVisualStyleBackColor = false;
            this.LogoButton.Click += new System.EventHandler(this.fileSetup_Click);
            // 
            // FileSetupButton
            // 
            this.FileSetupButton.BackColor = System.Drawing.Color.Transparent;
            this.FileSetupButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FileSetupButton.BackgroundImage")));
            this.FileSetupButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FileSetupButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FileSetupButton.FlatAppearance.BorderSize = 0;
            this.FileSetupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.FileSetupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FileSetupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileSetupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileSetupButton.Location = new System.Drawing.Point(11, 71);
            this.FileSetupButton.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.FileSetupButton.Name = "FileSetupButton";
            this.FileSetupButton.Size = new System.Drawing.Size(118, 32);
            this.FileSetupButton.TabIndex = 1;
            this.FileSetupButton.Text = "File Setup";
            this.FileSetupButton.UseVisualStyleBackColor = false;
            this.FileSetupButton.Click += new System.EventHandler(this.fileSetup_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsButton.BackgroundImage")));
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.Location = new System.Drawing.Point(11, 109);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(118, 32);
            this.SettingsButton.TabIndex = 2;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ProgramsButton
            // 
            this.ProgramsButton.BackColor = System.Drawing.Color.Transparent;
            this.ProgramsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProgramsButton.BackgroundImage")));
            this.ProgramsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProgramsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProgramsButton.FlatAppearance.BorderSize = 0;
            this.ProgramsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ProgramsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ProgramsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgramsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramsButton.Location = new System.Drawing.Point(11, 147);
            this.ProgramsButton.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.ProgramsButton.Name = "ProgramsButton";
            this.ProgramsButton.Size = new System.Drawing.Size(118, 32);
            this.ProgramsButton.TabIndex = 3;
            this.ProgramsButton.Text = "Programs";
            this.ProgramsButton.UseVisualStyleBackColor = false;
            this.ProgramsButton.Click += new System.EventHandler(this.ProgramsButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(11, 185);
            this.button1.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Help_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(11, 223);
            this.button2.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(34)))), ((int)(((byte)(15)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(558, 64);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cruise System Manager";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(59, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(181, 56);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // CSMHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 508);
            this.Controls.Add(this.RootLayoutPanel);
            this.Name = "CSMHome";
            this.Text = "CSM";
            this.RootLayoutPanel.ResumeLayout(false);
            this.RootLayoutPanel.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            this.SideBarPanel.ResumeLayout(false);
            this.SideBarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel RootLayoutPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.FlowLayoutPanel SideBarPanel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button3;
        private CruiseSystemManager.Controls.PageHost ContentHost;
        private System.Windows.Forms.Button LogoButton;
        private System.Windows.Forms.Button FileSetupButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ProgramsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}