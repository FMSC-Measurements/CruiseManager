using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public interface IFixCNTTallyPopulation
    {
        //string SpeciesName { get; set; }

        long? ID { get; }

        long? SampleGroup_CN { get; }
        long? TreeDefaultValue_CN { get; }

        TreeDefaultValueDO TreeDefaultValue { get; }
        SampleGroupDO SampleGroup { get; }

        long? FixCNTTallyClass_CN { get; set; }
        IFixCNTTallyClass TallyClass { get; set; }

        double IntervalSize { get; set; }
        double Min { get; set; }
        double Max { get; set; }

    }

    [EntitySource(SourceName = "FixCNTTallyPopulation")]
    public class FixCNTTallyPopulation : IFixCNTTallyPopulation
    {

        #region IFixCNTTallyPopulation Members

        [Field(Name = "ID")]
        public long? ID { get; set; }

        [Field(Name = "SampleGroup_CN")]
        public long? SampleGroup_CN { get; set; }
        public SampleGroupDO SampleGroup
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        [Field(Name = "TreeDefaultValue_CN")]
        public long? TreeDefaultValue_CN { get; set; }
        public TreeDefaultValueDO TreeDefaultValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        [Field(Name = "FixCNTTallyClass_CN")]
        public long? FixCNTTallyClass_CN { get; set; }
        public IFixCNTTallyClass TallyClass { get; set; }

        [Field(Name = "IntervalSize")]
        public double IntervalSize { get; set; }

        [Field(Name = "Min")]
        public double Min { get; set; }

        [Field(Name = "Max")]
        public double Max { get; set; }
        #endregion       
    }
}
