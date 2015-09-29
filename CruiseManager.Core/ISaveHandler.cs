using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core
{
    public interface  ISaveHandler
    {
        bool HandleSave();

        bool HasChangesToSave { get; }
    }
}
