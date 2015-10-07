namespace CruiseManager.WinForms.TemplateEditor
{
    partial class ImportFromCruiseView
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this._treeDefaultPage = new System.Windows.Forms.TabPage();
            this.selectedItemsGridView1 = new FMSC.Controls.SelectedItemsGridView();
            this.speciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveDeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fIAcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cullPrimaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenPrimaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cullSecondaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenSecondaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recoverableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractSpeciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeGradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.merchHeightLogLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.merchHeightTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barkThicknessRatioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averageZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceHeightPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._BS_TDV = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this._selectAllTDVBTN = new System.Windows.Forms.Button();
            this._volEqPage = new System.Windows.Forms.TabPage();
            this._importVolEqCB = new System.Windows.Forms.CheckBox();
            this._volEqOptGB = new System.Windows.Forms.GroupBox();
            this._dontReplaceVolEqRB = new System.Windows.Forms.RadioButton();
            this._replaceVolEqRB = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this._treeDefaultPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedItemsGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TDV)).BeginInit();
            this.panel1.SuspendLayout();
            this._volEqPage.SuspendLayout();
            this._volEqOptGB.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this._treeDefaultPage);
            this.tabControl1.Controls.Add(this._volEqPage);
            //this.tabControl1.Controls.Add(this.tabPage2); //TODO finish these tab pages
            //this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // _treeDefaultPage
            // 
            this._treeDefaultPage.Controls.Add(this.selectedItemsGridView1);
            this._treeDefaultPage.Controls.Add(this.panel1);
            this._treeDefaultPage.Location = new System.Drawing.Point(4, 22);
            this._treeDefaultPage.Name = "_treeDefaultPage";
            this._treeDefaultPage.Size = new System.Drawing.Size(668, 415);
            this._treeDefaultPage.TabIndex = 2;
            this._treeDefaultPage.Text = "Tree Defaults";
            this._treeDefaultPage.UseVisualStyleBackColor = true;
            // 
            // selectedItemsGridView1
            // 
            this.selectedItemsGridView1.AllowUserToAddRows = false;
            this.selectedItemsGridView1.AllowUserToDeleteRows = false;
            this.selectedItemsGridView1.AllowUserToResizeRows = false;
            this.selectedItemsGridView1.AutoGenerateColumns = false;
            this.selectedItemsGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedItemsGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.speciesDataGridViewTextBoxColumn,
            this.primaryProductDataGridViewTextBoxColumn,
            this.liveDeadDataGridViewTextBoxColumn,
            this.chargeableDataGridViewTextBoxColumn,
            this.fIAcodeDataGridViewTextBoxColumn,
            this.cullPrimaryDataGridViewTextBoxColumn,
            this.hiddenPrimaryDataGridViewTextBoxColumn,
            this.cullSecondaryDataGridViewTextBoxColumn,
            this.hiddenSecondaryDataGridViewTextBoxColumn,
            this.recoverableDataGridViewTextBoxColumn,
            this.contractSpeciesDataGridViewTextBoxColumn,
            this.treeGradeDataGridViewTextBoxColumn,
            this.merchHeightLogLengthDataGridViewTextBoxColumn,
            this.merchHeightTypeDataGridViewTextBoxColumn,
            this.formClassDataGridViewTextBoxColumn,
            this.barkThicknessRatioDataGridViewTextBoxColumn,
            this.averageZDataGridViewTextBoxColumn,
            this.referenceHeightPercentDataGridViewTextBoxColumn});
            this.selectedItemsGridView1.DataSource = this._BS_TDV;
            this.selectedItemsGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedItemsGridView1.Location = new System.Drawing.Point(0, 23);
            this.selectedItemsGridView1.Name = "selectedItemsGridView1";
            this.selectedItemsGridView1.ReadOnly = true;
            this.selectedItemsGridView1.RowHeadersVisible = false;
            this.selectedItemsGridView1.SelectedItems = null;
            this.selectedItemsGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.selectedItemsGridView1.Size = new System.Drawing.Size(668, 392);
            this.selectedItemsGridView1.TabIndex = 0;
            this.selectedItemsGridView1.VirtualMode = true;
            // 
            // speciesDataGridViewTextBoxColumn
            // 
            this.speciesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.speciesDataGridViewTextBoxColumn.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn.HeaderText = "Species";
            this.speciesDataGridViewTextBoxColumn.Name = "speciesDataGridViewTextBoxColumn";
            this.speciesDataGridViewTextBoxColumn.ReadOnly = true;
            this.speciesDataGridViewTextBoxColumn.ToolTipText = "Species Code";
            this.speciesDataGridViewTextBoxColumn.Width = 70;
            // 
            // primaryProductDataGridViewTextBoxColumn
            // 
            this.primaryProductDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.primaryProductDataGridViewTextBoxColumn.DataPropertyName = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn.HeaderText = "PProd";
            this.primaryProductDataGridViewTextBoxColumn.Name = "primaryProductDataGridViewTextBoxColumn";
            this.primaryProductDataGridViewTextBoxColumn.ReadOnly = true;
            this.primaryProductDataGridViewTextBoxColumn.ToolTipText = "Primary Product Code";
            this.primaryProductDataGridViewTextBoxColumn.Width = 61;
            // 
            // liveDeadDataGridViewTextBoxColumn
            // 
            this.liveDeadDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.liveDeadDataGridViewTextBoxColumn.DataPropertyName = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn.HeaderText = "L/D";
            this.liveDeadDataGridViewTextBoxColumn.Name = "liveDeadDataGridViewTextBoxColumn";
            this.liveDeadDataGridViewTextBoxColumn.ReadOnly = true;
            this.liveDeadDataGridViewTextBoxColumn.ToolTipText = "Default Live/Dead Code";
            this.liveDeadDataGridViewTextBoxColumn.Width = 51;
            // 
            // chargeableDataGridViewTextBoxColumn
            // 
            this.chargeableDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.chargeableDataGridViewTextBoxColumn.DataPropertyName = "Chargeable";
            this.chargeableDataGridViewTextBoxColumn.HeaderText = "Chargeable";
            this.chargeableDataGridViewTextBoxColumn.Name = "chargeableDataGridViewTextBoxColumn";
            this.chargeableDataGridViewTextBoxColumn.ReadOnly = true;
            this.chargeableDataGridViewTextBoxColumn.ToolTipText = "Yield Component (CL,CD,NL,ND)";
            this.chargeableDataGridViewTextBoxColumn.Width = 86;
            // 
            // fIAcodeDataGridViewTextBoxColumn
            // 
            this.fIAcodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.fIAcodeDataGridViewTextBoxColumn.DataPropertyName = "FIAcode";
            this.fIAcodeDataGridViewTextBoxColumn.HeaderText = "FIAcode";
            this.fIAcodeDataGridViewTextBoxColumn.Name = "fIAcodeDataGridViewTextBoxColumn";
            this.fIAcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.fIAcodeDataGridViewTextBoxColumn.ToolTipText = "Three Digit FIA Species Code";
            this.fIAcodeDataGridViewTextBoxColumn.Width = 72;
            // 
            // cullPrimaryDataGridViewTextBoxColumn
            // 
            this.cullPrimaryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cullPrimaryDataGridViewTextBoxColumn.DataPropertyName = "CullPrimary";
            this.cullPrimaryDataGridViewTextBoxColumn.HeaderText = "CullP";
            this.cullPrimaryDataGridViewTextBoxColumn.Name = "cullPrimaryDataGridViewTextBoxColumn";
            this.cullPrimaryDataGridViewTextBoxColumn.ReadOnly = true;
            this.cullPrimaryDataGridViewTextBoxColumn.ToolTipText = "Cull Defect Primary Product";
            this.cullPrimaryDataGridViewTextBoxColumn.Width = 56;
            // 
            // hiddenPrimaryDataGridViewTextBoxColumn
            // 
            this.hiddenPrimaryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.hiddenPrimaryDataGridViewTextBoxColumn.DataPropertyName = "HiddenPrimary";
            this.hiddenPrimaryDataGridViewTextBoxColumn.HeaderText = "HiddenP";
            this.hiddenPrimaryDataGridViewTextBoxColumn.Name = "hiddenPrimaryDataGridViewTextBoxColumn";
            this.hiddenPrimaryDataGridViewTextBoxColumn.ReadOnly = true;
            this.hiddenPrimaryDataGridViewTextBoxColumn.ToolTipText = "Hidden Defect Primary Product";
            this.hiddenPrimaryDataGridViewTextBoxColumn.Width = 73;
            // 
            // cullSecondaryDataGridViewTextBoxColumn
            // 
            this.cullSecondaryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cullSecondaryDataGridViewTextBoxColumn.DataPropertyName = "CullSecondary";
            this.cullSecondaryDataGridViewTextBoxColumn.HeaderText = "CullS";
            this.cullSecondaryDataGridViewTextBoxColumn.Name = "cullSecondaryDataGridViewTextBoxColumn";
            this.cullSecondaryDataGridViewTextBoxColumn.ReadOnly = true;
            this.cullSecondaryDataGridViewTextBoxColumn.ToolTipText = "Cull Defect Secondary Product";
            this.cullSecondaryDataGridViewTextBoxColumn.Width = 56;
            // 
            // hiddenSecondaryDataGridViewTextBoxColumn
            // 
            this.hiddenSecondaryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.hiddenSecondaryDataGridViewTextBoxColumn.DataPropertyName = "HiddenSecondary";
            this.hiddenSecondaryDataGridViewTextBoxColumn.HeaderText = "HiddenS";
            this.hiddenSecondaryDataGridViewTextBoxColumn.Name = "hiddenSecondaryDataGridViewTextBoxColumn";
            this.hiddenSecondaryDataGridViewTextBoxColumn.ReadOnly = true;
            this.hiddenSecondaryDataGridViewTextBoxColumn.ToolTipText = "Hiddent Defect Secondary Product";
            this.hiddenSecondaryDataGridViewTextBoxColumn.Width = 73;
            // 
            // recoverableDataGridViewTextBoxColumn
            // 
            this.recoverableDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.recoverableDataGridViewTextBoxColumn.DataPropertyName = "Recoverable";
            this.recoverableDataGridViewTextBoxColumn.HeaderText = "% Rec";
            this.recoverableDataGridViewTextBoxColumn.Name = "recoverableDataGridViewTextBoxColumn";
            this.recoverableDataGridViewTextBoxColumn.ReadOnly = true;
            this.recoverableDataGridViewTextBoxColumn.ToolTipText = "Percent Recoverable Product";
            this.recoverableDataGridViewTextBoxColumn.Width = 63;
            // 
            // contractSpeciesDataGridViewTextBoxColumn
            // 
            this.contractSpeciesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.contractSpeciesDataGridViewTextBoxColumn.DataPropertyName = "ContractSpecies";
            this.contractSpeciesDataGridViewTextBoxColumn.HeaderText = "ContractSp";
            this.contractSpeciesDataGridViewTextBoxColumn.Name = "contractSpeciesDataGridViewTextBoxColumn";
            this.contractSpeciesDataGridViewTextBoxColumn.ReadOnly = true;
            this.contractSpeciesDataGridViewTextBoxColumn.ToolTipText = "Contract Species Code";
            this.contractSpeciesDataGridViewTextBoxColumn.Width = 85;
            // 
            // treeGradeDataGridViewTextBoxColumn
            // 
            this.treeGradeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.treeGradeDataGridViewTextBoxColumn.DataPropertyName = "TreeGrade";
            this.treeGradeDataGridViewTextBoxColumn.HeaderText = "Grade";
            this.treeGradeDataGridViewTextBoxColumn.Name = "treeGradeDataGridViewTextBoxColumn";
            this.treeGradeDataGridViewTextBoxColumn.ReadOnly = true;
            this.treeGradeDataGridViewTextBoxColumn.ToolTipText = "Default Tree Grade";
            this.treeGradeDataGridViewTextBoxColumn.Width = 61;
            // 
            // merchHeightLogLengthDataGridViewTextBoxColumn
            // 
            this.merchHeightLogLengthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.merchHeightLogLengthDataGridViewTextBoxColumn.DataPropertyName = "MerchHeightLogLength";
            this.merchHeightLogLengthDataGridViewTextBoxColumn.HeaderText = "MerchHtLL";
            this.merchHeightLogLengthDataGridViewTextBoxColumn.Name = "merchHeightLogLengthDataGridViewTextBoxColumn";
            this.merchHeightLogLengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.merchHeightLogLengthDataGridViewTextBoxColumn.ToolTipText = "Merchantable Height Log Length";
            this.merchHeightLogLengthDataGridViewTextBoxColumn.Width = 85;
            // 
            // merchHeightTypeDataGridViewTextBoxColumn
            // 
            this.merchHeightTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.merchHeightTypeDataGridViewTextBoxColumn.DataPropertyName = "MerchHeightType";
            this.merchHeightTypeDataGridViewTextBoxColumn.HeaderText = "MerchHeightType";
            this.merchHeightTypeDataGridViewTextBoxColumn.Name = "merchHeightTypeDataGridViewTextBoxColumn";
            this.merchHeightTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.merchHeightTypeDataGridViewTextBoxColumn.ToolTipText = "Merchantable Height Type";
            this.merchHeightTypeDataGridViewTextBoxColumn.Width = 117;
            // 
            // formClassDataGridViewTextBoxColumn
            // 
            this.formClassDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.formClassDataGridViewTextBoxColumn.DataPropertyName = "FormClass";
            this.formClassDataGridViewTextBoxColumn.HeaderText = "FClass";
            this.formClassDataGridViewTextBoxColumn.Name = "formClassDataGridViewTextBoxColumn";
            this.formClassDataGridViewTextBoxColumn.ReadOnly = true;
            this.formClassDataGridViewTextBoxColumn.ToolTipText = "Default Form Class";
            this.formClassDataGridViewTextBoxColumn.Width = 63;
            // 
            // barkThicknessRatioDataGridViewTextBoxColumn
            // 
            this.barkThicknessRatioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.barkThicknessRatioDataGridViewTextBoxColumn.DataPropertyName = "BarkThicknessRatio";
            this.barkThicknessRatioDataGridViewTextBoxColumn.HeaderText = "BTR";
            this.barkThicknessRatioDataGridViewTextBoxColumn.Name = "barkThicknessRatioDataGridViewTextBoxColumn";
            this.barkThicknessRatioDataGridViewTextBoxColumn.ReadOnly = true;
            this.barkThicknessRatioDataGridViewTextBoxColumn.ToolTipText = "Bark Thickness Ratio";
            this.barkThicknessRatioDataGridViewTextBoxColumn.Width = 54;
            // 
            // averageZDataGridViewTextBoxColumn
            // 
            this.averageZDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.averageZDataGridViewTextBoxColumn.DataPropertyName = "AverageZ";
            this.averageZDataGridViewTextBoxColumn.HeaderText = "AvgZ";
            this.averageZDataGridViewTextBoxColumn.Name = "averageZDataGridViewTextBoxColumn";
            this.averageZDataGridViewTextBoxColumn.ReadOnly = true;
            this.averageZDataGridViewTextBoxColumn.ToolTipText = "Average Z-Score";
            this.averageZDataGridViewTextBoxColumn.Width = 58;
            // 
            // referenceHeightPercentDataGridViewTextBoxColumn
            // 
            this.referenceHeightPercentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.referenceHeightPercentDataGridViewTextBoxColumn.DataPropertyName = "ReferenceHeightPercent";
            this.referenceHeightPercentDataGridViewTextBoxColumn.HeaderText = "RefHtPer";
            this.referenceHeightPercentDataGridViewTextBoxColumn.Name = "referenceHeightPercentDataGridViewTextBoxColumn";
            this.referenceHeightPercentDataGridViewTextBoxColumn.ReadOnly = true;
            this.referenceHeightPercentDataGridViewTextBoxColumn.ToolTipText = "Reference Height Percent";
            this.referenceHeightPercentDataGridViewTextBoxColumn.Width = 76;
            // 
            // _BS_TDV
            // 
            this._BS_TDV.DataSource = typeof(CruiseDAL.DataObjects.TreeDefaultValueDO);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this._selectAllTDVBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 23);
            this.panel1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(81, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Copy Audit Rules ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // _selectAllTDVBTN
            // 
            this._selectAllTDVBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this._selectAllTDVBTN.Location = new System.Drawing.Point(0, 0);
            this._selectAllTDVBTN.Name = "_selectAllTDVBTN";
            this._selectAllTDVBTN.Size = new System.Drawing.Size(75, 23);
            this._selectAllTDVBTN.TabIndex = 0;
            this._selectAllTDVBTN.Text = "Select All";
            this._selectAllTDVBTN.UseVisualStyleBackColor = true;
            this._selectAllTDVBTN.Click += new System.EventHandler(this._selectAllTDVBTN_Click);
            // 
            // _volEqPage
            // 
            this._volEqPage.Controls.Add(this._importVolEqCB);
            this._volEqPage.Controls.Add(this._volEqOptGB);
            this._volEqPage.Location = new System.Drawing.Point(4, 22);
            this._volEqPage.Name = "_volEqPage";
            this._volEqPage.Padding = new System.Windows.Forms.Padding(3);
            this._volEqPage.Size = new System.Drawing.Size(668, 415);
            this._volEqPage.TabIndex = 0;
            this._volEqPage.Text = "Volume Equations";
            this._volEqPage.UseVisualStyleBackColor = true;
            // 
            // _importVolEqCB
            // 
            this._importVolEqCB.AutoSize = true;
            this._importVolEqCB.Location = new System.Drawing.Point(7, 7);
            this._importVolEqCB.Name = "_importVolEqCB";
            this._importVolEqCB.Size = new System.Drawing.Size(143, 17);
            this._importVolEqCB.TabIndex = 1;
            this._importVolEqCB.Text = "Import Volume Equations";
            this._importVolEqCB.UseVisualStyleBackColor = true;
            this._importVolEqCB.CheckedChanged += new System.EventHandler(this._importVolEqCB_CheckedChanged);
            // 
            // _volEqOptGB
            // 
            this._volEqOptGB.Controls.Add(this._dontReplaceVolEqRB);
            this._volEqOptGB.Controls.Add(this._replaceVolEqRB);
            this._volEqOptGB.Enabled = false;
            this._volEqOptGB.Location = new System.Drawing.Point(3, 30);
            this._volEqOptGB.Name = "_volEqOptGB";
            this._volEqOptGB.Size = new System.Drawing.Size(216, 80);
            this._volEqOptGB.TabIndex = 0;
            this._volEqOptGB.TabStop = false;
            // 
            // _dontReplaceVolEqRB
            // 
            this._dontReplaceVolEqRB.AutoSize = true;
            this._dontReplaceVolEqRB.Location = new System.Drawing.Point(7, 44);
            this._dontReplaceVolEqRB.Name = "_dontReplaceVolEqRB";
            this._dontReplaceVolEqRB.Size = new System.Drawing.Size(175, 17);
            this._dontReplaceVolEqRB.TabIndex = 1;
            this._dontReplaceVolEqRB.Text = "Don\'t Replace Existing Records";
            this._dontReplaceVolEqRB.UseVisualStyleBackColor = true;
            // 
            // _replaceVolEqRB
            // 
            this._replaceVolEqRB.AutoSize = true;
            this._replaceVolEqRB.Checked = true;
            this._replaceVolEqRB.Location = new System.Drawing.Point(7, 20);
            this._replaceVolEqRB.Name = "_replaceVolEqRB";
            this._replaceVolEqRB.Size = new System.Drawing.Size(189, 17);
            this._replaceVolEqRB.TabIndex = 0;
            this._replaceVolEqRB.TabStop = true;
            this._replaceVolEqRB.Text = "Relplace existing volume equation ";
            this._replaceVolEqRB.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(668, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reports ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Place Holder";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(668, 415);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Field Setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ImportFromCruiseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ImportFromCruiseView";
            this.Size = new System.Drawing.Size(676, 441);
            this.tabControl1.ResumeLayout(false);
            this._treeDefaultPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedItemsGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TDV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._volEqPage.ResumeLayout(false);
            this._volEqPage.PerformLayout();
            this._volEqOptGB.ResumeLayout(false);
            this._volEqOptGB.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage _volEqPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox _volEqOptGB;
        private System.Windows.Forms.RadioButton _replaceVolEqRB;
        private System.Windows.Forms.TabPage _treeDefaultPage;
        private System.Windows.Forms.RadioButton _dontReplaceVolEqRB;
        private FMSC.Controls.SelectedItemsGridView selectedItemsGridView1;
        private System.Windows.Forms.BindingSource _BS_TDV;
        private System.Windows.Forms.CheckBox _importVolEqCB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _selectAllTDVBTN;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryProductDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn liveDeadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIAcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cullPrimaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenPrimaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cullSecondaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenSecondaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recoverableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractSpeciesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeGradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn merchHeightLogLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn merchHeightTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barkThicknessRatioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceHeightPercentDataGridViewTextBoxColumn;
    }
}
