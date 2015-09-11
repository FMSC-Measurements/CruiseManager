using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSM.Logic;

namespace CSM.Common
{
    public interface IPresentor : IDisposable
    {
        IWindowPresenter WindowPresenter { get; set; }

        void UpdateView();
    }
}
