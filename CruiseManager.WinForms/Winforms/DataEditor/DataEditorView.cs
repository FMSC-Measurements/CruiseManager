using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using CruiseDAL;
using FMSC.Utility.Collections;
using CruiseManager.Core.Models;
using CruiseManager.Core.App;

namespace CruiseManager.WinForms.DataEditor
{
    public partial class DataEditorView : Form
    {

        #region Constants
        //place holder objects for "All" filter
        private readonly CuttingUnitDO ANY_OPTION_CUTTINGUNIT =
            new CuttingUnitDO
            {
                Code = "All"
            };

        private readonly StratumDO ANY_OPTION_STRATUM =
            new StratumDO
            {
                Code = "All"
            };

        private readonly SampleGroupDO ANY_OPTION_SAMPLEGROUP =
            new SampleGroupDO
            {
                Code = "All"
            };

        private readonly TreeDefaultValueDO ANY_OPTION_TREEDEFAULT =
            new TreeDefaultValueDO
            {
                Species = "All"
            };

        const string CUTTING_UNIT_COLUMN_NAME = "Cutting Unit";
        const string STRATUM_COLUMN_NAME = "Stratum";
        const string SAMPLEGROUP_COLUMN_NAME = "Sample Group";
        const string DEFAULTS_COLUMN_NAME = "Defaults";
        const string TREENUMBER_COLUMN_NAME = "Tree Number";
        const string COUNT_SPECIES_COLUMN_NAME = "Species";
        #endregion

        protected DataEditorView() 
        {
            InitializeComponent();
        }

        public DataEditorView(WindowPresenter windowPresenter, ApplicationControllerBase applicationController) : this()
        {
            this.WindowPresenter = windowPresenter;
            this.ApplicationController = applicationController;
            
            this.Text = "Field Data - " + System.IO.Path.GetFileName(applicationController.Database.Path);                        
       
            this._BS_TreeSpecies.DataSource = applicationController.Database.Read<TreeDefaultValueDO>("TreeDefaultValue", null);

            this._BS_TreeSampleGroups.DataSource = applicationController.Database.Read<SampleGroupDO>("SampleGroup", null);
            //ResetViewFilters();
        }

        DAL Database { get { return this.ApplicationController.Database; } }
        WindowPresenter WindowPresenter { get; set; }
        ApplicationControllerBase ApplicationController { get; set; }

        bool SuppressUpdates { get; set; }

        bool TreeDataDirty { get; set; }
        

        #region Data set stuff
        public List<ErrorLogDO> ErrorLogs { get; set; }

        public List<StratumDO> Strata
        {
            get { return StratumBindingSource.DataSource as List<StratumDO>; }
            set 
            {
                SuppressUpdates = true;
                value.Insert(0, ANY_OPTION_STRATUM);
                StratumBindingSource.DataSource = value;
                if (StratumBindingSource.Contains(_stratumFilter))
                {
                    StratumBindingSource.Position = StratumBindingSource.IndexOf(_stratumFilter);
                }
                else
                {
                    StratumBindingSource.Position = 0;
                }
                SuppressUpdates = false;
            }
        }
        public List<CuttingUnitDO> CuttingUnits
        {
            get { return CuttingUnitBindingSource.DataSource as List<CuttingUnitDO>; }
            set 
            {
                SuppressUpdates = true;
                value.Insert(0, ANY_OPTION_CUTTINGUNIT); 
                CuttingUnitBindingSource.DataSource = value;
                if (CuttingUnitBindingSource.Contains(_CuttingUnitFilter))
                {
                    CuttingUnitBindingSource.Position = CuttingUnitBindingSource.IndexOf(_CuttingUnitFilter);
                }
                else
                {
                    CuttingUnitBindingSource.Position = 0;
                }
                SuppressUpdates = false;
            }
        }

        public List<SampleGroupDO> SampleGroups
        {
            get { return SampleGroupBindingSource.DataSource as List<SampleGroupDO>; }
            set
            {
                SuppressUpdates = true;
                value.Insert(0, ANY_OPTION_SAMPLEGROUP); 
                SampleGroupBindingSource.DataSource = value;
                if (SampleGroupBindingSource.Contains(_sampleGroupFilter))
                {
                    SampleGroupBindingSource.Position = SampleGroupBindingSource.IndexOf(_sampleGroupFilter);
                }
                else
                {
                    SampleGroupBindingSource.Position = 0;
                }
                SuppressUpdates = false;
            }
        }

