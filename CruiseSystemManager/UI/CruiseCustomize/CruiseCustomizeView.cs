using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using System.Collections;

namespace CSM.UI.CruiseCustomize
{
    public partial class CruiseCustomizeView : UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TabPage _logMatrixTabPage;

        #region controls
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _fieldSetupPage;
        private System.Windows.Forms.TabPage _tallySetupPage;
        private System.Windows.Forms.TabPage _treeAuditTabPage;
        private System.Windows.Forms.DataGridView _treeAuditDGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox _treeAuditErrorTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox _treeAuditValueSetTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _treeAuditMaxTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _treeAuditMinTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox _treeAuditFieldList;
        private System.Windows.Forms.DataGridView _treeAuditTDVSelectDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryProductDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn liveDeadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIAcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cullPrimaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenPrimaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cullSecondaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenSecondaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recoverableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractSpeciesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treeGradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn merchHeightLogLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn merchHeightTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barkThicknessRatioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceHeightPercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl _fieldSetup_Child_TabControl;
        private System.Windows.Forms.TabPage _treeField_TabPage;
        private FMSC.Controls.OrderableAddRemoveWidget _treeFieldWidget;
        private System.Windows.Forms.TabPage _logField_TabPage;
        private FMSC.Controls.OrderableAddRemoveWidget _logFieldWidget;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox _strataLB;
        private System.Windows.Forms.BindingSource _BS_treeDefaults;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource _BS_treeAudits;
        private FMSC.Controls.SelectedItemsGridView _tdvDGV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox _TreeFieldHeadingTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource _BS_TreeField;
        private System.Windows.Forms.BindingSource _BS_LogField;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox _logFieldHeadingTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _treeFieldWidthTB;
        private System.Windows.Forms.TextBox _logFieldWidthTB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryProductDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn liveDeadDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeableDataGridViewTextBoxColumn1;
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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button _treeAuditClearSelectionBtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button _tavDeleteBTN;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel _tallyNavPanel;
        private System.Windows.Forms.CheckBox _systematicOptCB;
        private System.Windows.Forms.ComboBox _stratumHKCB;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox _sampleGroupCB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _strataCB;
        private TallyEditPanel _tallyEditPanel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button _auditRulesHelp_BTN;
        private System.Windows.Forms.ToolTip toolTip1;
        #endregion


        private StratumCustomizeViewModel _currentTallySetupStratum;
        private SampleGroupViewModel _currentSG;
        private DataGridViewComboBoxColumn fieldDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn minDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn maxDataGridViewTextBoxColumn;

        private LogMatrixSettingsView _logMatrixPage;

        public CustomizeCruisePresenter Presenter { get; set; }
        //protected StratumDO FieldSetup_CurrentStratum { get; set; }

