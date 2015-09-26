using CruiseManager.App;
using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface MainWindow : IDisposable
    {
        string Text { get; set; }

        bool EnableSave { get; set; }
        bool EnableSaveAs { get; set; }

        void ClearActiveView();

        void SetActiveView(object view);

        void SetNavCommands(IEnumerable<ViewCommand> navCommands);

        void ShowWaitCursor();

        void ShowDefaultCursor();

    }
}
