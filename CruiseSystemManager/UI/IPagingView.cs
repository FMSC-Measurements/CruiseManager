using System;
using System.Collections.Generic;
using System.Text;

namespace CSM
{
    public interface IPagingView
    {
        void Display(String Name);
        void Display(IPage Page);
    }
}
