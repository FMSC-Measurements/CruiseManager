using CruiseDAL.DataObjects;
using CruiseDAL.Enums;
using CruiseManager.Core.App;
using FMSC.ORM.EntityModel;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    [EntitySource(SourceName = "SampleGroup")]
    public class TallySetupSampleGroup : DataObject_Base
    {
        bool? _isTallyModeLocked;
        bool _hasTallyEdits = false;
        TallyVM _sgTallie;
        bool _tallieDataLoaded = false;
        IList<TreeDefaultValueDO> _treeDefaultValues;

        #region CTor

        public TallySetupSampleGroup()
            : base()
        { }

        #endregion CTor

        public new CruiseDAL.DAL DAL
        {
            get { return (CruiseDAL.DAL)base.DAL; }
            set { base.DAL = value; }
        }

        #region Persisted Members

        [PrimaryKeyField(Name = "SampleGroup_CN")]
        public Int64? SampleGroup_CN { get; set; }

        [Field(Name = "Stratum_CN")]
        public virtual long? Stratum_CN { get; set; }

        [Field(Name = "Code")]
        public virtual String Code { get; set; }

        TallyMode _tallyMethod;

        [Field(Name = "TallyMethod", PersistanceFlags = PersistanceFlags.OnUpdate)]
        public virtual CruiseDAL.Enums.TallyMode TallyMethod
        {
            get
            {
                if (_tallyMethod == TallyMode.Unknown)
                {
                    _tallyMethod = GetSampleGroupTallyMode();
                }
                return _tallyMethod;
            }
            set
            {
                _tallyMethod = value;
            }
        }

        //[Field(Name = "Description")]
        //public virtual String Description { get; set; }

        [Field(Name = "SampleSelectorType")]
        public virtual String SampleSelectorType { get; set; }

        [Field(Name = "SampleSelectorState")]
        public virtual String SampleSelectorState { get; set; }

        #endregion Persisted Members

        public TallySetupStratum_Base Stratum { get; set; }

        public IList<TreeDefaultValueDO> TreeDefaultValues
        {
            get
            {
                if (_treeDefaultValues == null)
                {
                    _treeDefaultValues = DAL.From<TreeDefaultValueDO>()
                        .Join("SampleGroupTreeDefaultValue", "USING (TreeDefaultValue_CN)")
                        .Where("SampleGroup_CN = ?")
                        .Query(SampleGroup_CN).ToList();
                }
                return _treeDefaultValues;
            }
        }

        public Dictionary<String, TallyPopulation> TallyPopulations { get; protected set; }

        public TallyMode GetSampleGroupTallyMode()
        {
            TallyMode mode = TallyMode.Unknown;
            if (DAL.GetRowCount("CountTree", "WHERE SampleGroup_CN = ?", SampleGroup_CN) == 0)
            {
                if (Stratum.Method == CruiseDAL.Schema.CruiseMethods.STR)
                {
                    return TallyMode.BySampleGroup;
                }
                else if (CruiseDAL.Schema.CruiseMethods.THREE_P_METHODS.Contains(Stratum.Method))
                {
                    return TallyMode.BySpecies;
                }

                return TallyMode.None;
            }

            if (DAL.GetRowCount("CountTree",
                "WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) == 0",
                SampleGroup_CN) > 0)
            {
                mode = mode | TallyMode.BySampleGroup;
            }
            if (DAL.GetRowCount("CountTree",
                "WHERE SampleGroup_CN = ? AND TreeDefaultValue_CN NOT NULL AND TreeDefaultValue_CN > 0",
                this.SampleGroup_CN) > 0)
            {
                mode = mode | TallyMode.BySpecies;
            }
            //if (DAL.GetRowCount("CountTree",
            //    "WHERE SampleGroup_CN = ? AND TreeCount > 0", this.SampleGroup_CN) > 0)
            //{
            //    mode = mode | TallyMode.Locked;
            //}

            return mode;
        }

        public bool CanEditSampleType
        {
            get
            {
                return String.IsNullOrEmpty(SampleSelectorState)
                    && Stratum.Method == CruiseDAL.Schema.CruiseMethods.STR;
            }
        }

        public bool CanTallyBySG
        {
            get
            {
                return (this.Stratum.Method != CruiseDAL.Schema.CruiseMethods.THREEP);
            }
        }

        public bool CanTallyBySpecies
        { get { return true; } }

        public bool HasTallyEdits
        {
            get { return _hasTallyEdits; }
            set { _hasTallyEdits = value; }
        }

        public bool IsTallyModeLocked
        {
            get
            {
                if (_isTallyModeLocked == null)
                {
                    _isTallyModeLocked = DAL.GetRowCount("CountTree",
                "WHERE SampleGroup_CN = ? AND TreeCount > 0", this.SampleGroup_CN) > 0;
                }
                return _isTallyModeLocked.Value;

                //return (TallyMethod & CruiseDAL.Enums.TallyMode.Locked) == CruiseDAL.Enums.TallyMode.Locked;
            }
        }

        public bool UseSystematicSampling
        {
            get
            {
                return SampleSelectorType == CruiseDAL.Schema.CruiseMethods.SYSTEMATIC_SAMPLER_TYPE;
            }
            set
            {
                if (UseSystematicSampling == value) { return; }
                if (CanEditSampleType)
                {
                    SampleSelectorType = (value) ? CruiseDAL.Schema.CruiseMethods.SYSTEMATIC_SAMPLER_TYPE : string.Empty;
                    NotifyPropertyChanged(nameof(UseSystematicSampling));
                    this.HasTallyEdits = true;
                }
                else
                {
                    throw new UserFacingException("Sample Settings are locked on this Sample Group");
                }
            }
        }

        public TallyVM SgTallie
        {
            get { return _sgTallie; }
            set { _sgTallie = value; }
        }

        public Dictionary<TreeDefaultValueDO, TallyVM> Tallies { get; set; }

        public IEnumerable<string> ListUsedHotKeys()
        {
            if (this.TallyMethod.HasFlag(CruiseDAL.Enums.TallyMode.BySpecies))
            {
                return (from TallyDO tally in this.Tallies.Values
                        select tally.Hotkey);
            }
            else if (this.TallyMethod.HasFlag(CruiseDAL.Enums.TallyMode.BySampleGroup))
            {
                return new string[] { this.SgTallie.Hotkey, };
            }
            else // SG is not tally by SG or Sp
            {
                return new string[] { };
            }
        }

        public void LoadTallieData()
        {
            if (this._tallieDataLoaded) { return; }//we have already loaded this samplegroup before, don't reload it

            this.TallyPopulations = new Dictionary<String, TallyPopulation>();

            //initialize a tally entity for use with tally by sample group
            TallyVM sgTally = DAL.From<TallyVM>()
                .Join("CountTree", "USING (Tally_CN)")
                .Where("SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) = 0")
                .Query(SampleGroup_CN).FirstOrDefault();

            TallyPopulation sgTallyPopulation = DAL.QuerySingleRecord<TallyPopulation>("SELECT SampleGroup_CN, TreeDefaultValue_CN, Tally.HotKey as HotKey, Tally.Description as Description " +
                "FROM CountTree " +
                "JOIN Tally USING (Tally_CN) " +
                "WHERE CountTree.Tally_CN = Tally.Tally_CN " +
                "AND CountTree.SampleGroup_CN = ? " +
                "AND ifnull(CountTree.TreeDefaultValue_CN, 0) = 0;", this.SampleGroup_CN)
                ?? new TallyPopulation() { Description = Code };

            this.TallyPopulations.Add("", sgTallyPopulation);

            if (sgTally == null)
            {
                sgTally = new TallyVM() { Description = Code };
            }

            SgTallie = sgTally;
            SgTallie.Validate();

            //initialize a list of tallies for use with tally by species
            this.Tallies = new Dictionary<TreeDefaultValueDO, TallyVM>();
            foreach (var tdv in TreeDefaultValues)
            {
                TallyVM tally = DAL.From<TallyVM>()
                    .Join("CountTree", "USING (Tally_CN)")
                    .Where("SampleGroup_CN = ? AND TreeDefaultValue_CN = ?")
                    .Query(this.SampleGroup_CN, tdv.TreeDefaultValue_CN)
                    .FirstOrDefault();

                if (tally == null)
                {
                    tally = new TallyVM() { Description = Code + "/" + tdv.Species + ((tdv.LiveDead == "D") ? "/D" : "") };
                }

                tally.Validate();
                this.Tallies.Add(tdv, tally);

                TallyPopulation tallyPopulation = DAL.QuerySingleRecord<TallyPopulation>("SELECT SampleGroup_CN, TreeDefaultValue_CN, tally.HotKey, tally.Description " +
                "FROM CountTree " +
                "JOIN Tally USING (Tally_CN) " +
                "WHERE CountTree.Tally_CN = Tally.Tally_CN " +
                "AND CountTree.SampleGroup_CN = ? " +
                "AND CountTree.TreeDefaultValue_CN = ?;", this.SampleGroup_CN, tdv.TreeDefaultValue_CN)
                ?? new TallyPopulation() { Description = Code + "/" + tdv.Species + ((tdv.LiveDead == "D") ? "/D" : "") };

                this.TallyPopulations.Add(tdv.Species, tallyPopulation);
            }

            this._tallieDataLoaded = true;
        }

        public bool SaveTallies(ref StringBuilder errorBuilder)
        {
            try
            {
                //if ((sgVM.TallyMethod & TallyMode.Locked) != TallyMode.Locked)
                //{
                //    string delCommand = String.Format("DELETE FROM CountTree WHERE SampleGroup_CN = {0}", sgVM.SampleGroup_CN);
                //    Controller.Database.Execute(delCommand); //cleaned any existing count records.
                //}

                if (TallyMethod.HasFlag(TallyMode.BySampleGroup))
                {
                    SaveTallyBySampleGroup();
                }
                else if (TallyMethod.HasFlag(TallyMode.BySpecies))
                {
                    SaveTallyBySpecies();
                }
                HasTallyEdits = false;
                return true;
            }
            catch (Exception e)
            {
                errorBuilder.AppendFormat("{2}: failed to setup tallies for SampleGroup({0} ) in Stratum ({1})", Code, Stratum.Code, e.GetType().Name);
                return false;
            }
        }

        private void SaveTallyBySpecies()
        {
            //this.Database.BeginTransaction();
            try
            {
                if (!IsTallyModeLocked)
                {
                    //remove any preexisting tally by sg entries
                    string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) = 0;";
                    DAL.Execute(command, SampleGroup_CN);

                    string user = DAL.User;
                    String makeCountsCommand = String.Format(@"INSERT  OR IGNORE INTO CountTree (CuttingUnit_CN, SampleGroup_CN, TreeDefaultValue_CN, CreatedBy)
                        Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN, SampleGroupTreeDefaultValue.TreeDefaultValue_CN, '{0}' AS CreatedBy
                        From SampleGroup
                        INNER JOIN CuttingUnitStratum
                        ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN
                        INNER JOIN SampleGroupTreeDefaultValue
                        ON SampleGroupTreeDefaultValue.SampleGroup_CN = SampleGroup.SampleGroup_CN
                        WHERE SampleGroup.SampleGroup_CN = {1};",
                            user, SampleGroup_CN);

                    DAL.Execute(makeCountsCommand);
                }
                foreach (KeyValuePair<TreeDefaultValueDO, TallyVM> pair in Tallies)
                {
                    TallyVM tally = DAL.From<TallyVM>()
                        .Where("Description = ? AND HotKey = ?")
                        .Query(pair.Value.Description, pair.Value.Hotkey)
                        .FirstOrDefault();

                    if (tally == null)
                    {
                        tally = new TallyVM(DAL) { Description = pair.Value.Description, Hotkey = pair.Value.Hotkey };
                        //tally = pair.Value;
                        //tally.DAL = Controller.Database;
                        tally.Save();
                    }

                    string setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1} AND TreeDefaultValue_CN = {2}",
                        tally.Tally_CN, SampleGroup_CN, pair.Key.TreeDefaultValue_CN);

                    DAL.Execute(setTallyCommand);
                }

                //this.Database.EndTransaction();
            }
            catch (Exception)
            {
                //this.Database.CancelTransaction();
                throw;
            }
        }

        private void SaveTallyBySampleGroup()
        {
            //this.Database.BeginTransaction();
            try
            {
                if (!IsTallyModeLocked)
                {
                    //remove any possible tally by species records
                    string command = "DELETE FROM CountTree WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) != 0;";
                    DAL.Execute(command, SampleGroup_CN);

                    string user = DAL.User;
                    String makeCountsCommand = String.Format(@"INSERT  OR Ignore INTO CountTree (CuttingUnit_CN, SampleGroup_CN,  CreatedBy)
                            Select CuttingUnitStratum.CuttingUnit_CN, SampleGroup.SampleGroup_CN,  '{0}' AS CreatedBy
                            From SampleGroup
                            INNER JOIN CuttingUnitStratum
                            ON SampleGroup.Stratum_CN = CuttingUnitStratum.Stratum_CN
                            WHERE SampleGroup.SampleGroup_CN = {1};", user, SampleGroup_CN);

                    DAL.Execute(makeCountsCommand);
                }
                TallyVM tally = DAL.From<TallyVM>()
                    .Where("Description = ? AND HotKey = ?")
                    .Query(SgTallie.Description, SgTallie.Hotkey)
                    .FirstOrDefault();

                if (tally == null)
                {
                    tally = new TallyVM(DAL)
                    {
                        Description = SgTallie.Description
                        ,
                        Hotkey = SgTallie.Hotkey
                    };

                    //tally = sgVM.SgTallie;
                    tally.Save();
                }

                String setTallyCommand = String.Format("UPDATE CountTree Set Tally_CN = {0} WHERE SampleGroup_CN = {1};",
                    tally.Tally_CN, SampleGroup_CN);

                DAL.Execute(setTallyCommand);

                //this.Database.EndTransaction();
            }
            catch (Exception)
            {
                //this.Database.CancelTransaction();
                throw;
            }
        }

        public override string ToString()
        {
            return Code;
        }
    }
}