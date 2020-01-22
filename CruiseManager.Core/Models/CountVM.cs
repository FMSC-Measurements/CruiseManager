using FMSC.ORM.EntityModel.Attributes;

namespace CruiseManager.Core.Models
{
    [EntitySource("CountTree",
        JoinCommands = 
        @"JOIN CuttingUnit USING (CuttingUnit_CN)
JOIN Samplegroup USING (SampleGroup_CN)
JOIN Stratum USING (Stratum_CN)
LEFT JOIN Tally USING (Tally_CN)
LEFT JOIN TreeDefaultValue as tdv USING (TreeDefaultValue_CN)
LEFT JOIN Component as comp USING (Component_CN)")]
    public class CountVM : CruiseDAL.DataObjects.CountTreeDO
    {
        [Field(SQLExpression = "CuttingUnit.Code", Alias = "UnitCode", PersistanceFlags = PersistanceFlags.Never)]
        public string UnitCode { get; set; }

        [Field(SQLExpression = "Stratum.Code", Alias = "StratumCode", PersistanceFlags = PersistanceFlags.Never)]
        public string StratumCode { get; set; }

        [Field(SQLExpression = "SampleGroup.Code", Alias = "SGCode", PersistanceFlags = PersistanceFlags.Never)]
        public string SGCode { get; set; }

        [Field(SQLExpression = "Tally.HotKey", Alias = "TallyHotKey", PersistanceFlags = PersistanceFlags.Never)]
        public string TallyHotKey { get; set; }

        [Field(SQLExpression = "tdv.Species", Alias = "Species", PersistanceFlags = PersistanceFlags.Never)]
        public string Species { get; set; }

        [Field(SQLExpression = "tdv.PrimaryProduct", Alias = "Product", PersistanceFlags = PersistanceFlags.Never)]
        public string Product { get; set; }

        [IgnoreField]
        public string LiveDead { get; set; }

        public string SpeciesProd => (string.IsNullOrEmpty(Species)) ? "N/A" : $"{Species}|{Product}|{LiveDead}";

        [Field(SQLExpression = "comp.FileName", Alias = "ComponentFileName", PersistanceFlags = PersistanceFlags.Never)]
        public string ComponentFileName { get; set; }

    }
}