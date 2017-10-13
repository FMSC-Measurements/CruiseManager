namespace CruiseManager.WinForms.Components
{
    partial class PreMergeReportView
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
            this._TH_conflicts = new System.Windows.Forms.TabControl();
            this._TH_additions = new System.Windows.Forms.TabControl();
            this.componentRowIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this._TP_conflicts = new System.Windows.Forms.TabPage();
            this._TP_matches = new System.Windows.Forms.TabPage();
            this._TH_matches = new System.Windows.Forms.TabControl();
            this._TP_new = new System.Windows.Forms.TabPage();
            this.TreeDO = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this._BS_treeMatches = new System.Windows.Forms.BindingSource(this.components);
            this._BS_TreeConflicts = new System.Windows.Forms.BindingSource(this.components);
            this._BS_LogConflicts = new System.Windows.Forms.BindingSource(this.components);
            this._BS_StemConflicts = new System.Windows.Forms.BindingSource(this.components);
            this._BS_PlotConflicts = new System.Windows.Forms.BindingSource(this.components);
            this._BS_logMatches = new System.Windows.Forms.BindingSource(this.components);
            this._BS_stemMatches = new System.Windows.Forms.BindingSource(this.components);
            this._BS_plotMatches = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.componentTabControl = new System.Windows.Forms.TabControl();
            this.component1 = new System.Windows.Forms.TabPage();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this._TP_conflicts.SuspendLayout();
            this._TP_matches.SuspendLayout();
            this._TP_new.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeConflicts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogConflicts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_StemConflicts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_PlotConflicts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_logMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_stemMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_plotMatches)).BeginInit();
            this.componentTabControl.SuspendLayout();
            this.component1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _TH_conflicts
            // 
            this._TH_conflicts.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TH_conflicts.Location = new System.Drawing.Point(3, 3);
            this._TH_conflicts.Name = "_TH_conflicts";
            this._TH_conflicts.SelectedIndex = 0;
            this._TH_conflicts.Size = new System.Drawing.Size(399, 325);
            this._TH_conflicts.TabIndex = 1;
            // 
            // _TH_additions
            // 
            this._TH_additions.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TH_additions.Location = new System.Drawing.Point(3, 3);
            this._TH_additions.Name = "_TH_additions";
            this._TH_additions.SelectedIndex = 0;
            this._TH_additions.Size = new System.Drawing.Size(399, 325);
            this._TH_additions.TabIndex = 1;
            // 
            // componentRowIDDataGridViewTextBoxColumn1
            // 
            this.componentRowIDDataGridViewTextBoxColumn1.DataPropertyName = "ComponentRowID";
            this.componentRowIDDataGridViewTextBoxColumn1.HeaderText = "ComponentRowID";
            this.componentRowIDDataGridViewTextBoxColumn1.Name = "componentRowIDDataGridViewTextBoxColumn1";
            this.componentRowIDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this._TP_conflicts);
            this.tabControl1.Controls.Add(this._TP_matches);
            this.tabControl1.Controls.Add(this._TP_new);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 357);
            this.tabControl1.TabIndex = 0;
            // 
            // _TP_conflicts
            // 
            this._TP_conflicts.Controls.Add(this._TH_conflicts);
            this._TP_conflicts.Location = new System.Drawing.Point(4, 22);
            this._TP_conflicts.Name = "_TP_conflicts";
            this._TP_conflicts.Padding = new System.Windows.Forms.Padding(3);
            this._TP_conflicts.Size = new System.Drawing.Size(405, 331);
            this._TP_conflicts.TabIndex = 0;
            this._TP_conflicts.Text = "Errors";
            this._TP_conflicts.UseVisualStyleBackColor = true;
            // 
            // _TP_matches
            // 
            this._TP_matches.Controls.Add(this._TH_matches);
            this._TP_matches.Location = new System.Drawing.Point(4, 22);
            this._TP_matches.Name = "_TP_matches";
            this._TP_matches.Padding = new System.Windows.Forms.Padding(3);
            this._TP_matches.Size = new System.Drawing.Size(405, 331);
            this._TP_matches.TabIndex = 1;
            this._TP_matches.Text = "Matches";
            this._TP_matches.UseVisualStyleBackColor = true;
            this._TP_matches.Enter += new System.EventHandler(this._TP_matches_Enter);
            // 
            // _TH_matches
            // 
            this._TH_matches.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TH_matches.Location = new System.Drawing.Point(3, 3);
            this._TH_matches.Name = "_TH_matches";
            this._TH_matches.SelectedIndex = 0;
            this._TH_matches.Size = new System.Drawing.Size(399, 325);
            this._TH_matches.TabIndex = 0;
            // 
            // _TP_new
            // 
            this._TP_new.Controls.Add(this._TH_additions);
            this._TP_new.Location = new System.Drawing.Point(4, 22);
            this._TP_new.Name = "_TP_new";
            this._TP_new.Padding = new System.Windows.Forms.Padding(3);
            this._TP_new.Size = new System.Drawing.Size(405, 331);
            this._TP_new.TabIndex = 2;
            this._TP_new.Text = "Additions";
            this._TP_new.UseVisualStyleBackColor = true;
            this._TP_new.Enter += new System.EventHandler(this._TP_new_Enter);
            // 
            // TreeDO
            // 
            this.TreeDO.DataSource = typeof(CruiseDAL.DataObjects.TreeDO);
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(399, 325);
            this.tabControl2.TabIndex = 1;
            // 
            // _BS_treeMatches
            // 
            this._BS_treeMatches.DataSource = typeof(CruiseManager.Core.Components.MergeObject);
            // 
            // _BS_TreeConflicts
            // 
            this._BS_TreeConflicts.DataSource = typeof(CruiseManager.Core.Components.MergeObject);
            // 
            // _BS_LogConflicts
            // 
            this._BS_LogConflicts.DataSource = typeof(CruiseManager.Core.Components.MergeObject);
            // 
            // _BS_StemConflicts
            // 
            this._BS_StemConflicts.DataSource = typeof(CruiseManager.Core.Components.MergeObject);
            // 
            // _BS_PlotConflicts
            // 
            this._BS_PlotConflicts.DataSource = typeof(CruiseManager.Core.Components.MergeObject);
            // 
            // _BS_logMatches
            // 
            this._BS_logMatches.DataSource = typeof(CruiseManager.Core.Components.MergeObject);
            // 
            // _BS_stemMatches
            // 
            this._BS_stemMatches.DataSource = typeof(CruiseManager.Core.Components.MergeObject);
            // 
            // _BS_plotMatches
            // 
            this._BS_plotMatches.DataSource = typeof(CruiseManager.Core.Components.MergeObject);
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.TreeDO;
            this.listBox1.DisplayMember = "TreeNumber";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(145, 264);
            this.listBox1.TabIndex = 6;
            // 
            // componentTabControl
            // 
            this.componentTabControl.Controls.Add(this.component1);
            this.componentTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentTabControl.Location = new System.Drawing.Point(234, 28);
            this.componentTabControl.Name = "componentTabControl";
            this.componentTabControl.SelectedIndex = 0;
            this.componentTabControl.Size = new System.Drawing.Size(162, 264);
            this.componentTabControl.TabIndex = 0;
            // 
            // component1
            // 
            this.component1.Controls.Add(this.listBox2);
            this.component1.Location = new System.Drawing.Point(4, 22);
            this.component1.Name = "component1";
            this.component1.Padding = new System.Windows.Forms.Padding(3);
            this.component1.Size = new System.Drawing.Size(154, 238);
            this.component1.TabIndex = 0;
            this.component1.Text = "Component 1";
            this.component1.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.DataSource = this._BS_treeMatches;
            this.listBox2.DisplayMember = "GUIDMatch";
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(148, 232);
            this.listBox2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(154, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(74, 264);
            this.panel1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(17, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 32);
            this.button4.TabIndex = 3;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(234, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Component File(s) Tree Numbers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Master File TreeNumbers";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBox1.Location = new System.Drawing.Point(234, 305);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(162, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Use Remarks";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.componentTabControl, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(399, 325);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // PreMergeReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "PreMergeReportView";
            this.Size = new System.Drawing.Size(413, 357);
            this.tabControl1.ResumeLayout(false);
            this._TP_conflicts.ResumeLayout(false);
            this._TP_matches.ResumeLayout(false);
            this._TP_new.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeConflicts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogConflicts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_StemConflicts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_PlotConflicts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_logMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_stemMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_plotMatches)).EndInit();
            this.componentTabControl.ResumeLayout(false);
            this.component1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _BS_TreeConflicts;
        private System.Windows.Forms.BindingSource _BS_LogConflicts;
        private System.Windows.Forms.BindingSource _BS_StemConflicts;
        private System.Windows.Forms.BindingSource _BS_PlotConflicts;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentRowIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage _TP_conflicts;
        private System.Windows.Forms.TabPage _TP_matches;
        private System.Windows.Forms.TabControl _TH_matches;
        private System.Windows.Forms.BindingSource _BS_treeMatches;
        private System.Windows.Forms.BindingSource _BS_logMatches;
        private System.Windows.Forms.BindingSource _BS_stemMatches;
        private System.Windows.Forms.BindingSource _BS_plotMatches;
        private System.Windows.Forms.TabPage _TP_new;
        private System.Windows.Forms.TabControl _TH_conflicts;
        private System.Windows.Forms.TabControl _TH_additions;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.BindingSource TreeDO;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl componentTabControl;
        private System.Windows.Forms.TabPage component1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
    }
}
