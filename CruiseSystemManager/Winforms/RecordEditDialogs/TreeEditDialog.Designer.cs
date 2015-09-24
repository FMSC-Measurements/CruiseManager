namespace CruiseManager.Winforms.RecordEditDialogs
{
    partial class TreeEditDialog
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
            this._BS_Tree = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._SLTB_rowid = new FMSC.Controls.SideLabelTextBox();
            this._SLTB_unit = new FMSC.Controls.SideLabelTextBox();
            this._SLTB_stratum = new FMSC.Controls.SideLabelTextBox();
            this._SLTB_samplegroup = new FMSC.Controls.SideLabelTextBox();
            this._SLTB_species = new FMSC.Controls.SideLabelTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._BS_Tree)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _BS_Tree
            // 
            this._BS_Tree.DataSource = typeof(CruiseDAL.DataObjects.TreeDO);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this._SLTB_rowid);
            this.flowLayoutPanel1.Controls.Add(this._SLTB_unit);
            this.flowLayoutPanel1.Controls.Add(this._SLTB_stratum);
            this.flowLayoutPanel1.Controls.Add(this._SLTB_samplegroup);
            this.flowLayoutPanel1.Controls.Add(this._SLTB_species);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(320, 285);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 34);
            this.panel1.TabIndex = 1;
            // 
            // _SLTB_rowid
            // 
            this._SLTB_rowid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._SLTB_rowid.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this._SLTB_rowid.LabelWidth = 100F;
            this._SLTB_rowid.LableText = "Record ID";
            this._SLTB_rowid.Location = new System.Drawing.Point(0, 0);
            this._SLTB_rowid.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_rowid.Name = "_SLTB_rowid";
            this._SLTB_rowid.Size = new System.Drawing.Size(300, 20);
            this._SLTB_rowid.TabIndex = 0;
            // 
            // 
            // 
            this._SLTB_rowid.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SLTB_rowid.TextBox.Location = new System.Drawing.Point(100, 0);
            this._SLTB_rowid.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_rowid.TextBox.Name = ".TextBox";
            this._SLTB_rowid.TextBox.Size = new System.Drawing.Size(200, 20);
            this._SLTB_rowid.TextBox.TabIndex = 1;
            // 
            // _SLTB_unit
            // 
            this._SLTB_unit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._SLTB_unit.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this._SLTB_unit.LabelWidth = 100F;
            this._SLTB_unit.LableText = "CuttingUnit";
            this._SLTB_unit.Location = new System.Drawing.Point(0, 20);
            this._SLTB_unit.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_unit.Name = "_SLTB_unit";
            this._SLTB_unit.Size = new System.Drawing.Size(300, 20);
            this._SLTB_unit.TabIndex = 1;
            // 
            // 
            // 
            this._SLTB_unit.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SLTB_unit.TextBox.Location = new System.Drawing.Point(100, 0);
            this._SLTB_unit.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_unit.TextBox.Name = ".TextBox";
            this._SLTB_unit.TextBox.Size = new System.Drawing.Size(200, 20);
            this._SLTB_unit.TextBox.TabIndex = 1;
            // 
            // _SLTB_stratum
            // 
            this._SLTB_stratum.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._SLTB_stratum.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this._SLTB_stratum.LabelWidth = 100F;
            this._SLTB_stratum.LableText = "Stratum";
            this._SLTB_stratum.Location = new System.Drawing.Point(0, 40);
            this._SLTB_stratum.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_stratum.Name = "_SLTB_stratum";
            this._SLTB_stratum.Size = new System.Drawing.Size(300, 20);
            this._SLTB_stratum.TabIndex = 2;
            // 
            // 
            // 
            this._SLTB_stratum.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SLTB_stratum.TextBox.Location = new System.Drawing.Point(100, 0);
            this._SLTB_stratum.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_stratum.TextBox.Name = ".TextBox";
            this._SLTB_stratum.TextBox.Size = new System.Drawing.Size(200, 20);
            this._SLTB_stratum.TextBox.TabIndex = 1;
            // 
            // _SLTB_samplegroup
            // 
            this._SLTB_samplegroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._SLTB_samplegroup.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this._SLTB_samplegroup.LabelWidth = 100F;
            this._SLTB_samplegroup.LableText = "Sample Group";
            this._SLTB_samplegroup.Location = new System.Drawing.Point(0, 60);
            this._SLTB_samplegroup.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_samplegroup.Name = "_SLTB_samplegroup";
            this._SLTB_samplegroup.Size = new System.Drawing.Size(300, 20);
            this._SLTB_samplegroup.TabIndex = 3;
            // 
            // 
            // 
            this._SLTB_samplegroup.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SLTB_samplegroup.TextBox.Location = new System.Drawing.Point(100, 0);
            this._SLTB_samplegroup.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_samplegroup.TextBox.Name = ".TextBox";
            this._SLTB_samplegroup.TextBox.Size = new System.Drawing.Size(200, 20);
            this._SLTB_samplegroup.TextBox.TabIndex = 1;
            // 
            // _SLTB_species
            // 
            this._SLTB_species.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._SLTB_species.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this._SLTB_species.LabelWidth = 100F;
            this._SLTB_species.LableText = "Species";
            this._SLTB_species.Location = new System.Drawing.Point(0, 80);
            this._SLTB_species.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_species.Name = "_SLTB_species";
            this._SLTB_species.Size = new System.Drawing.Size(300, 20);
            this._SLTB_species.TabIndex = 4;
            // 
            // 
            // 
            this._SLTB_species.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SLTB_species.TextBox.Location = new System.Drawing.Point(100, 0);
            this._SLTB_species.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this._SLTB_species.TextBox.Name = ".TextBox";
            this._SLTB_species.TextBox.Size = new System.Drawing.Size(200, 20);
            this._SLTB_species.TextBox.TabIndex = 1;
            // 
            // TreeEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(320, 319);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TreeEditDialog";
            this.Text = "TreeEditDialog";
            ((System.ComponentModel.ISupportInitialize)(this._BS_Tree)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource _BS_Tree;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private FMSC.Controls.SideLabelTextBox _SLTB_rowid;
        private FMSC.Controls.SideLabelTextBox _SLTB_unit;
        private FMSC.Controls.SideLabelTextBox _SLTB_stratum;
        private FMSC.Controls.SideLabelTextBox _SLTB_samplegroup;
        private FMSC.Controls.SideLabelTextBox _SLTB_species;
    }
}