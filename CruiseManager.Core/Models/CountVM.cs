using FMSC.ORM.EntityModel.Attributes;

namespace CruiseManager.Core.Models
{
    [EntitySource(SourceName = "CountTree",
        JoinCommands = @"LEFT JOIN Samplegroup USING (SampleGroup_CN)
LEFT JOIN Stratum USING (Stratum_CN)")]
    public class CountVM : CruiseDAL.DataObjects.CountTreeDO
    {
        [Field(SQLExpression = "Stratum.Code", Alias = "StratumCode", PersistanceFlags = PersistanceFlags.Never)]
        public string StratumCode { get; set; }

        [Field(SQLExpression = "SampleGroup.Code", Alias = "SGCode", PersistanceFlags = PersistanceFlags.Never)]
        public string SGCode { get; set; }
    }
}