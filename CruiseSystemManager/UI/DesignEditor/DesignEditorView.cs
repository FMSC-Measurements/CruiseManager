using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using System.Collections;

namespace CSM.UI.DesignEditor
{
    public partial class DesignEditorView : Form, IView
    {


        #region Designer Code
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
            System.Windows.Forms.ErrorProvider SaleErrorProvider;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalePurposeComboBox = new System.Windows.Forms.ComboBox();
            this.RegionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.forestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoggingMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CuttingUnitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CuttingUnits_StrataSelectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Strata_CuttingUnitsSelectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cruiseMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StrataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Strata_CuttingUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SampleGroups_StrataSelectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SampleGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SampleGroup_TDVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuttingUnitErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleGroupTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SampleGroups_DeleteButton = new System.Windows.Forms.Button();
            this.SampleGroups_AddButton = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.SampleGroupDataGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cutLeaveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uOMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondaryProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultLiveDeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.samplingFrequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insuranceFrequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tallyHotkeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.SampleGroups_TDVGridView = new FMSC.Controls.SelectedItemsGridView();
            this.primaryProductDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveDeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.StrataTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.EditFieldSetupButton = new System.Windows.Forms.Button();
            this.Strata_DeleteButton = new System.Windows.Forms.Button();
            this.Strata_AddButton = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.StrataDataGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basalAreaFactorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fixedPlotSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.monthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.Strata_CuttingUnitsGridView = new FMSC.Controls.SelectedItemsGridView();
            this.codeDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuttingUnitsTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.CuttingUnitDataGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loggingMethodDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.paymentUnitDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StratumCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CuttingUnits_DeleteButton = new System.Windows.Forms.Button();
            this.CuttingUnits_AddButton = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.SaleInfoTabPage = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SaleDistrictTextBox = new FMSC.Controls.SideLabelTextBox();
            this.SaleNumberTextBox = new FMSC.Controls.SideLabelTextBox();
            this.SaleNameTextBox = new FMSC.Controls.SideLabelTextBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            SaleErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(SaleErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleBindingSource)).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnits_StrataSelectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Strata_CuttingUnitsSelectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cruiseMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Strata_CuttingUnitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroups_StrataSelectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroup_TDVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitErrorProvider)).BeginInit();
            this.SampleGroupTabPage.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroupDataGridView)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroups_TDVGridView)).BeginInit();
            this.StrataTabPage.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StrataDataGridView)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Strata_CuttingUnitsGridView)).BeginInit();
            this.CuttingUnitsTabPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitDataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SaleInfoTabPage.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaleErrorProvider
            // 
            SaleErrorProvider.ContainerControl = this;
            SaleErrorProvider.DataSource = this.SaleBindingSource;
            // 
            // SaleBindingSource
            // 
            this.SaleBindingSource.DataSource = typeof(CruiseDAL.DataObjects.SaleDO);
            // 
            // label8
            // 
            label8.Dock = System.Windows.Forms.DockStyle.Left;
            label8.Location = new System.Drawing.Point(0, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(35, 25);
            label8.TabIndex = 2;
            label8.Text = "Strata";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Dock = System.Windows.Forms.DockStyle.Right;
            label7.Location = new System.Drawing.Point(363, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(102, 25);
            label7.TabIndex = 0;
            label7.Text = "Filter By Cutting Unit";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Dock = System.Windows.Forms.DockStyle.Right;
            label4.Location = new System.Drawing.Point(607, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 25);
            label4.TabIndex = 2;
            label4.Text = "Filter By Stratum";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(this.SalePurposeComboBox);
            panel1.Controls.Add(label6);
            panel1.Location = new System.Drawing.Point(10, 224);
            panel1.Margin = new System.Windows.Forms.Padding(10);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(237, 27);
            panel1.TabIndex = 16;
            // 
            // SalePurposeComboBox
            // 
            this.SalePurposeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleBindingSource, "Purpose", true));
            this.SalePurposeComboBox.FormattingEnabled = true;
            this.SalePurposeComboBox.Location = new System.Drawing.Point(66, 3);
            this.SalePurposeComboBox.Name = "SalePurposeComboBox";
            this.SalePurposeComboBox.Size = new System.Drawing.Size(171, 21);
            this.SalePurposeComboBox.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 3);
            label6.Name = "label6";
            label6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            label6.Size = new System.Drawing.Size(46, 21);
            label6.TabIndex = 15;
            label6.Text = "Purpose";
            // 
            // RegionBindingSource
            // 
            this.RegionBindingSource.DataSource = typeof(CSM.Utility.Setup.Region);
            // 
            // forestsBindingSource
            // 
            this.forestsBindingSource.DataMember = "Forests";
            this.forestsBindingSource.DataSource = this.RegionBindingSource;
            // 
            // LoggingMethodBindingSource
            // 
            this.LoggingMethodBindingSource.DataSource = typeof(CSM.Utility.Setup.LoggingMethod);
            // 
            // CuttingUnitsBindingSource
            // 
            this.CuttingUnitsBindingSource.DataSource = typeof(CruiseDAL.DataObjects.CuttingUnitDO);
            this.CuttingUnitsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.CuttingUnitsBindingSource_AddingNew);
            // 
            // CuttingUnits_StrataSelectionBindingSource
            // 
            this.CuttingUnits_StrataSelectionBindingSource.DataSource = typeof(CruiseDAL.DataObjects.StratumDO);
            this.CuttingUnits_StrataSelectionBindingSource.CurrentChanged += new System.EventHandler(this.CuttingUnits_StrataSelectionBindingSource_CurrentChanged);
            // 
            // Strata_CuttingUnitsSelectionBindingSource
            // 
            this.Strata_CuttingUnitsSelectionBindingSource.DataSource = typeof(CruiseDAL.DataObjects.CuttingUnitDO);
            this.Strata_CuttingUnitsSelectionBindingSource.CurrentChanged += new System.EventHandler(this.Strata_CuttingUnitsSelectionBindingSource_CurrentChanged);
            // 
            // cruiseMethodBindingSource
            // 
            this.cruiseMethodBindingSource.DataSource = typeof(CSM.Utility.Setup.CruiseMethod);
            // 
            // StrataBindingSource
            // 
            this.StrataBindingSource.DataSource = typeof(CruiseDAL.DataObjects.StratumDO);
            this.StrataBindingSource.CurrentChanged += new System.EventHandler(this.StrataBindingSource_CurrentChanged);
            this.StrataBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.StrataBindingSource_AddingNew);
            // 
            // Strata_CuttingUnitBindingSource
            // 
            this.Strata_CuttingUnitBindingSource.DataSource = typeof(CruiseDAL.DataObjects.CuttingUnitDO);
            // 
            // SampleGroups_StrataSelectionBindingSource
            // 
            this.SampleGroups_StrataSelectionBindingSource.DataSource = typeof(CruiseDAL.DataObjects.StratumDO);
            this.SampleGroups_StrataSelectionBindingSource.CurrentChanged += new System.EventHandler(this.SampleGroups_StrataSelectionBindingSource_CurrentChanged);
            // 
            // SampleGroupBindingSource
            // 
            this.SampleGroupBindingSource.DataSource = typeof(CruiseDAL.DataObjects.SampleGroupDO);
            this.SampleGroupBindingSource.CurrentChanged += new System.EventHandler(this.SampleGroupBindingSource_CurrentChanged);
            this.SampleGroupBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.SampleGroupBindingSource_AddingNew);
            // 
            // SampleGroup_TDVBindingSource
            // 
            this.SampleGroup_TDVBindingSource.DataSource = typeof(CruiseDAL.DataObjects.TreeDefaultValueDO);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Tag";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // CuttingUnitErrorProvider
            // 
            this.CuttingUnitErrorProvider.ContainerControl = this;
            this.CuttingUnitErrorProvider.DataSource = this.CuttingUnitsBindingSource;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Tag";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // SampleGroupTabPage
            // 
            this.SampleGroupTabPage.Controls.Add(this.splitContainer2);
            this.SampleGroupTabPage.Location = new System.Drawing.Point(4, 22);
            this.SampleGroupTabPage.Name = "SampleGroupTabPage";
            this.SampleGroupTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SampleGroupTabPage.Size = new System.Drawing.Size(817, 402);
            this.SampleGroupTabPage.TabIndex = 2;
            this.SampleGroupTabPage.Text = "Sample Groups";
            this.SampleGroupTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel7);
            this.splitContainer2.Size = new System.Drawing.Size(811, 396);
            this.splitContainer2.SplitterDistance = 536;
            this.splitContainer2.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SampleGroupDataGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.Controls.Add(this.SampleGroups_DeleteButton);
            this.panel4.Controls.Add(this.SampleGroups_AddButton);
            this.panel4.Controls.Add(this.comboBox7);
            this.panel4.Controls.Add(label8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(536, 25);
            this.panel4.TabIndex = 4;
            // 
            // SampleGroups_DeleteButton
            // 
            this.SampleGroups_DeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SampleGroups_DeleteButton.Location = new System.Drawing.Point(231, 0);
            this.SampleGroups_DeleteButton.Name = "SampleGroups_DeleteButton";
            this.SampleGroups_DeleteButton.Size = new System.Drawing.Size(75, 25);
            this.SampleGroups_DeleteButton.TabIndex = 5;
            this.SampleGroups_DeleteButton.Text = "Delete";
            this.SampleGroups_DeleteButton.UseVisualStyleBackColor = true;
            this.SampleGroups_DeleteButton.Click += new System.EventHandler(this.SampleGroups_DeleteButton_Click);
            // 
            // SampleGroups_AddButton
            // 
            this.SampleGroups_AddButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SampleGroups_AddButton.Location = new System.Drawing.Point(156, 0);
            this.SampleGroups_AddButton.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.SampleGroups_AddButton.Name = "SampleGroups_AddButton";
            this.SampleGroups_AddButton.Size = new System.Drawing.Size(75, 25);
            this.SampleGroups_AddButton.TabIndex = 4;
            this.SampleGroups_AddButton.Text = "Add";
            this.SampleGroups_AddButton.UseVisualStyleBackColor = true;
            this.SampleGroups_AddButton.Click += new System.EventHandler(this.SampleGroups_AddButton_Click);
            // 
            // comboBox7
            // 
            this.comboBox7.DataSource = this.SampleGroups_StrataSelectionBindingSource;
            this.comboBox7.DisplayMember = "Code";
            this.comboBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(35, 0);
            this.comboBox7.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(121, 21);
            this.comboBox7.TabIndex = 3;
            // 
            // SampleGroupDataGridView
            // 
            this.SampleGroupDataGridView.AllowUserToDeleteRows = false;
            this.SampleGroupDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SampleGroupDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.SampleGroupDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SampleGroupDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn2,
            this.cutLeaveDataGridViewTextBoxColumn,
            this.uOMDataGridViewTextBoxColumn,
            this.primaryProductDataGridViewTextBoxColumn,
            this.secondaryProductDataGridViewTextBoxColumn,
            this.defaultLiveDeadDataGridViewTextBoxColumn,
            this.samplingFrequencyDataGridViewTextBoxColumn,
            this.insuranceFrequencyDataGridViewTextBoxColumn,
            this.kZDataGridViewTextBoxColumn,
            this.tallyHotkeyDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn2});
            this.SampleGroupDataGridView.DataSource = this.SampleGroupBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SampleGroupDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.SampleGroupDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SampleGroupDataGridView.Location = new System.Drawing.Point(3, 28);
            this.SampleGroupDataGridView.Name = "SampleGroupDataGridView";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SampleGroupDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.SampleGroupDataGridView.Size = new System.Drawing.Size(530, 365);
            this.SampleGroupDataGridView.TabIndex = 5;
            this.SampleGroupDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.SampleGroupDataGridView_RowEnter);
            // 
            // codeDataGridViewTextBoxColumn2
            // 
            this.codeDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeDataGridViewTextBoxColumn2.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn2.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn2.Name = "codeDataGridViewTextBoxColumn2";
            this.codeDataGridViewTextBoxColumn2.Width = 57;
            // 
            // cutLeaveDataGridViewTextBoxColumn
            // 
            this.cutLeaveDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cutLeaveDataGridViewTextBoxColumn.DataPropertyName = "CutLeave";
            this.cutLeaveDataGridViewTextBoxColumn.HeaderText = "CutLeave";
            this.cutLeaveDataGridViewTextBoxColumn.Name = "cutLeaveDataGridViewTextBoxColumn";
            this.cutLeaveDataGridViewTextBoxColumn.Width = 78;
            // 
            // uOMDataGridViewTextBoxColumn
            // 
            this.uOMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uOMDataGridViewTextBoxColumn.DataPropertyName = "UOM";
            this.uOMDataGridViewTextBoxColumn.HeaderText = "UOM";
            this.uOMDataGridViewTextBoxColumn.Name = "uOMDataGridViewTextBoxColumn";
            this.uOMDataGridViewTextBoxColumn.Width = 57;
            // 
            // primaryProductDataGridViewTextBoxColumn
            // 
            this.primaryProductDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.primaryProductDataGridViewTextBoxColumn.DataPropertyName = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn.HeaderText = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn.Name = "primaryProductDataGridViewTextBoxColumn";
            this.primaryProductDataGridViewTextBoxColumn.Width = 103;
            // 
            // secondaryProductDataGridViewTextBoxColumn
            // 
            this.secondaryProductDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.secondaryProductDataGridViewTextBoxColumn.DataPropertyName = "SecondaryProduct";
            this.secondaryProductDataGridViewTextBoxColumn.HeaderText = "SecondaryProduct";
            this.secondaryProductDataGridViewTextBoxColumn.Name = "secondaryProductDataGridViewTextBoxColumn";
            this.secondaryProductDataGridViewTextBoxColumn.Width = 120;
            // 
            // defaultLiveDeadDataGridViewTextBoxColumn
            // 
            this.defaultLiveDeadDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.defaultLiveDeadDataGridViewTextBoxColumn.DataPropertyName = "DefaultLiveDead";
            this.defaultLiveDeadDataGridViewTextBoxColumn.HeaderText = "DefaultLiveDead";
            this.defaultLiveDeadDataGridViewTextBoxColumn.Name = "defaultLiveDeadDataGridViewTextBoxColumn";
            this.defaultLiveDeadDataGridViewTextBoxColumn.Width = 112;
            // 
            // samplingFrequencyDataGridViewTextBoxColumn
            // 
            this.samplingFrequencyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.samplingFrequencyDataGridViewTextBoxColumn.DataPropertyName = "SamplingFrequency";
            this.samplingFrequencyDataGridViewTextBoxColumn.HeaderText = "SamplingFrequency";
            this.samplingFrequencyDataGridViewTextBoxColumn.Name = "samplingFrequencyDataGridViewTextBoxColumn";
            this.samplingFrequencyDataGridViewTextBoxColumn.Width = 125;
            // 
            // insuranceFrequencyDataGridViewTextBoxColumn
            // 
            this.insuranceFrequencyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insuranceFrequencyDataGridViewTextBoxColumn.DataPropertyName = "InsuranceFrequency";
            this.insuranceFrequencyDataGridViewTextBoxColumn.HeaderText = "InsuranceFrequency";
            this.insuranceFrequencyDataGridViewTextBoxColumn.Name = "insuranceFrequencyDataGridViewTextBoxColumn";
            this.insuranceFrequencyDataGridViewTextBoxColumn.Width = 129;
            // 
            // kZDataGridViewTextBoxColumn
            // 
            this.kZDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.kZDataGridViewTextBoxColumn.DataPropertyName = "KZ";
            this.kZDataGridViewTextBoxColumn.HeaderText = "KZ";
            this.kZDataGridViewTextBoxColumn.Name = "kZDataGridViewTextBoxColumn";
            this.kZDataGridViewTextBoxColumn.Width = 46;
            // 
            // tallyHotkeyDataGridViewTextBoxColumn
            // 
            this.tallyHotkeyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tallyHotkeyDataGridViewTextBoxColumn.DataPropertyName = "TallyHotkey";
            this.tallyHotkeyDataGridViewTextBoxColumn.HeaderText = "TallyHotkey";
            this.tallyHotkeyDataGridViewTextBoxColumn.Name = "tallyHotkeyDataGridViewTextBoxColumn";
            this.tallyHotkeyDataGridViewTextBoxColumn.Width = 88;
            // 
            // descriptionDataGridViewTextBoxColumn2
            // 
            this.descriptionDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn2.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn2.MinimumWidth = 85;
            this.descriptionDataGridViewTextBoxColumn2.Name = "descriptionDataGridViewTextBoxColumn2";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(271, 396);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Defaults (Select to add)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.SampleGroups_TDVGridView);
            this.panel7.Controls.Add(this.button1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 28);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(265, 365);
            this.panel7.TabIndex = 8;
            // 
            // SampleGroups_TDVGridView
            // 
            this.SampleGroups_TDVGridView.AllowUserToAddRows = false;
            this.SampleGroups_TDVGridView.AllowUserToDeleteRows = false;
            this.SampleGroups_TDVGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SampleGroups_TDVGridView.AutoGenerateColumns = false;
            this.SampleGroups_TDVGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SampleGroups_TDVGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.primaryProductDataGridViewTextBoxColumn1,
            this.speciesDataGridViewTextBoxColumn,
            this.liveDeadDataGridViewTextBoxColumn});
            this.SampleGroups_TDVGridView.DataSource = this.SampleGroup_TDVBindingSource;
            this.SampleGroups_TDVGridView.Location = new System.Drawing.Point(0, -4);
            this.SampleGroups_TDVGridView.Margin = new System.Windows.Forms.Padding(0);
            this.SampleGroups_TDVGridView.Name = "SampleGroups_TDVGridView";
            this.SampleGroups_TDVGridView.ReadOnly = true;
            this.SampleGroups_TDVGridView.RowHeadersVisible = false;
            this.SampleGroups_TDVGridView.SelectedItems = null;
            this.SampleGroups_TDVGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SampleGroups_TDVGridView.Size = new System.Drawing.Size(268, 340);
            this.SampleGroups_TDVGridView.TabIndex = 9;
            this.SampleGroups_TDVGridView.VirtualMode = true;
            // 
            // primaryProductDataGridViewTextBoxColumn1
            // 
            this.primaryProductDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.primaryProductDataGridViewTextBoxColumn1.DataPropertyName = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn1.HeaderText = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn1.Name = "primaryProductDataGridViewTextBoxColumn1";
            this.primaryProductDataGridViewTextBoxColumn1.ReadOnly = true;
            this.primaryProductDataGridViewTextBoxColumn1.Width = 103;
            // 
            // speciesDataGridViewTextBoxColumn
            // 
            this.speciesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.speciesDataGridViewTextBoxColumn.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn.HeaderText = "Species";
            this.speciesDataGridViewTextBoxColumn.Name = "speciesDataGridViewTextBoxColumn";
            this.speciesDataGridViewTextBoxColumn.ReadOnly = true;
            this.speciesDataGridViewTextBoxColumn.Width = 70;
            // 
            // liveDeadDataGridViewTextBoxColumn
            // 
            this.liveDeadDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.liveDeadDataGridViewTextBoxColumn.DataPropertyName = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn.HeaderText = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn.Name = "liveDeadDataGridViewTextBoxColumn";
            this.liveDeadDataGridViewTextBoxColumn.ReadOnly = true;
            this.liveDeadDataGridViewTextBoxColumn.Width = 78;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Edit Tree Defaults";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // StrataTabPage
            // 
            this.StrataTabPage.Controls.Add(this.splitContainer1);
            this.StrataTabPage.Location = new System.Drawing.Point(4, 22);
            this.StrataTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.StrataTabPage.Name = "StrataTabPage";
            this.StrataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StrataTabPage.Size = new System.Drawing.Size(817, 402);
            this.StrataTabPage.TabIndex = 1;
            this.StrataTabPage.Text = "Strata";
            this.StrataTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel6);
            this.splitContainer1.Size = new System.Drawing.Size(811, 396);
            this.splitContainer1.SplitterDistance = 583;
            this.splitContainer1.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.StrataDataGridView, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(583, 396);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.EditFieldSetupButton);
            this.panel3.Controls.Add(this.Strata_DeleteButton);
            this.panel3.Controls.Add(this.Strata_AddButton);
            this.panel3.Controls.Add(label7);
            this.panel3.Controls.Add(this.comboBox6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(583, 25);
            this.panel3.TabIndex = 3;
            // 
            // EditFieldSetupButton
            // 
            this.EditFieldSetupButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.EditFieldSetupButton.Location = new System.Drawing.Point(150, 0);
            this.EditFieldSetupButton.Name = "EditFieldSetupButton";
            this.EditFieldSetupButton.Size = new System.Drawing.Size(89, 25);
            this.EditFieldSetupButton.TabIndex = 3;
            this.EditFieldSetupButton.Text = "Edit Field Setup";
            this.EditFieldSetupButton.UseVisualStyleBackColor = true;
            // 
            // Strata_DeleteButton
            // 
            this.Strata_DeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.Strata_DeleteButton.Location = new System.Drawing.Point(75, 0);
            this.Strata_DeleteButton.Name = "Strata_DeleteButton";
            this.Strata_DeleteButton.Size = new System.Drawing.Size(75, 25);
            this.Strata_DeleteButton.TabIndex = 1;
            this.Strata_DeleteButton.Text = "Delete";
            this.Strata_DeleteButton.UseVisualStyleBackColor = true;
            this.Strata_DeleteButton.Click += new System.EventHandler(this.Strata_DeleteButton_Click);
            // 
            // Strata_AddButton
            // 
            this.Strata_AddButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.Strata_AddButton.Location = new System.Drawing.Point(0, 0);
            this.Strata_AddButton.Name = "Strata_AddButton";
            this.Strata_AddButton.Size = new System.Drawing.Size(75, 25);
            this.Strata_AddButton.TabIndex = 0;
            this.Strata_AddButton.Text = "Add";
            this.Strata_AddButton.UseVisualStyleBackColor = true;
            this.Strata_AddButton.Click += new System.EventHandler(this.Strata_AddButton_Click);
            // 
            // comboBox6
            // 
            this.comboBox6.DataSource = this.Strata_CuttingUnitsSelectionBindingSource;
            this.comboBox6.DisplayMember = "Code";
            this.comboBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(465, 0);
            this.comboBox6.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(118, 21);
            this.comboBox6.TabIndex = 2;
            // 
            // StrataDataGridView
            // 
            this.StrataDataGridView.AllowUserToDeleteRows = false;
            this.StrataDataGridView.AutoGenerateColumns = false;
            this.StrataDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StrataDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.StrataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StrataDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.basalAreaFactorDataGridViewTextBoxColumn,
            this.fixedPlotSizeDataGridViewTextBoxColumn,
            this.Method,
            this.monthDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn});
            this.StrataDataGridView.DataSource = this.StrataBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StrataDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.StrataDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StrataDataGridView.Location = new System.Drawing.Point(3, 28);
            this.StrataDataGridView.Name = "StrataDataGridView";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StrataDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.StrataDataGridView.Size = new System.Drawing.Size(577, 365);
            this.StrataDataGridView.TabIndex = 0;
            this.StrataDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_RowEnter);
            this.StrataDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.StrataDataGridView_DataError);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.Width = 57;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 85;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // basalAreaFactorDataGridViewTextBoxColumn
            // 
            this.basalAreaFactorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.basalAreaFactorDataGridViewTextBoxColumn.DataPropertyName = "BasalAreaFactor";
            this.basalAreaFactorDataGridViewTextBoxColumn.HeaderText = "BasalAreaFactor";
            this.basalAreaFactorDataGridViewTextBoxColumn.Name = "basalAreaFactorDataGridViewTextBoxColumn";
            this.basalAreaFactorDataGridViewTextBoxColumn.Width = 110;
            // 
            // fixedPlotSizeDataGridViewTextBoxColumn
            // 
            this.fixedPlotSizeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fixedPlotSizeDataGridViewTextBoxColumn.DataPropertyName = "FixedPlotSize";
            this.fixedPlotSizeDataGridViewTextBoxColumn.HeaderText = "FixedPlotSize";
            this.fixedPlotSizeDataGridViewTextBoxColumn.Name = "fixedPlotSizeDataGridViewTextBoxColumn";
            this.fixedPlotSizeDataGridViewTextBoxColumn.Width = 95;
            // 
            // Method
            // 
            this.Method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Method.DataPropertyName = "Method";
            this.Method.DataSource = this.cruiseMethodBindingSource;
            this.Method.DisplayMember = "FriendlyValue";
            this.Method.DisplayStyleForCurrentCellOnly = true;
            this.Method.HeaderText = "Method";
            this.Method.Name = "Method";
            this.Method.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Method.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Method.ValueMember = "Code";
            this.Method.Width = 68;
            // 
            // monthDataGridViewTextBoxColumn
            // 
            this.monthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.monthDataGridViewTextBoxColumn.DataPropertyName = "Month";
            this.monthDataGridViewTextBoxColumn.HeaderText = "Month";
            this.monthDataGridViewTextBoxColumn.Name = "monthDataGridViewTextBoxColumn";
            this.monthDataGridViewTextBoxColumn.Width = 62;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            this.yearDataGridViewTextBoxColumn.Width = 54;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.Strata_CuttingUnitsGridView, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(224, 396);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cutting Units (Select to add)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Strata_CuttingUnitsGridView
            // 
            this.Strata_CuttingUnitsGridView.AllowUserToAddRows = false;
            this.Strata_CuttingUnitsGridView.AllowUserToDeleteRows = false;
            this.Strata_CuttingUnitsGridView.AutoGenerateColumns = false;
            this.Strata_CuttingUnitsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Strata_CuttingUnitsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn3,
            this.descriptionDataGridViewTextBoxColumn3});
            this.Strata_CuttingUnitsGridView.DataSource = this.Strata_CuttingUnitBindingSource;
            this.Strata_CuttingUnitsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Strata_CuttingUnitsGridView.Location = new System.Drawing.Point(3, 28);
            this.Strata_CuttingUnitsGridView.Name = "Strata_CuttingUnitsGridView";
            this.Strata_CuttingUnitsGridView.RowHeadersVisible = false;
            this.Strata_CuttingUnitsGridView.SelectedItems = null;
            this.Strata_CuttingUnitsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Strata_CuttingUnitsGridView.Size = new System.Drawing.Size(218, 365);
            this.Strata_CuttingUnitsGridView.TabIndex = 7;
            this.Strata_CuttingUnitsGridView.VirtualMode = true;
            // 
            // codeDataGridViewTextBoxColumn3
            // 
            this.codeDataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeDataGridViewTextBoxColumn3.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn3.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn3.Name = "codeDataGridViewTextBoxColumn3";
            this.codeDataGridViewTextBoxColumn3.Width = 57;
            // 
            // descriptionDataGridViewTextBoxColumn3
            // 
            this.descriptionDataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descriptionDataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn3.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn3.Name = "descriptionDataGridViewTextBoxColumn3";
            this.descriptionDataGridViewTextBoxColumn3.Width = 85;
            // 
            // CuttingUnitsTabPage
            // 
            this.CuttingUnitsTabPage.Controls.Add(this.tableLayoutPanel3);
            this.CuttingUnitsTabPage.Location = new System.Drawing.Point(4, 22);
            this.CuttingUnitsTabPage.Name = "CuttingUnitsTabPage";
            this.CuttingUnitsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CuttingUnitsTabPage.Size = new System.Drawing.Size(817, 402);
            this.CuttingUnitsTabPage.TabIndex = 0;
            this.CuttingUnitsTabPage.Text = "Cutting Units";
            this.CuttingUnitsTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.CuttingUnitDataGridView, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(811, 396);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // CuttingUnitDataGridView
            // 
            this.CuttingUnitDataGridView.AllowUserToDeleteRows = false;
            this.CuttingUnitDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CuttingUnitDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CuttingUnitDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CuttingUnitDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn1,
            this.areaDataGridViewTextBoxColumn1,
            this.descriptionDataGridViewTextBoxColumn1,
            this.loggingMethodDataGridViewTextBoxColumn1,
            this.paymentUnitDataGridViewTextBoxColumn1,
            this.StratumCol});
            this.CuttingUnitDataGridView.DataSource = this.CuttingUnitsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CuttingUnitDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.CuttingUnitDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CuttingUnitDataGridView.Location = new System.Drawing.Point(3, 28);
            this.CuttingUnitDataGridView.Name = "CuttingUnitDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CuttingUnitDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CuttingUnitDataGridView.Size = new System.Drawing.Size(805, 365);
            this.CuttingUnitDataGridView.TabIndex = 3;
            this.CuttingUnitDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CuttingUnitDataGridView_RowEnter);
            // 
            // codeDataGridViewTextBoxColumn1
            // 
            this.codeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn1.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
            this.codeDataGridViewTextBoxColumn1.Width = 57;
            // 
            // areaDataGridViewTextBoxColumn1
            // 
            this.areaDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.areaDataGridViewTextBoxColumn1.DataPropertyName = "Area";
            this.areaDataGridViewTextBoxColumn1.HeaderText = "Area";
            this.areaDataGridViewTextBoxColumn1.Name = "areaDataGridViewTextBoxColumn1";
            this.areaDataGridViewTextBoxColumn1.Width = 54;
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn1.MinimumWidth = 85;
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            // 
            // loggingMethodDataGridViewTextBoxColumn1
            // 
            this.loggingMethodDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.loggingMethodDataGridViewTextBoxColumn1.DataPropertyName = "LoggingMethod";
            this.loggingMethodDataGridViewTextBoxColumn1.DataSource = this.LoggingMethodBindingSource;
            this.loggingMethodDataGridViewTextBoxColumn1.DisplayMember = "FriendlyValue";
            this.loggingMethodDataGridViewTextBoxColumn1.DisplayStyleForCurrentCellOnly = true;
            this.loggingMethodDataGridViewTextBoxColumn1.HeaderText = "LoggingMethod";
            this.loggingMethodDataGridViewTextBoxColumn1.Name = "loggingMethodDataGridViewTextBoxColumn1";
            this.loggingMethodDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.loggingMethodDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.loggingMethodDataGridViewTextBoxColumn1.ValueMember = "Code";
            this.loggingMethodDataGridViewTextBoxColumn1.Width = 106;
            // 
            // paymentUnitDataGridViewTextBoxColumn1
            // 
            this.paymentUnitDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.paymentUnitDataGridViewTextBoxColumn1.DataPropertyName = "PaymentUnit";
            this.paymentUnitDataGridViewTextBoxColumn1.HeaderText = "PaymentUnit";
            this.paymentUnitDataGridViewTextBoxColumn1.Name = "paymentUnitDataGridViewTextBoxColumn1";
            this.paymentUnitDataGridViewTextBoxColumn1.Width = 92;
            // 
            // StratumCol
            // 
            this.StratumCol.HeaderText = "";
            this.StratumCol.Name = "StratumCol";
            this.StratumCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StratumCol.Text = "Remap Stratum";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.CuttingUnits_DeleteButton);
            this.panel2.Controls.Add(this.CuttingUnits_AddButton);
            this.panel2.Controls.Add(label4);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(811, 25);
            this.panel2.TabIndex = 2;
            // 
            // CuttingUnits_DeleteButton
            // 
            this.CuttingUnits_DeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CuttingUnits_DeleteButton.Location = new System.Drawing.Point(75, 0);
            this.CuttingUnits_DeleteButton.Name = "CuttingUnits_DeleteButton";
            this.CuttingUnits_DeleteButton.Size = new System.Drawing.Size(75, 25);
            this.CuttingUnits_DeleteButton.TabIndex = 5;
            this.CuttingUnits_DeleteButton.Text = "Delete";
            this.CuttingUnits_DeleteButton.UseVisualStyleBackColor = true;
            this.CuttingUnits_DeleteButton.Click += new System.EventHandler(this.CuttingUnits_DeleteButton_Click);
            // 
            // CuttingUnits_AddButton
            // 
            this.CuttingUnits_AddButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CuttingUnits_AddButton.Location = new System.Drawing.Point(0, 0);
            this.CuttingUnits_AddButton.Name = "CuttingUnits_AddButton";
            this.CuttingUnits_AddButton.Size = new System.Drawing.Size(75, 25);
            this.CuttingUnits_AddButton.TabIndex = 4;
            this.CuttingUnits_AddButton.Text = "Add";
            this.CuttingUnits_AddButton.UseVisualStyleBackColor = true;
            this.CuttingUnits_AddButton.Click += new System.EventHandler(this.CuttingUnits_AddButton_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.CuttingUnits_StrataSelectionBindingSource;
            this.comboBox3.DisplayMember = "Code";
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(690, 0);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 3;
            // 
            // SaleInfoTabPage
            // 
            this.SaleInfoTabPage.Controls.Add(this.flowLayoutPanel1);
            this.SaleInfoTabPage.Location = new System.Drawing.Point(4, 22);
            this.SaleInfoTabPage.Name = "SaleInfoTabPage";
            this.SaleInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SaleInfoTabPage.Size = new System.Drawing.Size(817, 402);
            this.SaleInfoTabPage.TabIndex = 4;
            this.SaleInfoTabPage.Text = "Sale Info";
            this.SaleInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.SaleDistrictTextBox);
            this.flowLayoutPanel1.Controls.Add(this.SaleNumberTextBox);
            this.flowLayoutPanel1.Controls.Add(this.SaleNameTextBox);
            this.flowLayoutPanel1.Controls.Add(panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(811, 396);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.comboBox1);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(10, 10);
            this.panel6.Margin = new System.Windows.Forms.Padding(10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(237, 27);
            this.panel6.TabIndex = 17;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleBindingSource, "Region", true));
            this.comboBox1.DataSource = this.RegionBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(65, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "RegionNumber";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label3.Size = new System.Drawing.Size(41, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Region";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.comboBox2);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Location = new System.Drawing.Point(10, 57);
            this.panel8.Margin = new System.Windows.Forms.Padding(10);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(237, 27);
            this.panel8.TabIndex = 18;
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.SaleBindingSource, "Forest", true));
            this.comboBox2.DataSource = this.forestsBindingSource;
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(65, 6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(172, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.ValueMember = "ForestNumber";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label5.Size = new System.Drawing.Size(36, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Forest";
            // 
            // SaleDistrictTextBox
            // 
            this.SaleDistrictTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaleDistrictTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleBindingSource, "District", true));
            this.SaleDistrictTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaleDistrictTextBox.LabelWidth = 100F;
            this.SaleDistrictTextBox.LableText = "District";
            this.SaleDistrictTextBox.Location = new System.Drawing.Point(10, 104);
            this.SaleDistrictTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.SaleDistrictTextBox.Name = "SaleDistrictTextBox";
            this.SaleDistrictTextBox.Size = new System.Drawing.Size(237, 20);
            this.SaleDistrictTextBox.TabIndex = 2;
            // 
            // 
            // 
            this.SaleDistrictTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaleDistrictTextBox.TextBox.Location = new System.Drawing.Point(100, 0);
            this.SaleDistrictTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SaleDistrictTextBox.TextBox.Name = "textBox1";
            this.SaleDistrictTextBox.TextBox.Size = new System.Drawing.Size(137, 20);
            this.SaleDistrictTextBox.TextBox.TabIndex = 0;
            // 
            // SaleNumberTextBox
            // 
            this.SaleNumberTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaleNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleBindingSource, "SaleNumber", true));
            this.SaleNumberTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaleNumberTextBox.LabelWidth = 100F;
            this.SaleNumberTextBox.LableText = "Sale Number";
            this.SaleNumberTextBox.Location = new System.Drawing.Point(10, 144);
            this.SaleNumberTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.SaleNumberTextBox.Name = "SaleNumberTextBox";
            this.SaleNumberTextBox.Size = new System.Drawing.Size(237, 20);
            this.SaleNumberTextBox.TabIndex = 3;
            // 
            // 
            // 
            this.SaleNumberTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaleNumberTextBox.TextBox.Location = new System.Drawing.Point(100, 0);
            this.SaleNumberTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SaleNumberTextBox.TextBox.Name = "textBox1";
            this.SaleNumberTextBox.TextBox.Size = new System.Drawing.Size(137, 20);
            this.SaleNumberTextBox.TextBox.TabIndex = 0;
            // 
            // SaleNameTextBox
            // 
            this.SaleNameTextBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaleNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SaleBindingSource, "Name", true));
            this.SaleNameTextBox.LabelTextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaleNameTextBox.LabelWidth = 100F;
            this.SaleNameTextBox.LableText = "SaleName";
            this.SaleNameTextBox.Location = new System.Drawing.Point(10, 184);
            this.SaleNameTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.SaleNameTextBox.Name = "SaleNameTextBox";
            this.SaleNameTextBox.Size = new System.Drawing.Size(237, 20);
            this.SaleNameTextBox.TabIndex = 4;
            // 
            // 
            // 
            this.SaleNameTextBox.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaleNameTextBox.TextBox.Location = new System.Drawing.Point(100, 0);
            this.SaleNameTextBox.TextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SaleNameTextBox.TextBox.Name = "textBox1";
            this.SaleNameTextBox.TextBox.Size = new System.Drawing.Size(137, 20);
            this.SaleNameTextBox.TextBox.TabIndex = 0;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.SaleInfoTabPage);
            this.TabControl1.Controls.Add(this.CuttingUnitsTabPage);
            this.TabControl1.Controls.Add(this.StrataTabPage);
            this.TabControl1.Controls.Add(this.SampleGroupTabPage);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(825, 428);
            this.TabControl1.TabIndex = 3;
            // 
            // DesignEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 428);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DesignEditorView";
            this.Text = "DesignEditorView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesignEditorView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(SaleErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleBindingSource)).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnits_StrataSelectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Strata_CuttingUnitsSelectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cruiseMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Strata_CuttingUnitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroups_StrataSelectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroup_TDVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitErrorProvider)).EndInit();
            this.SampleGroupTabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroupDataGridView)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SampleGroups_TDVGridView)).EndInit();
            this.StrataTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StrataDataGridView)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Strata_CuttingUnitsGridView)).EndInit();
            this.CuttingUnitsTabPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CuttingUnitDataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.SaleInfoTabPage.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.BindingSource CuttingUnitsBindingSource;
        public System.Windows.Forms.BindingSource StrataBindingSource;
        public System.Windows.Forms.BindingSource SampleGroupBindingSource;
        public System.Windows.Forms.BindingSource CuttingUnits_StrataSelectionBindingSource;
        public System.Windows.Forms.BindingSource Strata_CuttingUnitsSelectionBindingSource;
        public System.Windows.Forms.BindingSource SampleGroups_StrataSelectionBindingSource;
        private System.Windows.Forms.ErrorProvider CuttingUnitErrorProvider;
        public System.Windows.Forms.BindingSource Strata_CuttingUnitBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        public System.Windows.Forms.BindingSource SampleGroup_TDVBindingSource;
        public System.Windows.Forms.BindingSource SaleBindingSource;
        #endregion

        private BindingSource RegionBindingSource;
        private BindingSource forestsBindingSource;
        private BindingSource cruiseMethodBindingSource;
        private BindingSource LoggingMethodBindingSource;
        private DataGridViewTextBoxColumn sampleStringDataGridViewTextBoxColumn;
        private TabControl TabControl1;
        private TabPage SaleInfoTabPage;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel6;
        private ComboBox comboBox1;
        private Label label3;
        private Panel panel8;
        private ComboBox comboBox2;
        private Label label5;
        public FMSC.Controls.SideLabelTextBox SaleDistrictTextBox;
        public FMSC.Controls.SideLabelTextBox SaleNumberTextBox;
        public FMSC.Controls.SideLabelTextBox SaleNameTextBox;
        public ComboBox SalePurposeComboBox;
        private TabPage CuttingUnitsTabPage;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView CuttingUnitDataGridView;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private DataGridViewComboBoxColumn loggingMethodDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn paymentUnitDataGridViewTextBoxColumn1;
        private DataGridViewButtonColumn StratumCol;
        private Panel panel2;
        private Button CuttingUnits_DeleteButton;
        private Button CuttingUnits_AddButton;
        private ComboBox comboBox3;
        private TabPage StrataTabPage;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel3;
        private Button EditFieldSetupButton;
        private Button Strata_DeleteButton;
        private Button Strata_AddButton;
        private ComboBox comboBox6;
        private DataGridView StrataDataGridView;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn basalAreaFactorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fixedPlotSizeDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn Method;
        private DataGridViewTextBoxColumn monthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label1;
        public FMSC.Controls.SelectedItemsGridView Strata_CuttingUnitsGridView;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn3;
        private TabPage SampleGroupTabPage;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Button SampleGroups_DeleteButton;
        private Button SampleGroups_AddButton;
        private ComboBox comboBox7;
        private DataGridView SampleGroupDataGridView;
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn cutLeaveDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn uOMDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn primaryProductDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn secondaryProductDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn defaultLiveDeadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn samplingFrequencyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn insuranceFrequencyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kZDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tallyHotkeyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn2;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label2;
        private Panel panel7;
        private FMSC.Controls.SelectedItemsGridView SampleGroups_TDVGridView;
        private DataGridViewTextBoxColumn primaryProductDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn liveDeadDataGridViewTextBoxColumn;
        private Button button1;

        private DesignEditorPresentor _presentor;


        public DesignEditorView()
        {
            InitializeComponent();
            
        }

        public DesignEditorView(DesignEditorPresentor Presentor)
            : this()
        {
            this.Presentor = Presentor;

        }

        public DesignEditorPresentor Presentor 
        {
            get { return _presentor; }
            set
            {
                _presentor = value;
                if (value != null)
                {
                    _presentor.View = this;
                }
            }
        }


        //public void SetFileLoadState(bool isLoaded)
        //{
        //    if (isLoaded)
        //    {
        //        saveAsTemplateToolStripMenuItem.Enabled = true;
        //        saveasToolStripMenuItem.Enabled = true;
        //        saveToolStripMenuItem.Enabled = true;
        //        importPartsToolStripMenuItem1.Enabled = true;
        //        if (!TabControl1.TabPages.Contains(SaleInfoTabPage))
        //        { TabControl1.TabPages.Add(SaleInfoTabPage); }
        //        if (!TabControl1.TabPages.Contains(CuttingUnitsTabPage))
        //        { TabControl1.TabPages.Add(CuttingUnitsTabPage); }
        //        if(!TabControl1.TabPages.Contains(StrataTabPage))
        //        { TabControl1.TabPages.Add(StrataTabPage); }
        //        if(!TabControl1.TabPages.Contains(SampleGroupTabPage))
        //        { TabControl1.TabPages.Add(SampleGroupTabPage); }
        //        if (!TabControl1.TabPages.Contains(PlotsTabPage))
        //        { TabControl1.TabPages.Add(PlotsTabPage); }
        //        TabControl1.SelectTab(SaleInfoTabPage);
        //    }
        //    else
        //    {
        //        saveasToolStripMenuItem.Enabled = false;
        //        saveAsTemplateToolStripMenuItem.Enabled = false;
        //        importPartsToolStripMenuItem1.Enabled = false;
        //        saveToolStripMenuItem.Enabled = false;
        //        if (TabControl1.TabPages.Contains(CuttingUnitsTabPage))
        //        { TabControl1.TabPages.Remove(CuttingUnitsTabPage); }
        //        if (TabControl1.TabPages.Contains(SaleInfoTabPage))
        //        { TabControl1.TabPages.Remove(SaleInfoTabPage); }
        //        if (TabControl1.TabPages.Contains(StrataTabPage))
        //        { TabControl1.TabPages.Remove(StrataTabPage); }
        //        if (TabControl1.TabPages.Contains(SampleGroupTabPage))
        //        { TabControl1.TabPages.Remove(SampleGroupTabPage); }
        //        if (TabControl1.TabPages.Contains(PlotsTabPage))
        //        { TabControl1.TabPages.Remove(PlotsTabPage); }
        //    }
        //}


        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = "CSM -" + value;
            }
        }

        public void BindSetup()
        {
            this.SalePurposeComboBox.DataSource = Utility.Constants.SALE_PURPOSE;
            this.RegionBindingSource.DataSource = Presentor.Regions;
            this.cruiseMethodBindingSource.DataSource = Presentor.CruiseMethods;
            this.LoggingMethodBindingSource.DataSource = Presentor.LoggingMethods;

        }

        public void BindData()
        {

            //if (Presentor == null) { return; }
            //SetFileLoadState(Presentor.IsFileLoded);
            this.Text = Presentor.FileName;
            this.SaleBindingSource.DataSource = Presentor.Data.Sale;
            //This.SalePurposeComboBox.DataBindings.Add(new Binding("SelectedItem", Sale, "Purpose"));

            //View.SaleNumberTextBox.DataBindings.Add(new Binding("Text", value, "SaleNumber"));
            //View.SaleNameTextBox.DataBindings.Add(new Binding("Text", value, "Name"));
            //View.SaleRegionTextBox.DataBindings.Add(new Binding("Text", value, "Region"));
            //View.SaleForestTextBox.DataBindings.Add(new Binding("Text", value, "Forest"));
            //View.SaleDistrictTextBox.DataBindings.Add(new Binding("Text", value, "District"));
            //View.SalePurposeComboBox.DataBindings.Add(new Binding("SelectedItem", value, "Purpose"));

            this.SampleGroup_TDVBindingSource.DataSource = Presentor.Data.AllTreeDefaults;
            //This.Strata_CuttingUnitBindingSource.DataSource = AllCuttingUnits;

            this.CuttingUnitsBindingSource.DataSource = Presentor.Data.CuttingUnits;
            this.StrataBindingSource.DataSource = Presentor.Data.Strata;
            this.SampleGroupBindingSource.DataSource = Presentor.Data.SampleGroups;
            this.PlotBindingSource.DataSource = Presentor.Data.Plots;

            this.CuttingUnits_StrataSelectionBindingSource.DataSource = Presentor.Data.StrataFilterSelectionList;
            this.Strata_CuttingUnitsSelectionBindingSource.DataSource = Presentor.Data.CuttingUnitFilterSelectionList;
            this.SampleGroups_StrataSelectionBindingSource.DataSource = Presentor.Data.AllStrata;
            Strata_CuttingUnitBindingSource.DataSource = Presentor.Data.AllCuttingUnits;
            SetFileLoadState(Presentor.IsFileLoded);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = AskSavePath();
            Presentor.CreateNewCruise(path);
        }

        private void CuttingUnits_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = CuttingUnits_StrataSelectionBindingSource.Current as StratumDO;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            Presentor.FilterCutttingUnits(curStratum);
        }

        private void Strata_CuttingUnitsSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curUnit = Strata_CuttingUnitsSelectionBindingSource.Current as CuttingUnitDO;
            if (curUnit == null) { return; }
            if (curUnit.Code == "All") { curUnit = null; }
            Presentor.FilterStrata(curUnit);
        }

        private void SampleGroups_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = SampleGroups_StrataSelectionBindingSource.Current as StratumDO;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            Presentor.SampleGroups_SelectedStrata = curStratum;
        }

        private void Plots_CuttingUnitSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curUnit = Plots_CuttingUnitSelectionBindingSource.Current as CuttingUnitDO;
            if (curUnit == null) { return; }
            if (curUnit.Code == "All") { curUnit = null; }
            Presentor.Plots_SelectedCuttingUnit = curUnit;
        }

        private void Plots_StrataSelectionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var curStratum = Plots_StrataSelectionBindingSource.Current as StratumDO;
            if (curStratum == null) { return; }
            if (curStratum.Code == "All") { curStratum = null; }
            Presentor.Plots_SelectedStratum = curStratum;
        }

        private void CuttingUnits_AddButton_Click(object sender, EventArgs e)
        {
            Presentor.AddCuttingUnit();
        }

        private void CuttingUnits_DeleteButton_Click(object sender, EventArgs e)
        {
            var curCuttingUnit = CuttingUnitsBindingSource.Current as CuttingUnitDO;
            if (curCuttingUnit == null) { return; }
            Presentor.DeleteCuttingUnit(curCuttingUnit);
        }

        private void Strata_AddButton_Click(object sender, EventArgs e)
        {
            Presentor.AddStratum();
        }

        private void SampleGroups_DeleteButton_Click(object sender, EventArgs e)
        {
            var curSG = SampleGroupBindingSource.Current as SampleGroupDO;
            Presentor.DeleteSampleGroup(curSG);
        }

        private void Strata_DeleteButton_Click(object sender, EventArgs e)
        {
            var curST = StrataBindingSource.Current as StratumDO; 
            if ( curST == null) { return; }
            Presentor.DeleteStratum(curST);
        }

        private void SampleGroups_AddButton_Click(object sender, EventArgs e)
        {
            if (Presentor.SampleGroups_SelectedStrata == null)
            {
                MessageBox.Show("Please Select a Stratum");
            }
            else
            {
                Presentor.AddSampleGroup();
            }
        }

        private void CuttingUnitsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = Presentor.GetNewCuttingUnit();
        }

        private void StrataBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = Presentor.GetNewStratum();
        }

        private void SampleGroupBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = Presentor.GetNewSampleGroup();
        }

        private void CuttingUnitDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CuttingUnitDataGridView.Rows[e.RowIndex].ReadOnly = 
                !Presentor.CanEditCuttingUnit(CuttingUnitsBindingSource[e.RowIndex] as CuttingUnitDO);
        }



        private void dataGridView4_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            StrataDataGridView.Rows[e.RowIndex].ReadOnly =
                !Presentor.CanEditStratum(StrataBindingSource[e.RowIndex] as StratumDO);
        }



        private void SampleGroupDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SampleGroupDataGridView.Rows[e.RowIndex].ReadOnly =
                !Presentor.CanEditSampleGroup(SampleGroupBindingSource[e.RowIndex] as SampleGroupDO);
            
        }

        private void DesignEditorView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Presentor.HasUnsavedChanges)
            {
                var result = MessageBox.Show(this, "You Have Unsaved Data, Would You Like To Save Before Closing?", "Warning", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            Presentor.SaveData();
                            return;
                        }
                    case DialogResult.No:
                        {
                            return;
                        }
                    case DialogResult.Cancel:
                        {
                            e.Cancel = true;
                            return;
                        }
                }
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForceEndEdits();
            Presentor.SaveData();
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForceEndEdits();
            var path = AskSavePath();
            Presentor.SaveDataAs(path);
        }

        public String AskSavePath()
        {
            var saveFileDialog = new System.Windows.Forms.SaveFileDialog();

            saveFileDialog.DefaultExt = "cruise";
            saveFileDialog.Filter = "Cruise files(*.cruise)|*.cruise";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            return null;
        }

        public void ForceEndEdits()
        {
            //this is a bit of a hack
            //force focus away from any control that has focus, 
            //causing any control that has edited data to commit its data
            this.Select(true, true);
        }
        private void SampleGroupBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var sampleGroup = SampleGroupBindingSource.Current as SampleGroupDO;
            if (sampleGroup == null) { return; }
            if (sampleGroup.TreeDefaultValues.IsPopulated == false)
            {
                sampleGroup.TreeDefaultValues.Populate();
            }
            SampleGroups_TDVGridView.SelectedItems = sampleGroup.TreeDefaultValues;
        }

        private void StrataBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            OnSelectedStrataChanged();
        }

        private void OnSelectedStrataChanged()
        {
            var stratum = StrataBindingSource.Current as StratumDO;
            //make sure the currently selected stratum is not null
            if( stratum == null) { return; }
            //get the selection of cutting units in the stratum 
            if (stratum.CuttingUnits.IsPopulated == false)
            {
                stratum.CuttingUnits.Populate();
            }
            //display the cutting units in the stratum
            Strata_CuttingUnitsGridView.SelectedItems = (IList)stratum.CuttingUnits;
        }





        private void importPartsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Cruise files (*.cruise)|*.cruise";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (this.Presentor.WindowPresenter.ShowImportParts(dialog.FileName) == DialogResult.OK)
                {
                    this.Presentor.LoadCruiseData();
                    BindData();
                }
            }
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentor.WindowPresenter.ShowOpenCruiseDialog();
            BindData();
            
        }

        private void ViewTreeDefaultMenuRow_ButtonClick(object sender, EventArgs e)
        {
            Presentor.WindowPresenter.ShowTreeDefaultViewDialog();
        }

        private void ViewSetupMenuRow_ButtonClick(object sender, EventArgs e)
        {
            Presentor.WindowPresenter.ShowSetupEditorDialog();
        }

        private void ConvertCruiseMenuRow_ButtonClick(object sender, EventArgs e)
        {
            Presentor.WindowPresenter.ShowConvertCruiseFileViewDialog();
        }

        private void CreateNewCruiseMenuRow_ButtonClick(object sender, EventArgs e)
        {
            Presentor.WindowPresenter.ShowCruiseWizardDiolog();
            BindData();

        }

        private void cruiseDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentor.WindowPresenter.ShowDataEditor();
        }

        private void saveAsTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.InitialDirectory = ApplicationState.GetTemplateFolder().FullName;
            saveFileDialog.DefaultExt = "CZT";
            saveFileDialog.Filter = "Cruise template(*.cut)|*.cut";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Presentor.SaveAsTemplate(saveFileDialog.FileName);
            }
            
        }

        private void StrataDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var something = e;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentor.WindowPresenter.Shutdown();
        }

        //private DataGridViewCellStyle _readOnlyStyle = new DataGridViewCellStyle
        //{
        //    BackColor = Color.Gray
        //};
        //private void CuttingUnitDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    if (e.RowIndex >= CuttingUnitDataGridView.RowCount) { return; }
        //    if (!Presentor.CanEditCuttingUnit(CuttingUnitsBindingSource[e.RowIndex] as CuttingUnitDO))
        //    {
        //        CuttingUnitDataGridView.Rows[e.RowIndex].DefaultCellStyle = _readOnlyStyle;
        //    }
        //    else
        //    {
        //        var row = CuttingUnitDataGridView.Rows[e.RowIndex];
        //        row.DefaultCellStyle = row.InheritedStyle;
        //    }
            
        //}

 


    }
}
