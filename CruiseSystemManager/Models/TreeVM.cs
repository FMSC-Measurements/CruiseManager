using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;

namespace CSM.Models
{
    [SQLEntity(TableName = "Tree", 
        JoinCommand= "JOIN Stratum USING (Stratum_CN) JOIN CuttingUnit USING (CuttingUnit_CN) LEFT JOIN SampleGroup USING (SampleGroup_CN)")]
        
    public class TreeVM : TreeDO
    {
        public long? PlotNumber
        {
            get
            {
                if(this.Plot != null)
                {
                    return this.Plot.PlotNumber;
                }
                return null;
            }
        }

        [Field( MapExpression= "CuttingUnit.Code", Alias="CUCode")]
        public string UnitCode
        {
            get; set;
        }

        [Field(MapExpression= "Stratum.Code", Alias="STCode") ]
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
            return DAL.ReadSingleRow<StratumVM>(CruiseDAL.Schema.STRATUM._NAME, this.Stratum_CN);
        }

        public new StratumVM Stratum
        {
            get { return (StratumVM)base.Stratum; }
            set { base.Stratum = value; }
        }

    }
}
