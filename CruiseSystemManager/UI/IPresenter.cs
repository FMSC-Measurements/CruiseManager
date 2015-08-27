using System;
using System.Collections.Generic;
using System.Text;

namespace CSM
{
    public interface IPresenter
    {
        IView View
        {
            get;
        }

        void UpdateView();
    }
}
