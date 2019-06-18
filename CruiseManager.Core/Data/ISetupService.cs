using CruiseDAL.DataObjects;
using CruiseManager.Core.SetupModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Data
{
    public interface ISetupService
    {
        List<CruiseMethod> GetCruiseMethods();

        List<LogFieldSetupDO> GetLogFieldSetups();

        List<LoggingMethod> GetLoggingMethods();

        List<ProductCode> GetProductCodes();

        List<Region> GetRegions();

        List<TreeFieldSetupDO> GetTreeFieldSetups();

        List<UOMCode> GetUOMCodes();

        void SaveCruiseMethods(List<CruiseMethod> CruiseMethods);

        void SaveLoggingMethods(List<LoggingMethod> lMeths);

        void SaveProductCodes(List<ProductCode> pCodes);

        void SaveRegions(List<Region> regions);

        void SaveUOMCodes(List<UOMCode> uomCodes);

    }
}
