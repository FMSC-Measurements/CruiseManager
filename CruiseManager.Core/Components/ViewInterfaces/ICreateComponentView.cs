﻿using CruiseManager.Core.ViewModel;

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