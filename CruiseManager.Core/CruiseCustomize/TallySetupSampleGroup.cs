using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseDAL.Enums;
using CruiseManager.Core.App;
using FMSC.ORM.EntityModel;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManager.Core.CruiseCustomize
{
    [EntitySource(SourceName = "SampleGroup")]
    public class TallySetupSampleGroup : DataObject_Base
    {
        private TallyVM _sgTallie;
        private bool _hasTallyEdits = false;
        private bool _tallieDataLoaded = false;

        #region CTor

        public TallySetupSampleGroup()
            : base()
        { }

        public TallySetupSampleGroup(DAL db)
            : base(db)
        { }

        #endregion CTor

        #region Persisted Members

        [PrimaryKeyField(Name = "SampleGroup_CN")]
        public Int64? SampleGroup_CN { get; set; }

        [Field(Name = "Stratum_CN")]
        public virtual long? Stratum_CN { get; set; }

        [Field(Name = "Code")]
        public virtual String Code { get; set; }

        [Field(Name = "TallyMethod")]
        public virtual CruiseDAL.Enums.TallyMode TallyMethod { get; set; }

        //[Field(Name = "Description")]
        //public virtual String Description { get; set; }

        [Field(Name = "SampleSelectorType")]
        public virtual String SampleSelectorType { get; set; }

        [Field(Name = "SampleSelectorState")]
        public virtual String SampleSelectorState { get; set; }

        #endregion Persisted Members

        public TallySetupStratum Stratum { get; set; }

        private IList<TreeDefaultValueDO> _treeDefaultValues;

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
            if (base.DAL.GetRowCount("CountTree", "WHERE SampleGroup_CN = ?", SampleGroup_CN) == 0)
            {
                return TallyMode.None;
            }

            if (base.DAL.GetRowCount("CountTree",
                "WHERE SampleGroup_CN = ? AND ifnull(TreeDefaultValue_CN, 0) == 0",
                SampleGroup_CN) > 0)
            {
                mode = mode | TallyMode.BySampleGroup;
            }
            if (base.DAL.GetRowCount("CountTree",
                "WHERE SampleGroup_CN = ? AND TreeDefaultValue_CN NOT NULL AND TreeDefaultValue_CN > 0",
                this.SampleGroup_CN) > 0)
            {
                mode = mode | TallyMode.BySpecies;
            }
            if (base.DAL.GetRowCount("CountTree",
                "WHERE SampleGroup_CN = ? AND TreeCount > 0", this.SampleGroup_CN) > 0)
            {
                mode = mode | TallyMode.Locked;
            }

            return mode;
        }

        public bool HasTallyEdits
        {
            get { return _hasTallyEdits; }
            set { _hasTallyEdits = value; }
        }

        public bool IsTallyModeLocked
        {
            get
            {
                return (TallyMethod & CruiseDAL.Enums.TallyMode.Locked) == CruiseDAL.Enums.TallyMode.Locked;
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
                    tally = new TallyVM() { Description = tdv.Species + ((tdv.LiveDead == "D") ? "/D" : "") };
                }

                tally.Validate();
                this.Tallies.Add(tdv, tally);

                TallyPopulation tallyPopulation = DAL.QuerySingleRecord<TallyPopulation>("SELECT SampleGroup_CN, TreeDefaultValue_CN, tally.HotKey, tally.Description " +
                "FROM CountTree " +
                "JOIN Tally USING (Tally_CN) " +
                "WHERE CountTree.Tally_CN = Tally.Tally_CN " +
                "AND CountTree.SampleGroup_CN = ? " +
                "AND CountTree.TreeDefaultValue_CN = ?;", this.SampleGroup_CN, tdv.TreeDefaultValue_CN)
                ?? new TallyPopulation() { Description = tdv.Species + ((tdv.LiveDead == "D") ? "/D" : "") };

                this.TallyPopulations.Add(tdv.Species, tallyPopulation);
            }

            this._tallieDataLoaded = true;
        }

        public override string ToString()
        {
            return Code;
        }
    }
}