namespace CSM.UI
{
    partial class ErrorMessageDialog
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
            this._textView = new System.Windows.Forms.RichTextBox();
            this._close_BTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _textView
            // 
            this._textView.Dock = System.Windows.Forms.DockStyle.Top;
            this._textView.Location = new System.Drawing.Point(3, 3);
            this._textView.Name = "_textView";
            this._textView.ReadOnly = true;
            this._textView.Size = new System.Drawing.Size(463, 224);
            this._textView.TabIndex = 0;
            this._textView.Text = "";
            // 
            // _close_BTN
            // 
            this._close_BTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._close_BTN.Location = new System.Drawing.Point(388, 233);
            this._close_BTN.Name = "_close_BTN";
            this._close_BTN.Size = new System.Drawing.Size(75, 23);
            this._close_BTN.TabIndex = 1;
            this._close_BTN.Text = "Close";
            this._close_BTN.UseVisualStyleBackColor = true;
            // 
            // ErrorMessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._close_BTN;
            this.ClientSize = new System.Drawing.Size(469, 262);
            this.Controls.Add(this._close_BTN);
            this.Controls.Add(this._textView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorMessageDialog";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _textView;
        private System.Windows.Forms.Button _close_BTN;
    }
}