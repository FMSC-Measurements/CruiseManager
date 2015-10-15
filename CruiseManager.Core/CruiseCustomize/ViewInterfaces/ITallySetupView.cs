using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface ITallySetupView : IView   
    {
        new TallySetupPresenter ViewPresenter { get; set; }

        void UpdateTallySetupView();

    }
}
