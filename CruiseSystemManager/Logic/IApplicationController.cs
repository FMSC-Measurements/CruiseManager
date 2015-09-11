using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CSM.DataTypes;
using CSM.Common;

namespace CSM.Logic
{
    public interface IApplicationController
    {
        IExceptionHandler ExceptionHandler { get; }
        DAL Database { get; }
        ApplicationState AppState { get; }
        string CruiseSaveLocation { get; set; }
        string TemplateSaveLocation { get; set; }
        string[] RecentFiles { get; }

        void Save();
        void SaveAs();
        void OpenFile(String filePath);

        List<string> GetCruiseMethods(bool reconMethodsOnly);
        List<string> GetCruiseMethods(DAL database, bool reconMethodsOnly);
        object GetTreeTDVList(TreeVM tree);
        object GetSampleGroupsByStratum(long? st_cn);

    }
}
