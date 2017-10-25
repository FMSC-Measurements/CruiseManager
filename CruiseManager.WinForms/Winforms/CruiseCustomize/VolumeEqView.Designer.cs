namespace CruiseManager.WinForms.CruiseCustomize
{
    partial class VolumeEqView
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
            System.Windows.Forms.Panel panel6;
            this._volEq_delete_button = new System.Windows.Forms.Button();
            this._volEq_add_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._volumeEQsDGV = new System.Windows.Forms.DataGridView();
            this._BS_VolEquations = new System.Windows.Forms.BindingSource(this.components);
            this.volumeEquationNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonSpeciesNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryProductDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stumpHeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topDIBPrimaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topDIBSecondaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcBoardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcCubicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcCordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcTopwoodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcBiomassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trimDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segmentationLogicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minLogLengthPrimaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxLogLengthPrimaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minMerchLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panel6 = new System.Windows.Forms.Panel();
            panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._volumeEQsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_VolEquations)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            panel6.AutoSize = true;
            panel6.BackColor = System.Drawing.Color.DarkSeaGreen;
            panel6.Controls.Add(this._volEq_delete_button);
            panel6.Controls.Add(this._volEq_add_button);
            panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(0, 0);
            panel6.Margin = new System.Windows.Forms.Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(876, 29);
            panel6.TabIndex = 3;
            // 
            // _volEq_delete_button
            // 
            this._volEq_delete_button.Location = new System.Drawing.Point(84, 3);
            this._volEq_delete_button.Name = "_volEq_delete_button";
            this._volEq_delete_button.Size = new System.Drawing.Size(75, 23);
            this._volEq_delete_button.TabIndex = 2;
            this._volEq_delete_button.Text = "Delete";
            this._volEq_delete_button.UseVisualStyleBackColor = true;
            this._volEq_delete_button.Click += new System.EventHandler(this._volEq_delete_button_Click);
            // 
            // _volEq_add_button
            // 
            this._volEq_add_button.Location = new System.Drawing.Point(3, 3);
            this._volEq_add_button.Name = "_volEq_add_button";
            this._volEq_add_button.Size = new System.Drawing.Size(75, 23);
            this._volEq_add_button.TabIndex = 0;
            this._volEq_add_button.Text = "Add";
            this._volEq_add_button.UseVisualStyleBackColor = true;
            this._volEq_add_button.Click += new System.EventHandler(this._volEq_add_button_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this._volumeEQsDGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(panel6, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 484);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // _volumeEQsDGV
            // 
            this._volumeEQsDGV.AutoGenerateColumns = false;
            this._volumeEQsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._volumeEQsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.volumeEquationNumberDataGridViewTextBoxColumn,
            this.commonSpeciesNameDataGridViewTextBoxColumn,
            this.speciesDataGridViewTextBoxColumn1,
            this.primaryProductDataGridViewTextBoxColumn1,
            this.stumpHeightDataGridViewTextBoxColumn,
            this.topDIBPrimaryDataGridViewTextBoxColumn,
            this.topDIBSecondaryDataGridViewTextBoxColumn,
            this.calcTotalDataGridViewTextBoxColumn,
            this.calcBoardDataGridViewTextBoxColumn,
            this.calcCubicDataGridViewTextBoxColumn,
            this.calcCordDataGridViewTextBoxColumn,
            this.calcTopwoodDataGridViewTextBoxColumn,
            this.calcBiomassDataGridViewTextBoxColumn,
            this.trimDataGridViewTextBoxColumn,
            this.segmentationLogicDataGridViewTextBoxColumn,
            this.minLogLengthPrimaryDataGridViewTextBoxColumn,
            this.maxLogLengthPrimaryDataGridViewTextBoxColumn,
            this.minMerchLengthDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn});
            this._volumeEQsDGV.DataSource = this._BS_VolEquations;
            this._volumeEQsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._volumeEQsDGV.Location = new System.Drawing.Point(3, 32);
            this._volumeEQsDGV.Name = "_volumeEQsDGV";
            this._volumeEQsDGV.Size = new System.Drawing.Size(870, 449);
            this._volumeEQsDGV.TabIndex = 4;
            // 
            // _BS_VolEquations
            // 
            this._BS_VolEquations.DataSource = typeof(CruiseDAL.DataObjects.VolumeEquationDO);
            // 
            // volumeEquationNumberDataGridViewTextBoxColumn
            // 
            this.volumeEquationNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.volumeEquationNumberDataGridViewTextBoxColumn.DataPropertyName = "VolumeEquationNumber";
            this.volumeEquationNumberDataGridViewTextBoxColumn.HeaderText = "Equation #";
            this.volumeEquationNumberDataGridViewTextBoxColumn.Name = "volumeEquationNumberDataGridViewTextBoxColumn";
            this.volumeEquationNumberDataGridViewTextBoxColumn.ToolTipText = "Volume Equation Number";
            this.volumeEquationNumberDataGridViewTextBoxColumn.Width = 84;
            // 
            // commonSpeciesNameDataGridViewTextBoxColumn
            // 
            this.commonSpeciesNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.commonSpeciesNameDataGridViewTextBoxColumn.DataPropertyName = "CommonSpeciesName";
            this.commonSpeciesNameDataGridViewTextBoxColumn.HeaderText = "Species Name";
            this.commonSpeciesNameDataGridViewTextBoxColumn.Name = "commonSpeciesNameDataGridViewTextBoxColumn";
            this.commonSpeciesNameDataGridViewTextBoxColumn.ToolTipText = "Common Species Name";
            this.commonSpeciesNameDataGridViewTextBoxColumn.Width = 101;
            // 
            // speciesDataGridViewTextBoxColumn1
            // 
            this.speciesDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.speciesDataGridViewTextBoxColumn1.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn1.HeaderText = "Sp. Code";
            this.speciesDataGridViewTextBoxColumn1.Name = "speciesDataGridViewTextBoxColumn1";
            this.speciesDataGridViewTextBoxColumn1.ToolTipText = "Species Code";
            this.speciesDataGridViewTextBoxColumn1.Width = 76;
            // 
            // primaryProductDataGridViewTextBoxColumn1
            // 
            this.primaryProductDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.primaryProductDataGridViewTextBoxColumn1.DataPropertyName = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn1.HeaderText = "PProd";
            this.primaryProductDataGridViewTextBoxColumn1.Name = "primaryProductDataGridViewTextBoxColumn1";
            this.primaryProductDataGridViewTextBoxColumn1.ToolTipText = "Primary Product Code";
            this.primaryProductDataGridViewTextBoxColumn1.Width = 61;
            // 
            // stumpHeightDataGridViewTextBoxColumn
            // 
            this.stumpHeightDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.stumpHeightDataGridViewTextBoxColumn.DataPropertyName = "StumpHeight";
            this.stumpHeightDataGridViewTextBoxColumn.HeaderText = "StumpHt";
            this.stumpHeightDataGridViewTextBoxColumn.Name = "stumpHeightDataGridViewTextBoxColumn";
            this.stumpHeightDataGridViewTextBoxColumn.ToolTipText = "Stump Height";
            this.stumpHeightDataGridViewTextBoxColumn.Width = 73;
            // 
            // topDIBPrimaryDataGridViewTextBoxColumn
            // 
            this.topDIBPrimaryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.topDIBPrimaryDataGridViewTextBoxColumn.DataPropertyName = "TopDIBPrimary";
            this.topDIBPrimaryDataGridViewTextBoxColumn.HeaderText = "TopDibP";
            this.topDIBPrimaryDataGridViewTextBoxColumn.Name = "topDIBPrimaryDataGridViewTextBoxColumn";
            this.topDIBPrimaryDataGridViewTextBoxColumn.ToolTipText = "Minimum Top Diameter Primary Product (inside bark)";
            this.topDIBPrimaryDataGridViewTextBoxColumn.Width = 74;
            // 
            // topDIBSecondaryDataGridViewTextBoxColumn
            // 
            this.topDIBSecondaryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.topDIBSecondaryDataGridViewTextBoxColumn.DataPropertyName = "TopDIBSecondary";
            this.topDIBSecondaryDataGridViewTextBoxColumn.HeaderText = "TopDibS";
            this.topDIBSecondaryDataGridViewTextBoxColumn.Name = "topDIBSecondaryDataGridViewTextBoxColumn";
            this.topDIBSecondaryDataGridViewTextBoxColumn.ToolTipText = "Minimum Top Diameter Secondary Product (inside bark)";
            this.topDIBSecondaryDataGridViewTextBoxColumn.Width = 74;
            // 
            // calcTotalDataGridViewTextBoxColumn
            // 
            this.calcTotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.calcTotalDataGridViewTextBoxColumn.DataPropertyName = "CalcTotal";
            this.calcTotalDataGridViewTextBoxColumn.HeaderText = "CalcTotal";
            this.calcTotalDataGridViewTextBoxColumn.Name = "calcTotalDataGridViewTextBoxColumn";
            this.calcTotalDataGridViewTextBoxColumn.ToolTipText = "Calculate Total Cubic Volume Flag";
            this.calcTotalDataGridViewTextBoxColumn.Width = 77;
            // 
            // calcBoardDataGridViewTextBoxColumn
            // 
            this.calcBoardDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.calcBoardDataGridViewTextBoxColumn.DataPropertyName = "CalcBoard";
            this.calcBoardDataGridViewTextBoxColumn.HeaderText = "CalcBoard";
            this.calcBoardDataGridViewTextBoxColumn.Name = "calcBoardDataGridViewTextBoxColumn";
            this.calcBoardDataGridViewTextBoxColumn.ToolTipText = "Calculate Board Foot Volume Flag";
            this.calcBoardDataGridViewTextBoxColumn.Width = 81;
            // 
            // calcCubicDataGridViewTextBoxColumn
            // 
            this.calcCubicDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.calcCubicDataGridViewTextBoxColumn.DataPropertyName = "CalcCubic";
            this.calcCubicDataGridViewTextBoxColumn.HeaderText = "CalcCubic";
            this.calcCubicDataGridViewTextBoxColumn.Name = "calcCubicDataGridViewTextBoxColumn";
            this.calcCubicDataGridViewTextBoxColumn.ToolTipText = "Calculate Cubic Foot Volume Flag";
            this.calcCubicDataGridViewTextBoxColumn.Width = 80;
            // 
            // calcCordDataGridViewTextBoxColumn
            // 
            this.calcCordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.calcCordDataGridViewTextBoxColumn.DataPropertyName = "CalcCord";
            this.calcCordDataGridViewTextBoxColumn.HeaderText = "CalcCord";
            this.calcCordDataGridViewTextBoxColumn.Name = "calcCordDataGridViewTextBoxColumn";
            this.calcCordDataGridViewTextBoxColumn.ToolTipText = "Calculate Cordwood Volume Flag";
            this.calcCordDataGridViewTextBoxColumn.Width = 75;
            // 
            // calcTopwoodDataGridViewTextBoxColumn
            // 
            this.calcTopwoodDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.calcTopwoodDataGridViewTextBoxColumn.DataPropertyName = "CalcTopwood";
            this.calcTopwoodDataGridViewTextBoxColumn.HeaderText = "CalcTopwood";
            this.calcTopwoodDataGridViewTextBoxColumn.Name = "calcTopwoodDataGridViewTextBoxColumn";
            this.calcTopwoodDataGridViewTextBoxColumn.ToolTipText = "Calculate Topwood Volume Flag";
            this.calcTopwoodDataGridViewTextBoxColumn.Width = 98;
            // 
            // calcBiomassDataGridViewTextBoxColumn
            // 
            this.calcBiomassDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.calcBiomassDataGridViewTextBoxColumn.DataPropertyName = "CalcBiomass";
            this.calcBiomassDataGridViewTextBoxColumn.HeaderText = "CalcBiomass";
            this.calcBiomassDataGridViewTextBoxColumn.Name = "calcBiomassDataGridViewTextBoxColumn";
            this.calcBiomassDataGridViewTextBoxColumn.ToolTipText = "Calculate Biomass Flag";
            this.calcBiomassDataGridViewTextBoxColumn.Width = 92;
            // 
            // trimDataGridViewTextBoxColumn
            // 
            this.trimDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.trimDataGridViewTextBoxColumn.DataPropertyName = "Trim";
            this.trimDataGridViewTextBoxColumn.HeaderText = "Trim";
            this.trimDataGridViewTextBoxColumn.Name = "trimDataGridViewTextBoxColumn";
            this.trimDataGridViewTextBoxColumn.ToolTipText = "Amount of Trim in Feet";
            this.trimDataGridViewTextBoxColumn.Width = 52;
            // 
            // segmentationLogicDataGridViewTextBoxColumn
            // 
            this.segmentationLogicDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.segmentationLogicDataGridViewTextBoxColumn.DataPropertyName = "SegmentationLogic";
            this.segmentationLogicDataGridViewTextBoxColumn.HeaderText = "SegmentLogic";
            this.segmentationLogicDataGridViewTextBoxColumn.Name = "segmentationLogicDataGridViewTextBoxColumn";
            this.segmentationLogicDataGridViewTextBoxColumn.ToolTipText = "Segmentation Logic Code";
            // 
            // minLogLengthPrimaryDataGridViewTextBoxColumn
            // 
            this.minLogLengthPrimaryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.minLogLengthPrimaryDataGridViewTextBoxColumn.DataPropertyName = "MinLogLengthPrimary";
            this.minLogLengthPrimaryDataGridViewTextBoxColumn.HeaderText = "MinLogLenP";
            this.minLogLengthPrimaryDataGridViewTextBoxColumn.Name = "minLogLengthPrimaryDataGridViewTextBoxColumn";
            this.minLogLengthPrimaryDataGridViewTextBoxColumn.ToolTipText = "Minimum Log Length for Primary Product";
            this.minLogLengthPrimaryDataGridViewTextBoxColumn.Width = 92;
            // 
            // maxLogLengthPrimaryDataGridViewTextBoxColumn
            // 
            this.maxLogLengthPrimaryDataGridViewTextBoxColumn.DataPropertyName = "MaxLogLengthPrimary";
            this.maxLogLengthPrimaryDataGridViewTextBoxColumn.HeaderText = "MaxLogLenP";
            this.maxLogLengthPrimaryDataGridViewTextBoxColumn.Name = "maxLogLengthPrimaryDataGridViewTextBoxColumn";
            this.maxLogLengthPrimaryDataGridViewTextBoxColumn.ToolTipText = "Maximum Log Length for Primary";
            // 
            // minMerchLengthDataGridViewTextBoxColumn
            // 
            this.minMerchLengthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.minMerchLengthDataGridViewTextBoxColumn.DataPropertyName = "MinMerchLength";
            this.minMerchLengthDataGridViewTextBoxColumn.HeaderText = "MinMerchLen";
            this.minMerchLengthDataGridViewTextBoxColumn.Name = "minMerchLengthDataGridViewTextBoxColumn";
            this.minMerchLengthDataGridViewTextBoxColumn.ToolTipText = "Minimum Merchantable Length for Tree to Have Volume";
            this.minMerchLengthDataGridViewTextBoxColumn.Width = 97;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.ToolTipText = "Volume Model";
            this.modelDataGridViewTextBoxColumn.Width = 61;
            // 
            // VolumeEqView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VolumeEqView";
            this.Size = new System.Drawing.Size(876, 484);
            panel6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._volumeEQsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_VolEquations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView _volumeEQsDGV;
        private System.Windows.Forms.BindingSource _BS_VolEquations;
        private System.Windows.Forms.Button _volEq_delete_button;
        private System.Windows.Forms.Button _volEq_add_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeEquationNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commonSpeciesNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryProductDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stumpHeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn topDIBPrimaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn topDIBSecondaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcBoardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcCubicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcCordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcTopwoodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calcBiomassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trimDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segmentationLogicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minLogLengthPrimaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxLogLengthPrimaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minMerchLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
    }
}