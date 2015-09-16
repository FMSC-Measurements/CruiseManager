namespace CSM.Winforms
{
    partial class SettingsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this._TB_defaultFileFormat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._CB_createCruiseFolder = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this._BTN_browseTemplateFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._BTN_browseDefaultCruiseFolder = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 328);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(534, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this._CB_createCruiseFolder);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(528, 296);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._TB_defaultFileFormat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 174);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 108);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tip: Lorem ipsum dolor sit amet, consectetur adipiscing elit. .";
            // 
            // _TB_defaultFileFormat
            // 
            this._TB_defaultFileFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this._TB_defaultFileFormat.Location = new System.Drawing.Point(0, 13);
            this._TB_defaultFileFormat.Multiline = true;
            this._TB_defaultFileFormat.Name = "_TB_defaultFileFormat";
            this._TB_defaultFileFormat.Size = new System.Drawing.Size(323, 51);
            this._TB_defaultFileFormat.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Default File Name Format";
            // 
            // _CB_createCruiseFolder
            // 
            this._CB_createCruiseFolder.AutoSize = true;
            this._CB_createCruiseFolder.Location = new System.Drawing.Point(3, 183);
            this._CB_createCruiseFolder.Name = "_CB_createCruiseFolder";
            this._CB_createCruiseFolder.Size = new System.Drawing.Size(121, 17);
            this._CB_createCruiseFolder.TabIndex = 1;
            this._CB_createCruiseFolder.Text = "Create Cruise Folder";
            this._CB_createCruiseFolder.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(534, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Folders";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._BTN_browseTemplateFolder);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(9, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(359, 44);
            this.panel3.TabIndex = 5;
            // 
            // _BTN_browseTemplateFolder
            // 
            this._BTN_browseTemplateFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._BTN_browseTemplateFolder.Location = new System.Drawing.Point(281, 13);
            this._BTN_browseTemplateFolder.Name = "_BTN_browseTemplateFolder";
            this._BTN_browseTemplateFolder.Size = new System.Drawing.Size(75, 23);
            this._BTN_browseTemplateFolder.TabIndex = 5;
            this._BTN_browseTemplateFolder.Text = "Browse";
            this._BTN_browseTemplateFolder.UseVisualStyleBackColor = true;
            this._BTN_browseTemplateFolder.Click += new System.EventHandler(this._BTN_browseTemplateFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Default Template Folder";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._BTN_browseDefaultCruiseFolder);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(9, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 44);
            this.panel2.TabIndex = 4;
            // 
            // _BTN_browseDefaultCruiseFolder
            // 
            this._BTN_browseDefaultCruiseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._BTN_browseDefaultCruiseFolder.Location = new System.Drawing.Point(281, 13);
            this._BTN_browseDefaultCruiseFolder.Name = "_BTN_browseDefaultCruiseFolder";
            this._BTN_browseDefaultCruiseFolder.Size = new System.Drawing.Size(75, 23);
            this._BTN_browseDefaultCruiseFolder.TabIndex = 5;
            this._BTN_browseDefaultCruiseFolder.Text = "Browse";
            this._BTN_browseDefaultCruiseFolder.UseVisualStyleBackColor = true;
            this._BTN_browseDefaultCruiseFolder.Click += new System.EventHandler(this._BTN_browseDefaultCruiseFolder_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(3, 16);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(273, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3);
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Default Cruise Folder";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsView";
            this.Size = new System.Drawing.Size(542, 328);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _TB_defaultFileFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _CB_createCruiseFolder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _BTN_browseDefaultCruiseFolder;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _BTN_browseTemplateFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}
