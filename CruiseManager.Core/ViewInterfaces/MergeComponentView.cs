using CruiseManager.Core.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewInterfaces
{
    public abstract class MergeComponentView<T> : IView<T>
    {
        public MergeComponentView(MergeComponentsPresenter viewPresenter)
        {
            this.ViewPresenter = ViewPresenter;
        }

        public new MergeComponentsPresenter ViewPresenter
        {
            get { return base.ViewPresenter as MergeComponentsPresenter; }
            set { base.ViewPresenter = value; }
        }

        public abstract void UpdateMergeInfoView();

        public abstract void ShowPremergeReport();

        public abstract void HandleWorkerStatusChanged();
        public abstract void HandleProgressChanged(Object sender, WorkerProgressChangedEventArgs e);
    }
}
