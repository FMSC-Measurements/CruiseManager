using CruiseDAL.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.CruiseCustomize.Models
{
    public class LogGradeAuditRule : LogGradeAuditRuleDO
    {
        public override string ToString()
        {
            return ValidGrades + ((DefectMax > 0) ? $" & Defect < {DefectMax}%" : String.Empty);
        }
    }
}