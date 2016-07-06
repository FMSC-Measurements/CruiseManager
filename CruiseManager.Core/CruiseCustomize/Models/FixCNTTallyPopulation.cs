using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    [EntitySource(SourceName = "FixCNTTallyPopulation")]
    public class FixCNTTallyPopulation : DataObject_Base
    {
        #region Persisted Members

        double _min;

        double _max;

        double _intervalSize;

        [Field(Name = "SampleGroup_CN")]
        public long? SampleGroup_CN { get; set; }

        [Field(Name = "TreeDefaultValue_CN")]
        public long? TreeDefaultValue_CN { get; set; }

        [Field(Name = "FixCNTTallyClass_CN")]
        public long? FixCNTTallyClass_CN
        {
            get { return TallyClass.FixCNTTallyClass_CN; }
            set { }
        }

        [PrimaryKeyField(Name = "FixCNTTallyPopulation_CN")]
        public long? FixCNTTallyPopulation_CN { get; set; }

        [Field(Name = "IntervalSize")]
        public double IntervalSize
        {
            get { return _intervalSize; }
            set
            {
                if (_intervalSize.EqualsEx(value)) { return; }
                _intervalSize = value;
                NotifyPropertyChanged(nameof(IntervalSize));
            }
        }

        [Field(Name = "Min")]
        public double Min
        {
            get { return _min; }
            set
            {
                if (_min.EqualsEx(value)) { return; }
                _min = value;
                NotifyPropertyChanged(nameof(Min));
            }
        }

        [Field(Name = "Max")]
        public double Max
        {
            get { return _max; }
            set
            {
                if (_max.EqualsEx(value)) { return; }
                _max = value;
                NotifyPropertyChanged(nameof(Max));
            }
        }

        #endregion Persisted Members

        public string Errors { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                return IsChanged || !IsPersisted;
            }
        }

        public FixCNTTallyClass TallyClass { get; set; }

        TreeDefaultValueDO _treeDefaultValue;

        public TreeDefaultValueDO TreeDefaultValue
        {
            get
            {
                if (_treeDefaultValue == null)
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

        public IEnumerable<Double> EnumerateMaxOptions()
        {
            var opt = (Min > 0) ? Min : 0;

            if (Max > 0)
            {
                yield return Max;
            }

            opt = opt - 0.1;
            if (IntervalSize > 0)
            {
                while (true)
                {
                    opt = opt + IntervalSize;
                    yield return opt;
                }
            }
        }

        public bool Validate()
        {
            var errorBuilder = new StringBuilder();
            bool isValid = true;

            if (IntervalSize <= 0)
            {
                errorBuilder.AppendLine("Inc Too Small");
                isValid = false;
            }
            if (Max <= Min
                || ((Max + 0.1) - Min).LessThanEx(IntervalSize))
            {
                errorBuilder.AppendLine("Min/Max Range Invalid");
                isValid = false;
            }

            Errors = errorBuilder.ToString();

            return isValid;
        }
    }
}