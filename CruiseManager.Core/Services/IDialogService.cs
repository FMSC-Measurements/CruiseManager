using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Services
{
    public interface IDialogService
    {
        void ShowMessage(String message);

        void ShowMessage(String message, String caption);

        void ShowErrorMessage(String shortDiscription, String longDiscription);

        bool AskOKOrCancel(string message, string caption, bool defaultOption);

        bool? AskYesNoCancel(String message, String caption);

        bool? AskYesNoCancel(String message, String caption, bool? defaultOption);
    }
}
