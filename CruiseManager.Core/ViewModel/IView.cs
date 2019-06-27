using CruiseManager.Navigation;
using System;

namespace CruiseManager.Core.ViewModel
{
    public interface IView
    {
        void EndEdits();

        void ShowWaitCursor();

        void ShowDefaultCursor();

        ViewModelBase ViewModel { get; }

        
    }
}