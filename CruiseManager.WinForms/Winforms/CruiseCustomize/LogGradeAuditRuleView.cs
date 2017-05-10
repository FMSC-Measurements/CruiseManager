using CruiseDAL.DataObjects;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public class LogGradeAuditRuleView : UserControlView, ILogGradeAuditView
    {
        private System.Windows.Forms.BindingSource _logAuditsBindingSource;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn fieldNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valuesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speciesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defectMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidGrades;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;

        public new LogAuditRulePresenter ViewPresenter
        {
            get { return (LogAuditRulePresenter)base.ViewPresenter; }
            set
            {
                base.ViewPresenter = value;
            }
        }

        protected LogGradeAuditRuleView()
        {
            this.InitializeComponent();
        }

        public LogGradeAuditRuleView(LogAuditRulePresenter presenter) : this()
        {
            ViewPresenter = presenter;
        }

        protected override void OnViewPresenterChanging()
        {
            base.OnViewPresenterChanging();
            var presenter = ViewPresenter;
            if (presenter != null)
            {
                presenter.LogGradeAuditsChanged -= ViewPresenter_LogGradeAuditsChanged;
                presenter.LogGradeAuditsModified -= ViewPresenter_LogGradeAuditsModified;
            }
        }

        protected override void OnViewPresenterChanged()
        {
            base.OnViewPresenterChanged();
            var presenter = ViewPresenter;
            if (presenter != null)
            {
                presenter.LogGradeAuditsChanged += ViewPresenter_LogGradeAuditsChanged;
                presenter.LogGradeAuditsModified += ViewPresenter_LogGradeAuditsModified;
                ViewPresenter_LogGradeAuditsModified();
            }
        }

        private void ViewPresenter_LogGradeAuditsModified()
        {
            _logAuditsBindingSource.ResetBindings(false);
        }

        private void ViewPresenter_LogGradeAuditsChanged()
        {
            var logAudits = ViewPresenter.LogGradeAudits;
            _logAuditsBindingSource.DataSource = logAudits ?? new LogGradeAuditRuleDO[0];

            bindingNavigatorDeleteItem.Enabled = logAudits != null;
            bindingNavigatorAddNewItem.Enabled = logAudits != null;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var curItem = _logAuditsBindingSource.Current as LogGradeAuditRuleDO;
            if (curItem == null) { return; }
            var viewModel = ViewPresenter;
            viewModel.DeleteLogAudit(curItem);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            var viewModel = ViewPresenter;
            viewModel.AddLogAudit();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogGradeAuditRuleView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._logAuditsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.speciesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defectMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidGrades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._logAuditsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // dataGridView1
            //
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.speciesDataGridViewTextBoxColumn,
            this.defectMaxDataGridViewTextBoxColumn,
            this.ValidGrades});
            this.dataGridView1.DataSource = this._logAuditsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(302, 408);
            this.dataGridView1.TabIndex = 0;
            //
            // _logAuditsBindingSource
            //
            this._logAuditsBindingSource.DataSource = typeof(CruiseDAL.DataObjects.LogGradeAuditRuleDO);
            //
            // bindingNavigator1
            //
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(478, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            //
            // bindingNavigatorAddNewItem
            //
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            //
            // bindingNavigatorDeleteItem
            //
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.64435F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.35565F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 414);
            this.tableLayoutPanel1.TabIndex = 2;
            //
            // speciesDataGridViewTextBoxColumn
            //
            this.speciesDataGridViewTextBoxColumn.DataPropertyName = "Species";
            this.speciesDataGridViewTextBoxColumn.HeaderText = "Tree Species";
            this.speciesDataGridViewTextBoxColumn.Name = "speciesDataGridViewTextBoxColumn";
            this.speciesDataGridViewTextBoxColumn.Width = 50;
            //
            // defectMaxDataGridViewTextBoxColumn
            //
            this.defectMaxDataGridViewTextBoxColumn.DataPropertyName = "DefectMax";
            this.defectMaxDataGridViewTextBoxColumn.HeaderText = "Tree Defect Max";
            this.defectMaxDataGridViewTextBoxColumn.Name = "defectMaxDataGridViewTextBoxColumn";
            this.defectMaxDataGridViewTextBoxColumn.Width = 50;
            //
            // ValidGrades
            //
            this.ValidGrades.DataPropertyName = "ValidGrades";
            this.ValidGrades.HeaderText = "Valid Grades";
            this.ValidGrades.Name = "ValidGrades";
            this.ValidGrades.Width = 50;
            //
            // LogGradeAuditRuleView
            //
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bindingNavigator1);
            this.Name = "LogGradeAuditRuleView";
            this.Size = new System.Drawing.Size(478, 439);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._logAuditsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}