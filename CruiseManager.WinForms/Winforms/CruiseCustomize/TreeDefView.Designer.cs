namespace CruiseManager.WinForms.CruiseCustomize
{
    partial class TreeDefView
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
            System.Windows.Forms.Panel panel3;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            this._deleteTDVBTN = new System.Windows.Forms.Button();
            this._editTDVButton = new System.Windows.Forms.Button();
            this._addTDVButton = new System.Windows.Forms.Button();
            this._treeDefGrid = new System.Windows.Forms.DataGridView();
            this.speciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveDeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this._BS_treeDefaults = new System.Windows.Forms.BindingSource(this.components);
            panel3 = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._treeDefGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeDefaults)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            panel3.Controls.Add(this._deleteTDVBTN);
            panel3.Controls.Add(this._editTDVButton);
            panel3.Controls.Add(this._addTDVButton);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Margin = new System.Windows.Forms.Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(801, 32);
            panel3.TabIndex = 3;
            // 
            // _deleteTDVBTN
            // 
            this._deleteTDVBTN.Location = new System.Drawing.Point(84, 5);
            this._deleteTDVBTN.Name = "_deleteTDVBTN";
            this._deleteTDVBTN.Size = new System.Drawing.Size(75, 23);
            this._deleteTDVBTN.TabIndex = 2;
            this._deleteTDVBTN.Text = "Delete";
            this._deleteTDVBTN.UseVisualStyleBackColor = true;
            this._deleteTDVBTN.Click += new System.EventHandler(this._deleteTDVBTN_Click);
            // 
            // _editTDVButton
            // 
            this._editTDVButton.Location = new System.Drawing.Point(165, 5);
            this._editTDVButton.Name = "_editTDVButton";
            this._editTDVButton.Size = new System.Drawing.Size(75, 23);
            this._editTDVButton.TabIndex = 1;
            this._editTDVButton.Text = "Edit";
            this._editTDVButton.UseVisualStyleBackColor = true;
            this._editTDVButton.Click += new System.EventHandler(this._editTDVButton_Click);
            // 
            // _addTDVButton
            // 
            this._addTDVButton.Location = new System.Drawing.Point(3, 5);
            this._addTDVButton.Name = "_addTDVButton";
            this._addTDVButton.Size = new System.Drawing.Size(75, 23);
            this._addTDVButton.TabIndex = 0;
            this._addTDVButton.Text = "Add";
            this._addTDVButton.UseVisualStyleBackColor = true;
            this._addTDVButton.Click += new System.EventHandler(this._addTDVButton_Click);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(this._treeDefGrid, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(801, 554);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // _treeDefGrid
            // 
            this._treeDefGrid.AutoGenerateColumns = false;
            this._treeDefGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._treeDefGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.speciesDataGridViewTextBoxColumn,
            this.primaryProductDataGridViewTextBoxColumn,
            this.liveDeadDataGridViewTextBoxColumn,
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
            this._treeDefGrid.DataSource = this._BS_treeDefaults;
            this._treeDefGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeDefGrid.Location = new System.Drawing.Point(0, 32);
            this._treeDefGrid.Margin = new System.Windows.Forms.Padding(0);
            this._treeDefGrid.Name = "_treeDefGrid";
            this._treeDefGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._treeDefGrid.Size = new System.Drawing.Size(801, 522);
            this._treeDefGrid.TabIndex = 4;
            // 
            // speciesDataGridViewTextBoxColumn
            // 
            this.speciesDataGridViewTextBoxColumn.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn.HeaderText = "Species *";
            this.speciesDataGridViewTextBoxColumn.Name = "speciesDataGridViewTextBoxColumn";
            // 
            // primaryProductDataGridViewTextBoxColumn
            // 
            this.primaryProductDataGridViewTextBoxColumn.DataPropertyName = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn.HeaderText = "PProd *";
            this.primaryProductDataGridViewTextBoxColumn.Name = "primaryProductDataGridViewTextBoxColumn";
            // 
            // liveDeadDataGridViewTextBoxColumn
            // 
            this.liveDeadDataGridViewTextBoxColumn.DataPropertyName = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn.HeaderText = "L/D *";
            this.liveDeadDataGridViewTextBoxColumn.Name = "liveDeadDataGridViewTextBoxColumn";
            // 
            // fIAcodeDataGridViewTextBoxColumn
            // 
            this.fIAcodeDataGridViewTextBoxColumn.DataPropertyName = "FIAcode";
            this.fIAcodeDataGridViewTextBoxColumn.HeaderText = "FIAcode";
            this.fIAcodeDataGridViewTextBoxColumn.Name = "fIAcodeDataGridViewTextBoxColumn";
            // 
            // cullPrimaryDataGridViewTextBoxColumn
            // 
            this.cullPrimaryDataGridViewTextBoxColumn.DataPropertyName = "CullPrimary";
            this.cullPrimaryDataGridViewTextBoxColumn.HeaderText = "CullP";
            this.cullPrimaryDataGridViewTextBoxColumn.Name = "cullPrimaryDataGridViewTextBoxColumn";
            // 
            // hiddenPrimaryDataGridViewTextBoxColumn
            // 
            this.hiddenPrimaryDataGridViewTextBoxColumn.DataPropertyName = "HiddenPrimary";
            this.hiddenPrimaryDataGridViewTextBoxColumn.HeaderText = "HiddenP";
            this.hiddenPrimaryDataGridViewTextBoxColumn.Name = "hiddenPrimaryDataGridViewTextBoxColumn";
            // 
            // cullSecondaryDataGridViewTextBoxColumn
            // 
            this.cullSecondaryDataGridViewTextBoxColumn.DataPropertyName = "CullSecondary";
            this.cullSecondaryDataGridViewTextBoxColumn.HeaderText = "CullS";
            this.cullSecondaryDataGridViewTextBoxColumn.Name = "cullSecondaryDataGridViewTextBoxColumn";
            // 
            // hiddenSecondaryDataGridViewTextBoxColumn
            // 
            this.hiddenSecondaryDataGridViewTextBoxColumn.DataPropertyName = "HiddenSecondary";
            this.hiddenSecondaryDataGridViewTextBoxColumn.HeaderText = "HiddenS";
            this.hiddenSecondaryDataGridViewTextBoxColumn.Name = "hiddenSecondaryDataGridViewTextBoxColumn";
            // 
            // recoverableDataGridViewTextBoxColumn
            // 
            this.recoverableDataGridViewTextBoxColumn.DataPropertyName = "Recoverable";
            this.recoverableDataGridViewTextBoxColumn.HeaderText = "% Rec";
            this.recoverableDataGridViewTextBoxColumn.Name = "recoverableDataGridViewTextBoxColumn";
            // 
            // contractSpeciesDataGridViewTextBoxColumn
            // 
            this.contractSpeciesDataGridViewTextBoxColumn.DataPropertyName = "ContractSpecies";
            this.contractSpeciesDataGridViewTextBoxColumn.HeaderText = "ContractSpec";
            this.contractSpeciesDataGridViewTextBoxColumn.Name = "contractSpeciesDataGridViewTextBoxColumn";
            // 
            // treeGradeDataGridViewTextBoxColumn
            // 
            this.treeGradeDataGridViewTextBoxColumn.DataPropertyName = "TreeGrade";
            this.treeGradeDataGridViewTextBoxColumn.HeaderText = "Grade";
            this.treeGradeDataGridViewTextBoxColumn.Name = "treeGradeDataGridViewTextBoxColumn";
            // 
            // merchHeightLogLengthDataGridViewTextBoxColumn
            // 
            this.merchHeightLogLengthDataGridViewTextBoxColumn.DataPropertyName = "MerchHeightLogLength";
            this.merchHeightLogLengthDataGridViewTextBoxColumn.HeaderText = "MerchHLL";
            this.merchHeightLogLengthDataGridViewTextBoxColumn.Name = "merchHeightLogLengthDataGridViewTextBoxColumn";
            // 
            // merchHeightTypeDataGridViewTextBoxColumn
            // 
            this.merchHeightTypeDataGridViewTextBoxColumn.DataPropertyName = "MerchHeightType";
            this.merchHeightTypeDataGridViewTextBoxColumn.HeaderText = "MerchHtType";
            this.merchHeightTypeDataGridViewTextBoxColumn.Name = "merchHeightTypeDataGridViewTextBoxColumn";
            // 
            // formClassDataGridViewTextBoxColumn
            // 
            this.formClassDataGridViewTextBoxColumn.DataPropertyName = "FormClass";
            this.formClassDataGridViewTextBoxColumn.HeaderText = "FClass";
            this.formClassDataGridViewTextBoxColumn.Name = "formClassDataGridViewTextBoxColumn";
            // 
            // barkThicknessRatioDataGridViewTextBoxColumn
            // 
            this.barkThicknessRatioDataGridViewTextBoxColumn.DataPropertyName = "BarkThicknessRatio";
            this.barkThicknessRatioDataGridViewTextBoxColumn.HeaderText = "BTR";
            this.barkThicknessRatioDataGridViewTextBoxColumn.Name = "barkThicknessRatioDataGridViewTextBoxColumn";
            // 
            // averageZDataGridViewTextBoxColumn
            // 
            this.averageZDataGridViewTextBoxColumn.DataPropertyName = "AverageZ";
            this.averageZDataGridViewTextBoxColumn.HeaderText = "AvgZ";
            this.averageZDataGridViewTextBoxColumn.Name = "averageZDataGridViewTextBoxColumn";
            // 
            // referenceHeightPercentDataGridViewTextBoxColumn
            // 
            this.referenceHeightPercentDataGridViewTextBoxColumn.DataPropertyName = "ReferenceHeightPercent";
            this.referenceHeightPercentDataGridViewTextBoxColumn.HeaderText = "RefHtPerc";
            this.referenceHeightPercentDataGridViewTextBoxColumn.Name = "referenceHeightPercentDataGridViewTextBoxColumn";
            // 
            // _BS_treeDefaults
            // 
            this._BS_treeDefaults.DataSource = typeof(CruiseDAL.DataObjects.TreeDefaultValueDO);
            // 
            // TreeDefView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "TreeDefView";
            this.Size = new System.Drawing.Size(801, 554);
            panel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._treeDefGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeDefaults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource _BS_treeDefaults;
        private System.Windows.Forms.Button _deleteTDVBTN;
        private System.Windows.Forms.Button _editTDVButton;
        private System.Windows.Forms.Button _addTDVButton;
        private System.Windows.Forms.DataGridView _treeDefGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryProductDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn liveDeadDataGridViewTextBoxColumn;
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