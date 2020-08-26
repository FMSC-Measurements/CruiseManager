using CruiseDAL.DataObjects;
using CruiseDAL.Enums;
using CruiseDAL.Schema;
using CruiseManager.Core.App;
using FMSC.ORM.EntityModel;
using FMSC.ORM.EntityModel.Attributes;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    [EntitySource(SourceName = "SampleGroup")]
    public class TallySetupSampleGroup : DataObject_Base
    {
        bool _hasTallyEdits;
        bool? _isTallyModeLocked;
        TallyVM _sgTallie;
        bool _tallieDataLoaded;
        IList<TreeDefaultValueDO> _treeDefaultValues;

        #region Persisted Members

        [Field(Name = "Code", PersistanceFlags = PersistanceFlags.Never)]
        public virtual String Code { get; set; }

        [PrimaryKeyField(Name = "SampleGroup_CN", PersistanceFlags = PersistanceFlags.Never)]
        public Int64? SampleGroup_CN { get; set; }

        [Field(Name = "Stratum_CN", PersistanceFlags = PersistanceFlags.Never)]
        public virtual long? Stratum_CN { get; set; }

        string _sampleSelectorType;

        [Field(Name = "SampleSelectorType")]
        public virtual String SampleSelectorType
        {
            get { return _sampleSelectorType; }
            set
            {
                if (_sampleSelectorType == value) { return; }
                _sampleSelectorType = value;
                NotifyPropertyChanged(nameof(SampleSelectorType));
            }
        }

        TallyMode _tallyMethod;

        [Field(Name = "TallyMethod")]
        public virtual CruiseDAL.Enums.TallyMode TallyMethod
        {
            get
            {
                if (_tallyMethod == TallyMode.Unknown)
                {
                    TallyMethod = GetSampleGroupTallyMode();
                }
                return _tallyMethod;
            }
            set
            {
                if (_tallyMethod == value) { return; }
                _tallyMethod = value;
                base.NotifyPropertyChanged(nameof(TallyMethod));
            }
        }

        //[Field(Name = "SampleSelectorState")]
        //public virtual String SampleSelectorState { get; set; }

        //[Field(Name = "Description")]
        //public virtual String Description { get; set; }

        #endregion Persisted Members

        [IgnoreField]
        public bool IsTallyModeLocked
        {
            get
            {
                if (_isTallyModeLocked == null)
                {
                    _isTallyModeLocked = DAL.GetRowCount("CountTree", "WHERE SampleGroup_CN = @p1 AND TreeCount > 0", this.SampleGroup_CN) > 0
                        && DAL.GetRowCount("Tree", "WHERE SampleGroup_CN = @p1", SampleGroup_CN) > 0;
                }

                return _isTallyModeLocked.Value;

                //return (TallyMethod & CruiseDAL.Enums.TallyMode.Locked) == CruiseDAL.Enums.TallyMode.Locked;
            }
        }

        public bool CanEditSampleType => !IsTallyModeLocked
                    && Stratum.Method == CruiseMethods.STR;

        public bool CanTallyBySG => Stratum.Method != CruiseMethods.THREEP;

        public bool CanTallyBySpecies => true;

        public bool CanSelectSystematic =>
            !IsTallyModeLocked
            && !UseClickerTally
            && Stratum.Method == CruiseMethods.STR;

        [IgnoreField]
        public bool UseSystematicSampling
        {
            get
            {
                return SampleSelectorType == CruiseMethods.SYSTEMATIC_SAMPLER_TYPE;
            }
            set
            {
                if (!CanEditSampleType) { return; }

                SampleSelectorType = (value) ? CruiseMethods.SYSTEMATIC_SAMPLER_TYPE : string.Empty;

                NotifyPropertyChanged(nameof(UseSystematicSampling));
                NotifyPropertyChanged(nameof(CanSelectClickerTally));
            }
        }

        public bool CanSelectClickerTally =>
            !IsTallyModeLocked
            && !UseSystematicSampling
            && Stratum.Method == CruiseMethods.STR;

        [IgnoreField]
        public bool UseClickerTally
        {
            get { return SampleSelectorType == CruiseMethods.CLICKER_SAMPLER_TYPE; }
            set
            {
                if (!CanSelectClickerTally) { return; }

                SampleSelectorType = (value) ? CruiseMethods.CLICKER_SAMPLER_TYPE : string.Empty;

                NotifyPropertyChanged(nameof(CanSelectSystematic));
                NotifyPropertyChanged(nameof(UseClickerTally));
            }
        }

        public new CruiseDAL.DAL DAL
        {
            get { return (CruiseDAL.DAL)base.DAL; }
            set { base.DAL = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has changes
        /// to associated countTreeRecords and a call to SaveTallies is required
        /// </summary>
        [IgnoreField]
        public bool HasTallyEdits
        {
            get { return _hasTallyEdits; }
            set { _hasTallyEdits = value; }
        }

        public TallyVM SgTallie
        {
            get { return _sgTallie; }
            set { _sgTallie = value; }
        }

        public TallySetupStratum_Base Stratum { get; set; }

        public Dictionary<TreeDefaultValueDO, TallyVM> Tallies { get; set; }

        public Dictionary<String, TallyPopulation> TallyPopulations { get; protected set; }

        public IList<TreeDefaultValueDO> TreeDefaultValues
        {
            get
            {
                if (_treeDefaultValues == null)
                {
                    _treeDefaultValues = DAL.From<TreeDefaultValueDO>()
                        .Join("SampleGroupTreeDefaultValue", "USING (TreeDefaultValue_CN)")
                        .Where("SampleGroup_CN = @p1")
                        .Query(SampleGroup_CN).ToList();
                }
                return _treeDefaultValues;
            }
        }

        public TallyMode GetSampleGroupTallyMode()
        {
            TallyMode mode = TallyMode.Unknown;
            if (DAL.GetRowCount("CountTree", "WHERE SampleGroup_CN = @p1", SampleGroup_CN) == 0)
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
                "WHERE SampleGroup_CN = @p1 AND ifnull(TreeDefaultValue_CN, 0) == 0",
                SampleGroup_CN) > 0)
            {
                mode = mode | TallyMode.BySampleGroup;
            }
            if (DAL.GetRowCount("CountTree",
                "WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN NOT NULL AND TreeDefaultValue_CN > 0",
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
                .Where("SampleGroup_CN = @p1 AND ifnull(TreeDefaultValue_CN, 0) = 0")
                .Query(SampleGroup_CN).FirstOrDefault();

            TallyPopulation sgTallyPopulation = DAL.Query<TallyPopulation>("SELECT SampleGroup_CN, TreeDefaultValue_CN, Tally.HotKey as HotKey, Tally.Description as Description " +
                "FROM CountTree " +
                "JOIN Tally USING (Tally_CN) " +
                "WHERE CountTree.Tally_CN = Tally.Tally_CN " +
                "AND CountTree.SampleGroup_CN = @p1 " +
                "AND ifnull(CountTree.TreeDefaultValue_CN, 0) = 0;", this.SampleGroup_CN).FirstOrDefault()
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
                    .Where("SampleGroup_CN = @p1 AND TreeDefaultValue_CN = @p2")
                    .Query(this.SampleGroup_CN, tdv.TreeDefaultValue_CN)
                    .FirstOrDefault();

                if (tally == null)
                {
                    tally = new TallyVM() { Description = Code + "/" + tdv.Species + ((tdv.LiveDead == "D") ? "/D" : "") };
                }

                tally.Validate();
                this.Tallies.Add(tdv, tally);

                TallyPopulation tallyPopulation = DAL.Query<TallyPopulation>("SELECT SampleGroup_CN, TreeDefaultValue_CN, tally.HotKey, tally.Description " +
                "FROM CountTree " +
                "JOIN Tally USING (Tally_CN) " +
                "WHERE CountTree.Tally_CN = Tally.Tally_CN " +
                "AND CountTree.SampleGroup_CN = @p1 " +
                "AND CountTree.TreeDefaultValue_CN = @p2;", this.SampleGroup_CN, tdv.TreeDefaultValue_CN).FirstOrDefault()
                ?? new TallyPopulation() { Description = Code + "/" + tdv.Species + ((tdv.LiveDead == "D") ? "/D" : "") };

                if (!this.TallyPopulations.ContainsKey(tdv.Species))
                {
                    this.TallyPopulations.Add(tdv.Species, tallyPopulation);
                }
            }

            this._tallieDataLoaded = true;
        }

        public bool SaveTallies(ref StringBuilder errorBuilder)
        {
            try
            {
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
                Crashes.TrackError(e);
                errorBuilder.Append($"{e.GetType().Name}: failed to setup tallies for SampleGroup({Code} ) in Stratum ({Stratum.Code})");
                return false;
            }
        }

        public override string ToString()
        {
            return Code;
        }

        private void SaveTallyBySampleGroup()
        {
            var db = DAL;
            var sg_cn = SampleGroup_CN;

            var hasTallyBySp = db.ExecuteScalar<int>("SELECT count(*) FROM CountTree WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN IS NOT NULL;", sg_cn) > 0;
            if(hasTallyBySp)
            {
                var numTrees = db.ExecuteScalar<int>("SELECT count(*) FROM Tree WHERE SampleGroup_CN = @p1;", sg_cn);
                var treeCount = db.ExecuteScalar<int>("SELECT ifnull(sum(TreeCount), 0) FROM CountTree WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN IS NOT NULL;", sg_cn);
                if (numTrees == 0 && treeCount == 0)
                {
                    db.Execute("DELETE FROM CountTree WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN IS NOT NULL;", sg_cn);
                }
                else
                {
                    // should not be possible. UI prevents changing tally type if trees exist.
                    throw new UserFacingException("Can not remove tally by species setup because of trees or tree counts exist");
                }
            }

            TallyVM tally = DAL.From<TallyVM>()
                .Where("Description = @p1 AND HotKey = @p2")
                .Query(SgTallie.Description, SgTallie.Hotkey)
                .FirstOrDefault();

            if (tally == null)
            {
                tally = new TallyVM(DAL)
                {
                    Description = SgTallie.Description,
                    Hotkey = SgTallie.Hotkey,
                };
                db.Insert(tally);
            }

            var countTreeExists = db.ExecuteScalar<int>("SELECT count(*) FROM CountTree WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN IS NULL;", sg_cn) > 0;
            if (countTreeExists)
            {
                db.Execute("UPDATE CountTree Set Tally_CN = @p1 WHERE SampleGroup_CN = @p2;", tally.Tally_CN, sg_cn);
            }
            else
            {
                var user = db.User;
                db.Execute(
@"INSERT OR IGNORE INTO CountTree (CuttingUnit_CN, SampleGroup_CN, Tally_CN, CreatedBy)
    Select cust.CuttingUnit_CN, sg.SampleGroup_CN, @p2, @p3 AS CreatedBy
    From CuttingUnitStratum AS cust
    JOIN Stratum AS st USING (Stratum_CN)
    JOIN SampleGroup AS sg USING (Stratum_CN)
    WHERE sg.SampleGroup_CN = @p1;", sg_cn, tally.Tally_CN, user);
            }
            
        }

        private void SaveTallyBySpecies()
        {
            var db = DAL;
            var sg_cn = SampleGroup_CN;

            var hasTallyBySg = db.ExecuteScalar<int>("SELECT count(*) FROM CountTree WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN IS NULL;", sg_cn) > 0;
            if (hasTallyBySg)
            {
                var numTrees = db.ExecuteScalar<int>("SELECT count(*) FROM Tree WHERE SampleGroup_CN = @p1;", sg_cn);
                var treeCount = db.ExecuteScalar<int>("SELECT ifnull(sum(TreeCount), 0) FROM CountTree WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN IS NULL;", sg_cn);
                if (numTrees == 0 && treeCount == 0)
                {
                    db.Execute("DELETE FROM CountTree WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN IS NULL;", sg_cn);
                }
                else
                {
                    // should not be possible. UI prevents changing tally type if trees exist.
                    throw new UserFacingException("Can not remove tally by sample group setup because of trees or tree counts exist");
                }
            }


            string user = db.User;
            foreach (KeyValuePair<TreeDefaultValueDO, TallyVM> pair in Tallies)
            {
                var tally = pair.Value;

                var persistedTally = DAL.From<TallyVM>()
                    .Where("Description = @p1 AND HotKey = @p2")
                    .Query(tally.Description, tally.Hotkey)
                    .FirstOrDefault();

                if (persistedTally == null)
                {
                    persistedTally = new TallyVM(db)
                    {
                        Description = tally.Description,
                        Hotkey = tally.Hotkey
                    };
                    db.Insert(persistedTally);
                }

                var tdv_cn = pair.Key.TreeDefaultValue_CN.Value;
                var countTreeExists = db.ExecuteScalar<int>("SELECT count(*) FROM CountTree WHERE SampleGroup_CN = @p1 AND TreeDefaultValue_CN = @p2;", sg_cn, tdv_cn) > 0;

                if (countTreeExists == false)
                {
                    db.Execute(
@"INSERT OR IGNORE INTO CountTree (CuttingUnit_CN, SampleGroup_CN, TreeDefaultValue_CN, Tally_CN, CreatedBy)
    Select cust.CuttingUnit_CN, sg.SampleGroup_CN, @p2, @p3, @p4 AS CreatedBy
    From CuttingUnitStratum AS cust
    JOIN Stratum AS st USING (Stratum_CN)
    JOIN SampleGroup AS sg USING (Stratum_CN)
    WHERE sg.SampleGroup_CN = @p1;", sg_cn, tdv_cn, persistedTally.Tally_CN, user);
                }
                else
                {
                    db.Execute("UPDATE CountTree Set Tally_CN = @p1 WHERE SampleGroup_CN = @p2 AND TreeDefaultValue_CN = @p3;", persistedTally.Tally_CN, sg_cn, tdv_cn);
                }

            }

        }
    }
}