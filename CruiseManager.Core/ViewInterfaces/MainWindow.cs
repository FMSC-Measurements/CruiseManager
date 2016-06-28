using CruiseManager.Core.CommandModel;
using CruiseManager.Core.ViewModel;
using System.Collections.Generic;

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