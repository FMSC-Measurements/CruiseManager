using CruiseManager.Core.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface MergeComponentView
    {
        MergeComponentsPresenter Presenter { get; set; }

        void UpdateMergeInfoView();

        void ShowPremergeReport();

        void HandleWorkerStatusChanged();
        void HandleProgressChanged(Object sender, WorkerProgressChangedEventArgs e);
    }
}
