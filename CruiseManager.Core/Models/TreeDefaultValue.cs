using CruiseDAL.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.Models
{
    public class TreeDefaultValue : TreeDefaultValueDO
    {
        //public bool CanDelete
        //{
        //    get
        //    {
        //        if (IsPersisted == false) { return true; }
        //        bool hasTreeCounts = DAL.GetRowCount("CountTree", "WHERE TreeCount > 0 AND TreeDefaultValue_CN = ?", tdv.TreeDefaultValue_CN) > 0;
        //        bool hasTrees = DAL.GetRowCount("Tree", "WHERE TreeDefaultValue_CN = ?", tdv.TreeDefaultValue_CN) > 0;
        //        return !(hasTreeCounts || hasTrees);
        //    }
        //}
    }
}