using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel;
using FMSC.ORM.EntityModel.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManager.Core.CruiseCustomize
{
    public enum FixCNTTallyField { Unknown, DBH, TotalHeight };

    [EntitySource(SourceName = "FixCNTTallyClass")]
    public class FixCNTTallyClass : DataObject_Base
    {
        public static readonly string[] FIXCNT_FIELD_NAMES = { "DBH", "TotalHeight", "DRC" };

        #region Persisted Members

        string _field;

        [Field(Name = "FieldName")]
        public string Field
        {
            get { return _field; }
            set
            {
                if (_field == value) { return; }
                _field = value;
                base.NotifyPropertyChanged(nameof(Field));
            }
        }

        [PrimaryKeyField(Name = "FixCNTTallyClass_CN")]
        public long? FixCNTTallyClass_CN { get; set; }

        [Field(Name = "Stratum_CN")]
        public long? Stratum_CN { get; set; }

        #endregion Persisted Members

        private IList<FixCNTTallyPopulation> _tallyPopulations;

        public string Errors { get; set; }

        public bool HasChangesToSave
        {
            get
            {
                return IsChanged
                    || !IsPersisted
                    || TallyPopulations.Any(x => x.HasChangesToSave);
            }
        }

        public TallySetupStratum_Base Stratum { get; set; }

        public IList<FixCNTTallyPopulation> TallyPopulations
        {
            get
            {
                if (_tallyPopulations == null)
                {
                    _tallyPopulations = PopulateTallyPopulations();
                }

                return _tallyPopulations;
            }
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Field))
            {
                Errors = "Field Not Set";
                return false;
            }
            else
            {
                Errors = string.Empty;
                return true;
            }
        }

        private IList<FixCNTTallyPopulation> PopulateTallyPopulations()
        {
            System.Diagnostics.Debug.Assert(Stratum != null);

            var list = new List<FixCNTTallyPopulation>();

            var sampleGroups = DAL.From<SampleGroupDO>()
                .Where("Stratum_CN = ?")
                .Query(Stratum_CN);

            foreach (var sg in sampleGroups)
            {
                var treeDefaults = DAL.From<TreeDefaultValueDO>()
                    .Join("SampleGroupTreeDefaultValue", "USING (TreeDefaultValue_CN)")
                    .Where("SampleGroup_CN = ?")
                    .Query(sg.SampleGroup_CN);

                foreach (var tdv in treeDefaults)
                {
                    var pop = DAL.From<FixCNTTallyPopulation>()
                        .Where("SampleGroup_CN = ? AND TreeDefaultValue_CN = ?")
                        .Query(sg.SampleGroup_CN, tdv.TreeDefaultValue_CN).FirstOrDefault();

                    if (pop == null)
                    {
                        pop = new FixCNTTallyPopulation()
                        {
                            DAL = this.DAL,
                            SampleGroup_CN = sg.SampleGroup_CN,
                            TreeDefaultValue_CN = tdv.TreeDefaultValue_CN,
                        };
                    }

                    pop.TallyClass = this;

                    list.Add(pop);
                }
            }

            return list;
        }
    }
}