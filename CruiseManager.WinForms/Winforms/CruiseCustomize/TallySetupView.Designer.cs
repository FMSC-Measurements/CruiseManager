namespace CruiseManager.WinForms.CruiseCustomize
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
            this._tallyEditContainer = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._stratumHKCB = new System.Windows.Forms.ComboBox();
            this._strataCB = new System.Windows.Forms.ComboBox();
            this._BS_strata = new System.Windows.Forms.BindingSource(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._BS_strata)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tallyEditContainer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._tallyEditContainer, 5);
            this._tallyEditContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tallyEditContainer.Location = new System.Drawing.Point(3, 30);
            this._tallyEditContainer.Name = "_tallyEditContainer";
            this._tallyEditContainer.Size = new System.Drawing.Size(618, 283);
            this._tallyEditContainer.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 5);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 319);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(618, 94);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(225, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 27);
            this.label9.TabIndex = 9;
            this.label9.Text = "Stratum";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _stratumHKCB
            // 
            this._stratumHKCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._stratumHKCB.FormattingEnabled = true;
            this._stratumHKCB.Location = new System.Drawing.Point(278, 3);
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
            this._strataCB.Location = new System.Drawing.Point(98, 3);
            this._strataCB.Name = "_strataCB";
            this._strataCB.Size = new System.Drawing.Size(121, 21);
            this._strataCB.TabIndex = 8;
            // 
            // _BS_strata
            // 
            this._BS_strata.DataSource = typeof(CruiseManager.Core.CruiseCustomize.TallySetupStratum_Base);
            this._BS_strata.CurrentChanged += new System.EventHandler(this._BS_strata_CurrentChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(3, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 27);
            this.label21.TabIndex = 12;
            this.label21.Text = "Stratum Hot Key";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._strataCB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this._stratumHKCB, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this._tallyEditContainer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 416);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TallySetupView
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "TallySetupView";
            this.Size = new System.Drawing.Size(624, 416);
            ((System.ComponentModel.ISupportInitialize)(this._BS_strata)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox _stratumHKCB;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _strataCB;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.BindingSource _BS_strata;
        private System.Windows.Forms.Panel _tallyEditContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
