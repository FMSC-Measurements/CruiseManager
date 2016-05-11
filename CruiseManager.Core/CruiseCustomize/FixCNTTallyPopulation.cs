using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManager.Core.CruiseCustomize
{
    [EntitySource(SourceName = "FixCNTTallyPopulation")]
    public class FixCNTTallyPopulation : DataObject_Base
    {       

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

        TreeDefaultValueDO _treeDefaultValue;
        public TreeDefaultValueDO TreeDefaultValue
        {
            get
            {
                if(_treeDefaultValue == null)
                {
                    _treeDefaultValue = DAL.From<TreeDefaultValueDO>()
                        .Where("TreeDefaultValue_CN = ?")
                        .Query(TreeDefaultValue_CN).FirstOrDefault();
                }
                return _treeDefaultValue;
            }
            set
            {
                _treeDefaultValue = value;
            }
        }

        [Field(Name = "FixCNTTallyClass_CN")]
        public long? FixCNTTallyClass_CN { get; set; }

        public FixCNTTallyClass TallyClass { get; set; }

        [Field(Name = "IntervalSize")]
        public double IntervalSize { get; set; }

        [Field(Name = "Min")]
        public double Min { get; set; }

        [Field(Name = "Max")]
        public double Max { get; set; }

        public IEnumerable<Double> MaxOptions()
        {
            var opt = (Min > 0) ? Min : 0;

            if (Max > 0)
            {
                yield return Max;
            }

            if (IntervalSize > 0)
            {
                while (true)
                {
                    opt = opt + IntervalSize;
                    yield return opt;
                }
            }
        }

        
    }
}