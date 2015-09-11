using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSM.Common
{
    public interface  ISaveHandler
    {
        bool CanHandleSave { get; }
        //bool CanHandleSaveAs { get; }//TODO implement save-as in all saveHalders 

        bool HandleSave();
        //void HandleSaveAs();

        void HandleAppClosing(object sender, FormClosingEventArgs e);
        
    }
}
