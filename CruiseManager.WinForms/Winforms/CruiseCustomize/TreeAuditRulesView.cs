using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseDAL.DataObjects;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class TreeAuditRulesView : CruiseManager.WinForms.UserControlView, ITreeAuditView
    {
        public TreeAuditRulesView()
        {
            InitializeComponent();
        }

        public new TreeAuditRulePresenter ViewPresenter
        {
            get { return (TreeAuditRulePresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public void UpdateTreeAudits()
        {
            _BS_treeAudits.DataSource = ViewPresenter.TreeAudits;
        }

        public void UpdateTreeDefaults()
        {
            _BS_treeDefaults.DataSource = ViewPresenter.TreeDefaults;
        }

        private void _BS_treeAudits_CurrentItemChanged(object sender, EventArgs e)
        {
            TreeAuditValueDO tav = _BS_treeAudits.Current as TreeAuditValueDO;
            if (tav == null) { return; }
            if (!tav.TreeDefaultValues.IsPopulated)
            {
                tav.TreeDefaultValues.Populate();
            }
            _tdvDGV.SelectedItems = tav.TreeDefaultValues;
        }

        private void _treeAuditClearSelectionBtn_Click(object sender, EventArgs e)
        {
            TreeAuditValueDO tav = _BS_treeAudits.Current as TreeAuditValueDO;
            if (tav == null) { return; }
            if (!tav.TreeDefaultValues.IsPopulated)
            {
                tav.TreeDefaultValues.Populate();
            }
            tav.TreeDefaultValues.Clear();
            _tdvDGV.Invalidate();
        }

        private void _tavDeleteBTN_Click(object sender, EventArgs e)
        {
            TreeAuditValueDO tav = _BS_treeAudits.Current as TreeAuditValueDO;
            if (tav == null) { return; }
            if (tav.IsPersisted)
            {
                tav.Delete();
            }
            _BS_treeAudits.Remove(tav);
        }


        //TODO keep method? Under what situations do DG throw Data Errror?
        private void _treeAuditDGV_DataError(object sender,
            DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
