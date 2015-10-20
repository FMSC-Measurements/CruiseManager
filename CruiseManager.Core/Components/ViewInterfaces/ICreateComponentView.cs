﻿using CruiseManager.Core.Components;
using System;
using System.Collections.Generic;
using System.Text;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;

namespace CruiseManager.Core.Components.ViewInterfaces
{
    public interface ICreateComponentView : IView
    {
        new CreateComponentPresenter ViewPresenter { get; set; }

        void HideProgressBar();
        void InitializeAndShowProgress(int totalSteps);
        void StepProgressBar();
    }
}