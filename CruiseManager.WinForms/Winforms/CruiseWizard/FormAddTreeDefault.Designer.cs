namespace CruiseManager.WinForms.CruiseWizard
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
            this._cullPTB = new System.Windows.Forms.TextBox();
            this._BS_TDV = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._BTRTB = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._contractSpTB = new System.Windows.Forms.TextBox();
            this._FiaCodeTB = new System.Windows.Forms.TextBox();
            this._LiveDeadTB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._aveZTB = new System.Windows.Forms.TextBox();
            this._merchHghtLLTB = new System.Windows.Forms.TextBox();
            this._hiddenSTB = new System.Windows.Forms.TextBox();
            this._hiddenPTB = new System.Windows.Forms.TextBox();
            this._PProdCB = new System.Windows.Forms.ComboBox();
            this._speciesTB = new System.Windows.Forms.TextBox();
            this._cullSTB = new System.Windows.Forms.TextBox();
            this._RecoverableTB = new System.Windows.Forms.TextBox();
            this._treeGradeTB = new System.Windows.Forms.TextBox();
            this._formClassTB = new System.Windows.Forms.TextBox();
            this._refHghtTB = new System.Windows.Forms.TextBox();
            this._okBTN = new System.Windows.Forms.Button();
            this._cancelBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TDV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cullPTB
            // 
            this._cullPTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CullPrimary", true));
            this._cullPTB.Location = new System.Drawing.Point(117, 31);
            this._cullPTB.Multiline = true;
            this._cullPTB.Name = "_cullPTB";
            this._cullPTB.Size = new System.Drawing.Size(60, 21);
            this._cullPTB.TabIndex = 0;
            // 
            // _BS_TDV
            // 
            this._BS_TDV.DataSource = typeof(CruiseDAL.DataObjects.TreeDefaultValueDO);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cull Primary";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label14, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.label17, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.label18, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this._BTRTB, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this._contractSpTB, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this._FiaCodeTB, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this._LiveDeadTB, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label12, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this._aveZTB, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this._merchHghtLLTB, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this._hiddenSTB, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this._hiddenPTB, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this._PProdCB, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this._speciesTB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._cullPTB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this._cullSTB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this._RecoverableTB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this._treeGradeTB, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this._formClassTB, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this._refHghtTB, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this._cancelBTN, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this._okBTN, 7, 8);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 224);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(444, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 28);
            this.label14.TabIndex = 0;
            this.label14.Text = "Bark Thickness Ratio";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(444, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 26);
            this.label17.TabIndex = 0;
            this.label17.Text = "Merch Height Type";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(444, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 28);
            this.label10.TabIndex = 0;
            this.label10.Text = "Contract Species";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(443, 28);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 27);
            this.label18.TabIndex = 1;
            this.label18.Text = "FIACode";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(444, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Live Dead";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _BTRTB
            // 
            this._BTRTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "BarkThicknessRatio", true));
            this._BTRTB.Location = new System.Drawing.Point(562, 140);
            this._BTRTB.Name = "_BTRTB";
            this._BTRTB.Size = new System.Drawing.Size(36, 22);
            this._BTRTB.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "MerchHeightType", true));
            this.textBox1.Location = new System.Drawing.Point(562, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 22);
            this.textBox1.TabIndex = 0;
            // 
            // _contractSpTB
            // 
            this._contractSpTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "ContractSpecies", true));
            this._contractSpTB.Location = new System.Drawing.Point(562, 86);
            this._contractSpTB.MaxLength = 4;
            this._contractSpTB.Name = "_contractSpTB";
            this._contractSpTB.Size = new System.Drawing.Size(60, 22);
            this._contractSpTB.TabIndex = 0;
            // 
            // _FiaCodeTB
            // 
            this._FiaCodeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "FIAcode", true));
            this._FiaCodeTB.Location = new System.Drawing.Point(561, 30);
            this._FiaCodeTB.Margin = new System.Windows.Forms.Padding(2);
            this._FiaCodeTB.Name = "_FiaCodeTB";
            this._FiaCodeTB.Size = new System.Drawing.Size(103, 22);
            this._FiaCodeTB.TabIndex = 0;
            // 
            // _LiveDeadTB
            // 
            this._LiveDeadTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "LiveDead", true));
            this._LiveDeadTB.Location = new System.Drawing.Point(562, 3);
            this._LiveDeadTB.Name = "_LiveDeadTB";
            this._LiveDeadTB.Size = new System.Drawing.Size(101, 22);
            this._LiveDeadTB.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(188, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 28);
            this.label15.TabIndex = 0;
            this.label15.Text = "Average Z";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(188, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 26);
            this.label12.TabIndex = 0;
            this.label12.Text = "Merch Height Log Length";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(188, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hidden Secondary";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(188, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hidden Primary";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(188, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Primary Product";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _aveZTB
            // 
            this._aveZTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "AverageZ", true));
            this._aveZTB.Location = new System.Drawing.Point(332, 140);
            this._aveZTB.Name = "_aveZTB";
            this._aveZTB.Size = new System.Drawing.Size(60, 22);
            this._aveZTB.TabIndex = 0;
            // 
            // _merchHghtLLTB
            // 
            this._merchHghtLLTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "MerchHeightLogLength", true));
            this._merchHghtLLTB.Location = new System.Drawing.Point(332, 114);
            this._merchHghtLLTB.Name = "_merchHghtLLTB";
            this._merchHghtLLTB.Size = new System.Drawing.Size(60, 22);
            this._merchHghtLLTB.TabIndex = 0;
            // 
            // _hiddenSTB
            // 
            this._hiddenSTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "HiddenSecondary", true));
            this._hiddenSTB.Location = new System.Drawing.Point(332, 58);
            this._hiddenSTB.Multiline = true;
            this._hiddenSTB.Name = "_hiddenSTB";
            this._hiddenSTB.Size = new System.Drawing.Size(60, 22);
            this._hiddenSTB.TabIndex = 0;
            // 
            // _hiddenPTB
            // 
            this._hiddenPTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "HiddenPrimary", true));
            this._hiddenPTB.Location = new System.Drawing.Point(332, 31);
            this._hiddenPTB.Multiline = true;
            this._hiddenPTB.Name = "_hiddenPTB";
            this._hiddenPTB.Size = new System.Drawing.Size(60, 21);
            this._hiddenPTB.TabIndex = 0;
            // 
            // _PProdCB
            // 
            this._PProdCB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this._BS_TDV, "PrimaryProduct", true));
            this._PProdCB.DisplayMember = "FriendlyValue";
            this._PProdCB.FormattingEnabled = true;
            this._PProdCB.Location = new System.Drawing.Point(332, 3);
            this._PProdCB.Name = "_PProdCB";
            this._PProdCB.Size = new System.Drawing.Size(101, 21);
            this._PProdCB.TabIndex = 0;
            this._PProdCB.ValueMember = "Code";
            // 
            // _speciesTB
            // 
            this._speciesTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "Species", true));
            this._speciesTB.Location = new System.Drawing.Point(117, 3);
            this._speciesTB.Name = "_speciesTB";
            this._speciesTB.Size = new System.Drawing.Size(60, 22);
            this._speciesTB.TabIndex = 0;
            // 
            // _cullSTB
            // 
            this._cullSTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CullSecondary", true));
            this._cullSTB.Dock = System.Windows.Forms.DockStyle.Left;
            this._cullSTB.Location = new System.Drawing.Point(117, 58);
            this._cullSTB.Multiline = true;
            this._cullSTB.Name = "_cullSTB";
            this._cullSTB.Size = new System.Drawing.Size(60, 22);
            this._cullSTB.TabIndex = 0;
            // 
            // _RecoverableTB
            // 
            this._RecoverableTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "Recoverable", true));
            this._RecoverableTB.Dock = System.Windows.Forms.DockStyle.Left;
            this._RecoverableTB.Location = new System.Drawing.Point(117, 86);
            this._RecoverableTB.Name = "_RecoverableTB";
            this._RecoverableTB.Size = new System.Drawing.Size(60, 22);
            this._RecoverableTB.TabIndex = 0;
            // 
            // _treeGradeTB
            // 
            this._treeGradeTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "TreeGrade", true));
            this._treeGradeTB.Dock = System.Windows.Forms.DockStyle.Left;
            this._treeGradeTB.Location = new System.Drawing.Point(117, 114);
            this._treeGradeTB.Name = "_treeGradeTB";
            this._treeGradeTB.Size = new System.Drawing.Size(60, 22);
            this._treeGradeTB.TabIndex = 0;
            // 
            // _formClassTB
            // 
            this._formClassTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "FormClass", true));
            this._formClassTB.Dock = System.Windows.Forms.DockStyle.Left;
            this._formClassTB.Location = new System.Drawing.Point(117, 140);
            this._formClassTB.Name = "_formClassTB";
            this._formClassTB.Size = new System.Drawing.Size(34, 22);
            this._formClassTB.TabIndex = 0;
            // 
            // _refHghtTB
            // 
            this._refHghtTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "ReferenceHeightPercent", true));
            this._refHghtTB.Dock = System.Windows.Forms.DockStyle.Left;
            this._refHghtTB.Location = new System.Drawing.Point(117, 168);
            this._refHghtTB.Name = "_refHghtTB";
            this._refHghtTB.Size = new System.Drawing.Size(34, 22);
            this._refHghtTB.TabIndex = 0;
            // 
            // _okBTN
            // 
            this._okBTN.AutoSize = true;
            this._okBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okBTN.Location = new System.Drawing.Point(562, 198);
            this._okBTN.Name = "_okBTN";
            this._okBTN.Size = new System.Drawing.Size(60, 23);
            this._okBTN.TabIndex = 18;
            this._okBTN.Text = "OK";
            this._okBTN.UseVisualStyleBackColor = true;
            // 
            // _cancelBTN
            // 
            this._cancelBTN.AutoSize = true;
            this._cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelBTN.Location = new System.Drawing.Point(3, 198);
            this._cancelBTN.Name = "_cancelBTN";
            this._cancelBTN.Size = new System.Drawing.Size(75, 23);
            this._cancelBTN.TabIndex = 19;
            this._cancelBTN.Text = "Cancel";
            this._cancelBTN.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Species";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cull Secondary";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "Recoverable";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 26);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tree Grade";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 28);
            this.label13.TabIndex = 0;
            this.label13.Text = "Form Class";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(3, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 26);
            this.label16.TabIndex = 0;
            this.label16.Text = "Reference Height %";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAddTreeDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 224);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddTreeDefault";
            ((System.ComponentModel.ISupportInitialize)(this._BS_TDV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox _speciesTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _PProdCB;
        private System.Windows.Forms.TextBox _LiveDeadTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _cullPTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _hiddenPTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _cullSTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _hiddenSTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _RecoverableTB;
        private System.Windows.Forms.TextBox _contractSpTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _treeGradeTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _merchHghtLLTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _formClassTB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _BTRTB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _aveZTB;
        private System.Windows.Forms.TextBox _refHghtTB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button _okBTN;
        private System.Windows.Forms.Button _cancelBTN;
        private System.Windows.Forms.BindingSource _BS_TDV;
        private System.Windows.Forms.TextBox _FiaCodeTB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label17;
    }
}