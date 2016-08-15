using CruiseDAL.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.EditFieldData
{
    public class TreeDefaultSpeciesComparer : Comparer<TreeDefaultValueDO>
    {
        public override int Compare(TreeDefaultValueDO x, TreeDefaultValueDO y)
        {
            if (x == null) return y == null ? 0 : -1;
            if (y == null) return 1;

            return String.Compare(x.Species, y.Species, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class SampleGroupCodeComparer : Comparer<SampleGroupDO>
    {
        public override int Compare(SampleGroupDO x, SampleGroupDO y)
        {
            if (x == null) return y == null ? 0 : -1;
            if (y == null) return 1;

            return string.Compare(x.Code, y.Code, StringComparison.OrdinalIgnoreCase);
        }
    }
}