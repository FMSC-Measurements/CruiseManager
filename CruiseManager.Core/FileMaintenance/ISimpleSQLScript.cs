using CruiseDAL;
using System;

namespace CruiseManager.Core.FileMaintenance
{
    public interface ISimpleSQLScript
    {
        string Name { get; }

        string Description { get; }

        bool CheckCanExecute(DAL database);

        void Execute(DAL database);
    }
}