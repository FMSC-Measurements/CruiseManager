using System;

namespace CruiseManager
{
    public interface IPagingView
    {
        void Display(String Name);

        void Display(IPage Page);
    }
}