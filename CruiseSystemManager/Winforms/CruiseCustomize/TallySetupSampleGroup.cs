using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;

namespace CSM.Winforms.CruiseCustomize
{
    public class TallySetupSampleGroup : SampleGroupDO
    {
        private TallyVM _sgTallie;
        private bool _hasTallyEdits = false;
        private bool _tallieDataLoaded = false;

        public TallySetupSampleGroup()
            : base()
        { }

        public TallySetupSampleGroup(DAL db)
            : base(db)
        { }

        public TallySetupSampleGroup(SampleGroupDO dObj)
            : base(dObj)
        { }

        public Dictionary<TreeDefaultValueDO, TallyVM> Tallies { get; set; }

        public TallyVM SgTallie 
        {
            get { return _sgTallie; }
            set { _sgTallie = value; }
        }

        public bool HasTallyEdits
        {
            get { return _hasTallyEdits; }
            set { _hasTallyEdits = value; }
        }


        public bool UseSystematicSampling
        {
            get
            {
                if (IsSTR)
                {
                    return base.SampleSelectorType == CruiseDAL.Schema.Constants.CruiseMethods.SYSTEMATIC_SAMPLER_TYPE;
                }
                return false;
            }
            set
            {
                if (IsSTR && CanChangeSamplerType)
                {
                    base.SampleSelectorType = (value) ? CruiseDAL.Schema.Constants.CruiseMethods.SYSTEMATIC_SAMPLER_TYPE : string.Empty;
                    this.HasTallyEdits = true;
                }
            }
        }

        public bool CanChangeSamplerType
        {
            get
            {
                return SampleGroupDO.CanChangeSamplerType(this);
            }
        }

        public bool IsSTR
        {
            get
            {
                return base.Stratum.Method == CruiseDAL.Schema.Constants.CruiseMethods.STR;
            }
        }

        #region readMethods
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
        #endregion

        public void LoadTallieData()
        {
            if (this._tallieDataLoaded) { return; }//we have already loaded this samplegroup before, dont reload it

            //initialize a tally entity for use with tally by sample group
            TallyVM sgTally = DAL.ReadSingleRow<TallyVM>("Tally",
                "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND ifnull(CountTree.TreeDefaultValue_CN, 0) = 0",
                this.SampleGroup_CN);


            if (sgTally == null)
            {
                sgTally = new TallyVM() { Description = Code };
            }

            SgTallie = sgTally;
            SgTallie.Validate();




            //initialize a list of tallys for use with tally by species 
            this.Tallies = new Dictionary<TreeDefaultValueDO, TallyVM>();
            this.TreeDefaultValues.Populate();
            foreach (TreeDefaultValueDO tdv in this.TreeDefaultValues)
            {
                TallyVM tally = base.DAL.Read<TallyVM>("Tally", "JOIN CountTree WHERE CountTree.Tally_CN = Tally.Tally_CN AND CountTree.SampleGroup_CN = ? AND CountTree.TreeDefaultValue_CN = ?",
                    this.SampleGroup_CN, tdv.TreeDefaultValue_CN).FirstOrDefault();

                if (tally == null)
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
}
