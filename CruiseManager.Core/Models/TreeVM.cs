using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;
using FMSC.ORM.EntityModel.Attributes;

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
                if(this.Plot != null)
                {
                    return this.Plot.PlotNumber;
                }
                return null;
            }
        }

        [Field( SQLExpression = "CuttingUnit.Code", Alias="CUCode")]
        public string UnitCode
        {
            get; set;
        }

        [Field(SQLExpression = "Stratum.Code", Alias="STCode") ]
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
            return DAL.From<StratumVM>().Where("Stratum_CN = ?").Read(Stratum_CN).FirstOrDefault();
        }

        public new StratumVM Stratum
        {
            get { return (StratumVM)base.Stratum; }
            set { base.Stratum = value; }
        }

    }
}
