namespace CSM.Winforms
{
    partial class AboutDialog
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
            System.Windows.Forms.PictureBox pictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            this._versionNumLBL = new System.Windows.Forms.Label();
            this._login = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(100, 100);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(118, 12);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(245, 30);
            label3.TabIndex = 3;
            label3.Text = "Cruise Manager";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(122, 46);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(45, 13);
            label1.TabIndex = 4;
            label1.Text = "Version:";
            // 
            // _versionNumLBL
            // 
            this._versionNumLBL.AutoSize = true;
            this._versionNumLBL.Location = new System.Drawing.Point(173, 46);
            this._versionNumLBL.Name = "_versionNumLBL";
            this._versionNumLBL.Size = new System.Drawing.Size(75, 13);
            this._versionNumLBL.TabIndex = 5;
            this._versionNumLBL.Text = "<versionNum>";
            // 
            // _login
            // 
            this._login.Location = new System.Drawing.Point(12, 178);
            this._login.Name = "_login";
            this._login.Size = new System.Drawing.Size(75, 23);
            this._login.TabIndex = 6;
            this._login.Text = "Login";
            this._login.UseVisualStyleBackColor = true;
            this._login.Click += new System.EventHandler(this._login_Click);
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(375, 213);
            this.Controls.Add(this._login);
            this.Controls.Add(this._versionNumLBL);
            this.Controls.Add(label1);
            this.Controls.Add(label3);
            this.Controls.Add(pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutDialog";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _versionNumLBL;
        private System.Windows.Forms.Button _login;
    }
}