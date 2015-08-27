namespace CSM.UI
{
    partial class DialogConfigCounts
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
           System.Windows.Forms.Panel _contentPanel;
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this._behaviorCB = new System.Windows.Forms.ComboBox();
           this._BS_tally = new System.Windows.Forms.BindingSource(this.components);
           this.label4 = new System.Windows.Forms.Label();
           this._hotKeyCB = new System.Windows.Forms.ComboBox();
           this.label3 = new System.Windows.Forms.Label();
           this._descriptionTB = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this._presetCB = new System.Windows.Forms.ComboBox();
           this.label1 = new System.Windows.Forms.Label();
           this.panel1 = new System.Windows.Forms.Panel();
           this._speciesGB = new System.Windows.Forms.GroupBox();
           this._speciesLB = new System.Windows.Forms.ListBox();
           this._tallyBySpeciesCB = new System.Windows.Forms.CheckBox();
           _contentPanel = new System.Windows.Forms.Panel();
           _contentPanel.SuspendLayout();
           this.groupBox1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._BS_tally)).BeginInit();
           this.panel1.SuspendLayout();
           this._speciesGB.SuspendLayout();
           this.SuspendLayout();
           // 
           // _contentPanel
           // 
           _contentPanel.Controls.Add(this.groupBox1);
           _contentPanel.Controls.Add(this._presetCB);
           _contentPanel.Controls.Add(this.label1);
           _contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
           _contentPanel.Location = new System.Drawing.Point(189, 0);
           _contentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           _contentPanel.Name = "_contentPanel";
           _contentPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
           _contentPanel.Size = new System.Drawing.Size(196, 207);
           _contentPanel.TabIndex = 1;
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this._behaviorCB);
           this.groupBox1.Controls.Add(this.label4);
           this.groupBox1.Controls.Add(this._hotKeyCB);
           this.groupBox1.Controls.Add(this.label3);
           this.groupBox1.Controls.Add(this._descriptionTB);
           this.groupBox1.Controls.Add(this.label2);
           this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.groupBox1.Location = new System.Drawing.Point(7, 47);
           this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.groupBox1.Size = new System.Drawing.Size(182, 154);
           this.groupBox1.TabIndex = 2;
           this.groupBox1.TabStop = false;
           // 
           // _behaviorCB
           // 
           this._behaviorCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_tally, "IndicatorType", true));
           this._behaviorCB.Dock = System.Windows.Forms.DockStyle.Top;
           this._behaviorCB.FormattingEnabled = true;
           this._behaviorCB.Location = new System.Drawing.Point(4, 116);
           this._behaviorCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this._behaviorCB.Name = "_behaviorCB";
           this._behaviorCB.Size = new System.Drawing.Size(174, 24);
           this._behaviorCB.TabIndex = 5;
           // 
           // _BS_tally
           // 
           this._BS_tally.DataSource = typeof(CruiseDAL.DataObjects.TallyDO);
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Dock = System.Windows.Forms.DockStyle.Top;
           this.label4.Location = new System.Drawing.Point(4, 99);
           this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(64, 17);
           this.label4.TabIndex = 4;
           this.label4.Text = "Behavior";
           // 
           // _hotKeyCB
           // 
           this._hotKeyCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_tally, "Hotkey", true));
           this._hotKeyCB.Dock = System.Windows.Forms.DockStyle.Top;
           this._hotKeyCB.FormattingEnabled = true;
           this._hotKeyCB.Location = new System.Drawing.Point(4, 75);
           this._hotKeyCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this._hotKeyCB.Name = "_hotKeyCB";
           this._hotKeyCB.Size = new System.Drawing.Size(174, 24);
           this._hotKeyCB.TabIndex = 3;
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Dock = System.Windows.Forms.DockStyle.Top;
           this.label3.Location = new System.Drawing.Point(4, 58);
           this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(58, 17);
           this.label3.TabIndex = 2;
           this.label3.Text = "Hot Key";
           // 
           // _descriptionTB
           // 
           this._descriptionTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_tally, "Description", true));
           this._descriptionTB.Dock = System.Windows.Forms.DockStyle.Top;
           this._descriptionTB.Location = new System.Drawing.Point(4, 36);
           this._descriptionTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this._descriptionTB.Name = "_descriptionTB";
           this._descriptionTB.Size = new System.Drawing.Size(174, 22);
           this._descriptionTB.TabIndex = 1;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Dock = System.Windows.Forms.DockStyle.Top;
           this.label2.Location = new System.Drawing.Point(4, 19);
           this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(79, 17);
           this.label2.TabIndex = 0;
           this.label2.Text = "Description";
           // 
           // _presetCB
           // 
           this._presetCB.DataSource = this._BS_tally;
           this._presetCB.DisplayMember = "Description";
           this._presetCB.Dock = System.Windows.Forms.DockStyle.Top;
           this._presetCB.FormattingEnabled = true;
           this._presetCB.Location = new System.Drawing.Point(7, 23);
           this._presetCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this._presetCB.Name = "_presetCB";
           this._presetCB.Size = new System.Drawing.Size(182, 24);
           this._presetCB.TabIndex = 1;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Dock = System.Windows.Forms.DockStyle.Top;
           this.label1.Location = new System.Drawing.Point(7, 6);
           this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(49, 17);
           this.label1.TabIndex = 0;
           this.label1.Text = "Preset";
           // 
           // panel1
           // 
           this.panel1.Controls.Add(this._speciesGB);
           this.panel1.Controls.Add(this._tallyBySpeciesCB);
           this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
           this.panel1.Location = new System.Drawing.Point(0, 0);
           this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.panel1.Name = "panel1";
           this.panel1.Size = new System.Drawing.Size(189, 207);
           this.panel1.TabIndex = 2;
           // 
           // _speciesGB
           // 
           this._speciesGB.Controls.Add(this._speciesLB);
           this._speciesGB.Dock = System.Windows.Forms.DockStyle.Fill;
           this._speciesGB.Location = new System.Drawing.Point(0, 21);
           this._speciesGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this._speciesGB.Name = "_speciesGB";
           this._speciesGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this._speciesGB.Size = new System.Drawing.Size(189, 186);
           this._speciesGB.TabIndex = 1;
           this._speciesGB.TabStop = false;
           this._speciesGB.Text = "Species";
           // 
           // _speciesLB
           // 
           this._speciesLB.Dock = System.Windows.Forms.DockStyle.Fill;
           this._speciesLB.FormattingEnabled = true;
           this._speciesLB.ItemHeight = 16;
           this._speciesLB.Location = new System.Drawing.Point(4, 19);
           this._speciesLB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this._speciesLB.Name = "_speciesLB";
           this._speciesLB.Size = new System.Drawing.Size(181, 148);
           this._speciesLB.TabIndex = 0;
           // 
           // _tallyBySpeciesCB
           // 
           this._tallyBySpeciesCB.AutoSize = true;
           this._tallyBySpeciesCB.Dock = System.Windows.Forms.DockStyle.Top;
           this._tallyBySpeciesCB.Location = new System.Drawing.Point(0, 0);
           this._tallyBySpeciesCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this._tallyBySpeciesCB.Name = "_tallyBySpeciesCB";
           this._tallyBySpeciesCB.Size = new System.Drawing.Size(189, 21);
           this._tallyBySpeciesCB.TabIndex = 2;
           this._tallyBySpeciesCB.Text = "Tally By Species";
           this._tallyBySpeciesCB.UseVisualStyleBackColor = true;
           // 
           // DialogConfigCounts
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(385, 207);
           this.Controls.Add(_contentPanel);
           this.Controls.Add(this.panel1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
           this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.Name = "DialogConfigCounts";
           this.ShowInTaskbar = false;
           this.Text = "DialogConfigCounts";
           _contentPanel.ResumeLayout(false);
           _contentPanel.PerformLayout();
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this._BS_tally)).EndInit();
           this.panel1.ResumeLayout(false);
           this.panel1.PerformLayout();
           this._speciesGB.ResumeLayout(false);
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _descriptionTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _presetCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _behaviorCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _hotKeyCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource _BS_tally;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox _speciesGB;
        private System.Windows.Forms.ListBox _speciesLB;
        private System.Windows.Forms.CheckBox _tallyBySpeciesCB;
    }
}