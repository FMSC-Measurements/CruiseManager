using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;

namespace CSM.Logic.TypeComparers
{
    public class TreeDefaultSpeciesComparer: Comparer<TreeDefaultValueDO> 
    {
        public override int Compare(TreeDefaultValueDO x, TreeDefaultValueDO y)
        {
            return String.Compare(x.Species, y.Species, true);
        }
    }

    
    public class TreeFieldDefaultComparer : IEqualityComparer<TreeFieldSetupDefaultDO>, IComparer<TreeFieldSetupDefaultDO>
    {
        #region IEqualityComparer<TreeFieldSetupDO> Members

        public bool Equals(TreeFieldSetupDefaultDO x, TreeFieldSetupDefaultDO y)
        {
            return x.Field == y.Field;
        }

        public int GetHashCode(TreeFieldSetupDefaultDO obj)
        {
            return obj.Field.GetHashCode();
        }

        #endregion

        #region IComparer<TreeFieldSetupDO> Members

        public int Compare(TreeFieldSetupDefaultDO x, TreeFieldSetupDefaultDO y)
        {
            return string.Compare(x.Field, y.Field);
        }

        #endregion
    }

    
    public class LogFieldDefaultComparer : IEqualityComparer<LogFieldSetupDefaultDO>, IComparer<LogFieldSetupDefaultDO>
    {

        #region IEqualityComparer<LogFieldSetupDO> Members

        public bool Equals(LogFieldSetupDefaultDO x, LogFieldSetupDefaultDO y)
        {
            return x.Field == y.Field;
        }

        public int GetHashCode(LogFieldSetupDefaultDO obj)
        {
            return obj.Field.GetHashCode();
        }

        #endregion

        #region IComparer<LogFieldSetupDO> Members

        public int Compare(LogFieldSetupDefaultDO x, LogFieldSetupDefaultDO y)
        {
            return string.Compare(x.Field, y.Field);
        }

        #endregion
    }

    public class ComponentComparer : Comparer<ComponentDO>
    {
        #region IComparer<ComponentDO> Members

        public override int Compare(ComponentDO x, ComponentDO y)
        {
            return x.Component_CN.GetValueOrDefault(0).CompareTo(y.Component_CN.GetValueOrDefault(0));
        }

        #endregion
    }

}