        public List<TreeDefaultValueDO> TreeDefaults
        {
            get { return TreeDefaultBindingSource.DataSource as List<TreeDefaultValueDO>; }
            set
            {
                SuppressUpdates = true;
                value.Insert(0, ANY_OPTION_TREEDEFAULT); 
                TreeDefaultBindingSource.DataSource = value;
                if (TreeDefaultBindingSource.Contains(_treeDefaultValueFilter))
                {
                    TreeDefaultBindingSource.Position = TreeDefaultBindingSource.IndexOf(_treeDefaultValueFilter);
                }
                else
                {
                    TreeDefaultBindingSource.Position = 0;
                }
                SuppressUpdates = false;
            }
        }

        public BindingList<TreeVM> Trees
        {
            get { return _BS_Trees.DataSource as BindingList<TreeVM>; }
            set { _BS_Trees.DataSource = value; }
        }
       
        public BindingList<LogVM> Logs
        {
            get { return _BS_.DataSource as BindingList<LogVM>; }
            set { _BS_.DataSource = value; }
        }

        public BindingList<PlotDO> Plots
        {
            get { return _BS_Plots.DataSource as BindingList<PlotDO>; }
            set { _BS_Plots.DataSource = value; }
        }

        public BindingList<CountTreeDO> Counts
        {
            get { return _BS_Counts.DataSource as BindingList<CountTreeDO>; }
            set { _BS_Counts.DataSource = value; }
        }

        public bool CanSelectSampleGroup
        {
            get { return SampleGroupComboBox.Enabled; }
            set { SampleGroupComboBox.Enabled = value; }
        }
        public bool CanSelectTreeDefaultValue
        {
            get { return TreeDefaultComboBox.Enabled; }
            set { TreeDefaultComboBox.Enabled = value; }
        }

        #endregion

        #region filter selections

        private CuttingUnitDO _CuttingUnitFilter;
        public CuttingUnitDO CuttingUnitFilter
        {
            get
            {
                if (Object.ReferenceEquals(_CuttingUnitFilter, ANY_OPTION_CUTTINGUNIT))
                { return null; }
                else
                { return _CuttingUnitFilter; }
            }
            set
            {
                this._CuttingUnitFilter = value;
                OnCuttingUnitFilterChanged();
                PopulateData();
            }
        }

        private StratumDO _stratumFilter;
        public StratumDO StratumFilter
        {
            get
            {
                if (Object.ReferenceEquals(_stratumFilter, ANY_OPTION_STRATUM))
                { return null; }
                else
                { return _stratumFilter; }
            }
            set
            {
                this._stratumFilter = value;
                OnStratumFilterChanged();
                PopulateData();
            }
        }

        private SampleGroupDO _sampleGroupFilter;
        public SampleGroupDO SampleGroupFilter
        {
            get
            {
                if (Object.ReferenceEquals(_sampleGroupFilter, ANY_OPTION_SAMPLEGROUP))
                { return null; }
                else
                { return _sampleGroupFilter; }
            }
            set
            {
                _sampleGroupFilter = value;
                OnSampleGroupFilterChanged();
                PopulateData();
            }
        }



        private TreeDefaultValueDO _treeDefaultValueFilter;
        public TreeDefaultValueDO TreeDefaultValueFilter
        {
            get
            {
                if (Object.ReferenceEquals(_treeDefaultValueFilter, ANY_OPTION_TREEDEFAULT))
                { return null; }
                else
                { return _treeDefaultValueFilter; }
            }
            set
            {
                _treeDefaultValueFilter = value;
                PopulateData();
            }
        }
        #endregion

