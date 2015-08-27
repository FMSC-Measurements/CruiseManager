namespace CruiseSystemManager.NavPages
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.OutputPathBrowseButton = new System.Windows.Forms.Button();
            this.OutputPathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TargetPathBrowseButton = new System.Windows.Forms.Button();
            this.TargetPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(473, 394);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StatusLabel);
            this.panel1.Controls.Add(this.ConvertButton);
            this.panel1.Controls.Add(this.OutputPathBrowseButton);
            this.panel1.Controls.Add(this.OutputPathTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TargetPathBrowseButton);
            this.panel1.Controls.Add(this.TargetPathTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(86, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 300);
            this.panel1.TabIndex = 0;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(213, 274);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 6;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // OutputPathBrowseButton
            // 
            this.OutputPathBrowseButton.Location = new System.Drawing.Point(214, 106);
            this.OutputPathBrowseButton.Name = "OutputPathBrowseButton";
            this.OutputPathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.OutputPathBrowseButton.TabIndex = 5;
            this.OutputPathBrowseButton.Text = "Browse";
            this.OutputPathBrowseButton.UseVisualStyleBackColor = true;
            this.OutputPathBrowseButton.Click += new System.EventHandler(this.OutputPathBrowseButton_Click);
            // 
            // OutputPathTextBox
            // 
            this.OutputPathTextBox.Location = new System.Drawing.Point(6, 106);
            this.OutputPathTextBox.Name = "OutputPathTextBox";
            this.OutputPathTextBox.Size = new System.Drawing.Size(201, 20);
            this.OutputPathTextBox.TabIndex = 4;
            this.OutputPathTextBox.TextChanged += new System.EventHandler(this.OutputPathTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save as";
            // 
            // TargetPathBrowseButton
            // 
            this.TargetPathBrowseButton.Location = new System.Drawing.Point(214, 49);
            this.TargetPathBrowseButton.Name = "TargetPathBrowseButton";
            this.TargetPathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.TargetPathBrowseButton.TabIndex = 2;
            this.TargetPathBrowseButton.Text = "Browse";
            this.TargetPathBrowseButton.UseVisualStyleBackColor = true;
            this.TargetPathBrowseButton.Click += new System.EventHandler(this.TargetPathBrowseButton_Click);
            // 
            // TargetPathTextBox
            // 
            this.TargetPathTextBox.Location = new System.Drawing.Point(4, 53);
            this.TargetPathTextBox.Name = "TargetPathTextBox";
            this.TargetPathTextBox.Size = new System.Drawing.Size(203, 20);
            this.TargetPathTextBox.TabIndex = 1;
            this.TargetPathTextBox.TextChanged += new System.EventHandler(this.TargetPathTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File To Convert";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(1, 279);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 7;
            // 
            // COConverterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "COConverterPage";
            this.Size = new System.Drawing.Size(473, 394);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OutputPathBrowseButton;
        private System.Windows.Forms.TextBox OutputPathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TargetPathBrowseButton;
        private System.Windows.Forms.TextBox TargetPathTextBox;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}
