using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ILogMatrixView : IView
    {
        new LogMatrixPresenter ViewPresenter { get; set; }

        void UpdateLogMatrix();
    }
}
