using CruiseDAL;
using CruiseDAL.DataObjects;
using System;

namespace CruiseManager.Core.Models
{
    public class SaleVM : SaleDO
    {
        public SaleVM()
            : base()
        { }

        public SaleVM(DAL database)
            : base(database)
        { }

        public SaleVM(SaleDO sale)
            : base(sale)
        { }

        public int? DistrictNum
        {
            get
            {
                if (District == null) { return null; }

                int distNum;
                if (int.TryParse(District, out distNum))
                { return distNum; }
                else
                { return null; }
            }
            set
            {
                string str = (value != null) ? value.Value.ToString("D2") : String.Empty;
                if (this.District == str) { return; }
                this.District = str;
            }
        }
    }
}