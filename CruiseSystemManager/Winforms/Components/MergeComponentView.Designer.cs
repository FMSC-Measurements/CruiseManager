namespace CSM.Winforms.Components
{
    partial class MergeComponentView
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
            this._contentPanel = new System.Windows.Forms.Panel();
            this._bottomPanel = new System.Windows.Forms.Panel();
            this.@__progressBar = new System.Windows.Forms.ProgressBar();
            this._cancelButton = new System.Windows.Forms.Button();
            this._goButton = new System.Windows.Forms.Button();
            this._progressMessageTB = new System.Windows.Forms.TextBox();
            this._bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _contentPanel
            // 
            this._contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentPanel.Location = new System.Drawing.Point(0, 0);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(561, 319);
            this._contentPanel.TabIndex = 0;
            // 
            // _bottomPanel
            // 
            this._bottomPanel.Controls.Add(this.@__progressBar);
            this._bottomPanel.Controls.Add(this._progressMessageTB);
            this._bottomPanel.Controls.Add(this._cancelButton);
            this._bottomPanel.Controls.Add(this._goButton);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPanel.Location = new System.Drawing.Point(0, 319);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(561, 40);
            this._bottomPanel.TabIndex = 1;
            // 
            // __progressBar
            // 
            this.@__progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__progressBar.Location = new System.Drawing.Point(75, 0);
            this.@__progressBar.Name = "__progressBar";
            this.@__progressBar.Size = new System.Drawing.Size(411, 20);
            this.@__progressBar.TabIndex = 2;
            // 
            // _cancelButton
            // 
            this._cancelButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._cancelButton.Location = new System.Drawing.Point(0, 0);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 40);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _goButton
            // 
            this._goButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._goButton.Location = new System.Drawing.Point(486, 0);
            this._goButton.Name = "_goButton";
            this._goButton.Size = new System.Drawing.Size(75, 40);
            this._goButton.TabIndex = 0;
            this._goButton.Text = "Action";
            this._goButton.UseVisualStyleBackColor = true;
            this._goButton.Click += new System.EventHandler(this._goButton_Click);
            // 
            // _progressMessageTB
            // 
            this._progressMessageTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._progressMessageTB.Location = new System.Drawing.Point(75, 20);
            this._progressMessageTB.Name = "_progressMessageTB";
            this._progressMessageTB.ReadOnly = true;
            this._progressMessageTB.Size = new System.Drawing.Size(411, 20);
            this._progressMessageTB.TabIndex = 3;
            // 
            // MergeComponentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._contentPanel);
            this.Controls.Add(this._bottomPanel);
            this.Name = "MergeComponentView";
            this.Size = new System.Drawing.Size(561, 359);
            this._bottomPanel.ResumeLayout(false);
            this._bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _contentPanel;
        private System.Windows.Forms.Panel _bottomPanel;
        private System.Windows.Forms.ProgressBar __progressBar;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _goButton;
        private System.Windows.Forms.TextBox _progressMessageTB;

    }
}
