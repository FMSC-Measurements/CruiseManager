namespace CruiseManager.WinForms.Components
{
    partial class CreateComponentView 
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
            System.Windows.Forms.Label label1;
            this.@__numCompTB = new System.Windows.Forms.NumericUpDown();
            this.@__makeBtn = new System.Windows.Forms.Button();
            this.@__progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.@__numCompTB)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(159, 13);
            label1.TabIndex = 1;
            label1.Text = "Total Number of Components";
            // 
            // __numCompTB
            // 
            this.@__numCompTB.Location = new System.Drawing.Point(168, 3);
            
            this.@__numCompTB.Name = "__numCompTB";
            this.@__numCompTB.Size = new System.Drawing.Size(46, 22);
            this.@__numCompTB.TabIndex = 0;
            this.@__numCompTB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // __makeBtn
            // 
            this.@__makeBtn.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.@__makeBtn, 2);
            this.@__makeBtn.Location = new System.Drawing.Point(3, 31);
            this.@__makeBtn.Name = "__makeBtn";
            this.@__makeBtn.Size = new System.Drawing.Size(208, 33);
            this.@__makeBtn.TabIndex = 2;
            this.@__makeBtn.Text = "Make Components";
            this.@__makeBtn.UseVisualStyleBackColor = true;
            this.@__makeBtn.Click += new System.EventHandler(this.@__makeBtn_Click);
            // 
            // __progressBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.@__progressBar, 2);
            this.@__progressBar.Location = new System.Drawing.Point(3, 70);
            this.@__progressBar.Name = "__progressBar";
            this.@__progressBar.Size = new System.Drawing.Size(208, 23);
            this.@__progressBar.TabIndex = 3;
            this.@__progressBar.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.@__progressBar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.@__numCompTB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.@__makeBtn, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(643, 398);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // CreateComponentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "CreateComponentView";
            this.Size = new System.Drawing.Size(643, 398);
            ((System.ComponentModel.ISupportInitialize)(this.@__numCompTB)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown __numCompTB;
        private System.Windows.Forms.Button __makeBtn;
        private System.Windows.Forms.ProgressBar __progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
