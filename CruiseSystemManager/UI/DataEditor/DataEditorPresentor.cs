//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CruiseDAL.DataObjects;
//using CruiseDAL;
//using System.Windows.Data;
//using System.ComponentModel;

//namespace CSM.UI.DataEditor
//{
//    public class DataEditorPresentor
//    {
////        public CuttingUnitDO    CuttingUnitFilter { get; set; }
////        public StratumDO StratumFilter { get; set; }
////        public SampleGroupDO SampleGroupFilter { get; set; }
////        public TreeDefaultValueDO SpeciesFilter { get; set; }


//        public DataEditorPresentor(WindowPresenter WindowPresenter, DataEditorView view)
//        {

//            this.WindowPresenter = WindowPresenter;
//            this.View = view;
//            //this.View.Presentor = this;
//            CurrentStratum = null;
//            CurrentCuttingUnit = null;
//        }

//        public DataEditorView View { get; set; }
//        public WindowPresenter WindowPresenter { get; set; }

//        public DAL DAL
//        {
//            get { return WindowPresenter.DAL; }
//            set { WindowPresenter.DAL = value; }
//        }

//        private CuttingUnitDO _currentCuttingUnit;
//        public CuttingUnitDO CurrentCuttingUnit
//        {
//            get
//            {
//                return _currentCuttingUnit;
//            }
//            set
//            {
//                ChangeCurrentCuttingUnit(value);
//            }
//        }

//        private StratumDO _currentStratum;
//        public StratumDO CurrentStratum
//        {
//            get
//            {
//                return _currentStratum;
//            }
//            set
//            {
//                ChangeCurrentStratum(value);
//            }
//        }

//        private SampleGroupDO _currentSampleGroup;
//        public SampleGroupDO CurrentSampleGroup
//        {
//            get
//            {
//                return _currentSampleGroup;
//            }
//            set
//            {
//                _currentSampleGroup = value;
//            }
//        }

//        private TreeDefaultValueDO _currentTreeDefaultValue;
//        public TreeDefaultValueDO CurrentTreeDefaultValue
//        {
//            get { return _currentTreeDefaultValue; }
//            set { _currentTreeDefaultValue = value; }
//        }


//        public List<StratumDO> Strata { get; set; }
//        public List<CuttingUnitDO> CuttingUnits { get; set; }
//        public List<TreeDO> Trees { get; set; }
//        public List<SampleGroupDO> SampleGroups { get; set; }
//        public List<TreeDefaultValueDO> TreeDefaults { get; set; }
//        public List<LogDO> Logs { get; set; }
//        public List<PlotDO> Plots { get; set; }
//        public List<CountTreeDO> Counts { get; set; }

//        public bool CanSelectSampleGroup { get; set; }
//        public bool CanSelectTreeDefaultValue { get; set; }


//        protected void ChangeCurrentStratum(StratumDO value)
//        {
//            this._currentStratum = value;
//            if (value != null)
//            {
//                this.CuttingUnits = CurrentStratum.CuttingUnits.ToList();
//                this.SampleGroups = DAL.Read<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", CurrentStratum.Stratum_CN.ToString());
//            }
//            else
//            {
//                this.CuttingUnits = DAL.Read<CuttingUnitDO>("CuttingUnit", null, null);
//            }

//            this.Trees = ReadTrees(CurrentCuttingUnit, CurrentStratum, CurrentSampleGroup, CurrentTreeDefaultValue);
//            this.Logs = ReadLogs(CurrentCuttingUnit, CurrentStratum, CurrentSampleGroup, CurrentTreeDefaultValue);
//            this.Plots = ReadPlots(CurrentCuttingUnit, CurrentStratum);
//            this.Counts = ReadCounts(CurrentCuttingUnit, CurrentStratum, CurrentSampleGroup);

//            View.Update();
//        }

//        protected void ChangeCurrentCuttingUnit(CuttingUnitDO value)
//        {
//            this._currentCuttingUnit = value;
//            if (value != null)
//            {
//                this.Strata = CurrentCuttingUnit.Strata.ToList();
//            }
//            else
//            {
//                this.Strata = DAL.Read<StratumDO>("Stratum", null, null);
//            }

//            this.Trees = ReadTrees(CurrentCuttingUnit, CurrentStratum, CurrentSampleGroup, CurrentTreeDefaultValue);
//            this.Logs = ReadLogs(CurrentCuttingUnit, CurrentStratum, CurrentSampleGroup, CurrentTreeDefaultValue);
//            this.Plots = ReadPlots(CurrentCuttingUnit, CurrentStratum);
//            this.Counts = ReadCounts(CurrentCuttingUnit, CurrentStratum, CurrentSampleGroup);

//            View.Update();
//        }



