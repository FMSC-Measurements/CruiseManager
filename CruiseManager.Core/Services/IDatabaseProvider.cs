﻿using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Services
{
    public interface IDatabaseProvider
    {
        bool HasIncompleteCruise { get; }

        Task<DAL> GetNewCruiseAsync();

        DAL GetIncompleteCruise();

        void FinalizeNewCruise();

        DAL Database { get; }
    }
}
