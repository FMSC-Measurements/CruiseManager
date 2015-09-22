using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewInterfaces
{
    public interface MainWindow
    {
        string Text { get; set; }

        bool EnableSave { get; set; }
        bool EnableSaveAs { get; set; }

        void SetNavOptions(ICollection<NavOption> navOptions);

        void ShowWaitCursor();

        void ShowDefaultCursor();

    }
}
