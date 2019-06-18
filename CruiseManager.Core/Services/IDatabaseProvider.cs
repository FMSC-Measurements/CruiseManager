using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Services
{
    public interface IDatabaseProvider
    {
        DAL Database { get; }
    }
}
