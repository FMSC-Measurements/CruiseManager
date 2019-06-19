using System;

namespace CruiseManager.Core.ViewModel
{
    public interface IView
    {
        void EndEdits();

        void ShowWaitCursor();

        void ShowDefaultCursor();
    }
}