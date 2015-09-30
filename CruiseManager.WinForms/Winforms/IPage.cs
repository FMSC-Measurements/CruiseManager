using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager
{
    public interface IPage 
    {
        String Name
        {
            get;
            set;
        }

        bool HandleKeypress(System.Windows.Forms.Keys key);
    }
}
