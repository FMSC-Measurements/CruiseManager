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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Panel panel3;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalePage));
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
            this._logGradingEnabledCB = new System.Windows.Forms.CheckBox();
            this.SaleDOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._uomCB = new System.Windows.Forms.ComboBox();
            this.UOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._saleNumber_TB = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RegionForestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._saleName_TB = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.forestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurposeComboBox = new System.Windows.Forms.ComboBox();
            this._districtMTB = new System.Windows.Forms.TextBox();
            this._browseTemplateButton = new System.Windows.Forms.Button();
            this._templatePathTB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NextButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            label8 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaleDOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegionForestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forestsBindingSource)).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(3, 56);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            label4.Size = new System.Drawing.Size(72, 28);
            label4.TabIndex = 8;
            label4.Text = "Purpose";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = System.Windows.Forms.DockStyle.Fill;
            label6.Location = new System.Drawing.Point(3, 84);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 27);
            label6.TabIndex = 12;
            label6.Text = "UOM";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.DarkSeaGreen;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Location = new System.Drawing.Point(3, 62);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(505, 13);
            label5.TabIndex = 3;
            label5.Text = "Sale Info";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.DarkSeaGreen;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 3);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(505, 13);
            label1.TabIndex = 5;
            label1.Text = "Select Template";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 5;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.Controls.Add(label8, 0, 0);
            tableLayoutPanel3.Controls.Add(this._logGradingEnabledCB, 3, 3);
            tableLayoutPanel3.Controls.Add(this._uomCB, 1, 3);
            tableLayoutPanel3.Controls.Add(this._saleNumber_TB, 1, 0);
            tableLayoutPanel3.Controls.Add(label2, 3, 0);
            tableLayoutPanel3.Controls.Add(label6, 0, 3);
            tableLayoutPanel3.Controls.Add(this.comboBox1, 4, 0);
            tableLayoutPanel3.Controls.Add(label9, 0, 1);
            tableLayoutPanel3.Controls.Add(this._saleName_TB, 1, 1);
            tableLayoutPanel3.Controls.Add(label3, 3, 1);
            tableLayoutPanel3.Controls.Add(this.comboBox2, 4, 1);
            tableLayoutPanel3.Controls.Add(label4, 0, 2);
            tableLayoutPanel3.Controls.Add(this.PurposeComboBox, 1, 2);
            tableLayoutPanel3.Controls.Add(label7, 3, 2);
            tableLayoutPanel3.Controls.Add(this._districtMTB, 4, 2);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel3.Location = new System.Drawing.Point(6, 81);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new System.Drawing.Size(499, 111);
            tableLayoutPanel3.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = System.Windows.Forms.DockStyle.Fill;
            label8.Location = new System.Drawing.Point(3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(72, 28);
            label8.TabIndex = 0;
            label8.Text = "Sale Number";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _logGradingEnabledCB
            // 
            this._logGradingEnabledCB.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(this._logGradingEnabledCB, 2);
            this._logGradingEnabledCB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.SaleDOBindingSource, "LogGradingEnabled", true));
            this._logGradingEnabledCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logGradingEnabledCB.Location = new System.Drawing.Point(248, 87);
            this._logGradingEnabledCB.Name = "_logGradingEnabledCB";
            this._logGradingEnabledCB.Size = new System.Drawing.Size(248, 21);
            this._logGradingEnabledCB.TabIndex = 7;
            this._logGradingEnabledCB.Text = "Log Data Enabled";
            this._logGradingEnabledCB.UseVisualStyleBackColor = true;
            // 
            // SaleDOBindingSource
            // 
            this.SaleDOBindingSource.DataSource = typeof(CruiseManager.Core.Models.SaleVM);
            this.SaleDOBindingSource.CurrentItemChanged += new System.EventHandler(this.SaleDOBindingSource_CurrentItemChanged);
            // 
            // _uomCB
            // 
            this._uomCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._uomCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._uomCB.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleDOBindingSource, "DefaultUOM", true));
            this._uomCB.DataSource = this.UOMBindingSource;
            this._uomCB.DisplayMember = "DisplayValue";
            this._uomCB.Location = new System.Drawing.Point(81, 87);
            this._uomCB.Name = "_uomCB";
            this._uomCB.Size = new System.Drawing.Size(121, 21);
            this._uomCB.TabIndex = 3;
            this._uomCB.ValueMember = "Code";
            // 
            // UOMBindingSource
            // 
            this.UOMBindingSource.DataSource = typeof(CruiseManager.Core.SetupModels.UOMCode);
            this.UOMBindingSource.CurrentItemChanged += new System.EventHandler(this.UOMBindingSource_CurrentItemChanged);
            // 
            // _saleNumber_TB
            // 
            this._saleNumber_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleDOBindingSource, "SaleNumber", true));
            this._saleNumber_TB.Location = new System.Drawing.Point(81, 3);
            this._saleNumber_TB.MaxLength = 5;
            this._saleNumber_TB.Name = "_saleNumber_TB";
            this._saleNumber_TB.Size = new System.Drawing.Size(76, 22);
            this._saleNumber_TB.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(248, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 28);
            label2.TabIndex = 9;
            label2.Text = "Region";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleDOBindingSource, "Region", true));
            this.comboBox1.DataSource = this.RegionForestBindingSource;
            this.comboBox1.DisplayMember = "FormatNumberName";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(298, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "RegionNumber";
            // 
            // RegionForestBindingSource
            // 
            this.RegionForestBindingSource.DataSource = typeof(CruiseManager.Core.SetupModels.Region);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = System.Windows.Forms.DockStyle.Fill;
            label9.Location = new System.Drawing.Point(3, 28);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(72, 28);
            label9.TabIndex = 0;
            label9.Text = "Sale Name";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _saleName_TB
            // 
            this._saleName_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleDOBindingSource, "Name", true));
            this._saleName_TB.Location = new System.Drawing.Point(81, 31);
            this._saleName_TB.MaxLength = 25;
            this._saleName_TB.Name = "_saleName_TB";
            this._saleName_TB.Size = new System.Drawing.Size(76, 22);
            this._saleName_TB.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(248, 28);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 28);
            label3.TabIndex = 11;
            label3.Text = "Forest";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleDOBindingSource, "Forest", true));
            this.comboBox2.DataSource = this.forestsBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(298, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(142, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.ValueMember = "ForestNumber";
            // 
            // forestsBindingSource
            // 
            this.forestsBindingSource.DataMember = "Forests";
            this.forestsBindingSource.DataSource = this.RegionForestBindingSource;
            // 
            // PurposeComboBox
            // 
            this.PurposeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.PurposeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PurposeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.SaleDOBindingSource, "Purpose", true));
            this.PurposeComboBox.FormattingEnabled = true;
            this.PurposeComboBox.Location = new System.Drawing.Point(81, 59);
            this.PurposeComboBox.Name = "PurposeComboBox";
            this.PurposeComboBox.Size = new System.Drawing.Size(121, 21);
            this.PurposeComboBox.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Location = new System.Drawing.Point(248, 56);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(44, 28);
            label7.TabIndex = 14;
            label7.Text = "District";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _districtMTB
            // 
            this._districtMTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleDOBindingSource, "DistrictNum", true));
            this._districtMTB.Location = new System.Drawing.Point(298, 59);
            this._districtMTB.MaxLength = 2;
            this._districtMTB.Name = "_districtMTB";
            this._districtMTB.Size = new System.Drawing.Size(30, 22);
            this._districtMTB.TabIndex = 6;
            this._districtMTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._districtMTB_KeyPress);
            // 
            // panel3
            // 
            panel3.Controls.Add(this._browseTemplateButton);
            panel3.Controls.Add(this._templatePathTB);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(3, 19);
            panel3.Margin = new System.Windows.Forms.Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(505, 40);
            panel3.TabIndex = 1;
            // 
            // _browseTemplateButton
            // 
            this._browseTemplateButton.AutoSize = true;
            this._browseTemplateButton.Location = new System.Drawing.Point(201, 1);
            this._browseTemplateButton.Name = "_browseTemplateButton";
            this._browseTemplateButton.Size = new System.Drawing.Size(75, 33);
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
            tableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel2.BackgroundImage")));
            tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 4);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel2.Size = new System.Drawing.Size(638, 406);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(63, 80);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(511, 198);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = System.Drawing.Color.DarkSeaGreen;
            tableLayoutPanel4.ColumnCount = 5;
            tableLayoutPanel2.SetColumnSpan(tableLayoutPanel4, 3);
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel4.Controls.Add(this.NextButton, 3, 1);
            tableLayoutPanel4.Controls.Add(this.CancelButton, 1, 1);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(0, 359);
            tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new System.Drawing.Size(638, 47);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // NextButton
            // 
            this.NextButton.AutoSize = true;
            this.NextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NextButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NextButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Location = new System.Drawing.Point(501, 11);
            this.NextButton.Margin = new System.Windows.Forms.Padding(0);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(107, 25);
            this.NextButton.TabIndex = 0;
            this.NextButton.Text = "Cutting Units >>";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(30, 11);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(53, 25);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
            this.Controls.Add(tableLayoutPanel2);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "SalePage";
            this.Size = new System.Drawing.Size(638, 406);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaleDOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegionForestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forestsBindingSource)).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource forestsBindingSource;
        public System.Windows.Forms.BindingSource SaleDOBindingSource;
        public System.Windows.Forms.BindingSource RegionForestBindingSource;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button _browseTemplateButton;
        private System.Windows.Forms.TextBox _templatePathTB;
        public System.Windows.Forms.BindingSource UOMBindingSource;
        private System.Windows.Forms.TextBox _districtMTB;
        private System.Windows.Forms.CheckBox _logGradingEnabledCB;
        private System.Windows.Forms.TextBox _saleNumber_TB;
        private System.Windows.Forms.TextBox _saleName_TB;
        private System.Windows.Forms.ComboBox PurposeComboBox;
        private System.Windows.Forms.ComboBox _uomCB;
    }
}
