using CruiseManager.App;
using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
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


        void SetActiveView(IView view);

        //void SetNavCommands(IEnumerable<ViewCommand> navCommands);

        //void ShowWaitCursor();

        //void ShowDefaultCursor();

    }
}
