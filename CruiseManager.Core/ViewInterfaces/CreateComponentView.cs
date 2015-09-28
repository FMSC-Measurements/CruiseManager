using CruiseManager.Core.Components;
using System;
using System.Collections.Generic;
using System.Text;
using CruiseManager.Core.App;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface CreateComponentView : IView
    {
        new CreateComponentPresenter ViewPresenter { get; set; }

        void HideProgressBar();
        void InitializeAndShowProgress(int totalSteps);
        void StepProgressBar();
    }
}
