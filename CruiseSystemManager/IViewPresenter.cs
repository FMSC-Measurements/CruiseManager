using System;
using System.Collections.Generic;
using System.Text;

namespace CSM
{
    public interface IWindowPresenter
    {
        void Load(String view);

        bool Shutdown();
    }
}
