using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;
using System.Linq;

namespace CruiseManager.Core.Models
{
    [EntitySource(SourceName = "Tree",
        JoinCommands = "JOIN Stratum USING (Stratum_CN) JOIN CuttingUnit USING (CuttingUnit_CN) LEFT JOIN SampleGroup USING (SampleGroup_CN)")]
    public class TreeVM : TreeDO
    {
        public long? PlotNumber
        {
            get
            {
                if (this.Plot != null)
                {
                    return this.Plot.PlotNumber;
                }
                return null;
            }
        }

        [Field(SQLExpression = "CuttingUnit.Code", Alias = "CUCode", PersistanceFlags = PersistanceFlags.Never)]
        public string UnitCode
        {
            get; set;
        }

        [Field(SQLExpression = "Stratum.Code", Alias = "STCode", PersistanceFlags = PersistanceFlags.Never)]
        public string StratumCode
        {
            get; set;
        }

        //[Field(MapExpression= "SampleGroup.Code",
        //    Alias= "SGCode")]
        //public string SampleGroupCode
        //{
        //    get; set;
        //}

        public override StratumDO GetStratum()
        {
            if (DAL == null) { return null; }
            return DAL.From<StratumVM>().Where("Stratum_CN = @p1").Read(Stratum_CN).FirstOrDefault();
        }

        public new StratumVM Stratum
        {
            get { return (StratumVM)base.Stratum; }
            set { base.Stratum = value; }
        }
    }
}