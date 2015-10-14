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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TallySetupView));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._tallyNavPanel = new System.Windows.Forms.Panel();
            this._systematicOptCB = new System.Windows.Forms.CheckBox();
            this._stratumHKCB = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this._sampleGroupCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._strataCB = new System.Windows.Forms.ComboBox();
            this._tallyEditPanel = new CruiseManager.WinForms.CruiseCustomize.TallyEditPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this._tallyNavPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._tallyNavPanel);
            this.flowLayoutPanel1.Controls.Add(this._tallyEditPanel);
            this.flowLayoutPanel1.Controls.Add(this.richTextBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(659, 460);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // _tallyNavPanel
            // 
            this._tallyNavPanel.Controls.Add(this._systematicOptCB);
            this._tallyNavPanel.Controls.Add(this._stratumHKCB);
            this._tallyNavPanel.Controls.Add(this.label21);
            this._tallyNavPanel.Controls.Add(this._sampleGroupCB);
            this._tallyNavPanel.Controls.Add(this.label10);
            this._tallyNavPanel.Controls.Add(this.label9);
            this._tallyNavPanel.Controls.Add(this._strataCB);
            this._tallyNavPanel.Location = new System.Drawing.Point(3, 3);
            this._tallyNavPanel.Name = "_tallyNavPanel";
            this._tallyNavPanel.Size = new System.Drawing.Size(445, 56);
            this._tallyNavPanel.TabIndex = 10;
            // 
            // _systematicOptCB
            // 
            this._systematicOptCB.AutoSize = true;
            this._systematicOptCB.Location = new System.Drawing.Point(214, 35);
            this._systematicOptCB.Name = "_systematicOptCB";
            this._systematicOptCB.Size = new System.Drawing.Size(198, 17);
            this._systematicOptCB.TabIndex = 14;
            this._systematicOptCB.Text = "Use Systematic Sampling (STR only)";
            this._systematicOptCB.UseVisualStyleBackColor = true;
            // 
            // _stratumHKCB
            // 
            this._stratumHKCB.FormattingEnabled = true;
            this._stratumHKCB.Location = new System.Drawing.Point(301, 3);
            this._stratumHKCB.Name = "_stratumHKCB";
            this._stratumHKCB.Size = new System.Drawing.Size(47, 21);
            this._stratumHKCB.TabIndex = 13;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(211, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Stratum Hot Key";
            // 
            // _sampleGroupCB
            // 
            this._sampleGroupCB.FormattingEnabled = true;
            this._sampleGroupCB.Location = new System.Drawing.Point(83, 31);
            this._sampleGroupCB.Name = "_sampleGroupCB";
            this._sampleGroupCB.Size = new System.Drawing.Size(121, 21);
            this._sampleGroupCB.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Sample Group";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Stratum";
            // 
            // _strataCB
            // 
            this._strataCB.FormattingEnabled = true;
            this._strataCB.Location = new System.Drawing.Point(83, 3);
            this._strataCB.Name = "_strataCB";
            this._strataCB.Size = new System.Drawing.Size(121, 21);
            this._strataCB.TabIndex = 8;
            // 
            // _tallyEditPanel
            // 
            this._tallyEditPanel.Location = new System.Drawing.Point(4, 66);
            this._tallyEditPanel.Margin = new System.Windows.Forms.Padding(4);
            this._tallyEditPanel.Name = "_tallyEditPanel";
            this._tallyEditPanel.Size = new System.Drawing.Size(342, 258);
            this._tallyEditPanel.TabIndex = 9;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Location = new System.Drawing.Point(353, 65);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(175, 259);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // TallySetupView
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TallySetupView";
            this.Size = new System.Drawing.Size(659, 460);
            this.flowLayoutPanel1.ResumeLayout(false);
            this._tallyNavPanel.ResumeLayout(false);
            this._tallyNavPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel _tallyNavPanel;
        private System.Windows.Forms.CheckBox _systematicOptCB;
        private System.Windows.Forms.ComboBox _stratumHKCB;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox _sampleGroupCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _strataCB;
        private TallyEditPanel _tallyEditPanel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
