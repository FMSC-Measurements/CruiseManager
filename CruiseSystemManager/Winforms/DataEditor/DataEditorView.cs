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

namespace CSM.Winforms.DataEditor
{
    public partial class DataEditorView : Form
    {
        public const string CUTTING_UNIT_COLUMN_NAME = "Cutting Unit";
        public const string STRATUM_COLUMN_NAME = "Stratum";
        public const string SAMPLEGROUP_COLUMN_NAME = "Sample Group";
        public const string DEFAULTS_COLUMN_NAME = "Defaults";
        public const string TREENUMBER_COLUMN_NAME = "Tree Number";
        public const string COUNT_SPECIES_COLUMN_NAME = "Species";

        //private System.Threading.Thread _rebuildErrorsThread; 
        private TreeVM _currentTreeSelection; 

        #region Constants
        //these constants will be stand-in for the user to select "ANY" as an option from the drop downs
        //to determin if the user has selected the "ANY" option we will use Object.ReferenceEquals
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
        #endregion

        public DataEditorView() : this(WindowPresenter.Instance, ApplicationController.Instance)
        {

        }

        public DataEditorView(WindowPresenter windowPresenter, ApplicationController applicationController)
        {
            this.WindowPresenter = windowPresenter;
            this.ApplicationController = applicationController;

            InitializeComponent();
            this.Text = "Field Data - " + System.IO.Path.GetFileName(applicationController.Database.Path);
            

            this.TreeDataGridView.RowEnter += this.HandleCurrentTreeChanged;
            this.TreeDataGridView.CellValueChanged += this.HandleTreeValueChanged;
            this.TreeDataGridView.EditingControlShowing += this.HandleTreeEditControlShowing;
       
            this._BS_TreeSpecies.DataSource = applicationController.Database.Read<TreeDefaultValueDO>("TreeDefaultValue", null);

            this._BS_TreeSampleGroups.DataSource = applicationController.Database.Read<SampleGroupDO>("SampleGroup", null);
            //ResetViewFilters();
        }

        

        public bool SuppressUpdates { get; set; }

        public WindowPresenter WindowPresenter { get; set; }
        public ApplicationController ApplicationController { get; set; }

        public DAL DAL
        {
            get { return ApplicationController.Database; }
        }


        #region Current selections

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
                OnCuttingUnitChanged(); 
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
                OnStratumChanged(); 
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
                OnSampleGroupChanged(); 
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
            get { return TreeBindingSource.DataSource as BindingList<TreeVM>; }
            set { TreeBindingSource.DataSource = value; }
        }

        

        public BindingList<LogVM> Logs
        {
            get { return LogsBindingSource.DataSource as BindingList<LogVM>; }
            set { LogsBindingSource.DataSource = value; }
        }

        public BindingList<PlotDO> Plots
        {
            get { return PlotsBindingSource.DataSource as BindingList<PlotDO>; }
            set { PlotsBindingSource.DataSource = value; }
        }

