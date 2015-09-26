namespace CruiseManager.Winforms.CruiseCustomize
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._logMatrixLayout = new System.Windows.Forms.TableLayoutPanel();
            this.newParameters = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this._deleteLogMatrixBTN = new System.Windows.Forms.Button();
            this._clearLogMatrixBTN = new System.Windows.Forms.Button();
            this._addLogMatrixBTN = new System.Windows.Forms.Button();
            this._BS_LogMatrix = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this._logMatrixSpeciesCB = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.newLogSortDescription = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this._logGradeCodeTB = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this._descriptorCamprunRB = new System.Windows.Forms.RadioButton();
            this._descriptorOrRB = new System.Windows.Forms.RadioButton();
            this._descriptorAndRB = new System.Windows.Forms.RadioButton();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._sedMaxTB = new System.Windows.Forms.TextBox();
            this._descriptor2 = new System.Windows.Forms.ComboBox();
            this._minSEDTB = new System.Windows.Forms.TextBox();
            this._descriptor1 = new System.Windows.Forms.ComboBox();
            this._sedLimitTB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._r009RB = new System.Windows.Forms.RadioButton();
            this._r008RB = new System.Windows.Forms.RadioButton();
            this._logMatrixLayout.SuspendLayout();
            this.newParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogMatrix)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _logMatrixLayout
            // 
            this._logMatrixLayout.AutoSize = true;
            this._logMatrixLayout.ColumnCount = 1;
            this._logMatrixLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._logMatrixLayout.Controls.Add(this.newParameters, 0, 0);
            this._logMatrixLayout.Controls.Add(this.dataGridView1, 0, 2);
            this._logMatrixLayout.Controls.Add(this.panel1, 0, 1);
            this._logMatrixLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logMatrixLayout.Location = new System.Drawing.Point(0, 0);
            this._logMatrixLayout.Name = "_logMatrixLayout";
            this._logMatrixLayout.RowCount = 3;
            this._logMatrixLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._logMatrixLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this._logMatrixLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._logMatrixLayout.Size = new System.Drawing.Size(655, 497);
            this._logMatrixLayout.TabIndex = 1;
            // 
            // newParameters
            // 
            this.newParameters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newParameters.Controls.Add(this.flowLayoutPanel1);
            this.newParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newParameters.Enabled = false;
            this.newParameters.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newParameters.Location = new System.Drawing.Point(3, 3);
            this.newParameters.Name = "newParameters";
            this.newParameters.Size = new System.Drawing.Size(649, 313);
            this.newParameters.TabIndex = 3;
            this.newParameters.TabStop = false;
            this.newParameters.Text = "Parameters";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 343);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(649, 151);
            this.dataGridView1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._deleteLogMatrixBTN);
            this.panel1.Controls.Add(this._clearLogMatrixBTN);
            this.panel1.Controls.Add(this._addLogMatrixBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 319);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 21);
            this.panel1.TabIndex = 5;
            // 
            // _deleteLogMatrixBTN
            // 
            this._deleteLogMatrixBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this._deleteLogMatrixBTN.Location = new System.Drawing.Point(505, 0);
            this._deleteLogMatrixBTN.Name = "_deleteLogMatrixBTN";
            this._deleteLogMatrixBTN.Size = new System.Drawing.Size(75, 21);
            this._deleteLogMatrixBTN.TabIndex = 2;
            this._deleteLogMatrixBTN.Text = "Delete";
            this._deleteLogMatrixBTN.UseVisualStyleBackColor = true;
            this._deleteLogMatrixBTN.Click += new System.EventHandler(this._deleteLogMatrixBTN_Click);
            // 
            // _clearLogMatrixBTN
            // 
            this._clearLogMatrixBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this._clearLogMatrixBTN.Location = new System.Drawing.Point(580, 0);
            this._clearLogMatrixBTN.Name = "_clearLogMatrixBTN";
            this._clearLogMatrixBTN.Size = new System.Drawing.Size(75, 21);
            this._clearLogMatrixBTN.TabIndex = 1;
            this._clearLogMatrixBTN.Text = "Clear All";
            this._clearLogMatrixBTN.UseVisualStyleBackColor = true;
            this._clearLogMatrixBTN.Click += new System.EventHandler(this._clearLogMatrixBTN_Click);
            // 
            // _addLogMatrixBTN
            // 
            this._addLogMatrixBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this._addLogMatrixBTN.Location = new System.Drawing.Point(0, 0);
            this._addLogMatrixBTN.Name = "_addLogMatrixBTN";
            this._addLogMatrixBTN.Size = new System.Drawing.Size(75, 21);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(643, 292);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this._logMatrixSpeciesCB);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.newLogSortDescription);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(471, 56);
            this.panel5.TabIndex = 41;
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
            this._logMatrixSpeciesCB.Location = new System.Drawing.Point(404, 22);
            this._logMatrixSpeciesCB.Name = "_logMatrixSpeciesCB";
            this._logMatrixSpeciesCB.Size = new System.Drawing.Size(56, 24);
            this._logMatrixSpeciesCB.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(401, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 16);
            this.label18.TabIndex = 6;
            this.label18.Text = "Species";
            // 
            // newLogSortDescription
            // 
            this.newLogSortDescription.Location = new System.Drawing.Point(7, 24);
            this.newLogSortDescription.Name = "newLogSortDescription";
            this.newLogSortDescription.Size = new System.Drawing.Size(354, 22);
            this.newLogSortDescription.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 16);
            this.label19.TabIndex = 4;
            this.label19.Text = "Log Sort Description";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._logGradeCodeTB);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Location = new System.Drawing.Point(480, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(133, 62);
            this.panel4.TabIndex = 40;
            // 
            // _logGradeCodeTB
            // 
            this._logGradeCodeTB.Location = new System.Drawing.Point(15, 28);
            this._logGradeCodeTB.Name = "_logGradeCodeTB";
            this._logGradeCodeTB.ReadOnly = true;
            this._logGradeCodeTB.Size = new System.Drawing.Size(113, 22);
            this._logGradeCodeTB.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 7);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 16);
            this.label17.TabIndex = 6;
            this.label17.Text = "Log Grade Code";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._descriptorCamprunRB);
            this.panel3.Controls.Add(this._descriptorOrRB);
            this.panel3.Controls.Add(this._descriptorAndRB);
            this.panel3.Controls.Add(this.grade9);
            this.panel3.Controls.Add(this.grade8);
            this.panel3.Controls.Add(this.grade7);
            this.panel3.Controls.Add(this.grade6);
            this.panel3.Controls.Add(this.grade5);
            this.panel3.Controls.Add(this.grade4);
            this.panel3.Controls.Add(this.grade3);
            this.panel3.Controls.Add(this.grade2);
            this.panel3.Controls.Add(this.grade1);
            this.panel3.Controls.Add(this.grade0);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Location = new System.Drawing.Point(3, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 87);
            this.panel3.TabIndex = 39;
            // 
            // _descriptorCamprunRB
            // 
            this._descriptorCamprunRB.AutoSize = true;
            this._descriptorCamprunRB.Location = new System.Drawing.Point(90, 59);
            this._descriptorCamprunRB.Name = "_descriptorCamprunRB";
            this._descriptorCamprunRB.Size = new System.Drawing.Size(84, 20);
            this._descriptorCamprunRB.TabIndex = 43;
            this._descriptorCamprunRB.TabStop = true;
            this._descriptorCamprunRB.Text = "(camprun)";
            this._descriptorCamprunRB.UseVisualStyleBackColor = true;
            // 
            // _descriptorOrRB
            // 
            this._descriptorOrRB.AutoSize = true;
            this._descriptorOrRB.Location = new System.Drawing.Point(47, 59);
            this._descriptorOrRB.Name = "_descriptorOrRB";
            this._descriptorOrRB.Size = new System.Drawing.Size(37, 20);
            this._descriptorOrRB.TabIndex = 42;
            this._descriptorOrRB.TabStop = true;
            this._descriptorOrRB.Text = "or";
            this._descriptorOrRB.UseVisualStyleBackColor = true;
            // 
            // _descriptorAndRB
            // 
            this._descriptorAndRB.AutoSize = true;
            this._descriptorAndRB.Location = new System.Drawing.Point(6, 59);
            this._descriptorAndRB.Name = "_descriptorAndRB";
            this._descriptorAndRB.Size = new System.Drawing.Size(35, 20);
            this._descriptorAndRB.TabIndex = 41;
            this._descriptorAndRB.TabStop = true;
            this._descriptorAndRB.Text = "&&";
            this._descriptorAndRB.UseVisualStyleBackColor = true;
            // 
            // grade9
            // 
            this.grade9.AutoSize = true;
            this.grade9.Location = new System.Drawing.Point(366, 33);
            this.grade9.Name = "grade9";
            this.grade9.Size = new System.Drawing.Size(34, 20);
            this.grade9.TabIndex = 40;
            this.grade9.Text = "9";
            this.grade9.UseVisualStyleBackColor = true;
            // 
            // grade8
            // 
            this.grade8.AutoSize = true;
            this.grade8.Location = new System.Drawing.Point(326, 33);
            this.grade8.Name = "grade8";
            this.grade8.Size = new System.Drawing.Size(34, 20);
            this.grade8.TabIndex = 39;
            this.grade8.Text = "8";
            this.grade8.UseVisualStyleBackColor = true;
            // 
            // grade7
            // 
            this.grade7.AutoSize = true;
            this.grade7.Location = new System.Drawing.Point(286, 33);
            this.grade7.Name = "grade7";
            this.grade7.Size = new System.Drawing.Size(34, 20);
            this.grade7.TabIndex = 38;
            this.grade7.Text = "7";
            this.grade7.UseVisualStyleBackColor = true;
            // 
            // grade6
            // 
            this.grade6.AutoSize = true;
            this.grade6.Location = new System.Drawing.Point(246, 33);
            this.grade6.Name = "grade6";
            this.grade6.Size = new System.Drawing.Size(34, 20);
            this.grade6.TabIndex = 37;
            this.grade6.Text = "6";
            this.grade6.UseVisualStyleBackColor = true;
            // 
            // grade5
            // 
            this.grade5.AutoSize = true;
            this.grade5.Location = new System.Drawing.Point(206, 33);
            this.grade5.Name = "grade5";
            this.grade5.Size = new System.Drawing.Size(34, 20);
            this.grade5.TabIndex = 36;
            this.grade5.Text = "5";
            this.grade5.UseVisualStyleBackColor = true;
            // 
            // grade4
            // 
            this.grade4.AutoSize = true;
            this.grade4.Location = new System.Drawing.Point(166, 33);
            this.grade4.Name = "grade4";
            this.grade4.Size = new System.Drawing.Size(34, 20);
            this.grade4.TabIndex = 35;
            this.grade4.Text = "4";
            this.grade4.UseVisualStyleBackColor = true;
            // 
            // grade3
            // 
            this.grade3.AutoSize = true;
            this.grade3.Location = new System.Drawing.Point(126, 33);
            this.grade3.Name = "grade3";
            this.grade3.Size = new System.Drawing.Size(34, 20);
            this.grade3.TabIndex = 34;
            this.grade3.Text = "3";
            this.grade3.UseVisualStyleBackColor = true;
            // 
            // grade2
            // 
            this.grade2.AutoSize = true;
            this.grade2.Location = new System.Drawing.Point(86, 33);
            this.grade2.Name = "grade2";
            this.grade2.Size = new System.Drawing.Size(34, 20);
            this.grade2.TabIndex = 33;
            this.grade2.Text = "2";
            this.grade2.UseVisualStyleBackColor = true;
            // 
            // grade1
            // 
            this.grade1.AutoSize = true;
            this.grade1.Location = new System.Drawing.Point(46, 33);
            this.grade1.Name = "grade1";
            this.grade1.Size = new System.Drawing.Size(34, 20);
            this.grade1.TabIndex = 32;
            this.grade1.Text = "1";
            this.grade1.UseVisualStyleBackColor = true;
            // 
            // grade0
            // 
            this.grade0.AutoSize = true;
            this.grade0.Location = new System.Drawing.Point(6, 33);
            this.grade0.Name = "grade0";
            this.grade0.Size = new System.Drawing.Size(34, 20);
            this.grade0.TabIndex = 31;
            this.grade0.Text = "0";
            this.grade0.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(437, 16);
            this.label16.TabIndex = 30;
            this.label16.Text = "Click on log grade(s) to include and any descriptor to use between grades.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this._sedMaxTB);
            this.panel2.Controls.Add(this._descriptor2);
            this.panel2.Controls.Add(this._minSEDTB);
            this.panel2.Controls.Add(this._descriptor1);
            this.panel2.Controls.Add(this._sedLimitTB);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(3, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 57);
            this.panel2.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(349, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 16);
            this.label12.TabIndex = 39;
            this.label12.Text = "Max";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 16);
            this.label11.TabIndex = 38;
            this.label11.Text = "Min";
            // 
            // _sedMaxTB
            // 
            this._sedMaxTB.Location = new System.Drawing.Point(352, 21);
            this._sedMaxTB.Name = "_sedMaxTB";
            this._sedMaxTB.Size = new System.Drawing.Size(43, 22);
            this._sedMaxTB.TabIndex = 37;
            // 
            // _descriptor2
            // 
            this._descriptor2.FormattingEnabled = true;
            this._descriptor2.Items.AddRange(new object[] {
            "",
            "thru ",
            "and",
            "+"});
            this._descriptor2.Location = new System.Drawing.Point(302, 21);
            this._descriptor2.Name = "_descriptor2";
            this._descriptor2.Size = new System.Drawing.Size(45, 24);
            this._descriptor2.TabIndex = 36;
            // 
            // _minSEDTB
            // 
            this._minSEDTB.Location = new System.Drawing.Point(241, 21);
            this._minSEDTB.Name = "_minSEDTB";
            this._minSEDTB.Size = new System.Drawing.Size(43, 22);
            this._minSEDTB.TabIndex = 35;
            // 
            // _descriptor1
            // 
            this._descriptor1.FormattingEnabled = true;
            this._descriptor1.Items.AddRange(new object[] {
            "",
            "greater than",
            "between",
            "less than"});
            this._descriptor1.Location = new System.Drawing.Point(150, 21);
            this._descriptor1.Name = "_descriptor1";
            this._descriptor1.Size = new System.Drawing.Size(85, 24);
            this._descriptor1.TabIndex = 34;
            // 
            // _sedLimitTB
            // 
            this._sedLimitTB.Location = new System.Drawing.Point(3, 23);
            this._sedLimitTB.Name = "_sedLimitTB";
            this._sedLimitTB.ReadOnly = true;
            this._sedLimitTB.Size = new System.Drawing.Size(126, 22);
            this._sedLimitTB.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 16);
            this.label15.TabIndex = 32;
            this.label15.Text = "Small End Diameter";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._r009RB);
            this.groupBox1.Controls.Add(this._r008RB);
            this.groupBox1.Location = new System.Drawing.Point(408, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 54);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report ID";
            // 
            // _r009RB
            // 
            this._r009RB.AutoSize = true;
            this._r009RB.Location = new System.Drawing.Point(68, 23);
            this._r009RB.Name = "_r009RB";
            this._r009RB.Size = new System.Drawing.Size(56, 20);
            this._r009RB.TabIndex = 35;
            this._r009RB.TabStop = true;
            this._r009RB.Text = "R009";
            this._r009RB.UseVisualStyleBackColor = true;
            // 
            // _r008RB
            // 
            this._r008RB.AutoSize = true;
            this._r008RB.Location = new System.Drawing.Point(6, 23);
            this._r008RB.Name = "_r008RB";
            this._r008RB.Size = new System.Drawing.Size(56, 20);
            this._r008RB.TabIndex = 34;
            this._r008RB.TabStop = true;
            this._r008RB.Text = "R008";
            this._r008RB.UseVisualStyleBackColor = true;
            // 
            // LogMatrixSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this._logMatrixLayout);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(628, 280);
            this.Name = "LogMatrixSettingsView";
            this.Size = new System.Drawing.Size(655, 497);
            this._logMatrixLayout.ResumeLayout(false);
            this.newParameters.ResumeLayout(false);
            this.newParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogMatrix)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _logMatrixLayout;
        private System.Windows.Forms.GroupBox newParameters;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _deleteLogMatrixBTN;
        private System.Windows.Forms.Button _clearLogMatrixBTN;
        private System.Windows.Forms.Button _addLogMatrixBTN;
        private System.Windows.Forms.BindingSource _BS_LogMatrix;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox _logMatrixSpeciesCB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox newLogSortDescription;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox _logGradeCodeTB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton _descriptorCamprunRB;
        private System.Windows.Forms.RadioButton _descriptorOrRB;
        private System.Windows.Forms.RadioButton _descriptorAndRB;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _sedMaxTB;
        private System.Windows.Forms.ComboBox _descriptor2;
        private System.Windows.Forms.TextBox _minSEDTB;
        private System.Windows.Forms.ComboBox _descriptor1;
        private System.Windows.Forms.TextBox _sedLimitTB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _r009RB;
        private System.Windows.Forms.RadioButton _r008RB;
    }
}