        public CruiseCustomizeView(CustomizeCruisePresenter presenter)
        {
            this.Presenter = presenter;
            Presenter.View = this;

            InitializeComponent();



            if (this.Presenter.Controller.AppState.InSupervisorMode)
            {
                this._logMatrixPage = new LogMatrixSettingsView(this.Presenter);
                this._logMatrixPage.SuspendLayout();
                this._logMatrixPage.Dock = DockStyle.Fill;

                this._logMatrixTabPage = new System.Windows.Forms.TabPage();
                this._logMatrixTabPage.SuspendLayout();


                // 
                // _logMatrixTabPage
                // 
                this._logMatrixTabPage.Controls.Add(this._logMatrixPage);
                this._logMatrixTabPage.Location = new System.Drawing.Point(4, 22);
                this._logMatrixTabPage.Name = "_logMatrixTabPage";
                this._logMatrixTabPage.Padding = new System.Windows.Forms.Padding(3);
                this._logMatrixTabPage.Size = new System.Drawing.Size(632, 391);
                this._logMatrixTabPage.TabIndex = 7;
                this._logMatrixTabPage.Text = "Log Matrix";
                this._logMatrixTabPage.UseVisualStyleBackColor = true;

                this._logMatrixTabPage.ResumeLayout(false);
                this._logMatrixPage.ResumeLayout(false);

                this._tabControl.Controls.Add(this._logMatrixTabPage);
            }
        

            ////put all the grade checkBoxes in to a nice array
            ////, so we can access them with a indexer
            //this.grades = new CheckBox[10];
            //this.grades[0] = this.grade0;
            //this.grades[1] = this.grade1;
            //this.grades[2] = this.grade2;
            //this.grades[3] = this.grade3;
            //this.grades[4] = this.grade4;
            //this.grades[5] = this.grade5;
            //this.grades[6] = this.grade6;
            //this.grades[7] = this.grade7;
            //this.grades[8] = this.grade8;
            //this.grades[9] = this.grade9;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TableLayoutPanel _treeAuditRulesLayout;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CruiseCustomizeView));
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label20;
            this._tdvDGV = new FMSC.Controls.SelectedItemsGridView();
            this.speciesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryProductDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveDeadDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeableDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this._BS_treeAudits = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this._treeAuditClearSelectionBtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this._auditRulesHelp_BTN = new System.Windows.Forms.Button();
            this._tavDeleteBTN = new System.Windows.Forms.Button();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._fieldSetupPage = new System.Windows.Forms.TabPage();
            this._fieldSetup_Child_TabControl = new System.Windows.Forms.TabControl();
            this._treeField_TabPage = new System.Windows.Forms.TabPage();
            this._treeFieldWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this.panel3 = new System.Windows.Forms.Panel();
            this._treeFieldWidthTB = new System.Windows.Forms.TextBox();
            this._BS_TreeField = new System.Windows.Forms.BindingSource(this.components);
            this._TreeFieldHeadingTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._logField_TabPage = new System.Windows.Forms.TabPage();
            this._logFieldWidget = new FMSC.Controls.OrderableAddRemoveWidget();
            this.panel4 = new System.Windows.Forms.Panel();
            this._logFieldWidthTB = new System.Windows.Forms.TextBox();
            this._BS_LogField = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this._logFieldHeadingTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._strataLB = new System.Windows.Forms.ListBox();
            this._tallySetupPage = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._tallyNavPanel = new System.Windows.Forms.Panel();
            this._systematicOptCB = new System.Windows.Forms.CheckBox();
            this._stratumHKCB = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this._sampleGroupCB = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._strataCB = new System.Windows.Forms.ComboBox();
            this._tallyEditPanel = new CSM.UI.CruiseCustomize.TallyEditPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this._treeAuditTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this._treeAuditErrorTB = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._treeAuditValueSetTB = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._treeAuditMaxTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._treeAuditMinTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._treeAuditFieldList = new System.Windows.Forms.ListBox();
            this._treeAuditTDVSelectDGV = new System.Windows.Forms.DataGridView();
            this.primaryProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveDeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fIAcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cullPrimaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenPrimaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cullSecondaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenSecondaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recoverableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractSpeciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeGradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.merchHeightLogLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.merchHeightTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barkThicknessRatioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averageZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceHeightPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.minDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            _treeAuditRulesLayout = new System.Windows.Forms.TableLayoutPanel();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            _treeAuditRulesLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tdvDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeDefaults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._treeAuditDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeAudits)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._fieldSetupPage.SuspendLayout();
            this._fieldSetup_Child_TabControl.SuspendLayout();
            this._treeField_TabPage.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeField)).BeginInit();
            this._logField_TabPage.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogField)).BeginInit();
            this.groupBox3.SuspendLayout();
            this._tallySetupPage.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this._tallyNavPanel.SuspendLayout();
            this._treeAuditTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._treeAuditTDVSelectDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // _treeAuditRulesLayout
            // 
            _treeAuditRulesLayout.BackColor = System.Drawing.Color.Transparent;
            _treeAuditRulesLayout.ColumnCount = 1;
            _treeAuditRulesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            _treeAuditRulesLayout.Controls.Add(this._tdvDGV, 0, 3);
            _treeAuditRulesLayout.Controls.Add(this._treeAuditDGV, 0, 1);
            _treeAuditRulesLayout.Controls.Add(this.panel5, 0, 2);
            _treeAuditRulesLayout.Controls.Add(this.panel6, 0, 0);
            _treeAuditRulesLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            _treeAuditRulesLayout.Location = new System.Drawing.Point(0, 0);
            _treeAuditRulesLayout.Margin = new System.Windows.Forms.Padding(0);
            _treeAuditRulesLayout.Name = "_treeAuditRulesLayout";
            _treeAuditRulesLayout.RowCount = 4;
            _treeAuditRulesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _treeAuditRulesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            _treeAuditRulesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            _treeAuditRulesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            _treeAuditRulesLayout.Size = new System.Drawing.Size(632, 391);
            _treeAuditRulesLayout.TabIndex = 2;
            // 
            // _tdvDGV
            // 
            this._tdvDGV.AllowUserToAddRows = false;
            this._tdvDGV.AllowUserToResizeRows = false;
            this._tdvDGV.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._tdvDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._tdvDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._tdvDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.speciesDataGridViewTextBoxColumn1,
            this.primaryProductDataGridViewTextBoxColumn1,
            this.liveDeadDataGridViewTextBoxColumn1,
            this.chargeableDataGridViewTextBoxColumn1,
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
            this._tdvDGV.DataSource = this._BS_treeDefaults;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._tdvDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this._tdvDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tdvDGV.Location = new System.Drawing.Point(0, 236);
            this._tdvDGV.Margin = new System.Windows.Forms.Padding(0);
            this._tdvDGV.Name = "_tdvDGV";
            this._tdvDGV.RowHeadersVisible = false;
            this._tdvDGV.RowTemplate.Height = 24;
            this._tdvDGV.SelectedItems = null;
            this._tdvDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._tdvDGV.Size = new System.Drawing.Size(632, 157);
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
            this.primaryProductDataGridViewTextBoxColumn1.Width = 61;
            // 
            // liveDeadDataGridViewTextBoxColumn1
            // 
            this.liveDeadDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.liveDeadDataGridViewTextBoxColumn1.DataPropertyName = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn1.HeaderText = "L/D";
            this.liveDeadDataGridViewTextBoxColumn1.Name = "liveDeadDataGridViewTextBoxColumn1";
            this.liveDeadDataGridViewTextBoxColumn1.ToolTipText = "Default Live/Dead Code";
            this.liveDeadDataGridViewTextBoxColumn1.Width = 51;
            // 
            // chargeableDataGridViewTextBoxColumn1
            // 
            this.chargeableDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.chargeableDataGridViewTextBoxColumn1.DataPropertyName = "Chargeable";
            this.chargeableDataGridViewTextBoxColumn1.HeaderText = "Chargeable";
            this.chargeableDataGridViewTextBoxColumn1.Name = "chargeableDataGridViewTextBoxColumn1";
            this.chargeableDataGridViewTextBoxColumn1.ToolTipText = "Yield Component (CL,CD,NL,ND)";
            this.chargeableDataGridViewTextBoxColumn1.Width = 86;
            // 
            // fIAcodeDataGridViewTextBoxColumn1
            // 
            this.fIAcodeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.fIAcodeDataGridViewTextBoxColumn1.DataPropertyName = "FIAcode";
            this.fIAcodeDataGridViewTextBoxColumn1.HeaderText = "FIAcode";
            this.fIAcodeDataGridViewTextBoxColumn1.Name = "fIAcodeDataGridViewTextBoxColumn1";
            this.fIAcodeDataGridViewTextBoxColumn1.ToolTipText = "Three Digit FIA Species Code";
            this.fIAcodeDataGridViewTextBoxColumn1.Width = 72;
            // 
            // cullPrimaryDataGridViewTextBoxColumn1
            // 
            this.cullPrimaryDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cullPrimaryDataGridViewTextBoxColumn1.DataPropertyName = "CullPrimary";
            this.cullPrimaryDataGridViewTextBoxColumn1.HeaderText = "CullP";
            this.cullPrimaryDataGridViewTextBoxColumn1.Name = "cullPrimaryDataGridViewTextBoxColumn1";
            this.cullPrimaryDataGridViewTextBoxColumn1.ToolTipText = "Cull Defect Primary Product";
            this.cullPrimaryDataGridViewTextBoxColumn1.Width = 56;
            // 
            // hiddenPrimaryDataGridViewTextBoxColumn1
            // 
            this.hiddenPrimaryDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.hiddenPrimaryDataGridViewTextBoxColumn1.DataPropertyName = "HiddenPrimary";
            this.hiddenPrimaryDataGridViewTextBoxColumn1.HeaderText = "HiddenP";
            this.hiddenPrimaryDataGridViewTextBoxColumn1.Name = "hiddenPrimaryDataGridViewTextBoxColumn1";
            this.hiddenPrimaryDataGridViewTextBoxColumn1.ToolTipText = "Hidden Defect Primary Product";
            this.hiddenPrimaryDataGridViewTextBoxColumn1.Width = 73;
            // 
            // cullSecondaryDataGridViewTextBoxColumn1
            // 
            this.cullSecondaryDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cullSecondaryDataGridViewTextBoxColumn1.DataPropertyName = "CullSecondary";
            this.cullSecondaryDataGridViewTextBoxColumn1.HeaderText = "CullS";
            this.cullSecondaryDataGridViewTextBoxColumn1.Name = "cullSecondaryDataGridViewTextBoxColumn1";
            this.cullSecondaryDataGridViewTextBoxColumn1.ToolTipText = "Cull Defect Secondary Product";
            this.cullSecondaryDataGridViewTextBoxColumn1.Width = 56;
            // 
            // hiddenSecondaryDataGridViewTextBoxColumn1
            // 
            this.hiddenSecondaryDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.hiddenSecondaryDataGridViewTextBoxColumn1.DataPropertyName = "HiddenSecondary";
            this.hiddenSecondaryDataGridViewTextBoxColumn1.HeaderText = "HiddenS";
            this.hiddenSecondaryDataGridViewTextBoxColumn1.Name = "hiddenSecondaryDataGridViewTextBoxColumn1";
            this.hiddenSecondaryDataGridViewTextBoxColumn1.ToolTipText = "Hidden Defect Secondary Product";
            this.hiddenSecondaryDataGridViewTextBoxColumn1.Width = 73;
            // 
            // recoverableDataGridViewTextBoxColumn1
            // 
            this.recoverableDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.recoverableDataGridViewTextBoxColumn1.DataPropertyName = "Recoverable";
            this.recoverableDataGridViewTextBoxColumn1.HeaderText = "% Rec";
            this.recoverableDataGridViewTextBoxColumn1.Name = "recoverableDataGridViewTextBoxColumn1";
            this.recoverableDataGridViewTextBoxColumn1.ToolTipText = "Percent Recoverable Product";
            this.recoverableDataGridViewTextBoxColumn1.Width = 63;
            // 
            // contractSpeciesDataGridViewTextBoxColumn1
            // 
            this.contractSpeciesDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.contractSpeciesDataGridViewTextBoxColumn1.DataPropertyName = "ContractSpecies";
            this.contractSpeciesDataGridViewTextBoxColumn1.HeaderText = "ContractSp";
            this.contractSpeciesDataGridViewTextBoxColumn1.Name = "contractSpeciesDataGridViewTextBoxColumn1";
            this.contractSpeciesDataGridViewTextBoxColumn1.ToolTipText = "Contract Species Code";
            this.contractSpeciesDataGridViewTextBoxColumn1.Width = 85;
            // 
            // treeGradeDataGridViewTextBoxColumn1
            // 
            this.treeGradeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.treeGradeDataGridViewTextBoxColumn1.DataPropertyName = "TreeGrade";
            this.treeGradeDataGridViewTextBoxColumn1.HeaderText = "Grade";
            this.treeGradeDataGridViewTextBoxColumn1.Name = "treeGradeDataGridViewTextBoxColumn1";
            this.treeGradeDataGridViewTextBoxColumn1.ToolTipText = "Default Tree Grade";
            this.treeGradeDataGridViewTextBoxColumn1.Width = 61;
            // 
            // merchHeightLogLengthDataGridViewTextBoxColumn1
            // 
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.DataPropertyName = "MerchHeightLogLength";
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.HeaderText = "MerchHtLL";
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.Name = "merchHeightLogLengthDataGridViewTextBoxColumn1";
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.ToolTipText = "Merchantable Height Log Length (8,16,32)";
            this.merchHeightLogLengthDataGridViewTextBoxColumn1.Width = 85;
            // 
            // merchHeightTypeDataGridViewTextBoxColumn1
            // 
            this.merchHeightTypeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.merchHeightTypeDataGridViewTextBoxColumn1.DataPropertyName = "MerchHeightType";
            this.merchHeightTypeDataGridViewTextBoxColumn1.HeaderText = "MerchHtType";
            this.merchHeightTypeDataGridViewTextBoxColumn1.Name = "merchHeightTypeDataGridViewTextBoxColumn1";
            this.merchHeightTypeDataGridViewTextBoxColumn1.ToolTipText = "Merchantable Height Type (L,F)";
            this.merchHeightTypeDataGridViewTextBoxColumn1.Width = 97;
            // 
            // formClassDataGridViewTextBoxColumn1
            // 
            this.formClassDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.formClassDataGridViewTextBoxColumn1.DataPropertyName = "FormClass";
            this.formClassDataGridViewTextBoxColumn1.HeaderText = "FClass";
            this.formClassDataGridViewTextBoxColumn1.Name = "formClassDataGridViewTextBoxColumn1";
            this.formClassDataGridViewTextBoxColumn1.ToolTipText = "Default Form Class";
            this.formClassDataGridViewTextBoxColumn1.Width = 63;
            // 
            // barkThicknessRatioDataGridViewTextBoxColumn1
            // 
            this.barkThicknessRatioDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.barkThicknessRatioDataGridViewTextBoxColumn1.DataPropertyName = "BarkThicknessRatio";
            this.barkThicknessRatioDataGridViewTextBoxColumn1.HeaderText = "BTR";
            this.barkThicknessRatioDataGridViewTextBoxColumn1.Name = "barkThicknessRatioDataGridViewTextBoxColumn1";
            this.barkThicknessRatioDataGridViewTextBoxColumn1.ToolTipText = "Bark Thickness Ratio";
            this.barkThicknessRatioDataGridViewTextBoxColumn1.Width = 54;
            // 
            // averageZDataGridViewTextBoxColumn1
            // 
            this.averageZDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.averageZDataGridViewTextBoxColumn1.DataPropertyName = "AverageZ";
            this.averageZDataGridViewTextBoxColumn1.HeaderText = "AvgZ";
            this.averageZDataGridViewTextBoxColumn1.Name = "averageZDataGridViewTextBoxColumn1";
            this.averageZDataGridViewTextBoxColumn1.ToolTipText = "Average Z-Score";
            this.averageZDataGridViewTextBoxColumn1.Width = 58;
            // 
            // referenceHeightPercentDataGridViewTextBoxColumn1
            // 
            this.referenceHeightPercentDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.referenceHeightPercentDataGridViewTextBoxColumn1.DataPropertyName = "ReferenceHeightPercent";
            this.referenceHeightPercentDataGridViewTextBoxColumn1.HeaderText = "RefHtPer";
            this.referenceHeightPercentDataGridViewTextBoxColumn1.Name = "referenceHeightPercentDataGridViewTextBoxColumn1";
            this.referenceHeightPercentDataGridViewTextBoxColumn1.ToolTipText = "Reference Height Percent";
            this.referenceHeightPercentDataGridViewTextBoxColumn1.Width = 76;
            // 
            // _BS_treeDefaults
            // 
            this._BS_treeDefaults.DataSource = typeof(CruiseDAL.DataObjects.TreeDefaultValueDO);
            // 
            // _treeAuditDGV
            // 
            this._treeAuditDGV.AllowUserToResizeRows = false;
            this._treeAuditDGV.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._treeAuditDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._treeAuditDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._treeAuditDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldDataGridViewTextBoxColumn,
            this.minDataGridViewTextBoxColumn,
            this.maxDataGridViewTextBoxColumn});
            this._treeAuditDGV.DataSource = this._BS_treeAudits;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._treeAuditDGV.DefaultCellStyle = dataGridViewCellStyle4;
            this._treeAuditDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeAuditDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this._treeAuditDGV.Location = new System.Drawing.Point(0, 20);
            this._treeAuditDGV.Margin = new System.Windows.Forms.Padding(0);
            this._treeAuditDGV.Name = "_treeAuditDGV";
            this._treeAuditDGV.RowHeadersVisible = false;
            this._treeAuditDGV.RowTemplate.Height = 24;
            this._treeAuditDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._treeAuditDGV.Size = new System.Drawing.Size(632, 196);
            this._treeAuditDGV.TabIndex = 0;
            this._treeAuditDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this._treeAuditDGV_DataError);
            // 
            // _BS_treeAudits
            // 
            this._BS_treeAudits.DataSource = typeof(CruiseDAL.DataObjects.TreeAuditValueDO);
            this._BS_treeAudits.CurrentItemChanged += new System.EventHandler(this._BS_treeAudits_CurrentItemChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.Controls.Add(this._treeAuditClearSelectionBtn);
            this.panel5.Controls.Add(label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 216);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(632, 20);
            this.panel5.TabIndex = 3;
            // 
            // _treeAuditClearSelectionBtn
            // 
            this._treeAuditClearSelectionBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this._treeAuditClearSelectionBtn.Location = new System.Drawing.Point(545, 0);
            this._treeAuditClearSelectionBtn.Name = "_treeAuditClearSelectionBtn";
            this._treeAuditClearSelectionBtn.Size = new System.Drawing.Size(87, 20);
            this._treeAuditClearSelectionBtn.TabIndex = 5;
            this._treeAuditClearSelectionBtn.Text = "Clear Selection";
            this._treeAuditClearSelectionBtn.UseVisualStyleBackColor = true;
            this._treeAuditClearSelectionBtn.Click += new System.EventHandler(this._treeAuditClearSelectionBtn_Click);
            // 
            // label8
            // 
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Dock = System.Windows.Forms.DockStyle.Left;
            label8.Location = new System.Drawing.Point(0, 0);
            label8.Margin = new System.Windows.Forms.Padding(0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(194, 20);
            label8.TabIndex = 4;
            label8.Text = "Tree Defaults (select to apply audit rule)";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel6.Controls.Add(label7);
            this.panel6.Controls.Add(this._auditRulesHelp_BTN);
            this.panel6.Controls.Add(this._tavDeleteBTN);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(632, 20);
            this.panel6.TabIndex = 4;
            // 
            // label7
            // 
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Dock = System.Windows.Forms.DockStyle.Left;
            label7.Location = new System.Drawing.Point(21, 0);
            label7.Margin = new System.Windows.Forms.Padding(0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(64, 20);
            label7.TabIndex = 3;
            label7.Text = "Audit Rules ";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _auditRulesHelp_BTN
            // 
            this._auditRulesHelp_BTN.BackColor = System.Drawing.Color.Transparent;
            this._auditRulesHelp_BTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_auditRulesHelp_BTN.BackgroundImage")));
            this._auditRulesHelp_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._auditRulesHelp_BTN.Dock = System.Windows.Forms.DockStyle.Left;
            this._auditRulesHelp_BTN.FlatAppearance.BorderSize = 0;
            this._auditRulesHelp_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._auditRulesHelp_BTN.ForeColor = System.Drawing.Color.Transparent;
            this._auditRulesHelp_BTN.Location = new System.Drawing.Point(0, 0);
            this._auditRulesHelp_BTN.Margin = new System.Windows.Forms.Padding(0);
            this._auditRulesHelp_BTN.Name = "_auditRulesHelp_BTN";
            this._auditRulesHelp_BTN.Size = new System.Drawing.Size(21, 20);
            this._auditRulesHelp_BTN.TabIndex = 5;
            this._auditRulesHelp_BTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this._auditRulesHelp_BTN, resources.GetString("_auditRulesHelp_BTN.ToolTip"));
            this._auditRulesHelp_BTN.UseVisualStyleBackColor = false;
            // 
            // _tavDeleteBTN
            // 
            this._tavDeleteBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this._tavDeleteBTN.Location = new System.Drawing.Point(557, 0);
            this._tavDeleteBTN.Name = "_tavDeleteBTN";
            this._tavDeleteBTN.Size = new System.Drawing.Size(75, 20);
            this._tavDeleteBTN.TabIndex = 4;
            this._tavDeleteBTN.Text = "Delete";
            this._tavDeleteBTN.UseVisualStyleBackColor = true;
            this._tavDeleteBTN.Click += new System.EventHandler(this._tavDeleteBTN_Click);
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(134, 7);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(106, 13);
            label13.TabIndex = 2;
            label13.Text = "Width (in Characters)";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(240, 27);
            label20.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(84, 13);
            label20.TabIndex = 4;
            label20.Text = "(0 = Auto Width)";
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._fieldSetupPage);
            this._tabControl.Controls.Add(this._tallySetupPage);
            this._tabControl.Controls.Add(this._treeAuditTabPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(640, 417);
            this._tabControl.TabIndex = 0;
            // 
            // _fieldSetupPage
            // 
            this._fieldSetupPage.Controls.Add(this._fieldSetup_Child_TabControl);
            this._fieldSetupPage.Controls.Add(this.groupBox3);
            this._fieldSetupPage.Location = new System.Drawing.Point(4, 22);
            this._fieldSetupPage.Name = "_fieldSetupPage";
            this._fieldSetupPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this._fieldSetupPage.Size = new System.Drawing.Size(632, 391);
            this._fieldSetupPage.TabIndex = 0;
            this._fieldSetupPage.Text = "Field Setup";
            this._fieldSetupPage.UseVisualStyleBackColor = true;
            // 
            // _fieldSetup_Child_TabControl
            // 
            this._fieldSetup_Child_TabControl.Controls.Add(this._treeField_TabPage);
            this._fieldSetup_Child_TabControl.Controls.Add(this._logField_TabPage);
            this._fieldSetup_Child_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._fieldSetup_Child_TabControl.Location = new System.Drawing.Point(137, 3);
            this._fieldSetup_Child_TabControl.Margin = new System.Windows.Forms.Padding(0);
            this._fieldSetup_Child_TabControl.Name = "_fieldSetup_Child_TabControl";
            this._fieldSetup_Child_TabControl.Padding = new System.Drawing.Point(0, 0);
            this._fieldSetup_Child_TabControl.SelectedIndex = 0;
            this._fieldSetup_Child_TabControl.Size = new System.Drawing.Size(492, 385);
            this._fieldSetup_Child_TabControl.TabIndex = 2;
            // 
            // _treeField_TabPage
            // 
            this._treeField_TabPage.Controls.Add(this._treeFieldWidget);
            this._treeField_TabPage.Controls.Add(this.panel3);
            this._treeField_TabPage.Location = new System.Drawing.Point(4, 22);
            this._treeField_TabPage.Name = "_treeField_TabPage";
            this._treeField_TabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this._treeField_TabPage.Size = new System.Drawing.Size(484, 359);
            this._treeField_TabPage.TabIndex = 0;
            this._treeField_TabPage.Text = "Tree Field Setup";
            this._treeField_TabPage.UseVisualStyleBackColor = true;
            // 
            // _treeFieldWidget
            // 
            this._treeFieldWidget.DisplayMember = "Field";
            this._treeFieldWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeFieldWidget.Location = new System.Drawing.Point(3, 3);
            this._treeFieldWidget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._treeFieldWidget.MinimumSize = new System.Drawing.Size(0, 183);
            this._treeFieldWidget.Name = "_treeFieldWidget";
            this._treeFieldWidget.SelectedItemsDataSource = null;
            this._treeFieldWidget.SelectedValue = null;
            this._treeFieldWidget.Size = new System.Drawing.Size(478, 304);
            this._treeFieldWidget.TabIndex = 0;
            this._treeFieldWidget.ValueMember = null;
            this._treeFieldWidget.SelectedValueChanged += new FMSC.Controls.SelectedValueChangedEventHandler(this._treeFieldWidget_SelectedValueChanged);
            this._treeFieldWidget.SelectionAdded += new FMSC.Controls.SelectionAddedEventHandler(this._treeFieldWidget_SelectionAdded);
            this._treeFieldWidget.SelectionMoved += new FMSC.Controls.ItemMovedEventHandler(this._treeFieldWidget_SelectionMoved);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(label20);
            this.panel3.Controls.Add(this._treeFieldWidthTB);
            this.panel3.Controls.Add(label13);
            this.panel3.Controls.Add(this._TreeFieldHeadingTB);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 307);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 49);
            this.panel3.TabIndex = 2;
            // 
            // _treeFieldWidthTB
            // 
            this._treeFieldWidthTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TreeField, "Width", true));
            this._treeFieldWidthTB.Location = new System.Drawing.Point(137, 24);
            this._treeFieldWidthTB.Name = "_treeFieldWidthTB";
            this._treeFieldWidthTB.Size = new System.Drawing.Size(100, 20);
            this._treeFieldWidthTB.TabIndex = 3;
            // 
            // _BS_TreeField
            // 
            this._BS_TreeField.DataSource = typeof(CruiseDAL.DataObjects.TreeFieldSetupDefaultDO);
            // 
            // _TreeFieldHeadingTB
            // 
            this._TreeFieldHeadingTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_TreeField, "Heading", true));
            this._TreeFieldHeadingTB.Location = new System.Drawing.Point(7, 24);
            this._TreeFieldHeadingTB.Name = "_TreeFieldHeadingTB";
            this._TreeFieldHeadingTB.Size = new System.Drawing.Size(100, 20);
            this._TreeFieldHeadingTB.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Heading";
            // 
            // _logField_TabPage
            // 
            this._logField_TabPage.Controls.Add(this._logFieldWidget);
            this._logField_TabPage.Controls.Add(this.panel4);
            this._logField_TabPage.Location = new System.Drawing.Point(4, 22);
            this._logField_TabPage.Name = "_logField_TabPage";
            this._logField_TabPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this._logField_TabPage.Size = new System.Drawing.Size(486, 363);
            this._logField_TabPage.TabIndex = 1;
            this._logField_TabPage.Text = "Log Field Setup";
            this._logField_TabPage.UseVisualStyleBackColor = true;
            // 
            // _logFieldWidget
            // 
            this._logFieldWidget.DisplayMember = "Field";
            this._logFieldWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logFieldWidget.Location = new System.Drawing.Point(3, 3);
            this._logFieldWidget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this._logFieldWidget.MinimumSize = new System.Drawing.Size(0, 183);
            this._logFieldWidget.Name = "_logFieldWidget";
            this._logFieldWidget.SelectedItemsDataSource = null;
            this._logFieldWidget.SelectedValue = null;
            this._logFieldWidget.Size = new System.Drawing.Size(480, 308);
            this._logFieldWidget.TabIndex = 0;
            this._logFieldWidget.ValueMember = null;
            this._logFieldWidget.SelectedValueChanged += new FMSC.Controls.SelectedValueChangedEventHandler(this._logFieldWidget_SelectedValueChanged);
            this._logFieldWidget.SelectionAdded += new FMSC.Controls.SelectionAddedEventHandler(this._logFieldWidget_SelectionAdded);
            this._logFieldWidget.SelectionMoved += new FMSC.Controls.ItemMovedEventHandler(this._logFieldWidget_SelectionMoved);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this._logFieldWidthTB);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this._logFieldHeadingTB);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 311);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(480, 49);
            this.panel4.TabIndex = 3;
            // 
            // _logFieldWidthTB
            // 
            this._logFieldWidthTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_LogField, "Width", true));
            this._logFieldWidthTB.Location = new System.Drawing.Point(137, 24);
            this._logFieldWidthTB.Name = "_logFieldWidthTB";
            this._logFieldWidthTB.Size = new System.Drawing.Size(100, 20);
            this._logFieldWidthTB.TabIndex = 5;
            // 
            // _BS_LogField
            // 
            this._BS_LogField.DataSource = typeof(CruiseDAL.DataObjects.LogFieldSetupDefaultDO);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(134, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Width (leave empty to use Auto Width)";
            // 
            // _logFieldHeadingTB
            // 
            this._logFieldHeadingTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._BS_LogField, "Heading", true));
            this._logFieldHeadingTB.Location = new System.Drawing.Point(7, 24);
            this._logFieldHeadingTB.Name = "_logFieldHeadingTB";
            this._logFieldHeadingTB.Size = new System.Drawing.Size(100, 20);
            this._logFieldHeadingTB.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Heading";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._strataLB);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 385);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Strata";
            // 
            // _strataLB
            // 
            this._strataLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._strataLB.FormatString = "[Code] - [Method]";
            this._strataLB.FormattingEnabled = true;
            this._strataLB.Location = new System.Drawing.Point(3, 16);
            this._strataLB.Name = "_strataLB";
            this._strataLB.Size = new System.Drawing.Size(128, 355);
            this._strataLB.TabIndex = 0;
            this._strataLB.SelectedValueChanged += new System.EventHandler(this._strataLB_SelectedValueChanged);
            // 
            // _tallySetupPage
            // 
            this._tallySetupPage.Controls.Add(this.flowLayoutPanel1);
            this._tallySetupPage.Location = new System.Drawing.Point(4, 22);
            this._tallySetupPage.Name = "_tallySetupPage";
            this._tallySetupPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this._tallySetupPage.Size = new System.Drawing.Size(632, 391);
            this._tallySetupPage.TabIndex = 1;
            this._tallySetupPage.Text = "Tally Setup";
            this._tallySetupPage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._tallyNavPanel);
            this.flowLayoutPanel1.Controls.Add(this._tallyEditPanel);
            this.flowLayoutPanel1.Controls.Add(this.richTextBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(626, 385);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // _tallyNavPanel
            // 
            this._tallyNavPanel.Controls.Add(this._systematicOptCB);
            this._tallyNavPanel.Controls.Add(this._stratumHKCB);
            this._tallyNavPanel.Controls.Add(this.label21);
            this._tallyNavPanel.Controls.Add(this._sampleGroupCB);
            this._tallyNavPanel.Controls.Add(this.label10);
            this._tallyNavPanel.Controls.Add(this.label9);
            this._tallyNavPanel.Controls.Add(this._strataCB);
            this._tallyNavPanel.Location = new System.Drawing.Point(3, 3);
            this._tallyNavPanel.Name = "_tallyNavPanel";
            this._tallyNavPanel.Size = new System.Drawing.Size(445, 56);
            this._tallyNavPanel.TabIndex = 10;
            // 
            // _systematicOptCB
            // 
            this._systematicOptCB.AutoSize = true;
            this._systematicOptCB.Location = new System.Drawing.Point(214, 35);
            this._systematicOptCB.Name = "_systematicOptCB";
            this._systematicOptCB.Size = new System.Drawing.Size(198, 17);
            this._systematicOptCB.TabIndex = 14;
            this._systematicOptCB.Text = "Use Systematic Sampling (STR only)";
            this._systematicOptCB.UseVisualStyleBackColor = true;
            // 
            // _stratumHKCB
            // 
            this._stratumHKCB.FormattingEnabled = true;
            this._stratumHKCB.Location = new System.Drawing.Point(301, 3);
            this._stratumHKCB.Name = "_stratumHKCB";
            this._stratumHKCB.Size = new System.Drawing.Size(47, 21);
            this._stratumHKCB.TabIndex = 13;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(211, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Stratum Hot Key";
            // 
            // _sampleGroupCB
            // 
            this._sampleGroupCB.FormattingEnabled = true;
            this._sampleGroupCB.Location = new System.Drawing.Point(83, 31);
            this._sampleGroupCB.Name = "_sampleGroupCB";
            this._sampleGroupCB.Size = new System.Drawing.Size(121, 21);
            this._sampleGroupCB.TabIndex = 11;
            this._sampleGroupCB.SelectedValueChanged += new System.EventHandler(this._sampleGroupCB_SelectedValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Sample Group";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Stratum";
            // 
            // _strataCB
            // 
            this._strataCB.FormattingEnabled = true;
            this._strataCB.Location = new System.Drawing.Point(83, 3);
            this._strataCB.Name = "_strataCB";
            this._strataCB.Size = new System.Drawing.Size(121, 21);
            this._strataCB.TabIndex = 8;
            this._strataCB.SelectedValueChanged += new System.EventHandler(this._strataCB_SelectedValueChanged);
            // 
            // _tallyEditPanel
            // 
            this._tallyEditPanel.AllowTallyBySG = true;
            this._tallyEditPanel.AllowTallyBySpecies = true;
            this._tallyEditPanel.HotKeyOptions = null;
            this._tallyEditPanel.Location = new System.Drawing.Point(4, 66);
            this._tallyEditPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._tallyEditPanel.Name = "_tallyEditPanel";
            this._tallyEditPanel.Size = new System.Drawing.Size(342, 258);
            this._tallyEditPanel.TabIndex = 9;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Location = new System.Drawing.Point(353, 65);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(175, 259);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // _treeAuditTabPage
            // 
            this._treeAuditTabPage.Controls.Add(_treeAuditRulesLayout);
            this._treeAuditTabPage.Location = new System.Drawing.Point(4, 22);
            this._treeAuditTabPage.Margin = new System.Windows.Forms.Padding(0);
            this._treeAuditTabPage.Name = "_treeAuditTabPage";
            this._treeAuditTabPage.Size = new System.Drawing.Size(632, 391);
            this._treeAuditTabPage.TabIndex = 6;
            this._treeAuditTabPage.Text = "Tree Audit Rules";
            this._treeAuditTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._treeAuditErrorTB);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this._treeAuditValueSetTB);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this._treeAuditMaxTB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this._treeAuditMinTB);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(203, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 220);
            this.panel2.TabIndex = 2;
            // 
            // _treeAuditErrorTB
            // 
            this._treeAuditErrorTB.Location = new System.Drawing.Point(7, 125);
            this._treeAuditErrorTB.Name = "_treeAuditErrorTB";
            this._treeAuditErrorTB.Size = new System.Drawing.Size(275, 90);
            this._treeAuditErrorTB.TabIndex = 7;
            this._treeAuditErrorTB.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Error Message";
            // 
            // _treeAuditValueSetTB
            // 
            this._treeAuditValueSetTB.Location = new System.Drawing.Point(7, 55);
            this._treeAuditValueSetTB.Name = "_treeAuditValueSetTB";
            this._treeAuditValueSetTB.Size = new System.Drawing.Size(275, 47);
            this._treeAuditValueSetTB.TabIndex = 5;
            this._treeAuditValueSetTB.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value Set";
            // 
            // _treeAuditMaxTB
            // 
            this._treeAuditMaxTB.Location = new System.Drawing.Point(128, 4);
            this._treeAuditMaxTB.Name = "_treeAuditMaxTB";
            this._treeAuditMaxTB.Size = new System.Drawing.Size(52, 20);
            this._treeAuditMaxTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max";
            // 
            // _treeAuditMinTB
            // 
            this._treeAuditMinTB.Location = new System.Drawing.Point(37, 4);
            this._treeAuditMinTB.Name = "_treeAuditMinTB";
            this._treeAuditMinTB.Size = new System.Drawing.Size(52, 20);
            this._treeAuditMinTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._treeAuditFieldList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 220);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Field Name";
            // 
            // _treeAuditFieldList
            // 
            this._treeAuditFieldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeAuditFieldList.FormattingEnabled = true;
            this._treeAuditFieldList.Location = new System.Drawing.Point(3, 16);
            this._treeAuditFieldList.Name = "_treeAuditFieldList";
            this._treeAuditFieldList.Size = new System.Drawing.Size(194, 201);
            this._treeAuditFieldList.TabIndex = 0;
            // 
            // _treeAuditTDVSelectDGV
            // 
            this._treeAuditTDVSelectDGV.AutoGenerateColumns = false;
            this._treeAuditTDVSelectDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._treeAuditTDVSelectDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.primaryProductDataGridViewTextBoxColumn,
            this.speciesDataGridViewTextBoxColumn,
            this.liveDeadDataGridViewTextBoxColumn,
            this.fIAcodeDataGridViewTextBoxColumn,
            this.cullPrimaryDataGridViewTextBoxColumn,
            this.hiddenPrimaryDataGridViewTextBoxColumn,
            this.cullSecondaryDataGridViewTextBoxColumn,
            this.hiddenSecondaryDataGridViewTextBoxColumn,
            this.recoverableDataGridViewTextBoxColumn,
            this.chargeableDataGridViewTextBoxColumn,
            this.contractSpeciesDataGridViewTextBoxColumn,
            this.treeGradeDataGridViewTextBoxColumn,
            this.merchHeightLogLengthDataGridViewTextBoxColumn,
            this.merchHeightTypeDataGridViewTextBoxColumn,
            this.formClassDataGridViewTextBoxColumn,
            this.barkThicknessRatioDataGridViewTextBoxColumn,
            this.averageZDataGridViewTextBoxColumn,
            this.referenceHeightPercentDataGridViewTextBoxColumn});
            this._treeAuditTDVSelectDGV.Dock = System.Windows.Forms.DockStyle.Top;
            this._treeAuditTDVSelectDGV.Location = new System.Drawing.Point(3, 3);
            this._treeAuditTDVSelectDGV.Name = "_treeAuditTDVSelectDGV";
            this._treeAuditTDVSelectDGV.RowTemplate.Height = 24;
            this._treeAuditTDVSelectDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._treeAuditTDVSelectDGV.Size = new System.Drawing.Size(488, 131);
            this._treeAuditTDVSelectDGV.TabIndex = 0;
            // 
            // primaryProductDataGridViewTextBoxColumn
            // 
            this.primaryProductDataGridViewTextBoxColumn.DataPropertyName = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn.HeaderText = "PrimaryProduct";
            this.primaryProductDataGridViewTextBoxColumn.Name = "primaryProductDataGridViewTextBoxColumn";
            // 
            // speciesDataGridViewTextBoxColumn
            // 
            this.speciesDataGridViewTextBoxColumn.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn.HeaderText = "Species";
            this.speciesDataGridViewTextBoxColumn.Name = "speciesDataGridViewTextBoxColumn";
            // 
            // liveDeadDataGridViewTextBoxColumn
            // 
            this.liveDeadDataGridViewTextBoxColumn.DataPropertyName = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn.HeaderText = "LiveDead";
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
            this.cullPrimaryDataGridViewTextBoxColumn.HeaderText = "CullPrimary";
            this.cullPrimaryDataGridViewTextBoxColumn.Name = "cullPrimaryDataGridViewTextBoxColumn";
            // 
            // hiddenPrimaryDataGridViewTextBoxColumn
            // 
            this.hiddenPrimaryDataGridViewTextBoxColumn.DataPropertyName = "HiddenPrimary";
            this.hiddenPrimaryDataGridViewTextBoxColumn.HeaderText = "HiddenPrimary";
            this.hiddenPrimaryDataGridViewTextBoxColumn.Name = "hiddenPrimaryDataGridViewTextBoxColumn";
            // 
            // cullSecondaryDataGridViewTextBoxColumn
            // 
            this.cullSecondaryDataGridViewTextBoxColumn.DataPropertyName = "CullSecondary";
            this.cullSecondaryDataGridViewTextBoxColumn.HeaderText = "CullSecondary";
            this.cullSecondaryDataGridViewTextBoxColumn.Name = "cullSecondaryDataGridViewTextBoxColumn";
            // 
            // hiddenSecondaryDataGridViewTextBoxColumn
            // 
            this.hiddenSecondaryDataGridViewTextBoxColumn.DataPropertyName = "HiddenSecondary";
            this.hiddenSecondaryDataGridViewTextBoxColumn.HeaderText = "HiddenSecondary";
            this.hiddenSecondaryDataGridViewTextBoxColumn.Name = "hiddenSecondaryDataGridViewTextBoxColumn";
            // 
            // recoverableDataGridViewTextBoxColumn
            // 
            this.recoverableDataGridViewTextBoxColumn.DataPropertyName = "Recoverable";
            this.recoverableDataGridViewTextBoxColumn.HeaderText = "Recoverable";
            this.recoverableDataGridViewTextBoxColumn.Name = "recoverableDataGridViewTextBoxColumn";
            // 
            // chargeableDataGridViewTextBoxColumn
            // 
            this.chargeableDataGridViewTextBoxColumn.DataPropertyName = "Chargeable";
            this.chargeableDataGridViewTextBoxColumn.HeaderText = "Chargeable";
            this.chargeableDataGridViewTextBoxColumn.Name = "chargeableDataGridViewTextBoxColumn";
            // 
            // contractSpeciesDataGridViewTextBoxColumn
            // 
            this.contractSpeciesDataGridViewTextBoxColumn.DataPropertyName = "ContractSpecies";
            this.contractSpeciesDataGridViewTextBoxColumn.HeaderText = "ContractSpecies";
            this.contractSpeciesDataGridViewTextBoxColumn.Name = "contractSpeciesDataGridViewTextBoxColumn";
            // 
            // treeGradeDataGridViewTextBoxColumn
            // 
            this.treeGradeDataGridViewTextBoxColumn.DataPropertyName = "TreeGrade";
            this.treeGradeDataGridViewTextBoxColumn.HeaderText = "TreeGrade";
            this.treeGradeDataGridViewTextBoxColumn.Name = "treeGradeDataGridViewTextBoxColumn";
            // 
            // merchHeightLogLengthDataGridViewTextBoxColumn
            // 
            this.merchHeightLogLengthDataGridViewTextBoxColumn.DataPropertyName = "MerchHeightLogLength";
            this.merchHeightLogLengthDataGridViewTextBoxColumn.HeaderText = "MerchHeightLogLength";
            this.merchHeightLogLengthDataGridViewTextBoxColumn.Name = "merchHeightLogLengthDataGridViewTextBoxColumn";
            // 
            // merchHeightTypeDataGridViewTextBoxColumn
            // 
            this.merchHeightTypeDataGridViewTextBoxColumn.DataPropertyName = "MerchHeightType";
            this.merchHeightTypeDataGridViewTextBoxColumn.HeaderText = "MerchHeightType";
            this.merchHeightTypeDataGridViewTextBoxColumn.Name = "merchHeightTypeDataGridViewTextBoxColumn";
            // 
            // formClassDataGridViewTextBoxColumn
            // 
            this.formClassDataGridViewTextBoxColumn.DataPropertyName = "FormClass";
            this.formClassDataGridViewTextBoxColumn.HeaderText = "FormClass";
            this.formClassDataGridViewTextBoxColumn.Name = "formClassDataGridViewTextBoxColumn";
            // 
            // barkThicknessRatioDataGridViewTextBoxColumn
            // 
            this.barkThicknessRatioDataGridViewTextBoxColumn.DataPropertyName = "BarkThicknessRatio";
            this.barkThicknessRatioDataGridViewTextBoxColumn.HeaderText = "BarkThicknessRatio";
            this.barkThicknessRatioDataGridViewTextBoxColumn.Name = "barkThicknessRatioDataGridViewTextBoxColumn";
            // 
            // averageZDataGridViewTextBoxColumn
            // 
            this.averageZDataGridViewTextBoxColumn.DataPropertyName = "AverageZ";
            this.averageZDataGridViewTextBoxColumn.HeaderText = "AverageZ";
            this.averageZDataGridViewTextBoxColumn.Name = "averageZDataGridViewTextBoxColumn";
            // 
            // referenceHeightPercentDataGridViewTextBoxColumn
            // 
            this.referenceHeightPercentDataGridViewTextBoxColumn.DataPropertyName = "ReferenceHeightPercent";
            this.referenceHeightPercentDataGridViewTextBoxColumn.HeaderText = "ReferenceHeightPercent";
            this.referenceHeightPercentDataGridViewTextBoxColumn.Name = "referenceHeightPercentDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Tag";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tag";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
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
            // CruiseCustomizeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tabControl);
            this.Name = "CruiseCustomizeView";
            this.Size = new System.Drawing.Size(640, 417);
            _treeAuditRulesLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._tdvDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeDefaults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._treeAuditDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BS_treeAudits)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this._tabControl.ResumeLayout(false);
            this._fieldSetupPage.ResumeLayout(false);
            this._fieldSetup_Child_TabControl.ResumeLayout(false);
            this._treeField_TabPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_TreeField)).EndInit();
            this._logField_TabPage.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BS_LogField)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this._tallySetupPage.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this._tallyNavPanel.ResumeLayout(false);
            this._tallyNavPanel.PerformLayout();
            this._treeAuditTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._treeAuditTDVSelectDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public void UpdateView()
        {
            if (this.Presenter.IsLogGradingEnabled)
            {
                if (!this._fieldSetup_Child_TabControl.TabPages.Contains(this._logField_TabPage))
                {
                    this._fieldSetup_Child_TabControl.TabPages.Add(this._logField_TabPage);
                }
            }
            else
            {
                this._fieldSetup_Child_TabControl.TabPages.Remove(this._logField_TabPage);
            }
        }

        public void UpdateStrata()
        {
            //HACK ToArray the strata because if you use the same list for two datasources the become linked 
            //i.e.  position changed events will fire when the other's position is changed
            _strataCB.DataSource = Presenter.StrataVM.ToArray();
            _strataLB.DataSource = Presenter.StrataVM.ToArray();
        }

        public void UpdatePresets()
        {
            _tallyEditPanel.TallyPresets = Presenter.TallyPresets;
        }


        public void UpdateTreeDefaults()
        {
            _BS_treeDefaults.DataSource = Presenter.TreeDefaults;
        }

        public void UpdateTreeAudits()
        {
            _BS_treeAudits.DataSource = Presenter.TreeAudits;
        }

        public void UpdateLogMatrix()
        {
            //_BS_LogMatrix.DataSource = Presenter.LogMatrix;
            if(this._logMatrixPage != null)
            {
                this._logMatrixPage.DataSource = Presenter.LogMatrix;
            }
        }

        public void UpdateTallySampleGroups(IList<SampleGroupDO> sampleGroups)
        {
            _sampleGroupCB.DataSource = sampleGroups;
        }

        public void EndEdits()
        {
            if (_currentSG != null && this._systematicOptCB.Enabled)
            {
                _currentSG.UseSystematicSampling = this._systematicOptCB.Checked;
            }
            if (_currentTallySetupStratum != null)
            {
                _currentTallySetupStratum.Hotkey = _stratumHKCB.Text;
            }

            this._tallyEditPanel.EndEdits();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Presenter.UpdateView();
        }


        #region Tally setup
        private void _strataCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_currentTallySetupStratum != null)
            {
                _currentTallySetupStratum.Hotkey = _stratumHKCB.Text;
                _currentTallySetupStratum.Save();
            }
            _currentTallySetupStratum = _strataCB.SelectedValue as StratumCustomizeViewModel;

            
            if(_currentTallySetupStratum == null) { return; }

            _stratumHKCB.DataSource = GetAvalibleHotKeys(_currentTallySetupStratum);
            _stratumHKCB.Text = _currentTallySetupStratum.Hotkey;

            this._tallyEditPanel.Enabled = Presenter.CanDefintTallys(_currentTallySetupStratum);
            
            _sampleGroupCB.DataSource = _currentTallySetupStratum.SampleGroups;                
        }

        private void _sampleGroupCB_SelectedValueChanged(object sender, EventArgs e)
        {
            //store use systematic sampleing option for previously selected sample group, if there was one
            if (_currentSG != null && this._systematicOptCB.Enabled)
            {
                _currentSG.UseSystematicSampling = this._systematicOptCB.Checked;
            }

            _currentSG = (SampleGroupViewModel)_sampleGroupCB.SelectedValue;
            if (_currentSG == null || _tallyEditPanel.Enabled == false)
            {
                this._systematicOptCB.Enabled = false;
                return;
            }
            else
            {
                this._systematicOptCB.Enabled = _currentSG.IsSTR() && _currentSG.CanChangeSamplerType();
                this._systematicOptCB.Checked = _currentSG.UseSystematicSampling;
            }

            string method = _currentSG.Stratum.Method;
            //_currentSG.LoadTallieData();
            _tallyEditPanel.SampleGroup = _currentSG;
            _tallyEditPanel.AllowTallyBySG = (method != CruiseDAL.Schema.Constants.CruiseMethods.THREEP);
            _tallyEditPanel.HotKeyOptions = GetAvalibleHotKeys(_currentSG);
        }

        //TODO move these methods to presenter class
        private string[] GetAvalibleHotKeys(SampleGroupDO sg)
        {
            return CSM.Utility.R.Strings.HOTKEYS;
        }

        private string[] GetAvalibleHotKeys(StratumDO st)
        {
            return CSM.Utility.R.Strings.HOTKEYS;
        }
        #endregion

        #region Tree/Log Field methods
        private void _strataLB_SelectedValueChanged(object sender, EventArgs e)
        {
            StratumCustomizeViewModel stratum = _strataLB.SelectedValue as StratumCustomizeViewModel;
            if (stratum == null) { return; }
            HandleFieldSetupSelectedStratumChanged(stratum);
        }

        private void HandleFieldSetupSelectedStratumChanged(StratumCustomizeViewModel stratum)
        {
            if (stratum != null)
            {
                List<TreeFieldSetupDO> selectedTreeFields = stratum.SelectedTreeFields;
                List<TreeFieldSetupDO> unselectedTreeFields = stratum.UnselectedTreeFields;
                unselectedTreeFields.Sort(TreeFieldComparer.GetInstance());
                this._treeFieldWidget.SelectedItemsDataSource = selectedTreeFields;
                this._treeFieldWidget.DataSource = unselectedTreeFields;

                List<LogFieldSetupDO> selectedLogFields = stratum.SelectedLogFields;
                List<LogFieldSetupDO> unselectedLogFields = stratum.UnselectedLogFields;
                unselectedLogFields.Sort(LogFieldComparer.GetInstance());
                this._logFieldWidget.SelectedItemsDataSource = selectedLogFields;
                this._logFieldWidget.DataSource = unselectedLogFields;
            }
        }


        private void _treeFieldWidget_SelectionMoved(object sender, FMSC.Controls.ItemMovedEventArgs e)
        {
            UpdateTreeFieldOrder();
            //TreeFieldSetupDO tf = e.Item as TreeFieldSetupDO;
            //IList<TreeFieldSetupDO> list = (IList<TreeFieldSetupDO>)_treeFieldWidget.SelectedItemsDataSource;
            //TreeFieldSetupDO othertf = list[e.PreviousIndex];
            //tf.FieldOrder = e.NewIndex;
            //othertf.FieldOrder = e.PreviousIndex;
        }

        private void _treeFieldWidget_SelectionAdded(object sender, object item, int index)
        {
            UpdateTreeFieldOrder();
            //TreeFieldSetupDO tf = item as TreeFieldSetupDO;
            //if (tf == null) { return; }
            ////tf.Stratum = FieldSetup_CurrentStratum;
            //tf.FieldOrder = index;
            ////tf.DAL = Presenter.Controller.Database;
            ////tf.Save();
        }

        private void _logFieldWidget_SelectionAdded(object sender, object item, int index)
        {
            UpdateLogFieldOrder();
            //LogFieldSetupDO lf = item as LogFieldSetupDO;
            //if (lf == null) { return; }
            ////lf.Stratum = FieldSetup_CurrentStratum;
            //lf.FieldOrder = index;
            ////lf.DAL = Presenter.Controller.Database;
            ////lf.Save();
        }

        private void _logFieldWidget_SelectionMoved(object sender, FMSC.Controls.ItemMovedEventArgs e)
        {
            UpdateLogFieldOrder();
            //LogFieldSetupDO lf = e.Item as LogFieldSetupDO;
            //IList<LogFieldSetupDO> list = (IList<LogFieldSetupDO>)_logFieldWidget.SelectedItemsDataSource;
            //LogFieldSetupDO otherlf = list[e.PreviousIndex];
            //lf.FieldOrder = e.NewIndex;
            //otherlf.FieldOrder = e.PreviousIndex;
            ////lf.Save();
            ////otherlf.Save();
        }



        //refreshes the field order on all items
        //item's fieldOrder = item's list position + 1
        private void UpdateLogFieldOrder()
        {
            IList<LogFieldSetupDO> list = (IList<LogFieldSetupDO>)_logFieldWidget.SelectedItemsDataSource;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FieldOrder = i + 1;
            }
        }

        //refreshes the field order on all items
        //item's fieldOrder = item's list position + 1
        private void UpdateTreeFieldOrder()
        {
            IList<TreeFieldSetupDO> list = (IList<TreeFieldSetupDO>)_treeFieldWidget.SelectedItemsDataSource;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FieldOrder = i + 1;
            }
        }

        private void _logFieldWidget_SelectedValueChanged(object sender, EventArgs e, object selectedValue)
        {
            if (selectedValue == null) { return; }
            this._BS_LogField.DataSource = selectedValue;
        }

        private void _treeFieldWidget_SelectedValueChanged(object sender, EventArgs e, object selectedValue)
        {
            if (selectedValue == null) { return; }
            this._BS_TreeField.DataSource = selectedValue;
        }
