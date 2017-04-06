using CruiseDAL;
using CruiseDAL.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.EditDesign
{
    public class DesignEditorSampleGroup : SampleGroupDO
    {
        public DesignEditorSampleGroup(DAL dal) : base(dal)
        {
        }

        public DesignEditorSampleGroup(SampleGroupDO sg) : base(sg)
        {
        }

        public DesignEditorSampleGroup()
        {
        }

        public bool Validate(StratumDO st, out string error)
        {
            bool isValid = true;
            error = null;
            Validate(CruiseDAL.Schema.SAMPLEGROUP._ALL.Except(new string[] { "Stratum_CN" }));
            string pre = $"Stratum: {st.Code} IN SG: {Code} -";
            if (HasErrors())
            {
                isValid = false;
                error += pre + Error;
            }
            if (String.IsNullOrEmpty(Code))
            {
                isValid = false;
                error += pre + " Code can't be empty";
            }
            if (TreeDefaultValues.Count == 0)
            {
                isValid = false;
                error += pre + " No Tree Defaults Selected";
            }

            isValid = ValidatePProdOnTDVs(ref error) && isValid;
            return isValid;
        }
    }
}