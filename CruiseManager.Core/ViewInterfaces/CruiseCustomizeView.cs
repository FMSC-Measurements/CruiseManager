using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface CruiseCustomizeView : IView
    {
        new CustomizeCruisePresenter ViewPresenter { get; set; }


        void UpdateTallySetupView();
        void UpdateFieldSetupViews();
        void UpdateTreeDefaults();
        void UpdateTreeAudits();
        void UpdateLogMatrix();

        void EndEdits();


    }
}
