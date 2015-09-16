using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;

namespace CSM.Models
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
                try
                {
                    return int.Parse(this.District);
                }
                catch
                {
                    return null;
                }
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