        public BindingList<CountTreeDO> Counts
        {
            get { return CountsBindingSource.DataSource as BindingList<CountTreeDO>; }
            set { CountsBindingSource.DataSource = value; }
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

        //private DataEditorPresentor _presentor;
        //public DataEditorPresentor Presentor {
        //    get { return _presentor; }
        //    set
        //    {
        //        _presentor = value;
        //        if (_presentor == null) { return; }
        //        this.CuttingUnitBindingSource.DataSource = _presentor;
        //        this.StratumBindingSource.DataSource = _presentor;
        //        this.SampleGroupComboBox.DataSource = _presentor;
        //        this.TreeDefaultBindingSource.DataSource = _presentor;
        //        this.TreeBindingSource.DataSource = _presentor;
        //        this.LogsBindingSource.DataSource = _presentor;
        //        this.PlotsBindingSource.DataSource = _presentor;
        //        this.CountsBindingSource.DataSource = _presentor;

        //        //Update();
        //    }
        //}

        #region event handlers
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

        
        #endregion

        //public void UpdateData()
        //{
        //    //PopulateData();
        //    //this.CuttingUnitBindingSource.ResetBindings(false);
        //    //this.StratumBindingSource.ResetBindings(false);
        //    //this.SampleGroupBindingSource.ResetBindings(false);
        //    //this.TreeDefaultBindingSource.ResetBindings(false);
        //    //this.TreeBindingSource.ResetBindings(false);
        //    //this.LogsBindingSource.ResetBindings(false);
        //    //this.PlotsBindingSource.ResetBindings(false);
        //    //this.CountsBindingSource.ResetBindings(false);


        //}

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

        private void RebuildErrors()
        {
                this.DAL.Execute("DELETE FROM ErrorLog WHERE TableName in ('Tree','Log') AND Suppress = 0;");
                foreach (TreeVM tree in Trees)
                {
                    tree.PurgeErrorList();
                    if (!tree.Validate(tree.Stratum.FieldsArray))
                    {
                        tree.SaveErrors();
                    }
                }
        }

        private void ResetViewFilters()
        {
            _CuttingUnitFilter = ANY_OPTION_CUTTINGUNIT;
            _stratumFilter = ANY_OPTION_STRATUM;
            _sampleGroupFilter = ANY_OPTION_SAMPLEGROUP;
            _treeDefaultValueFilter = ANY_OPTION_TREEDEFAULT;

            OnCuttingUnitChanged();
            OnStratumChanged();
            PopulateData();
        }


        private void OnSampleGroupChanged()
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

        

        protected void OnStratumChanged()
        {
            if (this.DesignMode == true) { return; }
            //if all stratum selected
            if (StratumFilter == null)
            {
                //read all cutting units
                this.CuttingUnits = DAL.Read<CuttingUnitDO>("CuttingUnit", null, null);
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
                this.SampleGroups = DAL.Read<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", StratumFilter.Stratum_CN.ToString());
                //and enable ability to select sample group and tree default
                CanSelectSampleGroup = true;
                CanSelectTreeDefaultValue = true;
            }
        }

        protected void OnCuttingUnitChanged()
        {
            if (this.DesignMode == true) { return; }
            //if cutting unit not given
            if (CuttingUnitFilter == null)
            {
                //populate stratum selection list with all stratum
                this.Strata = DAL.Read<StratumDO>("Stratum", null, null);
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

        private void PopulateData()
        {
            if (this.DesignMode == true) { return; }

            //populate tree, log, plot, and count lists with selected unit, stratum, samplegroup, and defaults, if given
            SortableBindingList<TreeVM> treeList = new FMSC.Utility.Collections.SortableBindingList<TreeVM>(ReadTrees(CuttingUnitFilter, StratumFilter, SampleGroupFilter, TreeDefaultValueFilter));
            treeList.SetPropertyComparer("TreeDefaultValue", new TreeDefaultSpeciesComparer());
            this.Trees = treeList;
            this.Logs = new FMSC.Utility.Collections.SortableBindingList<LogVM>(ReadLogs(CuttingUnitFilter, StratumFilter, SampleGroupFilter, TreeDefaultValueFilter));
            this.Plots = new FMSC.Utility.Collections.SortableBindingList<PlotDO>(ReadPlots(CuttingUnitFilter, StratumFilter));
            FMSC.Utility.Collections.SortableBindingList<CountTreeDO> countList = new FMSC.Utility.Collections.SortableBindingList<CountTreeDO>(ReadCounts(CuttingUnitFilter, StratumFilter, SampleGroupFilter));
            countList.SetPropertyComparer("Component", new ComponentComparer());
            this.Counts = countList;
            

            this.ValidateData();
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

        #region read methods

        protected List<TreeVM> ReadTrees(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg, TreeDefaultValueDO tdv)
        {
            List<String> selectionList = new List<string>();
            List<String> selectionArgs = new List<string>();
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
                return DAL.Read<TreeVM>(CruiseDAL.Schema.TREE._NAME, selection + " ORDER BY TreeNumber, Plot_CN", selectionArgs.ToArray());
            }
            else
            {

                return DAL.Read<TreeVM>(CruiseDAL.Schema.TREE._NAME, "ORDER BY TreeNumber, Plot_CN", null);
            }
        }

        protected List<LogVM> ReadLogs(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg, TreeDefaultValueDO tdv)
        {
            List<String> selectionList = new List<string>();
            List<String> selectionArgs = new List<string>();
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
                return DAL.Read<LogVM>(CruiseDAL.Schema.LOG._NAME, selection, selectionArgs.ToArray());//since we are using LogVM we don't need to join tree, it already joins Tree
            }
            else
            {
                return DAL.Read<LogVM>(CruiseDAL.Schema.LOG._NAME, null, null);
            }
        }

        protected List<PlotDO> ReadPlots(CuttingUnitDO cu, StratumDO st)
        {
            List<String> selectionList = new List<string>();
            List<String> selectionArgs = new List<string>();
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
                return DAL.Read<PlotDO>(CruiseDAL.Schema.PLOT._NAME, selection, selectionArgs.ToArray());
            }
            else
            {
                return DAL.Read<PlotDO>(CruiseDAL.Schema.PLOT._NAME, null, null);
            }
        }

        protected List<CountTreeDO> ReadCounts(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg)
        {
            List<String> selectionList = new List<string>();
            List<String> selectionArgs = new List<string>();
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
                return DAL.Read<CountTreeDO>(CruiseDAL.Schema.COUNTTREE._NAME, "JOIN SampleGroup ON CountTree.SampleGroup_CN = SampleGroup.SampleGroup_CN WHERE " + selection, selectionArgs.ToArray());
            }
            else
            {
                return DAL.Read<CountTreeDO>(CruiseDAL.Schema.COUNTTREE._NAME, null, null);
            }

        }

