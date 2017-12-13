using CruiseManager.Core.Tvol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvol.Data;

namespace CruiseManager.WinForms.Tvol
{
    public class EditTvolDataView : UserControlView
    {
        public new EditTvolDataPresenter ViewPresenter
        {
            get { return (EditTvolDataPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }

        }

        protected override void OnViewPresenterChanged()
        {
            base.OnViewPresenterChanged();
            var vp = ViewPresenter;
            if(vp != null)
            {
                vp.PropertyChanged += Vp_PropertyChanged;

                _trees_BS.DataSource = vp.Trees;
            }
        }

        private void Vp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        protected EditTvolDataView()
        {
            InitializeComponent();

            liveDeadDataGridViewTextBoxColumn.Items.AddRange(
                new string[]
                {
                    "L",
                    "D"
                });
        }

        public EditTvolDataView(EditTvolDataPresenter presenter) : this()
        {
            ViewPresenter = presenter;
        }

        #region Designer Generated
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button _add_BTN;
        private System.Windows.Forms.Button _delete_BTN;
        private System.Windows.Forms.BindingSource _viewPresenter_BS;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.BindingSource _trees_BS;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn liveDeadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dBHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._trees_BS = new System.Windows.Forms.BindingSource(this.components);
            this._add_BTN = new System.Windows.Forms.Button();
            this._delete_BTN = new System.Windows.Forms.Button();
            this._viewPresenter_BS = new System.Windows.Forms.BindingSource(this.components);
            this.speciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveDeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dBHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._trees_BS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._viewPresenter_BS)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.ForestGreen;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._add_BTN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._delete_BTN, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 404);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.speciesDataGridViewTextBoxColumn,
            this.productDataGridViewTextBoxColumn,
            this.liveDeadDataGridViewTextBoxColumn,
            this.dBHDataGridViewTextBoxColumn,
            this.heightDataGridViewTextBoxColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.DataSource = this._trees_BS;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(474, 375);
            this.dataGridView1.TabIndex = 0;
            // 
            // _trees_BS
            // 
            this._trees_BS.DataSource = typeof(Tree);
            // 
            // _add_BTN
            // 
            this._add_BTN.AutoSize = true;
            this._add_BTN.Location = new System.Drawing.Point(3, 3);
            this._add_BTN.Name = "_add_BTN";
            this._add_BTN.Size = new System.Drawing.Size(36, 23);
            this._add_BTN.TabIndex = 1;
            this._add_BTN.Text = "Add";
            this._add_BTN.UseVisualStyleBackColor = true;
            this._add_BTN.Click += new System.EventHandler(this._add_BTN_Click);
            // 
            // _delete_BTN
            // 
            this._delete_BTN.AutoSize = true;
            this._delete_BTN.Location = new System.Drawing.Point(45, 3);
            this._delete_BTN.Name = "_delete_BTN";
            this._delete_BTN.Size = new System.Drawing.Size(48, 23);
            this._delete_BTN.TabIndex = 2;
            this._delete_BTN.Text = "Delete";
            this._delete_BTN.UseVisualStyleBackColor = true;
            this._delete_BTN.Click += new System.EventHandler(this._delete_BTN_Click);
            // 
            // _viewPresenter_BS
            // 
            this._viewPresenter_BS.DataSource = typeof(CruiseManager.Core.Tvol.EditTvolDataPresenter);
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
            this.liveDeadDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.liveDeadDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dBHDataGridViewTextBoxColumn
            // 
            this.dBHDataGridViewTextBoxColumn.DataPropertyName = "DBH";
            this.dBHDataGridViewTextBoxColumn.HeaderText = "DBH";
            this.dBHDataGridViewTextBoxColumn.Name = "dBHDataGridViewTextBoxColumn";
            // 
            // heightDataGridViewTextBoxColumn
            // 
            this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
            this.heightDataGridViewTextBoxColumn.HeaderText = "Height";
            this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
            // 
            // EditTvolDataView
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EditTvolDataView";
            this.Size = new System.Drawing.Size(474, 404);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._trees_BS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._viewPresenter_BS)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void _add_BTN_Click(object sender, EventArgs e)
        {
            ViewPresenter.AddTree();
        }

        private void _delete_BTN_Click(object sender, EventArgs e)
        {
            var currTree = _trees_BS.Current as Tree;
            if (currTree == null) return;

            ViewPresenter.DeleteTree(currTree);
        }
    }
}
