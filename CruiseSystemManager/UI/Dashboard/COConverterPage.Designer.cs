﻿namespace CSM.NavPages
{
    partial class COConverterPage
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
           this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
           this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
           this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
           this.WaitGif = new System.Windows.Forms.Panel();
           this.progressBar1 = new System.Windows.Forms.ProgressBar();
           this.StatusLabel = new System.Windows.Forms.Label();
           this.ConvertButton = new System.Windows.Forms.Button();
           this.OutputPathBrowseButton = new System.Windows.Forms.Button();
           this.OutputPathTextBox = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this.TargetPathBrowseButton = new System.Windows.Forms.Button();
           this.TargetPathTextBox = new System.Windows.Forms.TextBox();
           this.label1 = new System.Windows.Forms.Label();
           this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
           this.tableLayoutPanel1.SuspendLayout();
           this.WaitGif.SuspendLayout();
           this.SuspendLayout();
           // 
           // tableLayoutPanel1
           // 
           this.tableLayoutPanel1.ColumnCount = 3;
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.Controls.Add(this.WaitGif, 1, 1);
           this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
           this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
           this.tableLayoutPanel1.Name = "tableLayoutPanel1";
           this.tableLayoutPanel1.RowCount = 3;
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 369F));
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.Size = new System.Drawing.Size(631, 485);
           this.tableLayoutPanel1.TabIndex = 0;
           // 
           // WaitGif
           // 
           this.WaitGif.Controls.Add(this.progressBar1);
           this.WaitGif.Controls.Add(this.StatusLabel);
           this.WaitGif.Controls.Add(this.ConvertButton);
           this.WaitGif.Controls.Add(this.OutputPathBrowseButton);
           this.WaitGif.Controls.Add(this.OutputPathTextBox);
           this.WaitGif.Controls.Add(this.label2);
           this.WaitGif.Controls.Add(this.TargetPathBrowseButton);
           this.WaitGif.Controls.Add(this.TargetPathTextBox);
           this.WaitGif.Controls.Add(this.label1);
           this.WaitGif.Dock = System.Windows.Forms.DockStyle.Fill;
           this.WaitGif.Enabled = false;
           this.WaitGif.Location = new System.Drawing.Point(115, 58);
           this.WaitGif.Margin = new System.Windows.Forms.Padding(0);
           this.WaitGif.Name = "WaitGif";
           this.WaitGif.Size = new System.Drawing.Size(400, 369);
           this.WaitGif.TabIndex = 0;
           this.WaitGif.Visible = false;
           // 
           // progressBar1
           // 
           this.progressBar1.BackColor = System.Drawing.Color.DarkSeaGreen;
           this.progressBar1.Location = new System.Drawing.Point(0, 302);
           this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
           this.progressBar1.Name = "progressBar1";
           this.progressBar1.Size = new System.Drawing.Size(400, 28);
           this.progressBar1.TabIndex = 8;
           this.progressBar1.Visible = false;
           // 
           // StatusLabel
           // 
           this.StatusLabel.AutoSize = true;
           this.StatusLabel.Location = new System.Drawing.Point(1, 343);
           this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.StatusLabel.Name = "StatusLabel";
           this.StatusLabel.Size = new System.Drawing.Size(0, 17);
           this.StatusLabel.TabIndex = 7;
           // 
           // ConvertButton
           // 
           this.ConvertButton.Location = new System.Drawing.Point(284, 337);
           this.ConvertButton.Margin = new System.Windows.Forms.Padding(4);
           this.ConvertButton.Name = "ConvertButton";
           this.ConvertButton.Size = new System.Drawing.Size(100, 28);
           this.ConvertButton.TabIndex = 6;
           this.ConvertButton.Text = "Convert";
           this.ConvertButton.UseVisualStyleBackColor = true;
           this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
           // 
           // OutputPathBrowseButton
           // 
           this.OutputPathBrowseButton.Location = new System.Drawing.Point(285, 130);
           this.OutputPathBrowseButton.Margin = new System.Windows.Forms.Padding(4);
           this.OutputPathBrowseButton.Name = "OutputPathBrowseButton";
           this.OutputPathBrowseButton.Size = new System.Drawing.Size(100, 28);
           this.OutputPathBrowseButton.TabIndex = 5;
           this.OutputPathBrowseButton.Text = "Browse";
           this.OutputPathBrowseButton.UseVisualStyleBackColor = true;
           this.OutputPathBrowseButton.Click += new System.EventHandler(this.OutputPathBrowseButton_Click);
           // 
           // OutputPathTextBox
           // 
           this.OutputPathTextBox.Location = new System.Drawing.Point(8, 130);
           this.OutputPathTextBox.Margin = new System.Windows.Forms.Padding(4);
           this.OutputPathTextBox.Name = "OutputPathTextBox";
           this.OutputPathTextBox.Size = new System.Drawing.Size(267, 22);
           this.OutputPathTextBox.TabIndex = 4;
           this.OutputPathTextBox.TextChanged += new System.EventHandler(this.OutputPathTextBox_TextChanged);
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(4, 110);
           this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(59, 17);
           this.label2.TabIndex = 3;
           this.label2.Text = "Save as";
           // 
           // TargetPathBrowseButton
           // 
           this.TargetPathBrowseButton.Location = new System.Drawing.Point(285, 60);
           this.TargetPathBrowseButton.Margin = new System.Windows.Forms.Padding(4);
           this.TargetPathBrowseButton.Name = "TargetPathBrowseButton";
           this.TargetPathBrowseButton.Size = new System.Drawing.Size(100, 28);
           this.TargetPathBrowseButton.TabIndex = 2;
           this.TargetPathBrowseButton.Text = "Browse";
           this.TargetPathBrowseButton.UseVisualStyleBackColor = true;
           this.TargetPathBrowseButton.Click += new System.EventHandler(this.TargetPathBrowseButton_Click);
           // 
           // TargetPathTextBox
           // 
           this.TargetPathTextBox.Location = new System.Drawing.Point(5, 65);
           this.TargetPathTextBox.Margin = new System.Windows.Forms.Padding(4);
           this.TargetPathTextBox.Name = "TargetPathTextBox";
           this.TargetPathTextBox.Size = new System.Drawing.Size(269, 22);
           this.TargetPathTextBox.TabIndex = 1;
           this.TargetPathTextBox.TextChanged += new System.EventHandler(this.TargetPathTextBox_TextChanged);
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(4, 44);
           this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(104, 17);
           this.label1.TabIndex = 0;
           this.label1.Text = "File To Convert";
           // 
           // COConverterPage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.tableLayoutPanel1);
           this.Margin = new System.Windows.Forms.Padding(4);
           this.Name = "COConverterPage";
           this.Size = new System.Drawing.Size(631, 485);
           this.tableLayoutPanel1.ResumeLayout(false);
           this.WaitGif.ResumeLayout(false);
           this.WaitGif.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel WaitGif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OutputPathBrowseButton;
        private System.Windows.Forms.TextBox OutputPathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TargetPathBrowseButton;
        private System.Windows.Forms.TextBox TargetPathTextBox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
