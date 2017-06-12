using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class ReportsSummPresenter : Presentor
    {
        bool _isInitialized;

        public new IReportsSumm View
        {
            get { return (IReportsSumm)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }
    }
}
