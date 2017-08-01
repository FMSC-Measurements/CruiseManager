using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class ReportsView : CruiseManager.WinForms.UserControlView, IReportsView
    {
        public ReportsView(ReportsPresenter viewPresenter)
        {
            ViewPresenter = viewPresenter;
            ViewPresenter.View = this;
            InitializeComponent();
        }

        public new ReportsPresenter ViewPresenter
        {
            get { return ((ReportsPresenter)base.ViewPresenter); }
            set { base.ViewPresenter = value; }
        }

        #region Reports

        private void _reportsSelectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (ReportsDO rpt in this.ViewPresenter.Reports)
            {
                rpt.Selected = true;
            }
        }

        private void _reportsClearSltnBTN_Click(object sender, EventArgs e)
        {
            foreach (ReportsDO rpt in this.ViewPresenter.Reports)
            {
                rpt.Selected = false;
            }
        }

        public void UpdateReports()
        {
            _BS_Reports.DataSource = ViewPresenter.Reports;
        }

        #endregion Reports



        public void EndEdit()
        {
            _reportsDGV.EndEdit();
        }
    }
}