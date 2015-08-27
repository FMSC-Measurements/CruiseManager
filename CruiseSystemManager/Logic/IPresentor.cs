using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSM.Logic
{
    public interface IPresentor : IDisposable, ISaveHandler
    {
        IWindowPresenter Controller { get; set; }

        void UpdateView();
    }
}
