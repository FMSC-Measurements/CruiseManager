namespace CruiseManager.WinForms.CruiseCustomize
{
    partial class FormAddVolumeEqs
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
            this._StumpHt = new System.Windows.Forms.TextBox();
            this._BS_TDV = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Model = new System.Windows.Forms.TextBox();
            this._MinLogLenP = new System.Windows.Forms.TextBox();
            this._CalcBiomass = new System.Windows.Forms.TextBox();
            this._TopDibS = new System.Windows.Forms.TextBox();
            this._VolEqNum = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._MinMerchLen = new System.Windows.Forms.TextBox();
            this._SegmentLogic = new System.Windows.Forms.TextBox();
            this._CalcBoard = new System.Windows.Forms.TextBox();
            this._TopDibP = new System.Windows.Forms.TextBox();
            this._PProdCB = new System.Windows.Forms.ComboBox();
            this._speciesTB = new System.Windows.Forms.TextBox();
            this._CalcTotal = new System.Windows.Forms.TextBox();
            this._CalcCord = new System.Windows.Forms.TextBox();
            this._Trim = new System.Windows.Forms.TextBox();
            this._MaxLogLenP = new System.Windows.Forms.TextBox();
            this._SpeciesName = new System.Windows.Forms.TextBox();
            this._cancelBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this._okBTN = new System.Windows.Forms.Button();
            this._CalcCubic = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._CalcTopwood = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TDV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _StumpHt
            // 
            this._StumpHt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "StumpHeight", true));
            this._StumpHt.Location = new System.Drawing.Point(138, 31);
            this._StumpHt.Multiline = true;
            this._StumpHt.Name = "_StumpHt";
            this._StumpHt.Size = new System.Drawing.Size(60, 21);
            this._StumpHt.TabIndex = 0;
            // 
            // _BS_TDV
            // 
            this._BS_TDV.DataSource = typeof(CruiseDAL.DataObjects.VolumeEquationDO);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Stump Height";
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
            this.tableLayoutPanel1.Controls.Add(this.label19, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.label17, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.label18, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this._Model, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this._MinLogLenP, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this._CalcBiomass, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this._TopDibS, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this._VolEqNum, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label12, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this._MinMerchLen, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this._SegmentLogic, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this._CalcBoard, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this._TopDibP, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this._PProdCB, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this._speciesTB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._StumpHt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this._CalcTotal, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this._CalcCord, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this._Trim, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this._MaxLogLenP, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this._SpeciesName, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this._cancelBTN, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this._okBTN, 7, 8);
            this.tableLayoutPanel1.Controls.Add(this._CalcCubic, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this._CalcTopwood, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label20, 3, 3);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(706, 221);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(223, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(1, 28);
            this.label19.TabIndex = 23;
            this.label19.Text = "Calc Board";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(464, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 28);
            this.label14.TabIndex = 0;
            this.label14.Text = "Model";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(464, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 26);
            this.label17.TabIndex = 0;
            this.label17.Text = "Min Log Length Primary";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(464, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 28);
            this.label10.TabIndex = 0;
            this.label10.Text = "Calc Biomass";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(463, 28);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(130, 27);
            this.label18.TabIndex = 1;
            this.label18.Text = "Total DIB Secondary";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(464, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Vol Equation Num";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _Model
            // 
            this._Model.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "Model", true));
            this._Model.Location = new System.Drawing.Point(598, 140);
            this._Model.Name = "_Model";
            this._Model.Size = new System.Drawing.Size(36, 22);
            this._Model.TabIndex = 0;
            // 
            // _MinLogLenP
            // 
            this._MinLogLenP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "MinLogLengthPrimary", true));
            this._MinLogLenP.Location = new System.Drawing.Point(598, 114);
            this._MinLogLenP.Name = "_MinLogLenP";
            this._MinLogLenP.Size = new System.Drawing.Size(48, 22);
            this._MinLogLenP.TabIndex = 0;
            // 
            // _CalcBiomass
            // 
            this._CalcBiomass.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CalcBiomass", true));
            this._CalcBiomass.Location = new System.Drawing.Point(598, 86);
            this._CalcBiomass.MaxLength = 4;
            this._CalcBiomass.Name = "_CalcBiomass";
            this._CalcBiomass.Size = new System.Drawing.Size(60, 22);
            this._CalcBiomass.TabIndex = 0;
            // 
            // _TopDibS
            // 
            this._TopDibS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "TopDIBSecondary", true));
            this._TopDibS.Location = new System.Drawing.Point(597, 30);
            this._TopDibS.Margin = new System.Windows.Forms.Padding(2);
            this._TopDibS.Name = "_TopDibS";
            this._TopDibS.Size = new System.Drawing.Size(103, 22);
            this._TopDibS.TabIndex = 0;
            // 
            // _VolEqNum
            // 
            this._VolEqNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "VolumeEquationNumber", true));
            this._VolEqNum.Location = new System.Drawing.Point(598, 3);
            this._VolEqNum.Name = "_VolEqNum";
            this._VolEqNum.Size = new System.Drawing.Size(101, 22);
            this._VolEqNum.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(228, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 28);
            this.label15.TabIndex = 0;
            this.label15.Text = "Min Merchant Length";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(228, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 26);
            this.label12.TabIndex = 0;
            this.label12.Text = "Segment Logic";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(228, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Calc Board";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(228, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total DIB Primary";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(228, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Primary Product";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _MinMerchLen
            // 
            this._MinMerchLen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "MinMerchLength", true));
            this._MinMerchLen.Location = new System.Drawing.Point(352, 140);
            this._MinMerchLen.Name = "_MinMerchLen";
            this._MinMerchLen.Size = new System.Drawing.Size(60, 22);
            this._MinMerchLen.TabIndex = 0;
            // 
            // _SegmentLogic
            // 
            this._SegmentLogic.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "SegmentationLogic", true));
            this._SegmentLogic.Location = new System.Drawing.Point(352, 114);
            this._SegmentLogic.Name = "_SegmentLogic";
            this._SegmentLogic.Size = new System.Drawing.Size(60, 22);
            this._SegmentLogic.TabIndex = 0;
            // 
            // _CalcBoard
            // 
            this._CalcBoard.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CalcBoard", true));
            this._CalcBoard.Location = new System.Drawing.Point(352, 58);
            this._CalcBoard.Multiline = true;
            this._CalcBoard.Name = "_CalcBoard";
            this._CalcBoard.Size = new System.Drawing.Size(60, 22);
            this._CalcBoard.TabIndex = 0;
            // 
            // _TopDibP
            // 
            this._TopDibP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "TopDIBPrimary", true));
            this._TopDibP.Location = new System.Drawing.Point(352, 31);
            this._TopDibP.Multiline = true;
            this._TopDibP.Name = "_TopDibP";
            this._TopDibP.Size = new System.Drawing.Size(60, 21);
            this._TopDibP.TabIndex = 0;
            // 
            // _PProdCB
            // 
            this._PProdCB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this._BS_TDV, "PrimaryProduct", true));
            this._PProdCB.DisplayMember = "FriendlyValue";
            this._PProdCB.FormattingEnabled = true;
            this._PProdCB.Location = new System.Drawing.Point(352, 3);
            this._PProdCB.Name = "_PProdCB";
            this._PProdCB.Size = new System.Drawing.Size(101, 21);
            this._PProdCB.TabIndex = 0;
            this._PProdCB.ValueMember = "Code";
            // 
            // _speciesTB
            // 
            this._speciesTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "Species", true));
            this._speciesTB.Location = new System.Drawing.Point(138, 3);
            this._speciesTB.Name = "_speciesTB";
            this._speciesTB.Size = new System.Drawing.Size(60, 22);
            this._speciesTB.TabIndex = 0;
            // 
            // _CalcTotal
            // 
            this._CalcTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CalcTotal", true));
            this._CalcTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this._CalcTotal.Location = new System.Drawing.Point(138, 58);
            this._CalcTotal.Multiline = true;
            this._CalcTotal.Name = "_CalcTotal";
            this._CalcTotal.Size = new System.Drawing.Size(60, 22);
            this._CalcTotal.TabIndex = 0;
            // 
            // _CalcCord
            // 
            this._CalcCord.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CalcCord", true));
            this._CalcCord.Dock = System.Windows.Forms.DockStyle.Left;
            this._CalcCord.Location = new System.Drawing.Point(138, 86);
            this._CalcCord.Name = "_CalcCord";
            this._CalcCord.Size = new System.Drawing.Size(60, 22);
            this._CalcCord.TabIndex = 0;
            // 
            // _Trim
            // 
            this._Trim.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "Trim", true));
            this._Trim.Dock = System.Windows.Forms.DockStyle.Left;
            this._Trim.Location = new System.Drawing.Point(138, 114);
            this._Trim.Name = "_Trim";
            this._Trim.Size = new System.Drawing.Size(60, 22);
            this._Trim.TabIndex = 0;
            // 
            // _MaxLogLenP
            // 
            this._MaxLogLenP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "FormClass", true));
            this._MaxLogLenP.Dock = System.Windows.Forms.DockStyle.Left;
            this._MaxLogLenP.Location = new System.Drawing.Point(138, 140);
            this._MaxLogLenP.Name = "_MaxLogLenP";
            this._MaxLogLenP.Size = new System.Drawing.Size(48, 22);
            this._MaxLogLenP.TabIndex = 0;
            // 
            // _SpeciesName
            // 
            this._SpeciesName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CommonSpeciesName", true));
            this._SpeciesName.Dock = System.Windows.Forms.DockStyle.Left;
            this._SpeciesName.Location = new System.Drawing.Point(138, 168);
            this._SpeciesName.Name = "_SpeciesName";
            this._SpeciesName.Size = new System.Drawing.Size(79, 22);
            this._SpeciesName.TabIndex = 0;
            // 
            // _cancelBTN
            // 
            this._cancelBTN.AutoSize = true;
            this._cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelBTN.Location = new System.Drawing.Point(3, 195);
            this._cancelBTN.Name = "_cancelBTN";
            this._cancelBTN.Size = new System.Drawing.Size(51, 23);
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
            this.label1.Size = new System.Drawing.Size(129, 28);
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
            this.label6.Size = new System.Drawing.Size(129, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Calc Total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "Calc Cord";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 26);
            this.label11.TabIndex = 0;
            this.label11.Text = "Trim";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 28);
            this.label13.TabIndex = 0;
            this.label13.Text = "Max Log Length Primary";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(3, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 26);
            this.label16.TabIndex = 0;
            this.label16.Text = "Species Name";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _okBTN
            // 
            this._okBTN.AutoSize = true;
            this._okBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okBTN.Location = new System.Drawing.Point(598, 195);
            this._okBTN.Name = "_okBTN";
            this._okBTN.Size = new System.Drawing.Size(32, 23);
            this._okBTN.TabIndex = 18;
            this._okBTN.Text = "OK";
            this._okBTN.UseVisualStyleBackColor = true;
            // 
            // _CalcCubic
            // 
            this._CalcCubic.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CalcCubic", true));
            this._CalcCubic.Location = new System.Drawing.Point(598, 58);
            this._CalcCubic.Multiline = true;
            this._CalcCubic.Name = "_CalcCubic";
            this._CalcCubic.Size = new System.Drawing.Size(60, 22);
            this._CalcCubic.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(464, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 28);
            this.label9.TabIndex = 22;
            this.label9.Text = "Calc Cubic";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _CalcTopwood
            // 
            this._CalcTopwood.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TDV, "CalcTopwood", true));
            this._CalcTopwood.Location = new System.Drawing.Point(352, 86);
            this._CalcTopwood.Multiline = true;
            this._CalcTopwood.Name = "_CalcTopwood";
            this._CalcTopwood.Size = new System.Drawing.Size(60, 22);
            this._CalcTopwood.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(228, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(118, 28);
            this.label20.TabIndex = 25;
            this.label20.Text = "Calc Topwood";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAddVolumeEqs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 221);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddVolumeEqs";
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
        private System.Windows.Forms.TextBox _VolEqNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _StumpHt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _TopDibP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _CalcTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _CalcBoard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _CalcCord;
        private System.Windows.Forms.TextBox _CalcBiomass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _Trim;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _SegmentLogic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox _MaxLogLenP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _Model;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox _MinMerchLen;
        private System.Windows.Forms.TextBox _SpeciesName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button _okBTN;
        private System.Windows.Forms.Button _cancelBTN;
        private System.Windows.Forms.BindingSource _BS_TDV;
        private System.Windows.Forms.TextBox _TopDibS;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox _MinLogLenP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox _CalcCubic;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox _CalcTopwood;
        private System.Windows.Forms.Label label20;
    }
}