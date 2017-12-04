using CruiseManager.Core.Tvol;
using Tvol.Data;

namespace CruiseManager.WinForms.Tvol
{
    public class EditTvolView : UserControlView
    {
        

        public new EditTvolPresenter ViewPresenter
        {
            get { return (EditTvolPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        protected EditTvolView()
        {
            InitializeComponent();
        }

        public EditTvolView(EditTvolPresenter presenter) : this()
        {
            ViewPresenter = presenter;
        }

        protected override void OnViewPresenterChanged()
        {
            base.OnViewPresenterChanged();

            var vp = ViewPresenter;
            if (vp != null)
            {
                _viewModel_BS.DataSource = vp;
            }
            
        }

        private void _treeProfile_Add_BTN_Click(object sender, System.EventArgs e)
        {

        }

        private void _treeProfile_Delete_BTN_Click(object sender, System.EventArgs e)
        {

        }

        private void _regression_add_BTN_Click(object sender, System.EventArgs e)
        {

        }

        private void _regression_delete_BTN_Click(object sender, System.EventArgs e)
        {

        }

        #region Designer Generated

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _sale_tabPage;
        private System.Windows.Forms.TabPage _treeProfifle_tabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _saleNumber_TB;
        private System.Windows.Forms.DataGridView _treeProfifle_DGV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button _treeProfile_Add_BTN;
        private System.Windows.Forms.Button _treeProfile_Delete_BTN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView _regression_DGV;
        private System.Windows.Forms.Button _regression_add_BTN;
        private System.Windows.Forms.Button _regression_delete_BTN;
        private System.Windows.Forms.BindingSource _viewModel_BS;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.BindingSource _treeProfiles_BS;
        private System.Windows.Forms.BindingSource _regression_BS;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn liveDeadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dBHMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dBHMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regressionModelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coefficientADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coefficientBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coefficientCDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage _regression_tabPage;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._sale_tabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._saleNumber_TB = new System.Windows.Forms.TextBox();
            this._viewModel_BS = new System.Windows.Forms.BindingSource(this.components);
            this._treeProfifle_tabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._treeProfifle_DGV = new System.Windows.Forms.DataGridView();
            this._treeProfile_Add_BTN = new System.Windows.Forms.Button();
            this._treeProfile_Delete_BTN = new System.Windows.Forms.Button();
            this._regression_tabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._regression_DGV = new System.Windows.Forms.DataGridView();
            this._regression_add_BTN = new System.Windows.Forms.Button();
            this._regression_delete_BTN = new System.Windows.Forms.Button();
            this._treeProfiles_BS = new System.Windows.Forms.BindingSource(this.components);
            this._regression_BS = new System.Windows.Forms.BindingSource(this.components);
            this.speciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveDeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speciesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dBHMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dBHMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regressionModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coefficientADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coefficientBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coefficientCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tabControl.SuspendLayout();
            this._sale_tabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._viewModel_BS)).BeginInit();
            this._treeProfifle_tabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._treeProfifle_DGV)).BeginInit();
            this._regression_tabPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._regression_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._treeProfiles_BS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._regression_BS)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._sale_tabPage);
            this._tabControl.Controls.Add(this._treeProfifle_tabPage);
            this._tabControl.Controls.Add(this._regression_tabPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Margin = new System.Windows.Forms.Padding(0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(508, 436);
            this._tabControl.TabIndex = 0;
            // 
            // _sale_tabPage
            // 
            this._sale_tabPage.Controls.Add(this.tableLayoutPanel1);
            this._sale_tabPage.Location = new System.Drawing.Point(4, 22);
            this._sale_tabPage.Margin = new System.Windows.Forms.Padding(0);
            this._sale_tabPage.Name = "_sale_tabPage";
            this._sale_tabPage.Size = new System.Drawing.Size(500, 410);
            this._sale_tabPage.TabIndex = 0;
            this._sale_tabPage.Text = "Sale";
            this._sale_tabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._saleNumber_TB, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 410);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _saleNumber_TB
            // 
            this._saleNumber_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._viewModel_BS, "Sale.SaleNumber", true));
            this._saleNumber_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saleNumber_TB.Location = new System.Drawing.Point(77, 3);
            this._saleNumber_TB.Name = "_saleNumber_TB";
            this._saleNumber_TB.Size = new System.Drawing.Size(94, 20);
            this._saleNumber_TB.TabIndex = 1;
            // 
            // _viewModel_BS
            // 
            this._viewModel_BS.DataSource = typeof(CruiseManager.Core.Tvol.EditTvolPresenter);
            // 
            // _treeProfifle_tabPage
            // 
            this._treeProfifle_tabPage.Controls.Add(this.tableLayoutPanel2);
            this._treeProfifle_tabPage.Location = new System.Drawing.Point(4, 22);
            this._treeProfifle_tabPage.Margin = new System.Windows.Forms.Padding(0);
            this._treeProfifle_tabPage.Name = "_treeProfifle_tabPage";
            this._treeProfifle_tabPage.Size = new System.Drawing.Size(500, 410);
            this._treeProfifle_tabPage.TabIndex = 1;
            this._treeProfifle_tabPage.Text = "Tree Profiles";
            this._treeProfifle_tabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.ForestGreen;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this._treeProfifle_DGV, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this._treeProfile_Add_BTN, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this._treeProfile_Delete_BTN, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(500, 410);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // _treeProfifle_DGV
            // 
            this._treeProfifle_DGV.AutoGenerateColumns = false;
            this._treeProfifle_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._treeProfifle_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.speciesDataGridViewTextBoxColumn,
            this.productDataGridViewTextBoxColumn,
            this.liveDeadDataGridViewTextBoxColumn});
            this.tableLayoutPanel2.SetColumnSpan(this._treeProfifle_DGV, 3);
            this._treeProfifle_DGV.DataMember = "TreeProfiles";
            this._treeProfifle_DGV.DataSource = this._viewModel_BS;
            this._treeProfifle_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeProfifle_DGV.Location = new System.Drawing.Point(0, 29);
            this._treeProfifle_DGV.Margin = new System.Windows.Forms.Padding(0);
            this._treeProfifle_DGV.Name = "_treeProfifle_DGV";
            this._treeProfifle_DGV.Size = new System.Drawing.Size(500, 381);
            this._treeProfifle_DGV.TabIndex = 0;
            // 
            // _treeProfile_Add_BTN
            // 
            this._treeProfile_Add_BTN.AutoSize = true;
            this._treeProfile_Add_BTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._treeProfile_Add_BTN.Location = new System.Drawing.Point(3, 3);
            this._treeProfile_Add_BTN.Name = "_treeProfile_Add_BTN";
            this._treeProfile_Add_BTN.Size = new System.Drawing.Size(36, 23);
            this._treeProfile_Add_BTN.TabIndex = 1;
            this._treeProfile_Add_BTN.Text = "Add";
            this._treeProfile_Add_BTN.UseVisualStyleBackColor = true;
            this._treeProfile_Add_BTN.Click += new System.EventHandler(this._treeProfile_Add_BTN_Click);
            // 
            // _treeProfile_Delete_BTN
            // 
            this._treeProfile_Delete_BTN.AutoSize = true;
            this._treeProfile_Delete_BTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._treeProfile_Delete_BTN.Location = new System.Drawing.Point(45, 3);
            this._treeProfile_Delete_BTN.Name = "_treeProfile_Delete_BTN";
            this._treeProfile_Delete_BTN.Size = new System.Drawing.Size(48, 23);
            this._treeProfile_Delete_BTN.TabIndex = 2;
            this._treeProfile_Delete_BTN.Text = "Delete";
            this._treeProfile_Delete_BTN.UseVisualStyleBackColor = true;
            this._treeProfile_Delete_BTN.Click += new System.EventHandler(this._treeProfile_Delete_BTN_Click);
            // 
            // _regression_tabPage
            // 
            this._regression_tabPage.Controls.Add(this.tableLayoutPanel3);
            this._regression_tabPage.Location = new System.Drawing.Point(4, 22);
            this._regression_tabPage.Margin = new System.Windows.Forms.Padding(0);
            this._regression_tabPage.Name = "_regression_tabPage";
            this._regression_tabPage.Size = new System.Drawing.Size(500, 410);
            this._regression_tabPage.TabIndex = 2;
            this._regression_tabPage.Text = "Regression";
            this._regression_tabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.ForestGreen;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this._regression_DGV, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this._regression_add_BTN, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this._regression_delete_BTN, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(500, 410);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // _regression_DGV
            // 
            this._regression_DGV.AutoGenerateColumns = false;
            this._regression_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._regression_DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.speciesDataGridViewTextBoxColumn1,
            this.productDataGridViewTextBoxColumn1,
            this.dBHMinDataGridViewTextBoxColumn,
            this.dBHMaxDataGridViewTextBoxColumn,
            this.regressionModelDataGridViewTextBoxColumn,
            this.coefficientADataGridViewTextBoxColumn,
            this.coefficientBDataGridViewTextBoxColumn,
            this.coefficientCDataGridViewTextBoxColumn});
            this.tableLayoutPanel3.SetColumnSpan(this._regression_DGV, 3);
            this._regression_DGV.DataSource = this._regression_BS;
            this._regression_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this._regression_DGV.Location = new System.Drawing.Point(0, 29);
            this._regression_DGV.Margin = new System.Windows.Forms.Padding(0);
            this._regression_DGV.Name = "_regression_DGV";
            this._regression_DGV.Size = new System.Drawing.Size(500, 381);
            this._regression_DGV.TabIndex = 0;
            // 
            // _regression_add_BTN
            // 
            this._regression_add_BTN.AutoSize = true;
            this._regression_add_BTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._regression_add_BTN.Location = new System.Drawing.Point(3, 3);
            this._regression_add_BTN.Name = "_regression_add_BTN";
            this._regression_add_BTN.Size = new System.Drawing.Size(36, 23);
            this._regression_add_BTN.TabIndex = 1;
            this._regression_add_BTN.Text = "Add";
            this._regression_add_BTN.UseVisualStyleBackColor = true;
            this._regression_add_BTN.Click += new System.EventHandler(this._regression_add_BTN_Click);
            // 
            // _regression_delete_BTN
            // 
            this._regression_delete_BTN.AutoSize = true;
            this._regression_delete_BTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._regression_delete_BTN.Location = new System.Drawing.Point(45, 3);
            this._regression_delete_BTN.Name = "_regression_delete_BTN";
            this._regression_delete_BTN.Size = new System.Drawing.Size(48, 23);
            this._regression_delete_BTN.TabIndex = 2;
            this._regression_delete_BTN.Text = "Delete";
            this._regression_delete_BTN.UseVisualStyleBackColor = true;
            this._regression_delete_BTN.Click += new System.EventHandler(this._regression_delete_BTN_Click);
            // 
            // _treeProfiles_BS
            // 
            this._treeProfiles_BS.DataMember = "TreeProfiles";
            this._treeProfiles_BS.DataSource = this._viewModel_BS;
            // 
            // _regression_BS
            // 
            this._regression_BS.DataMember = "Regressions";
            this._regression_BS.DataSource = this._viewModel_BS;
            // 
            // speciesDataGridViewTextBoxColumn
            // 
            this.speciesDataGridViewTextBoxColumn.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn.HeaderText = "Species";
            this.speciesDataGridViewTextBoxColumn.Name = "speciesDataGridViewTextBoxColumn";
            // 
            // productDataGridViewTextBoxColumn
            // 
            this.productDataGridViewTextBoxColumn.DataPropertyName = "Product";
            this.productDataGridViewTextBoxColumn.HeaderText = "Product";
            this.productDataGridViewTextBoxColumn.Name = "productDataGridViewTextBoxColumn";
            // 
            // liveDeadDataGridViewTextBoxColumn
            // 
            this.liveDeadDataGridViewTextBoxColumn.DataPropertyName = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn.HeaderText = "LiveDead";
            this.liveDeadDataGridViewTextBoxColumn.Name = "liveDeadDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // speciesDataGridViewTextBoxColumn1
            // 
            this.speciesDataGridViewTextBoxColumn1.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn1.HeaderText = "Species";
            this.speciesDataGridViewTextBoxColumn1.Name = "speciesDataGridViewTextBoxColumn1";
            // 
            // productDataGridViewTextBoxColumn1
            // 
            this.productDataGridViewTextBoxColumn1.DataPropertyName = "Product";
            this.productDataGridViewTextBoxColumn1.HeaderText = "Product";
            this.productDataGridViewTextBoxColumn1.Name = "productDataGridViewTextBoxColumn1";
            // 
            // dBHMinDataGridViewTextBoxColumn
            // 
            this.dBHMinDataGridViewTextBoxColumn.DataPropertyName = "DBHMin";
            this.dBHMinDataGridViewTextBoxColumn.HeaderText = "DBHMin";
            this.dBHMinDataGridViewTextBoxColumn.Name = "dBHMinDataGridViewTextBoxColumn";
            // 
            // dBHMaxDataGridViewTextBoxColumn
            // 
            this.dBHMaxDataGridViewTextBoxColumn.DataPropertyName = "DBHMax";
            this.dBHMaxDataGridViewTextBoxColumn.HeaderText = "DBHMax";
            this.dBHMaxDataGridViewTextBoxColumn.Name = "dBHMaxDataGridViewTextBoxColumn";
            // 
            // regressionModelDataGridViewTextBoxColumn
            // 
            this.regressionModelDataGridViewTextBoxColumn.DataPropertyName = "RegressionModel";
            this.regressionModelDataGridViewTextBoxColumn.HeaderText = "RegressionModel";
            this.regressionModelDataGridViewTextBoxColumn.Name = "regressionModelDataGridViewTextBoxColumn";
            // 
            // coefficientADataGridViewTextBoxColumn
            // 
            this.coefficientADataGridViewTextBoxColumn.DataPropertyName = "CoefficientA";
            this.coefficientADataGridViewTextBoxColumn.HeaderText = "CoefficientA";
            this.coefficientADataGridViewTextBoxColumn.Name = "coefficientADataGridViewTextBoxColumn";
            // 
            // coefficientBDataGridViewTextBoxColumn
            // 
            this.coefficientBDataGridViewTextBoxColumn.DataPropertyName = "CoefficientB";
            this.coefficientBDataGridViewTextBoxColumn.HeaderText = "CoefficientB";
            this.coefficientBDataGridViewTextBoxColumn.Name = "coefficientBDataGridViewTextBoxColumn";
            // 
            // coefficientCDataGridViewTextBoxColumn
            // 
            this.coefficientCDataGridViewTextBoxColumn.DataPropertyName = "CoefficientC";
            this.coefficientCDataGridViewTextBoxColumn.HeaderText = "CoefficientC";
            this.coefficientCDataGridViewTextBoxColumn.Name = "coefficientCDataGridViewTextBoxColumn";
            // 
            // EditTvolView
            // 
            this.Controls.Add(this._tabControl);
            this.Name = "EditTvolView";
            this.Size = new System.Drawing.Size(508, 436);
            this._tabControl.ResumeLayout(false);
            this._sale_tabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._viewModel_BS)).EndInit();
            this._treeProfifle_tabPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._treeProfifle_DGV)).EndInit();
            this._regression_tabPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._regression_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._treeProfiles_BS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._regression_BS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion Designer Generated

        
    }
}