//        protected List<TreeDO> ReadTrees(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg, TreeDefaultValueDO tdv)
//        {
//            List<String> selectionList = new List<string>();
//            List<String> selectionArgs = new List<string>();
//            if (cu != null)
//            {
//                selectionList.Add(CruiseDAL.Schema.TREE.CUTTINGUNIT_CN + " = ?");
//                selectionArgs.Add(cu.CuttingUnit_CN.ToString());
//            }
//            if (st != null)
//            {
//                selectionList.Add(CruiseDAL.Schema.TREE.STRATUM_CN + " = ?");
//                selectionArgs.Add(st.Stratum_CN.ToString());
//            }
//            if (sg != null)
//            {
//                selectionList.Add(CruiseDAL.Schema.TREE.SAMPLEGROUP_CN + " = ?");
//                selectionArgs.Add(sg.SampleGroup_CN.ToString());
//            }
//            if (tdv != null)
//            {
//                selectionList.Add(CruiseDAL.Schema.TREE.TREEDEFAULTVALUE_CN + " = ?");
//                selectionArgs.Add(tdv.TreeDefaultValue_CN.ToString());
//            }
//            if (selectionList.Count > 0)
//            {
//                String selection = "WHERE " + String.Join(" AND ", selectionList.ToArray());
//                return DAL.Read<TreeDO>(CruiseDAL.Schema.TREE._NAME, selection, selectionArgs.ToArray());
//            }
//            else
//            {
//                return DAL.Read<TreeDO>(CruiseDAL.Schema.TREE._NAME, null, null);
//            }
//        }

//        protected List<LogDO> ReadLogs(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg, TreeDefaultValueDO tdv)
//        {
//            List<String> selectionList = new List<string>();
//            List<String> selectionArgs = new List<string>();
//            if (cu != null)
//            {
//                selectionList.Add(String.Format("Tree.{0} = ?", CruiseDAL.Schema.TREE.CUTTINGUNIT_CN));
//                selectionArgs.Add(cu.CuttingUnit_CN.ToString());
//            }
//            if (st != null)
//            {
//                selectionList.Add(String.Format("Tree.{0} = ?", CruiseDAL.Schema.TREE.STRATUM_CN));
//                selectionArgs.Add(st.Stratum_CN.ToString());
//            }
//            if (sg != null)
//            {
//                selectionList.Add(String.Format("Tree.{0} = ?", CruiseDAL.Schema.TREE.SAMPLEGROUP_CN));
//                selectionArgs.Add(sg.SampleGroup_CN.ToString());
//            }
//            if (tdv != null)
//            {
//                selectionList.Add(String.Format("Tree.{0} = ?", CruiseDAL.Schema.TREE.TREEDEFAULTVALUE_CN));
//                selectionArgs.Add(tdv.TreeDefaultValue_CN.ToString());
//            }
//            if (selectionList.Count > 0)
//            {
//                String selection = "WHERE " + String.Join(" AND ", selectionList.ToArray());
//                return DAL.Read<LogDO>(CruiseDAL.Schema.LOG._NAME, "INNER JOIN Tree ON Tree.Tree_CN = Log.Tree_CN " + selection, selectionArgs.ToArray());
//            }
//            else
//            {
//                return DAL.Read<LogDO>(CruiseDAL.Schema.LOG._NAME, null, null);
//            }
//        }

//        protected List<PlotDO> ReadPlots(CuttingUnitDO cu, StratumDO st)
//        {
//            List<String> selectionList = new List<string>();
//            List<String> selectionArgs = new List<string>();
//            if (cu != null)
//            {
//                selectionList.Add(String.Format("{0} = ?", CruiseDAL.Schema.TREE.CUTTINGUNIT_CN));
//                selectionArgs.Add(cu.CuttingUnit_CN.ToString());
//            }
//            if (st != null)
//            {
//                selectionList.Add(String.Format("{0} = ?", CruiseDAL.Schema.TREE.STRATUM_CN));
//                selectionArgs.Add(st.Stratum_CN.ToString());
//            }

//            if (selectionList.Count > 0)
//            {
//                String selection = "WHERE " + String.Join(" AND ", selectionList.ToArray());
//                return DAL.Read<PlotDO>(CruiseDAL.Schema.PLOT._NAME, selection, selectionArgs.ToArray());
//            }
//            else
//            {
//                return DAL.Read<PlotDO>(CruiseDAL.Schema.PLOT._NAME, null, null);
//            }
//        }

//        protected List<CountTreeDO> ReadCounts(CuttingUnitDO cu, StratumDO st, SampleGroupDO sg)
//        {
//            List<String> selectionList = new List<string>();
//            List<String> selectionArgs = new List<string>();
//            if (cu != null)
//            {
//                selectionList.Add(String.Format("CountTree.{0} = ?", CruiseDAL.Schema.COUNTTREE.CUTTINGUNIT_CN));
//                selectionArgs.Add(cu.CuttingUnit_CN.ToString());
//            }
//            if (st != null)
//            {
//                selectionList.Add(String.Format("SampleGroup.{0} = ?", CruiseDAL.Schema.SAMPLEGROUP.STRATUM_CN));
//                selectionArgs.Add(st.Stratum_CN.ToString());
//            }
//            if (sg != null)
//            {
//                selectionList.Add(String.Format("CountTree.{0} = ?", CruiseDAL.Schema.COUNTTREE.SAMPLEGROUP_CN));
//                selectionArgs.Add(sg.SampleGroup_CN.ToString());
//            }

//            if (selectionList.Count > 0)
//            {
//                String selection = String.Join(" AND ", selectionList.ToArray());
//                return DAL.Read<CountTreeDO>(CruiseDAL.Schema.COUNTTREE._NAME, "INNER JOIN SampleGroup WHERE " + selection, selectionArgs.ToArray());
//            }
//            else
//            {
//                return DAL.Read<CountTreeDO>(CruiseDAL.Schema.COUNTTREE._NAME, null, null);
//            }
//        }
//    }
//}
