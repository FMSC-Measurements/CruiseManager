using CruiseManager.Core.Components;
using CruiseManager.Core.ViewModel;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Components
{
    public partial class MergeInfoView : UserControl
    {
        private MergeComponentsPresenter _viewModel;
        public MergeComponentView HostView { get; }

        public MergeInfoView(MergeComponentsPresenter viewModel, MergeComponentView hostView)
        {
            InitializeComponent();
            ViewModel = viewModel;
            HostView = hostView;
            

            UpdateMasterInfo();
            UpdateComponentInfo();
        }

        protected MergeComponentsPresenter ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel != null)
                { OnViewModelChangeing(_viewModel); }
                _viewModel = value;
                if (value != null)
                { OnViewModelChanged(value); }
            }
        }

        private void OnViewModelChangeing(MergeComponentsPresenter oldVM)
        {
            oldVM.PropertyChanged -= ViewModel_PropertyChanged;
            oldVM.MergeLog.LogChanged -= MergeLog_LogChanged;
        }

        private void OnViewModelChanged(MergeComponentsPresenter newVM)
        {
            newVM.MergeLog.LogChanged += MergeLog_LogChanged;
            newVM.PropertyChanged += ViewModel_PropertyChanged;

            _goButton.Enabled = true;

        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void MergeLog_LogChanged(object sender, string e)
        {
            _progressMessageTB.Text = e;
        }

        public void UpdateMasterInfo()
        {
            __numComLBL.Text = ViewModel.NumComponents.ToString();
            __dateLastMergeLBL.Text = ViewModel.LastMergeDate;
            __totalTreeRecLBL.Text = ViewModel.MasterTreeCount.ToString();
        }

        public void UpdateComponentInfo()
        {
            this._BS_ComponentFiles.DataSource = ViewModel.AllComponents;
        }

        private void __searchBTN_Click(object sender, EventArgs e)
        {
            ViewModel.FindComponents();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            ViewModel.Cancel();
        }

        private async void _goButton_Click(object sender, EventArgs e)
        {
            _goButton.Enabled = false;
            _cancelButton.Enabled = true;
            var (result, exception) = await ViewModel.RunPreMerge();
            _cancelButton.Enabled = false;

            if (result)
            { HostView.ShowPreMergeReport(); }
            else
            {
                if (exception != null)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}