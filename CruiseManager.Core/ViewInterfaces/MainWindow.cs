using CruiseDAL.DataObjects;
using CruiseManager.App;
using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface MainWindow : IWindow
    {
        //bool EnableSave { get; set; }
        //bool EnableSaveAs { get; set; }

        void ClearActiveView();

        void SetActiveView(object view);

        void SetNavCommands(IEnumerable<BindableCommand> navCommands);
    }
}
