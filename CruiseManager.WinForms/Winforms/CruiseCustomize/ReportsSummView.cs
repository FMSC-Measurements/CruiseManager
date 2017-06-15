using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class ReportsSummView : CruiseManager.WinForms.UserControlView, IReportsSumm
    {
        public ReportsSummView(ReportsSummPresenter viewPresenter)
        {
            ViewPresenter = viewPresenter;
            ViewPresenter.View = this;
            InitializeComponent();
        }

        public new ReportsSummPresenter ViewPresenter
        {
            get { return ((ReportsSummPresenter)base.ViewPresenter); }
            set { base.ViewPresenter = value; }
        }

        #region Reports

        private void _reportsSelectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (ReportsDO rpt in this.ViewPresenter.DefaultReports)
            {
                rpt.Selected = true;
            }
        }

        private void _reportsClearSltnBTN_Click(object sender, EventArgs e)
        {
            foreach (ReportsDO rpt in this.ViewPresenter.DefaultReports)
            {
                rpt.Selected = false;
            }
        }

        public void UpdateReports()
        {
            _BS_Reports.DataSource = ViewPresenter.DefaultReports;
        }
        #endregion Report 

        private void _reportsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _reportsSelectAllBtn.Select();
        }
    }
}