using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;

namespace CSM.DataTypes
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
}
