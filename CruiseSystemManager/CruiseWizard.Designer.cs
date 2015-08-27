namespace CruiseSystemManager
{
    partial class CruiseWizard
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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pageHost = new CruiseSystemManager.Controls.PageHost();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // pageHost
            // 
            this.pageHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageHost.Location = new System.Drawing.Point(0, 0);
            this.pageHost.Name = "pageHost";
            this.pageHost.Size = new System.Drawing.Size(652, 466);
            this.pageHost.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Cruise Setup Files (*.setup)|*.setup | Cruise File (*.cruise)| *.cruise";
            // 
            // CruiseWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 466);
            this.Controls.Add(this.pageHost);
            this.Name = "CruiseWizard";
            this.Text = "CruiseWizard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private CruiseSystemManager.Controls.PageHost pageHost;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;


    }
}