using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize.ViewInterfaces
{
    public interface IFieldSetupView : IView
    {
        new FieldSetupPresenter ViewPresenter { get; set; }

        void UpdateFieldSetupViews();
    }
}
