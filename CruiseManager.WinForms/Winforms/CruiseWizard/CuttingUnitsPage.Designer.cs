namespace CruiseManager.WinForms.CruiseWizard
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuttingUnitsPage));
            this.CuttingUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoggingMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.LogMethComboBox = new System.Windows.Forms.ComboBox();
            this.AreaTB = new System.Windows.Forms.TextBox();
            this.DescriptionTB = new System.Windows.Forms.TextBox();
            this.PaymentUnitTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.StrataButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(3, 128);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(149, 32);
            label4.TabIndex = 16;
            label4.Text = "Logging Method";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(149, 32);
            label1.TabIndex = 4;
            label1.Text = "Cutting Unit Code";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(3, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(149, 32);
            label2.TabIndex = 6;
            label2.Text = "Area";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 64);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(149, 32);
            label3.TabIndex = 7;
            label3.Text = "Description";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Location = new System.Drawing.Point(3, 96);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(149, 32);
            label5.TabIndex = 8;
            label5.Text = "Payment Unit";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CuttingUnitBindingSource
            // 
            this.CuttingUnitBindingSource.DataSource = typeof(CruiseDAL.DataObjects.CuttingUnitDO);
            this.CuttingUnitBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.CuttingUnitBindingSource_AddingNew);
            this.CuttingUnitBindingSource.CurrentChanged += new System.EventHandler(this.CuttingUnitBindingSource_CurrentChanged);
            // 
            // LoggingMethodBindingSource
            // 
            this.LoggingMethodBindingSource.DataSource = typeof(CruiseManager.Core.SetupModels.LoggingMethod);
            // 
            // CuttingUnitsListBox
            // 
            this.CuttingUnitsListBox.DataSource = this.CuttingUnitBindingSource;
            this.CuttingUnitsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CuttingUnitsListBox.FormatString = "● [Code]";
            this.CuttingUnitsListBox.FormattingEnabled = true;
            this.CuttingUnitsListBox.IntegralHeight = false;
            this.CuttingUnitsListBox.ItemHeight = 23;
            this.CuttingUnitsListBox.Location = new System.Drawing.Point(0, 32);
            this.CuttingUnitsListBox.Margin = new System.Windows.Forms.Padding(0);
            this.CuttingUnitsListBox.Name = "CuttingUnitsListBox";
            this.CuttingUnitsListBox.ScrollAlwaysVisible = true;
            this.CuttingUnitsListBox.Size = new System.Drawing.Size(148, 311);
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
            this.bindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            this.bindingNavigator.Size = new System.Drawing.Size(148, 32);
            this.bindingNavigator.TabIndex = 0;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(111, 29);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.ToolTipText = "Add Cutting Unit";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(90, 29);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 29);
            this.toolStripLabel1.Text = "Cutting Units";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.CuttingUnitsListBox);
            this.panel2.Controls.Add(this.bindingNavigator);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(152, 347);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 406);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CodeTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(label5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.LogMethComboBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.AreaTB, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.DescriptionTB, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.PaymentUnitTB, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(158, 32);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(483, 318);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CuttingUnitBindingSource, "Code", true));
            this.CodeTextBox.Location = new System.Drawing.Point(158, 3);
            this.CodeTextBox.MaxLength = 3;
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(41, 29);
            this.CodeTextBox.TabIndex = 0;
            // 
            // LogMethComboBox
            // 
            this.LogMethComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.LogMethComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel2.SetColumnSpan(this.LogMethComboBox, 2);
            this.LogMethComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.CuttingUnitBindingSource, "LoggingMethod", true));
            this.LogMethComboBox.DataSource = this.LoggingMethodBindingSource;
            this.LogMethComboBox.DisplayMember = "CodePlus";
            this.LogMethComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogMethComboBox.FormattingEnabled = true;
            this.LogMethComboBox.Location = new System.Drawing.Point(158, 131);
            this.LogMethComboBox.Name = "LogMethComboBox";
            this.LogMethComboBox.Size = new System.Drawing.Size(254, 31);
            this.LogMethComboBox.TabIndex = 4;
            this.LogMethComboBox.ValueMember = "Code";
            // 
            // AreaTB
            // 
            this.AreaTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CuttingUnitBindingSource, "Area", true));
            this.AreaTB.Location = new System.Drawing.Point(158, 35);
            this.AreaTB.Name = "AreaTB";
            this.AreaTB.Size = new System.Drawing.Size(41, 29);
            this.AreaTB.TabIndex = 1;
            // 
            // DescriptionTB
            // 
            this.DescriptionTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CuttingUnitBindingSource, "Description", true));
            this.DescriptionTB.Location = new System.Drawing.Point(158, 67);
            this.DescriptionTB.Name = "DescriptionTB";
            this.DescriptionTB.Size = new System.Drawing.Size(245, 29);
            this.DescriptionTB.TabIndex = 2;
            // 
            // PaymentUnitTB
            // 
            this.PaymentUnitTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CuttingUnitBindingSource, "PaymentUnit", true));
            this.PaymentUnitTB.Location = new System.Drawing.Point(158, 99);
            this.PaymentUnitTB.MaxLength = 3;
            this.PaymentUnitTB.Name = "PaymentUnitTB";
            this.PaymentUnitTB.Size = new System.Drawing.Size(41, 29);
            this.PaymentUnitTB.TabIndex = 3;
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
            this.label6.Size = new System.Drawing.Size(483, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cutting Unit";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.Controls.Add(this.StrataButton, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.CancelButton, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 353);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(638, 50);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // StrataButton
            // 
            this.StrataButton.AutoSize = true;
            this.StrataButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StrataButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StrataButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StrataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StrataButton.Location = new System.Drawing.Point(502, 7);
            this.StrataButton.Margin = new System.Windows.Forms.Padding(0);
            this.StrataButton.Name = "StrataButton";
            this.StrataButton.Size = new System.Drawing.Size(96, 35);
            this.StrataButton.TabIndex = 0;
            this.StrataButton.Text = "Strata >>";
            this.StrataButton.UseVisualStyleBackColor = false;
            this.StrataButton.Click += new System.EventHandler(this.StrataButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(39, 7);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(73, 35);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.CuttingUnitBindingSource;
            // 
            // CuttingUnitsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        public System.Windows.Forms.BindingSource CuttingUnitBindingSource;
        public System.Windows.Forms.BindingSource LoggingMethodBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ComboBox LogMethComboBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button StrataButton;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.TextBox AreaTB;
        private System.Windows.Forms.TextBox DescriptionTB;
        private System.Windows.Forms.TextBox PaymentUnitTB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
