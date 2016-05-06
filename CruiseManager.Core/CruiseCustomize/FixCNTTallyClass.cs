using CruiseManager.Core.Models;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public enum FixCNTTallyField { Unknown, DBH, TotalHeight };

    public interface IFixCNTTallyClass
    {
        FixCNTTallyField Field { get; set; }

        long? Stratum_CN { get; set; }

        TallySetupStratum Stratum { get; set; }


    }


    [EntitySource(SourceName = "FixCNTClass")]
    public class FixCNTTallyClass : IFixCNTTallyClass
    {
        [Field(Name = "FieldName")]
        public FixCNTTallyField Field { get; set; }

        [Field(Name = "Stratum_CN")]
        public long? Stratum_CN { get; set; }

        public TallySetupStratum Stratum { get; set; }


    }
}
