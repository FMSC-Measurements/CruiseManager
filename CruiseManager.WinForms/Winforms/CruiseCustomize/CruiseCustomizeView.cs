using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using System.Collections;
using CruiseManager.Core.App;
using CruiseManager.Core.Models;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class CruiseCustomizeView : UserControlView, Core.ViewInterfaces.CruiseCustomizeView
    {
        private TabPage _logMatrixTabPage;
        
        private TallySetupStratum_Base _currentTallySetupStratum;
        private TallySetupSampleGroup _currentSG;
        private DataGridViewComboBoxColumn fieldDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn minDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn maxDataGridViewTextBoxColumn;

        private LogMatrixSettingsPage _logMatrixPage;

        public new CustomizeCruisePresenter ViewPresenter
        {
            get { return (CustomizeCruisePresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }
        //protected StratumDO FieldSetup_CurrentStratum { get; set; }

        public CruiseCustomizeView(CustomizeCruisePresenter presenter)
        {
            this.ViewPresenter = presenter;
            ViewPresenter.View = this;

            InitializeComponent();

            if (this.ViewPresenter.ApplicationController.InSupervisorMode)
            {
                InitializeLogMatrixComponent();
            }        
        }

        private void InitializeLogMatrixComponent()
        {
            this._logMatrixPage = new LogMatrixSettingsPage(this.ViewPresenter);
            this._logMatrixPage.SuspendLayout();
            this._logMatrixPage.Dock = DockStyle.Fill;

            this._logMatrixTabPage = new System.Windows.Forms.TabPage();
            this._logMatrixTabPage.SuspendLayout();


            // 
            // _logMatrixTabPage
            // 
            this._logMatrixTabPage.Controls.Add(this._logMatrixPage);
            this._logMatrixTabPage.Location = new System.Drawing.Point(4, 22);
            this._logMatrixTabPage.Name = "_logMatrixTabPage";
            this._logMatrixTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._logMatrixTabPage.Size = new System.Drawing.Size(632, 391);
            this._logMatrixTabPage.TabIndex = 7;
            this._logMatrixTabPage.Text = "Log Matrix";
            this._logMatrixTabPage.UseVisualStyleBackColor = true;

            this._logMatrixTabPage.ResumeLayout(false);
            this._logMatrixPage.ResumeLayout(false);

            this._tabControl.Controls.Add(this._logMatrixTabPage);
        }

        



        public void UpdateTallySetupView()
        {
            _strataCB.DataSource = ViewPresenter.TallySetupStrata;
            //_tallyEditPanel.TallyPresets = Presenter.TallyPresets;
        }

        public void UpdateFieldSetupViews()
        {
            if (this.ViewPresenter.IsLogGradingEnabled)
            {
                if (!this._fieldSetup_Child_TabControl.TabPages.Contains(this._logField_TabPage))
                {
                    this._fieldSetup_Child_TabControl.TabPages.Add(this._logField_TabPage);
                }
            }
            else
            {
                this._fieldSetup_Child_TabControl.TabPages.Remove(this._logField_TabPage);
            }
            _strataLB.DataSource = ViewPresenter.FieldSetupStrata;
        }

        public void UpdateTreeDefaults()
        {
            _BS_treeDefaults.DataSource = ViewPresenter.TreeDefaults;
        }

        public void UpdateTreeAudits()
        {
            _BS_treeAudits.DataSource = ViewPresenter.TreeAudits;
        }

        public void UpdateLogMatrix()
        {
            //_BS_LogMatrix.DataSource = Presenter.LogMatrix;
            if(this._logMatrixPage != null)
            {
                this._logMatrixPage.DataSource = ViewPresenter.LogMatrix;
            }
        }

        //public void UpdateTallySampleGroups(IList<SampleGroupDO> sampleGroups)
        //{
        //    _sampleGroupCB.DataSource = sampleGroups;
        //}

        public void EndEdits()
        {
            if (_currentSG != null && this._systematicOptCB.Enabled)
            {
                _currentSG.UseSystematicSampling = this._systematicOptCB.Checked;
            }
            if (_currentTallySetupStratum != null)
            {
                _currentTallySetupStratum.Hotkey = _stratumHKCB.Text;
            }

            this._tallyEditPanel.EndEdits();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ViewPresenter.InitializeFieldSetup();
 
            this.ViewPresenter.InitializeTallySetup();

            this.ViewPresenter.InitializeTreeAudits();
   
            this.ViewPresenter.InitializeLogMatrix();
     
        }



        #region Tally setup
        private void _strataCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_currentTallySetupStratum != null)
            {
                _currentTallySetupStratum.Hotkey = _stratumHKCB.Text;
                _currentTallySetupStratum.Save();
            }
            _currentTallySetupStratum = _strataCB.SelectedValue as TallySetupStratum_Base;

            
            if(_currentTallySetupStratum == null) { return; }

            _stratumHKCB.DataSource = this.ViewPresenter.GetAvalibleStratumHotKeys(_currentTallySetupStratum);
            _stratumHKCB.Text = _currentTallySetupStratum.Hotkey;

            this._tallyEditPanel.Enabled = _currentTallySetupStratum.CanDefineTallies;
            
            _sampleGroupCB.DataSource = _currentTallySetupStratum.SampleGroups;                
        }

        private void _sampleGroupCB_SelectedValueChanged(object sender, EventArgs e)
        {
            //store use systematic sampleing option for previously selected sample group, if there was one
            if (_currentSG != null && this._systematicOptCB.Enabled)
            {
                _currentSG.UseSystematicSampling = this._systematicOptCB.Checked;
            }

            _currentSG = _sampleGroupCB.SelectedValue as TallySetupSampleGroup;
            if (_currentSG == null || _tallyEditPanel.Enabled == false)
            {
                this._systematicOptCB.Enabled = false;
                return;
            }
            else
            {
                this._systematicOptCB.Enabled =  _currentSG.CanEditSampleType;
                this._systematicOptCB.Checked = _currentSG.UseSystematicSampling;
            }

            _tallyEditPanel.CurrentSampleGroup = _currentSG;
            _tallyEditPanel.SetHotKeys(this.ViewPresenter.GetAvalibleHotKeysInStratum(_currentTallySetupStratum));
        }

        //TODO move these methods to presenter class
        
        #endregion

        #region Tree/Log Field methods
        private void _strataLB_SelectedValueChanged(object sender, EventArgs e)
        {
            FieldSetupStratum stratum = _strataLB.SelectedValue as FieldSetupStratum;
            if (stratum == null) { return; }
            HandleFieldSetupSelectedStratumChanged(stratum);
        }

        private void HandleFieldSetupSelectedStratumChanged(FieldSetupStratum stratum)
        {
            if (stratum != null)
            {
                var selectedTreeFields = stratum.SelectedTreeFields;
                var unselectedTreeFields = stratum.UnselectedTreeFields.OrderBy(x => x.Heading).ToList();
                this._treeFieldWidget.SelectedItemsDataSource = selectedTreeFields;
                this._treeFieldWidget.DataSource = unselectedTreeFields;

                var selectedLogFields = stratum.SelectedLogFields;
                var unselectedLogFields = stratum.UnselectedLogFields.OrderBy(x=> x.Heading).ToList();

                this._logFieldWidget.SelectedItemsDataSource = selectedLogFields;
                this._logFieldWidget.DataSource = unselectedLogFields;
            }
        }


        private void _treeFieldWidget_SelectionMoved(object sender, FMSC.Controls.ItemMovedEventArgs e)
        {
            UpdateTreeFieldOrder();
            //TreeFieldSetupDO tf = e.Item as TreeFieldSetupDO;
            //IList<TreeFieldSetupDO> list = (IList<TreeFieldSetupDO>)_treeFieldWidget.SelectedItemsDataSource;
            //TreeFieldSetupDO othertf = list[e.PreviousIndex];
            //tf.FieldOrder = e.NewIndex;
            //othertf.FieldOrder = e.PreviousIndex;
        }

        private void _treeFieldWidget_SelectionAdded(object sender, object item, int index)
        {
            UpdateTreeFieldOrder();
            //TreeFieldSetupDO tf = item as TreeFieldSetupDO;
            //if (tf == null) { return; }
            ////tf.Stratum = FieldSetup_CurrentStratum;
            //tf.FieldOrder = index;
            ////tf.DAL = Presenter.Controller.Database;
            ////tf.Save();
        }

        private void _logFieldWidget_SelectionAdded(object sender, object item, int index)
        {
            UpdateLogFieldOrder();
            //LogFieldSetupDO lf = item as LogFieldSetupDO;
            //if (lf == null) { return; }
            ////lf.Stratum = FieldSetup_CurrentStratum;
            //lf.FieldOrder = index;
            ////lf.DAL = Presenter.Controller.Database;
            ////lf.Save();
        }

        private void _logFieldWidget_SelectionMoved(object sender, FMSC.Controls.ItemMovedEventArgs e)
        {
            UpdateLogFieldOrder();
            //LogFieldSetupDO lf = e.Item as LogFieldSetupDO;
            //IList<LogFieldSetupDO> list = (IList<LogFieldSetupDO>)_logFieldWidget.SelectedItemsDataSource;
            //LogFieldSetupDO otherlf = list[e.PreviousIndex];
            //lf.FieldOrder = e.NewIndex;
            //otherlf.FieldOrder = e.PreviousIndex;
            ////lf.Save();
            ////otherlf.Save();
        }



        //refreshes the field order on all items
        //item's fieldOrder = item's list position + 1
        private void UpdateLogFieldOrder()
        {
            IList<LogFieldSetupDO> list = (IList<LogFieldSetupDO>)_logFieldWidget.SelectedItemsDataSource;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FieldOrder = i + 1;
            }
        }

        //refreshes the field order on all items
        //item's fieldOrder = item's list position + 1
        private void UpdateTreeFieldOrder()
        {
            IList<TreeFieldSetupDO> list = (IList<TreeFieldSetupDO>)_treeFieldWidget.SelectedItemsDataSource;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FieldOrder = i + 1;
            }
        }

        private void _logFieldWidget_SelectedValueChanged(object sender, EventArgs e, object selectedValue)
        {
            if (selectedValue == null) { return; }
            this._BS_LogField.DataSource = selectedValue;
        }

        private void _treeFieldWidget_SelectedValueChanged(object sender, EventArgs e, object selectedValue)
        {
            if (selectedValue == null) { return; }
            this._BS_TreeField.DataSource = selectedValue;
        }
#endregion 

        #region Tree Audits
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
        #endregion 




        ///// <summary> 
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if(_logMatrixTabPage != null)
        //        {
        //            _logMatrixTabPage.Dispose();
        //        }
        //    }
            

        //    base.Dispose(disposing);


        //}

        
    }
}
