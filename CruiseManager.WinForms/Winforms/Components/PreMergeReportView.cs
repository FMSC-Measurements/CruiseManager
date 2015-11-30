using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core.Components;

namespace CruiseManager.WinForms.Components
{
    public partial class PreMergeReportView : UserControl
    {
        private class ViewDataLink
        {
            public ViewDataLink(MergeTableCommandBuilder bldr)
            {
                this.CmdBldr = bldr;
            }

            public MergeTableCommandBuilder CmdBldr;
            public DataGridView ConflictsDGV;
            public DataGridView MatchDGV; 
            public DataGridView NewDGV; 
            //public DataGridView DeletedDGV; 
            public BindingSource ConflictsDataSource;
            public BindingSource MatchDataSource; 
            public BindingSource NewDataSource; 
            //public BindingSource DeletedDataSource; 
        }


        public PreMergeReportView(MergeComponentsPresenter viewPresenter)
        {
            this.ViewPresenter = viewPresenter; 
            InitializeComponent();


            InitializeTableByTableViews();

        }

        List<ViewDataLink> _viewDataLinks; 

        MergeComponentsPresenter ViewPresenter { get; set; }

        public DataGridViewColumn[] BuildDGVColumns()
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
                new DataGridViewTextBoxColumn(){ DataPropertyName = "MasterRowVersion", HeaderText = "MasterRowVersion", ReadOnly = true},
                new DataGridViewTextBoxColumn(){ DataPropertyName = "ComponentRowVersion", HeaderText = "ComponentRowVersion", ReadOnly = true},
                //new DataGridViewTextBoxColumn(){ DataPropertyName = "ComponentConflict", HeaderText = "ComponentConflict", ReadOnly = true},
                //new DataGridViewTextBoxColumn(){ DataPropertyName = "ComponentConflictFileID", HeaderText = "ComponentConflictFileID", ReadOnly = true},
                //new DataGridViewTextBoxColumn(){ DataPropertyName = "MatchConflict", HeaderText = "MatchConflict", ReadOnly = true}
            };
            return cols;
        }


        public void InitializeTableByTableViews()
        {
            _viewDataLinks = (from MergeTableCommandBuilder bldr in ViewPresenter.CommandBuilders.Values
                                                      select new ViewDataLink(bldr)).ToList();


            foreach (ViewDataLink thing in _viewDataLinks)
            {
                TabPage tp = new TabPage(Text = thing.CmdBldr.ClientTableName);
                tp.SuspendLayout();

                thing.ConflictsDataSource = new BindingSource(typeof(MergeObject), (string)null);

                thing.ConflictsDGV = new DataGridView(){
                    AllowUserToAddRows = false, 
                    AllowUserToDeleteRows = false,
                    AllowUserToOrderColumns = false, 
                    AllowUserToResizeColumns = false, 
                    AllowUserToResizeRows = false, 
                    AutoGenerateColumns = false,
                    Dock = DockStyle.Fill
                };
                thing.ConflictsDGV.DataSource = thing.ConflictsDataSource;

                thing.ConflictsDGV.Columns.AddRange(BuildDGVColumns());

                tp.Controls.Add(thing.ConflictsDGV);

                _TH_conflicts.TabPages.Add(tp);
                tp.ResumeLayout();
            }

            foreach (ViewDataLink thing in _viewDataLinks)
            {
                TabPage tp = new TabPage(Text = thing.CmdBldr.ClientTableName);
                tp.SuspendLayout();

                thing.MatchDataSource = new BindingSource(typeof(MergeObject), (string)null);

                thing.MatchDGV = new DataGridView(){
                    AllowUserToAddRows = false, 
                    AllowUserToDeleteRows = false,
                    AllowUserToOrderColumns = false, 
                    AllowUserToResizeColumns = false, 
                    AllowUserToResizeRows = false,
                    AutoGenerateColumns = false,
                    Dock = DockStyle.Fill
                };
                thing.MatchDGV.DataSource = thing.MatchDataSource;
                thing.MatchDGV.Columns.AddRange(BuildDGVColumns());

                tp.Controls.Add(thing.MatchDGV);

                _TH_matches.TabPages.Add(tp);
                tp.ResumeLayout();
            }

            foreach (ViewDataLink thing in _viewDataLinks)
            {
                TabPage tp = new TabPage(Text = thing.CmdBldr.ClientTableName);
                tp.SuspendLayout();

                thing.NewDataSource = new BindingSource(typeof(MergeObject), (string)null);

                thing.NewDGV = new DataGridView()
                {
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    AllowUserToOrderColumns = false,
                    AllowUserToResizeColumns = false,
                    AllowUserToResizeRows = false,
                    AutoGenerateColumns = false,
                    Dock = DockStyle.Fill,
                    DataSource = thing.NewDataSource
                };
                thing.NewDGV.Columns.AddRange(BuildDGVColumns());

                tp.Controls.Add(thing.NewDGV);

                _TH_additions.TabPages.Add(tp);
                tp.ResumeLayout();
            }

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


        public void UpdateView()
        {
            foreach (ViewDataLink link in _viewDataLinks)
            {
                link.ConflictsDataSource.DataSource = this.ViewPresenter.ListConflicts(link.CmdBldr);
            }
        }

        private bool _matchesLoaded = false;
        

        private void _TP_matches_Enter(object sender, EventArgs e)
        {

            if (!_matchesLoaded)
            {
                foreach (ViewDataLink link in _viewDataLinks)
                {
                    link.MatchDataSource.DataSource = this.ViewPresenter.ListMatches(link.CmdBldr);
                }
                _matchesLoaded = true;
            }
        }


        private bool _newLoaded = false;
        private void _TP_new_Enter(object sender, EventArgs e)
        {
            if (!_newLoaded)
            {
                foreach (ViewDataLink link in _viewDataLinks)
                {
                    link.NewDataSource.DataSource = this.ViewPresenter.ListNew(link.CmdBldr);
                }
                _newLoaded = true;
            }
        }

        //private bool _deletedLoaded = false;
        //private void _TP_deletions_Enter(object sender, EventArgs e)
        //{
        //    if (!_deletedLoaded)
        //    {
        //        foreach (ViewDataLink link in _viewDataLinks)
        //        {
        //            link.DeletedDataSource.DataSource = this.Presenter.ListDeleted(link.CmdBldr);
        //        }
        //        _deletedLoaded = true;
        //    }
        //}

    }
}
