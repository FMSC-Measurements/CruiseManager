using CruiseDAL;

namespace CruiseManager.Core.Models
{
    [SQLEntity(TableName="Log", 
        JoinCommand=@"JOIN Tree USING (Tree_CN) 
JOIN CuttingUnit USING (CuttingUnit_CN) 
JOIN Stratum USING (Stratum_CN) 
LEFT JOIN Samplegroup USING (SampleGroup_CN)
LEFT JOIN Plot USING (Plot_CN)")]
    public class LogVM : CruiseDAL.DataObjects.LogDO
    {
        [Field(MapExpression="Tree.TreeNumber", Alias="TreeNumber")]
        public long TreeNumber { get; set; }

        [Field(MapExpression="CuttingUnit.Code", Alias="CUCode")]
        public string CUCode { get; set; }

        [Field(MapExpression="Stratum.Code", Alias="STCode")]
        public string StratumCode { get; set; }

        [Field(MapExpression="SampleGroup.Code", Alias="SGCode")]
        public string SGCode { get; set; }

        [Field(MapExpression = "Plot.PlotNumber", Alias = "PlotNum")]
        public long PlotNumber { get; set; } 
    }
}
