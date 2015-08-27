namespace CSM.UI
{
    partial class MergeComponentView
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
            System.Windows.Forms.Panel leftContentPanel;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tree edits:");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Log edits");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Edits", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Structure edits:");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Trees removed:");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Logs removed:");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Warnings:", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Structure conflicts:");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Data conflicts:");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Errors:", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Panel rightContentPanel;
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "<file name>",
            "##/##/####",
            "##",
            "##",
            "##"}, -1);
            System.Windows.Forms.ColumnHeader FileName;
            System.Windows.Forms.ColumnHeader LastMod;
            System.Windows.Forms.ColumnHeader Edits;
            System.Windows.Forms.ColumnHeader Errors;
            this.@__mergePreviewGB = new System.Windows.Forms.GroupBox();
            this.@__previewInfoTV = new System.Windows.Forms.TreeView();
            this.@__previewTotalTreeRecLBL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.@__totalTreeRecLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.@__dateLastMergeLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.@__numComLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.@__CompListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.lowerRightContentPanel = new System.Windows.Forms.Panel();
            this.@__progressBar = new System.Windows.Forms.ProgressBar();
            this.@__mergeBTN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.@__searchBTN = new System.Windows.Forms.Button();
            this.@__browseSearchPathBTN = new System.Windows.Forms.Button();
            this.@__searchPathTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            leftContentPanel = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            rightContentPanel = new System.Windows.Forms.Panel();
            FileName = new System.Windows.Forms.ColumnHeader();
            LastMod = new System.Windows.Forms.ColumnHeader();
            Edits = new System.Windows.Forms.ColumnHeader();
            Errors = new System.Windows.Forms.ColumnHeader();
            leftContentPanel.SuspendLayout();
            this.@__mergePreviewGB.SuspendLayout();
            groupBox1.SuspendLayout();
            rightContentPanel.SuspendLayout();
            this.lowerRightContentPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftContentPanel
            // 
            leftContentPanel.Controls.Add(this.@__mergePreviewGB);
            leftContentPanel.Controls.Add(groupBox1);
            leftContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftContentPanel.Location = new System.Drawing.Point(0, 0);
            leftContentPanel.Margin = new System.Windows.Forms.Padding(0);
            leftContentPanel.Name = "leftContentPanel";
            leftContentPanel.Padding = new System.Windows.Forms.Padding(3);
            leftContentPanel.Size = new System.Drawing.Size(230, 359);
            leftContentPanel.TabIndex = 0;
            // 
            // __mergePreviewGB
            // 
            this.@__mergePreviewGB.Controls.Add(this.@__previewInfoTV);
            this.@__mergePreviewGB.Controls.Add(this.@__previewTotalTreeRecLBL);
            this.@__mergePreviewGB.Controls.Add(this.label3);
            this.@__mergePreviewGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.@__mergePreviewGB.Location = new System.Drawing.Point(3, 115);
            this.@__mergePreviewGB.Name = "__mergePreviewGB";
            this.@__mergePreviewGB.Size = new System.Drawing.Size(224, 156);
            this.@__mergePreviewGB.TabIndex = 2;
            this.@__mergePreviewGB.TabStop = false;
            this.@__mergePreviewGB.Text = "Merge Preview";
            // 
            // __previewInfoTV
            // 
            this.@__previewInfoTV.BackColor = System.Drawing.Color.White;
            this.@__previewInfoTV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.@__previewInfoTV.Location = new System.Drawing.Point(3, 42);
            this.@__previewInfoTV.Name = "__previewInfoTV";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Tree edits:";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Log edits";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Edits";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Structure edits:";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Trees removed:";
            treeNode6.Name = "Node6";
            treeNode6.Text = "Logs removed:";
            treeNode7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            treeNode7.Name = "Node3";
            treeNode7.Text = "Warnings:";
            treeNode8.Name = "Node8";
            treeNode8.Text = "Structure conflicts:";
            treeNode9.Name = "Node9";
            treeNode9.Text = "Data conflicts:";
            treeNode10.ForeColor = System.Drawing.Color.Red;
            treeNode10.Name = "Node7";
            treeNode10.Text = "Errors:";
            this.@__previewInfoTV.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7,
            treeNode10});
            this.@__previewInfoTV.Size = new System.Drawing.Size(218, 111);
            this.@__previewInfoTV.TabIndex = 2;
            this.@__previewInfoTV.Visible = false;
            // 
            // __previewTotalTreeRecLBL
            // 
            this.@__previewTotalTreeRecLBL.AutoSize = true;
            this.@__previewTotalTreeRecLBL.Location = new System.Drawing.Point(116, 19);
            this.@__previewTotalTreeRecLBL.Name = "__previewTotalTreeRecLBL";
            this.@__previewTotalTreeRecLBL.Size = new System.Drawing.Size(52, 13);
            this.@__previewTotalTreeRecLBL.TabIndex = 1;
            this.@__previewTotalTreeRecLBL.Text = "###,###";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Tree Records ";
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
            groupBox1.Size = new System.Drawing.Size(224, 112);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Parent Cruise Info";
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
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Tree Records";
            // 
            // __dateLastMergeLBL
            // 
            this.@__dateLastMergeLBL.AutoSize = true;
            this.@__dateLastMergeLBL.Location = new System.Drawing.Point(134, 43);
            this.@__dateLastMergeLBL.Name = "__dateLastMergeLBL";
            this.@__dateLastMergeLBL.Size = new System.Drawing.Size(73, 13);
            this.@__dateLastMergeLBL.TabIndex = 3;
            this.@__dateLastMergeLBL.Text = "##/##/####";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
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
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Of Components";
            // 
            // rightContentPanel
            // 
            rightContentPanel.Controls.Add(this.@__CompListView);
            rightContentPanel.Controls.Add(this.lowerRightContentPanel);
            rightContentPanel.Controls.Add(this.panel1);
            rightContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightContentPanel.Location = new System.Drawing.Point(230, 0);
            rightContentPanel.Margin = new System.Windows.Forms.Padding(0);
            rightContentPanel.Name = "rightContentPanel";
            rightContentPanel.Padding = new System.Windows.Forms.Padding(3);
            rightContentPanel.Size = new System.Drawing.Size(331, 359);
            rightContentPanel.TabIndex = 1;
            // 
            // __CompListView
            // 
            this.@__CompListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            FileName,
            LastMod,
            Edits,
            Errors,
            this.columnHeader5});
            this.@__CompListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__CompListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.@__CompListView.Location = new System.Drawing.Point(3, 83);
            this.@__CompListView.Name = "__CompListView";
            this.@__CompListView.Size = new System.Drawing.Size(325, 251);
            this.@__CompListView.TabIndex = 1;
            this.@__CompListView.UseCompatibleStateImageBehavior = false;
            this.@__CompListView.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            FileName.Text = "File Name";
            FileName.Width = 69;
            // 
            // LastMod
            // 
            LastMod.Text = "Last Modified";
            LastMod.Width = 86;
            // 
            // Edits
            // 
            Edits.Text = "Edits";
            Edits.Width = 40;
            // 
            // Errors
            // 
            Errors.Text = "Warnings";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Errors";
            this.columnHeader5.Width = 45;
            // 
            // lowerRightContentPanel
            // 
            this.lowerRightContentPanel.Controls.Add(this.@__progressBar);
            this.lowerRightContentPanel.Controls.Add(this.@__mergeBTN);
            this.lowerRightContentPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lowerRightContentPanel.Location = new System.Drawing.Point(3, 334);
            this.lowerRightContentPanel.Name = "lowerRightContentPanel";
            this.lowerRightContentPanel.Size = new System.Drawing.Size(325, 22);
            this.lowerRightContentPanel.TabIndex = 2;
            // 
            // __progressBar
            // 
            this.@__progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__progressBar.Location = new System.Drawing.Point(0, 0);
            this.@__progressBar.Name = "__progressBar";
            this.@__progressBar.Size = new System.Drawing.Size(250, 22);
            this.@__progressBar.TabIndex = 1;
            this.@__progressBar.Visible = false;
            // 
            // __mergeBTN
            // 
            this.@__mergeBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.@__mergeBTN.Location = new System.Drawing.Point(250, 0);
            this.@__mergeBTN.Name = "__mergeBTN";
            this.@__mergeBTN.Size = new System.Drawing.Size(75, 22);
            this.@__mergeBTN.TabIndex = 0;
            this.@__mergeBTN.Text = "Merge";
            this.@__mergeBTN.UseVisualStyleBackColor = true;
            this.@__mergeBTN.Click += new System.EventHandler(this.@__mergeBTN_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.@__searchBTN);
            this.panel1.Controls.Add(this.@__browseSearchPathBTN);
            this.panel1.Controls.Add(this.@__searchPathTB);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 80);
            this.panel1.TabIndex = 0;
            // 
            // __searchBTN
            // 
            this.@__searchBTN.Location = new System.Drawing.Point(123, 54);
            this.@__searchBTN.Name = "__searchBTN";
            this.@__searchBTN.Size = new System.Drawing.Size(75, 23);
            this.@__searchBTN.TabIndex = 2;
            this.@__searchBTN.Text = "Search";
            this.@__searchBTN.UseVisualStyleBackColor = true;
            this.@__searchBTN.Click += new System.EventHandler(this.@__searchBTN_Click);
            // 
            // __browseSearchPathBTN
            // 
            this.@__browseSearchPathBTN.Location = new System.Drawing.Point(4, 54);
            this.@__browseSearchPathBTN.Name = "__browseSearchPathBTN";
            this.@__browseSearchPathBTN.Size = new System.Drawing.Size(113, 23);
            this.@__browseSearchPathBTN.TabIndex = 1;
            this.@__browseSearchPathBTN.Text = "Select Search Path";
            this.@__browseSearchPathBTN.UseVisualStyleBackColor = true;
            this.@__browseSearchPathBTN.Click += new System.EventHandler(this.@__browseSearchPathBTN_Click);
            // 
            // __searchPathTB
            // 
            this.@__searchPathTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.@__searchPathTB.Location = new System.Drawing.Point(0, 30);
            this.@__searchPathTB.Name = "__searchPathTB";
            this.@__searchPathTB.Size = new System.Drawing.Size(325, 20);
            this.@__searchPathTB.TabIndex = 0;
            this.@__searchPathTB.Text = "<Search Path>";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(325, 30);
            this.label5.TabIndex = 3;
            this.label5.Text = "Component Files";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.99822F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.00178F));
            this.tableLayoutPanel1.Controls.Add(leftContentPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(rightContentPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 359);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MergeComponentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MergeComponentView";
            this.Size = new System.Drawing.Size(561, 359);
            leftContentPanel.ResumeLayout(false);
            this.@__mergePreviewGB.ResumeLayout(false);
            this.@__mergePreviewGB.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            rightContentPanel.ResumeLayout(false);
            this.lowerRightContentPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox __mergePreviewGB;
        private System.Windows.Forms.TreeView __previewInfoTV;
        private System.Windows.Forms.Label __previewTotalTreeRecLBL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label __totalTreeRecLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label __dateLastMergeLBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label __numComLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView __CompListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button __searchBTN;
        private System.Windows.Forms.Button __browseSearchPathBTN;
        private System.Windows.Forms.TextBox __searchPathTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel lowerRightContentPanel;
        private System.Windows.Forms.ProgressBar __progressBar;
        private System.Windows.Forms.Button __mergeBTN;
    }
}
