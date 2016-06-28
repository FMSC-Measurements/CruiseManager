using FMSC.ORM.EntityModel.Attributes;

namespace CruiseManager.Core.Models
{
    [EntitySource(SourceName = "Log",
        JoinCommands = @"JOIN Tree USING (Tree_CN)
JOIN CuttingUnit USING (CuttingUnit_CN)
JOIN Stratum USING (Stratum_CN)
LEFT JOIN Samplegroup USING (SampleGroup_CN)
LEFT JOIN Plot USING (Plot_CN)")]
    public class LogVM : CruiseDAL.DataObjects.LogDO
    {
        [Field(SQLExpression = "Tree.TreeNumber", Alias = "TreeNumber")]
        public long TreeNumber { get; set; }

        [Field(SQLExpression = "CuttingUnit.Code", Alias = "CUCode")]
        public string CUCode { get; set; }

        [Field(SQLExpression = "Stratum.Code", Alias = "STCode")]
        public string StratumCode { get; set; }

        [Field(SQLExpression = "SampleGroup.Code", Alias = "SGCode")]
        public string SGCode { get; set; }

        [Field(SQLExpression = "Plot.PlotNumber", Alias = "PlotNum")]
        public long PlotNumber { get; set; }
    }
}