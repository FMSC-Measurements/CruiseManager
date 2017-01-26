namespace CruiseManager.WinForms.CruiseWizard
{
    partial class StrataPage
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
            System.Windows.Forms.Panel panel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StrataPage));
            this.SampleGroupButton = new System.Windows.Forms.Button();
            this.CuttingUnitButton = new System.Windows.Forms.Button();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.StrataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CruiseMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CodeTextBox = new FMSC.Controls.SideLabelTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BAFTextBox = new FMSC.Controls.SideLabelTextBox();
            this.FixedPlotSizeTextBox = new FMSC.Controls.SideLabelTextBox();
            this.CuttingUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.StrataListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.YearComboBox = new FMSC.Controls.YearComboBox();
            this.sideLabelTextBox1 = new FMSC.Controls.SideLabelTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this._kzTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._SLTB_YealdComponent = new FMSC.Controls.SideLabelTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CuttingUnitGridView = new FMSC.Controls.SelectedItemsGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loggingMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StrataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CruiseMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            panel1.Controls.Add(this.SampleGroupButton);
            panel1.Controls.Add(this.CuttingUnitButton);
            panel1.Location = new System.Drawing.Point(0, 428);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(630, 45);
            panel1.TabIndex = 0;
            // 
            // SampleGroupButton
            // 
            this.SampleGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SampleGroupButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SampleGroupButton.Location = new System.Drawing.Point(518, 12);
            this.SampleGroupButton.Margin = new System.Windows.Forms.Padding(10);
            this.SampleGroupButton.Name = "SampleGroupButton";
            this.SampleGroupButton.Size = new System.Drawing.Size(102, 23);
            this.SampleGroupButton.TabIndex = 1;
            this.SampleGroupButton.Text = "Sample Group >>";
            this.SampleGroupButton.UseVisualStyleBackColor = false;
            this.SampleGroupButton.Click += new System.EventHandler(this.SampleGroupButton_Click);
            // 
            // CuttingUnitButton
            // 
            this.CuttingUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CuttingUnitButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CuttingUnitButton.Location = new System.Drawing.Point(10, 12);
            this.CuttingUnitButton.Margin = new System.Windows.Forms.Padding(10);
            this.CuttingUnitButton.Name = "CuttingUnitButton";
            this.CuttingUnitButton.Size = new System.Drawing.Size(93, 23);
            this.CuttingUnitButton.TabIndex = 0;
            this.CuttingUnitButton.Text = "<< Cutting Units";
            this.CuttingUnitButton.UseVisualStyleBackColor = false;
            this.CuttingUnitButton.Click += new System.EventHandler(this.CuttingUnitButton_Click);
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.MethodComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.MethodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Method", true));
            this.MethodComboBox.DataSource = this.CruiseMethodBindingSource;
            this.MethodComboBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Location = new System.Drawing.Point(49, 0);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(103, 21);
            this.MethodComboBox.TabIndex = 0;
            this.MethodComboBox.SelectedValueChanged += new System.EventHandler(this.MethodComboBox_SelectedValueChanged);
            // 
            // StrataBindingSource
            // 
            this.StrataBindingSource.DataSource = typeof(CruiseDAL.DataObjects.StratumDO);
            this.StrataBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.StrataBindingSource_AddingNew);
            this.StrataBindingSource.CurrentChanged += new System.EventHandler(this.StrataBindingSource_CurrentChanged);
            // 
            // CruiseMethodBindingSource
            // 
            this.CruiseMethodBindingSource.DataSource = typeof(string);
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Code", true));
            this.CodeTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.CodeTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CodeTextBox.LabelWidth = 80F;
            this.CodeTextBox.LableText = "Stratum Code";
            this.CodeTextBox.Location = new System.Drawing.Point(0, 0);
            this.CodeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(131, 31);
            this.CodeTextBox.TabIndex = 1;
            // 
            // 
            // 
            this.CodeTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeTextBox.TextBox.Location = new System.Drawing.Point(80, 2);
            this.CodeTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.CodeTextBox.TextBox.MaxLength = 2;
            this.CodeTextBox.TextBox.Name = ".TextBox";
            this.CodeTextBox.TextBox.Size = new System.Drawing.Size(51, 22);
            this.CodeTextBox.TextBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Year";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Method";
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Month", true));
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Location = new System.Drawing.Point(56, 0);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(53, 21);
            this.MonthComboBox.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Month";
            // 
            // BAFTextBox
            // 
            this.BAFTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BAFTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "BasalAreaFactor", true));
            this.BAFTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.BAFTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAFTextBox.LabelWidth = 50F;
            this.BAFTextBox.LableText = "BAF";
            this.BAFTextBox.Location = new System.Drawing.Point(0, 31);
            this.BAFTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.BAFTextBox.Name = "BAFTextBox";
            this.BAFTextBox.Size = new System.Drawing.Size(75, 31);
            this.BAFTextBox.TabIndex = 4;
            // 
            // 
            // 
            this.BAFTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BAFTextBox.TextBox.Enabled = false;
            this.BAFTextBox.TextBox.Location = new System.Drawing.Point(50, 4);
            this.BAFTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.BAFTextBox.TextBox.MaxLength = 6;
            this.BAFTextBox.TextBox.Name = ".TextBox";
            this.BAFTextBox.TextBox.Size = new System.Drawing.Size(25, 22);
            this.BAFTextBox.TextBox.TabIndex = 1;
            // 
            // FixedPlotSizeTextBox
            // 
            this.FixedPlotSizeTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FixedPlotSizeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "FixedPlotSize", true));
            this.FixedPlotSizeTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.FixedPlotSizeTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.FixedPlotSizeTextBox.LabelWidth = 110F;
            this.FixedPlotSizeTextBox.LableText = "Fixed Plot Size";
            this.FixedPlotSizeTextBox.Location = new System.Drawing.Point(131, 31);
            this.FixedPlotSizeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.FixedPlotSizeTextBox.Name = "FixedPlotSizeTextBox";
            this.FixedPlotSizeTextBox.Size = new System.Drawing.Size(132, 31);
            this.FixedPlotSizeTextBox.TabIndex = 5;
            // 
            // 
            // 
            this.FixedPlotSizeTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FixedPlotSizeTextBox.TextBox.Enabled = false;
            this.FixedPlotSizeTextBox.TextBox.Location = new System.Drawing.Point(110, 4);
            this.FixedPlotSizeTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.FixedPlotSizeTextBox.TextBox.MaxLength = 4;
            this.FixedPlotSizeTextBox.TextBox.Name = ".TextBox";
            this.FixedPlotSizeTextBox.TextBox.Size = new System.Drawing.Size(22, 22);
            this.FixedPlotSizeTextBox.TextBox.TabIndex = 1;
            // 
            // CuttingUnitBindingSource
            // 
            this.CuttingUnitBindingSource.DataSource = typeof(CruiseDAL.DataObjects.CuttingUnitDO);
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator.BindingSource = this.StrataBindingSource;
            this.bindingNavigator.CountItem = null;
            this.bindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.bindingNavigatorAddNewItem,
            this.toolStripSeparator3,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator2});
            this.bindingNavigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator.MoveFirstItem = null;
            this.bindingNavigator.MoveLastItem = null;
            this.bindingNavigator.MoveNextItem = null;
            this.bindingNavigator.MovePreviousItem = null;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = null;
            this.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator.Size = new System.Drawing.Size(156, 23);
            this.bindingNavigator.TabIndex = 1;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(74, 20);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(60, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 0);
            this.toolStripLabel1.Text = "Strata";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // StrataListBox
            // 
            this.StrataListBox.DataSource = this.StrataBindingSource;
            this.StrataListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StrataListBox.FormatString = "● [Code] - [Method]";
            this.StrataListBox.FormattingEnabled = true;
            this.StrataListBox.IntegralHeight = false;
            this.StrataListBox.Location = new System.Drawing.Point(0, 23);
            this.StrataListBox.Margin = new System.Windows.Forms.Padding(0);
            this.StrataListBox.Name = "StrataListBox";
            this.StrataListBox.ScrollAlwaysVisible = true;
            this.StrataListBox.Size = new System.Drawing.Size(156, 394);
            this.StrataListBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.StrataListBox);
            this.panel2.Controls.Add(this.bindingNavigator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 4);
            this.panel2.Size = new System.Drawing.Size(160, 421);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CuttingUnitGridView, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 421);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BAFTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.FixedPlotSizeTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.CodeTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.sideLabelTextBox1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this._SLTB_YealdComponent, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(163, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(458, 124);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.MethodComboBox);
            this.panel4.Location = new System.Drawing.Point(134, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(152, 24);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.MonthComboBox);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(125, 25);
            this.panel5.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.YearComboBox);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(134, 65);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(171, 25);
            this.panel6.TabIndex = 7;
            // 
            // YearComboBox
            // 
            this.YearComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Year", true));
            this.YearComboBox.EndYear = 2099;
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(99, 3);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(50, 21);
            this.YearComboBox.StartYear = 1950;
            this.YearComboBox.TabIndex = 1;
            this.YearComboBox.Text = "2014";
            // 
            // sideLabelTextBox1
            // 
            this.sideLabelTextBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.SetColumnSpan(this.sideLabelTextBox1, 2);
            this.sideLabelTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Description", true));
            this.sideLabelTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideLabelTextBox1.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.sideLabelTextBox1.LabelWidth = 100F;
            this.sideLabelTextBox1.LableText = "Description";
            this.sideLabelTextBox1.Location = new System.Drawing.Point(0, 93);
            this.sideLabelTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.sideLabelTextBox1.Name = "sideLabelTextBox1";
            this.sideLabelTextBox1.Size = new System.Drawing.Size(300, 31);
            this.sideLabelTextBox1.TabIndex = 8;
            // 
            // 
            // 
            this.sideLabelTextBox1.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideLabelTextBox1.TextBox.Location = new System.Drawing.Point(100, 4);
            this.sideLabelTextBox1.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.sideLabelTextBox1.TextBox.MaxLength = 25;
            this.sideLabelTextBox1.TextBox.Name = ".TextBox";
            this.sideLabelTextBox1.TextBox.Size = new System.Drawing.Size(200, 22);
            this.sideLabelTextBox1.TextBox.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._kzTB);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(308, 31);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 31);
            this.panel3.TabIndex = 4;
            // 
            // _kzTB
            // 
            this._kzTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "KZ3PPNT", true));
            this._kzTB.Enabled = false;
            this._kzTB.Location = new System.Drawing.Point(73, 6);
            this._kzTB.Name = "_kzTB";
            this._kzTB.Size = new System.Drawing.Size(34, 22);
            this._kzTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "3PPNT KZ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _SLTB_YealdComponent
            // 
            this._SLTB_YealdComponent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._SLTB_YealdComponent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "YieldComponent", true));
            this._SLTB_YealdComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SLTB_YealdComponent.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this._SLTB_YealdComponent.LabelWidth = 100F;
            this._SLTB_YealdComponent.LableText = "Yield Component";
            this._SLTB_YealdComponent.Location = new System.Drawing.Point(308, 62);
            this._SLTB_YealdComponent.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_YealdComponent.Name = "_SLTB_YealdComponent";
            this._SLTB_YealdComponent.Size = new System.Drawing.Size(150, 31);
            this._SLTB_YealdComponent.TabIndex = 9;
            // 
            // 
            // 
            this._SLTB_YealdComponent.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SLTB_YealdComponent.TextBox.Location = new System.Drawing.Point(100, 2);
            this._SLTB_YealdComponent.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_YealdComponent.TextBox.MaxLength = 2;
            this._SLTB_YealdComponent.TextBox.Name = ".TextBox";
            this._SLTB_YealdComponent.TextBox.Size = new System.Drawing.Size(50, 22);
            this._SLTB_YealdComponent.TextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(160, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(464, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cutting Units";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(160, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(464, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stratum";
            // 
            // CuttingUnitGridView
            // 
            this.CuttingUnitGridView.AllowUserToAddRows = false;
            this.CuttingUnitGridView.AllowUserToDeleteRows = false;
            this.CuttingUnitGridView.AutoGenerateColumns = false;
            this.CuttingUnitGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CuttingUnitGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CuttingUnitGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.areaDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.loggingMethodDataGridViewTextBoxColumn,
            this.paymentUnitDataGridViewTextBoxColumn});
            this.CuttingUnitGridView.DataSource = this.CuttingUnitBindingSource;
            this.CuttingUnitGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CuttingUnitGridView.Location = new System.Drawing.Point(160, 170);
            this.CuttingUnitGridView.Margin = new System.Windows.Forms.Padding(0);
            this.CuttingUnitGridView.Name = "CuttingUnitGridView";
            this.CuttingUnitGridView.ReadOnly = true;
            this.CuttingUnitGridView.RowHeadersVisible = false;
            this.CuttingUnitGridView.RowTemplate.Height = 24;
            this.CuttingUnitGridView.SelectedItems = null;
            this.CuttingUnitGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CuttingUnitGridView.Size = new System.Drawing.Size(464, 251);
            this.CuttingUnitGridView.TabIndex = 2;
            this.CuttingUnitGridView.VirtualMode = true;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.ToolTipText = "Cutting Unit Code";
            this.codeDataGridViewTextBoxColumn.Width = 59;
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.areaDataGridViewTextBoxColumn.DataPropertyName = "Area";
            this.areaDataGridViewTextBoxColumn.HeaderText = "Area";
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            this.areaDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaDataGridViewTextBoxColumn.ToolTipText = "Area in Acres";
            this.areaDataGridViewTextBoxColumn.Width = 55;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.ToolTipText = "Cutting Unit Description";
            this.descriptionDataGridViewTextBoxColumn.Width = 91;
            // 
            // loggingMethodDataGridViewTextBoxColumn
            // 
            this.loggingMethodDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.loggingMethodDataGridViewTextBoxColumn.DataPropertyName = "LoggingMethod";
            this.loggingMethodDataGridViewTextBoxColumn.HeaderText = "LogMeth";
            this.loggingMethodDataGridViewTextBoxColumn.Name = "loggingMethodDataGridViewTextBoxColumn";
            this.loggingMethodDataGridViewTextBoxColumn.ReadOnly = true;
            this.loggingMethodDataGridViewTextBoxColumn.ToolTipText = "Logging Method Code";
            this.loggingMethodDataGridViewTextBoxColumn.Width = 78;
            // 
            // paymentUnitDataGridViewTextBoxColumn
            // 
            this.paymentUnitDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.paymentUnitDataGridViewTextBoxColumn.DataPropertyName = "PaymentUnit";
            this.paymentUnitDataGridViewTextBoxColumn.HeaderText = "PaymentUnit";
            this.paymentUnitDataGridViewTextBoxColumn.Name = "paymentUnitDataGridViewTextBoxColumn";
            this.paymentUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.paymentUnitDataGridViewTextBoxColumn.ToolTipText = "Payment Unit Code";
            this.paymentUnitDataGridViewTextBoxColumn.Width = 97;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.StrataBindingSource;
            // 
            // StrataPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.MinimumSize = new System.Drawing.Size(630, 0);
            this.Name = "StrataPage";
            this.Size = new System.Drawing.Size(630, 472);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StrataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CruiseMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SampleGroupButton;
        private System.Windows.Forms.Button CuttingUnitButton;
        private System.Windows.Forms.ComboBox MethodComboBox;
        private FMSC.Controls.SideLabelTextBox CodeTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.Label label13;
        private FMSC.Controls.SideLabelTextBox BAFTextBox;
        private FMSC.Controls.SideLabelTextBox FixedPlotSizeTextBox;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ListBox StrataListBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private FMSC.Controls.SideLabelTextBox sideLabelTextBox1;
        private FMSC.Controls.SelectedItemsGridView CuttingUnitGridView;
        private FMSC.Controls.YearComboBox YearComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.BindingSource StrataBindingSource;
        public System.Windows.Forms.BindingSource CuttingUnitBindingSource;
        public System.Windows.Forms.BindingSource CruiseMethodBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox _kzTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loggingMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentUnitDataGridViewTextBoxColumn;
        private FMSC.Controls.SideLabelTextBox _SLTB_YealdComponent;
    }
}
