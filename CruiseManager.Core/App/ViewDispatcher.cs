using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public class ViewDispatcher
    {
        public ViewContext Context { get; set; }


        public ViewDispatcher()
        { }

        public void Display<T>()
        {
            this.Display(typeof(T));
        }

        public void Display(Type viewType)
        {

        }

        public IView GetView(Type viewType)
        {
            throw new NotImplementedException();
        }

    }
}
