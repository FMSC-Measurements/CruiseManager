using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.FileMaintenance
{
    public interface ISimpleSQLScript
    {
        String Description { get; }

        bool CheckCanExecute(DAL database);
        void Execute(DAL database);
    }
}
