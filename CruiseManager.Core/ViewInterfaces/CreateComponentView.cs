using CruiseManager.Core.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface CreateComponentView
    {
        CreateComponentPresenter Presenter { get; set; }

        void HideProgressBar();
        void InitializeAndShowProgress(int totalSteps);
        void StepProgressBar();
    }
}
