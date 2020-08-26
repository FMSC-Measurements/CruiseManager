using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;

namespace CruiseManager.Core.CruiseCustomize
{
    [Table("Tally")]
    public class TallyVM : TallyDO
    {
        public TallyVM() : base()
        {
        }

        public TallyVM(DAL db) : base(db)
        {
        }

        public override string Hotkey
        {
            get
            {
                return base.Hotkey;
            }

            set
            {
                if (base.Hotkey == value) { return; }
                base.Hotkey = value;
            }
        }

        public override string IndicatorType
        {
            get
            {
                return base.IndicatorType;
            }

            set
            {
                if (base.IndicatorType == value) { return; }
                base.IndicatorType = value;
            }
        }

        public override string IndicatorValue
        {
            get
            {
                return base.IndicatorValue;
            }

            set
            {
                if (base.IndicatorValue == value) { return; }
                base.IndicatorValue = value;
            }
        }

        public override string Description
        {
            get
            {
                return base.Description;
            }

            set
            {
                if (base.Description == value) { return; }
                base.Description = value;
            }
        }
    }

    public class TallyPopulation
    {
        public SampleGroupDO SampleGroup { get; set; }

        public TreeDefaultValueDO Species { get; set; }

        public long? SampleGroup_CN { get; set; }

        public long? TreeDefaultValue_CN { get; set; }

        public string Hotkey { get; set; }

        public string Description { get; set; }

        public string IndicatorType { get; set; }
    }
}