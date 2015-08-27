namespace CSM.UI.CruiseCustomize
{
    partial class LogMatrixSettingsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this._logMatrixLayout = new System.Windows.Forms.TableLayoutPanel();
            this.newParameters = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._r009RB = new System.Windows.Forms.RadioButton();
            this._r008RB = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._descriptorCamprunRB = new System.Windows.Forms.RadioButton();
            this._descriptorOrRB = new System.Windows.Forms.RadioButton();
            this._descriptorAndRB = new System.Windows.Forms.RadioButton();
            this._sedMaxTB = new System.Windows.Forms.TextBox();
            this._descriptor2 = new System.Windows.Forms.ComboBox();
            this._minSEDTB = new System.Windows.Forms.TextBox();
            this._descriptor1 = new System.Windows.Forms.ComboBox();
            this._sedLimitTB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grade9 = new System.Windows.Forms.CheckBox();
            this.grade8 = new System.Windows.Forms.CheckBox();
            this.grade7 = new System.Windows.Forms.CheckBox();
            this.grade6 = new System.Windows.Forms.CheckBox();
            this.grade5 = new System.Windows.Forms.CheckBox();
            this.grade4 = new System.Windows.Forms.CheckBox();
            this.grade3 = new System.Windows.Forms.CheckBox();
            this.grade2 = new System.Windows.Forms.CheckBox();
            this.grade1 = new System.Windows.Forms.CheckBox();
            this.grade0 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this._logGradeCodeTB = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this._logMatrixSpeciesCB = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.newLogSortDescription = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this._deleteLogMatrixBTN = new System.Windows.Forms.Button();
            this._clearLogMatrixBTN = new System.Windows.Forms.Button();
            this._addLogMatrixBTN = new System.Windows.Forms.Button();
            this._BS_LogMatrix = new System.Windows.Forms.BindingSource(this.components);
            this._logMatrixLayout.SuspendLayout();
            this.newParameters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // _logMatrixLayout
            // 
            this._logMatrixLayout.ColumnCount = 1;
            this._logMatrixLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._logMatrixLayout.Controls.Add(this.newParameters, 0, 0);
            this._logMatrixLayout.Controls.Add(this.dataGridView1, 0, 2);
            this._logMatrixLayout.Controls.Add(this.panel1, 0, 1);
            this._logMatrixLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logMatrixLayout.Location = new System.Drawing.Point(0, 0);
            this._logMatrixLayout.Margin = new System.Windows.Forms.Padding(4);
            this._logMatrixLayout.Name = "_logMatrixLayout";
            this._logMatrixLayout.RowCount = 3;
            this._logMatrixLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.01043F));
            this._logMatrixLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this._logMatrixLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.98957F));
            this._logMatrixLayout.Size = new System.Drawing.Size(837, 476);
            this._logMatrixLayout.TabIndex = 1;
            // 
            // newParameters
            // 
            this.newParameters.Controls.Add(this.groupBox1);
            this.newParameters.Controls.Add(this.label12);
            this.newParameters.Controls.Add(this.label11);
            this.newParameters.Controls.Add(this._descriptorCamprunRB);
            this.newParameters.Controls.Add(this._descriptorOrRB);
            this.newParameters.Controls.Add(this._descriptorAndRB);
            this.newParameters.Controls.Add(this._sedMaxTB);
            this.newParameters.Controls.Add(this._descriptor2);
            this.newParameters.Controls.Add(this._minSEDTB);
            this.newParameters.Controls.Add(this._descriptor1);
            this.newParameters.Controls.Add(this._sedLimitTB);
            this.newParameters.Controls.Add(this.label15);
            this.newParameters.Controls.Add(this.grade9);
            this.newParameters.Controls.Add(this.grade8);
            this.newParameters.Controls.Add(this.grade7);
            this.newParameters.Controls.Add(this.grade6);
            this.newParameters.Controls.Add(this.grade5);
            this.newParameters.Controls.Add(this.grade4);
            this.newParameters.Controls.Add(this.grade3);
            this.newParameters.Controls.Add(this.grade2);
            this.newParameters.Controls.Add(this.grade1);
            this.newParameters.Controls.Add(this.grade0);
            this.newParameters.Controls.Add(this.label16);
            this.newParameters.Controls.Add(this._logGradeCodeTB);
            this.newParameters.Controls.Add(this.label17);
            this.newParameters.Controls.Add(this._logMatrixSpeciesCB);
            this.newParameters.Controls.Add(this.label18);
            this.newParameters.Controls.Add(this.newLogSortDescription);
            this.newParameters.Controls.Add(this.label19);
            this.newParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newParameters.Enabled = false;
            this.newParameters.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newParameters.Location = new System.Drawing.Point(4, 4);
            this.newParameters.Margin = new System.Windows.Forms.Padding(4);
            this.newParameters.MinimumSize = new System.Drawing.Size(0, 246);
            this.newParameters.Name = "newParameters";
            this.newParameters.Padding = new System.Windows.Forms.Padding(4);
            this.newParameters.Size = new System.Drawing.Size(829, 248);
            this.newParameters.TabIndex = 3;
            this.newParameters.TabStop = false;
            this.newParameters.Text = "Parameters";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._r009RB);
            this.groupBox1.Controls.Add(this._r008RB);
            this.groupBox1.Location = new System.Drawing.Point(631, 172);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(188, 66);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report ID";
            // 
            // _r009RB
            // 
            this._r009RB.AutoSize = true;
            this._r009RB.Location = new System.Drawing.Point(91, 28);
            this._r009RB.Margin = new System.Windows.Forms.Padding(4);
            this._r009RB.Name = "_r009RB";
            this._r009RB.Size = new System.Drawing.Size(68, 23);
            this._r009RB.TabIndex = 35;
            this._r009RB.TabStop = true;
            this._r009RB.Text = "R009";
            this._r009RB.UseVisualStyleBackColor = true;
            this._r009RB.CheckedChanged += new System.EventHandler(this.ReportID_CheckedChanged);
            // 
            // _r008RB
            // 
            this._r008RB.AutoSize = true;
            this._r008RB.Location = new System.Drawing.Point(8, 28);
            this._r008RB.Margin = new System.Windows.Forms.Padding(4);
            this._r008RB.Name = "_r008RB";
            this._r008RB.Size = new System.Drawing.Size(68, 23);
            this._r008RB.TabIndex = 34;
            this._r008RB.TabStop = true;
            this._r008RB.Text = "R008";
            this._r008RB.UseVisualStyleBackColor = true;
            this._r008RB.CheckedChanged += new System.EventHandler(this.ReportID_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(491, 191);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 19);
            this.label12.TabIndex = 31;
            this.label12.Text = "Max";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(345, 191);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 19);
            this.label11.TabIndex = 30;
            this.label11.Text = "Min";
            // 
            // _descriptorCamprunRB
            // 
            this._descriptorCamprunRB.AutoSize = true;
            this._descriptorCamprunRB.Location = new System.Drawing.Point(297, 153);
            this._descriptorCamprunRB.Margin = new System.Windows.Forms.Padding(4);
            this._descriptorCamprunRB.Name = "_descriptorCamprunRB";
            this._descriptorCamprunRB.Size = new System.Drawing.Size(106, 23);
            this._descriptorCamprunRB.TabIndex = 29;
            this._descriptorCamprunRB.TabStop = true;
            this._descriptorCamprunRB.Text = "(camprun)";
            this._descriptorCamprunRB.UseVisualStyleBackColor = true;
            this._descriptorCamprunRB.CheckedChanged += new System.EventHandler(this.descriptor_CheckedChanged);
            // 
            // _descriptorOrRB
            // 
            this._descriptorOrRB.AutoSize = true;
            this._descriptorOrRB.Location = new System.Drawing.Point(240, 153);
            this._descriptorOrRB.Margin = new System.Windows.Forms.Padding(4);
            this._descriptorOrRB.Name = "_descriptorOrRB";
            this._descriptorOrRB.Size = new System.Drawing.Size(45, 23);
            this._descriptorOrRB.TabIndex = 28;
            this._descriptorOrRB.TabStop = true;
            this._descriptorOrRB.Text = "or";
            this._descriptorOrRB.UseVisualStyleBackColor = true;
            this._descriptorOrRB.CheckedChanged += new System.EventHandler(this.descriptor_CheckedChanged);
            // 
            // _descriptorAndRB
            // 
            this._descriptorAndRB.AutoSize = true;
            this._descriptorAndRB.Location = new System.Drawing.Point(185, 153);
            this._descriptorAndRB.Margin = new System.Windows.Forms.Padding(4);
            this._descriptorAndRB.Name = "_descriptorAndRB";
            this._descriptorAndRB.Size = new System.Drawing.Size(41, 23);
            this._descriptorAndRB.TabIndex = 27;
            this._descriptorAndRB.TabStop = true;
            this._descriptorAndRB.Text = "&&";
            this._descriptorAndRB.UseVisualStyleBackColor = true;
            this._descriptorAndRB.CheckedChanged += new System.EventHandler(this.descriptor_CheckedChanged);
            // 
            // _sedMaxTB
            // 
            this._sedMaxTB.Location = new System.Drawing.Point(495, 212);
            this._sedMaxTB.Margin = new System.Windows.Forms.Padding(4);
            this._sedMaxTB.Name = "_sedMaxTB";
            this._sedMaxTB.Size = new System.Drawing.Size(56, 26);
            this._sedMaxTB.TabIndex = 24;
            this._sedMaxTB.Validated += new System.EventHandler(this.sedLimmitSettingsChanged);
            // 
            // _descriptor2
            // 
            this._descriptor2.FormattingEnabled = true;
            this._descriptor2.Items.AddRange(new object[] {
            "",
            "thru ",
            "and",
            "+"});
            this._descriptor2.Location = new System.Drawing.Point(425, 212);
            this._descriptor2.Margin = new System.Windows.Forms.Padding(4);
            this._descriptor2.Name = "_descriptor2";
            this._descriptor2.Size = new System.Drawing.Size(59, 26);
            this._descriptor2.TabIndex = 23;
            this._descriptor2.TextChanged += new System.EventHandler(this.sedLimmitSettingsChanged);
            // 
            // _minSEDTB
            // 
            this._minSEDTB.Location = new System.Drawing.Point(345, 212);
            this._minSEDTB.Margin = new System.Windows.Forms.Padding(4);
            this._minSEDTB.Name = "_minSEDTB";
            this._minSEDTB.Size = new System.Drawing.Size(56, 26);
            this._minSEDTB.TabIndex = 22;
            this._minSEDTB.Validated += new System.EventHandler(this.sedLimmitSettingsChanged);
            // 
            // _descriptor1
            // 
            this._descriptor1.FormattingEnabled = true;
            this._descriptor1.Items.AddRange(new object[] {
            "",
            "greater than",
            "between",
            "less than"});
            this._descriptor1.Location = new System.Drawing.Point(224, 212);
            this._descriptor1.Margin = new System.Windows.Forms.Padding(4);
            this._descriptor1.Name = "_descriptor1";
            this._descriptor1.Size = new System.Drawing.Size(112, 26);
            this._descriptor1.TabIndex = 21;
            this._descriptor1.TextChanged += new System.EventHandler(this.sedLimmitSettingsChanged);
            // 
            // _sedLimitTB
            // 
            this._sedLimitTB.Location = new System.Drawing.Point(9, 214);
            this._sedLimitTB.Margin = new System.Windows.Forms.Padding(4);
            this._sedLimitTB.Name = "_sedLimitTB";
            this._sedLimitTB.ReadOnly = true;
            this._sedLimitTB.Size = new System.Drawing.Size(167, 26);
            this._sedLimitTB.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 191);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(153, 19);
            this.label15.TabIndex = 17;
            this.label15.Text = "Small End Diameter";
            // 
            // grade9
            // 
            this.grade9.AutoSize = true;
            this.grade9.Location = new System.Drawing.Point(665, 121);
            this.grade9.Margin = new System.Windows.Forms.Padding(4);
            this.grade9.Name = "grade9";
            this.grade9.Size = new System.Drawing.Size(40, 23);
            this.grade9.TabIndex = 16;
            this.grade9.Text = "9";
            this.grade9.UseVisualStyleBackColor = true;
            this.grade9.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade8
            // 
            this.grade8.AutoSize = true;
            this.grade8.Location = new System.Drawing.Point(612, 121);
            this.grade8.Margin = new System.Windows.Forms.Padding(4);
            this.grade8.Name = "grade8";
            this.grade8.Size = new System.Drawing.Size(40, 23);
            this.grade8.TabIndex = 15;
            this.grade8.Text = "8";
            this.grade8.UseVisualStyleBackColor = true;
            this.grade8.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade7
            // 
            this.grade7.AutoSize = true;
            this.grade7.Location = new System.Drawing.Point(559, 121);
            this.grade7.Margin = new System.Windows.Forms.Padding(4);
            this.grade7.Name = "grade7";
            this.grade7.Size = new System.Drawing.Size(40, 23);
            this.grade7.TabIndex = 14;
            this.grade7.Text = "7";
            this.grade7.UseVisualStyleBackColor = true;
            this.grade7.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade6
            // 
            this.grade6.AutoSize = true;
            this.grade6.Location = new System.Drawing.Point(505, 121);
            this.grade6.Margin = new System.Windows.Forms.Padding(4);
            this.grade6.Name = "grade6";
            this.grade6.Size = new System.Drawing.Size(40, 23);
            this.grade6.TabIndex = 13;
            this.grade6.Text = "6";
            this.grade6.UseVisualStyleBackColor = true;
            this.grade6.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade5
            // 
            this.grade5.AutoSize = true;
            this.grade5.Location = new System.Drawing.Point(452, 121);
            this.grade5.Margin = new System.Windows.Forms.Padding(4);
            this.grade5.Name = "grade5";
            this.grade5.Size = new System.Drawing.Size(40, 23);
            this.grade5.TabIndex = 12;
            this.grade5.Text = "5";
            this.grade5.UseVisualStyleBackColor = true;
            this.grade5.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade4
            // 
            this.grade4.AutoSize = true;
            this.grade4.Location = new System.Drawing.Point(399, 121);
            this.grade4.Margin = new System.Windows.Forms.Padding(4);
            this.grade4.Name = "grade4";
            this.grade4.Size = new System.Drawing.Size(40, 23);
            this.grade4.TabIndex = 11;
            this.grade4.Text = "4";
            this.grade4.UseVisualStyleBackColor = true;
            this.grade4.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade3
            // 
            this.grade3.AutoSize = true;
            this.grade3.Location = new System.Drawing.Point(345, 121);
            this.grade3.Margin = new System.Windows.Forms.Padding(4);
            this.grade3.Name = "grade3";
            this.grade3.Size = new System.Drawing.Size(40, 23);
            this.grade3.TabIndex = 10;
            this.grade3.Text = "3";
            this.grade3.UseVisualStyleBackColor = true;
            this.grade3.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade2
            // 
            this.grade2.AutoSize = true;
            this.grade2.Location = new System.Drawing.Point(292, 121);
            this.grade2.Margin = new System.Windows.Forms.Padding(4);
            this.grade2.Name = "grade2";
            this.grade2.Size = new System.Drawing.Size(40, 23);
            this.grade2.TabIndex = 9;
            this.grade2.Text = "2";
            this.grade2.UseVisualStyleBackColor = true;
            this.grade2.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade1
            // 
            this.grade1.AutoSize = true;
            this.grade1.Location = new System.Drawing.Point(239, 121);
            this.grade1.Margin = new System.Windows.Forms.Padding(4);
            this.grade1.Name = "grade1";
            this.grade1.Size = new System.Drawing.Size(40, 23);
            this.grade1.TabIndex = 8;
            this.grade1.Text = "1";
            this.grade1.UseVisualStyleBackColor = true;
            this.grade1.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // grade0
            // 
            this.grade0.AutoSize = true;
            this.grade0.Location = new System.Drawing.Point(185, 121);
            this.grade0.Margin = new System.Windows.Forms.Padding(4);
            this.grade0.Name = "grade0";
            this.grade0.Size = new System.Drawing.Size(40, 23);
            this.grade0.TabIndex = 7;
            this.grade0.Text = "0";
            this.grade0.UseVisualStyleBackColor = true;
            this.grade0.CheckedChanged += new System.EventHandler(this.grade_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(181, 92);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(552, 19);
            this.label16.TabIndex = 6;
            this.label16.Text = "Click on log grade(s) to include and any descriptor to use between grades.";
            // 
            // _logGradeCodeTB
            // 
            this._logGradeCodeTB.Location = new System.Drawing.Point(13, 118);
            this._logGradeCodeTB.Margin = new System.Windows.Forms.Padding(4);
            this._logGradeCodeTB.Name = "_logGradeCodeTB";
            this._logGradeCodeTB.ReadOnly = true;
            this._logGradeCodeTB.Size = new System.Drawing.Size(149, 26);
            this._logGradeCodeTB.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 92);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 19);
            this.label17.TabIndex = 4;
            this.label17.Text = "Log Grade Code";
            // 
            // _logMatrixSpeciesCB
            // 
            this._logMatrixSpeciesCB.Items.AddRange(new object[] {
            "042",
            "098",
            "242",
            "263",
            "098Y",
            "263Y"});
            this._logMatrixSpeciesCB.Location = new System.Drawing.Point(543, 49);
            this._logMatrixSpeciesCB.Margin = new System.Windows.Forms.Padding(4);
            this._logMatrixSpeciesCB.Name = "_logMatrixSpeciesCB";
            this._logMatrixSpeciesCB.Size = new System.Drawing.Size(73, 26);
            this._logMatrixSpeciesCB.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(539, 22);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 19);
            this.label18.TabIndex = 2;
            this.label18.Text = "Species";
            // 
            // newLogSortDescription
            // 
            this.newLogSortDescription.Location = new System.Drawing.Point(13, 52);
            this.newLogSortDescription.Margin = new System.Windows.Forms.Padding(4);
            this.newLogSortDescription.Name = "newLogSortDescription";
            this.newLogSortDescription.Size = new System.Drawing.Size(471, 26);
            this.newLogSortDescription.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 22);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(159, 19);
            this.label19.TabIndex = 0;
            this.label19.Text = "Log Sort Description";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 286);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.Size = new System.Drawing.Size(829, 186);
            this.dataGridView1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._deleteLogMatrixBTN);
            this.panel1.Controls.Add(this._clearLogMatrixBTN);
            this.panel1.Controls.Add(this._addLogMatrixBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 256);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 26);
            this.panel1.TabIndex = 5;
            // 
            // _deleteLogMatrixBTN
            // 
            this._deleteLogMatrixBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this._deleteLogMatrixBTN.Location = new System.Drawing.Point(637, 0);
            this._deleteLogMatrixBTN.Margin = new System.Windows.Forms.Padding(4);
            this._deleteLogMatrixBTN.Name = "_deleteLogMatrixBTN";
            this._deleteLogMatrixBTN.Size = new System.Drawing.Size(100, 26);
            this._deleteLogMatrixBTN.TabIndex = 2;
            this._deleteLogMatrixBTN.Text = "Delete";
            this._deleteLogMatrixBTN.UseVisualStyleBackColor = true;
            this._deleteLogMatrixBTN.Click += new System.EventHandler(this._deleteLogMatrixBTN_Click);
            // 
            // _clearLogMatrixBTN
            // 
            this._clearLogMatrixBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this._clearLogMatrixBTN.Location = new System.Drawing.Point(737, 0);
            this._clearLogMatrixBTN.Margin = new System.Windows.Forms.Padding(4);
            this._clearLogMatrixBTN.Name = "_clearLogMatrixBTN";
            this._clearLogMatrixBTN.Size = new System.Drawing.Size(100, 26);
            this._clearLogMatrixBTN.TabIndex = 1;
            this._clearLogMatrixBTN.Text = "Clear All";
            this._clearLogMatrixBTN.UseVisualStyleBackColor = true;
            this._clearLogMatrixBTN.Click += new System.EventHandler(this._clearLogMatrixBTN_Click);
            // 
            // _addLogMatrixBTN
            // 
            this._addLogMatrixBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this._addLogMatrixBTN.Location = new System.Drawing.Point(0, 0);
            this._addLogMatrixBTN.Margin = new System.Windows.Forms.Padding(4);
            this._addLogMatrixBTN.Name = "_addLogMatrixBTN";
            this._addLogMatrixBTN.Size = new System.Drawing.Size(100, 26);
            this._addLogMatrixBTN.TabIndex = 0;
            this._addLogMatrixBTN.Text = "Add";
            this._addLogMatrixBTN.UseVisualStyleBackColor = true;
            this._addLogMatrixBTN.Click += new System.EventHandler(this._addLogMatrixBTN_Click);
            // 
            // _BS_LogMatrix
            // 
            this._BS_LogMatrix.DataSource = typeof(CruiseDAL.DataObjects.LogMatrixDO);
            this._BS_LogMatrix.CurrentChanged += new System.EventHandler(this._BS_LogMatrix_CurrentChanged);
            // 
            // LogMatrixSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._logMatrixLayout);
            this.Name = "LogMatrixSettingsView";
            this.Size = new System.Drawing.Size(837, 476);
            this._logMatrixLayout.ResumeLayout(false);
            this.newParameters.ResumeLayout(false);
            this.newParameters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogMatrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _logMatrixLayout;
        private System.Windows.Forms.GroupBox newParameters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _r009RB;
        private System.Windows.Forms.RadioButton _r008RB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton _descriptorCamprunRB;
        private System.Windows.Forms.RadioButton _descriptorOrRB;
        private System.Windows.Forms.RadioButton _descriptorAndRB;
        private System.Windows.Forms.TextBox _sedMaxTB;
        private System.Windows.Forms.ComboBox _descriptor2;
        private System.Windows.Forms.TextBox _minSEDTB;
        private System.Windows.Forms.ComboBox _descriptor1;
        private System.Windows.Forms.TextBox _sedLimitTB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox grade9;
        private System.Windows.Forms.CheckBox grade8;
        private System.Windows.Forms.CheckBox grade7;
        private System.Windows.Forms.CheckBox grade6;
        private System.Windows.Forms.CheckBox grade5;
        private System.Windows.Forms.CheckBox grade4;
        private System.Windows.Forms.CheckBox grade3;
        private System.Windows.Forms.CheckBox grade2;
        private System.Windows.Forms.CheckBox grade1;
        private System.Windows.Forms.CheckBox grade0;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox _logGradeCodeTB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox _logMatrixSpeciesCB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox newLogSortDescription;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _deleteLogMatrixBTN;
        private System.Windows.Forms.Button _clearLogMatrixBTN;
        private System.Windows.Forms.Button _addLogMatrixBTN;
        private System.Windows.Forms.BindingSource _BS_LogMatrix;
    }
}
