using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core
{
    public interface  ISaveHandler
    {
        bool CanHandleSave { get; }
        //bool CanHandleSaveAs { get; }//TODO implement save-as in all saveHalders 

        bool HandleSave();

        bool HasChangesToSave { get; }

        void HandleAppClosing(ref bool cancel);
        
    }
}