#endregion 

        #region Tree Audits
        private void _BS_treeAudits_CurrentItemChanged(object sender, EventArgs e)
        {
            TreeAuditValueDO tav = _BS_treeAudits.Current as TreeAuditValueDO;
            if (tav == null) { return; }
            if (!tav.TreeDefaultValues.IsPopulated)
            {
                tav.TreeDefaultValues.Populate();
            }
            _tdvDGV.SelectedItems = tav.TreeDefaultValues;
        }

        private void _treeAuditClearSelectionBtn_Click(object sender, EventArgs e)
        {
            TreeAuditValueDO tav = _BS_treeAudits.Current as TreeAuditValueDO;
            if (tav == null) { return; }
            if (!tav.TreeDefaultValues.IsPopulated)
            {
                tav.TreeDefaultValues.Populate();
            }
            tav.TreeDefaultValues.Clear();
            _tdvDGV.Invalidate();
        }

        private void _tavDeleteBTN_Click(object sender, EventArgs e)
        {
            TreeAuditValueDO tav = _BS_treeAudits.Current as TreeAuditValueDO;
            if (tav == null) { return; }
            tav.Delete();
            _BS_treeAudits.Remove(tav);
        }

       
        //TODO keep method? Under what situations do DG throw Data Errror?
        private void _treeAuditDGV_DataError(object sender,
            DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion 

        #region Log Matrix Stuff
        //private string GradeCodeSeperator
        //{
        //    get
        //    {
        //        if (_descriptorAndRB.Checked == true)
        //        { return "&"; }
        //        if (_descriptorOrRB.Checked == true)
        //        { return "or"; }
        //        if (_descriptorCamprunRB.Checked == true)
        //        { return "(camprun)"; }
        //        return string.Empty;
        //    }
        //}

        //private bool _currentLogMatrixChanging = false;

        //private void UpdateLogGradeCode()
        //{
        //    LogMatrixDO lm = this._BS_LogMatrix.Current as LogMatrixDO;
        //    if (lm == null) 
        //    { 
        //        this._logGradeCodeTB.Text = string.Empty; 
        //        return; 
        //    }

        //    List<String> list = new List<string>();

        //    if (!string.IsNullOrEmpty(lm.LogGrade1)) { list.Add(lm.LogGrade1); }
        //    if (!string.IsNullOrEmpty(lm.LogGrade2)) { list.Add(lm.LogGrade2); }
        //    if (!string.IsNullOrEmpty(lm.LogGrade3)) { list.Add(lm.LogGrade3); }
        //    if (!string.IsNullOrEmpty(lm.LogGrade4)) { list.Add(lm.LogGrade4); }
        //    if (!string.IsNullOrEmpty(lm.LogGrade5)) { list.Add(lm.LogGrade5); }
        //    if (!string.IsNullOrEmpty(lm.LogGrade6)) { list.Add(lm.LogGrade6); }

        //    lm.GradeDescription = string.Join(" " + GradeCodeSeperator + " ",
        //        list.ToArray());
        //}

        //private void OnCurrentLogMatrixChanged(LogMatrixDO lm)
        //{
        //    _currentLogMatrixChanging = true;

        //    foreach (CheckBox cb in grades)
        //    {
        //        cb.Checked = false;
        //    }

        //    if (string.IsNullOrEmpty(lm.Species))
        //    {
        //        _logMatrixSpeciesCB.SelectedIndex = -1;
        //    }

        //    if (!String.IsNullOrEmpty(lm.LogGrade1))
        //    {
        //        SetLogMatrixGradeView(lm.LogGrade1, true);
        //    }
        //    if (!String.IsNullOrEmpty(lm.LogGrade2))
        //    {
        //        SetLogMatrixGradeView(lm.LogGrade2, true);
        //    }
        //    if (!String.IsNullOrEmpty(lm.LogGrade3))
        //    {
        //        SetLogMatrixGradeView(lm.LogGrade3, true);
        //    }
        //    if (!String.IsNullOrEmpty(lm.LogGrade4))
        //    {
        //        SetLogMatrixGradeView(lm.LogGrade4, true);
        //    }
        //    if (!String.IsNullOrEmpty(lm.LogGrade5))
        //    {
        //        SetLogMatrixGradeView(lm.LogGrade5, true);
        //    }
        //    if (!String.IsNullOrEmpty(lm.LogGrade6))
        //    {
        //        SetLogMatrixGradeView(lm.LogGrade6, true);
        //    }

        //    if(!string.IsNullOrEmpty(lm.GradeDescription))
        //    {
        //        if (lm.GradeDescription.Contains('&'))
        //        {
        //            this._descriptorAndRB.Checked = true;
        //        }
        //        else if (lm.GradeDescription.Contains("or"))
        //        {
        //            this._descriptorOrRB.Checked = true;
        //        }
        //        else if (lm.GradeDescription.Contains("(camprun)"))
        //        {
        //            this._descriptorCamprunRB.Checked = true;
        //        }
        //    }
        //    else
        //    {
        //        this._descriptorAndRB.Checked = false;
        //        this._descriptorOrRB.Checked = false;
        //        this._descriptorCamprunRB.Checked = false;
        //    }

        //    if (lm.ReportNumber == "R008")
        //    {
        //        _r008RB.Checked = true;
        //    }
        //    else if (lm.ReportNumber == "R009")
        //    {
        //        _r009RB.Checked = true;
        //    }
        //    else
        //    {
        //        _r008RB.Checked = true;
        //        //HACK editing property while current logMatrix is changind causes exception to be thrown when property changed event is thrown
        //        lm.StartWrite();//prevent property changed events from fireing
        //        lm.ReportNumber = "R008";
        //        lm.EndWrite();
        //    }

        //    //UpdateLogGradeCode();
        //    _currentLogMatrixChanging = false;
        //}

        //private void SetLogMatrixGradeView(string grade, bool value)
        //{
        //    try
        //    {
        //        int i = Convert.ToInt32(grade);
        //        grades[i].Checked = value;
        //    }
        //    catch
        //    {
        //        //do nothing
        //    }
        //}

        //private bool SetLogMatrixGrade(string grade, bool value)
        //{
        //    LogMatrixDO lm = this._BS_LogMatrix.Current as LogMatrixDO;
        //    if (lm == null) { return false; }

        //    if (value == false)
        //    {
        //        if (lm.LogGrade1 == grade)
        //        {
        //            lm.LogGrade1 = string.Empty;
        //            return true;
        //        }
        //        if (lm.LogGrade2 == grade)
        //        {
        //            lm.LogGrade2 = string.Empty;
        //            return true;
        //        }
        //        if (lm.LogGrade3 == grade)
        //        {
        //            lm.LogGrade3 = string.Empty;
        //            return true;
        //        }
        //        if (lm.LogGrade4 == grade)
        //        {
        //            lm.LogGrade4 = string.Empty;
        //            return true;
        //        }
        //        if (lm.LogGrade5 == grade)
        //        {
        //            lm.LogGrade5 = string.Empty;
        //            return true;
        //        }
        //        if (lm.LogGrade6 == grade)
        //        {
        //            lm.LogGrade6 = string.Empty;
        //            return true;
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(lm.LogGrade1))
        //        {
        //            lm.LogGrade1 = grade;
        //            return true;
        //        }
        //        if (string.IsNullOrEmpty(lm.LogGrade2))
        //        {
        //            lm.LogGrade2 = grade;
        //            return true;
        //        }
        //        if (string.IsNullOrEmpty(lm.LogGrade3))
        //        {
        //            lm.LogGrade3 = grade;
        //            return true;
        //        }
        //        if (string.IsNullOrEmpty(lm.LogGrade4))
        //        {
        //            lm.LogGrade4 = grade;
        //            return true;
        //        }
        //        if (string.IsNullOrEmpty(lm.LogGrade5))
        //        {
        //            lm.LogGrade5 = grade;
        //            return true;
        //        }
        //        if (string.IsNullOrEmpty(lm.LogGrade6))
        //        {
        //            lm.LogGrade6 = grade;
        //            return true;
        //        }
        //        return false;
        //    }
        //}

        //private void grade_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (_currentLogMatrixChanging == true) { return; }

        //    for (int i = 0; i < grades.Length; i++)
        //    {
        //        if (object.ReferenceEquals(grades[i], sender))
        //        {
        //            if (this.SetLogMatrixGrade(i.ToString(), this.grades[i].Checked) == false)
        //            {
        //                this.grades[i].Checked = false;
        //            }
        //            UpdateLogGradeCode();
        //        }
        //    }
        //}

        //private void descriptor_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (_currentLogMatrixChanging == true) { return; }
        //    this.UpdateLogGradeCode();
        //}

        //private void _addLogMatrixBTN_Click(object sender, EventArgs e)
        //{

        //    this._BS_LogMatrix.Add(new LogMatrixDO());
        //}

        //private void _deleteLogMatrixBTN_Click(object sender, EventArgs e)
        //{
        //    LogMatrixDO lm = this._BS_LogMatrix.Current as LogMatrixDO;
        //    if (lm == null) { return; }
        //    lm.Delete();
        //    this._BS_LogMatrix.Remove(lm);
        //}

        //private void _clearLogMatrixBTN_Click(object sender, EventArgs e)
        //{
        //    foreach (LogMatrixDO lm in Presenter.LogMatrix)
        //    {
        //        if (lm.IsPersisted)
        //        {
        //            lm.Delete();
        //        }
        //    }
        //    _BS_LogMatrix.Clear();
        //}

        //private void _BS_LogMatrix_CurrentChanged(object sender, EventArgs e)
        //{
        //    LogMatrixDO lm = _BS_LogMatrix.Current as LogMatrixDO;
        //    if (lm == null) 
        //    {
        //        this.newParameters.Enabled = false;
        //        return; 
        //    }
        //    this.newParameters.Enabled = true;
        //    this.OnCurrentLogMatrixChanged(lm);
        //}

        //private void UpdateSEDLimmit()
        //{
        //    LogMatrixDO lm = _BS_LogMatrix.Current as LogMatrixDO;
        //    if (lm == null) { return; }

        //    lm.SEDlimit = string.Format("{0} {1} {2} {3}",
        //        this._descriptor1.Text,
        //        (lm.SEDminimum > 0) ? lm.SEDminimum.ToString() : string.Empty,
        //        this._descriptor2.Text,
        //        (lm.SEDmaximum > 0) ? lm.SEDmaximum.ToString() : string.Empty);

        //}


        //private void sedLimmitSettingsChanged(object sender, EventArgs e)
        //{
        //    UpdateSEDLimmit();
        //}

        //private void ReportID_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (_currentLogMatrixChanging == true) { return; }
        //    LogMatrixDO lm = _BS_LogMatrix.Current as LogMatrixDO;
        //    if (lm == null) { return; }
        //    if (_r008RB.Checked == true)
        //    {
        //        lm.ReportNumber = "R008";
        //    }
        //    else if (_r009RB.Checked == true)
        //    {
        //        lm.ReportNumber = "R009";
        //    }
        //}

        #endregion

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(components != null)
                { 
                components.Dispose();
                }
                if(_logMatrixTabPage != null)
                {
                    _logMatrixTabPage.Dispose();
                }
            }
            

            base.Dispose(disposing);


        }

    }
}
