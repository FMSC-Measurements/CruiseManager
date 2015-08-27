using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;
using CSM.Logic;
using System.ComponentModel;
using CruiseDAL.Enums;

namespace CSM.UI.CruiseCustomize
{
    //[Flags]
    //public enum TallyMode {Unknown = 0, None = 1, BySpecies = 2, BySampleGroup = 4, Locked = 8, Manual = 16 }

    [SQLEntity(TableName="Tally", IsCached=false)]
    public class TallyVM : TallyDO
    {
        public TallyVM() : base() { }
        public TallyVM(DAL db) : base(db) { }
    }

    public class StratumCustomizeViewModel : StratumDO
    {
        public List<TreeFieldSetupDO> SelectedTreeFields { get; set; }
        public List<LogFieldSetupDO> SelectedLogFields { get; set; }

        public List<TreeFieldSetupDO> UnselectedTreeFields { get; set; }
        public List<LogFieldSetupDO> UnselectedLogFields { get; set; }

        public List<SampleGroupViewModel> SampleGroups { get; set; }

        public override string ToString()
        {
            return (base.Code + "  -  " + base.Method);
        }
    }

    public class SampleGroupViewModel : SampleGroupDO
    {

        private TallyVM _sgTallie;
        private bool _hasTallyEdits = false;
        private bool _tallieDataLoaded = false;


        public SampleGroupViewModel()
            : base()
        { }

        public SampleGroupViewModel(DAL db)
            : base(db)
        { }

        public SampleGroupViewModel(SampleGroupDO dObj)
            : base(dObj)
        { }

        //public SampleGroupDO SampleGroup { get; set; }
        public Dictionary<TreeDefaultValueDO, TallyVM> Tallies { get; set; }

        public TallyVM SgTallie 
        {
            get { return _sgTallie; }
            set { _sgTallie = value; }
        }

        //public TallyMode Mode 
        //{
        //    get 
        //    {
        //        return base.TallyMethod;
        //    }
        //    set 
        //    { 
        //        base.TallyMethod = value; 
        //    } 
        //}

        
        public bool HasTallyEdits
        {
            get { return _hasTallyEdits; }
            set { _hasTallyEdits = value; }
        }


        public bool UseSystematicSampling 
        {
            get
            {
                if (IsSTR())
                {
                    return base.SampleSelectorType == CruiseDAL.Schema.Constants.CruiseMethods.SYSTEMATIC_SAMPLER_TYPE;
                }
                return false;
            }
            set
            {
                if (IsSTR() && CanChangeSamplerType())
                {
                    base.SampleSelectorType = (value) ? CruiseDAL.Schema.Constants.CruiseMethods.SYSTEMATIC_SAMPLER_TYPE : string.Empty;
                    this.HasTallyEdits = true;
                }
            }
        }

        public bool CanChangeSamplerType()
        {
            return SampleGroupDO.CanChangeSamplerType(this);
        }

        //public CruiseDAL.Enums.TallyMode GetSampleGroupTallyMode()
        //{
        //    TallyMode mode = TallyMode.Unknown;
        //    if (base.DAL.GetRowCount("CountTree", "WHERE SampleGroup_CN = ?", base.SampleGroup_CN) == 0)
        //    {
        //        return TallyMode.None;
        //    }

        //    if (base.DAL.GetRowCount("CountTree",
        //        "WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) == 0",
        //        base.SampleGroup_CN) > 0)
        //    {
        //        mode = mode | TallyMode.BySampleGroup;
        //    }
        //    if (base.DAL.GetRowCount("CountTree",
        //        "WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) > 0",
        //        base.SampleGroup_CN) > 0)
        //    {
        //        mode = mode | TallyMode.BySpecies;
        //    }
        //    if (base.DAL.GetRowCount("CountTree",
        //        "WHERE SampleGroup_CN = ? AND TreeCount > 0", base.SampleGroup_CN) > 0)
        //    {
        //        mode = mode | TallyMode.Locked;
        //    }

        //    //foreach (CountTreeDO count in counts)
        //    //{
        //    //    if (count.TreeDefaultValue_CN.HasValue == false || count.TreeDefaultValue_CN == 0)
        //    //    {
        //    //        mode = mode | TallyMode.BySampleGroup;
        //    //    }
        //    //    else
        //    //    {
        //    //        mode = mode | TallyMode.BySpecies;
        //    //    }

        //    //    if (count.TreeCount > 0)
        //    //    {
        //    //        mode = mode | TallyMode.Locked;
        //    //    }
        //    //}