        #region filter event handlers
        private void CuttingUnitBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!SuppressUpdates)
            {
                CuttingUnitFilter = CuttingUnitBindingSource.Current as CuttingUnitDO;
            }
        }

        private void StratumBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!SuppressUpdates)
            {
                StratumFilter = StratumBindingSource.Current as StratumDO;
            }
        }

        private void SampleGroupBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!SuppressUpdates)
            {
                SampleGroupFilter = SampleGroupBindingSource.Current as SampleGroupDO;
            }
        }

        private void TreeDefaultBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!SuppressUpdates)
            {
                TreeDefaultValueFilter = TreeDefaultBindingSource.Current as TreeDefaultValueDO;
            }
        }

        void OnSampleGroupFilterChanged()
        {
            if (this.DesignMode == true) { return; }
            //if sample group given
            if (SampleGroupFilter != null)
            {
                //populate list of tree defaults for given sample group
                if (SampleGroupFilter.TreeDefaultValues.IsPopulated == false)
                {
                    SampleGroupFilter.TreeDefaultValues.Populate();
                }
                TreeDefaults = SampleGroupFilter.TreeDefaultValues.ToList();
            }
            else
            {
                //populate tree default selection list with all tree defaults
                TreeDefaults = new List<TreeDefaultValueDO>();
            }
        }

        void OnStratumFilterChanged()
        {
            if (this.DesignMode == true) { return; }
            //if all stratum selected
            if (StratumFilter == null)
            {
                //read all cutting units
                this.CuttingUnits = Database.Read<CuttingUnitDO>("CuttingUnit", null, null);
                //and disable ability to select samplegroup or tree default
                _sampleGroupFilter = ANY_OPTION_SAMPLEGROUP;
                _treeDefaultValueFilter = ANY_OPTION_TREEDEFAULT;
                CanSelectSampleGroup = false;
                CanSelectTreeDefaultValue = false;
            }
            else
            {
                //load cutting unit selection list with all cutting units in stratum
                if (StratumFilter.CuttingUnits.IsPopulated == false)
                {
                    StratumFilter.CuttingUnits.Populate();
                }
                this.CuttingUnits = StratumFilter.CuttingUnits.ToList();
                //load sample group selection list with all sample groups in stratum
                this.SampleGroups = Database.Read<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", StratumFilter.Stratum_CN.ToString());
                //and enable ability to select sample group and tree default
                CanSelectSampleGroup = true;
                CanSelectTreeDefaultValue = true;
            }
        }

        void OnCuttingUnitFilterChanged()
        {
            if (this.DesignMode == true) { return; }
            //if cutting unit not given
            if (CuttingUnitFilter == null)
            {
                //populate stratum selection list with all stratum
                this.Strata = Database.Read<StratumDO>("Stratum", null, null);
            }
            else
            {
                //populate stratum selection with stratum in cutting unit
                if (CuttingUnitFilter.Strata.IsPopulated == false)
                {
                    CuttingUnitFilter.Strata.Populate();
                }
                this.Strata = CuttingUnitFilter.Strata.ToList();
            }

        }
        #endregion


        protected override void OnLoad(EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.ResetViewFilters();//initialize filters and load data

                this.RebuildErrors();

                base.OnLoad(e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _DGV_Trees.EndEdit();
            _DGV_Logs.EndEdit();
            _DGV_Plots.EndEdit();
            _DGV_Counts.EndEdit();
            _DGV_Errors.EndEdit();
        }

        private void ResetViewFilters()
        {
            _CuttingUnitFilter = ANY_OPTION_CUTTINGUNIT;
            _stratumFilter = ANY_OPTION_STRATUM;
            _sampleGroupFilter = ANY_OPTION_SAMPLEGROUP;
            _treeDefaultValueFilter = ANY_OPTION_TREEDEFAULT;

            OnCuttingUnitFilterChanged();
            OnStratumFilterChanged();
            PopulateData();
        }

        private void PopulateData()
        {
            if (this.DesignMode == true) { return; }

            PopulateTreeData();
            this.Logs = new FMSC.Utility.Collections.SortableBindingList<LogVM>(ReadLogs(CuttingUnitFilter, StratumFilter, SampleGroupFilter, TreeDefaultValueFilter));
            this.Plots = new FMSC.Utility.Collections.SortableBindingList<PlotDO>(ReadPlots(CuttingUnitFilter, StratumFilter));
            var countList = new FMSC.Utility.Collections.SortableBindingList<CountTreeDO>(ReadCounts(CuttingUnitFilter, StratumFilter, SampleGroupFilter));
            countList.SetPropertyComparer("Component", new ComponentComparer());
            this.Counts = countList;
            

            this.ValidateData();
        }

        void PopulateTreeData()
        {
            //populate tree, log, plot, and count lists with selected unit, stratum, samplegroup, and defaults, if given
            var treeList = new FMSC.Utility.Collections.SortableBindingList<TreeVM>(ReadTrees(CuttingUnitFilter, StratumFilter, SampleGroupFilter, TreeDefaultValueFilter));
            treeList.SetPropertyComparer("TreeDefaultValue", new TreeDefaultSpeciesComparer());
            this.Trees = treeList;
        }


        private void ValidateData()
        {
            foreach (TreeVM tree in Trees)
            {
                tree.Validate();

            }

            foreach (LogVM log in Logs)
            {

                log.Validate();
            }
        }

        private void RebuildErrors()
        {
            this.Database.Execute("DELETE FROM ErrorLog WHERE TableName in ('Tree','Log') AND Suppress = 0;");
            foreach (TreeVM tree in Trees)
            {
                tree.PurgeErrorList();
                if (tree.Stratum.FieldsArray != null
                && !tree.Validate(tree.Stratum.FieldsArray))
                {
                    tree.SaveErrors();
                }
            }
        }

        #region read methods

        protected List<TreeVM> ReadTrees(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg, TreeDefaultValueDO tdv)
        {
            var selectionList = new List<string>();
            var selectionArgs = new List<string>();
            if (cu != null)
            {
                selectionList.Add(CruiseDAL.Schema.TREE.CUTTINGUNIT_CN + " = ?");
                selectionArgs.Add(cu.CuttingUnit_CN.ToString());
            }
            if (st != null)
            {
                selectionList.Add( "Tree." + CruiseDAL.Schema.TREE.STRATUM_CN + " = ?");
                selectionArgs.Add(st.Stratum_CN.ToString());
            }
            if (sg != null)
            {
                selectionList.Add(CruiseDAL.Schema.TREE.SAMPLEGROUP_CN + " = ?");
                selectionArgs.Add(sg.SampleGroup_CN.ToString());
            }
            if (tdv != null)
            {
                selectionList.Add(CruiseDAL.Schema.TREE.TREEDEFAULTVALUE_CN + " = ?");
                selectionArgs.Add(tdv.TreeDefaultValue_CN.ToString());
            }

            
            if (selectionList.Count > 0)
            {
                String selection = "WHERE " + String.Join(" AND ", selectionList.ToArray());
                return Database.Read<TreeVM>(CruiseDAL.Schema.TREE._NAME, selection + " ORDER BY TreeNumber, Plot_CN", selectionArgs.ToArray());
            }
            else
            {

                return Database.Read<TreeVM>(CruiseDAL.Schema.TREE._NAME, "ORDER BY TreeNumber, Plot_CN", null);
            }
        }

        protected List<LogVM> ReadLogs(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg, TreeDefaultValueDO tdv)
        {
            var selectionList = new List<string>();
            var selectionArgs = new List<string>();
            if (cu != null)
            {
                selectionList.Add(String.Format("Tree.{0} = ?", CruiseDAL.Schema.TREE.CUTTINGUNIT_CN));
                selectionArgs.Add(cu.CuttingUnit_CN.ToString());
            }
            if (st != null)
            {
                selectionList.Add(String.Format("Tree.{0} = ?", CruiseDAL.Schema.TREE.STRATUM_CN));
                selectionArgs.Add(st.Stratum_CN.ToString());
            }
            if (sg != null)
            {
                selectionList.Add(String.Format("Tree.{0} = ?", CruiseDAL.Schema.TREE.SAMPLEGROUP_CN));
                selectionArgs.Add(sg.SampleGroup_CN.ToString());
            }
            if (tdv != null)
            {
                selectionList.Add(String.Format("Tree.{0} = ?", CruiseDAL.Schema.TREE.TREEDEFAULTVALUE_CN));
                selectionArgs.Add(tdv.TreeDefaultValue_CN.ToString());
            }
            if (selectionList.Count > 0)
            {
                String selection = "WHERE " + String.Join(" AND ", selectionList.ToArray());
                //return DAL.Read<LogDO>(CruiseDAL.Schema.LOG._NAME, "INNER JOIN Tree USING Tree_CN " + selection, selectionArgs.ToArray());
                return Database.Read<LogVM>(CruiseDAL.Schema.LOG._NAME, selection, selectionArgs.ToArray());//since we are using LogVM we don't need to join tree, it already joins Tree
            }
            else
            {
                return Database.Read<LogVM>(CruiseDAL.Schema.LOG._NAME, null, null);
            }
        }

        protected List<PlotDO> ReadPlots(CuttingUnitDO cu, StratumDO st)
        {
            var selectionList = new List<string>();
            var selectionArgs = new List<string>();
            if (cu != null)
            {
                selectionList.Add(String.Format("{0} = ?", CruiseDAL.Schema.TREE.CUTTINGUNIT_CN));
                selectionArgs.Add(cu.CuttingUnit_CN.ToString());
            }
            if (st != null)
            {
                selectionList.Add(String.Format("{0} = ?", CruiseDAL.Schema.TREE.STRATUM_CN));
                selectionArgs.Add(st.Stratum_CN.ToString());
            }

            if (selectionList.Count > 0)
            {
                String selection = "WHERE " + String.Join(" AND ", selectionList.ToArray());
                return Database.Read<PlotDO>(CruiseDAL.Schema.PLOT._NAME, selection, selectionArgs.ToArray());
            }
            else
            {
                return Database.Read<PlotDO>(CruiseDAL.Schema.PLOT._NAME, null, null);
            }
        }

        protected List<CountTreeDO> ReadCounts(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg)
        {
            var selectionList = new List<string>();
            var selectionArgs = new List<string>();
            if (cu != null)
            {
                selectionList.Add(String.Format("CountTree.{0} = ?", CruiseDAL.Schema.COUNTTREE.CUTTINGUNIT_CN));
                selectionArgs.Add(cu.CuttingUnit_CN.ToString());
            }
            if (st != null)
            {
                selectionList.Add(String.Format("SampleGroup.{0} = ?", CruiseDAL.Schema.SAMPLEGROUP.STRATUM_CN));
                selectionArgs.Add(st.Stratum_CN.ToString());
            }
            if (sg != null)
            {
                selectionList.Add(String.Format("CountTree.{0} = ?", CruiseDAL.Schema.COUNTTREE.SAMPLEGROUP_CN));
                selectionArgs.Add(sg.SampleGroup_CN.ToString());
            }

            if (selectionList.Count > 0)
            {
                String selection = String.Join(" AND ", selectionList.ToArray());
                return Database.Read<CountTreeDO>(CruiseDAL.Schema.COUNTTREE._NAME, "JOIN SampleGroup ON CountTree.SampleGroup_CN = SampleGroup.SampleGroup_CN WHERE " + selection, selectionArgs.ToArray());
            }
            else
            {
                return Database.Read<CountTreeDO>(CruiseDAL.Schema.COUNTTREE._NAME, null, null);
            }

        }

        #endregion


        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowPresenter.ShowDataExportDialog(Trees, Logs, Plots, Counts);
            //AppController.ShowDataExportDialog(Trees, Logs, Plots, Counts);
        }

        public void DisplayTrees()
        {
            this.tabControl1.SelectedIndex = 0;
        }

        public void DisplayLogs()
        {
            this.tabControl1.SelectedIndex = 1;
        }

        public void DisplayPlots()
        {
            this.tabControl1.SelectedIndex = 2;
        }

        public void DisplayCounts()
        {
            this.tabControl1.SelectedIndex = 3;
        }

        protected void LocateRecord(String tableName, long rowID)
        {
            CruiseDAL.DataObject record;
            switch (tableName.ToLower())
            {
                case "tree":
                    {
                        record = Database.ReadSingleRow<TreeVM>("Tree", rowID);
                        ResetViewFilters();
                        this._BS_Trees.Position = this._BS_Trees.IndexOf(record);
                        this.DisplayTrees();
                        break;
                    }
                case "log":
                    {

                        record = Database.ReadSingleRow<LogDO>("Log", rowID);
                        ResetViewFilters();
                        this._BS_.Position = this._BS_.IndexOf(record);
                        this.DisplayLogs();
                        break;
                    }
                case "plot":
                    {
                        record = Database.ReadSingleRow<PlotDO>("Plot", rowID);
                        ResetViewFilters();
                        this._BS_Plots.Position = this._BS_Plots.IndexOf(record);
                        this.DisplayPlots();
                        break;
                    }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                if (TreeDataDirty)
                {
                    PopulateTreeData();
                    TreeDataDirty = false;
                }
            }
            //reread errors every time the user enters the errorLog tab
            else if (tabControl1.SelectedTab == tabPage5)
            {
                this.ErrorLogs = Database.Read<ErrorLogDO>("ErrorLog", null);
                this._BS_Errors.DataSource = this.ErrorLogs;
            }


        }
        

        #region Trees page
 
        protected void HandleTreeValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TreeVM tree = null;
            try
            {
                tree = this._BS_Trees[e.RowIndex] as TreeVM;
            }
            catch (ArgumentOutOfRangeException) { return; }//ignore possible out of bound exceptions

            if (tree == null) { return; }

            // if species value changed
            if (speciesDataGridViewColumn != null 
                && e.ColumnIndex == speciesDataGridViewColumn.Index)
            {
                DatabaseExtentions.SetTreeTDV(tree, tree.TreeDefaultValue);
            }
            // if stratum value changed
            else if (stratumDataGridViewTextBoxColumn != null 
                && e.ColumnIndex == stratumDataGridViewTextBoxColumn.Index)
            {
                tree.Species = null;
                tree.SampleGroup = null;
                DatabaseExtentions.SetTreeTDV(tree, null);
            }
            // if sample group value changed
            else if (sampleGroupDataGridViewTextBoxColumn != null 
                && e.ColumnIndex == sampleGroupDataGridViewTextBoxColumn.Index)
            {
                if (!tree.SampleGroup.TreeDefaultValues.Contains(tree.TreeDefaultValue))
                {
                    DatabaseExtentions.SetTreeTDV(tree, null);
                }
            }

            TrySaveTree(tree);
        }
        
        protected void TreeDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            
            var curTree = this._BS_Trees[e.RowIndex] as TreeVM;
            if (curTree == null) { return; }

            var cell = _DGV_Trees[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
            if (cell == null) { return; }

            // if entering sample group column, update sample group selection 
            if (this.sampleGroupDataGridViewTextBoxColumn != null 
                && e.ColumnIndex == this.sampleGroupDataGridViewTextBoxColumn.Index)
            {
                this.UpdateSampleGroupColumn(curTree, cell);
            }

            // if entering species column, update species selection 
            if (this.speciesDataGridViewColumn != null 
                && e.ColumnIndex == this.speciesDataGridViewColumn.Index)
            {
                this.UpdateSpeciesColumn(curTree, cell);
            }
        }

        private void TreeDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var cell = _DGV_Trees[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
            if (cell == null) { return; }
            if (cell.FormattedValue == e.FormattedValue) { return; }//are there any changes 

            TreeVM curTree = null;
            try
            {
                curTree = this._BS_Trees[e.RowIndex] as TreeVM;
                if (curTree == null) { return; }
            }
            catch (SystemException) { return; }//ignore possible out of bound exceptions


            object cellValue = e.FormattedValue;
            cellValue = cell.ParseFormattedValue(cellValue, cell.InheritedStyle, null, null);

            if (stratumDataGridViewTextBoxColumn != null && e.ColumnIndex == stratumDataGridViewTextBoxColumn.Index)
            {
                var newStratum = cellValue as StratumDO;
                if (newStratum == null) { e.Cancel = true; }
                if (curTree.Stratum.Stratum_CN != newStratum.Stratum_CN)
                {
                    e.Cancel = !this.AskYesNo(
                        "You are changing the stratum of a tree\r\n" +
                        "Are you sure you want to do this?", "!", MessageBoxIcon.Asterisk);
                }
            }
            if (sampleGroupDataGridViewTextBoxColumn != null && e.ColumnIndex == sampleGroupDataGridViewTextBoxColumn.Index)
            {
                var newSg = cellValue as SampleGroupDO;
                if (newSg == null) { e.Cancel = true; }
                if (curTree.SampleGroup.SampleGroup_CN != newSg.SampleGroup_CN)
                {
                    e.Cancel = !this.AskYesNo(
                        "You are changing the Sample Group of a tree\r\n" +
                        "Are you sure you want to do this?", "!", MessageBoxIcon.Asterisk);
                }
            }
        }

        private void TreeDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        //private void TreeDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    var tree = e.Row.DataBoundItem as TreeVM;
        //    if (tree == null) { e.Cancel = true; return; }
        //    e.Cancel = !this.TryDeleteTree(tree);
        //}

        protected void UpdateSampleGroupColumn(TreeVM tree, DataGridViewComboBoxCell cell)
        {
            if (cell == null) { return; }
            cell.DataSource = ApplicationController.Database.GetSampleGroupsByStratum(tree.Stratum_CN);
        }

        protected void UpdateSpeciesColumn(TreeVM tree, DataGridViewComboBoxCell cell)
        {
            if (cell == null) { return; }
            cell.DataSource = ApplicationController.Database.GetTreeTDVList(tree);
        }

        protected bool TryDeleteTree(TreeVM tree)
        {
            try
            {
                tree.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool TrySaveTree(TreeVM tree)
        {
            try
            {
                tree.Save();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to save tree. Ensure Tree Number, Sample Group and Stratum are valid");
                //this.HandleNonCriticalException(e, "Unable to save tree. Ensure Tree Number, Sample Group and Stratum are valid");
                return false;
            }
        }


        #endregion

        #region Logs page

        private void _DGV_Logs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.RowIndex > this.Logs.Count) { return; }

            try
            {
                var log = this.Logs[e.RowIndex];
                log.Save();
            }
            catch (ArgumentOutOfRangeException) { return; }
            catch (Exception)
            {
                MessageBox.Show("Unable to save Log.");
            }
        }


        private void _DGV_Logs_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            LogDO log = Logs[e.RowIndex];
            switch (_DGV_Logs.Columns[e.ColumnIndex].HeaderText)
            {
                case CUTTING_UNIT_COLUMN_NAME:
                    {

                        e.Value = log.Tree.CuttingUnit.Code;
                        break;
                    }
                case STRATUM_COLUMN_NAME:
                    {
                        e.Value = log.Tree.Stratum.Code;
                        break;
                    }
                case SAMPLEGROUP_COLUMN_NAME:
                    {
                        e.Value = log.Tree.SampleGroup.Code;
                        break;
                    }
                case DEFAULTS_COLUMN_NAME:
                    {
                        e.Value = string.Format("{0}/{1}/{2}",
                            log.Tree.TreeDefaultValue.Species,
                            log.Tree.TreeDefaultValue.LiveDead,
                            log.Tree.TreeDefaultValue.PrimaryProduct);
                        break;
                    }
                case TREENUMBER_COLUMN_NAME:
                    {
                        e.Value = log.Tree.TreeNumber;
                        break;
                    }
            }
        }

        //private void _DGV_Logs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    var log = e.Row.DataBoundItem as LogDO;
        //    if (log == null) { e.Cancel = true; return; }
        //    e.Cancel = !this.TryDeleteLog(log);
        //}

        protected bool TryDeleteLog(LogDO log)
        {
            try
            {
                log.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion 

        #region Plots page
        private void _DGV_Plots_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > this.Plots.Count) { return; }

            try
            {
                var plot = this.Plots[e.RowIndex];
                plot.Save();
            }
            catch (ArgumentOutOfRangeException) { return; }
            catch (Exception)
            {
                MessageBox.Show("Unable to save changes.");
            }
        }

        //private void _DGV_Plots_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    var plot = e.Row.DataBoundItem as PlotDO;
        //    if (plot == null) { e.Cancel = true; return; }
        //    e.Cancel = !this.DeletePlot(plot); 
        //}

        protected bool TryDeletePlot(PlotDO plot)
        {
            plot.DAL.BeginTransaction();
            try
            {
                
                PlotDO.RecursiveDeletePlot(plot);
                plot.DAL.EndTransaction();
                TreeDataDirty = true;
                return true;
            }
            catch
            {
                plot.DAL.CancelTransaction();
                return false;
            }
        }
        #endregion 

        #region Counts page

        private void _DGV_Counts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > this.Counts.Count) { return; }

            try
            {
                var count = this.Counts[e.RowIndex];
                count.Save();
            }
            catch (ArgumentOutOfRangeException) { return; }
            catch (Exception)
            {
                MessageBox.Show("Unable to save changes.");
            }
        }

        #endregion

        #region Errors page
        private void _DGV_Errors_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            var errorLog = _BS_Errors[e.RowIndex] as ErrorLogDO;
            if (errorLog == null) { return; }
            this.LocateRecord(errorLog.TableName, errorLog.CN_Number);
        }

        private void _DGV_Errors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            var errorLog = _BS_Errors[e.RowIndex] as ErrorLogDO;
            if (errorLog == null) { return; }
            this.LocateRecord(errorLog.TableName, errorLog.CN_Number);
        }

        private void _DGV_Errors_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > _BS_Errors.Count) { return; }
                        
            try
            {
                var eLog = _BS_Errors[e.RowIndex] as ErrorLogDO;
                if (eLog == null) { return; }

                eLog.Save();
            }
            catch (ArgumentOutOfRangeException) { return; }
            catch (Exception)
            {
                MessageBox.Show("Unable to save changes.");
            }
        }
        #endregion 

        #region context menu
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dgv = _ContextMenu.SourceControl as DataGridView;//get the DataGridView control that the menu is being displayed for
            System.Diagnostics.Debug.Assert(dgv != null);
            if (dgv == null)
            {
                //for some reason SourceControl is null or not a DataGridView so don't continue. 
                return;
            }

            try
            {
                Point p = _ContextMenu.Location;//because the context menu displays at the location the user clicked we can use it to determine the row number
                p = dgv.PointToClient(p);//convert location relative to datagrid
                int x = p.X;
                int y = p.Y;

                System.Windows.Forms.DataGridView.HitTestInfo ht = dgv.HitTest(x, y);//get row location from screen point
                int rowIndex = ht.RowIndex;
                if (rowIndex >= 0 && //check to see if row index if valid 
                    (ht.Type == DataGridViewHitTestType.Cell || ht.Type == DataGridViewHitTestType.RowHeader))
                {
                    DataGridViewRow row = dgv.Rows[rowIndex];
                    Type dataType = row.DataBoundItem.GetType();
                    if (dataType.IsAssignableFrom(typeof(TreeVM)))
                    {
                        var tree = row.DataBoundItem as TreeVM;
                        if (this.TryDeleteTree(tree))
                        {
                            dgv.Rows.RemoveAt(rowIndex);
                        }
                    }
                    else if (dataType.IsAssignableFrom(typeof(LogDO)))
                    {
                        var log = row.DataBoundItem as LogDO;
                        if (this.TryDeleteLog(log))
                        {
                            dgv.Rows.RemoveAt(rowIndex);
                        }
                    }
                    else if (dataType.IsAssignableFrom(typeof(PlotDO)))
                    {
                        var plot = row.DataBoundItem as PlotDO;
                        if (this.TryDeletePlot(plot))
                        {
                            dgv.Rows.RemoveAt(rowIndex);
                        }
                        //CountTreeDO ct = row.DataBoundItem as CountTreeDO;
                    }

                }
            }
            catch
            {
                //just in case HitTest or point to client throws exception
            }
        }

        private void _ContextMenu_Opening(object sender, CancelEventArgs e)
        {
            var dgv = _ContextMenu.SourceControl as DataGridView;//get the DataGridView control that the menu is being displayed for
            if (dgv == null) { return; }
            try
            {
                Point p = _ContextMenu.Location;//because the context menu displays at the location the user clicked we can use it to determine the row number
                p = dgv.PointToClient(p);//convert location relative to datagrid
                int x = p.X;
                int y = p.Y;

                System.Windows.Forms.DataGridView.HitTestInfo ht = dgv.HitTest(x, y);//get row location from screen point
                if (!(ht.Type == DataGridViewHitTestType.Cell || ht.Type == DataGridViewHitTestType.RowHeader))
                {
                    e.Cancel = true;
                }
            }
            catch
            {
            }

        }
        #endregion 

        public bool AskYesNo(String message, String caption, MessageBoxIcon icon)
        {
            return DialogResult.Yes == MessageBox.Show(message, caption, MessageBoxButtons.YesNo, icon, MessageBoxDefaultButton.Button2);
        }

        public bool AskYesNo(String message, String caption, MessageBoxIcon icon, bool defaultNo)
        {
            return DialogResult.Yes == MessageBox.Show(message,
                caption,
                MessageBoxButtons.YesNo,
                icon,
                (defaultNo) ? MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button1);
        }

        
    }

        
}
