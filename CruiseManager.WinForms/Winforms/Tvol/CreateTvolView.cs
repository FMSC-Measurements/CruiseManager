using CruiseManager.Core.Tvol;
using CruiseManager.WinForms.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Tvol
{
    public class CreateTvolView : UserControlView
    {
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox _directory_TB;
        private Button _create_btn;
        private BindingSource _viewDataSource;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button __browse_btn;

        public ApplicationController App { get; set; }

        private CreateTvolView() : base()
        {
            InitializeComponent();
        }

        public CreateTvolView(CreateTvolPresenter presenter) : this()
        {
            base.ViewPresenter = presenter;

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.Windows.Forms.Label label2;
            this._directory_TB = new System.Windows.Forms.TextBox();
            this.@__browse_btn = new System.Windows.Forms.Button();
            this._create_btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._viewDataSource = new System.Windows.Forms.BindingSource(this.components);
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._viewDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(this.@__browse_btn, 2, 0);
            tableLayoutPanel2.Controls.Add(this._create_btn, 1, 1);
            tableLayoutPanel2.Controls.Add(this._directory_TB, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(42, 74);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new System.Drawing.Size(402, 230);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(23, 26);
            label2.TabIndex = 2;
            label2.Text = "File";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _directory_TB
            // 
            this._directory_TB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._viewDataSource, "FilePath", true));
            this._directory_TB.Location = new System.Drawing.Point(32, 3);
            this._directory_TB.Name = "_directory_TB";
            this._directory_TB.Size = new System.Drawing.Size(207, 20);
            this._directory_TB.TabIndex = 3;
            // 
            // __browse_btn
            // 
            this.@__browse_btn.Location = new System.Drawing.Point(245, 3);
            this.@__browse_btn.Name = "__browse_btn";
            this.@__browse_btn.Size = new System.Drawing.Size(75, 20);
            this.@__browse_btn.TabIndex = 4;
            this.@__browse_btn.Text = "Browse";
            this.@__browse_btn.UseVisualStyleBackColor = true;
            this.@__browse_btn.Click += new System.EventHandler(this.@__browse_btn_Click);
            // 
            // _create_btn
            // 
            this._create_btn.Location = new System.Drawing.Point(32, 29);
            this._create_btn.Name = "_create_btn";
            this._create_btn.Size = new System.Drawing.Size(75, 23);
            this._create_btn.TabIndex = 5;
            this._create_btn.Text = "Create";
            this._create_btn.UseVisualStyleBackColor = true;
            this._create_btn.Click += new System.EventHandler(this._create_btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.515571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.48443F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.46043F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.53957F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 472);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _viewDataSource
            // 
            this._viewDataSource.DataSource = typeof(CruiseManager.Core.Tvol.CreateTvolPresenter);
            // 
            // CreateTvolView
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CreateTvolView";
            this.Size = new System.Drawing.Size(556, 472);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._viewDataSource)).EndInit();
            this.ResumeLayout(false);

        }


        public new CreateTvolPresenter ViewPresenter
        {
            get { return base.ViewPresenter as CreateTvolPresenter; }
            set { base.ViewPresenter = value; }
        }

        //protected override void OnViewPresenterChanging()
        //{
        //    base.OnViewPresenterChanging();
        //}

        protected override void OnViewPresenterChanged()
        {
            base.OnViewPresenterChanged();
            var vp = ViewPresenter;

            //vp.PropertyChanged += ViewPresenter_PropertyChanged;
            _viewDataSource.DataSource = vp;

        }

        //private void ViewPresenter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == nameof(CreateTvolPresenter.FilePath))
        //    {
        //        _directory_TB.SelectionStart = Math.Max(_directory_TB.Text.Count() - 1, 0);
        //    }
        //}

        private void __browse_btn_Click(object sender, EventArgs e)
        {
            using (var sfd = new System.Windows.Forms.SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.CreatePrompt = false;//don't ask user for permission to create file, if it doesn't exist
                sfd.OverwritePrompt = true;//warn user if overwriting file

                sfd.Filter = "tvol files (*.tvol)|*.tvol";
                sfd.FilterIndex = 0;


                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    ViewPresenter.FilePath = sfd.FileName;
                    _directory_TB.SelectionStart = Math.Max(_directory_TB.Text.Count(), 0);
                }
            }
        }

        private void _create_btn_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true;
                _create_btn.Enabled = false;
                
                ViewPresenter.CreateFile();
            }
            catch(Core.App.UserFacingException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UseWaitCursor = false;
                _create_btn.Enabled = true;
            }
        }
    }
}
