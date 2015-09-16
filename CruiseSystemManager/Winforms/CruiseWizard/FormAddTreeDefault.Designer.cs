namespace CSM.Winforms.CruiseWizard
{
    partial class FormAddTreeDefault
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
            System.Windows.Forms.Panel _cullPPanel;
            this._cullPTB = new System.Windows.Forms.TextBox();
            this._BS_TDV = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this._speciesPanel = new System.Windows.Forms.Panel();
            this._speciesTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._PProdPanel = new System.Windows.Forms.Panel();
            this._PProdCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._LiveDeadPanel = new System.Windows.Forms.Panel();
            this._LiveDeadTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._hiddenPTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._cullSTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this._hiddenSTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this._RecoverableTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this._contractSpTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this._treeGradeTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this._merchHghtLLTB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this._formClassTB = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this._BTRTB = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this._aveZTB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this._refHghtTB = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this._okBTN = new System.Windows.Forms.Button();
            this._cancelBTN = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this._FiaCodeTB = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            _cullPPanel = new System.Windows.Forms.Panel();
            _cullPPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TDV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel14.SuspendLayout();
            this._speciesPanel.SuspendLayout();
            this._PProdPanel.SuspendLayout();
            this._LiveDeadPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cullPPanel
            // 
            _cullPPanel.Controls.Add(this._cullPTB);
            _cullPPanel.Controls.Add(this.label4);
            _cullPPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _cullPPanel.Location = new System.Drawing.Point(0, 21);
            _cullPPanel.Margin = new System.Windows.Forms.Padding(0);
            _cullPPanel.Name = "_cullPPanel";
            _cullPPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            _cullPPanel.Size = new System.Drawing.Size(138, 27);
            _cullPPanel.TabIndex = 3;
            // 
            // _cullPTB
            // 
            this._cullPTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CullPrimary", true));
            this._cullPTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cullPTB.Location = new System.Drawing.Point(62, 3);
            this._cullPTB.Multiline = true;
            this._cullPTB.Name = "_cullPTB";
            this._cullPTB.Size = new System.Drawing.Size(76, 21);
            this._cullPTB.TabIndex = 0;
            // 
            // _BS_TDV
            // 
            this._BS_TDV.DataSource = typeof(CruiseDAL.DataObjects.TreeDefaultValueDO);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cull Primary";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel1.Controls.Add(this.panel14, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this._speciesPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._PProdPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._LiveDeadPanel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(_cullPPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this._okBTN, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this._cancelBTN, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel13, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 255);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.textBox1);
            this.panel14.Controls.Add(this.label17);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(335, 104);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel14.Size = new System.Drawing.Size(164, 26);
            this.panel14.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "MerchHeightType", true));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(128, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(0, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Merch Height Type";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _speciesPanel
            // 
            this._speciesPanel.Controls.Add(this._speciesTB);
            this._speciesPanel.Controls.Add(this.label1);
            this._speciesPanel.Location = new System.Drawing.Point(0, 0);
            this._speciesPanel.Margin = new System.Windows.Forms.Padding(0);
            this._speciesPanel.Name = "_speciesPanel";
            this._speciesPanel.Size = new System.Drawing.Size(138, 20);
            this._speciesPanel.TabIndex = 0;
            // 
            // _speciesTB
            // 
            this._speciesTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "Species", true));
            this._speciesTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._speciesTB.Location = new System.Drawing.Point(62, 0);
            this._speciesTB.Name = "_speciesTB";
            this._speciesTB.Size = new System.Drawing.Size(76, 20);
            this._speciesTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Species";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _PProdPanel
            // 
            this._PProdPanel.Controls.Add(this._PProdCB);
            this._PProdPanel.Controls.Add(this.label2);
            this._PProdPanel.Location = new System.Drawing.Point(138, 0);
            this._PProdPanel.Margin = new System.Windows.Forms.Padding(0);
            this._PProdPanel.Name = "_PProdPanel";
            this._PProdPanel.Size = new System.Drawing.Size(196, 21);
            this._PProdPanel.TabIndex = 1;
            // 
            // _PProdCB
            // 
            this._PProdCB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this._BS_TDV, "PrimaryProduct", true));
            this._PProdCB.DisplayMember = "FriendlyValue";
            this._PProdCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._PProdCB.FormattingEnabled = true;
            this._PProdCB.Location = new System.Drawing.Point(91, 0);
            this._PProdCB.Name = "_PProdCB";
            this._PProdCB.Size = new System.Drawing.Size(105, 21);
            this._PProdCB.TabIndex = 0;
            this._PProdCB.ValueMember = "Code";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Primary Product";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _LiveDeadPanel
            // 
            this._LiveDeadPanel.Controls.Add(this._LiveDeadTB);
            this._LiveDeadPanel.Controls.Add(this.label3);
            this._LiveDeadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LiveDeadPanel.Location = new System.Drawing.Point(335, 0);
            this._LiveDeadPanel.Margin = new System.Windows.Forms.Padding(0);
            this._LiveDeadPanel.Name = "_LiveDeadPanel";
            this._LiveDeadPanel.Size = new System.Drawing.Size(164, 21);
            this._LiveDeadPanel.TabIndex = 2;
            // 
            // _LiveDeadTB
            // 
            this._LiveDeadTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "LiveDead", true));
            this._LiveDeadTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._LiveDeadTB.Location = new System.Drawing.Point(56, 0);
            this._LiveDeadTB.Name = "_LiveDeadTB";
            this._LiveDeadTB.Size = new System.Drawing.Size(108, 20);
            this._LiveDeadTB.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Live Dead";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._hiddenPTB);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(138, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel1.Size = new System.Drawing.Size(197, 27);
            this.panel1.TabIndex = 4;
            // 
            // _hiddenPTB
            // 
            this._hiddenPTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "HiddenPrimary", true));
            this._hiddenPTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._hiddenPTB.Location = new System.Drawing.Point(91, 3);
            this._hiddenPTB.Multiline = true;
            this._hiddenPTB.Name = "_hiddenPTB";
            this._hiddenPTB.Size = new System.Drawing.Size(106, 21);
            this._hiddenPTB.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hidden Primary";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._cullSTB);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel2.Size = new System.Drawing.Size(138, 28);
            this.panel2.TabIndex = 6;
            // 
            // _cullSTB
            // 
            this._cullSTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CullSecondary", true));
            this._cullSTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cullSTB.Location = new System.Drawing.Point(78, 3);
            this._cullSTB.Multiline = true;
            this._cullSTB.Name = "_cullSTB";
            this._cullSTB.Size = new System.Drawing.Size(60, 22);
            this._cullSTB.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cull Secondary";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._hiddenSTB);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(138, 48);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel3.Size = new System.Drawing.Size(196, 28);
            this.panel3.TabIndex = 7;
            // 
            // _hiddenSTB
            // 
            this._hiddenSTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "HiddenSecondary", true));
            this._hiddenSTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._hiddenSTB.Location = new System.Drawing.Point(95, 3);
            this._hiddenSTB.Multiline = true;
            this._hiddenSTB.Name = "_hiddenSTB";
            this._hiddenSTB.Size = new System.Drawing.Size(101, 22);
            this._hiddenSTB.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hidden Secondary";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._RecoverableTB);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(0, 76);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel4.Size = new System.Drawing.Size(138, 28);
            this.panel4.TabIndex = 8;
            // 
            // _RecoverableTB
            // 
            this._RecoverableTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "Recoverable", true));
            this._RecoverableTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._RecoverableTB.Location = new System.Drawing.Point(72, 3);
            this._RecoverableTB.Name = "_RecoverableTB";
            this._RecoverableTB.Size = new System.Drawing.Size(66, 20);
            this._RecoverableTB.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Recoverable";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(138, 76);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel5.Size = new System.Drawing.Size(196, 28);
            this.panel5.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this._contractSpTB);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(335, 76);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel6.Size = new System.Drawing.Size(164, 28);
            this.panel6.TabIndex = 10;
            // 
            // _contractSpTB
            // 
            this._contractSpTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "ContractSpecies", true));
            this._contractSpTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contractSpTB.Location = new System.Drawing.Point(104, 3);
            this._contractSpTB.Name = "_contractSpTB";
            this._contractSpTB.Size = new System.Drawing.Size(60, 20);
            this._contractSpTB.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 22);
            this.label10.TabIndex = 0;
            this.label10.Text = "Contract Species";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this._treeGradeTB);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 104);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel7.Size = new System.Drawing.Size(138, 26);
            this.panel7.TabIndex = 11;
            // 
            // _treeGradeTB
            // 
            this._treeGradeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "TreeGrade", true));
            this._treeGradeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeGradeTB.Location = new System.Drawing.Point(72, 3);
            this._treeGradeTB.Name = "_treeGradeTB";
            this._treeGradeTB.Size = new System.Drawing.Size(66, 20);
            this._treeGradeTB.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(0, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tree Grade";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this._merchHghtLLTB);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(138, 104);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel8.Size = new System.Drawing.Size(197, 26);
            this.panel8.TabIndex = 12;
            // 
            // _merchHghtLLTB
            // 
            this._merchHghtLLTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "MerchHeightLogLength", true));
            this._merchHghtLLTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._merchHghtLLTB.Location = new System.Drawing.Point(128, 3);
            this._merchHghtLLTB.Name = "_merchHghtLLTB";
            this._merchHghtLLTB.Size = new System.Drawing.Size(69, 20);
            this._merchHghtLLTB.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(0, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Merch Height Log Length";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this._formClassTB);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Location = new System.Drawing.Point(0, 130);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel9.Size = new System.Drawing.Size(138, 26);
            this.panel9.TabIndex = 14;
            // 
            // _formClassTB
            // 
            this._formClassTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "FormClass", true));
            this._formClassTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._formClassTB.Location = new System.Drawing.Point(104, 3);
            this._formClassTB.Name = "_formClassTB";
            this._formClassTB.Size = new System.Drawing.Size(34, 20);
            this._formClassTB.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Location = new System.Drawing.Point(0, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Form Class";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this._BTRTB);
            this.panel10.Controls.Add(this.label14);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(335, 130);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel10.Size = new System.Drawing.Size(164, 28);
            this.panel10.TabIndex = 16;
            // 
            // _BTRTB
            // 
            this._BTRTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "BarkThicknessRatio", true));
            this._BTRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._BTRTB.Location = new System.Drawing.Point(128, 3);
            this._BTRTB.Name = "_BTRTB";
            this._BTRTB.Size = new System.Drawing.Size(36, 20);
            this._BTRTB.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(0, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 22);
            this.label14.TabIndex = 0;
            this.label14.Text = "Bark Thickness Ratio";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this._aveZTB);
            this.panel11.Controls.Add(this.label15);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(138, 130);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel11.Size = new System.Drawing.Size(197, 28);
            this.panel11.TabIndex = 15;
            // 
            // _aveZTB
            // 
            this._aveZTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "AverageZ", true));
            this._aveZTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._aveZTB.Location = new System.Drawing.Point(72, 3);
            this._aveZTB.Name = "_aveZTB";
            this._aveZTB.Size = new System.Drawing.Size(125, 20);
            this._aveZTB.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Location = new System.Drawing.Point(0, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 22);
            this.label15.TabIndex = 0;
            this.label15.Text = "Average Z";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this._refHghtTB);
            this.panel12.Controls.Add(this.label16);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 158);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel12.Size = new System.Drawing.Size(138, 26);
            this.panel12.TabIndex = 17;
            // 
            // _refHghtTB
            // 
            this._refHghtTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "ReferenceHeightPercent", true));
            this._refHghtTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._refHghtTB.Location = new System.Drawing.Point(104, 3);
            this._refHghtTB.Name = "_refHghtTB";
            this._refHghtTB.Size = new System.Drawing.Size(34, 20);
            this._refHghtTB.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(0, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Reference Height %";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _okBTN
            // 
            this._okBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this._okBTN.Location = new System.Drawing.Point(421, 225);
            this._okBTN.Name = "_okBTN";
            this._okBTN.Size = new System.Drawing.Size(75, 27);
            this._okBTN.TabIndex = 18;
            this._okBTN.Text = "OK";
            this._okBTN.UseVisualStyleBackColor = true;
            this._okBTN.Click += new System.EventHandler(this._okBTN_Click);
            // 
            // _cancelBTN
            // 
            this._cancelBTN.Location = new System.Drawing.Point(3, 225);
            this._cancelBTN.Name = "_cancelBTN";
            this._cancelBTN.Size = new System.Drawing.Size(75, 22);
            this._cancelBTN.TabIndex = 19;
            this._cancelBTN.Text = "Cancel";
            this._cancelBTN.UseVisualStyleBackColor = true;
            this._cancelBTN.Click += new System.EventHandler(this._cancelBTN_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this._FiaCodeTB);
            this.panel13.Controls.Add(this.label18);
            this.panel13.Location = new System.Drawing.Point(337, 23);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(160, 22);
            this.panel13.TabIndex = 5;
            // 
            // _FiaCodeTB
            // 
            this._FiaCodeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "FIAcode", true));
            this._FiaCodeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._FiaCodeTB.Location = new System.Drawing.Point(54, 0);
            this._FiaCodeTB.Margin = new System.Windows.Forms.Padding(2);
            this._FiaCodeTB.Name = "_FiaCodeTB";
            this._FiaCodeTB.Size = new System.Drawing.Size(106, 20);
            this._FiaCodeTB.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 22);
            this.label18.TabIndex = 1;
            this.label18.Text = "FIACode";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAddTreeDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 255);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddTreeDefault";
            _cullPPanel.ResumeLayout(false);
            _cullPPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TDV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this._speciesPanel.ResumeLayout(false);
            this._speciesPanel.PerformLayout();
            this._PProdPanel.ResumeLayout(false);
            this._LiveDeadPanel.ResumeLayout(false);
            this._LiveDeadPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel _speciesPanel;
        private System.Windows.Forms.TextBox _speciesTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _PProdPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _PProdCB;
        private System.Windows.Forms.Panel _LiveDeadPanel;
        private System.Windows.Forms.TextBox _LiveDeadTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _cullPTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox _hiddenPTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _cullSTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox _hiddenSTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _RecoverableTB;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox _contractSpTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox _treeGradeTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox _merchHghtLLTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox _formClassTB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox _BTRTB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _aveZTB;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox _refHghtTB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button _okBTN;
        private System.Windows.Forms.Button _cancelBTN;
        private System.Windows.Forms.BindingSource _BS_TDV;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox _FiaCodeTB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label17;
    }
}