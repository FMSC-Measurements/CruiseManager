namespace CruiseManager.WinForms
{
    partial class LicencesDialog
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
            this._LB_licences = new System.Windows.Forms.ListBox();
            this._RTB_licenceDisplay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _LB_licences
            // 
            this._LB_licences.Dock = System.Windows.Forms.DockStyle.Left;
            this._LB_licences.FormattingEnabled = true;
            this._LB_licences.IntegralHeight = false;
            this._LB_licences.Location = new System.Drawing.Point(0, 0);
            this._LB_licences.Name = "_LB_licences";
            this._LB_licences.Size = new System.Drawing.Size(132, 272);
            this._LB_licences.TabIndex = 0;
            // 
            // _RTB_licenceDisplay
            // 
            this._RTB_licenceDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this._RTB_licenceDisplay.Location = new System.Drawing.Point(132, 0);
            this._RTB_licenceDisplay.Name = "_RTB_licenceDisplay";
            this._RTB_licenceDisplay.ReadOnly = true;
            this._RTB_licenceDisplay.Size = new System.Drawing.Size(305, 272);
            this._RTB_licenceDisplay.TabIndex = 1;
            this._RTB_licenceDisplay.Text = "";
            // 
            // LicencesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 272);
            this.Controls.Add(this._RTB_licenceDisplay);
            this.Controls.Add(this._LB_licences);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicencesDialog";
            this.Text = "Licences";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _LB_licences;
        private System.Windows.Forms.RichTextBox _RTB_licenceDisplay;
    }
}