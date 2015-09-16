namespace CSM.Winforms.Components
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
            this._BS_TreeConflicts = new System.Windows.Forms.BindingSource(this.components);
            this._BS_LogConflicts = new System.Windows.Forms.BindingSource(this.components);
            this._BS_StemConflicts = new System.Windows.Forms.BindingSource(this.components);
            this._BS_PlotConflicts = new System.Windows.Forms.BindingSource(this.components);
            this._BS_treeMatches = new System.Windows.Forms.BindingSource(this.components);
            this._BS_logMatches = new System.Windows.Forms.BindingSource(this.components);
            this._BS_stemMatches = new System.Windows.Forms.BindingSource(this.components);
            this._BS_plotMatches = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this._TP_conflicts.SuspendLayout();
            this._TP_matches.SuspendLayout();
            this._TP_new.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeConflicts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogConflicts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_StemConflicts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_PlotConflicts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_logMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_stemMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_plotMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // _TH_conflicts
            // 
            this._TH_conflicts.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TH_conflicts.Location = new System.Drawing.Point(3, 3);
            this._TH_conflicts.Name = "_TH_conflicts";
            this._TH_conflicts.SelectedIndex = 0;
            this._TH_conflicts.Size = new System.Drawing.Size(419, 326);
            this._TH_conflicts.TabIndex = 1;
            // 
            // _TH_additions
            // 
            this._TH_additions.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TH_additions.Location = new System.Drawing.Point(3, 3);
            this._TH_additions.Name = "_TH_additions";
            this._TH_additions.SelectedIndex = 0;
            this._TH_additions.Size = new System.Drawing.Size(419, 326);
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
            this.tabControl1.Size = new System.Drawing.Size(433, 358);
            this.tabControl1.TabIndex = 0;
            // 
            // _TP_conflicts
            // 
            this._TP_conflicts.Controls.Add(this._TH_conflicts);
            this._TP_conflicts.Location = new System.Drawing.Point(4, 22);
            this._TP_conflicts.Name = "_TP_conflicts";
            this._TP_conflicts.Padding = new System.Windows.Forms.Padding(3);
            this._TP_conflicts.Size = new System.Drawing.Size(425, 332);
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
            this._TP_matches.Size = new System.Drawing.Size(425, 332);
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
            this._TH_matches.Size = new System.Drawing.Size(419, 326);
            this._TH_matches.TabIndex = 0;
            // 
            // _TP_new
            // 
            this._TP_new.Controls.Add(this._TH_additions);
            this._TP_new.Location = new System.Drawing.Point(4, 22);
            this._TP_new.Name = "_TP_new";
            this._TP_new.Padding = new System.Windows.Forms.Padding(3);
            this._TP_new.Size = new System.Drawing.Size(425, 332);
            this._TP_new.TabIndex = 2;
            this._TP_new.Text = "Additions";
            this._TP_new.UseVisualStyleBackColor = true;
            this._TP_new.Enter += new System.EventHandler(this._TP_new_Enter);
            // 
            // _BS_TreeConflicts
            // 
            this._BS_TreeConflicts.DataSource = typeof(CSM.Logic.Components.MergeObject);
            // 
            // _BS_LogConflicts
            // 
            this._BS_LogConflicts.DataSource = typeof(CSM.Logic.Components.MergeObject);
            // 
            // _BS_StemConflicts
            // 
            this._BS_StemConflicts.DataSource = typeof(CSM.Logic.Components.MergeObject);
            // 
            // _BS_PlotConflicts
            // 
            this._BS_PlotConflicts.DataSource = typeof(CSM.Logic.Components.MergeObject);
            // 
            // _BS_treeMatches
            // 
            this._BS_treeMatches.DataSource = typeof(CSM.Logic.Components.MergeObject);
            // 
            // _BS_logMatches
            // 
            this._BS_logMatches.DataSource = typeof(CSM.Logic.Components.MergeObject);
            // 
            // _BS_stemMatches
            // 
            this._BS_stemMatches.DataSource = typeof(CSM.Logic.Components.MergeObject);
            // 
            // _BS_plotMatches
            // 
            this._BS_plotMatches.DataSource = typeof(CSM.Logic.Components.MergeObject);
            // 
            // PreMergeReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "PreMergeReportView";
            this.Size = new System.Drawing.Size(433, 358);
            this.tabControl1.ResumeLayout(false);
            this._TP_conflicts.ResumeLayout(false);
            this._TP_matches.ResumeLayout(false);
            this._TP_new.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeConflicts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogConflicts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_StemConflicts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_PlotConflicts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_logMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_stemMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_plotMatches)).EndInit();
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
    }
}
