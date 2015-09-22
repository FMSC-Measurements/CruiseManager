using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface CreateComponentView
    {
        void HideProgressBar();
        void InitializeAndShowProgress(int totalSteps);
        void StepProgressBar();
    }
}
