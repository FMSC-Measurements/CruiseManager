using CruiseManager.Core.Components;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Components
{
    public partial class MergeInfoView : UserControl
    {
        public MergeInfoView(MergeComponentsPresenter viewPresenter)
        {
            InitializeComponent();
            
            this.ViewPresenter = viewPresenter;
            viewPresenter.PropertyChanged += ViewPresenter_PropertyChanged;

            UpdateMasterInfo();
            UpdateComponentInfo();
        }

        private void ViewPresenter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            if(propertyName == nameof(MergeComponentsPresenter.NumComponents)
                || propertyName == nameof(MergeComponentsPresenter.LastMergeDate)
                || propertyName == nameof(MergeComponentsPresenter.MasterTreeCount))
            { UpdateMasterInfo(); }
            else if(propertyName == nameof(MergeComponentsPresenter.AllComponents))
            { UpdateComponentInfo(); }
        }

        public MergeComponentsPresenter ViewPresenter
        {
            get; set;
        }

        public void UpdateMasterInfo()
        {
            __numComLBL.Text = ViewPresenter.NumComponents.ToString();
            __dateLastMergeLBL.Text = ViewPresenter.LastMergeDate;
            __totalTreeRecLBL.Text = ViewPresenter.MasterTreeCount.ToString();
        }

        public void UpdateComponentInfo()
        {
            this._BS_ComponentFiles.DataSource = ViewPresenter.AllComponents;
        }

        private void __searchBTN_Click(object sender, EventArgs e)
        {
            this.ViewPresenter.FindComponents();
        }
    }
}