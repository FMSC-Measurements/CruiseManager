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
        #region Persisted Members

        [Field(Name = "FieldName")]
        public FixCNTTallyField Field { get; set; }

        [Field(Name = "Stratum_CN")]
        public long? Stratum_CN { get; set; }

        #endregion Persisted Members

        public string Errors { get; set; }

        public TallySetupStratum_Base Stratum { get; set; }

        private IList<FixCNTTallyPopulation> _tallyPopulations;

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

        private IList<FixCNTTallyPopulation> PopulateTallyPopulations()
        {
            var list = DAL.From<FixCNTTallyPopulation>()
                .Join("FixCNTTallyClass", "USING (FixCNTTallyClass_CN)")
                .Where("Stratum_CN = ?")
                .Query(Stratum_CN).ToList();

            if (list == null
                || list.Count == 0)
            {
                MakeTallyPopulations();
            }

            return list;
        }

        private IList<FixCNTTallyPopulation> MakeTallyPopulations()
        {
            System.Diagnostics.Debug.Assert(Stratum != null);

            var list = new List<FixCNTTallyPopulation>();

            foreach (var sg in Stratum.SampleGroups)
            {
                foreach (var tdv in sg.TreeDefaultValues)
                {
                    var newPop = new FixCNTTallyPopulation()
                    {
                        SampleGroup_CN = sg.SampleGroup_CN ,
                        TreeDefaultValue_CN = tdv.TreeDefaultValue_CN ,
                        TallyClass = this
                    };

                    list.Add(newPop);
                }
            }
            return list;
        }

        public bool Validate()
        {
            if (Field == FixCNTTallyField.Unknown)
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
    }
}