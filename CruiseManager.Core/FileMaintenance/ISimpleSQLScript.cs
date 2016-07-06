using CruiseDAL;
using System;

namespace CruiseManager.Core.FileMaintenance
{
    public interface ISimpleSQLScript
    {
        String Description { get; }

        bool CheckCanExecute(DAL database);

        void Execute(DAL database);
    }
}