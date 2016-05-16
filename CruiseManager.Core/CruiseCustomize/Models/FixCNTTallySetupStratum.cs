using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class FixCNTTallySetupStratum : TallySetupStratum_Base
    {
        FixCNTTallyClass _tallyClass;

        public FixCNTTallyClass TallyClass
        {
            get
            {
                if (_tallyClass == null)
                {
                    _tallyClass = DAL.From<FixCNTTallyClass>()
                        .Where("Stratum_CN = ?")
                        .Query(Stratum_CN)
                        .FirstOrDefault()
                        ?? new FixCNTTallyClass()
                        {
                            Stratum_CN = Stratum_CN,
                            DAL = this.DAL
                        };

                    _tallyClass.Stratum = this;
                }
                return _tallyClass;
            }
        }

        public override bool HasChangesToSave
        {
            get
            {
                return IsChanged 
                    || !IsPersisted
                    || TallyClass.HasChangesToSave;
            }
        }

        //called when the view is initialized, for each stratum
        //initialized a list containing information about sampleGroups
        public override void Initialize()
        {
            if (SampleGroups != null) { return; }//if we have already created initialized this stratum,

            SampleGroups = DAL.From<TallySetupSampleGroup>()
                .Where("Stratum_CN = ?").Read(Stratum_CN).ToList();
            foreach (TallySetupSampleGroup sg in SampleGroups)
            {
                sg.Stratum = this;
            }
        }

        public override bool SaveTallySetup(ref StringBuilder errorBuilder)
        {
            bool success = true;

            TallyClass.Save();

            foreach (var pop in TallyClass.TallyPopulations)
            {
                pop.Save();
            }

            return success;
        }

        public override bool Validate()
        {
            var errorBuilder = new StringBuilder();
            bool isValid = true;

            if (!TallyClass.Validate())
            {
                errorBuilder.AppendLine(TallyClass.Errors);
                isValid = false;
            }

            foreach (var tallyPop in TallyClass.TallyPopulations)
            {
                if (!tallyPop.Validate())
                {
                    errorBuilder.AppendLine(tallyPop.Errors);
                    isValid = false;
                }
            }

            Errors = errorBuilder.ToString();

            return isValid;
        }
    }
}