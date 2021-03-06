﻿using System;

namespace CruiseManager.Core.ViewModel
{
    public interface IView
    {
        IPresentor ViewPresenter { get; }

        //IEnumerable<ViewCommand> NavCommands { get; }
        //IEnumerable<ViewCommand> UserCommands { get; }

        event EventHandler Load;

        void EndEdits();

        void ShowMessage(String message);

        void ShowMessage(String message, String caption);

        void ShowErrorMessage(String shortDiscription, String longDiscription);

        bool AskOKOrCancel(string message, string caption, bool defaultOption);

        bool? AskYesNoCancel(String message, String caption);

        bool? AskYesNoCancel(String message, String caption, bool? defaultOption);

        void ShowWaitCursor();

        void ShowDefaultCursor();
    }
}