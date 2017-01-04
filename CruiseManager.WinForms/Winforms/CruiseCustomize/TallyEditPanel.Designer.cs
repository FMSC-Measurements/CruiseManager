namespace CruiseManager.WinForms.CruiseCustomize
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
            this._BS_CurTally = new System.Windows.Forms.BindingSource(this.components);
            this._GB_topLevelContainer = new System.Windows.Forms.GroupBox();
            this._GB_tallyFields = new System.Windows.Forms.GroupBox();
            this._behaviorCB = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this._hotKeyCB = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this._discriptionTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._speciesGB = new System.Windows.Forms.GroupBox();
            this._speciesLB = new System.Windows.Forms.ListBox();
            this._BS_SPList = new System.Windows.Forms.BindingSource(this.components);
            this._dontTallyRB = new System.Windows.Forms.RadioButton();
            this._tallyBySpRB = new System.Windows.Forms.RadioButton();
            this._tallyBySGRB = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this._sampleGroup_PNL = new System.Windows.Forms.Panel();
            this._tallyClickerCB = new System.Windows.Forms.CheckBox();
            this._BS_sampleGroups = new System.Windows.Forms.BindingSource(this.components);
            this._systematicOptCB = new System.Windows.Forms.CheckBox();
            this._sampleGroupCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._BS_CurTally)).BeginInit();
            this._GB_topLevelContainer.SuspendLayout();
            this._GB_tallyFields.SuspendLayout();
            this.panel1.SuspendLayout();
            this._speciesGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_SPList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this._sampleGroup_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_sampleGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // _BS_CurTally
            // 
            this._BS_CurTally.DataSource = typeof(CruiseDAL.DataObjects.TallyDO);
            this._BS_CurTally.CurrentItemChanged += new System.EventHandler(this._BS_CurTally_CurrentItemChanged);
            // 
            // _GB_topLevelContainer
            // 
            this._GB_topLevelContainer.Controls.Add(this._GB_tallyFields);
            this._GB_topLevelContainer.Controls.Add(this.panel1);
            this._GB_topLevelContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this._GB_topLevelContainer.Location = new System.Drawing.Point(0, 58);
            this._GB_topLevelContainer.Name = "_GB_topLevelContainer";
            this._GB_topLevelContainer.Size = new System.Drawing.Size(336, 268);
            this._GB_topLevelContainer.TabIndex = 5;
            this._GB_topLevelContainer.TabStop = false;
            // 
            // _GB_tallyFields
            // 
            this._GB_tallyFields.Controls.Add(this._behaviorCB);
            this._GB_tallyFields.Controls.Add(this.label11);
            this._GB_tallyFields.Controls.Add(this._hotKeyCB);
            this._GB_tallyFields.Controls.Add(this.label12);
            this._GB_tallyFields.Controls.Add(this._discriptionTB);
            this._GB_tallyFields.Controls.Add(this.label1);
            this._GB_tallyFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this._GB_tallyFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._GB_tallyFields.Location = new System.Drawing.Point(147, 18);
            this._GB_tallyFields.Name = "_GB_tallyFields";
            this._GB_tallyFields.Padding = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this._GB_tallyFields.Size = new System.Drawing.Size(186, 247);
            this._GB_tallyFields.TabIndex = 7;
            this._GB_tallyFields.TabStop = false;
            // 
            // _behaviorCB
            // 
            this._behaviorCB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_CurTally, "IndicatorType", true));
            this._behaviorCB.Dock = System.Windows.Forms.DockStyle.Top;
            this._behaviorCB.Enabled = false;
            this._behaviorCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._behaviorCB.FormattingEnabled = true;
            this._behaviorCB.Location = new System.Drawing.Point(3, 100);
            this._behaviorCB.Name = "_behaviorCB";
            this._behaviorCB.Size = new System.Drawing.Size(163, 21);
            this._behaviorCB.TabIndex = 5;
            this._behaviorCB.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(3, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Behavior";
            this.label11.Visible = false;
            // 
            // _hotKeyCB
            // 
            this._hotKeyCB.Dock = System.Windows.Forms.DockStyle.Top;
            this._hotKeyCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._hotKeyCB.FormattingEnabled = true;
            this._hotKeyCB.Location = new System.Drawing.Point(3, 66);
            this._hotKeyCB.Name = "_hotKeyCB";
            this._hotKeyCB.Size = new System.Drawing.Size(163, 21);
            this._hotKeyCB.TabIndex = 3;
            this._hotKeyCB.DropDown += new System.EventHandler(this._hotKeyCB_DropedDown);
            this._hotKeyCB.TextChanged += new System.EventHandler(this._hotKeyCB_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(3, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Hot Key";
            // 
            // _discriptionTB
            // 
            this._discriptionTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._discriptionTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_CurTally, "Description", true));
            this._discriptionTB.Dock = System.Windows.Forms.DockStyle.Top;
            this._discriptionTB.Location = new System.Drawing.Point(3, 31);
            this._discriptionTB.Name = "_discriptionTB";
            this._discriptionTB.Size = new System.Drawing.Size(163, 22);
            this._discriptionTB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tally Button Text";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._speciesGB);
            this.panel1.Controls.Add(this._dontTallyRB);
            this.panel1.Controls.Add(this._tallyBySpRB);
            this.panel1.Controls.Add(this._tallyBySGRB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 247);
            this.panel1.TabIndex = 6;
            // 
            // _speciesGB
            // 
            this._speciesGB.Controls.Add(this._speciesLB);
            this._speciesGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._speciesGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._speciesGB.Location = new System.Drawing.Point(0, 51);
            this._speciesGB.Name = "_speciesGB";
            this._speciesGB.Size = new System.Drawing.Size(144, 196);
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
            this._speciesLB.Location = new System.Drawing.Point(3, 18);
            this._speciesLB.Name = "_speciesLB";
            this._speciesLB.Size = new System.Drawing.Size(138, 175);
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
            this._dontTallyRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this._tallyBySpRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this._tallyBySGRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            // _sampleGroup_PNL
            // 
            this._sampleGroup_PNL.Controls.Add(this._tallyClickerCB);
            this._sampleGroup_PNL.Controls.Add(this._systematicOptCB);
            this._sampleGroup_PNL.Controls.Add(this._sampleGroupCB);
            this._sampleGroup_PNL.Controls.Add(this.label10);
            this._sampleGroup_PNL.Dock = System.Windows.Forms.DockStyle.Top;
            this._sampleGroup_PNL.Location = new System.Drawing.Point(0, 0);
            this._sampleGroup_PNL.Name = "_sampleGroup_PNL";
            this._sampleGroup_PNL.Size = new System.Drawing.Size(461, 58);
            this._sampleGroup_PNL.TabIndex = 11;
            // 
            // _tallyClickerCB
            // 
            this._tallyClickerCB.AutoSize = true;
            this._tallyClickerCB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._BS_sampleGroups, "UseClickerTally", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._tallyClickerCB.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._BS_sampleGroups, "CanSelectClickerTally", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this._tallyClickerCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._tallyClickerCB.Location = new System.Drawing.Point(162, 31);
            this._tallyClickerCB.Name = "_tallyClickerCB";
            this._tallyClickerCB.Size = new System.Drawing.Size(175, 17);
            this._tallyClickerCB.TabIndex = 15;
            this._tallyClickerCB.Text = "Use Tally Clicker For Sampling";
            this._tallyClickerCB.UseVisualStyleBackColor = true;
            // 
            // _BS_sampleGroups
            // 
            this._BS_sampleGroups.DataSource = typeof(CruiseManager.Core.CruiseCustomize.TallySetupSampleGroup);
            this._BS_sampleGroups.CurrentChanged += new System.EventHandler(this._BS_sampleGroups_CurrentChanged);
            // 
            // _systematicOptCB
            // 
            this._systematicOptCB.AutoSize = true;
            this._systematicOptCB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this._BS_sampleGroups, "UseSystematicSampling", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._systematicOptCB.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this._BS_sampleGroups, "CanSelectSystematic", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this._systematicOptCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._systematicOptCB.Location = new System.Drawing.Point(6, 30);
            this._systematicOptCB.Name = "_systematicOptCB";
            this._systematicOptCB.Size = new System.Drawing.Size(149, 17);
            this._systematicOptCB.TabIndex = 14;
            this._systematicOptCB.Text = "Use Systematic Sampling";
            this._systematicOptCB.UseVisualStyleBackColor = true;
            // 
            // _sampleGroupCB
            // 
            this._sampleGroupCB.DataSource = this._BS_sampleGroups;
            this._sampleGroupCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._sampleGroupCB.FormattingEnabled = true;
            this._sampleGroupCB.Location = new System.Drawing.Point(83, 3);
            this._sampleGroupCB.Name = "_sampleGroupCB";
            this._sampleGroupCB.Size = new System.Drawing.Size(121, 21);
            this._sampleGroupCB.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Sample Group";
            // 
            // TallyEditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._GB_topLevelContainer);
            this.Controls.Add(this._sampleGroup_PNL);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TallyEditPanel";
            this.Size = new System.Drawing.Size(461, 326);
            ((System.ComponentModel.ISupportInitialize)(this._BS_CurTally)).EndInit();
            this._GB_topLevelContainer.ResumeLayout(false);
            this._GB_tallyFields.ResumeLayout(false);
            this._GB_tallyFields.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._speciesGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._BS_SPList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this._sampleGroup_PNL.ResumeLayout(false);
            this._sampleGroup_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_sampleGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _GB_topLevelContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton _tallyBySpRB;
        private System.Windows.Forms.RadioButton _tallyBySGRB;
        private System.Windows.Forms.GroupBox _speciesGB;
        private System.Windows.Forms.ListBox _speciesLB;
        private System.Windows.Forms.RadioButton _dontTallyRB;
        private System.Windows.Forms.BindingSource _BS_SPList;
        private System.Windows.Forms.BindingSource _BS_CurTally;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox _GB_tallyFields;
        private System.Windows.Forms.ComboBox _behaviorCB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _hotKeyCB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _discriptionTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _sampleGroup_PNL;
        private System.Windows.Forms.CheckBox _systematicOptCB;
        private System.Windows.Forms.ComboBox _sampleGroupCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource _BS_sampleGroups;
        private System.Windows.Forms.CheckBox _tallyClickerCB;
    }
}
