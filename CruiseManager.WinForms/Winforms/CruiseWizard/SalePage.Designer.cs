namespace CruiseManager.WinForms.CruiseWizard
{
    partial class SalePage
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalePage));
            this.SaleDOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._uomCB = new System.Windows.Forms.ComboBox();
            this.UOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurposeComboBox = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this._saleName_TB = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this._saleNumber_TB = new System.Windows.Forms.TextBox();
            this._logGradingEnabledCB = new System.Windows.Forms.CheckBox();
            this._districtMTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.forestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RegionForestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this._browseTemplateButton = new System.Windows.Forms.Button();
            this._templatePathTB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SaleDOBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UOMBindingSource)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegionForestBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 89);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            label4.Size = new System.Drawing.Size(49, 21);
            label4.TabIndex = 8;
            label4.Text = "Purpose";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(16, 119);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(34, 13);
            label6.TabIndex = 12;
            label6.Text = "UOM";
            // 
            // SaleDOBindingSource
            // 
            this.SaleDOBindingSource.DataSource = typeof(CruiseManager.Core.Models.SaleVM);
            this.SaleDOBindingSource.CurrentItemChanged += new System.EventHandler(this.SaleDOBindingSource_CurrentItemChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(86, 46);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(466, 268);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(460, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Sale Info";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._uomCB);
            this.panel2.Controls.Add(this.PurposeComboBox);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this._logGradingEnabledCB);
            this.panel2.Controls.Add(this._districtMTB);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(label6);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 123);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 142);
            this.panel2.TabIndex = 1;
            // 
            // _uomCB
            // 
            this._uomCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._uomCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._uomCB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleDOBindingSource, "DefaultUOM", true));
            this._uomCB.DataSource = this.UOMBindingSource;
            this._uomCB.DisplayMember = "DisplayValue";
            this._uomCB.Location = new System.Drawing.Point(74, 115);
            this._uomCB.Name = "_uomCB";
            this._uomCB.Size = new System.Drawing.Size(121, 21);
            this._uomCB.TabIndex = 15;
            this._uomCB.ValueMember = "Code";
            // 
            // UOMBindingSource
            // 
            this.UOMBindingSource.DataSource = typeof(CruiseManager.Core.SetupModels.UOMCode);
            this.UOMBindingSource.CurrentItemChanged += new System.EventHandler(this.UOMBindingSource_CurrentItemChanged);
            // 
            // PurposeComboBox
            // 
            this.PurposeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.PurposeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PurposeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.SaleDOBindingSource, "Purpose", true));
            this.PurposeComboBox.FormattingEnabled = true;
            this.PurposeComboBox.Location = new System.Drawing.Point(74, 86);
            this.PurposeComboBox.Name = "PurposeComboBox";
            this.PurposeComboBox.Size = new System.Drawing.Size(121, 21);
            this.PurposeComboBox.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this._saleName_TB);
            this.panel5.Location = new System.Drawing.Point(20, 54);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(175, 20);
            this.panel5.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sale Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _saleName_TB
            // 
            this._saleName_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleDOBindingSource, "Name", true));
            this._saleName_TB.Dock = System.Windows.Forms.DockStyle.Right;
            this._saleName_TB.Location = new System.Drawing.Point(99, 0);
            this._saleName_TB.MaxLength = 25;
            this._saleName_TB.Name = "_saleName_TB";
            this._saleName_TB.Size = new System.Drawing.Size(76, 22);
            this._saleName_TB.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this._saleNumber_TB);
            this.panel4.Location = new System.Drawing.Point(19, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(175, 20);
            this.panel4.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sale Number";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _saleNumber_TB
            // 
            this._saleNumber_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleDOBindingSource, "SaleNumber", true));
            this._saleNumber_TB.Dock = System.Windows.Forms.DockStyle.Right;
            this._saleNumber_TB.Location = new System.Drawing.Point(99, 0);
            this._saleNumber_TB.MaxLength = 5;
            this._saleNumber_TB.Name = "_saleNumber_TB";
            this._saleNumber_TB.Size = new System.Drawing.Size(76, 22);
            this._saleNumber_TB.TabIndex = 1;
            // 
            // _logGradingEnabledCB
            // 
            this._logGradingEnabledCB.AutoSize = true;
            this._logGradingEnabledCB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.SaleDOBindingSource, "LogGradingEnabled", true));
            this._logGradingEnabledCB.Location = new System.Drawing.Point(285, 115);
            this._logGradingEnabledCB.Name = "_logGradingEnabledCB";
            this._logGradingEnabledCB.Size = new System.Drawing.Size(117, 17);
            this._logGradingEnabledCB.TabIndex = 8;
            this._logGradingEnabledCB.Text = "Log Data Enabled";
            this._logGradingEnabledCB.UseVisualStyleBackColor = true;
            // 
            // _districtMTB
            // 
            this._districtMTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleDOBindingSource, "DistrictNum", true));
            this._districtMTB.Location = new System.Drawing.Point(285, 89);
            this._districtMTB.MaxLength = 2;
            this._districtMTB.Name = "_districtMTB";
            this._districtMTB.Size = new System.Drawing.Size(30, 22);
            this._districtMTB.TabIndex = 7;
            this._districtMTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._districtMTB_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "District";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleDOBindingSource, "Forest", true));
            this.comboBox2.DataSource = this.forestsBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(285, 54);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(142, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.ValueMember = "ForestNumber";
            // 
            // forestsBindingSource
            // 
            this.forestsBindingSource.DataMember = "Forests";
            this.forestsBindingSource.DataSource = this.RegionForestBindingSource;
            // 
            // RegionForestBindingSource
            // 
            this.RegionForestBindingSource.DataSource = typeof(CruiseManager.Core.SetupModels.Region);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Forest";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleDOBindingSource, "Region", true));
            this.comboBox1.DataSource = this.RegionForestBindingSource;
            this.comboBox1.DisplayMember = "FormatNumberName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(285, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.ValueMember = "RegionNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Region";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Template";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._browseTemplateButton);
            this.panel3.Controls.Add(this._templatePathTB);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 26);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 71);
            this.panel3.TabIndex = 1;
            // 
            // _browseTemplateButton
            // 
            this._browseTemplateButton.Location = new System.Drawing.Point(201, 1);
            this._browseTemplateButton.Name = "_browseTemplateButton";
            this._browseTemplateButton.Size = new System.Drawing.Size(75, 23);
            this._browseTemplateButton.TabIndex = 1;
            this._browseTemplateButton.Text = "Browse";
            this._browseTemplateButton.UseVisualStyleBackColor = true;
            this._browseTemplateButton.Click += new System.EventHandler(this._browseTemplateButton_Click);
            // 
            // _templatePathTB
            // 
            this._templatePathTB.Location = new System.Drawing.Point(3, 3);
            this._templatePathTB.Name = "_templatePathTB";
            this._templatePathTB.Size = new System.Drawing.Size(192, 22);
            this._templatePathTB.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            this.tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(638, 406);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.NextButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 360);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 46);
            this.panel1.TabIndex = 1;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton.Location = new System.Drawing.Point(10, 14);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(10);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NextButton.Location = new System.Drawing.Point(500, 14);
            this.NextButton.Margin = new System.Windows.Forms.Padding(10);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(128, 23);
            this.NextButton.TabIndex = 0;
            this.NextButton.Text = "Save and Continue >>";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.SaleDOBindingSource;
            // 
            // SalePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "SalePage";
            this.Size = new System.Drawing.Size(638, 406);
            ((System.ComponentModel.ISupportInitialize)(this.SaleDOBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UOMBindingSource)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegionForestBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource forestsBindingSource;
        public System.Windows.Forms.BindingSource SaleDOBindingSource;
        public System.Windows.Forms.BindingSource RegionForestBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button _browseTemplateButton;
        private System.Windows.Forms.TextBox _templatePathTB;
        public System.Windows.Forms.BindingSource UOMBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _districtMTB;
        private System.Windows.Forms.CheckBox _logGradingEnabledCB;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox _saleNumber_TB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _saleName_TB;
        private System.Windows.Forms.ComboBox PurposeComboBox;
        private System.Windows.Forms.ComboBox _uomCB;
    }
}
