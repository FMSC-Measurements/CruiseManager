using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager
{
    public interface IPagingView 
    {
        void Display(String Name);
        void Display(IPage Page);
    }
}
