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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Panel panel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StrataPage));
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
            this.StrataListBox = new System.Windows.Forms.ListBox();
            this.StrataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._kzTB = new System.Windows.Forms.TextBox();
            this.YearComboBox = new FMSC.Controls.YearComboBox();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.CruiseMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BAFTextBox = new System.Windows.Forms.TextBox();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.FixedPlotSizeTextBox = new System.Windows.Forms.TextBox();
            this.yieldCombo = new System.Windows.Forms.ComboBox();
            this.CuttingUnitGridView = new FMSC.Controls.SelectedItemsGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loggingMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuttingUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SampleGroupButton = new System.Windows.Forms.Button();
            this.CuttingUnitButton = new System.Windows.Forms.Button();
            this._btn_cancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StrataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CruiseMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = System.Windows.Forms.DockStyle.Fill;
            label10.Location = new System.Drawing.Point(137, 56);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(80, 28);
            label10.TabIndex = 0;
            label10.Text = "Year";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = System.Windows.Forms.DockStyle.Fill;
            label11.Location = new System.Drawing.Point(137, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(80, 28);
            label11.TabIndex = 1;
            label11.Text = "Method";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = System.Windows.Forms.DockStyle.Fill;
            label13.Location = new System.Drawing.Point(3, 56);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(77, 28);
            label13.TabIndex = 0;
            label13.Text = "Month";
            label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel2.Controls.Add(this.StrataListBox);
            panel2.Controls.Add(this.bindingNavigator);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(0);
            panel2.Name = "panel2";
            tableLayoutPanel1.SetRowSpan(panel2, 4);
            panel2.Size = new System.Drawing.Size(160, 422);
            panel2.TabIndex = 1;
            // 
            // StrataListBox
            // 
            this.StrataListBox.DataSource = this.StrataBindingSource;
            this.StrataListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StrataListBox.FormatString = "● [Code] - [Method]";
            this.StrataListBox.FormattingEnabled = true;
            this.StrataListBox.IntegralHeight = false;
            this.StrataListBox.Location = new System.Drawing.Point(0, 46);
            this.StrataListBox.Margin = new System.Windows.Forms.Padding(0);
            this.StrataListBox.Name = "StrataListBox";
            this.StrataListBox.ScrollAlwaysVisible = true;
            this.StrataListBox.Size = new System.Drawing.Size(156, 372);
            this.StrataListBox.TabIndex = 0;
            // 
            // StrataBindingSource
            // 
            this.StrataBindingSource.DataSource = typeof(CruiseDAL.DataObjects.StratumDO);
            this.StrataBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.StrataBindingSource_AddingNew);
            this.StrataBindingSource.CurrentChanged += new System.EventHandler(this.StrataBindingSource_CurrentChanged);
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
            this.bindingNavigator.Size = new System.Drawing.Size(156, 46);
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
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 15);
            this.toolStripLabel1.Text = "Strata:";
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 1, 0);
            tableLayoutPanel1.Controls.Add(this.CuttingUnitGridView, 1, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 4);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(630, 472);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this._kzTB, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.YearComboBox, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.MonthComboBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.MethodComboBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(label13, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.BAFTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.CodeTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 1, 3);
            this.tableLayoutPanel2.Controls.Add(label6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(label11, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.FixedPlotSizeTextBox, 3, 1);
            this.tableLayoutPanel2.Controls.Add(label7, 2, 1);
            this.tableLayoutPanel2.Controls.Add(label10, 2, 2);
            this.tableLayoutPanel2.Controls.Add(label8, 4, 2);
            this.tableLayoutPanel2.Controls.Add(label1, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.yieldCombo, 5, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(163, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(464, 122);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // _kzTB
            // 
            this._kzTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "KZ3PPNT", true));
            this._kzTB.Enabled = false;
            this._kzTB.Location = new System.Drawing.Point(403, 31);
            this._kzTB.Name = "_kzTB";
            this._kzTB.Size = new System.Drawing.Size(42, 22);
            this._kzTB.TabIndex = 7;
            // 
            // YearComboBox
            // 
            this.YearComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Year", true));
            this.YearComboBox.EndYear = 2099;
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(223, 59);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(50, 21);
            this.YearComboBox.StartYear = 1950;
            this.YearComboBox.TabIndex = 6;
            this.YearComboBox.Text = "2014";
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Month", true));
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Location = new System.Drawing.Point(86, 59);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(45, 21);
            this.MonthComboBox.TabIndex = 2;
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.MethodComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.MethodComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Method", true));
            this.MethodComboBox.DataSource = this.CruiseMethodBindingSource;
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Location = new System.Drawing.Point(223, 3);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(73, 21);
            this.MethodComboBox.TabIndex = 4;
            this.MethodComboBox.SelectedValueChanged += new System.EventHandler(this.MethodComboBox_SelectedValueChanged);
            // 
            // CruiseMethodBindingSource
            // 
            this.CruiseMethodBindingSource.DataSource = typeof(string);
            // 
            // BAFTextBox
            // 
            this.BAFTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "BasalAreaFactor", true));
            this.BAFTextBox.Enabled = false;
            this.BAFTextBox.Location = new System.Drawing.Point(86, 31);
            this.BAFTextBox.MaxLength = 6;
            this.BAFTextBox.Name = "BAFTextBox";
            this.BAFTextBox.Size = new System.Drawing.Size(45, 22);
            this.BAFTextBox.TabIndex = 1;
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Code", true));
            this.CodeTextBox.Location = new System.Drawing.Point(86, 3);
            this.CodeTextBox.MaxLength = 2;
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(35, 22);
            this.CodeTextBox.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(77, 28);
            label2.TabIndex = 12;
            label2.Text = "Stratum Code";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Location = new System.Drawing.Point(3, 28);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(77, 28);
            label5.TabIndex = 13;
            label5.Text = "BAF";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBox3, 5);
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "Description", true));
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(86, 87);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(438, 22);
            this.textBox3.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = System.Windows.Forms.DockStyle.Fill;
            label6.Location = new System.Drawing.Point(3, 84);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(77, 28);
            label6.TabIndex = 15;
            label6.Text = "Description";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FixedPlotSizeTextBox
            // 
            this.FixedPlotSizeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "FixedPlotSize", true));
            this.FixedPlotSizeTextBox.Enabled = false;
            this.FixedPlotSizeTextBox.Location = new System.Drawing.Point(223, 31);
            this.FixedPlotSizeTextBox.MaxLength = 5;
            this.FixedPlotSizeTextBox.Name = "FixedPlotSizeTextBox";
            this.FixedPlotSizeTextBox.Size = new System.Drawing.Size(35, 22);
            this.FixedPlotSizeTextBox.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Location = new System.Drawing.Point(137, 28);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(80, 28);
            label7.TabIndex = 17;
            label7.Text = "Fixed Plot Size";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = System.Windows.Forms.DockStyle.Fill;
            label8.Location = new System.Drawing.Point(302, 56);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(95, 28);
            label8.TabIndex = 19;
            label8.Text = "Yield Component";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(302, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(95, 28);
            label1.TabIndex = 0;
            label1.Text = "3PPNT KZ";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yieldCombo
            // 
            this.yieldCombo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.StrataBindingSource, "YieldComponent", true));
            this.yieldCombo.FormattingEnabled = true;
            this.yieldCombo.Items.AddRange(Core.Constants.Strings.YIELD_COMPONENT_VALUES);
            this.yieldCombo.Location = new System.Drawing.Point(403, 59);
            this.yieldCombo.Name = "yieldCombo";
            this.yieldCombo.Size = new System.Drawing.Size(42, 21);
            this.yieldCombo.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.DarkSeaGreen;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(160, 144);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            label3.Size = new System.Drawing.Size(470, 16);
            label3.TabIndex = 1;
            label3.Text = "Cutting Units";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.DarkSeaGreen;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(160, 0);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            label4.Size = new System.Drawing.Size(470, 16);
            label4.TabIndex = 3;
            label4.Text = "Stratum";
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
            this.CuttingUnitGridView.Location = new System.Drawing.Point(160, 160);
            this.CuttingUnitGridView.Margin = new System.Windows.Forms.Padding(0);
            this.CuttingUnitGridView.Name = "CuttingUnitGridView";
            this.CuttingUnitGridView.ReadOnly = true;
            this.CuttingUnitGridView.RowHeadersVisible = false;
            this.CuttingUnitGridView.RowTemplate.Height = 24;
            this.CuttingUnitGridView.SelectedItems = null;
            this.CuttingUnitGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CuttingUnitGridView.Size = new System.Drawing.Size(470, 262);
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
            // CuttingUnitBindingSource
            // 
            this.CuttingUnitBindingSource.DataSource = typeof(CruiseDAL.DataObjects.CuttingUnitDO);
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            tableLayoutPanel3.ColumnCount = 7;
            tableLayoutPanel1.SetColumnSpan(tableLayoutPanel3, 2);
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel3.Controls.Add(this.SampleGroupButton, 5, 1);
            tableLayoutPanel3.Controls.Add(this.CuttingUnitButton, 1, 1);
            tableLayoutPanel3.Controls.Add(this._btn_cancel, 3, 1);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(0, 422);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new System.Drawing.Size(630, 50);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // SampleGroupButton
            // 
            this.SampleGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SampleGroupButton.AutoSize = true;
            this.SampleGroupButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SampleGroupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SampleGroupButton.Location = new System.Drawing.Point(489, 12);
            this.SampleGroupButton.Margin = new System.Windows.Forms.Padding(0);
            this.SampleGroupButton.Name = "SampleGroupButton";
            this.SampleGroupButton.Size = new System.Drawing.Size(111, 25);
            this.SampleGroupButton.TabIndex = 0;
            this.SampleGroupButton.Text = "Sample Group >>";
            this.SampleGroupButton.UseVisualStyleBackColor = false;
            this.SampleGroupButton.Click += new System.EventHandler(this.SampleGroupButton_Click);
            // 
            // CuttingUnitButton
            // 
            this.CuttingUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CuttingUnitButton.AutoSize = true;
            this.CuttingUnitButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CuttingUnitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CuttingUnitButton.Location = new System.Drawing.Point(30, 12);
            this.CuttingUnitButton.Margin = new System.Windows.Forms.Padding(0);
            this.CuttingUnitButton.Name = "CuttingUnitButton";
            this.CuttingUnitButton.Size = new System.Drawing.Size(107, 25);
            this.CuttingUnitButton.TabIndex = 1;
            this.CuttingUnitButton.Text = "<< Cutting Units";
            this.CuttingUnitButton.UseVisualStyleBackColor = false;
            this.CuttingUnitButton.Click += new System.EventHandler(this.CuttingUnitButton_Click);
            // 
            // _btn_cancel
            // 
            this._btn_cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._btn_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btn_cancel.Location = new System.Drawing.Point(147, 12);
            this._btn_cancel.Margin = new System.Windows.Forms.Padding(0);
            this._btn_cancel.Name = "_btn_cancel";
            this._btn_cancel.Size = new System.Drawing.Size(53, 25);
            this._btn_cancel.TabIndex = 2;
            this._btn_cancel.Text = "Cancel";
            this._btn_cancel.UseVisualStyleBackColor = false;
            this._btn_cancel.Click += new System.EventHandler(this._btn_cancel_Click);
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
            this.Controls.Add(tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.MinimumSize = new System.Drawing.Size(630, 0);
            this.Name = "StrataPage";
            this.Size = new System.Drawing.Size(630, 472);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StrataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CruiseMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SampleGroupButton;
        private System.Windows.Forms.Button CuttingUnitButton;
        private System.Windows.Forms.ComboBox MethodComboBox;
        private System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ListBox StrataListBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private FMSC.Controls.SelectedItemsGridView CuttingUnitGridView;
        private FMSC.Controls.YearComboBox YearComboBox;
        public System.Windows.Forms.BindingSource StrataBindingSource;
        public System.Windows.Forms.BindingSource CuttingUnitBindingSource;
        public System.Windows.Forms.BindingSource CruiseMethodBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox _kzTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loggingMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox BAFTextBox;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox FixedPlotSizeTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ComboBox yieldCombo;
        private System.Windows.Forms.Button _btn_cancel;
    }
}
