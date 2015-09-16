using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;

namespace CSM.Winforms.DesignEditor
{
    public class DesignEditorStratum : CruiseDAL.DataObjects.StratumDO
    {
        public DesignEditorStratum(DAL db) : base(db) { }
        public DesignEditorStratum(CruiseDAL.DataObjects.StratumDO st) : base(st) { }
        public DesignEditorStratum() : base() { }

        public string MonthStr
        {
            get { return this.Month.ToString("D"); }
            set
            {
                try
                {
                    this.Month = long.Parse(value);
                }
                catch { }
            }
        }
    }
}