        //    return mode;
        //}

        public bool IsSTR()
        {
            return base.Stratum.Method == CruiseDAL.Schema.Constants.CruiseMethods.STR;
        }

        public List<T> ReadSpeciesCountTreeRecords<T>(CuttingUnitDO unit) where T : CountTreeDO, new()
        {
            return base.DAL.Read<T>(CruiseDAL.Schema.COUNTTREE._NAME,
                "WHERE SampleGroup_CN = ? AND CuttingUnit_CN AND ifnull(TreeDefaultValue_CN, 0) != 0", base.SampleGroup_CN, unit.CuttingUnit_CN);
        }


        public T ReadSpeciesCountTreeRecord<T>(TreeDefaultValueDO species, CuttingUnitDO unit) where T : CountTreeDO, new()
        {
            return base.DAL.ReadSingleRow<T>(CruiseDAL.Schema.COUNTTREE._NAME,
                "WHERE SampleGroup_CN = ? AND CuttingUnit_CN = ? AND TreeDefaultValue_CN = ?", this.SampleGroup_CN, unit.CuttingUnit_CN, species.TreeDefaultValue_CN);
        }

        public CountTreeDO ReadSpeciesCountTreeRecourd(TreeDefaultValueDO species, CuttingUnitDO unit)
        {
            return this.ReadSpeciesCountTreeRecord<CountTreeDO>(species, unit);
        }

        public T ReadSampleGroupCountTreeRecord<T>() where T : CountTreeDO, new()
        {
            return base.DAL.ReadSingleRow<T>(CruiseDAL.Schema.COUNTTREE._NAME,
                "WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) = 0", base.SampleGroup_CN);
        }

        public CountTreeDO ReadSampleGroupCountTreeRecord()
        {
            return this.ReadSampleGroupCountTreeRecord<CountTreeDO>();
        }


        public void LoadTallieData()
        {
            if (this._tallieDataLoaded) { return; }//we have already loaded this samplegroup before, dont reload it

            //initialize a tally entity for use with tally by sample group
            TallyVM sgTally = base.DAL.ReadSingleRow<TallyVM>("Tally",
                "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND ifnull(CountTree.TreeDefaultValue_CN, 0) = 0",
                this.SampleGroup_CN);

            
            if(sgTally == null)
            {
                sgTally = new TallyVM() { Description = this.Code };
            }

            this.SgTallie = sgTally;
            this.SgTallie.Validate();
            
            


            //initialize a list of tallys for use with tally by species 
            this.Tallies = new Dictionary<TreeDefaultValueDO, TallyVM>();
            this.TreeDefaultValues.Populate();
            foreach (TreeDefaultValueDO tdv in this.TreeDefaultValues)
            {
                TallyVM tally = base.DAL.Read<TallyVM>("Tally", "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND CountTree.TreeDefaultValue_CN = ?", 
                    this.SampleGroup_CN, tdv.TreeDefaultValue_CN).FirstOrDefault();

                if(tally == null)
                {
                    tally = new TallyVM() { Description = tdv.Species + ((tdv.LiveDead == "D") ? "/D" : "") };
                }

                //if (tally == null)
                //{
                //    tally = new TallyDO(base.DAL) { Description = tdv.Species + ((tdv.LiveDead == "D") ? "/D" : "") };
                //}
                tally.Validate();
                this.Tallies.Add(tdv, tally);
            }

            this._tallieDataLoaded = true;

        }

        

        public override string ToString()
        {
            return base.Code;
        }
    }

    //public class TallyViewModel
    //{
    //    public TallyDO Tally { get; set; }
    //    public TreeDefaultValueDO TDV { get; set; }
    //    public List<CountTreeDO> Counts { get; set; }
    //    public TallyViewModel(TallyDO tally)
    //    {
    //        this.Tally = tally;
    //    }
    //}

    //a worker class for comparing TreeFieldSetupDO 
    public class TreeFieldComparer : IEqualityComparer<TreeFieldSetupDO>, IComparer<TreeFieldSetupDO>
    {
        private static TreeFieldComparer _instance;
        public static TreeFieldComparer GetInstance()
        {
            if (_instance == null) { _instance = new TreeFieldComparer(); }
            return _instance;
        }

        #region IEqualityComparer<TreeFieldSetupDO> Members

        public bool Equals(TreeFieldSetupDO x, TreeFieldSetupDO y)
        {
            return x.Field == y.Field;
        }

