using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core;
using CruiseManager.Core.Components;
using CruiseManager.Core.ViewInterfaces;

namespace CSM.Winforms.Components
{
    public partial class WinformsMergeComponentView : UserControl, MergeComponentView
    {
        MergeInfoView mergeInfoView;

        public WinformsMergeComponentView()
        {
            InitializeComponent();
            mergeInfoView = new MergeInfoView();
            mergeInfoView.Dock = DockStyle.Fill; 
            this._contentPanel.Controls.Add(mergeInfoView);
        }

        public MergeComponentsPresenter Presenter
        {
            get;
            set;
        }

        public void HandleLoad()
        {
 
        }

        public void UpdateMergeInfoView()
        {
            mergeInfoView.MergePresenter = this.Presenter;
            mergeInfoView.UpdateMasterInfo();
            mergeInfoView.UpdateComponentInfo(); 
        }

        public void ShowPremergeReport()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.ShowPremergeReport));
            }
            else
            {
                this._contentPanel.Controls.Clear();
                PreMergeReportView view = new PreMergeReportView(this.Presenter);
                view.Dock = DockStyle.Fill;
                this._contentPanel.Controls.Add(view);
                view.UpdateView();
            }
        }

        public void HandleWorkerStatusChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.HandleWorkerStatusChanged));
            }
            else
            {
                _goButton.Enabled = this.Presenter.IsWorkerReady;
                if (this.Presenter.CurrentWorker == null)
                {
                    _cancelButton.Enabled = false;
                    _goButton.Text = String.Empty;
                }
                else
                {
                    _cancelButton.Enabled = this.Presenter.CurrentWorker.IsWorking;
                    _goButton.Text = this.Presenter.CurrentWorker.ActionName;
                }
            }
        }



        public void HandleProgressChanged(Object sender, WorkerProgressChangedEventArgs e) 
        {
            if (this.__progressBar.InvokeRequired)
            {
                this.__progressBar.Invoke(new EventHandler<WorkerProgressChangedEventArgs>(this.HandleProgressChanged), sender, e);
                return;
            }
            int percentDone = Math.Min(e.ProgressPercentage, 100);
            percentDone = Math.Max(0, percentDone);
            this.__progressBar.Value = percentDone;
            this._progressMessageTB.Text = e.Message;
            this.HandleWorkerStatusChanged(); 
        }

        private void _goButton_Click(object sender, EventArgs e)
        {
            if (this.Presenter.IsWorkerReady)
            {
                this.Presenter.CurrentWorker.BeginWork();
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Presenter.CurrentWorker.Cancel();
        }

    }
}
