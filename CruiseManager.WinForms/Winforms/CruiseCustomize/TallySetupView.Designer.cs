﻿namespace CruiseManager.WinForms.CruiseCustomize
{
    partial class TallySetupView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TallySetupView));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.fixCNTTallyEditPanel1 = new CruiseManager.WinForms.CruiseCustomize.FixCNTTallyEditPanel();
            this._tallyEditContainer = new System.Windows.Forms.Panel();
            this._tallyEditPanel = new CruiseManager.WinForms.CruiseCustomize.TallyEditPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this._stratum_PNL = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this._stratumHKCB = new System.Windows.Forms.ComboBox();
            this._strataCB = new System.Windows.Forms.ComboBox();
            this._BS_strata = new System.Windows.Forms.BindingSource(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this._tallyEditContainer.SuspendLayout();
            this._stratum_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_strata)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.fixCNTTallyEditPanel1);
            this.flowLayoutPanel1.Controls.Add(this._tallyEditContainer);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(653, 565);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // fixCNTTallyEditPanel1
            // 
            this.fixCNTTallyEditPanel1.Location = new System.Drawing.Point(3, 3);
            this.fixCNTTallyEditPanel1.Name = "fixCNTTallyEditPanel1";
            this.fixCNTTallyEditPanel1.Size = new System.Drawing.Size(352, 287);
            this.fixCNTTallyEditPanel1.TabIndex = 14;
            this.fixCNTTallyEditPanel1.TallyClass = null;
            // 
            // _tallyEditContainer
            // 
            this._tallyEditContainer.AutoSize = true;
            this._tallyEditContainer.Controls.Add(this._tallyEditPanel);
            this._tallyEditContainer.Location = new System.Drawing.Point(3, 296);
            this._tallyEditContainer.Name = "_tallyEditContainer";
            this._tallyEditContainer.Size = new System.Drawing.Size(352, 266);
            this._tallyEditContainer.TabIndex = 13;
            // 
            // _tallyEditPanel
            // 
            this._tallyEditPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tallyEditPanel.Location = new System.Drawing.Point(6, 4);
            this._tallyEditPanel.Margin = new System.Windows.Forms.Padding(4);
            this._tallyEditPanel.Name = "_tallyEditPanel";
            this._tallyEditPanel.Size = new System.Drawing.Size(342, 258);
            this._tallyEditPanel.TabIndex = 9;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 597);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(653, 107);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // _stratum_PNL
            // 
            this._stratum_PNL.Controls.Add(this.label9);
            this._stratum_PNL.Controls.Add(this._stratumHKCB);
            this._stratum_PNL.Controls.Add(this._strataCB);
            this._stratum_PNL.Controls.Add(this.label21);
            this._stratum_PNL.Dock = System.Windows.Forms.DockStyle.Top;
            this._stratum_PNL.Location = new System.Drawing.Point(0, 0);
            this._stratum_PNL.Name = "_stratum_PNL";
            this._stratum_PNL.Size = new System.Drawing.Size(653, 32);
            this._stratum_PNL.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Stratum";
            // 
            // _stratumHKCB
            // 
            this._stratumHKCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._stratumHKCB.FormattingEnabled = true;
            this._stratumHKCB.Location = new System.Drawing.Point(301, 3);
            this._stratumHKCB.Name = "_stratumHKCB";
            this._stratumHKCB.Size = new System.Drawing.Size(47, 21);
            this._stratumHKCB.TabIndex = 13;
            this._stratumHKCB.DropDown += new System.EventHandler(this._stratumHKCB_DropDown);
            this._stratumHKCB.TextChanged += new System.EventHandler(this._stratumHKCB_TextChanged);
            // 
            // _strataCB
            // 
            this._strataCB.DataSource = this._BS_strata;
            this._strataCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._strataCB.FormattingEnabled = true;
            this._strataCB.Location = new System.Drawing.Point(83, 3);
            this._strataCB.Name = "_strataCB";
            this._strataCB.Size = new System.Drawing.Size(121, 21);
            this._strataCB.TabIndex = 8;
            // 
            // _BS_strata
            // 
            this._BS_strata.DataSource = typeof(CruiseManager.Core.CruiseCustomize.TallySetupStratum);
            this._BS_strata.CurrentChanged += new System.EventHandler(this._BS_strata_CurrentChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(211, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Stratum Hot Key";
            // 
            // TallySetupView
            // 
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this._stratum_PNL);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TallySetupView";
            this.Size = new System.Drawing.Size(653, 704);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this._tallyEditContainer.ResumeLayout(false);
            this._stratum_PNL.ResumeLayout(false);
            this._stratum_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_strata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox _stratumHKCB;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _strataCB;
        private TallyEditPanel _tallyEditPanel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.BindingSource _BS_strata;
        private System.Windows.Forms.Panel _stratum_PNL;
        private System.Windows.Forms.Panel _tallyEditContainer;
        private FixCNTTallyEditPanel fixCNTTallyEditPanel1;
    }
}
