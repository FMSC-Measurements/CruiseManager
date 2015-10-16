using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewModel
{
    public interface IDialog
    {
        void Show(ApplicationControllerBase applicationController, ref IDialogDataContext dataContext);
    }
}
