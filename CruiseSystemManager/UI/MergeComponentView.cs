using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSM.Logic;

namespace CSM.UI
{
    public partial class MergeComponentView : UserControl, IView
    {
        public MergeComponentView()
        {
            InitializeComponent();

            
        }

        public MergeComponentsPresenter Presenter
        {
            get;
            set;
        }

        public void HandleLoad()
        {
            this.__numComLBL.Text = Presenter.GetNumComponents().ToString();
            this.__dateLastMergeLBL.Text = Presenter.GetMasterLastMergeDate();
            this.__totalTreeRecLBL.Text = Presenter.GetMasterTreeCount().ToString();
            this.__CompListView.Items.Clear();

            this.__previewTotalTreeRecLBL.Text = "0";

            this.__searchPathTB.Text = System.IO.Path.GetDirectoryName(Presenter.MasterDB.Path);

            this.__mergePreviewGB.Enabled = false;
            this.__mergeBTN.Enabled = false;
        }

        public void HandleComponentsUpdate()
        {
            this.__CompListView.Items.Clear();

            int totalTreeEdits = 0;
            int totalLogEdits = 0;
            int totalTreeRecs = 0;

            foreach (CSM.Logic.MergeComponentsPresenter.ComponentFileVM comp in Presenter.Components)
            {
                ListViewItem entry = new ListViewItem(comp.FileName);
                entry.SubItems.Add(comp.LastMerge);
                entry.SubItems.Add(comp.Edits.ToString());
                entry.SubItems.Add(comp.Warnings.ToString());
                entry.SubItems.Add(comp.Errors);

                this.__CompListView.Items.Add(entry);

                totalTreeEdits += comp.TreeEdits;
                totalLogEdits += comp.LogEdits;
                totalTreeRecs += comp.TreeCount;
            }

            this.__previewTotalTreeRecLBL.Text = totalTreeRecs.ToString();

            this.__previewInfoTV.Nodes[0].Nodes[0].Text = String.Format("Tree Edits: {0}", totalTreeEdits);
            this.__previewInfoTV.Nodes[0].Nodes[1].Text = String.Format("Log Edits: {0}", totalLogEdits);

            this.__mergePreviewGB.Enabled = true;
            this.__mergeBTN.Enabled = true;

        }

        public void ShowPostMergeReport()
        {
            
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(Presenter.Errors))
            {
                sb.Append("Merge unsuccesful. ");
                sb.Append(Presenter.Errors);
            }

            sb.AppendFormat("SG Added       : {0}\r\n", Presenter.SGAdded);
            sb.AppendFormat("TDV Added      : {0}\r\n", Presenter.TDVAdded);
            sb.AppendFormat("SGTDV Added    : {0}\r\n", Presenter.SGTDVAdded);
            sb.AppendFormat("Trees Added    : {0}\r\n", Presenter.TreesAdded);
            sb.AppendFormat("Trees Updated  : {0}\r\n", Presenter.TreesUpdated);
            if (Presenter.LogsAdded > 0) { sb.AppendFormat("Logs Added    : {0}\r\n", Presenter.LogsAdded); }
            if (Presenter.LogsUpdated > 0) { sb.AppendFormat("Logs Updated  : {0}\r\n", Presenter.LogsUpdated); }
            if (Presenter.StemsAdded > 0) { sb.AppendFormat("Stems Added   : {0}\r\n", Presenter.StemsAdded); }
            if (Presenter.StemsUpdated > 0) { sb.AppendFormat("Stems Updated : {0}\r\n", Presenter.StemsUpdated); }

            MessageBox.Show(sb.ToString());
        }

        public void InitializeAndShowProgress(int numSteps)
        {
            this.Cursor = Cursors.WaitCursor;
            this.__progressBar.Maximum = numSteps;
            this.__progressBar.Step = 1;
            this.__progressBar.Value = 0;
            this.__progressBar.Visible = true;
            this.__progressBar.Update();
        }

        public void HideProgressBar()
        {
            this.Cursor = Cursors.Default;
            this.__progressBar.Visible = false;
            this.__progressBar.Update();
        }

        public void StepProgressBar()
        {
            this.__progressBar.PerformStep();
            this.__progressBar.Update();
        }

        private void __searchBTN_Click(object sender, EventArgs e)
        {
            this.__mergeBTN.Enabled = false;
            if (System.IO.Directory.Exists(this.__searchPathTB.Text) == false)
            {
                return;
            }

            List<String> missingFiles = null;
            Presenter.FindComponents(this.__searchPathTB.Text, out missingFiles);

            if (missingFiles != null && missingFiles.Count > 0)
            {
                StringBuilder sb = new StringBuilder("The Following Files Could Not Be Located:");
                foreach (string file in missingFiles)
                {
                    sb.AppendLine(file);
                }
                MessageBox.Show(sb.ToString());
            }
            this.HandleComponentsUpdate();
        }

        private void __browseSearchPathBTN_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.__searchPathTB.Text = fbd.SelectedPath;
            }
        }

        private void __mergeBTN_Click(object sender, EventArgs e)
        {
            Presenter.BeginMerge();
        }
    }
}
