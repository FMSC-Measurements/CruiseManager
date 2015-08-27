namespace CSM.UI.CombineCruise
{
    partial class ComponentSelectPage
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("<Child>");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("<Child>");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("<Parent>", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("<Child>");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("<Child>");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("<Parent>", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.@__doneButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.@__ComponentTree = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.@__stratumFirstRB = new System.Windows.Forms.RadioButton();
            this.@__UnitFirstRB = new System.Windows.Forms.RadioButton();
            this.CuttingUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StrataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.@__processBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 411);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.@__processBTN);
            this.panel1.Controls.Add(this.@__doneButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 381);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 30);
            this.panel1.TabIndex = 2;
            // 
            // __doneButton
            // 
            this.@__doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.@__doneButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.@__doneButton.Location = new System.Drawing.Point(505, 4);
            this.@__doneButton.Name = "__doneButton";
            this.@__doneButton.Size = new System.Drawing.Size(75, 23);
            this.@__doneButton.TabIndex = 0;
            this.@__doneButton.Text = "Done";
            this.@__doneButton.UseVisualStyleBackColor = false;
            this.@__doneButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.81661F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.18339F));
            this.tableLayoutPanel2.Controls.Add(this.@__ComponentTree, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.66666F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(578, 375);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // __ComponentTree
            // 
            this.@__ComponentTree.CheckBoxes = true;
            this.@__ComponentTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__ComponentTree.Location = new System.Drawing.Point(158, 38);
            this.@__ComponentTree.Name = "__ComponentTree";
            treeNode7.Name = "Node1";
            treeNode7.Text = "<Child>";
            treeNode8.Name = "Node3";
            treeNode8.Text = "<Child>";
            treeNode9.Name = "Node0";
            treeNode9.Text = "<Parent>";
            treeNode10.Name = "Node5";
            treeNode10.Text = "<Child>";
            treeNode11.Name = "Node6";
            treeNode11.Text = "<Child>";
            treeNode12.Name = "Node4";
            treeNode12.Text = "<Parent>";
            this.@__ComponentTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode12});
            this.@__ComponentTree.Size = new System.Drawing.Size(417, 334);
            this.@__ComponentTree.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.@__stratumFirstRB);
            this.groupBox1.Controls.Add(this.@__UnitFirstRB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 334);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Mode";
            // 
            // __stratumFirstRB
            // 
            this.@__stratumFirstRB.AutoSize = true;
            this.@__stratumFirstRB.Location = new System.Drawing.Point(7, 44);
            this.@__stratumFirstRB.Name = "__stratumFirstRB";
            this.@__stratumFirstRB.Size = new System.Drawing.Size(131, 17);
            this.@__stratumFirstRB.TabIndex = 1;
            this.@__stratumFirstRB.Text = "Stratum -> Cutting Unit";
            this.@__stratumFirstRB.UseVisualStyleBackColor = true;
            this.@__stratumFirstRB.CheckedChanged += new System.EventHandler(this.@__stratumFirstRB_CheckedChanged);
            // 
            // __UnitFirstRB
            // 
            this.@__UnitFirstRB.AutoSize = true;
            this.@__UnitFirstRB.Checked = true;
            this.@__UnitFirstRB.Location = new System.Drawing.Point(7, 20);
            this.@__UnitFirstRB.Name = "__UnitFirstRB";
            this.@__UnitFirstRB.Size = new System.Drawing.Size(131, 17);
            this.@__UnitFirstRB.TabIndex = 0;
            this.@__UnitFirstRB.TabStop = true;
            this.@__UnitFirstRB.Text = "Cutting Unit -> Stratum";
            this.@__UnitFirstRB.UseVisualStyleBackColor = true;
            this.@__UnitFirstRB.CheckedChanged += new System.EventHandler(this.@__UnitFirstRB_CheckedChanged);
            // 
            // CuttingUnitBindingSource
            // 
            this.CuttingUnitBindingSource.DataSource = typeof(CruiseDAL.DataObjects.CuttingUnitDO);
            // 
            // StrataBindingSource
            // 
            this.StrataBindingSource.DataSource = typeof(CruiseDAL.DataObjects.StratumDO);
            // 
            // __processBTN
            // 
            this.@__processBTN.Location = new System.Drawing.Point(424, 3);
            this.@__processBTN.Name = "__processBTN";
            this.@__processBTN.Size = new System.Drawing.Size(75, 23);
            this.@__processBTN.TabIndex = 1;
            this.@__processBTN.Text = "Process";
            this.@__processBTN.UseVisualStyleBackColor = true;
            this.@__processBTN.Click += new System.EventHandler(this.@__processBTN_Click);
            // 
            // ComponentSelectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ComponentSelectPage";
            this.Size = new System.Drawing.Size(584, 411);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button __doneButton;
        public System.Windows.Forms.BindingSource CuttingUnitBindingSource;
        public System.Windows.Forms.BindingSource StrataBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TreeView __ComponentTree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton __stratumFirstRB;
        private System.Windows.Forms.RadioButton __UnitFirstRB;
        private System.Windows.Forms.Button __processBTN;
    }
}