        public int GetHashCode(TreeFieldSetupDO obj)
        {
            return (obj.Field != null) ? obj.Field.GetHashCode() : 0;
        }

        #endregion

        #region IComparer<TreeFieldSetupDO> Members

        public int Compare(TreeFieldSetupDO x, TreeFieldSetupDO y)
        {
            return string.Compare(x.Field, y.Field);
        }

        #endregion
    }

    //a worker class for comparing LogFieldSetupDO 
    public class LogFieldComparer : IEqualityComparer<LogFieldSetupDO>, IComparer<LogFieldSetupDO>
    {
        private static LogFieldComparer _instance;
        public static LogFieldComparer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LogFieldComparer();
            }
            return _instance;
        }

        #region IEqualityComparer<LogFieldSetupDO> Members

        public bool Equals(LogFieldSetupDO x, LogFieldSetupDO y)
        {
            return x.Field == y.Field;
        }

        public int GetHashCode(LogFieldSetupDO obj)
        {
            return (obj.Field != null) ? obj.Field.GetHashCode() : 0;
        }

        #endregion

        #region IComparer<LogFieldSetupDO> Members

        public int Compare(LogFieldSetupDO x, LogFieldSetupDO y)
        {
            return string.Compare(x.Field, y.Field);
        }

        #endregion
    }


    public class CustomizeCruisePresenter : IPresentor
    {
        public IWindowPresenter Controller { get; set; }
        public CruiseCustomizeView View { get; set; }
        //public List<StratumDO> Strata { get; set; }
        public List<StratumCustomizeViewModel> StrataVM { get; set; }
        public List<TreeDefaultValueDO> TreeDefaults { get; set; }
        public List<TreeAuditValueDO> TreeAudits { get; set; }

        public List<TreeFieldSetupDO> TreeFields { get; set; }
        public List<TreeFieldSetupDefaultDO> TreeFieldsDefault { get; set; }
        public List<LogFieldSetupDO> LogFields { get; set; }
        public List<TallyVM> TallyPresets { get; set; }
        public List<LogMatrixDO> LogMatrix { get; set; }

        public bool IsLogGradingEnabled { get; protected set; }

        //private List<TreeAuditValueDO> _treeAuditValues = new List<TreeAuditValueDO>();
        //private List<TreeAuditValueDO> _wiredTreeAuditValues = new List<TreeAuditValueDO>();

        public CustomizeCruisePresenter(IWindowPresenter presenter)
        {
            Controller = presenter;
            
            

            this.IsLogGradingEnabled = this.Controller.Database.Read<SaleDO>("Sale", null)[0].LogGradingEnabled;

            //this.TreeFields = this.Controller.AppState.SetupServ.GetTreeFieldSetups();
            //this.LogFields = this.Controller.AppState.SetupServ.GetLogFieldSetups();

            //DAL dal = Controller.Database;
            ////Strata = dal.Read<StratumCustomizeViewModel>("Stratum", null);
            //StrataVM = dal.Read<StratumCustomizeViewModel>("Stratum", null);
            //foreach (StratumCustomizeViewModel st in StrataVM)
            //{
            //    //StratumCustomizeViewModel newVM = new StratumCustomizeViewModel(st);
            //    st.SelectedLogFields = GetSelectedLogFields(st);
            //    st.SelectedTreeFields = GetSelectedTreeFields(st);
            //    if (st.SelectedTreeFields.Count() <= 0)
            //    {
            //       // if blank, use default values for cruise method
            //        st.SelectedTreeFields = GetSelectedTreeFieldsDefault(st);
            //    }
            //    List<TreeFieldSetupDO> unselectedTreeFields =
            //        (from tfs in this.TreeFields.Except(st.SelectedTreeFields, TreeFieldComparer.GetInstance()) 
            //         select new TreeFieldSetupDO(tfs)).ToList();
            //    List<LogFieldSetupDO> unselectedLogFields = (
            //        from lfs in this.LogFields.Except(st.SelectedLogFields, LogFieldComparer.GetInstance()) 
            //        select new LogFieldSetupDO(lfs)).ToList();

            //    st.UnselectedLogFields = unselectedLogFields;
            //    st.UnselectedTreeFields = unselectedTreeFields;
            //    //StrataVM.Add(newVM);
            //}

            //TreeAudits = dal.Read<TreeAuditValueDO>("TreeAuditValue", null);
            //TreeDefaults = dal.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
            //TallyPresets = dal.Read<TallyDO>("Tally", null);
            //this.LogMatrix = dal.Read<LogMatrixDO>("LogMatrix", null);
            
            //view.UpdatePresets();
            //view.UpdateStrata();
            //view.UpdateTreeDefaults();
            //view.UpdateTreeAudits();
            //view.UpdateLogMatrix();

        }

        public void UpdateView()
        {
            this.TreeFields = this.Controller.AppState.SetupServ.GetTreeFieldSetups();
            this.LogFields = this.Controller.AppState.SetupServ.GetLogFieldSetups();

            DAL dal = Controller.Database;
            try
            {
                //dal.EnterConnectionHold();
                StrataVM = dal.Read<StratumCustomizeViewModel>("Stratum", null);
                foreach (StratumCustomizeViewModel st in StrataVM)
                {
                    //StratumCustomizeViewModel newVM = new StratumCustomizeViewModel(st);
                    st.SelectedLogFields = GetSelectedLogFields(st);
                    st.SelectedTreeFields = GetSelectedTreeFields(st);
                    if (st.SelectedTreeFields.Count() <= 0)
                    {
                        // if blank, use default values for cruise method
                        st.SelectedTreeFields = GetSelectedTreeFieldsDefault(st);
                    }

                    //compare selected tree/log fields to all tree.log fields to create a list of unselected tree/log fields
                    List<TreeFieldSetupDO> unselectedTreeFields =
                        (from tfs in this.TreeFields.Except(st.SelectedTreeFields, TreeFieldComparer.GetInstance())
                         select new TreeFieldSetupDO(tfs)).ToList();
                    List<LogFieldSetupDO> unselectedLogFields = (
                        from lfs in this.LogFields.Except(st.SelectedLogFields, LogFieldComparer.GetInstance())
                        select new LogFieldSetupDO(lfs)).ToList();

                    st.UnselectedLogFields = unselectedLogFields;
                    st.UnselectedTreeFields = unselectedTreeFields;

                    this.LoadSampleGroups(st);
                }

                TreeAudits = dal.Read<TreeAuditValueDO>("TreeAuditValue", "Order By Field");
                TreeDefaults = dal.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
                TallyPresets = dal.Read<TallyVM>("Tally", null);
                this.LogMatrix = dal.Read<LogMatrixDO>("LogMatrix", null);
            }
            finally
            {
                //dal.ExitConnectionHold();
            }

            this.View.UpdateView();
            this.View.UpdatePresets();
            this.View.UpdateStrata();
            this.View.UpdateTreeDefaults();
            this.View.UpdateTreeAudits();
            this.View.UpdateLogMatrix();
        }

        #region Tally Setup

        //public CruiseDAL.Enums.TallyMode GetSampleGroupTallyMode(SampleGroupDO sg)
        //{
        //    TallyMode mode = TallyMode.Unknown;
        //    DAL db = Controller.Database;
        //    if (db.GetRowCount("CountTree", "WHERE SampleGroup_CN = ?", sg.SampleGroup_CN) == 0)
        //    {
        //        return TallyMode.None;
        //    }

        //    if (db.GetRowCount("CountTree",
        //        "WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) == 0",
        //        sg.SampleGroup_CN) > 0)
        //    {
        //        mode = mode | TallyMode.BySampleGroup;
        //    }
        //    if (db.GetRowCount("CountTree",
        //        "WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) > 0",
        //        sg.SampleGroup_CN) > 0)
        //    {
        //        mode = mode | TallyMode.BySpecies;
        //    }
        //    if (db.GetRowCount("CountTree",
        //        "WHERE SampleGroup_CN = ? AND TreeCount > 0", sg.SampleGroup_CN) > 0)
        //    {
        //        mode = mode | TallyMode.Locked;
        //    }

            //foreach (CountTreeDO count in counts)
            //{
            //    if (count.TreeDefaultValue_CN.HasValue == false || count.TreeDefaultValue_CN == 0)
            //    {
            //        mode = mode | TallyMode.BySampleGroup;
            //    }
            //    else
            //    {
            //        mode = mode | TallyMode.BySpecies;
            //    }

            //    if (count.TreeCount > 0)
            //    {
            //        mode = mode | TallyMode.Locked;
            //    }
            //}
            

        //    return mode;
        //}

        public bool CanDefintTallys(StratumDO stratum)
        {
            return StratumDO.CanDefineTallys(stratum);
        }



        //called when the view is initialized, for eash stratum 
        //initialized a list containing information about sampleGroups
        public void LoadSampleGroups(StratumCustomizeViewModel stratum)
        {
            if (stratum.SampleGroups != null) { return; }//if we have already created initialized this stratum, 

            stratum.SampleGroups = Controller.Database.Read<SampleGroupViewModel>("SampleGroup", "WHERE Stratum_CN = ?", stratum.Stratum_CN);
            foreach (SampleGroupViewModel sg in stratum.SampleGroups)
            {
                //TODO compare what we see as the tally mode vs. the stored mode on the sample group
                sg.TallyMethod = sg.GetSampleGroupTallyMode();
                sg.LoadTallieData();

                if (stratum.Method == CruiseDAL.Schema.Constants.CruiseMethods.STR && sg.TallyMethod == TallyMode.None)
                {
                    sg.TallyMethod = TallyMode.BySampleGroup;
                }
                if (CruiseDAL.Schema.Constants.CruiseMethods.THREE_P_METHODS.Contains(stratum.Method) && sg.TallyMethod == TallyMode.None)
                {
                    sg.TallyMethod = TallyMode.BySpecies;
                }
            }
        }


        ////called when a samplegroup is selected from the dropdown list in tally setup
        //public void LoadTallies(SampleGroupViewModel sg)
        //{
        //    if (sg.TallyMethod != TallyMode.Unknown) { return; }//assume we have already loaded this samplegroup before, dont reload it

        //    //TODO compare what we see as the tally mode vs. the stored mode on the sample group
        //    sg.TallyMethod = GetSampleGroupTallyMode(sg);

        //    //initialize a tally entity for use with tally by sample group
        //    TallyDO sgTally = Controller.Database.ReadSingleRow<TallyDO>("Tally", 
        //        "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND ifnull(CountTree.TreeDefaultValue_CN, 0) = 0", 
        //        sg.SampleGroup_CN);

        //    if (sgTally == null)
        //    {
        //        sg.SgTallie = new TallyDO(Controller.Database);
        //        sg.SgTallie.Description = sg.Code;
        //    }
        //    else
        //    {
        //        sg.SgTallie = sgTally;
        //    }
            

        //    //initialize a list of tallys for use with tally by species 
        //    sg.Tallies = new Dictionary<TreeDefaultValueDO, TallyDO>();
        //    sg.TreeDefaultValues.Populate();
        //    foreach (TreeDefaultValueDO tdv in sg.TreeDefaultValues)
        //    {
        //        TallyDO tally = Controller.Database.Read<TallyDO>("Tally", "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND CountTree.TreeDefaultValue_CN = ?",  sg.SampleGroup_CN, tdv.TreeDefaultValue_CN).FirstOrDefault();
        //        if (tally == null)
        //        {
        //            tally = new TallyDO(Controller.Database);
        //            tally.Description = tdv.Species + ((tdv.LiveDead == "D") ? "D" : "");
        //        }
        //        sg.Tallies.Add(tdv, tally);
        //    }
        //}

        protected void CopyTreeFields(StratumCustomizeViewModel from, StratumCustomizeViewModel to)
        {
            //TODO comeback
            //foreach (TreeFieldSetupDO tf in from.SelectedTreeFields)
            //{
            //    if (!to.SelectedTreeFields.Contains(tf, TreeFieldComparer.GetInstance()))
            //    {
            //        TreeFieldSetupDO match = to.UnselectedTreeFields.Find((TreeFieldSetupDO t) => t.Field = tf.Field);
            //        if (match == null) continue;
            //        to.SelectedTreeFields.Add(match);
            //        to.UnselectedTreeFields.Remove(match);
            //    }
            //}
            //foreach (TreeFieldSetupDO tf in from.UnselectedTreeFields)
            //{
            //    if (!to.UnselectedTreeFields.Contains(tf, TreeFieldComparer.GetInstance()))
            //    {
            //        TreeFieldSetupDO match = to.SelectedTreeFields.Find((TreeFieldSetupDO t) => t.Field = tf.Field);
            //        if (match == null) continue;
            //        to.UnselectedTreeFields.Add(match);
            //        to.SelectedTreeFields.Remove(match);
            //    }
            //}

        }


        private bool SaveTallies()
        {
            foreach (StratumCustomizeViewModel vm in StrataVM)
            {
                if (vm.SampleGroups != null)
                {

                    string error = null;
                    if (!this.ValidateHotKeys(vm, ref error))
                    {
                        System.Windows.Forms.MessageBox.Show("Errors found\r\n" + error);
                        return false;
                    }


                    foreach (SampleGroupViewModel sgVM in vm.SampleGroups)
                    {
                        if (sgVM.HasTallyEdits == true)
                        {
                            SaveTallies(sgVM);
                        }
                    }
                }

            }
            return true;
        }

        private void SaveTallies(SampleGroupViewModel sgVM)
        {
            try
            {
                Controller.Database.BeginTransaction();

                //if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
                //{
                //    string delCommand = String.Format("DELETE FROM CountTree WHERE SampleGroup_CN = {0}", sgVM.SampleGroup_CN);
                //    Controller.Database.Execute(delCommand); //clead any existing count records. 
                //}

                if ((sgVM.TallyMethod & TallyMode.BySampleGroup) == TallyMode.BySampleGroup)
                {
                    SaveTallyBySampleGroup(sgVM);
                }
                else if ((sgVM.TallyMethod & TallyMode.BySpecies) == TallyMode.BySpecies)
                {
                    SaveTallyBySpecies(sgVM);
                }
                Controller.Database.EndTransaction();
                sgVM.HasTallyEdits = false;
            }
            catch(Exception)
            {
                Controller.Database.CancelTransaction();
                string errorMsg = string.Format("Error: failed to setup tallies for SampleGroup({0} ) in Stratum ({1})", sgVM.Code, sgVM.Stratum.Code);
                System.Windows.Forms.MessageBox.Show(errorMsg, "Error");
            }
        }

        private void SaveTallyBySampleGroup(SampleGroupViewModel sgVM)
        {
            if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
            {
                string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) != 0;";
                Controller.Database.Execute(command, sgVM.SampleGroup_CN); 

                string user = Controller.Database.User;
                String makeCountsCommand = String.Format(@"INSERT  OR Fail INTO CountTree (CuttingUnit_CN, SampleGroup_CN,  CreatedBy)
                            Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN,  '{0}' AS CreatedBy
                            From SampleGroup 
                            INNER JOIN CuttingUnitStratum 
                            ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN 
                            WHERE SampleGroup.SampleGroup_CN = {1};", user, sgVM.SampleGroup_CN);

                Controller.Database.Execute(makeCountsCommand);
            }
            TallyVM tally = Controller.Database.ReadSingleRow<TallyVM>("Tally", "WHERE Description = ? AND HotKey = ?", sgVM.SgTallie.Description, sgVM.SgTallie.Hotkey);
            if (tally == null)
            {
                tally = new TallyVM(Controller.Database) { Description = sgVM.SgTallie.Description, Hotkey = sgVM.SgTallie.Hotkey };
                //tally = sgVM.SgTallie;
                tally.Save();
            }

            String setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1};",
                tally.Tally_CN, sgVM.SampleGroup_CN);

            Controller.Database.Execute(setTallyCommand);
        }

        private void SaveTallyBySpecies(SampleGroupViewModel sgVM)
        {
            if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
            {
                string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) = 0;";
                Controller.Database.Execute(command, sgVM.SampleGroup_CN);

                string user = Controller.Database.User;
                String makeCountsCommand = String.Format(@"INSERT  OR IGNORE INTO CountTree (CuttingUnit_CN, SampleGroup_CN, TreeDefaultValue_CN, CreatedBy)
                        Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN, SampleGroupTreeDefaultValue.TreeDefaultValue_CN, '{0}' AS CreatedBy 
                        From SampleGroup 
                        INNER JOIN CuttingUnitStratum 
                        ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN 
                        INNER JOIN SampleGroupTreeDefaultValue 
                        ON SampleGroupTreeDefaultValue.SampleGroup_CN = SampleGroup.SampleGroup_CN 
                        WHERE SampleGroup.SampleGroup_CN = {1};",
                        user, sgVM.SampleGroup_CN);


                Controller.Database.Execute(makeCountsCommand);
            }
            foreach (KeyValuePair<TreeDefaultValueDO, TallyVM> pair in sgVM.Tallies)
            {
                TallyVM tally = Controller.Database.ReadSingleRow<TallyVM>("Tally", "WHERE Description = ? AND HotKey = ?", pair.Value.Description, pair.Value.Hotkey);
                if (tally == null)
                {
                    tally = new TallyVM(Controller.Database) { Description = pair.Value.Description, Hotkey = pair.Value.Hotkey };
                    //tally = pair.Value;
                    //tally.DAL = Controller.Database;
                    tally.Save();
                }

                string setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1} AND TreeDefaultValue_CN = {2}",
                    tally.Tally_CN, sgVM.SampleGroup_CN, pair.Key.TreeDefaultValue_CN);

                Controller.Database.Execute(setTallyCommand);
            }

        }


        private static char HotKeyToChar(string str)//TODO move method somewhere more useful
        {
            if(String.IsNullOrEmpty(str))
            {
                return char.MinValue;
            }
            return char.ToUpper(str[0]);
        }



        private bool ValidateHotKeys(StratumCustomizeViewModel st,  ref string errorMessage)
        {
            List<char> usedHotKeys = new List<char>();
            StringBuilder errorBuilder = new StringBuilder();
            foreach (SampleGroupViewModel sgVM in st.SampleGroups)
            {
                if ((sgVM.TallyMethod & TallyMode.BySampleGroup) == TallyMode.BySampleGroup)
                {
                    char hk = HotKeyToChar(sgVM.SgTallie.Hotkey);
                    if (hk == char.MinValue) { continue; } //no hot key set, SKIP
                    if (usedHotKeys.IndexOf(hk) >= 0)//see if usedHotKeys already CONTAINS value
                    {
                        //ERROR stratum already has hotkey
                        errorBuilder.AppendFormat("Hot Key '{0}' in SG:{1} Stratum:{2} already in use\r\n", sgVM.SgTallie.Hotkey, sgVM.ToString(), st.Code);
                    }
                    else
                    {
                        //SUCCESS add hot key to list of in ues hot keys
                        usedHotKeys.Add(hk);
                    }
                }
                else if ((sgVM.TallyMethod & TallyMode.BySpecies) == TallyMode.BySpecies)
                {
                    foreach (TallyVM t in sgVM.Tallies.Values)
                    {
                        char hk = HotKeyToChar(t.Hotkey);
                        if (hk == char.MinValue) { continue; } //not hot key set, SKIP
                        if (usedHotKeys.IndexOf(hk) >= 0)//see if usedHotKeys already CONTAINS value
                        {
                            //ERROR stratum already has hotkey
                            errorBuilder.AppendFormat("Hot Key '{0}' in SG:{1} Stratum:{2} already in use\r\n", t.Hotkey, sgVM.ToString(), st.Code);
                        }
                        else
                        {
                            //SUCCESS add hot key to list of in ues hot keys
                            usedHotKeys.Add(hk);
                        }
                    }
                }
            }

            if (errorBuilder.Length > 0)
            {
                errorMessage = errorBuilder.ToString();
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion

        #region Tree / Log Field Setup
        public List<TreeFieldSetupDO> GetSelectedTreeFields(StratumDO stratum)
        {
            return this.Controller.Database.Read<TreeFieldSetupDO>("TreeFieldSetup", "WHERE Stratum_CN = ? ORDER BY FieldOrder", stratum.Stratum_CN);
        }

        public List<TreeFieldSetupDO> GetSelectedTreeFieldsDefault(StratumDO stratum)
        {
           //select from TreeFieldSetupDefault where method = stratum.method
           List<TreeFieldSetupDefaultDO> treeFieldDefaults = Controller.Database.Read<TreeFieldSetupDefaultDO>("TreeFieldSetupDefault", "WHERE Method = ? ORDER BY FieldOrder", stratum.Method);
           
           List<TreeFieldSetupDO> treeFields = new List<TreeFieldSetupDO>();
           
           foreach (TreeFieldSetupDefaultDO tfd in treeFieldDefaults)
           {
              TreeFieldSetupDO tfs = new TreeFieldSetupDO();
              tfs.Stratum_CN = stratum.Stratum_CN;
              tfs.Field = tfd.Field;
              tfs.FieldOrder = tfd.FieldOrder;
              tfs.ColumnType = tfd.ColumnType;
              tfs.Heading = tfd.Heading;
              tfs.Width = tfd.Width;
              tfs.Format = tfd.Format;
              tfs.Behavior = tfd.Behavior;
              
              treeFields.Add(tfs);
           }
           return treeFields;
        }

        public List<LogFieldSetupDO> GetSelectedLogFields(StratumDO stratum)
        {
            return this.Controller.Database.Read<LogFieldSetupDO>("LogFieldSetup", "WHERE Stratum_CN = ? ORDER BY FieldOrder", stratum.Stratum_CN);
        }

        #endregion



        public bool ValidateTallySettup(out string error)
        {
            StringBuilder errorBuilder = new StringBuilder();
            bool isValid = true;
            foreach (StratumCustomizeViewModel st in StrataVM)
            {
                if (CruiseDAL.Schema.Constants.CruiseMethods.MANDITORY_TALLY_METHODS.Contains(st.Method))
                {
                    foreach (SampleGroupViewModel sg in st.SampleGroups)
                    {
                        if (sg.TallyMethod == TallyMode.Unknown || (sg.TallyMethod & TallyMode.None) == TallyMode.None)
                        {
                            errorBuilder.AppendFormat("Sample Group {0} in Stratum {1} needs tally configuration\r\n", sg.Code, st.Code);
                            isValid = false;
                        }
                    }
                }

            }
            error = errorBuilder.ToString();
            return isValid;
        }

        private bool Save()
        {
            bool success = true; 
            View.EndEdits();

            


            try
            {
                //begin transaction for saving strata and their field set up info
                this.Controller.Database.BeginTransaction();
                foreach (StratumCustomizeViewModel vm in StrataVM)
                {

                    //ensure any canges to stratum are saved 
                    vm.Save();

                    //ensure all unselected tree fields are removed 
                    foreach (TreeFieldSetupDO tf in vm.UnselectedTreeFields)
                    {
                        if (tf.IsPersisted == true)
                        {
                            tf.Delete();
                        }
                    }

                    //ensure all unselected log fields are removed 
                    foreach (LogFieldSetupDO lf in vm.UnselectedLogFields)
                    {
                        if (lf.IsPersisted == true)
                        {
                            lf.Delete();
                        }
                    }


                    foreach (TreeFieldSetupDO tf in vm.SelectedTreeFields)
                    {
                        if (tf.IsPersisted == false)
                        {
                            tf.DAL = this.Controller.Database;
                            tf.Stratum = vm;
                        }
                        tf.Save();
                    }
                    foreach (LogFieldSetupDO lf in vm.SelectedLogFields)
                    {
                        if (lf.IsPersisted == false)
                        {
                            lf.DAL = this.Controller.Database;
                            lf.Stratum = vm;
                        }
                        lf.Save();
                    }

                    //ensure any changes in sample groups are saved.
                    //this will save the TallyMethod which may have changed
                    if (vm.SampleGroups != null)
                    {
                        foreach (SampleGroupViewModel sg in vm.SampleGroups)
                        {
                            //if (sg.HasTallyEdits)
                            //{
                            //    sg.Save();
                            //}
                            sg.Save();
                        }
                    }
                }//end foreach
                this.Controller.Database.EndTransaction();
            }
            catch(Exception ex) 
            {
                success = false;
                string errorMessage = String.Format("File save error. Field setup was not saved. <Error details: {0}>", ex.ToString());
                this.Controller.ShowSimpleErrorMessage(errorMessage);
                this.Controller.Database.CancelTransaction(); 
            }

            

            try
            {
                this.Controller.Database.BeginTransaction();

                foreach (LogMatrixDO lm in this.LogMatrix)
                {
                    if (lm.IsPersisted == false)
                    {
                        lm.DAL = this.Controller.Database;
                    }
                    lm.Save();
                }
                this.Controller.Database.EndTransaction();
            }
            catch (Exception ex)
            {
                success = false;
                string errorMessage = String.Format("File save error. Log Matrix data was not saved. <Error details: {0}>", ex.ToString());
                this.Controller.ShowSimpleErrorMessage(errorMessage);
                this.Controller.Database.CancelTransaction();
            }

            try
            {
                this.Controller.Database.BeginTransaction();
                foreach (TreeAuditValueDO tav in TreeAudits)
                {
                    if (tav.DAL == null)
                    {
                        tav.DAL = this.Controller.Database;
                    }
                    tav.Save();
                    tav.TreeDefaultValues.Save();
                }
                this.Controller.Database.EndTransaction();
            }
            catch (Exception ex)
            {
                success = false;
                string errorMessage = String.Format("File save error. Tree Audit Rules was not saved. <Error details: {0}>", ex.ToString());
                this.Controller.ShowSimpleErrorMessage(errorMessage);
                this.Controller.Database.CancelTransaction();
            }

            string error;
            if (!ValidateTallySettup(out error))
            {
                this.Controller.ShowSimpleErrorMessage(error);
                return false;
            }
            if (this.SaveTallies() == false)
            {
                return false;
            }

            return success;
        }


        #region ISaveHandler Members

        public void HandleSave()
        {
            Save();
        }

        public void HandleAppClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = !Save();
        }

        public bool CanHandleSave
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            //Dispose(true);
            //GC.SuppressFinalize(this);
        }

     
        #endregion
    }
}
