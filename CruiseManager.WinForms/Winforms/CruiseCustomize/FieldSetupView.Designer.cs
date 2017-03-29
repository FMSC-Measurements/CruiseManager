namespace CruiseManager.WinForms.CruiseCustomize
{
    partial class FieldSetupView
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
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label13;
            this._fieldSetup_Child_TabControl = new System.Windows.Forms.TabControl();
            this._treeField_TabPage = new System.Windows.Forms.TabPage();
            this._treeFieldWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this._treeFieldWidthTB = new System.Windows.Forms.TextBox();
            this._BS_TreeField = new System.Windows.Forms.BindingSource(this.components);
            this._TreeFieldHeadingTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._logField_TabPage = new System.Windows.Forms.TabPage();
            this._logFieldWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this._logFieldWidthTB = new System.Windows.Forms.TextBox();
            this._BS_LogField = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this._logFieldHeadingTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._strataLB = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            label20 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            this._fieldSetup_Child_TabControl.SuspendLayout();
            this._treeField_TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeField)).BeginInit();
            this._logField_TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogField)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            label20.Dock = System.Windows.Forms.DockStyle.Fill;
            label20.Location = new System.Drawing.Point(221, 13);
            label20.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(339, 28);
            label20.TabIndex = 4;
            label20.Text = "(0 = Auto Width)";
            label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = System.Windows.Forms.DockStyle.Fill;
            label13.Location = new System.Drawing.Point(103, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(115, 13);
            label13.TabIndex = 2;
            label13.Text = "Width (in Characters)";
            label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // _fieldSetup_Child_TabControl
            // 
            this._fieldSetup_Child_TabControl.Controls.Add(this._treeField_TabPage);
            this._fieldSetup_Child_TabControl.Controls.Add(this._logField_TabPage);
            this._fieldSetup_Child_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._fieldSetup_Child_TabControl.Location = new System.Drawing.Point(134, 0);
            this._fieldSetup_Child_TabControl.Margin = new System.Windows.Forms.Padding(0);
            this._fieldSetup_Child_TabControl.Name = "_fieldSetup_Child_TabControl";
            this._fieldSetup_Child_TabControl.Padding = new System.Drawing.Point(0, 0);
            this._fieldSetup_Child_TabControl.SelectedIndex = 0;
            this._fieldSetup_Child_TabControl.Size = new System.Drawing.Size(577, 446);
            this._fieldSetup_Child_TabControl.TabIndex = 4;
            // 
            // _treeField_TabPage
            // 
            this._treeField_TabPage.Controls.Add(this._treeFieldWidget);
            this._treeField_TabPage.Controls.Add(this.tableLayoutPanel1);
            this._treeField_TabPage.Location = new System.Drawing.Point(4, 22);
            this._treeField_TabPage.Name = "_treeField_TabPage";
            this._treeField_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this._treeField_TabPage.Size = new System.Drawing.Size(569, 420);
            this._treeField_TabPage.TabIndex = 0;
            this._treeField_TabPage.Text = "Tree Field Setup";
            this._treeField_TabPage.UseVisualStyleBackColor = true;
            // 
            // _treeFieldWidget
            // 
            this._treeFieldWidget.DisplayMember = "Field";
            this._treeFieldWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeFieldWidget.Location = new System.Drawing.Point(3, 3);
            this._treeFieldWidget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._treeFieldWidget.MinimumSize = new System.Drawing.Size(0, 183);
            this._treeFieldWidget.Name = "_treeFieldWidget";
            this._treeFieldWidget.SelectedItemsDataSource = null;
            this._treeFieldWidget.SelectedValue = null;
            this._treeFieldWidget.Size = new System.Drawing.Size(563, 373);
            this._treeFieldWidget.TabIndex = 0;
            this._treeFieldWidget.ValueMember = null;
            this._treeFieldWidget.SelectionMoved += new FMSC.Controls.ItemMovedEventHandler(this._treeFieldWidget_SelectionMoved);
            this._treeFieldWidget.SelectionAdded += new FMSC.Controls.SelectionAddedEventHandler(this._treeFieldWidget_SelectionAdded);
            this._treeFieldWidget.SelectedValueChanged += new FMSC.Controls.SelectedValueChangedEventHandler(this._treeFieldWidget_SelectedValueChanged);
            // 
            // _treeFieldWidthTB
            // 
            this._treeFieldWidthTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TreeField, "Width", true));
            this._treeFieldWidthTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeFieldWidthTB.Location = new System.Drawing.Point(103, 16);
            this._treeFieldWidthTB.Name = "_treeFieldWidthTB";
            this._treeFieldWidthTB.Size = new System.Drawing.Size(115, 22);
            this._treeFieldWidthTB.TabIndex = 3;
            // 
            // _BS_TreeField
            // 
            this._BS_TreeField.DataSource = typeof(CruiseDAL.DataObjects.TreeFieldSetupDefaultDO);
            // 
            // _TreeFieldHeadingTB
            // 
            this._TreeFieldHeadingTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TreeField, "Heading", true));
            this._TreeFieldHeadingTB.Location = new System.Drawing.Point(3, 16);
            this._TreeFieldHeadingTB.Name = "_TreeFieldHeadingTB";
            this._TreeFieldHeadingTB.Size = new System.Drawing.Size(94, 22);
            this._TreeFieldHeadingTB.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Heading";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // _logField_TabPage
            // 
            this._logField_TabPage.Controls.Add(this._logFieldWidget);
            this._logField_TabPage.Controls.Add(this.tableLayoutPanel2);
            this._logField_TabPage.Location = new System.Drawing.Point(4, 22);
            this._logField_TabPage.Name = "_logField_TabPage";
            this._logField_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this._logField_TabPage.Size = new System.Drawing.Size(569, 420);
            this._logField_TabPage.TabIndex = 1;
            this._logField_TabPage.Text = "Log Field Setup";
            this._logField_TabPage.UseVisualStyleBackColor = true;
            // 
            // _logFieldWidget
            // 
            this._logFieldWidget.DisplayMember = "Field";
            this._logFieldWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logFieldWidget.Location = new System.Drawing.Point(3, 3);
            this._logFieldWidget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._logFieldWidget.MinimumSize = new System.Drawing.Size(0, 183);
            this._logFieldWidget.Name = "_logFieldWidget";
            this._logFieldWidget.SelectedItemsDataSource = null;
            this._logFieldWidget.SelectedValue = null;
            this._logFieldWidget.Size = new System.Drawing.Size(563, 373);
            this._logFieldWidget.TabIndex = 0;
            this._logFieldWidget.ValueMember = null;
            this._logFieldWidget.SelectionMoved += new FMSC.Controls.ItemMovedEventHandler(this._logFieldWidget_SelectionMoved);
            this._logFieldWidget.SelectionAdded += new FMSC.Controls.SelectionAddedEventHandler(this._logFieldWidget_SelectionAdded);
            this._logFieldWidget.SelectedValueChanged += new FMSC.Controls.SelectedValueChangedEventHandler(this._logFieldWidget_SelectedValueChanged);
            // 
            // _logFieldWidthTB
            // 
            this._logFieldWidthTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_LogField, "Width", true));
            this._logFieldWidthTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logFieldWidthTB.Location = new System.Drawing.Point(103, 16);
            this._logFieldWidthTB.Name = "_logFieldWidthTB";
            this._logFieldWidthTB.Size = new System.Drawing.Size(94, 22);
            this._logFieldWidthTB.TabIndex = 5;
            // 
            // _BS_LogField
            // 
            this._BS_LogField.DataSource = typeof(CruiseDAL.DataObjects.LogFieldSetupDefaultDO);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label14, 2);
            this.label14.Location = new System.Drawing.Point(103, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(206, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Width (leave empty to use Auto Width)";
            // 
            // _logFieldHeadingTB
            // 
            this._logFieldHeadingTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_LogField, "Heading", true));
            this._logFieldHeadingTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logFieldHeadingTB.Location = new System.Drawing.Point(3, 16);
            this._logFieldHeadingTB.Name = "_logFieldHeadingTB";
            this._logFieldHeadingTB.Size = new System.Drawing.Size(94, 22);
            this._logFieldHeadingTB.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Heading";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._strataLB);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 446);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Strata";
            // 
            // _strataLB
            // 
            this._strataLB.DisplayMember = "FriendlyStr";
            this._strataLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._strataLB.Location = new System.Drawing.Point(3, 18);
            this._strataLB.Name = "_strataLB";
            this._strataLB.Size = new System.Drawing.Size(128, 425);
            this._strataLB.TabIndex = 0;
            this._strataLB.SelectedValueChanged += new System.EventHandler(this._strataLB_SelectedValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(label20, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._treeFieldWidthTB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(label13, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._TreeFieldHeadingTB, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 376);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 41);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this._logFieldHeadingTB, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this._logFieldWidthTB, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 376);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(563, 41);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // FieldSetupView
            // 
            this.Controls.Add(this._fieldSetup_Child_TabControl);
            this.Controls.Add(this.groupBox3);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "FieldSetupView";
            this.Size = new System.Drawing.Size(711, 446);
            this._fieldSetup_Child_TabControl.ResumeLayout(false);
            this._treeField_TabPage.ResumeLayout(false);
            this._treeField_TabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeField)).EndInit();
            this._logField_TabPage.ResumeLayout(false);
            this._logField_TabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogField)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _fieldSetup_Child_TabControl;
        private System.Windows.Forms.TabPage _treeField_TabPage;
        private FMSC.Controls.OrderableAddRemoveWidget _treeFieldWidget;
        private System.Windows.Forms.TextBox _treeFieldWidthTB;
        private System.Windows.Forms.BindingSource _BS_TreeField;
        private System.Windows.Forms.TextBox _TreeFieldHeadingTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage _logField_TabPage;
        private FMSC.Controls.OrderableAddRemoveWidget _logFieldWidget;
        private System.Windows.Forms.TextBox _logFieldWidthTB;
        private System.Windows.Forms.BindingSource _BS_LogField;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _logFieldHeadingTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox _strataLB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
