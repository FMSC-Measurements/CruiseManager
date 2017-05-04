using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.EditFieldData;
using CruiseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

        #endregion Constants

        protected DataEditorView()
        {
            InitializeComponent();
        }

        public DataEditorView(WindowPresenter windowPresenter, ApplicationControllerBase applicationController) : this()
        {
            WindowPresenter = windowPresenter;
            ApplicationController = applicationController;

            Text = "Field Data - " + System.IO.Path.GetFileName(applicationController.Database.Path);

            _BS_TreeSpecies.DataSource = applicationController.Database.From<TreeDefaultValueDO>().Read().ToList();

            _BS_TreeSampleGroups.DataSource = applicationController.Database.From<SampleGroupDO>().Read().ToList();
            //ResetViewFilters();
        }

        DAL Database { get { return ApplicationController.Database; } }
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
            get { return _BS_Logs.DataSource as BindingList<LogVM>; }
            set { _BS_Logs.DataSource = value; }
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

        #endregion Data set stuff

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
                _CuttingUnitFilter = value;
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
                _stratumFilter = value;
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

        #endregion filter selections

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
            if (DesignMode == true) { return; }
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
            if (DesignMode == true) { return; }
            //if all stratum selected
            if (StratumFilter == null)
            {
                //read all cutting units
                CuttingUnits = Database.From<CuttingUnitDO>().Read().ToList();
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
                CuttingUnits = StratumFilter.CuttingUnits.ToList();
                //load sample group selection list with all sample groups in stratum
                SampleGroups = Database.From<SampleGroupDO>()
                    .Where("Stratum_CN = ?").Read(StratumFilter.Stratum_CN).ToList();
                //and enable ability to select sample group and tree default
                CanSelectSampleGroup = true;
                CanSelectTreeDefaultValue = true;
            }
        }

        void OnCuttingUnitFilterChanged()
        {
            if (DesignMode == true) { return; }
            //if cutting unit not given
            if (CuttingUnitFilter == null)
            {
                //populate stratum selection list with all stratum
                Strata = Database.From<StratumDO>().Read().ToList();
            }
            else
            {
                //populate stratum selection with stratum in cutting unit
                if (CuttingUnitFilter.Strata.IsPopulated == false)
                {
                    CuttingUnitFilter.Strata.Populate();
                }
                Strata = CuttingUnitFilter.Strata.ToList();
            }
        }

        #endregion filter event handlers

        protected override void OnLoad(EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                ResetViewFilters();//initialize filters and load data

                RebuildErrors();

                base.OnLoad(e);
            }
            finally
            {
                Cursor = Cursors.Default;
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
            if (DesignMode == true) { return; }

            PopulateTreeData();
            Logs = new FMSC.Utility.Collections.SortableBindingList<LogVM>(ReadLogs(CuttingUnitFilter, StratumFilter, SampleGroupFilter, TreeDefaultValueFilter));
            Plots = new FMSC.Utility.Collections.SortableBindingList<PlotDO>(ReadPlots(CuttingUnitFilter, StratumFilter));
            var countList = new FMSC.Utility.Collections.SortableBindingList<CountTreeDO>(ReadCounts(CuttingUnitFilter, StratumFilter, SampleGroupFilter));
            countList.SetPropertyComparer("Component", new ComponentComparer());
            Counts = countList;

            ValidateData();
        }

        void PopulateTreeData()
        {
            //populate tree, log, plot, and count lists with selected unit, stratum, samplegroup, and defaults, if given
            var treeList = new FMSC.Utility.Collections.SortableBindingList<TreeVM>(ReadTrees(CuttingUnitFilter, StratumFilter, SampleGroupFilter, TreeDefaultValueFilter));
            treeList.SetPropertyComparer("TreeDefaultValue", new TreeDefaultSpeciesComparer());
            treeList.SetPropertyComparer("SampleGroup", new SampleGroupCodeComparer());
            Trees = treeList;
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
            Database.Execute("DELETE FROM ErrorLog WHERE TableName in ('Tree','Log') AND Suppress = 0;");
            Database.ClearCache(typeof(ErrorLogDO));
            foreach (TreeVM tree in Trees)
            {
                tree.PurgeErrorList();

                var treeFields = tree.Stratum.FieldsArray;
                if (treeFields == null || treeFields.Length == 0) { continue; }

                if (!tree.Validate(tree.Stratum.FieldsArray))
                {
                    tree.SaveErrors();
                }
            }
        }

        #region read methods

        public List<TreeVM> ReadTrees(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg, TreeDefaultValueDO tdv)
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
                selectionList.Add("Tree." + CruiseDAL.Schema.TREE.STRATUM_CN + " = ?");
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
                var selection = String.Join(" AND ", selectionList.ToArray());
                return Database.From<TreeVM>()
                    .Where(selection).OrderBy("TreeNumber", "Plot_CN").Read(selectionArgs.ToArray<Object>()).ToList();
            }
            else
            {
                return Database.From<TreeVM>().OrderBy("TreeNumber", "Plot_CN").Read().ToList();
            }
        }

        public List<LogVM> ReadLogs(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg, TreeDefaultValueDO tdv)
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
                var selection = String.Join(" AND ", selectionList.ToArray());
                //return DAL.Read<LogDO>(CruiseDAL.Schema.LOG._NAME, "INNER JOIN Tree USING Tree_CN " + selection, selectionArgs.ToArray());
                return Database.From<LogVM>().Where(selection).Read(selectionArgs.ToArray<object>()).ToList();
            }
            else
            {
                return Database.From<LogVM>().Read().ToList();
            }
        }

        public List<PlotDO> ReadPlots(CuttingUnitDO cu, StratumDO st)
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
                var selection = String.Join(" AND ", selectionList.ToArray());
                return Database.From<PlotDO>().Where(selection).Read(selectionArgs.ToArray<object>()).ToList();
            }
            else
            {
                return Database.From<PlotDO>().Read().ToList();
            }
        }

        public List<CountTreeDO> ReadCounts(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg)
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
                var selection = String.Join(" AND ", selectionList.ToArray());
                return Database.From<CountTreeDO>().Join("SampleGroup", "USING (SampleGroup_CN)")
                    .Where(selection).Read(selectionArgs.ToArray<object>()).ToList();
            }
            else
            {
                return Database.From<CountTreeDO>().Read().ToList();
            }
        }

        #endregion read methods

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowPresenter.ShowDataExportDialog(Trees, Logs, Plots, Counts);
        }

        public void DisplayTrees()
        {
            tabControl1.SelectedIndex = 0;
        }

        public void DisplayLogs()
        {
            tabControl1.SelectedIndex = 1;
        }

        public void DisplayPlots()
        {
            tabControl1.SelectedIndex = 2;
        }

        public void DisplayCounts()
        {
            tabControl1.SelectedIndex = 3;
        }

        protected void LocateRecord(String tableName, long rowID)
        {
            CruiseDAL.DataObject record;
            switch (tableName.ToLower())
            {
                case "tree":
                    {
                        record = Database.From<TreeVM>()
                            .Where("Tree.Tree_CN = ?").Read(rowID).FirstOrDefault();
                        ResetViewFilters();
                        _BS_Trees.Position = _BS_Trees.IndexOf(record);
                        DisplayTrees();
                        break;
                    }
                case "log":
                    {
                        record = Database.From<LogDO>().Where("Log.Log_CN = ?")
                            .Read(rowID).FirstOrDefault();
                        ResetViewFilters();
                        _BS_Logs.Position = _BS_Logs.IndexOf(record);
                        DisplayLogs();
                        break;
                    }
                case "plot":
                    {
                        record = Database.From<PlotDO>()
                            .Where("Plot.Plot_CN = ?").Read(rowID).FirstOrDefault();
                        ResetViewFilters();
                        _BS_Plots.Position = _BS_Plots.IndexOf(record);
                        DisplayPlots();
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
                ErrorLogs = Database.From<ErrorLogDO>().Read().ToList();
                _BS_Errors.DataSource = ErrorLogs;
            }
        }

        #region Trees page

        protected void HandleTreeValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TreeVM tree = null;
            try
            {
                tree = _BS_Trees[e.RowIndex] as TreeVM;
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
            var curTree = _BS_Trees[e.RowIndex] as TreeVM;
            if (curTree == null) { return; }

            var cell = _DGV_Trees[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
            if (cell == null) { return; }

            // if entering sample group column, update sample group selection
            if (sampleGroupDataGridViewTextBoxColumn != null
                && e.ColumnIndex == sampleGroupDataGridViewTextBoxColumn.Index)
            {
                UpdateSampleGroupColumn(curTree, cell);
            }

            // if entering species column, update species selection
            if (speciesDataGridViewColumn != null
                && e.ColumnIndex == speciesDataGridViewColumn.Index)
            {
                UpdateSpeciesColumn(curTree, cell);
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
                curTree = _BS_Trees[e.RowIndex] as TreeVM;
                if (curTree == null) { return; }
            }
            catch (SystemException) { return; }//ignore possible out of bound exceptions

            object cellValue = e.FormattedValue;
            cellValue = cell.ParseFormattedValue(cellValue, cell.InheritedStyle, null, null);

            if (stratumDataGridViewTextBoxColumn != null && e.ColumnIndex == stratumDataGridViewTextBoxColumn.Index)
            {
                var newStratum = cellValue as StratumDO;
                if (newStratum == null) { e.Cancel = true; }
                if (curTree.Stratum != null
                    && curTree.Stratum.Stratum_CN != newStratum.Stratum_CN)
                {
                    e.Cancel = !AskYesNo(
                        "You are changing the stratum of a tree\r\n" +
                        "Are you sure you want to do this?", "!", MessageBoxIcon.Asterisk);
                }
            }
            if (sampleGroupDataGridViewTextBoxColumn != null && e.ColumnIndex == sampleGroupDataGridViewTextBoxColumn.Index)
            {
                var newSg = cellValue as SampleGroupDO;
                if (newSg == null) { e.Cancel = true; }
                if (curTree.SampleGroup != null
                    && curTree.SampleGroup.SampleGroup_CN != newSg.SampleGroup_CN)
                {
                    e.Cancel = !AskYesNo(
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
            catch (Exception)
            {
                MessageBox.Show("Unable to save tree. Ensure Tree Number, Sample Group and Stratum are valid");
                //this.HandleNonCriticalException(e, "Unable to save tree. Ensure Tree Number, Sample Group and Stratum are valid");
                return false;
            }
        }

        #endregion Trees page

        #region Logs page

        private void _DGV_Logs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > Logs.Count) { return; }

            try
            {
                var log = Logs[e.RowIndex];
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

        #endregion Logs page

        #region Plots page

        private void _DGV_Plots_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > Plots.Count) { return; }

            try
            {
                var plot = Plots[e.RowIndex];
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
                plot.DAL.CommitTransaction();
                TreeDataDirty = true;
                return true;
            }
            catch
            {
                plot.DAL.RollbackTransaction();
                return false;
            }
        }

        #endregion Plots page

        #region Counts page

        private void _DGV_Counts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > Counts.Count) { return; }

            try
            {
                var count = Counts[e.RowIndex];
                count.Save();
            }
            catch (ArgumentOutOfRangeException) { return; }
            catch (Exception)
            {
                MessageBox.Show("Unable to save changes.");
            }
        }

        #endregion Counts page

        #region Errors page

        private void _DGV_Errors_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            var errorLog = _BS_Errors[e.RowIndex] as ErrorLogDO;
            if (errorLog == null) { return; }
            LocateRecord(errorLog.TableName, errorLog.CN_Number);
        }

        private void _DGV_Errors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            var errorLog = _BS_Errors[e.RowIndex] as ErrorLogDO;
            if (errorLog == null) { return; }
            LocateRecord(errorLog.TableName, errorLog.CN_Number);
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

        #endregion Errors page

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

                var ht = dgv.HitTest(x, y);//get row location from screen point
                int rowIndex = ht.RowIndex;
                if (rowIndex >= 0 && //check to see if row index if valid
                    (ht.Type == DataGridViewHitTestType.Cell || ht.Type == DataGridViewHitTestType.RowHeader))
                {
                    DataGridViewRow row = dgv.Rows[rowIndex];
                    var dataType = row.DataBoundItem.GetType();
                    if (dataType.IsAssignableFrom(typeof(TreeVM)))
                    {
                        var tree = row.DataBoundItem as TreeVM;
                        if (TryDeleteTree(tree))
                        {
                            dgv.Rows.RemoveAt(rowIndex);
                        }
                    }
                    else if (dataType.IsAssignableFrom(typeof(LogDO)))
                    {
                        var log = row.DataBoundItem as LogDO;
                        if (TryDeleteLog(log))
                        {
                            dgv.Rows.RemoveAt(rowIndex);
                        }
                    }
                    else if (dataType.IsAssignableFrom(typeof(PlotDO)))
                    {
                        var plot = row.DataBoundItem as PlotDO;
                        if (TryDeletePlot(plot))
                        {
                            dgv.Rows.RemoveAt(rowIndex);
                        }
                        //CountTreeDO ct = row.DataBoundItem as CountTreeDO;
                    }
                }
            }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
            catch
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
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

                var ht = dgv.HitTest(x, y);//get row location from screen point
                if (!(ht.Type == DataGridViewHitTestType.Cell || ht.Type == DataGridViewHitTestType.RowHeader))
                {
                    e.Cancel = true;
                }
            }
            catch
            {
            }
        }

        #endregion context menu

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