        #endregion


        

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowPresenter.Instance.ShowDataExportDialog(Trees, Logs, Plots, Counts);
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
                        record = DAL.ReadSingleRow<TreeVM>("Tree", rowID);
                        ResetViewFilters();
                        this.TreeBindingSource.Position = this.TreeBindingSource.IndexOf(record);
                        this.DisplayTrees();
                        break;
                    }
                case "log":
                    {

                        record = DAL.ReadSingleRow<LogDO>("Log", rowID);
                        ResetViewFilters();
                        this.LogsBindingSource.Position = this.LogsBindingSource.IndexOf(record);
                        this.DisplayLogs();
                        break;
                    }
                case "plot":
                    {
                        record = DAL.ReadSingleRow<PlotDO>("Plot", rowID);
                        ResetViewFilters();
                        this.PlotsBindingSource.Position = this.PlotsBindingSource.IndexOf(record);
                        this.DisplayPlots();
                        break;
                    }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 4)
            {
                this.ErrorLogs = DAL.Read<ErrorLogDO>("ErrorLog", null);
                this._BS_Errors.DataSource = this.ErrorLogs;
            }
        }
        



        #region Trees page

        //void TreeDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        //{
        //    if (e.ColumnIndex == this.speciesDataGridViewColumn.Index)
        //    {
        //        TreeVM tree = this.TreeBindingSource[e.RowIndex] as TreeVM;
        //        if (tree != null)
        //        {

        //            e.Value = _currentTreeSelection.Species;
        //        }
        //    }
        //}

        protected void HandleCurrentTreeChanged(object sender, DataGridViewCellEventArgs e)
        {
            _currentTreeSelection = this.TreeBindingSource[e.RowIndex] as TreeVM;
            //if (_currentTreeSelection == null) { return; }

            

        }

        protected void HandleTreeValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(_currentTreeSelection == null) { return; }
            if (e.ColumnIndex == this.speciesDataGridViewColumn.Index)
            {
                DataGridViewComboBoxCell cell = this.TreeDataGridView[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                if (cell != null)
                {

                    TreeDefaultValueDO tdv = this._BS_TreeSpecies.Current as TreeDefaultValueDO;
                    CruiseManager.Core.App.WindowPresenter.SetTreeTDV(_currentTreeSelection, tdv);
                }
            }
            else if (e.ColumnIndex == this.sampleGroupDataGridViewTextBoxColumn.Index)
            {
                DataGridViewComboBoxCell cell = this.TreeDataGridView[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                
                SampleGroupDO sg = (cell != null) ? this._BS_TreeSampleGroups.Current as SampleGroupDO : null;
                if (sg != null)
                {
                    _currentTreeSelection.SampleGroup = sg;
                    //_currentTreeSelection.SampleGroup_CN = sg.SampleGroup_CN;

                }
            }
        }

        

        protected void HandleTreeEditControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.TreeDataGridView.CurrentCell.ColumnIndex == this.speciesDataGridViewColumn.Index)
            {
                DataGridViewComboBoxEditingControl control = e.Control as DataGridViewComboBoxEditingControl;
                //BindingSource bs = control.DataSource as BindingSource;
                //if (bs != null)
                //{
                //    this._BS_TreeSpecies.DataSource = AppController.GetTreeTDVList(_currentTreeSelection);
                //}
                //control.DataSource = AppController.GetTreeTDVList(_currentTreeSelection);
                control.DataSource = ApplicationController.Instance.GetTreeTDVList(_currentTreeSelection);
            }
            if (this.TreeDataGridView.CurrentCell.ColumnIndex == this.sampleGroupDataGridViewTextBoxColumn.Index)
            {
                String sgCode = _currentTreeSelection.SampleGroup.Code; 
                DataGridViewComboBoxEditingControl control = e.Control as DataGridViewComboBoxEditingControl;
                control.DataSource = WindowPresenter.GetSampleGroupsByStratum(_currentTreeSelection.Stratum_CN);
                control.SelectedIndex = control.FindString(sgCode);
            }
        }


        protected bool DeleteTree(TreeVM tree)
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

        private void TreeDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            TreeVM tree = this.Trees[e.RowIndex];
            if (tree == null) { return; }
            tree.Save();
            tree.SaveErrors();
        }

        private void TreeDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void TreeDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            TreeVM tree = e.Row.DataBoundItem as TreeVM;
            if (tree == null) { e.Cancel = true; return; }
            e.Cancel = !this.DeleteTree(tree);
        }


        #endregion

        #region Logs page
        protected bool DeleteLog(LogDO log)
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


        private void LogDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            this.Logs[e.RowIndex].Save();
        }

        private void LogsDataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            LogDO log = Logs[e.RowIndex];
            switch (LogDataGridView.Columns[e.ColumnIndex].HeaderText)
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

        private void LogDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            LogDO log = e.Row.DataBoundItem as LogDO;
            if (log == null) { e.Cancel = true; return; }
            e.Cancel = !this.DeleteLog(log);
        }

        #endregion 

        #region Plots page
        private void PlotDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            this.Plots[e.RowIndex].Save();
        }

        private void PlotDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            PlotDO plot = e.Row.DataBoundItem as PlotDO;
            if (plot == null) { e.Cancel = true; return; }
            e.Cancel = !this.DeletePlot(plot); 
        }

        protected bool DeletePlot(PlotDO plot)
        {
            try
            {
                PlotDO.RecursiveDeletePlot(plot);
                //plot.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion 

        #region Counts page
        private void CountDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            this.Counts[e.RowIndex].Save();
        }


        #endregion

        #region Errors page
        private void _errorsDGV_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            ErrorLogDO errorLog = _BS_Errors[e.RowIndex] as ErrorLogDO;
            if (errorLog == null) { return; }
            this.LocateRecord(errorLog.TableName, errorLog.CN_Number);
        }

        private void _errorsDGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            ErrorLogDO errorLog = _BS_Errors[e.RowIndex] as ErrorLogDO;
            if (errorLog == null) { return; }
            this.LocateRecord(errorLog.TableName, errorLog.CN_Number);
        }

        private void _errorsDGV_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            ErrorLogDO eLog = _BS_Errors[e.RowIndex] as ErrorLogDO;
            if (eLog == null) { return; }
            eLog.Save();

        }
        #endregion 

       

        #region context menu
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dgv = _ContextMenu.SourceControl as DataGridView;//get the DataGridView control that the menu is being displayed for
            if (dgv == null)
            {
                //for some reason SourceControl is null or not a DataGridView so don't continue. 
                CruiseManager.Core.App.WindowPresenter.HandleNonCriticalError(false, null);//error beep, just to let the user know their action wasn't compleated
                return;
            }

            try
            {
                Point p = _ContextMenu.Location;//because the context menu displays at the location the user clicked we can use it to determin the row number
                p = dgv.PointToClient(p);//convert location relitive to datagrid
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
                        TreeVM tree = row.DataBoundItem as TreeVM;
                        if (this.DeleteTree(tree))
                        {
                            dgv.Rows.RemoveAt(rowIndex);
                        }
                    }
                    else if (dataType.IsAssignableFrom(typeof(LogDO)))
                    {
                        LogDO log = row.DataBoundItem as LogDO;
                        if (this.DeleteLog(log))
                        {
                            dgv.Rows.RemoveAt(rowIndex);
                        }
                    }
                    else if (dataType.IsAssignableFrom(typeof(PlotDO)))
                    {
                        //CountTreeDO ct = row.DataBoundItem as CountTreeDO;
                    }

                }
            }
            catch
            {
                //just incase HitTest or point to client throws exception
            }
        }

        private void _ContextMenu_Opening(object sender, CancelEventArgs e)
        {
            DataGridView dgv = _ContextMenu.SourceControl as DataGridView;//get the DataGridView control that the menu is being displayed for
            if (dgv == null) { return; }
            try
            {
                Point p = _ContextMenu.Location;//because the context menu displays at the location the user clicked we can use it to determin the row number
                p = dgv.PointToClient(p);//convert location relitive to datagrid
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



        //private void TreeBindingSource_CurrentChanged(object sender, EventArgs e)
        //{
        //    TreeDO tree = TreeBindingSource.Current as TreeDO;
        //    if (tree == null) { return; }

        //    if (tree.SampleGroup.TreeDefaultValues.IsPopulated == false)
        //    {
        //        tree.SampleGroup.TreeDefaultValues.Populate();
        //    }
        //    _BS_treeDefaults.DataSource = tree.SampleGroup.TreeDefaultValues;
        //    _BS_sampleGroups.DataSource = DAL.Read<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", tree.Stratum_CN);
        //}
        
    }

        
}
