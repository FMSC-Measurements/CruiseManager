using CruiseDAL.DataObjects;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.Models;
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
        private System.Windows.Forms.BindingNavigator speciesBindingNavigator;
        private System.Windows.Forms.ToolStripButton speciesBindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton speciesBindingNavigatorDeleteItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TableLayoutPanel _logGradeAuditSelectPanel;
        private System.Windows.Forms.ComboBox _speciesOptComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel _logGradeAuditEditPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.BindingSource _logAuditSpeciesBindingSource;
        private System.Windows.Forms.BindingNavigator logGradeAuditBindingNavigator;
        private System.Windows.Forms.ToolStripButton logGradeAuditBindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton logGradeAuditBindingNavigatorDeleteItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

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
            }
        }

        protected override void OnViewPresenterChanged()
        {
            base.OnViewPresenterChanged();
            var presenter = ViewPresenter;
            if (presenter != null)
            {
                _speciesOptComboBox.DataSource = presenter.SpeciesOptions;

                _logAuditSpeciesBindingSource.DataSource = presenter.LogGradeSpecies;
            }
        }

        private void speciesBindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var curItem = _logAuditSpeciesBindingSource.Current as LogGradeSpecies;
            if (curItem == null) { return; }
            var viewModel = ViewPresenter;
            viewModel.DeleteSpecies(curItem);
        }

        private void logGradeAuditBindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var species = _logAuditSpeciesBindingSource.Current as LogGradeSpecies;
            if (species == null) { return; }
            var logGradeAudit = _logAuditsBindingSource.Current as LogGradeAuditRule;
            if (logGradeAudit == null) { return; }
            ViewPresenter.DeleteLogAudit(species, logGradeAudit);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripLabel toolStripLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogGradeAuditRuleView));
            this._logAuditsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._logAuditSpeciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.speciesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.speciesBindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.speciesBindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this._logGradeAuditSelectPanel = new System.Windows.Forms.TableLayoutPanel();
            this._speciesOptComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.logGradeAuditBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.logGradeAuditBindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.logGradeAuditBindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this._logGradeAuditEditPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this._logAuditsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._logAuditSpeciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speciesBindingNavigator)).BeginInit();
            this.speciesBindingNavigator.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this._logGradeAuditSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGradeAuditBindingNavigator)).BeginInit();
            this.logGradeAuditBindingNavigator.SuspendLayout();
            this.panel3.SuspendLayout();
            this._logGradeAuditEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            toolStripLabel1.Text = "Species:";
            // 
            // _logAuditsBindingSource
            // 
            this._logAuditsBindingSource.DataSource = typeof(CruiseManager.Core.CruiseCustomize.Models.LogGradeAuditRule);
            this._logAuditsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this._logAuditsBindingSource_AddingNew);
            this._logAuditsBindingSource.CurrentChanged += new System.EventHandler(this._logAuditsBindingSource_CurrentChanged);
            // 
            // _logAuditSpeciesBindingSource
            // 
            this._logAuditSpeciesBindingSource.DataSource = typeof(CruiseManager.Core.CruiseCustomize.LogGradeSpecies);
            this._logAuditSpeciesBindingSource.CurrentChanged += new System.EventHandler(this._logAuditSpeciesBindingSource_CurrentChanged);
            // 
            // speciesBindingNavigator
            // 
            this.speciesBindingNavigator.AddNewItem = this.speciesBindingNavigatorAddNewItem;
            this.speciesBindingNavigator.BindingSource = this._logAuditSpeciesBindingSource;
            this.speciesBindingNavigator.CountItem = null;
            this.speciesBindingNavigator.DeleteItem = this.speciesBindingNavigatorDeleteItem;
            this.speciesBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.speciesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel1,
            this.speciesBindingNavigatorAddNewItem,
            this.speciesBindingNavigatorDeleteItem});
            this.speciesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.speciesBindingNavigator.MoveFirstItem = null;
            this.speciesBindingNavigator.MoveLastItem = null;
            this.speciesBindingNavigator.MoveNextItem = null;
            this.speciesBindingNavigator.MovePreviousItem = null;
            this.speciesBindingNavigator.Name = "speciesBindingNavigator";
            this.speciesBindingNavigator.PositionItem = null;
            this.speciesBindingNavigator.Size = new System.Drawing.Size(115, 25);
            this.speciesBindingNavigator.TabIndex = 1;
            this.speciesBindingNavigator.Text = "bindingNavigator1";
            // 
            // speciesBindingNavigatorAddNewItem
            // 
            this.speciesBindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.speciesBindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("speciesBindingNavigatorAddNewItem.Image")));
            this.speciesBindingNavigatorAddNewItem.Name = "speciesBindingNavigatorAddNewItem";
            this.speciesBindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.speciesBindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.speciesBindingNavigatorAddNewItem.Text = "Add new";
            // 
            // speciesBindingNavigatorDeleteItem
            // 
            this.speciesBindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.speciesBindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("speciesBindingNavigatorDeleteItem.Image")));
            this.speciesBindingNavigatorDeleteItem.Name = "speciesBindingNavigatorDeleteItem";
            this.speciesBindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.speciesBindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.speciesBindingNavigatorDeleteItem.Text = "Delete";
            this.speciesBindingNavigatorDeleteItem.Click += new System.EventHandler(this.speciesBindingNavigatorDeleteItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.52301F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.47699F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._logGradeAuditSelectPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 439);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.speciesBindingNavigator);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(115, 433);
            this.panel1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this._logAuditSpeciesBindingSource;
            this.listBox1.DisplayMember = "Species";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(115, 408);
            this.listBox1.TabIndex = 2;
            // 
            // _logGradeAuditSelectPanel
            // 
            this._logGradeAuditSelectPanel.ColumnCount = 5;
            this._logGradeAuditSelectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._logGradeAuditSelectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._logGradeAuditSelectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this._logGradeAuditSelectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._logGradeAuditSelectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this._logGradeAuditSelectPanel.Controls.Add(this._speciesOptComboBox, 1, 0);
            this._logGradeAuditSelectPanel.Controls.Add(this.label1, 0, 0);
            this._logGradeAuditSelectPanel.Controls.Add(this.listBox2, 0, 2);
            this._logGradeAuditSelectPanel.Controls.Add(this.logGradeAuditBindingNavigator, 3, 2);
            this._logGradeAuditSelectPanel.Controls.Add(this.label4, 0, 1);
            this._logGradeAuditSelectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logGradeAuditSelectPanel.Enabled = false;
            this._logGradeAuditSelectPanel.Location = new System.Drawing.Point(124, 3);
            this._logGradeAuditSelectPanel.Name = "_logGradeAuditSelectPanel";
            this._logGradeAuditSelectPanel.RowCount = 3;
            this._logGradeAuditSelectPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._logGradeAuditSelectPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._logGradeAuditSelectPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._logGradeAuditSelectPanel.Size = new System.Drawing.Size(351, 205);
            this._logGradeAuditSelectPanel.TabIndex = 4;
            // 
            // _speciesOptComboBox
            // 
            this._speciesOptComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._logAuditSpeciesBindingSource, "Species", true));
            this._speciesOptComboBox.FormattingEnabled = true;
            this._speciesOptComboBox.Location = new System.Drawing.Point(54, 3);
            this._speciesOptComboBox.Name = "_speciesOptComboBox";
            this._speciesOptComboBox.Size = new System.Drawing.Size(72, 21);
            this._speciesOptComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Species";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox2
            // 
            this._logGradeAuditSelectPanel.SetColumnSpan(this.listBox2, 3);
            this.listBox2.DataSource = this._logAuditsBindingSource;
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 50);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(160, 152);
            this.listBox2.TabIndex = 2;
            // 
            // logGradeAuditBindingNavigator
            // 
            this.logGradeAuditBindingNavigator.AddNewItem = this.logGradeAuditBindingNavigatorAddNewItem;
            this.logGradeAuditBindingNavigator.BindingSource = this._logAuditsBindingSource;
            this.logGradeAuditBindingNavigator.CountItem = null;
            this.logGradeAuditBindingNavigator.DeleteItem = this.logGradeAuditBindingNavigatorDeleteItem;
            this.logGradeAuditBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.logGradeAuditBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logGradeAuditBindingNavigatorAddNewItem,
            this.logGradeAuditBindingNavigatorDeleteItem});
            this.logGradeAuditBindingNavigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.logGradeAuditBindingNavigator.Location = new System.Drawing.Point(166, 47);
            this.logGradeAuditBindingNavigator.MoveFirstItem = null;
            this.logGradeAuditBindingNavigator.MoveLastItem = null;
            this.logGradeAuditBindingNavigator.MoveNextItem = null;
            this.logGradeAuditBindingNavigator.MovePreviousItem = null;
            this.logGradeAuditBindingNavigator.Name = "logGradeAuditBindingNavigator";
            this.logGradeAuditBindingNavigator.PositionItem = null;
            this.logGradeAuditBindingNavigator.Size = new System.Drawing.Size(24, 48);
            this.logGradeAuditBindingNavigator.TabIndex = 3;
            this.logGradeAuditBindingNavigator.Text = "bindingNavigator2";
            // 
            // logGradeAuditBindingNavigatorAddNewItem
            // 
            this.logGradeAuditBindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logGradeAuditBindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("logGradeAuditBindingNavigatorAddNewItem.Image")));
            this.logGradeAuditBindingNavigatorAddNewItem.Name = "logGradeAuditBindingNavigatorAddNewItem";
            this.logGradeAuditBindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.logGradeAuditBindingNavigatorAddNewItem.Size = new System.Drawing.Size(22, 20);
            this.logGradeAuditBindingNavigatorAddNewItem.Text = "Add new";
            // 
            // logGradeAuditBindingNavigatorDeleteItem
            // 
            this.logGradeAuditBindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logGradeAuditBindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("logGradeAuditBindingNavigatorDeleteItem.Image")));
            this.logGradeAuditBindingNavigatorDeleteItem.Name = "logGradeAuditBindingNavigatorDeleteItem";
            this.logGradeAuditBindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.logGradeAuditBindingNavigatorDeleteItem.Size = new System.Drawing.Size(22, 20);
            this.logGradeAuditBindingNavigatorDeleteItem.Text = "Delete";
            this.logGradeAuditBindingNavigatorDeleteItem.Click += new System.EventHandler(this.logGradeAuditBindingNavigatorDeleteItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this._logGradeAuditSelectPanel.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rule Deffinitions";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this._logGradeAuditEditPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(124, 214);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(351, 222);
            this.panel3.TabIndex = 3;
            // 
            // _logGradeAuditEditPanel
            // 
            this._logGradeAuditEditPanel.ColumnCount = 3;
            this._logGradeAuditEditPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._logGradeAuditEditPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._logGradeAuditEditPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._logGradeAuditEditPanel.Controls.Add(this.label2, 0, 0);
            this._logGradeAuditEditPanel.Controls.Add(this.label3, 0, 1);
            this._logGradeAuditEditPanel.Controls.Add(this.textBox1, 1, 0);
            this._logGradeAuditEditPanel.Controls.Add(this.textBox2, 1, 1);
            this._logGradeAuditEditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logGradeAuditEditPanel.Enabled = false;
            this._logGradeAuditEditPanel.Location = new System.Drawing.Point(0, 0);
            this._logGradeAuditEditPanel.Name = "_logGradeAuditEditPanel";
            this._logGradeAuditEditPanel.RowCount = 3;
            this._logGradeAuditEditPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._logGradeAuditEditPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._logGradeAuditEditPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._logGradeAuditEditPanel.Size = new System.Drawing.Size(349, 220);
            this._logGradeAuditEditPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Max Log Defect";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Log Grades";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._logAuditsBindingSource, "DefectMax", true));
            this.textBox1.Location = new System.Drawing.Point(92, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._logAuditsBindingSource, "ValidGrades", true));
            this.textBox2.Location = new System.Drawing.Point(92, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // LogGradeAuditRuleView
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LogGradeAuditRuleView";
            this.Size = new System.Drawing.Size(478, 439);
            ((System.ComponentModel.ISupportInitialize)(this._logAuditsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._logAuditSpeciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speciesBindingNavigator)).EndInit();
            this.speciesBindingNavigator.ResumeLayout(false);
            this.speciesBindingNavigator.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._logGradeAuditSelectPanel.ResumeLayout(false);
            this._logGradeAuditSelectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGradeAuditBindingNavigator)).EndInit();
            this.logGradeAuditBindingNavigator.ResumeLayout(false);
            this.logGradeAuditBindingNavigator.PerformLayout();
            this.panel3.ResumeLayout(false);
            this._logGradeAuditEditPanel.ResumeLayout(false);
            this._logGradeAuditEditPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void _logAuditSpeciesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var item = _logAuditSpeciesBindingSource.Current as LogGradeSpecies;

            _logAuditsBindingSource.DataSource = (object)item ?? new LogGradeAuditRuleDO[0];
            _logGradeAuditSelectPanel.Enabled = item != null;
        }

        private void _logAuditsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var item = _logAuditsBindingSource.Current as LogGradeAuditRuleDO;
            _logGradeAuditEditPanel.Enabled = item != null;
        }

        private void _logAuditsBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            e.NewObject = ViewPresenter.MakeLogGradeAudit();
        }
    }
}