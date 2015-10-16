using CruiseManager.Core.Components;
using System;
using System.Collections.Generic;
using System.Text;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;

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
