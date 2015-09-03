using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;

namespace CSM.UI.CruiseCustomize
{
    [CruiseDAL.SQLEntity(TableName = "Tally", IsCached = false)]
    public class TallyVM : TallyDO
    {
        public TallyVM() : base() { }
        public TallyVM(DAL db) : base(db) { }
    }


    public class TallyPopulation
    {
        public SampleGroupDO SampleGroup { get; set; }

        public TreeDefaultValueDO Species { get; set; }

        public string HotKey { get; set; }

        public string Description { get; set; }
    }
}
