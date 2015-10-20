namespace CruiseManager.WinForms
{
    partial class UserControlContainerView
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
            this._navLinkPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._contentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _navLinkPanel
            // 
            this._navLinkPanel.AutoSize = true;
            this._navLinkPanel.BackColor = System.Drawing.Color.ForestGreen;
            this._navLinkPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._navLinkPanel.Location = new System.Drawing.Point(0, 0);
            this._navLinkPanel.Name = "_navLinkPanel";
            this._navLinkPanel.Size = new System.Drawing.Size(575, 0);
            this._navLinkPanel.TabIndex = 0;
            // 
            // _contentPanel
            // 
            this._contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentPanel.Location = new System.Drawing.Point(0, 0);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(575, 390);
            this._contentPanel.TabIndex = 1;
            // 
            // UserControlContainerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._contentPanel);
            this.Controls.Add(this._navLinkPanel);
            this.Name = "UserControlContainerView";
            this.Size = new System.Drawing.Size(575, 390);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _navLinkPanel;
        private System.Windows.Forms.Panel _contentPanel;
    }
}
