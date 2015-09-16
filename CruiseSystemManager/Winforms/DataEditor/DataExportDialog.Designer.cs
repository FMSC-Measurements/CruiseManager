namespace CSM.Winforms.DataEditor
{
    partial class DataExportDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataExportDialog));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TreeColumnsTabPage = new System.Windows.Forms.TabPage();
            this.TreeFieldOrderableAddRemoveWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this.TreeFieldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LogColumnsTabPage = new System.Windows.Forms.TabPage();
            this.LogOrderableAddRemoveWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this.PlotColumnsTabPage = new System.Windows.Forms.TabPage();
            this.PlotFieldOrderableAddRemoveWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this.CountColumnsTabPage = new System.Windows.Forms.TabPage();
            this.CountFieldOrderableAddRemoveWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ExportMethodComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.TreeColumnsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeFieldBindingSource)).BeginInit();
            this.LogColumnsTabPage.SuspendLayout();
            this.PlotColumnsTabPage.SuspendLayout();
            this.CountColumnsTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TreeColumnsTabPage);
            this.tabControl1.Controls.Add(this.LogColumnsTabPage);
            this.tabControl1.Controls.Add(this.PlotColumnsTabPage);
            this.tabControl1.Controls.Add(this.CountColumnsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(382, 279);
            this.tabControl1.TabIndex = 1;
            // 
            // TreeColumnsTabPage
            // 
            this.TreeColumnsTabPage.Controls.Add(this.TreeFieldOrderableAddRemoveWidget);
            this.TreeColumnsTabPage.Location = new System.Drawing.Point(4, 22);
            this.TreeColumnsTabPage.Name = "TreeColumnsTabPage";
            this.TreeColumnsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TreeColumnsTabPage.Size = new System.Drawing.Size(374, 253);
            this.TreeColumnsTabPage.TabIndex = 0;
            this.TreeColumnsTabPage.Text = "Tree Fields";
            this.TreeColumnsTabPage.UseVisualStyleBackColor = true;
            // 
            // TreeFieldOrderableAddRemoveWidget
            // 
            this.TreeFieldOrderableAddRemoveWidget.BackColor = System.Drawing.SystemColors.Control;
            this.TreeFieldOrderableAddRemoveWidget.DataSource = this.TreeFieldBindingSource;
            this.TreeFieldOrderableAddRemoveWidget.DisplayMember = "Field";
            this.TreeFieldOrderableAddRemoveWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeFieldOrderableAddRemoveWidget.Location = new System.Drawing.Point(3, 3);
            this.TreeFieldOrderableAddRemoveWidget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TreeFieldOrderableAddRemoveWidget.MinimumSize = new System.Drawing.Size(0, 183);
            this.TreeFieldOrderableAddRemoveWidget.Name = "TreeFieldOrderableAddRemoveWidget";
            this.TreeFieldOrderableAddRemoveWidget.SelectedItemsDataSource = null;
            this.TreeFieldOrderableAddRemoveWidget.SelectedValue = null;
            this.TreeFieldOrderableAddRemoveWidget.Size = new System.Drawing.Size(368, 247);
            this.TreeFieldOrderableAddRemoveWidget.TabIndex = 0;
            this.TreeFieldOrderableAddRemoveWidget.ValueMember = null;
            // 
            // TreeFieldBindingSource
            // 
            this.TreeFieldBindingSource.DataSource = typeof(CruiseDAL.DataObjects.TreeFieldSetupDO);
            // 
            // LogColumnsTabPage
            // 
            this.LogColumnsTabPage.Controls.Add(this.LogOrderableAddRemoveWidget);
            this.LogColumnsTabPage.Location = new System.Drawing.Point(4, 22);
            this.LogColumnsTabPage.Name = "LogColumnsTabPage";
            this.LogColumnsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogColumnsTabPage.Size = new System.Drawing.Size(374, 253);
            this.LogColumnsTabPage.TabIndex = 1;
            this.LogColumnsTabPage.Text = "Log Fields";
            this.LogColumnsTabPage.UseVisualStyleBackColor = true;
            // 
            // LogOrderableAddRemoveWidget
            // 
            this.LogOrderableAddRemoveWidget.DisplayMember = "Field";
            this.LogOrderableAddRemoveWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogOrderableAddRemoveWidget.Location = new System.Drawing.Point(3, 3);
            this.LogOrderableAddRemoveWidget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LogOrderableAddRemoveWidget.MinimumSize = new System.Drawing.Size(0, 183);
            this.LogOrderableAddRemoveWidget.Name = "LogOrderableAddRemoveWidget";
            this.LogOrderableAddRemoveWidget.SelectedItemsDataSource = null;
            this.LogOrderableAddRemoveWidget.SelectedValue = null;
            this.LogOrderableAddRemoveWidget.Size = new System.Drawing.Size(368, 247);
            this.LogOrderableAddRemoveWidget.TabIndex = 0;
            this.LogOrderableAddRemoveWidget.ValueMember = null;
            // 
            // PlotColumnsTabPage
            // 
            this.PlotColumnsTabPage.Controls.Add(this.PlotFieldOrderableAddRemoveWidget);
            this.PlotColumnsTabPage.Location = new System.Drawing.Point(4, 22);
            this.PlotColumnsTabPage.Name = "PlotColumnsTabPage";
            this.PlotColumnsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PlotColumnsTabPage.Size = new System.Drawing.Size(374, 253);
            this.PlotColumnsTabPage.TabIndex = 2;
            this.PlotColumnsTabPage.Text = "Plot Fields";
            this.PlotColumnsTabPage.UseVisualStyleBackColor = true;
            // 
            // PlotFieldOrderableAddRemoveWidget
            // 
            this.PlotFieldOrderableAddRemoveWidget.DisplayMember = "Field";
            this.PlotFieldOrderableAddRemoveWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlotFieldOrderableAddRemoveWidget.Location = new System.Drawing.Point(3, 3);
            this.PlotFieldOrderableAddRemoveWidget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PlotFieldOrderableAddRemoveWidget.MinimumSize = new System.Drawing.Size(0, 183);
            this.PlotFieldOrderableAddRemoveWidget.Name = "PlotFieldOrderableAddRemoveWidget";
            this.PlotFieldOrderableAddRemoveWidget.SelectedItemsDataSource = null;
            this.PlotFieldOrderableAddRemoveWidget.SelectedValue = null;
            this.PlotFieldOrderableAddRemoveWidget.Size = new System.Drawing.Size(368, 247);
            this.PlotFieldOrderableAddRemoveWidget.TabIndex = 0;
            this.PlotFieldOrderableAddRemoveWidget.ValueMember = null;
            // 
            // CountColumnsTabPage
            // 
            this.CountColumnsTabPage.Controls.Add(this.CountFieldOrderableAddRemoveWidget);
            this.CountColumnsTabPage.Location = new System.Drawing.Point(4, 22);
            this.CountColumnsTabPage.Name = "CountColumnsTabPage";
            this.CountColumnsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CountColumnsTabPage.Size = new System.Drawing.Size(374, 253);
            this.CountColumnsTabPage.TabIndex = 3;
            this.CountColumnsTabPage.Text = "Count Fields";
            this.CountColumnsTabPage.UseVisualStyleBackColor = true;
            // 
            // CountFieldOrderableAddRemoveWidget
            // 
            this.CountFieldOrderableAddRemoveWidget.DisplayMember = "Header";
            this.CountFieldOrderableAddRemoveWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountFieldOrderableAddRemoveWidget.Location = new System.Drawing.Point(3, 3);
            this.CountFieldOrderableAddRemoveWidget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CountFieldOrderableAddRemoveWidget.MinimumSize = new System.Drawing.Size(0, 183);
            this.CountFieldOrderableAddRemoveWidget.Name = "CountFieldOrderableAddRemoveWidget";
            this.CountFieldOrderableAddRemoveWidget.SelectedItemsDataSource = null;
            this.CountFieldOrderableAddRemoveWidget.SelectedValue = null;
            this.CountFieldOrderableAddRemoveWidget.Size = new System.Drawing.Size(368, 247);
            this.CountFieldOrderableAddRemoveWidget.TabIndex = 0;
            this.CountFieldOrderableAddRemoveWidget.ValueMember = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ExportButton);
            this.panel1.Controls.Add(this.ExportMethodComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 282);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 61);
            this.panel1.TabIndex = 2;
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.Location = new System.Drawing.Point(300, 30);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 8;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ExportMethodComboBox
            // 
            this.ExportMethodComboBox.FormattingEnabled = true;
            this.ExportMethodComboBox.Items.AddRange(new object[] {
            "Printable PDF",
            "Excel Spread Sheet (.xls)"});
            this.ExportMethodComboBox.Location = new System.Drawing.Point(75, 3);
            this.ExportMethodComboBox.Name = "ExportMethodComboBox";
            this.ExportMethodComboBox.Size = new System.Drawing.Size(300, 21);
            this.ExportMethodComboBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Export As";
            // 
            // DataExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 343);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataExportDialog";
            this.ShowInTaskbar = false;
            this.Text = "Data Export";
            this.tabControl1.ResumeLayout(false);
            this.TreeColumnsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeFieldBindingSource)).EndInit();
            this.LogColumnsTabPage.ResumeLayout(false);
            this.PlotColumnsTabPage.ResumeLayout(false);
            this.CountColumnsTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TreeColumnsTabPage;
        private System.Windows.Forms.TabPage LogColumnsTabPage;
        private FMSC.Controls.OrderableAddRemoveWidget TreeFieldOrderableAddRemoveWidget;
        private System.Windows.Forms.BindingSource TreeFieldBindingSource;
        private FMSC.Controls.OrderableAddRemoveWidget LogOrderableAddRemoveWidget;
        private System.Windows.Forms.TabPage PlotColumnsTabPage;
        private System.Windows.Forms.TabPage CountColumnsTabPage;
        private FMSC.Controls.OrderableAddRemoveWidget PlotFieldOrderableAddRemoveWidget;
        private FMSC.Controls.OrderableAddRemoveWidget CountFieldOrderableAddRemoveWidget;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.ComboBox ExportMethodComboBox;
        private System.Windows.Forms.Label label1;
    }
}