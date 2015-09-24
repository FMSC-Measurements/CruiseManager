namespace CruiseManager.Winforms.CruiseWizard
{
    partial class CruiseWizardView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CruiseWizardView));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pageHost = new CruiseManager.Winforms.PageHost();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Cruise Setup Files (*.setup)|*.setup | Cruise File (*.cruise)| *.cruise";
            // 
            // pageHost
            // 
            this.pageHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageHost.Location = new System.Drawing.Point(0, 0);
            this.pageHost.Name = "pageHost";
            this.pageHost.Size = new System.Drawing.Size(758, 466);
            this.pageHost.TabIndex = 0;
            // 
            // CruiseWizardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 466);
            this.Controls.Add(this.pageHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(630, 0);
            this.Name = "CruiseWizardView";
            this.ShowInTaskbar = false;
            this.Text = "CruiseWizard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private CruiseManager.Winforms.PageHost pageHost;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;


    }
}