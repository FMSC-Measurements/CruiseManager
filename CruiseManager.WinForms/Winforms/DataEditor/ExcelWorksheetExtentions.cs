using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.WinForms.DataEditor
{
    public static class ExcelWorksheetExtentions
    {
        public static void SetValues<TValues>(this ExcelWorksheet @this, IEnumerable<TValues> values, int row, int startCol = 1)
        {
            foreach (var value in values)
            {
                @this.SetValue(row, startCol++, value);
            }
        }
    }
}