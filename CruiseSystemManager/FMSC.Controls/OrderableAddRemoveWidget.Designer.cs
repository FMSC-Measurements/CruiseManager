namespace FMSC.Controls
{
    partial class OrderableAddRemoveWidget
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddAllButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.RemoveAllButton = new System.Windows.Forms.Button();
            this.SelectedListBox = new System.Windows.Forms.ListBox();
            this.AvailableListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.AddAllButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.AddButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.UpButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.DownButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.RemoveButton, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.RemoveAllButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.SelectedListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AvailableListBox, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(338, 229);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // AddAllButton
            // 
            this.AddAllButton.AutoSize = true;
            this.AddAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddAllButton.Location = new System.Drawing.Point(141, 27);
            this.AddAllButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AddAllButton.Name = "AddAllButton";
            this.AddAllButton.Size = new System.Drawing.Size(56, 24);
            this.AddAllButton.TabIndex = 0;
            this.AddAllButton.Text = "<<";
            this.AddAllButton.UseVisualStyleBackColor = true;
            this.AddAllButton.Click += new System.EventHandler(this.AddAllButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.AutoSize = true;
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(141, 57);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(56, 24);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "<";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.AutoSize = true;
            this.UpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpButton.Location = new System.Drawing.Point(141, 87);
            this.UpButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(56, 24);
            this.UpButton.TabIndex = 2;
            this.UpButton.Text = "UP";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.AutoSize = true;
            this.DownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownButton.Location = new System.Drawing.Point(141, 117);
            this.DownButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(56, 24);
            this.DownButton.TabIndex = 3;
            this.DownButton.Text = "DOWN";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveButton.Location = new System.Drawing.Point(141, 147);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(56, 24);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = ">";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RemoveAllButton
            // 
            this.RemoveAllButton.AutoSize = true;
            this.RemoveAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveAllButton.Location = new System.Drawing.Point(141, 177);
            this.RemoveAllButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RemoveAllButton.Name = "RemoveAllButton";
            this.RemoveAllButton.Size = new System.Drawing.Size(56, 24);
            this.RemoveAllButton.TabIndex = 5;
            this.RemoveAllButton.Text = ">>";
            this.RemoveAllButton.UseVisualStyleBackColor = true;
            this.RemoveAllButton.Click += new System.EventHandler(this.RemoveAllButton_Click);
            // 
            // SelectedListBox
            // 
            this.SelectedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedListBox.FormattingEnabled = true;
            this.SelectedListBox.IntegralHeight = false;
            this.SelectedListBox.Location = new System.Drawing.Point(2, 3);
            this.SelectedListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SelectedListBox.Name = "SelectedListBox";
            this.tableLayoutPanel1.SetRowSpan(this.SelectedListBox, 8);
            this.SelectedListBox.Size = new System.Drawing.Size(135, 223);
            this.SelectedListBox.TabIndex = 6;
            // 
            // AvailableListBox
            // 
            this.AvailableListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvailableListBox.FormattingEnabled = true;
            this.AvailableListBox.IntegralHeight = false;
            this.AvailableListBox.Location = new System.Drawing.Point(201, 3);
            this.AvailableListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AvailableListBox.Name = "AvailableListBox";
            this.tableLayoutPanel1.SetRowSpan(this.AvailableListBox, 8);
            this.AvailableListBox.Size = new System.Drawing.Size(135, 223);
            this.AvailableListBox.TabIndex = 7;
            // 
            // OrderableAddRemoveWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(0, 183);
            this.Name = "OrderableAddRemoveWidget";
            this.Size = new System.Drawing.Size(338, 229);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AddAllButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button RemoveAllButton;
        private System.Windows.Forms.ListBox SelectedListBox;
        private System.Windows.Forms.ListBox AvailableListBox;
    }
}
