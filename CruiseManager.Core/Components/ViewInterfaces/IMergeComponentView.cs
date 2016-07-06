using CruiseManager.Core.ViewModel;
using System;

namespace CruiseManager.Core.Components.ViewInterfaces
{
    public interface IMergeComponentView : IView
    {
        new MergeComponentsPresenter ViewPresenter { get; set; }

        void UpdateMergeInfoView();

        void ShowPremergeReport();

        void HandleWorkerStatusChanged();

        void HandleProgressChanged(Object sender, WorkerProgressChangedEventArgs e);
    }
}