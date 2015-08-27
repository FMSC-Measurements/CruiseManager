namespace CSM.UI.CruiseWizard
{
    partial class CuttingUnitsPage
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
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuttingUnitsPage));
            this.CuttingUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PaymentUnitTextBox = new FMSC.Controls.SideLabelTextBox();
            this.LoggingMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AreaTextBox = new FMSC.Controls.SideLabelTextBox();
            this.CodeTextBox = new FMSC.Controls.SideLabelTextBox();
            this.CuttingUnitsListBox = new System.Windows.Forms.ListBox();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.StrataButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DescriptionTextBox = new FMSC.Controls.SideLabelTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LogMethComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(0, 6);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(84, 13);
            label4.TabIndex = 16;
            label4.Text = "Logging Method";
            label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CuttingUnitBindingSource
            // 
            this.CuttingUnitBindingSource.DataSource = typeof(CruiseDAL.DataObjects.CuttingUnitDO);
            this.CuttingUnitBindingSource.CurrentChanged += new System.EventHandler(this.CuttingUnitBindingSource_CurrentChanged);
            this.CuttingUnitBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.CuttingUnitBindingSource_AddingNew);
            // 
            // PaymentUnitTextBox
            // 
            this.PaymentUnitTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PaymentUnitTextBox.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.PaymentUnitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CuttingUnitBindingSource, "PaymentUnit", true));
            this.PaymentUnitTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.PaymentUnitTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.PaymentUnitTextBox.LabelWidth = 100F;
            this.PaymentUnitTextBox.LableText = "Payment Unit";
            this.PaymentUnitTextBox.Location = new System.Drawing.Point(0, 96);
            this.PaymentUnitTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.PaymentUnitTextBox.Name = "PaymentUnitTextBox";
            this.PaymentUnitTextBox.Size = new System.Drawing.Size(132, 32);
            this.PaymentUnitTextBox.TabIndex = 3;
            // 
            // 
            // 
            this.PaymentUnitTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaymentUnitTextBox.TextBox.Location = new System.Drawing.Point(100, 6);
            this.PaymentUnitTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.PaymentUnitTextBox.TextBox.MaxLength = 3;
            this.PaymentUnitTextBox.TextBox.Name = ".TextBox";
            this.PaymentUnitTextBox.TextBox.Size = new System.Drawing.Size(32, 20);
            this.PaymentUnitTextBox.TextBox.TabIndex = 1;
            // 
            // LoggingMethodBindingSource
            // 
            this.LoggingMethodBindingSource.DataSource = typeof(CSM.Utility.Setup.LoggingMethod);
            // 
            // AreaTextBox
            // 
            this.AreaTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AreaTextBox.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.AreaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CuttingUnitBindingSource, "Area", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.AreaTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.AreaTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.AreaTextBox.LabelWidth = 50F;
            this.AreaTextBox.LableText = "Area";
            this.AreaTextBox.Location = new System.Drawing.Point(0, 32);
            this.AreaTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AreaTextBox.Name = "AreaTextBox";
            this.AreaTextBox.Size = new System.Drawing.Size(112, 32);
            this.AreaTextBox.TabIndex = 1;
            // 
            // 
            // 
            this.AreaTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AreaTextBox.TextBox.Location = new System.Drawing.Point(50, 6);
            this.AreaTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AreaTextBox.TextBox.Name = ".TextBox";
            this.AreaTextBox.TextBox.Size = new System.Drawing.Size(62, 20);
            this.AreaTextBox.TextBox.TabIndex = 1;
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CodeTextBox.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CuttingUnitBindingSource, "Code", true));
            this.CodeTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.CodeTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CodeTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CodeTextBox.LabelWidth = 100F;
            this.CodeTextBox.LableText = "Cutting Unit Code";
            this.CodeTextBox.Location = new System.Drawing.Point(0, 0);
            this.CodeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(156, 32);
            this.CodeTextBox.TabIndex = 0;
            // 
            // 
            // 
            this.CodeTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeTextBox.TextBox.Location = new System.Drawing.Point(100, 6);
            this.CodeTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.CodeTextBox.TextBox.MaxLength = 3;
            this.CodeTextBox.TextBox.Name = ".TextBox";
            this.CodeTextBox.TextBox.Size = new System.Drawing.Size(56, 20);
            this.CodeTextBox.TextBox.TabIndex = 1;
            // 
            // CuttingUnitsListBox
            // 
            this.CuttingUnitsListBox.DataSource = this.CuttingUnitBindingSource;
            this.CuttingUnitsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CuttingUnitsListBox.FormatString = "● [Code]";
            this.CuttingUnitsListBox.FormattingEnabled = true;
            this.CuttingUnitsListBox.IntegralHeight = false;
            this.CuttingUnitsListBox.Location = new System.Drawing.Point(0, 25);
            this.CuttingUnitsListBox.Margin = new System.Windows.Forms.Padding(0);
            this.CuttingUnitsListBox.Name = "CuttingUnitsListBox";
            this.CuttingUnitsListBox.ScrollAlwaysVisible = true;
            this.CuttingUnitsListBox.Size = new System.Drawing.Size(148, 323);
            this.CuttingUnitsListBox.TabIndex = 0;
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator.BindingSource = this.CuttingUnitBindingSource;
            this.bindingNavigator.CanOverflow = false;
            this.bindingNavigator.CountItem = null;
            this.bindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.bindingNavigatorAddNewItem,
            this.toolStripSeparator2,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator3});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator.MoveFirstItem = null;
            this.bindingNavigator.MoveLastItem = null;
            this.bindingNavigator.MoveNextItem = null;
            this.bindingNavigator.MovePreviousItem = null;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = null;
            this.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator.Size = new System.Drawing.Size(148, 25);
            this.bindingNavigator.TabIndex = 0;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(74, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.ToolTipText = "Add Cutting Unit";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(60, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            this.toolStripLabel1.Text = "Cutting Units";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.CuttingUnitsListBox);
            this.panel2.Controls.Add(this.bindingNavigator);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(152, 352);
            this.panel2.TabIndex = 65;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 406);
            this.tableLayoutPanel1.TabIndex = 66;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.StrataButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 361);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 39);
            this.panel1.TabIndex = 66;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton.Location = new System.Drawing.Point(10, 7);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(10);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // StrataButton
            // 
            this.StrataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StrataButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StrataButton.Location = new System.Drawing.Point(547, 7);
            this.StrataButton.Margin = new System.Windows.Forms.Padding(10);
            this.StrataButton.Name = "StrataButton";
            this.StrataButton.Size = new System.Drawing.Size(75, 23);
            this.StrataButton.TabIndex = 0;
            this.StrataButton.Text = "Strata >>";
            this.StrataButton.UseVisualStyleBackColor = false;
            this.StrataButton.Click += new System.EventHandler(this.StrataButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 499F));
            this.tableLayoutPanel2.Controls.Add(this.CodeTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DescriptionTextBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.PaymentUnitTextBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.AreaTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(161, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(477, 327);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CuttingUnitBindingSource, "Description", true));
            this.DescriptionTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.DescriptionTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DescriptionTextBox.LabelWidth = 100F;
            this.DescriptionTextBox.LableText = "Description";
            this.DescriptionTextBox.Location = new System.Drawing.Point(0, 64);
            this.DescriptionTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(357, 32);
            this.DescriptionTextBox.TabIndex = 2;
            // 
            // 
            // 
            this.DescriptionTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionTextBox.TextBox.Location = new System.Drawing.Point(100, 6);
            this.DescriptionTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.DescriptionTextBox.TextBox.MaxLength = 25;
            this.DescriptionTextBox.TextBox.Name = ".TextBox";
            this.DescriptionTextBox.TextBox.Size = new System.Drawing.Size(257, 20);
            this.DescriptionTextBox.TextBox.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LogMethComboBox);
            this.panel4.Controls.Add(label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 131);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(493, 26);
            this.panel4.TabIndex = 3;
            // 
            // LogMethComboBox
            // 
            this.LogMethComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.LogMethComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.LogMethComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.CuttingUnitBindingSource, "LoggingMethod", true));
            this.LogMethComboBox.DataSource = this.LoggingMethodBindingSource;
            this.LogMethComboBox.DisplayMember = "CodePlus";
            this.LogMethComboBox.FormattingEnabled = true;
            this.LogMethComboBox.Location = new System.Drawing.Point(88, 4);
            this.LogMethComboBox.Name = "LogMethComboBox";
            this.LogMethComboBox.Size = new System.Drawing.Size(266, 21);
            this.LogMethComboBox.TabIndex = 0;
            this.LogMethComboBox.ValueMember = "Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(158, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.label6.Size = new System.Drawing.Size(483, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cutting Unit";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.CuttingUnitBindingSource;
            // 
            // CuttingUnitsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CuttingUnitsPage";
            this.Size = new System.Drawing.Size(644, 406);
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FMSC.Controls.SideLabelTextBox PaymentUnitTextBox;
        private FMSC.Controls.SideLabelTextBox AreaTextBox;
        private FMSC.Controls.SideLabelTextBox CodeTextBox;
        private System.Windows.Forms.ListBox CuttingUnitsListBox;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private FMSC.Controls.SideLabelTextBox DescriptionTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.BindingSource CuttingUnitBindingSource;
        public System.Windows.Forms.BindingSource LoggingMethodBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox LogMethComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button StrataButton;
    }
}
