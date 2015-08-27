namespace CSM.UI.CruiseCustomize
{
    partial class TallyEditPanel
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
            this.components = new System.ComponentModel.Container();
            this._contentPanel = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._behaviorCB = new System.Windows.Forms.ComboBox();
            this._BS_CurTally = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this._hotKeyCB = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this._discriptionTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._presetCB = new System.Windows.Forms.ComboBox();
            this._BS_tallyPresets = new System.Windows.Forms.BindingSource(this.components);
            this._addTallyButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._speciesGB = new System.Windows.Forms.GroupBox();
            this._speciesLB = new System.Windows.Forms.ListBox();
            this._BS_SPList = new System.Windows.Forms.BindingSource(this.components);
            this._dontTallyRB = new System.Windows.Forms.RadioButton();
            this._tallyBySpRB = new System.Windows.Forms.RadioButton();
            this._tallyBySGRB = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this._contentPanel.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_CurTally)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_tallyPresets)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this._speciesGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_SPList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // _contentPanel
            // 
            this._contentPanel.Controls.Add(this.groupBox5);
            this._contentPanel.Controls.Add(this.panel2);
            this._contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentPanel.Location = new System.Drawing.Point(147, 16);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Padding = new System.Windows.Forms.Padding(5);
            this._contentPanel.Size = new System.Drawing.Size(186, 260);
            this._contentPanel.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._behaviorCB);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this._hotKeyCB);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this._discriptionTB);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(5, 26);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.groupBox5.Size = new System.Drawing.Size(176, 229);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // _behaviorCB
            // 
            this._behaviorCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_CurTally, "IndicatorType", true));
            this._behaviorCB.Dock = System.Windows.Forms.DockStyle.Top;
            this._behaviorCB.Enabled = false;
            this._behaviorCB.FormattingEnabled = true;
            this._behaviorCB.Location = new System.Drawing.Point(3, 96);
            this._behaviorCB.Name = "_behaviorCB";
            this._behaviorCB.Size = new System.Drawing.Size(153, 21);
            this._behaviorCB.TabIndex = 5;
            this._behaviorCB.Visible = false;
            // 
            // _BS_CurTally
            // 
            this._BS_CurTally.DataSource = typeof(CruiseDAL.DataObjects.TallyDO);
            this._BS_CurTally.CurrentItemChanged += new System.EventHandler(this._BS_CurTally_CurrentItemChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(3, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Behavior";
            this.label11.Visible = false;
            // 
            // _hotKeyCB
            // 
            this._hotKeyCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_CurTally, "Hotkey", true));
            this._hotKeyCB.Dock = System.Windows.Forms.DockStyle.Top;
            this._hotKeyCB.FormattingEnabled = true;
            this._hotKeyCB.Location = new System.Drawing.Point(3, 62);
            this._hotKeyCB.Name = "_hotKeyCB";
            this._hotKeyCB.Size = new System.Drawing.Size(153, 21);
            this._hotKeyCB.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(3, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Hot Key";
            // 
            // _discriptionTB
            // 
            this._discriptionTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_CurTally, "Description", true));
            this._discriptionTB.Dock = System.Windows.Forms.DockStyle.Top;
            this._discriptionTB.Location = new System.Drawing.Point(3, 29);
            this._discriptionTB.Name = "_discriptionTB";
            this._discriptionTB.Size = new System.Drawing.Size(153, 20);
            this._discriptionTB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tally Button Text";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._presetCB);
            this.panel2.Controls.Add(this._addTallyButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 21);
            this.panel2.TabIndex = 3;
            // 
            // _presetCB
            // 
            this._presetCB.DataSource = this._BS_tallyPresets;
            this._presetCB.DisplayMember = "Description";
            this._presetCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._presetCB.FormattingEnabled = true;
            this._presetCB.Location = new System.Drawing.Point(0, 0);
            this._presetCB.Name = "_presetCB";
            this._presetCB.Size = new System.Drawing.Size(155, 21);
            this._presetCB.TabIndex = 1;
            this._presetCB.Visible = false;
            // 
            // _BS_tallyPresets
            // 
            this._BS_tallyPresets.DataSource = typeof(CruiseDAL.DataObjects.TallyDO);
            this._BS_tallyPresets.CurrentChanged += new System.EventHandler(this._BS_tallyPresets_CurrentChanged);
            // 
            // _addTallyButton
            // 
            this._addTallyButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._addTallyButton.Location = new System.Drawing.Point(155, 0);
            this._addTallyButton.Name = "_addTallyButton";
            this._addTallyButton.Size = new System.Drawing.Size(21, 21);
            this._addTallyButton.TabIndex = 2;
            this._addTallyButton.Text = "+";
            this._addTallyButton.UseVisualStyleBackColor = true;
            this._addTallyButton.Visible = false;
            this._addTallyButton.Click += new System.EventHandler(this._addTallyButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._contentPanel);
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(336, 279);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._speciesGB);
            this.panel1.Controls.Add(this._dontTallyRB);
            this.panel1.Controls.Add(this._tallyBySpRB);
            this.panel1.Controls.Add(this._tallyBySGRB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 260);
            this.panel1.TabIndex = 6;
            // 
            // _speciesGB
            // 
            this._speciesGB.Controls.Add(this._speciesLB);
            this._speciesGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._speciesGB.Location = new System.Drawing.Point(0, 51);
            this._speciesGB.Name = "_speciesGB";
            this._speciesGB.Size = new System.Drawing.Size(144, 209);
            this._speciesGB.TabIndex = 6;
            this._speciesGB.TabStop = false;
            this._speciesGB.Text = "Species";
            // 
            // _speciesLB
            // 
            this._speciesLB.DataSource = this._BS_SPList;
            this._speciesLB.DisplayMember = "Species";
            this._speciesLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._speciesLB.FormatString = "[Species]";
            this._speciesLB.FormattingEnabled = true;
            this._speciesLB.Location = new System.Drawing.Point(3, 16);
            this._speciesLB.Name = "_speciesLB";
            this._speciesLB.Size = new System.Drawing.Size(138, 186);
            this._speciesLB.TabIndex = 0;
            // 
            // _BS_SPList
            // 
            this._BS_SPList.DataSource = typeof(CruiseDAL.DataObjects.TreeDefaultValueDO);
            this._BS_SPList.CurrentChanged += new System.EventHandler(this._BS_SPList_CurrentChanged);
            // 
            // _dontTallyRB
            // 
            this._dontTallyRB.AutoSize = true;
            this._dontTallyRB.Checked = true;
            this._dontTallyRB.Dock = System.Windows.Forms.DockStyle.Top;
            this._dontTallyRB.Location = new System.Drawing.Point(0, 34);
            this._dontTallyRB.Name = "_dontTallyRB";
            this._dontTallyRB.Size = new System.Drawing.Size(144, 17);
            this._dontTallyRB.TabIndex = 9;
            this._dontTallyRB.TabStop = true;
            this._dontTallyRB.Text = "Don\'t Tally";
            this._dontTallyRB.UseVisualStyleBackColor = true;
            this._dontTallyRB.CheckedChanged += new System.EventHandler(this._dontTallyRB_CheckedChanged);
            // 
            // _tallyBySpRB
            // 
            this._tallyBySpRB.AutoSize = true;
            this._tallyBySpRB.Dock = System.Windows.Forms.DockStyle.Top;
            this._tallyBySpRB.Location = new System.Drawing.Point(0, 17);
            this._tallyBySpRB.Name = "_tallyBySpRB";
            this._tallyBySpRB.Size = new System.Drawing.Size(144, 17);
            this._tallyBySpRB.TabIndex = 8;
            this._tallyBySpRB.Text = "Tally by Species";
            this._tallyBySpRB.UseVisualStyleBackColor = true;
            this._tallyBySpRB.CheckedChanged += new System.EventHandler(this._tallyBySpRB_CheckedChanged);
            // 
            // _tallyBySGRB
            // 
            this._tallyBySGRB.AutoSize = true;
            this._tallyBySGRB.Dock = System.Windows.Forms.DockStyle.Top;
            this._tallyBySGRB.Location = new System.Drawing.Point(0, 0);
            this._tallyBySGRB.Name = "_tallyBySGRB";
            this._tallyBySGRB.Size = new System.Drawing.Size(144, 17);
            this._tallyBySGRB.TabIndex = 7;
            this._tallyBySGRB.Text = "Tally by Sample Group";
            this._tallyBySGRB.UseVisualStyleBackColor = true;
            this._tallyBySGRB.CheckedChanged += new System.EventHandler(this._tallyBySGRB_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this._BS_CurTally;
            // 
            // TallyEditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "TallyEditPanel";
            this.Size = new System.Drawing.Size(336, 279);
            this._contentPanel.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_CurTally)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._BS_tallyPresets)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._speciesGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._BS_SPList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton _tallyBySpRB;
        private System.Windows.Forms.RadioButton _tallyBySGRB;
        private System.Windows.Forms.GroupBox _speciesGB;
        private System.Windows.Forms.ListBox _speciesLB;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox _behaviorCB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _hotKeyCB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox _presetCB;
        public System.Windows.Forms.BindingSource _BS_tallyPresets;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel _contentPanel;
        private System.Windows.Forms.RadioButton _dontTallyRB;
        private System.Windows.Forms.BindingSource _BS_SPList;
        private System.Windows.Forms.BindingSource _BS_CurTally;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _discriptionTB;
        private System.Windows.Forms.Button _addTallyButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
