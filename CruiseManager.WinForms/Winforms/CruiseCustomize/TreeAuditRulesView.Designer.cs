namespace CruiseManager.WinForms.CruiseCustomize
{
    partial class TreeAuditRulesView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TableLayoutPanel _treeAuditRulesLayout;
            System.Windows.Forms.Label label7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeAuditRulesView));
            System.Windows.Forms.Label label8;
            this._auditRulesHelp_BTN = new System.Windows.Forms.Button();
            this._tavDeleteBTN = new System.Windows.Forms.Button();
            this._treeAuditClearSelectionBtn = new System.Windows.Forms.Button();
            this._tdvDGV = new FMSC.Controls.SelectedItemsGridView();
            this.speciesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryProductDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveDeadDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fIAcodeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cullPrimaryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenPrimaryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cullSecondaryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenSecondaryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recoverableDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractSpeciesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeGradeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.merchHeightLogLengthDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.merchHeightTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formClassDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barkThicknessRatioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averageZDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceHeightPercentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._BS_treeDefaults = new System.Windows.Forms.BindingSource(this.components);
            this._treeAuditDGV = new System.Windows.Forms.DataGridView();
            this.fieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.minDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._BS_treeAudits = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            _treeAuditRulesLayout = new System.Windows.Forms.TableLayoutPanel();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            _treeAuditRulesLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tdvDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeDefaults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._treeAuditDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeAudits)).BeginInit();
            this.SuspendLayout();
            // 
            // _treeAuditRulesLayout
            // 
            _treeAuditRulesLayout.BackColor = System.Drawing.Color.DarkSeaGreen;
            _treeAuditRulesLayout.ColumnCount = 4;
            _treeAuditRulesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _treeAuditRulesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            _treeAuditRulesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            _treeAuditRulesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            _treeAuditRulesLayout.Controls.Add(label7, 1, 0);
            _treeAuditRulesLayout.Controls.Add(this._auditRulesHelp_BTN, 0, 0);
            _treeAuditRulesLayout.Controls.Add(this._tavDeleteBTN, 3, 0);
            _treeAuditRulesLayout.Controls.Add(label8, 0, 2);
            _treeAuditRulesLayout.Controls.Add(this._treeAuditClearSelectionBtn, 3, 2);
            _treeAuditRulesLayout.Controls.Add(this._tdvDGV, 0, 3);
            _treeAuditRulesLayout.Controls.Add(this._treeAuditDGV, 0, 1);
            _treeAuditRulesLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            _treeAuditRulesLayout.Location = new System.Drawing.Point(0, 0);
            _treeAuditRulesLayout.Margin = new System.Windows.Forms.Padding(0);
            _treeAuditRulesLayout.Name = "_treeAuditRulesLayout";
            _treeAuditRulesLayout.RowCount = 4;
            _treeAuditRulesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            _treeAuditRulesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            _treeAuditRulesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            _treeAuditRulesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            _treeAuditRulesLayout.Size = new System.Drawing.Size(649, 521);
            _treeAuditRulesLayout.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Location = new System.Drawing.Point(20, 0);
            label7.Margin = new System.Windows.Forms.Padding(0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(190, 31);
            label7.TabIndex = 3;
            label7.Text = "Audit Rules ";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _auditRulesHelp_BTN
            // 
            this._auditRulesHelp_BTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._auditRulesHelp_BTN.BackColor = System.Drawing.Color.Transparent;
            this._auditRulesHelp_BTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_auditRulesHelp_BTN.BackgroundImage")));
            this._auditRulesHelp_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._auditRulesHelp_BTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this._auditRulesHelp_BTN.FlatAppearance.BorderSize = 0;
            this._auditRulesHelp_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._auditRulesHelp_BTN.ForeColor = System.Drawing.Color.Transparent;
            this._auditRulesHelp_BTN.Location = new System.Drawing.Point(0, 0);
            this._auditRulesHelp_BTN.Margin = new System.Windows.Forms.Padding(0);
            this._auditRulesHelp_BTN.Name = "_auditRulesHelp_BTN";
            this._auditRulesHelp_BTN.Size = new System.Drawing.Size(20, 31);
            this._auditRulesHelp_BTN.TabIndex = 5;
            this._auditRulesHelp_BTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this._auditRulesHelp_BTN, resources.GetString("_auditRulesHelp_BTN.ToolTip"));
            this._auditRulesHelp_BTN.UseVisualStyleBackColor = false;
            // 
            // _tavDeleteBTN
            // 
            this._tavDeleteBTN.AutoSize = true;
            this._tavDeleteBTN.BackColor = System.Drawing.SystemColors.Control;
            this._tavDeleteBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tavDeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._tavDeleteBTN.Location = new System.Drawing.Point(551, 3);
            this._tavDeleteBTN.Name = "_tavDeleteBTN";
            this._tavDeleteBTN.Size = new System.Drawing.Size(95, 25);
            this._tavDeleteBTN.TabIndex = 4;
            this._tavDeleteBTN.Text = "Delete";
            this._tavDeleteBTN.UseVisualStyleBackColor = false;
            this._tavDeleteBTN.Click += new System.EventHandler(this._tavDeleteBTN_Click);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.Color.Transparent;
            _treeAuditRulesLayout.SetColumnSpan(label8, 2);
            label8.Dock = System.Windows.Forms.DockStyle.Fill;
            label8.Location = new System.Drawing.Point(0, 260);
            label8.Margin = new System.Windows.Forms.Padding(0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(210, 31);
            label8.TabIndex = 4;
            label8.Text = "Tree Defaults (select to apply audit rule)";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _treeAuditClearSelectionBtn
            // 
            this._treeAuditClearSelectionBtn.AutoSize = true;
            this._treeAuditClearSelectionBtn.BackColor = System.Drawing.SystemColors.Control;
            this._treeAuditClearSelectionBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeAuditClearSelectionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._treeAuditClearSelectionBtn.Location = new System.Drawing.Point(551, 263);
            this._treeAuditClearSelectionBtn.Name = "_treeAuditClearSelectionBtn";
            this._treeAuditClearSelectionBtn.Size = new System.Drawing.Size(95, 25);
            this._treeAuditClearSelectionBtn.TabIndex = 5;
            this._treeAuditClearSelectionBtn.Text = "Clear Selection";
            this._treeAuditClearSelectionBtn.UseVisualStyleBackColor = false;
            this._treeAuditClearSelectionBtn.Click += new System.EventHandler(this._treeAuditClearSelectionBtn_Click);
            // 
            // _tdvDGV
            // 
            this._tdvDGV.AllowUserToAddRows = false;
            this._tdvDGV.AllowUserToResizeRows = false;
            this._tdvDGV.AutoGenerateColumns = false;
            this._tdvDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._tdvDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.speciesDataGridViewTextBoxColumn1,
            this.primaryProductDataGridViewTextBoxColumn1,
            this.liveDeadDataGridViewTextBoxColumn1,
            this.fIAcodeDataGridViewTextBoxColumn1,
            this.cullPrimaryDataGridViewTextBoxColumn1,
            this.hiddenPrimaryDataGridViewTextBoxColumn1,
            this.cullSecondaryDataGridViewTextBoxColumn1,
            this.hiddenSecondaryDataGridViewTextBoxColumn1,
            this.recoverableDataGridViewTextBoxColumn1,
            this.contractSpeciesDataGridViewTextBoxColumn1,
            this.treeGradeDataGridViewTextBoxColumn1,
            this.merchHeightLogLengthDataGridViewTextBoxColumn1,
            this.merchHeightTypeDataGridViewTextBoxColumn1,
            this.formClassDataGridViewTextBoxColumn1,
            this.barkThicknessRatioDataGridViewTextBoxColumn1,
            this.averageZDataGridViewTextBoxColumn1,
            this.referenceHeightPercentDataGridViewTextBoxColumn1});
            _treeAuditRulesLayout.SetColumnSpan(this._tdvDGV, 4);
            this._tdvDGV.DataSource = this._BS_treeDefaults;
            this._tdvDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tdvDGV.Location = new System.Drawing.Point(0, 291);
            this._tdvDGV.Margin = new System.Windows.Forms.Padding(0);
            this._tdvDGV.Name = "_tdvDGV";
            this._tdvDGV.RowHeadersVisible = false;
            this._tdvDGV.RowTemplate.Height = 24;
            this._tdvDGV.SelectedItems = null;
            this._tdvDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._tdvDGV.Size = new System.Drawing.Size(649, 230);
            this._tdvDGV.TabIndex = 1;
            this._tdvDGV.VirtualMode = true;
            // 
            // speciesDataGridViewTextBoxColumn1
            // 
            this.speciesDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.speciesDataGridViewTextBoxColumn1.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn1.HeaderText = "Species";
            this.speciesDataGridViewTextBoxColumn1.Name = "speciesDataGridViewTextBoxColumn1";
            this.speciesDataGridViewTextBoxColumn1.ToolTipText = "Species Code";
            this.speciesDataGridViewTextBoxColumn1.Width = 70;
            // 
            // primaryProductDataGridViewTextBoxColumn1
            // 
            this.primaryProductDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.primaryProductDataGridViewTextBoxColumn1.DataPropertyName = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn1.HeaderText = "PProd";
            this.primaryProductDataGridViewTextBoxColumn1.Name = "primaryProductDataGridViewTextBoxColumn1";
            this.primaryProductDataGridViewTextBoxColumn1.ToolTipText = "Primary Product Code";
            this.primaryProductDataGridViewTextBoxColumn1.Width = 62;
            // 
            // liveDeadDataGridViewTextBoxColumn1
            // 
            this.liveDeadDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.liveDeadDataGridViewTextBoxColumn1.DataPropertyName = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn1.HeaderText = "L/D";
            this.liveDeadDataGridViewTextBoxColumn1.Name = "liveDeadDataGridViewTextBoxColumn1";
            this.liveDeadDataGridViewTextBoxColumn1.ToolTipText = "Default Live/Dead Code";
            this.liveDeadDataGridViewTextBoxColumn1.Width = 49;
            // 
            // fIAcodeDataGridViewTextBoxColumn1
            // 
            this.fIAcodeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.fIAcodeDataGridViewTextBoxColumn1.DataPropertyName = "FIAcode";
            this.fIAcodeDataGridViewTextBoxColumn1.HeaderText = "FIAcode";
            this.fIAcodeDataGridViewTextBoxColumn1.Name = "fIAcodeDataGridViewTextBoxColumn1";
            this.fIAcodeDataGridViewTextBoxColumn1.ToolTipText = "Three Digit FIA Species Code";
            this.fIAcodeDataGridViewTextBoxColumn1.Width = 73;
            // 
            // cullPrimaryDataGridViewTextBoxColumn1
            // 
            this.cullPrimaryDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cullPrimaryDataGridViewTextBoxColumn1.DataPropertyName = "CullPrimary";
            this.cullPrimaryDataGridViewTextBoxColumn1.HeaderText = "CullP";
            this.cullPrimaryDataGridViewTextBoxColumn1.Name = "cullPrimaryDataGridViewTextBoxColumn1";
            this.cullPrimaryDataGridViewTextBoxColumn1.ToolTipText = "Cull Defect Primary Product";
            this.cullPrimaryDataGridViewTextBoxColumn1.Width = 58;
            // 
            // hiddenPrimaryDataGridViewTextBoxColumn1
            // 
            this.hiddenPrimaryDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.hiddenPrimaryDataGridViewTextBoxColumn1.DataPropertyName = "HiddenPrimary";
            this.hiddenPrimaryDataGridViewTextBoxColumn1.HeaderText = "HiddenP";
            this.hiddenPrimaryDataGridViewTextBoxColumn1.Name = "hiddenPrimaryDataGridViewTextBoxColumn1";
            this.hiddenPrimaryDataGridViewTextBoxColumn1.ToolTipText = "Hidden Defect Primary Product";
            this.hiddenPrimaryDataGridViewTextBoxColumn1.Width = 76;
            // 
            // cullSecondaryDataGridViewTextBoxColumn1
            // 
            this.cullSecondaryDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cullSecondaryDataGridViewTextBoxColumn1.DataPropertyName = "CullSecondary";
            this.cullSecondaryDataGridViewTextBoxColumn1.HeaderText = "CullS";
            this.cullSecondaryDataGridViewTextBoxColumn1.Name = "cullSecondaryDataGridViewTextBoxColumn1";
            this.cullSecondaryDataGridViewTextBoxColumn1.ToolTipText = "Cull Defect Secondary Product";
            this.cullSecondaryDataGridViewTextBoxColumn1.Width = 58;
            // 
            // hiddenSecondaryDataGridViewTextBoxColumn1
            // 
            this.hiddenSecondaryDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.hiddenSecondaryDataGridViewTextBoxColumn1.DataPropertyName = "HiddenSecondary";
            this.hiddenSecondaryDataGridViewTextBoxColumn1.HeaderText = "HiddenS";
            this.hiddenSecondaryDataGridViewTextBoxColumn1.Name = "hiddenSecondaryDataGridViewTextBoxColumn1";
            this.hiddenSecondaryDataGridViewTextBoxColumn1.ToolTipText = "Hidden Defect Secondary Product";
            this.hiddenSecondaryDataGridViewTextBoxColumn1.Width = 76;
            // 
            // recoverableDataGridViewTextBoxColumn1
            // 
            this.recoverableDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.recoverableDataGridViewTextBoxColumn1.DataPropertyName = "Recoverable";
            this.recoverableDataGridViewTextBoxColumn1.HeaderText = "% Rec";
            this.recoverableDataGridViewTextBoxColumn1.Name = "recoverableDataGridViewTextBoxColumn1";
            this.recoverableDataGridViewTextBoxColumn1.ToolTipText = "Percent Recoverable Product";
            this.recoverableDataGridViewTextBoxColumn1.Width = 62;
            // 
            // contractSpeciesDataGridViewTextBoxColumn1
            // 
            this.contractSpeciesDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.contractSpeciesDataGridViewTextBoxColumn1.DataPropertyName = "ContractSpecies";
            this.contractSpeciesDataGridViewTextBoxColumn1.HeaderText = "ContractSp";
            this.contractSpeciesDataGridViewTextBoxColumn1.Name = "contractSpeciesDataGridViewTextBoxColumn1";
            this.contractSpeciesDataGridViewTextBoxColumn1.ToolTipText = "Contract Species Code";
            this.contractSpeciesDataGridViewTextBoxColumn1.Width = 89;
            // 
            // treeGradeDataGridViewTextBoxColumn1
            // 
            this.treeGradeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.treeGradeDataGridViewTextBoxColumn1.DataPropertyName = "TreeGrade";
            this.treeGradeDataGridViewTextBoxColumn1.HeaderText = "Grade";
            this.treeGradeDataGridViewTextBoxColumn1.Name = "treeGradeDataGridViewTextBoxColumn1";
            this.treeGradeDataGridViewTextBoxColumn1.ToolTipText = "Default Tree Grade";
            this.treeGradeDataGridViewTextBoxColumn1.Width = 63;
            // 
            // merchHeightLogLengthDataGridViewTextBoxColumn1
            // 
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.DataPropertyName = "MerchHeightLogLength";
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.HeaderText = "MerchHtLL";
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.Name = "merchHeightLogLengthDataGridViewTextBoxColumn1";
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.ToolTipText = "Merchantable Height Log Length (8,16,32)";
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.Width = 86;
            // 
            // merchHeightTypeDataGridViewTextBoxColumn1
            // 
            this.merchHeightTypeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.merchHeightTypeDataGridViewTextBoxColumn1.DataPropertyName = "MerchHeightType";
            this.merchHeightTypeDataGridViewTextBoxColumn1.HeaderText = "MerchHtType";
            this.merchHeightTypeDataGridViewTextBoxColumn1.Name = "merchHeightTypeDataGridViewTextBoxColumn1";
            this.merchHeightTypeDataGridViewTextBoxColumn1.ToolTipText = "Merchantable Height Type (L,F)";
            this.merchHeightTypeDataGridViewTextBoxColumn1.Width = 99;
            // 
            // formClassDataGridViewTextBoxColumn1
            // 
            this.formClassDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.formClassDataGridViewTextBoxColumn1.DataPropertyName = "FormClass";
            this.formClassDataGridViewTextBoxColumn1.HeaderText = "FClass";
            this.formClassDataGridViewTextBoxColumn1.Name = "formClassDataGridViewTextBoxColumn1";
            this.formClassDataGridViewTextBoxColumn1.ToolTipText = "Default Form Class";
            this.formClassDataGridViewTextBoxColumn1.Width = 64;
            // 
            // barkThicknessRatioDataGridViewTextBoxColumn1
            // 
            this.barkThicknessRatioDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.barkThicknessRatioDataGridViewTextBoxColumn1.DataPropertyName = "BarkThicknessRatio";
            this.barkThicknessRatioDataGridViewTextBoxColumn1.HeaderText = "BTR";
            this.barkThicknessRatioDataGridViewTextBoxColumn1.Name = "barkThicknessRatioDataGridViewTextBoxColumn1";
            this.barkThicknessRatioDataGridViewTextBoxColumn1.ToolTipText = "Bark Thickness Ratio";
            this.barkThicknessRatioDataGridViewTextBoxColumn1.Width = 51;
            // 
            // averageZDataGridViewTextBoxColumn1
            // 
            this.averageZDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.averageZDataGridViewTextBoxColumn1.DataPropertyName = "AverageZ";
            this.averageZDataGridViewTextBoxColumn1.HeaderText = "AvgZ";
            this.averageZDataGridViewTextBoxColumn1.Name = "averageZDataGridViewTextBoxColumn1";
            this.averageZDataGridViewTextBoxColumn1.ToolTipText = "Average Z-Score";
            this.averageZDataGridViewTextBoxColumn1.Width = 57;
            // 
            // referenceHeightPercentDataGridViewTextBoxColumn1
            // 
            this.referenceHeightPercentDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.referenceHeightPercentDataGridViewTextBoxColumn1.DataPropertyName = "ReferenceHeightPercent";
            this.referenceHeightPercentDataGridViewTextBoxColumn1.HeaderText = "RefHtPer";
            this.referenceHeightPercentDataGridViewTextBoxColumn1.Name = "referenceHeightPercentDataGridViewTextBoxColumn1";
            this.referenceHeightPercentDataGridViewTextBoxColumn1.ToolTipText = "Reference Height Percent";
            this.referenceHeightPercentDataGridViewTextBoxColumn1.Width = 77;
            // 
            // _BS_treeDefaults
            // 
            this._BS_treeDefaults.DataSource = typeof(CruiseDAL.DataObjects.TreeDefaultValueDO);
            // 
            // _treeAuditDGV
            // 
            this._treeAuditDGV.AllowUserToResizeRows = false;
            this._treeAuditDGV.AutoGenerateColumns = false;
            this._treeAuditDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._treeAuditDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldDataGridViewTextBoxColumn,
            this.minDataGridViewTextBoxColumn,
            this.maxDataGridViewTextBoxColumn});
            _treeAuditRulesLayout.SetColumnSpan(this._treeAuditDGV, 4);
            this._treeAuditDGV.DataSource = this._BS_treeAudits;
            this._treeAuditDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeAuditDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this._treeAuditDGV.Location = new System.Drawing.Point(0, 31);
            this._treeAuditDGV.Margin = new System.Windows.Forms.Padding(0);
            this._treeAuditDGV.Name = "_treeAuditDGV";
            this._treeAuditDGV.RowHeadersVisible = false;
            this._treeAuditDGV.RowTemplate.Height = 24;
            this._treeAuditDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._treeAuditDGV.Size = new System.Drawing.Size(649, 229);
            this._treeAuditDGV.TabIndex = 0;
            this._treeAuditDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this._treeAuditDGV_DataError);
            // 
            // fieldDataGridViewTextBoxColumn
            // 
            this.fieldDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fieldDataGridViewTextBoxColumn.DataPropertyName = "Field";
            this.fieldDataGridViewTextBoxColumn.HeaderText = "Field";
            this.fieldDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "DBH",
            "DRC",
            "TotalHeight",
            "MerchHeightPrimary",
            "MerchHeightSecondary",
            "UpperStemHeight",
            "SeenDefectPrimary",
            "SeenDefectSecondary",
            "RecoverablePrimary"});
            this.fieldDataGridViewTextBoxColumn.Name = "fieldDataGridViewTextBoxColumn";
            this.fieldDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fieldDataGridViewTextBoxColumn.ToolTipText = "Select Field to Create Edit Check";
            // 
            // minDataGridViewTextBoxColumn
            // 
            this.minDataGridViewTextBoxColumn.DataPropertyName = "Min";
            this.minDataGridViewTextBoxColumn.HeaderText = "Min";
            this.minDataGridViewTextBoxColumn.Name = "minDataGridViewTextBoxColumn";
            this.minDataGridViewTextBoxColumn.ToolTipText = "Minimum Value Allowed";
            // 
            // maxDataGridViewTextBoxColumn
            // 
            this.maxDataGridViewTextBoxColumn.DataPropertyName = "Max";
            this.maxDataGridViewTextBoxColumn.HeaderText = "Max";
            this.maxDataGridViewTextBoxColumn.Name = "maxDataGridViewTextBoxColumn";
            this.maxDataGridViewTextBoxColumn.ToolTipText = "Maximum Value Allowed";
            // 
            // _BS_treeAudits
            // 
            this._BS_treeAudits.DataSource = typeof(CruiseDAL.DataObjects.TreeAuditValueDO);
            this._BS_treeAudits.CurrentItemChanged += new System.EventHandler(this._BS_treeAudits_CurrentItemChanged);
            // 
            // TreeAuditRulesView
            // 
            this.Controls.Add(_treeAuditRulesLayout);
            this.Font = global::CruiseManager.Properties.Settings.Default.AppFont;
            this.Name = "TreeAuditRulesView";
            this.Size = new System.Drawing.Size(649, 521);
            _treeAuditRulesLayout.ResumeLayout(false);
            _treeAuditRulesLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tdvDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeDefaults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._treeAuditDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeAudits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FMSC.Controls.SelectedItemsGridView _tdvDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryProductDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn liveDeadDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIAcodeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cullPrimaryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenPrimaryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cullSecondaryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenSecondaryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn recoverableDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractSpeciesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeGradeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn merchHeightLogLengthDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn merchHeightTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn formClassDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn barkThicknessRatioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageZDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceHeightPercentDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource _BS_treeDefaults;
        private System.Windows.Forms.DataGridView _treeAuditDGV;
        private System.Windows.Forms.DataGridViewComboBoxColumn fieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource _BS_treeAudits;
        private System.Windows.Forms.Button _treeAuditClearSelectionBtn;
        private System.Windows.Forms.Button _auditRulesHelp_BTN;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button _tavDeleteBTN;
    }
}
