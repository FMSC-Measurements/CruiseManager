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
using CruiseManager.Core.App;

namespace CruiseManager.WinForms.Components
{
    public partial class MergeComponentViewWinforms : UserControlView, MergeComponentView
    {
        MergeInfoViewWinforms mergeInfoView;

        public new MergeComponentsPresenter ViewPresenter
        {
            get { return (MergeComponentsPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public MergeComponentViewWinforms(MergeComponentsPresenter viewPresenter) 
        {
            this.ViewPresenter = viewPresenter;
            this.ViewPresenter.View = this;

            InitializeComponent();
            mergeInfoView = new MergeInfoViewWinforms(this.ViewPresenter);
            mergeInfoView.Dock = DockStyle.Fill; 
            this._contentPanel.Controls.Add(mergeInfoView);
        }


        public void UpdateMergeInfoView()
        {            
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
                PreMergeReportView view = new PreMergeReportView(this.ViewPresenter);
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
                _goButton.Enabled = this.ViewPresenter.IsWorkerReady;
                if (this.ViewPresenter.CurrentWorker == null)
                {
                    _cancelButton.Enabled = false;
                    _goButton.Text = String.Empty;
                }
                else
                {
                    _cancelButton.Enabled = this.ViewPresenter.CurrentWorker.IsWorking;
                    _goButton.Text = this.ViewPresenter.CurrentWorker.ActionName;
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
            if (this.ViewPresenter.IsWorkerReady)
            {
                this.ViewPresenter.CurrentWorker.BeginWork();
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.ViewPresenter.CurrentWorker.Cancel();
        }

    }
}
