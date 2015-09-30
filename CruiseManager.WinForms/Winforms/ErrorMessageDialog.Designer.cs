namespace CruiseManager.Winforms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._close_BTN = new System.Windows.Forms.Button();
            this._shortMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _textView
            // 
            this._textView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textView.Location = new System.Drawing.Point(3, 26);
            this._textView.Name = "_textView";
            this._textView.ReadOnly = true;
            this._textView.Size = new System.Drawing.Size(348, 164);
            this._textView.TabIndex = 0;
            this._textView.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._close_BTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 29);
            this.panel1.TabIndex = 2;
            // 
            // _close_BTN
            // 
            this._close_BTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._close_BTN.Dock = System.Windows.Forms.DockStyle.Right;
            this._close_BTN.Location = new System.Drawing.Point(273, 0);
            this._close_BTN.Name = "_close_BTN";
            this._close_BTN.Size = new System.Drawing.Size(75, 29);
            this._close_BTN.TabIndex = 2;
            this._close_BTN.Text = "Close";
            this._close_BTN.UseVisualStyleBackColor = true;
            // 
            // _shortMessage
            // 
            this._shortMessage.AutoSize = true;
            this._shortMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this._shortMessage.Location = new System.Drawing.Point(3, 3);
            this._shortMessage.Name = "_shortMessage";
            this._shortMessage.Padding = new System.Windows.Forms.Padding(5);
            this._shortMessage.Size = new System.Drawing.Size(97, 23);
            this._shortMessage.TabIndex = 3;
            this._shortMessage.Text = "<ShortMessage>";
            // 
            // ErrorMessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 222);
            this.Controls.Add(this._textView);
            this.Controls.Add(this._shortMessage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorMessageDialog";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox _textView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _close_BTN;
        private System.Windows.Forms.Label _shortMessage;
    }
}