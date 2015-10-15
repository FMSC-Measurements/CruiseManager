using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;

namespace CruiseManager.Core.Models
{
    public class TreeFieldComparer : IEqualityComparer<TreeFieldSetupDO>, IComparer<TreeFieldSetupDO>
    {
        public static TreeFieldComparer Instance
        {
            get
            {
                if (_instance == null) { _instance = new TreeFieldComparer(); }
                return _instance;
            }
        }

        private static TreeFieldComparer _instance;

        #region IEqualityComparer<TreeFieldSetupDO> Members

        public bool Equals(TreeFieldSetupDO x, TreeFieldSetupDO y)
        {
            return x.Field == y.Field;
        }

        public int GetHashCode(TreeFieldSetupDO obj)
        {
            return (obj.Field != null) ? obj.Field.GetHashCode() : 0;
        }

        #endregion

        #region IComparer<TreeFieldSetupDO> Members

        public int Compare(TreeFieldSetupDO x, TreeFieldSetupDO y)
        {
            return string.Compare(x.Field, y.Field);
        }

        #endregion
    }

    //a worker class for comparing LogFieldSetupDO 
    public class LogFieldComparer : IEqualityComparer<LogFieldSetupDO>, IComparer<LogFieldSetupDO>
    {
        public static LogFieldComparer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogFieldComparer();
                }
                return _instance;
            }
        }

        private static LogFieldComparer _instance;


        #region IEqualityComparer<LogFieldSetupDO> Members

        public bool Equals(LogFieldSetupDO x, LogFieldSetupDO y)
        {
            return x.Field == y.Field;
        }

        public int GetHashCode(LogFieldSetupDO obj)
        {
            return (obj.Field != null) ? obj.Field.GetHashCode() : 0;
        }

        #endregion

        #region IComparer<LogFieldSetupDO> Members

        public int Compare(LogFieldSetupDO x, LogFieldSetupDO y)
        {
            return string.Compare(x.Field, y.Field);
        }

        #endregion
    }

    public class TreeDefaultSpeciesComparer : Comparer<TreeDefaultValueDO>
    {
        public override int Compare(TreeDefaultValueDO x, TreeDefaultValueDO y)
        {
            return String.Compare(x.Species, y.Species, true);
        }
    }

    public class TreeDefaultComparer : IEqualityComparer<TreeDefaultValueDO>
    {
        #region IEqualityComparer<TreeDefaultValueDO> Members

        private static TreeDefaultComparer _instance; 
        public static TreeDefaultComparer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TreeDefaultComparer();
                }
                return _instance; 
            }
        }

        public bool Equals(TreeDefaultValueDO x, TreeDefaultValueDO y)
        {
            return ((x.PrimaryProduct == y.PrimaryProduct) &&
                (x.Species == y.Species) &&
                (x.LiveDead == y.LiveDead));
        }

        public int GetHashCode(TreeDefaultValueDO obj)
        {
            return obj.PrimaryProduct.GetHashCode() ^ 3 + obj.Species.GetHashCode() ^ 2 + obj.LiveDead.GetHashCode();
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
