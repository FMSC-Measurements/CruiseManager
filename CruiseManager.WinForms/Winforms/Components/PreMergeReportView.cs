using CruiseManager.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Components
{
    public partial class PreMergeReportView : UserControl
    {
        private MergeComponentsPresenter _viewModel;

        public IEnumerable<PreMergeTableReport> Reports { get; }

        public PreMergeReportView(MergeComponentsPresenter viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            
            var reports = viewModel.GetPreMergeReports();
            InitializeReportTabs(reports);
        }

        protected MergeComponentsPresenter ViewModel 
        {
            get => _viewModel;
            set
            {
                if(_viewModel !=  null)
                { OnViewModelChangeing(_viewModel); }
                _viewModel = value;
                if(value != null)
                { OnViewModelChanged(value); }
            }
        }

        private void OnViewModelChangeing(MergeComponentsPresenter oldVM)
        {
            oldVM.PropertyChanged -= ViewModel_PropertyChanged;
            oldVM.MergeLog.LogChanged -= MergeLog_LogChanged;
        }

        private void OnViewModelChanged(MergeComponentsPresenter newVM)
        {
            newVM.MergeLog.LogChanged += MergeLog_LogChanged;
            newVM.PropertyChanged += ViewModel_PropertyChanged;

            _goButton.Enabled = newVM.CanMerge;

        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        private void MergeLog_LogChanged(object sender, string e)
        {
            _progressMessageTB.Text = e;
        }

        protected void InitializeReportTabs(IEnumerable<PreMergeTableReport> reports)
        {
            foreach(var report in reports)
            {
                var tableTabHost = new TabControl();

                var errorsDGV = new DataGridView()
                {
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToOrderColumns = false,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AutoGenerateColumns = false,
                    Dock = DockStyle.Fill,
                    DataSource = report.Errors,
                };
                errorsDGV.Columns.AddRange(BuildDGVColumns());

                var errorsPage = new TabPage() { Text = "Errors" };
                errorsPage.Controls.Add(errorsDGV);
                tableTabHost.TabPages.Add(errorsPage);

                var matchesDGV = new DataGridView()
                {
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToOrderColumns = false,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AutoGenerateColumns = false,
                    Dock = DockStyle.Fill,
                    DataSource = report.Matches,
                };
                matchesDGV.Columns.AddRange(BuildDGVColumns());

                var matchesPage = new TabPage() { Text = "Matches" };
                matchesPage.Controls.Add(matchesDGV);
                tableTabHost.TabPages.Add(matchesPage);

                var additionsDGV = new DataGridView()
                {
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToOrderColumns = false,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AutoGenerateColumns = false,
                    Dock = DockStyle.Fill,
                    DataSource = report.Additions,
                };
                additionsDGV.Columns.AddRange(BuildDGVColumns());

                var additionsPage = new TabPage() { Text = "Additions" };
                additionsPage.Controls.Add(additionsDGV);
                tableTabHost.TabPages.Add(additionsPage);

                var tablePage = new TabPage() { Text = report.TableName, };
                tablePage.Controls.Add(tableTabHost);
                tabControl1.TabPages.Add(tablePage);
            }



            //_viewDataLinks = (from MergeTableCommandBuilder bldr in ViewPresenter.CommandBuilders.Values
            //                  select new ViewDataLink(bldr)).ToList();

            //foreach (ViewDataLink thing in _viewDataLinks)
            //{
            //    TabPage tp = new TabPage(Text = thing.CmdBldr.ClientTableName);
            //    tp.SuspendLayout();

            //    thing.ConflictsDataSource = new BindingSource(typeof(MergeObject), (string)null);

            //    thing.ConflictsDGV = new DataGridView()
            //    {
            //        AllowUserToAddRows = false,
            //        AllowUserToDeleteRows = false,
            //        AllowUserToOrderColumns = false,
            //        AllowUserToResizeColumns = false,
            //        AllowUserToResizeRows = false,
            //        AutoGenerateColumns = false,
            //        Dock = DockStyle.Fill
            //    };
            //    thing.ConflictsDGV.DataSource = thing.ConflictsDataSource;

            //    thing.ConflictsDGV.Columns.AddRange(BuildDGVColumns());

            //    tp.Controls.Add(thing.ConflictsDGV);

            //    _TH_conflicts.TabPages.Add(tp);
            //    tp.ResumeLayout();
            //}

            //foreach (ViewDataLink thing in _viewDataLinks)
            //{
            //    TabPage tp = new TabPage(Text = thing.CmdBldr.ClientTableName);
            //    tp.SuspendLayout();

            //    thing.MatchDataSource = new BindingSource(typeof(MergeObject), (string)null);

            //    thing.MatchDGV = new DataGridView()
            //    {
            //        AllowUserToAddRows = false,
            //        AllowUserToDeleteRows = false,
            //        AllowUserToOrderColumns = false,
            //        AllowUserToResizeColumns = false,
            //        AllowUserToResizeRows = false,
            //        AutoGenerateColumns = false,
            //        Dock = DockStyle.Fill
            //    };
            //    thing.MatchDGV.DataSource = thing.MatchDataSource;
            //    thing.MatchDGV.Columns.AddRange(BuildDGVColumns());

            //    tp.Controls.Add(thing.MatchDGV);

            //    _TH_matches.TabPages.Add(tp);
            //    tp.ResumeLayout();
            //}

            //foreach (ViewDataLink thing in _viewDataLinks)
            //{
            //    TabPage tp = new TabPage(Text = thing.CmdBldr.ClientTableName);
            //    tp.SuspendLayout();

            //    thing.NewDataSource = new BindingSource(typeof(MergeObject), (string)null);

            //    thing.NewDGV = new DataGridView()
            //    {
            //        AllowUserToAddRows = false,
            //        AllowUserToDeleteRows = false,
            //        AllowUserToOrderColumns = false,
            //        AllowUserToResizeColumns = false,
            //        AllowUserToResizeRows = false,
            //        AutoGenerateColumns = false,
            //        Dock = DockStyle.Fill,
            //        DataSource = thing.NewDataSource
            //    };
            //    thing.NewDGV.Columns.AddRange(BuildDGVColumns());

            //    tp.Controls.Add(thing.NewDGV);

            //    _TH_additions.TabPages.Add(tp);
            //    tp.ResumeLayout();
            //}

            //foreach (ViewDataLink thing in _viewDataLinks)
            //{
            //    TabPage tp = new TabPage(Text = thing.CmdBldr.ClientTableName);
            //    tp.SuspendLayout();

            //    thing.DeletedDataSource = new BindingSource(typeof(MergeObject), (string)null);

            //    thing.DeletedDGV = new DataGridView()
            //    {
            //        AllowUserToAddRows = false,
            //        AllowUserToDeleteRows = false,
            //        AllowUserToOrderColumns = false,
            //        AllowUserToResizeColumns = false,
            //        AllowUserToResizeRows = false,
            //        AutoGenerateColumns = false,
            //        Dock = DockStyle.Fill,
            //        DataSource = thing.DeletedDataSource
            //    };

            //    thing.DeletedDGV.Columns.AddRange(BuildDGVColumns());

            //    tp.Controls.Add(thing.DeletedDGV);

            //    _TH_deletions.TabPages.Add(tp);
            //    tp.ResumeLayout();
            //}
        }

        protected DataGridViewColumn[] BuildDGVColumns()
        {
            DataGridViewColumn[] cols = {
                new DataGridViewTextBoxColumn(){ DataPropertyName = "MergeRowID", HeaderText = "Merge Track ID", ReadOnly = true },
                new DataGridViewTextBoxColumn(){ DataPropertyName = "SiblingRecords", HeaderText = "SiblingRecords", ReadOnly = true },
                new DataGridViewTextBoxColumn(){ DataPropertyName = "NaturalSiblings", HeaderText = "NaturalSiblings", ReadOnly = true },
                new DataGridViewTextBoxColumn(){ DataPropertyName = "MatchRowID", HeaderText = "Full Match", ReadOnly = true },
                new DataGridViewTextBoxColumn(){ DataPropertyName = "PartialMatch", HeaderText = "PartialMatch", ReadOnly = true },
                new DataGridViewTextBoxColumn(){ DataPropertyName = "ComponentRowID", HeaderText = "Component Row ID", ReadOnly = true },
                new DataGridViewTextBoxColumn(){ DataPropertyName = "ComponentID", HeaderText = "Component File Number", ReadOnly = true},
                new DataGridViewTextBoxColumn(){ DataPropertyName = "GUIDMatch", HeaderText = "GUIDMatch", ReadOnly = true},
                new DataGridViewTextBoxColumn(){ DataPropertyName = "RowIDMatch", HeaderText = "RowIDMatch", ReadOnly = true},
                new DataGridViewTextBoxColumn(){ DataPropertyName = "NaturalMatch", HeaderText = "NaturalMatch", ReadOnly = true},
                new DataGridViewTextBoxColumn(){ DataPropertyName = "ParentRowVersion", HeaderText = "MasterRowVersion", ReadOnly = true},
                new DataGridViewTextBoxColumn(){ DataPropertyName = "ComponentRowVersion", HeaderText = "ComponentRowVersion", ReadOnly = true},
                //new DataGridViewTextBoxColumn(){ DataPropertyName = "ComponentConflict", HeaderText = "ComponentConflict", ReadOnly = true},
                //new DataGridViewTextBoxColumn(){ DataPropertyName = "ComponentConflictFileID", HeaderText = "ComponentConflictFileID", ReadOnly = true},
                //new DataGridViewTextBoxColumn(){ DataPropertyName = "MatchConflict", HeaderText = "MatchConflict", ReadOnly = true}
            };
            return cols;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            ViewModel.Cancel();
        }

        private async void _goButton_Click(object sender, EventArgs e)
        {
            _goButton.Enabled = false;
            _cancelButton.Enabled = true;
            var (result, exception) = await ViewModel.RunMerge();
            _cancelButton.Enabled = false;

            if (result)
            { MessageBox.Show("Done"); }
            else
            {
                if(exception != null)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}