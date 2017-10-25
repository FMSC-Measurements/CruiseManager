namespace CruiseManager.WinForms.CruiseCustomize
{
    partial class ReportsView
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
            this._BS_Reports = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._reportsDGV = new System.Windows.Forms.DataGridView();
            this.reportIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this._reportsClearSltnBTN = new System.Windows.Forms.Button();
            this._reportsSelectAllBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._BS_Reports)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._reportsDGV)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // _BS_Reports
            // 
            this._BS_Reports.DataSource = typeof(CruiseDAL.DataObjects.ReportsDO);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this._reportsDGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 382);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _reportsDGV
            // 
            this._reportsDGV.AutoGenerateColumns = false;
            this._reportsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._reportsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reportIDDataGridViewTextBoxColumn,
            this.selectedDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn});
            this._reportsDGV.DataSource = this._BS_Reports;
            this._reportsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._reportsDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this._reportsDGV.Location = new System.Drawing.Point(3, 23);
            this._reportsDGV.Name = "_reportsDGV";
            this._reportsDGV.Size = new System.Drawing.Size(342, 356);
            this._reportsDGV.TabIndex = 8;
            // 
            // reportIDDataGridViewTextBoxColumn
            // 
            this.reportIDDataGridViewTextBoxColumn.DataPropertyName = "ReportID";
            this.reportIDDataGridViewTextBoxColumn.HeaderText = "ReportID";
            this.reportIDDataGridViewTextBoxColumn.Name = "reportIDDataGridViewTextBoxColumn";
            this.reportIDDataGridViewTextBoxColumn.ToolTipText = "Report Number";
            // 
            // selectedDataGridViewTextBoxColumn
            // 
            this.selectedDataGridViewTextBoxColumn.DataPropertyName = "Selected";
            this.selectedDataGridViewTextBoxColumn.HeaderText = "Selected";
            this.selectedDataGridViewTextBoxColumn.Name = "selectedDataGridViewTextBoxColumn";
            this.selectedDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ToolTipText = "Report Title";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel5.Controls.Add(this._reportsClearSltnBTN);
            this.panel5.Controls.Add(this._reportsSelectAllBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(348, 20);
            this.panel5.TabIndex = 7;
            // 
            // _reportsClearSltnBTN
            // 
            this._reportsClearSltnBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this._reportsClearSltnBTN.Location = new System.Drawing.Point(75, 0);
            this._reportsClearSltnBTN.Name = "_reportsClearSltnBTN";
            this._reportsClearSltnBTN.Size = new System.Drawing.Size(87, 20);
            this._reportsClearSltnBTN.TabIndex = 1;
            this._reportsClearSltnBTN.Text = "Clear Selection";
            this._reportsClearSltnBTN.UseVisualStyleBackColor = true;
            this._reportsClearSltnBTN.Click += new System.EventHandler(this._reportsClearSltnBTN_Click);
            // 
            // _reportsSelectAllBtn
            // 
            this._reportsSelectAllBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this._reportsSelectAllBtn.Location = new System.Drawing.Point(0, 0);
            this._reportsSelectAllBtn.Name = "_reportsSelectAllBtn";
            this._reportsSelectAllBtn.Size = new System.Drawing.Size(75, 20);
            this._reportsSelectAllBtn.TabIndex = 0;
            this._reportsSelectAllBtn.Text = "Select All";
            this._reportsSelectAllBtn.UseVisualStyleBackColor = true;
            this._reportsSelectAllBtn.Click += new System.EventHandler(this._reportsSelectAllBtn_Click);
            // 
            // ReportsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReportsView";
            this.Size = new System.Drawing.Size(348, 382);
            ((System.ComponentModel.ISupportInitialize)(this._BS_Reports)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._reportsDGV)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource _BS_Reports;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button _reportsClearSltnBTN;
        private System.Windows.Forms.Button _reportsSelectAllBtn;
        private System.Windows.Forms.DataGridView _reportsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
    }
}