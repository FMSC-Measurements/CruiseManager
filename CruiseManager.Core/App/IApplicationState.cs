using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CruiseDAL.DataObjects;
using System.IO;
using System.Xml.Serialization;

namespace CruiseManager.Core.App
{

    
    public interface IApplicationState
    {
        String[] RecentFiles { get; }

        void AddRecentFile(String path);
        void Save();
    }
}
