using CruiseDAL.DataObjects;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class ReportsSummView : CruiseManager.WinForms.UserControlView, IReportsSumm
    {
        public ReportsSummView()
        {
            InitializeComponent();
        }
        public new ReportsSummPresenter ViewPresenter
        {
            get { return ((ReportsSummPresenter)base.ViewPresenter); }
            set { base.ViewPresenter = value; }
        }
    }
}