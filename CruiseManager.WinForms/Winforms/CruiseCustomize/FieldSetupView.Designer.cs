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
            this.panel3 = new System.Windows.Forms.Panel();
            this._treeFieldWidthTB = new System.Windows.Forms.TextBox();
            this._BS_TreeField = new System.Windows.Forms.BindingSource(this.components);
            this._TreeFieldHeadingTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._logField_TabPage = new System.Windows.Forms.TabPage();
            this._logFieldWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this.panel4 = new System.Windows.Forms.Panel();
            this._logFieldWidthTB = new System.Windows.Forms.TextBox();
            this._BS_LogField = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this._logFieldHeadingTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._strataLB = new System.Windows.Forms.ListBox();
            label20 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            this._fieldSetup_Child_TabControl.SuspendLayout();
            this._treeField_TabPage.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeField)).BeginInit();
            this._logField_TabPage.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogField)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(240, 27);
            label20.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(93, 13);
            label20.TabIndex = 4;
            label20.Text = "(0 = Auto Width)";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(134, 7);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(115, 13);
            label13.TabIndex = 2;
            label13.Text = "Width (in Characters)";
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
            this._treeField_TabPage.Controls.Add(this.panel3);
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
            this._treeFieldWidget.Size = new System.Drawing.Size(563, 365);
            this._treeFieldWidget.TabIndex = 0;
            this._treeFieldWidget.ValueMember = null;
            this._treeFieldWidget.SelectionMoved += new FMSC.Controls.ItemMovedEventHandler(this._treeFieldWidget_SelectionMoved);
            this._treeFieldWidget.SelectionAdded += new FMSC.Controls.SelectionAddedEventHandler(this._treeFieldWidget_SelectionAdded);
            this._treeFieldWidget.SelectedValueChanged += new FMSC.Controls.SelectedValueChangedEventHandler(this._treeFieldWidget_SelectedValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(label20);
            this.panel3.Controls.Add(this._treeFieldWidthTB);
            this.panel3.Controls.Add(label13);
            this.panel3.Controls.Add(this._TreeFieldHeadingTB);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 368);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(563, 49);
            this.panel3.TabIndex = 2;
            // 
            // _treeFieldWidthTB
            // 
            this._treeFieldWidthTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TreeField, "Width", true));
            this._treeFieldWidthTB.Location = new System.Drawing.Point(137, 24);
            this._treeFieldWidthTB.Name = "_treeFieldWidthTB";
            this._treeFieldWidthTB.Size = new System.Drawing.Size(100, 22);
            this._treeFieldWidthTB.TabIndex = 3;
            // 
            // _BS_TreeField
            // 
            this._BS_TreeField.DataSource = typeof(CruiseDAL.DataObjects.TreeFieldSetupDefaultDO);
            // 
            // _TreeFieldHeadingTB
            // 
            this._TreeFieldHeadingTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TreeField, "Heading", true));
            this._TreeFieldHeadingTB.Location = new System.Drawing.Point(7, 24);
            this._TreeFieldHeadingTB.Name = "_TreeFieldHeadingTB";
            this._TreeFieldHeadingTB.Size = new System.Drawing.Size(100, 22);
            this._TreeFieldHeadingTB.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Heading";
            // 
            // _logField_TabPage
            // 
            this._logField_TabPage.Controls.Add(this._logFieldWidget);
            this._logField_TabPage.Controls.Add(this.panel4);
            this._logField_TabPage.Location = new System.Drawing.Point(4, 22);
            this._logField_TabPage.Name = "_logField_TabPage";
            this._logField_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this._logField_TabPage.Size = new System.Drawing.Size(192, 74);
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
            this._logFieldWidget.Size = new System.Drawing.Size(186, 183);
            this._logFieldWidget.TabIndex = 0;
            this._logFieldWidget.ValueMember = null;
            this._logFieldWidget.SelectionMoved += new FMSC.Controls.ItemMovedEventHandler(this._logFieldWidget_SelectionMoved);
            this._logFieldWidget.SelectionAdded += new FMSC.Controls.SelectionAddedEventHandler(this._logFieldWidget_SelectionAdded);
            this._logFieldWidget.SelectedValueChanged += new FMSC.Controls.SelectedValueChangedEventHandler(this._logFieldWidget_SelectedValueChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._logFieldWidthTB);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this._logFieldHeadingTB);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(186, 49);
            this.panel4.TabIndex = 3;
            // 
            // _logFieldWidthTB
            // 
            this._logFieldWidthTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_LogField, "Width", true));
            this._logFieldWidthTB.Location = new System.Drawing.Point(137, 24);
            this._logFieldWidthTB.Name = "_logFieldWidthTB";
            this._logFieldWidthTB.Size = new System.Drawing.Size(100, 22);
            this._logFieldWidthTB.TabIndex = 5;
            // 
            // _BS_LogField
            // 
            this._BS_LogField.DataSource = typeof(CruiseDAL.DataObjects.LogFieldSetupDefaultDO);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(134, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(206, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Width (leave empty to use Auto Width)";
            // 
            // _logFieldHeadingTB
            // 
            this._logFieldHeadingTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_LogField, "Heading", true));
            this._logFieldHeadingTB.Location = new System.Drawing.Point(7, 24);
            this._logFieldHeadingTB.Name = "_logFieldHeadingTB";
            this._logFieldHeadingTB.Size = new System.Drawing.Size(100, 22);
            this._logFieldHeadingTB.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 7);
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
            // FieldSetupView
            // 
            this.Controls.Add(this._fieldSetup_Child_TabControl);
            this.Controls.Add(this.groupBox3);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "FieldSetupView";
            this.Size = new System.Drawing.Size(711, 446);
            this._fieldSetup_Child_TabControl.ResumeLayout(false);
            this._treeField_TabPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeField)).EndInit();
            this._logField_TabPage.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogField)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _fieldSetup_Child_TabControl;
        private System.Windows.Forms.TabPage _treeField_TabPage;
        private FMSC.Controls.OrderableAddRemoveWidget _treeFieldWidget;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox _treeFieldWidthTB;
        private System.Windows.Forms.BindingSource _BS_TreeField;
        private System.Windows.Forms.TextBox _TreeFieldHeadingTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage _logField_TabPage;
        private FMSC.Controls.OrderableAddRemoveWidget _logFieldWidget;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox _logFieldWidthTB;
        private System.Windows.Forms.BindingSource _BS_LogField;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox _logFieldHeadingTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox _strataLB;
    }
}
