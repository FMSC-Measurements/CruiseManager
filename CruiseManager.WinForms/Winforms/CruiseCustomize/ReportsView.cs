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
            viewPresenter.PropertyChanged += ViewPresenter_PropertyChanged;
            ViewPresenter.View = this;
            InitializeComponent();
        }

        private void ViewPresenter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            if (propertyName == nameof(ReportsPresenter.Reports))
            {
                UpdateReports();
            }
        }

        public new ReportsPresenter ViewPresenter
        {
            get { return ((ReportsPresenter)base.ViewModel); }
            set { base.ViewModel = value; }
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



        public override void EndEdits()
        {
            _reportsDGV.EndEdit();
        }
    }
}