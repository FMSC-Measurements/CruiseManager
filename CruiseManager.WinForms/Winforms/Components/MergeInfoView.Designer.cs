namespace CruiseManager.WinForms.Components
{
    partial class MergeInfoView
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
            System.Windows.Forms.Panel componentFilesPanel;
            System.Windows.Forms.Panel _masterInfoPanel;
            System.Windows.Forms.GroupBox groupBox1;
            this._Components_GV = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlotCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StemCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentCNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastMergeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._BS_ComponentFiles = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.@__searchBTN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.@__totalTreeRecLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.@__dateLastMergeLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.@__numComLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            componentFilesPanel = new System.Windows.Forms.Panel();
            _masterInfoPanel = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            componentFilesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Components_GV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_ComponentFiles)).BeginInit();
            this.panel1.SuspendLayout();
            _masterInfoPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // componentFilesPanel
            // 
            componentFilesPanel.Controls.Add(this._Components_GV);
            componentFilesPanel.Controls.Add(this.panel1);
            componentFilesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            componentFilesPanel.Location = new System.Drawing.Point(0, 0);
            componentFilesPanel.Margin = new System.Windows.Forms.Padding(0);
            componentFilesPanel.Name = "componentFilesPanel";
            componentFilesPanel.Padding = new System.Windows.Forms.Padding(3);
            componentFilesPanel.Size = new System.Drawing.Size(476, 438);
            componentFilesPanel.TabIndex = 2;
            // 
            // _Components_GV
            // 
            this._Components_GV.AllowUserToAddRows = false;
            this._Components_GV.AllowUserToDeleteRows = false;
            this._Components_GV.AutoGenerateColumns = false;
            this._Components_GV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._Components_GV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.treeCountDataGridViewTextBoxColumn,
            this.LogCount,
            this.PlotCount,
            this.StemCount,
            this.errorsDataGridViewTextBoxColumn,
            this.componentCNDataGridViewTextBoxColumn,
            this.lastMergeDataGridViewTextBoxColumn,
            this.fullPathDataGridViewTextBoxColumn});
            this._Components_GV.DataSource = this._BS_ComponentFiles;
            this._Components_GV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Components_GV.Location = new System.Drawing.Point(3, 36);
            this._Components_GV.Name = "_Components_GV";
            this._Components_GV.ReadOnly = true;
            this._Components_GV.Size = new System.Drawing.Size(470, 399);
            this._Components_GV.TabIndex = 1;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "File Name";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // treeCountDataGridViewTextBoxColumn
            // 
            this.treeCountDataGridViewTextBoxColumn.DataPropertyName = "TreeCount";
            this.treeCountDataGridViewTextBoxColumn.HeaderText = "Total Trees";
            this.treeCountDataGridViewTextBoxColumn.Name = "treeCountDataGridViewTextBoxColumn";
            this.treeCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // LogCount
            // 
            this.LogCount.DataPropertyName = "LogCount";
            this.LogCount.HeaderText = "Total Logs";
            this.LogCount.Name = "LogCount";
            this.LogCount.ReadOnly = true;
            // 
            // PlotCount
            // 
            this.PlotCount.DataPropertyName = "PlotCount";
            this.PlotCount.HeaderText = "Total Plots";
            this.PlotCount.Name = "PlotCount";
            this.PlotCount.ReadOnly = true;
            // 
            // StemCount
            // 
            this.StemCount.DataPropertyName = "StemCount";
            this.StemCount.HeaderText = "Total Stems";
            this.StemCount.Name = "StemCount";
            this.StemCount.ReadOnly = true;
            // 
            // errorsDataGridViewTextBoxColumn
            // 
            this.errorsDataGridViewTextBoxColumn.DataPropertyName = "Errors";
            this.errorsDataGridViewTextBoxColumn.HeaderText = "Errors";
            this.errorsDataGridViewTextBoxColumn.Name = "errorsDataGridViewTextBoxColumn";
            this.errorsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // componentCNDataGridViewTextBoxColumn
            // 
            this.componentCNDataGridViewTextBoxColumn.DataPropertyName = "Component_CN";
            this.componentCNDataGridViewTextBoxColumn.HeaderText = "Component ID #";
            this.componentCNDataGridViewTextBoxColumn.Name = "componentCNDataGridViewTextBoxColumn";
            this.componentCNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastMergeDataGridViewTextBoxColumn
            // 
            this.lastMergeDataGridViewTextBoxColumn.DataPropertyName = "LastMerge";
            this.lastMergeDataGridViewTextBoxColumn.HeaderText = "Last Merge";
            this.lastMergeDataGridViewTextBoxColumn.Name = "lastMergeDataGridViewTextBoxColumn";
            this.lastMergeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fullPathDataGridViewTextBoxColumn
            // 
            this.fullPathDataGridViewTextBoxColumn.DataPropertyName = "FullPath";
            this.fullPathDataGridViewTextBoxColumn.HeaderText = "FullPath";
            this.fullPathDataGridViewTextBoxColumn.Name = "fullPathDataGridViewTextBoxColumn";
            this.fullPathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _BS_ComponentFiles
            // 
            this._BS_ComponentFiles.DataSource = typeof(CruiseManager.Core.Components.ComponentFileVM);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.@__searchBTN);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 33);
            this.panel1.TabIndex = 0;
            // 
            // __searchBTN
            // 
            this.@__searchBTN.Location = new System.Drawing.Point(165, 0);
            this.@__searchBTN.Name = "__searchBTN";
            this.@__searchBTN.Size = new System.Drawing.Size(75, 23);
            this.@__searchBTN.TabIndex = 2;
            this.@__searchBTN.Text = "Refresh List";
            this.@__searchBTN.UseVisualStyleBackColor = true;
            this.@__searchBTN.Click += new System.EventHandler(this.@__searchBTN_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(470, 30);
            this.label5.TabIndex = 3;
            this.label5.Text = "Component Files";
            // 
            // _masterInfoPanel
            // 
            _masterInfoPanel.Controls.Add(groupBox1);
            _masterInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _masterInfoPanel.Location = new System.Drawing.Point(476, 0);
            _masterInfoPanel.Margin = new System.Windows.Forms.Padding(0);
            _masterInfoPanel.Name = "_masterInfoPanel";
            _masterInfoPanel.Padding = new System.Windows.Forms.Padding(3);
            _masterInfoPanel.Size = new System.Drawing.Size(200, 438);
            _masterInfoPanel.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.@__totalTreeRecLBL);
            groupBox1.Controls.Add(this.label4);
            groupBox1.Controls.Add(this.@__dateLastMergeLBL);
            groupBox1.Controls.Add(this.label2);
            groupBox1.Controls.Add(this.@__numComLBL);
            groupBox1.Controls.Add(this.label1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(194, 112);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Master File Info";
            // 
            // __totalTreeRecLBL
            // 
            this.@__totalTreeRecLBL.AutoSize = true;
            this.@__totalTreeRecLBL.Location = new System.Drawing.Point(137, 67);
            this.@__totalTreeRecLBL.Name = "__totalTreeRecLBL";
            this.@__totalTreeRecLBL.Size = new System.Drawing.Size(52, 13);
            this.@__totalTreeRecLBL.TabIndex = 5;
            this.@__totalTreeRecLBL.Text = "###,###";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Tree Records";
            // 
            // __dateLastMergeLBL
            // 
            this.@__dateLastMergeLBL.AutoSize = true;
            this.@__dateLastMergeLBL.Location = new System.Drawing.Point(134, 43);
            this.@__dateLastMergeLBL.Name = "__dateLastMergeLBL";
            this.@__dateLastMergeLBL.Size = new System.Drawing.Size(71, 13);
            this.@__dateLastMergeLBL.TabIndex = 3;
            this.@__dateLastMergeLBL.Text = "##/##/####";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date Of Last Merge";
            // 
            // __numComLBL
            // 
            this.@__numComLBL.AutoSize = true;
            this.@__numComLBL.Location = new System.Drawing.Point(134, 20);
            this.@__numComLBL.Name = "__numComLBL";
            this.@__numComLBL.Size = new System.Drawing.Size(21, 13);
            this.@__numComLBL.TabIndex = 1;
            this.@__numComLBL.Text = "##";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Of Components";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(_masterInfoPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(componentFilesPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(676, 438);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MergeInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "MergeInfoView";
            this.Size = new System.Drawing.Size(676, 438);
            componentFilesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Components_GV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_ComponentFiles)).EndInit();
            this.panel1.ResumeLayout(false);
            _masterInfoPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button __searchBTN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label __totalTreeRecLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label __dateLastMergeLBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label __numComLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource _BS_ComponentFiles;
        private System.Windows.Forms.DataGridView _Components_GV;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlotCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StemCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentCNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastMergeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullPathDataGridViewTextBoxColumn;
    }
}
