using CruiseManager.Core;
using CruiseManager.Core.Components;
using CruiseManager.Core.Components.ViewInterfaces;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Components
{
    public partial class MergeComponentView : UserControlView, IMergeComponentView
    {
        MergeInfoView mergeInfoView;

        public new MergeComponentsPresenter ViewPresenter
        {
            get { return (MergeComponentsPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public void ShowPreMergeReport()
        {
            _contentPanel.Controls.Clear();
            _contentPanel.Controls.Add(new PreMergeReportView(ViewPresenter) { Dock = DockStyle.Fill });
        }

        public void ShowMergeInfoView()
        {
            _contentPanel.Controls.Clear();
            _contentPanel.Controls.Add(new MergeInfoView(ViewPresenter, this) { Dock = DockStyle.Fill });
        }


        public MergeComponentView(MergeComponentsPresenter viewPresenter)
        {
            ViewPresenter = viewPresenter;
            InitializeComponent();

            ShowMergeInfoView();
        }
    }
}