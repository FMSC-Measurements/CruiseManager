using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;

namespace CSM.Winforms.CruiseCustomize
{
    public class FieldSetupStratum : CruiseDAL.DataObjects.StratumDO
    {
        public List<TreeFieldSetupDO> SelectedTreeFields { get; set; }
        public List<LogFieldSetupDO> SelectedLogFields { get; set; }

        public List<TreeFieldSetupDO> UnselectedTreeFields { get; set; }
        public List<LogFieldSetupDO> UnselectedLogFields { get; set; }
    }
}
