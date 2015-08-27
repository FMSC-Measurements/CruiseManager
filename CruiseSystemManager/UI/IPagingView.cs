using System;
using System.Collections.Generic;
using System.Text;

namespace CSM
{
    public interface IPagingView : IView
    {
        void Display(String Name);
        void Display(IPage Page);
    }
}
