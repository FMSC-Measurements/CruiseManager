using CruiseManager.App;
using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface MainWindow : IDisposable
    {
        string Text { get; set; }

        event CancelEventHandler Closing;

        bool EnableSave { get; set; }
        bool EnableSaveAs { get; set; }

        void ClearActiveView();

        void SetActiveView(object view);

        void SetNavCommands(IEnumerable<BindableCommand> navCommands);

        void ShowWaitCursor();

        void ShowDefaultCursor();

        

    }
}
