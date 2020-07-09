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
            this.fullPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._BS_ComponentFiles = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.@__numComLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.@__dateLastMergeLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.@__totalTreeRecLBL = new System.Windows.Forms.Label();
            this.@__searchBTN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._bottomPanel = new System.Windows.Forms.Panel();
            this.@__progressBar = new System.Windows.Forms.ProgressBar();
            this._progressMessageTB = new System.Windows.Forms.TextBox();
            this._cancelButton = new System.Windows.Forms.Button();
            this._goButton = new System.Windows.Forms.Button();
            componentFilesPanel = new System.Windows.Forms.Panel();
            _masterInfoPanel = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            componentFilesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._Components_GV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_ComponentFiles)).BeginInit();
            _masterInfoPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // componentFilesPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(componentFilesPanel, 2);
            componentFilesPanel.Controls.Add(this._Components_GV);
            componentFilesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            componentFilesPanel.Location = new System.Drawing.Point(0, 46);
            componentFilesPanel.Margin = new System.Windows.Forms.Padding(0);
            componentFilesPanel.Name = "componentFilesPanel";
            componentFilesPanel.Padding = new System.Windows.Forms.Padding(3);
            componentFilesPanel.Size = new System.Drawing.Size(556, 373);
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
            this.fullPathDataGridViewTextBoxColumn});
            this._Components_GV.DataSource = this._BS_ComponentFiles;
            this._Components_GV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Components_GV.Location = new System.Drawing.Point(3, 3);
            this._Components_GV.Name = "_Components_GV";
            this._Components_GV.ReadOnly = true;
            this._Components_GV.RowHeadersWidth = 62;
            this._Components_GV.Size = new System.Drawing.Size(550, 367);
            this._Components_GV.TabIndex = 1;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "File Name";
            this.fileNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // treeCountDataGridViewTextBoxColumn
            // 
            this.treeCountDataGridViewTextBoxColumn.DataPropertyName = "TreeCount";
            this.treeCountDataGridViewTextBoxColumn.HeaderText = "Total Trees";
            this.treeCountDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.treeCountDataGridViewTextBoxColumn.Name = "treeCountDataGridViewTextBoxColumn";
            this.treeCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.treeCountDataGridViewTextBoxColumn.Width = 150;
            // 
            // LogCount
            // 
            this.LogCount.DataPropertyName = "LogCount";
            this.LogCount.HeaderText = "Total Logs";
            this.LogCount.MinimumWidth = 8;
            this.LogCount.Name = "LogCount";
            this.LogCount.ReadOnly = true;
            this.LogCount.Width = 150;
            // 
            // PlotCount
            // 
            this.PlotCount.DataPropertyName = "PlotCount";
            this.PlotCount.HeaderText = "Total Plots";
            this.PlotCount.MinimumWidth = 8;
            this.PlotCount.Name = "PlotCount";
            this.PlotCount.ReadOnly = true;
            this.PlotCount.Width = 150;
            // 
            // StemCount
            // 
            this.StemCount.DataPropertyName = "StemCount";
            this.StemCount.HeaderText = "Total Stems";
            this.StemCount.MinimumWidth = 8;
            this.StemCount.Name = "StemCount";
            this.StemCount.ReadOnly = true;
            this.StemCount.Width = 150;
            // 
            // errorsDataGridViewTextBoxColumn
            // 
            this.errorsDataGridViewTextBoxColumn.DataPropertyName = "Errors";
            this.errorsDataGridViewTextBoxColumn.HeaderText = "Errors";
            this.errorsDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.errorsDataGridViewTextBoxColumn.Name = "errorsDataGridViewTextBoxColumn";
            this.errorsDataGridViewTextBoxColumn.ReadOnly = true;
            this.errorsDataGridViewTextBoxColumn.Width = 150;
            // 
            // componentCNDataGridViewTextBoxColumn
            // 
            this.componentCNDataGridViewTextBoxColumn.DataPropertyName = "Component_CN";
            this.componentCNDataGridViewTextBoxColumn.HeaderText = "Component ID #";
            this.componentCNDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.componentCNDataGridViewTextBoxColumn.Name = "componentCNDataGridViewTextBoxColumn";
            this.componentCNDataGridViewTextBoxColumn.ReadOnly = true;
            this.componentCNDataGridViewTextBoxColumn.Width = 150;
            // 
            // fullPathDataGridViewTextBoxColumn
            // 
            this.fullPathDataGridViewTextBoxColumn.DataPropertyName = "FullPath";
            this.fullPathDataGridViewTextBoxColumn.HeaderText = "FullPath";
            this.fullPathDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fullPathDataGridViewTextBoxColumn.Name = "fullPathDataGridViewTextBoxColumn";
            this.fullPathDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullPathDataGridViewTextBoxColumn.Width = 150;
            // 
            // _BS_ComponentFiles
            // 
            this._BS_ComponentFiles.DataSource = typeof(CruiseManager.Core.Components.ComponentFile);
            // 
            // _masterInfoPanel
            // 
            _masterInfoPanel.Controls.Add(groupBox1);
            _masterInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _masterInfoPanel.Location = new System.Drawing.Point(556, 46);
            _masterInfoPanel.Margin = new System.Windows.Forms.Padding(0);
            _masterInfoPanel.Name = "_masterInfoPanel";
            _masterInfoPanel.Padding = new System.Windows.Forms.Padding(3);
            _masterInfoPanel.Size = new System.Drawing.Size(157, 373);
            _masterInfoPanel.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(this.flowLayoutPanel1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(151, 367);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Parent File Info";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.@__numComLBL);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.@__dateLastMergeLBL);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.@__totalTreeRecLBL);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(145, 339);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Of Components";
            // 
            // __numComLBL
            // 
            this.@__numComLBL.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.@__numComLBL, true);
            this.@__numComLBL.Location = new System.Drawing.Point(3, 46);
            this.@__numComLBL.Name = "__numComLBL";
            this.@__numComLBL.Size = new System.Drawing.Size(30, 23);
            this.@__numComLBL.TabIndex = 1;
            this.@__numComLBL.Text = "##";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date Of Last Merge";
            // 
            // __dateLastMergeLBL
            // 
            this.@__dateLastMergeLBL.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.@__dateLastMergeLBL, true);
            this.@__dateLastMergeLBL.Location = new System.Drawing.Point(3, 115);
            this.@__dateLastMergeLBL.Name = "__dateLastMergeLBL";
            this.@__dateLastMergeLBL.Size = new System.Drawing.Size(104, 23);
            this.@__dateLastMergeLBL.TabIndex = 3;
            this.@__dateLastMergeLBL.Text = "##/##/####";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 46);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Tree Records";
            // 
            // __totalTreeRecLBL
            // 
            this.@__totalTreeRecLBL.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.@__totalTreeRecLBL, true);
            this.@__totalTreeRecLBL.Location = new System.Drawing.Point(3, 184);
            this.@__totalTreeRecLBL.Name = "__totalTreeRecLBL";
            this.@__totalTreeRecLBL.Size = new System.Drawing.Size(74, 23);
            this.@__totalTreeRecLBL.TabIndex = 5;
            this.@__totalTreeRecLBL.Text = "###,###";
            // 
            // __searchBTN
            // 
            this.@__searchBTN.AutoSize = true;
            this.@__searchBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.@__searchBTN.Location = new System.Drawing.Point(245, 3);
            this.@__searchBTN.Name = "__searchBTN";
            this.@__searchBTN.Size = new System.Drawing.Size(106, 40);
            this.@__searchBTN.TabIndex = 2;
            this.@__searchBTN.Text = "Refresh List";
            this.@__searchBTN.UseVisualStyleBackColor = true;
            this.@__searchBTN.Click += new System.EventHandler(this.@__searchBTN_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 46);
            this.label5.TabIndex = 3;
            this.label5.Text = "Component Files";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this._bottomPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.@__searchBTN, 1, 0);
            this.tableLayoutPanel1.Controls.Add(_masterInfoPanel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(componentFilesPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(713, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _bottomPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._bottomPanel, 3);
            this._bottomPanel.Controls.Add(this.@__progressBar);
            this._bottomPanel.Controls.Add(this._progressMessageTB);
            this._bottomPanel.Controls.Add(this._cancelButton);
            this._bottomPanel.Controls.Add(this._goButton);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPanel.Location = new System.Drawing.Point(3, 422);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(707, 40);
            this._bottomPanel.TabIndex = 4;
            // 
            // __progressBar
            // 
            this.@__progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__progressBar.Location = new System.Drawing.Point(75, 0);
            this.@__progressBar.Name = "__progressBar";
            this.@__progressBar.Size = new System.Drawing.Size(557, 11);
            this.@__progressBar.TabIndex = 2;
            // 
            // _progressMessageTB
            // 
            this._progressMessageTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._progressMessageTB.Location = new System.Drawing.Point(75, 11);
            this._progressMessageTB.Name = "_progressMessageTB";
            this._progressMessageTB.ReadOnly = true;
            this._progressMessageTB.Size = new System.Drawing.Size(557, 29);
            this._progressMessageTB.TabIndex = 3;
            // 
            // _cancelButton
            // 
            this._cancelButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._cancelButton.Enabled = false;
            this._cancelButton.Location = new System.Drawing.Point(0, 0);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 40);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _goButton
            // 
            this._goButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._goButton.Location = new System.Drawing.Point(632, 0);
            this._goButton.Name = "_goButton";
            this._goButton.Size = new System.Drawing.Size(75, 40);
            this._goButton.TabIndex = 0;
            this._goButton.Text = "Check Files";
            this._goButton.UseVisualStyleBackColor = true;
            this._goButton.Click += new System.EventHandler(this._goButton_Click);
            // 
            // MergeInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "MergeInfoView";
            this.Size = new System.Drawing.Size(713, 465);
            componentFilesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._Components_GV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_ComponentFiles)).EndInit();
            _masterInfoPanel.ResumeLayout(false);
            _masterInfoPanel.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this._bottomPanel.ResumeLayout(false);
            this._bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel _bottomPanel;
        private System.Windows.Forms.ProgressBar __progressBar;
        private System.Windows.Forms.TextBox _progressMessageTB;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _goButton;
    }
}
