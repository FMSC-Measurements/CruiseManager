namespace CSM.UI.CombineCruise
{
    partial class SubComponentSelectPage
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
           this.components = new System.ComponentModel.Container();
           this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
           this.SubComponentGridView = new FMSC.Controls.SelectedItemsGridView();
           this.panel1 = new System.Windows.Forms.Panel();
           this.BackButton = new System.Windows.Forms.Button();
           this.OKButton = new System.Windows.Forms.Button();
           this.SubSelectionTypeLabel = new System.Windows.Forms.Label();
           this.CuttingUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
           this.tableLayoutPanel1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.SubComponentGridView)).BeginInit();
           this.panel1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).BeginInit();
           this.SuspendLayout();
           // 
           // tableLayoutPanel1
           // 
           this.tableLayoutPanel1.ColumnCount = 1;
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
           this.tableLayoutPanel1.Controls.Add(this.SubComponentGridView, 0, 1);
           this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
           this.tableLayoutPanel1.Controls.Add(this.SubSelectionTypeLabel, 0, 0);
           this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
           this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
           this.tableLayoutPanel1.Name = "tableLayoutPanel1";
           this.tableLayoutPanel1.RowCount = 3;
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
           this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 448);
           this.tableLayoutPanel1.TabIndex = 0;
           // 
           // SubComponentGridView
           // 
           this.SubComponentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           this.SubComponentGridView.Dock = System.Windows.Forms.DockStyle.Fill;
           this.SubComponentGridView.Location = new System.Drawing.Point(0, 25);
           this.SubComponentGridView.Margin = new System.Windows.Forms.Padding(0);
           this.SubComponentGridView.Name = "SubComponentGridView";
           this.SubComponentGridView.RowHeadersVisible = false;
           this.SubComponentGridView.SelectedItems = null;
           this.SubComponentGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
           this.SubComponentGridView.Size = new System.Drawing.Size(635, 386);
           this.SubComponentGridView.TabIndex = 0;
           this.SubComponentGridView.VirtualMode = true;
           // 
           // panel1
           // 
           this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
           this.panel1.Controls.Add(this.BackButton);
           this.panel1.Controls.Add(this.OKButton);
           this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.panel1.Location = new System.Drawing.Point(0, 411);
           this.panel1.Margin = new System.Windows.Forms.Padding(0);
           this.panel1.Name = "panel1";
           this.panel1.Size = new System.Drawing.Size(635, 37);
           this.panel1.TabIndex = 1;
           // 
           // BackButton
           // 
           this.BackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
           this.BackButton.Location = new System.Drawing.Point(4, 5);
           this.BackButton.Margin = new System.Windows.Forms.Padding(4);
           this.BackButton.Name = "BackButton";
           this.BackButton.Size = new System.Drawing.Size(100, 28);
           this.BackButton.TabIndex = 1;
           this.BackButton.Text = "Back";
           this.BackButton.UseVisualStyleBackColor = false;
           this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
           // 
           // OKButton
           // 
           this.OKButton.BackColor = System.Drawing.SystemColors.ButtonFace;
           this.OKButton.Location = new System.Drawing.Point(531, 5);
           this.OKButton.Margin = new System.Windows.Forms.Padding(4);
           this.OKButton.Name = "OKButton";
           this.OKButton.Size = new System.Drawing.Size(100, 28);
           this.OKButton.TabIndex = 0;
           this.OKButton.Text = "OK";
           this.OKButton.UseVisualStyleBackColor = false;
           this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
           // 
           // SubSelectionTypeLabel
           // 
           this.SubSelectionTypeLabel.AutoSize = true;
           this.SubSelectionTypeLabel.BackColor = System.Drawing.Color.DarkSeaGreen;
           this.SubSelectionTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
           this.SubSelectionTypeLabel.Location = new System.Drawing.Point(4, 0);
           this.SubSelectionTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.SubSelectionTypeLabel.Name = "SubSelectionTypeLabel";
           this.SubSelectionTypeLabel.Size = new System.Drawing.Size(627, 25);
           this.SubSelectionTypeLabel.TabIndex = 2;
           this.SubSelectionTypeLabel.Text = "placeHolder";
           this.SubSelectionTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // SubComponentSelectPage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.tableLayoutPanel1);
           this.Margin = new System.Windows.Forms.Padding(4);
           this.Name = "SubComponentSelectPage";
           this.Size = new System.Drawing.Size(635, 448);
           this.tableLayoutPanel1.ResumeLayout(false);
           this.tableLayoutPanel1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.SubComponentGridView)).EndInit();
           this.panel1.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitBindingSource)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.BindingSource CuttingUnitBindingSource;
        public FMSC.Controls.SelectedItemsGridView SubComponentGridView;
        public System.Windows.Forms.Label SubSelectionTypeLabel;
    }
}
