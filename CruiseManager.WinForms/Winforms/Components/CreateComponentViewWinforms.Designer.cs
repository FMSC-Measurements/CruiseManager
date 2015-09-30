namespace CruiseManager.WinForms.Components
{
    partial class CreateComponentViewWinforms 
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
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.@__numCompTB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(145, 13);
            label1.TabIndex = 1;
            label1.Text = "Total Number of Components";
            // 
            // __numCompTB
            // 
            this.@__numCompTB.Location = new System.Drawing.Point(153, 7);
            this.@__numCompTB.Name = "__numCompTB";
            this.@__numCompTB.Size = new System.Drawing.Size(46, 20);
            this.@__numCompTB.TabIndex = 0;
            // 
            // __makeBtn
            // 
            this.@__makeBtn.Location = new System.Drawing.Point(6, 35);
            this.@__makeBtn.Name = "__makeBtn";
            this.@__makeBtn.Size = new System.Drawing.Size(193, 23);
            this.@__makeBtn.TabIndex = 2;
            this.@__makeBtn.Text = "Make Components";
            this.@__makeBtn.UseVisualStyleBackColor = true;
            this.@__makeBtn.Click += new System.EventHandler(this.@__makeBtn_Click);
            // 
            // __progressBar
            // 
            this.@__progressBar.Location = new System.Drawing.Point(6, 65);
            this.@__progressBar.Name = "__progressBar";
            this.@__progressBar.Size = new System.Drawing.Size(193, 23);
            this.@__progressBar.TabIndex = 3;
            this.@__progressBar.Visible = false;
            // 
            // CreateComponentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.@__progressBar);
            this.Controls.Add(this.@__makeBtn);
            this.Controls.Add(label1);
            this.Controls.Add(this.@__numCompTB);
            this.Name = "CreateComponentView";
            this.Size = new System.Drawing.Size(643, 398);
            ((System.ComponentModel.ISupportInitialize)(this.@__numCompTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown __numCompTB;
        private System.Windows.Forms.Button __makeBtn;
        private System.Windows.Forms.ProgressBar __progressBar;
    }
}
