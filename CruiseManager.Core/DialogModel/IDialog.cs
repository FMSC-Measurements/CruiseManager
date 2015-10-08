using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.DialogModel
{
    public interface IDialog
    {
        void Show(ApplicationController applicationController, ref IDialogDataContext dataContext);
    }
}
