using CruiseManager.Core.ViewModel;
using System;

namespace CruiseManager.Core.Components.ViewInterfaces
{
    public interface IMergeComponentView : IView
    {
        new MergeComponentsPresenter ViewPresenter { get; set; }

        void ShowMergeInfoView();

        void ShowPreMergeReport();
    }
}