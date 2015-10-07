using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.App;
using CruiseManager.Core;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.EditTemplate;

namespace CruiseManager.WinForms.TemplateEditor
{
    public partial class EditTemplateViewWinForms : UserControlView, EditTemplateView
    {

        public EditTemplateViewWinForms(WindowPresenter windowPresenter, TemplateEditViewPresenter viewPresenter )
        {
            this.ViewPresenter = viewPresenter;
            ViewPresenter.View = this;
            

            //this.UserCommands = new ViewCommand[]{
            //    this.ViewPresenter.ApplicationController.MakeViewCommand("Close File", this.ViewPresenter.WindowPresenter.ShowCruiseLandingLayout),
            //    this.ViewPresenter.ApplicationController.MakeViewCommand("Import From File", this.ViewPresenter.WindowPresenter.ShowImportTemplate)
            //};

            InitializeComponent();
        }

        protected WindowPresenter WindowPresenter { get; set; }
        
        public new TemplateEditViewPresenter ViewPresenter
        {
            get { return (TemplateEditViewPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }
        protected TreeDefaultValueDO TreeAudit_CurrentTDV { get; set; }
        protected CruiseMethodsDO FieldSetup_CurrentMethod { get; set; }



        //private void _tallyDGV_VisibleChanged(object sender, EventArgs e)
        //{
        //    Presenter.HandleTallyLoad();
        //}

        #region VolEq

        private void _volEq_add_button_Click(object sender, EventArgs e)
        {
            this._BS_VolEquations.Add(new VolumeEquationDO(this.ViewPresenter.Database));
        }

        private void _volEq_delete_button_Click(object sender, EventArgs e)
        {
            VolumeEquationDO obj = this._BS_VolEquations.Current as VolumeEquationDO;
            if (obj != null)
            {
                obj.Delete();
                this._BS_VolEquations.Remove(obj);
            }
        }

        private void _volumeEQsDGV_VisibleChanged(object sender, EventArgs e)
        {
            ViewPresenter.HandleVolumeEquLoad();
        }

        public void UpdateVolumeEqs()
        {
            _BS_VolEquations.DataSource = ViewPresenter.VolumeEQs;
        }

        #endregion

        
       
        //public void UpdateTallySetup()
        //{
        //    _BS_Tallies.DataSource = Presenter.Tallies;
        //}

        

        

       

#region Tree/Log Field Setup
        public void UpdateFieldSetup()
        {
            if (ViewPresenter.CruiseMethods != null)
            {
                _BS_CruiseMethods.DataSource = ViewPresenter.CruiseMethods;
            }
            this._logFieldWidget.SelectedItemsDataSource = ViewPresenter.SelectedLogFields;
            this._logFieldWidget.DataSource = ViewPresenter.UnselectedLogFields;
            //this._BS_LogField.DataSource = Presenter.SelectedLogFields;
            //this._BS_TreeField.DataSource = Presenter.TreeFields;
        }

        private void _cruiseMethodListBox_VisibleChanged(object sender, EventArgs e)
        {
            ViewPresenter.HandleFieldSetupLoad();
        }

        private void _BS_CruiseMethods_CurrentChanged(object sender, EventArgs e)
        {
            EditTemplateCruiseMethod method = this._BS_CruiseMethods.Current as EditTemplateCruiseMethod;
            HandleFieldSetupSelectedCruiseMethodChanged(method);
        }

        private void HandleFieldSetupSelectedCruiseMethodChanged(EditTemplateCruiseMethod method)
        {


            if (method != null)
            {
                //List<String> selectedTreeFields = (from TreeFieldSetupDefaultDO tf in this.Presenter.GetSelectedTreeFields(method) select tf.Field).ToList();
                //List<TreeFieldSetupDefaultDO> unselectedTreeFields = method.UnselectedTreeFields;
                this._treeFieldWidget.SelectedItemsDataSource = method.TreeFields;
                this._treeFieldWidget.DataSource = method.UnselectedTreeFields;

                //List<String> selectedLogFields = (from LogFieldSetupDefaultDO lf in this.Presenter.GetSelectedLogFields(method) select lf.Field).ToList();
                //List<LogFieldSetupDefaultDO> unselectedLogFields = method.UnselectedLogFields;

            }
        }

        private void _logFieldWidget_SelectedValueChanged(object sender, EventArgs e, object selectedValue)
        {
            this._BS_LogField.DataSource = selectedValue ?? String.Empty;
        }

        private void _treeFieldWidget_SelectedValueChanged(object sender, EventArgs e, object selectedValue)
        {
            this._BS_TreeField.DataSource = selectedValue ?? String.Empty;
        }

        private void _treeFieldWidget_SelectionMoved(object sender, FMSC.Controls.ItemMovedEventArgs e)
        {
            UpdateTreeFieldOrder();
        }

        private void _treeFieldWidget_SelectionAdded(object sender, object item, int index)
        {
            UpdateTreeFieldOrder();
        }

        private void _logFieldWidget_SelectionAdded(object sender, object item, int index)
        {
            UpdateLogFieldOrder();
        }

        private void _logFieldWidget_SelectionMoved(object sender, FMSC.Controls.ItemMovedEventArgs e)
        {
            UpdateLogFieldOrder();
        }

        private void UpdateLogFieldOrder()
        {
            IList<LogFieldSetupDefaultDO> list = (IList<LogFieldSetupDefaultDO>)_logFieldWidget.SelectedItemsDataSource;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FieldOrder = i + 1;
            }
        }

        private void UpdateTreeFieldOrder()
        {
            IList<TreeFieldSetupDefaultDO> list = (IList<TreeFieldSetupDefaultDO>)_treeFieldWidget.SelectedItemsDataSource;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FieldOrder = i + 1;
            }
        }
#endregion

        #region Tree Audits
        public void UpdateTreeAudit()
        {
            _BS_TreeDefaults.DataSource = ViewPresenter.TreeDefaultValues;
            _BS_treeAudits.DataSource = ViewPresenter.TreeAudits;
        }

        private void _BS_treeAudits_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            e.NewObject = new TreeAuditValueDO(this.ViewPresenter.Database);
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

        private void _treeAuditDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this._treeAudit_Remove_ButtonCol.Index)
            {
                TreeAuditValueDO tav = this._BS_treeAudits[e.RowIndex] as TreeAuditValueDO;
                if (tav != null)
                {
                    if (tav.IsPersisted) { tav.Delete(); }
                    this._BS_treeAudits.Remove(tav);
                }
            }
        }

        private void _treeAuditTDVSelectDGV_VisibleChanged(object sender, EventArgs e)
        {
            ViewPresenter.HandleTreeAuditsLoad();
        }

        private void _treeAuditDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void _treeAuditClearSelectionBTN_Click(object sender, EventArgs e)
        {
            TreeAuditValueDO tav = _BS_treeAudits.Current as TreeAuditValueDO;
            if (tav == null) { return; }
            tav.TreeDefaultValues.Clear();
            _tdvDGV.Invalidate();
        }
        #endregion

        #region TreeDefaults
        public void UpdateTreeDefaults()
        {
            _BS_TreeDefaults.DataSource = ViewPresenter.TreeDefaultValues;
        }

        private void _treeDefaultDGV_VisibleChanged(object sender, EventArgs e)
        {
            ViewPresenter.HandleTreeDefaultsLoad();
        }

        private void _addTDVButton_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO newTDV = this.WindowPresenter.ShowAddTreeDefult();
            if(newTDV != null)
            {
                this._BS_TreeDefaults.Add(newTDV);
            }
            //TreeDefaultValueDO newTDV = new TreeDefaultValueDO(this.Presenter.Database);
            //SetupService setupService = this.ApplicationController.SetupService;

            //CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault dialog = new CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault(setupService.GetProductCodes());
            //if (dialog.ShowDialog(newTDV) == DialogResult.OK)
            //{
            //    try
            //    {
            //        newTDV.Save();
            //        this._BS_TreeDefaults.Add(newTDV);
            //    }
            //    catch(CruiseDAL.DatabaseExecutionException)
            //    {
            //        MessageBox.Show("Error: Tree Default not saved");
            //    }
            //}
        }

        private void _editTDVButton_Click(object sender, EventArgs e)
        {
            TreeDefaultValueDO tdv = this._BS_TreeDefaults.Current as TreeDefaultValueDO;
            if (tdv == null) { return; }
            {
                this.WindowPresenter.ShowEditTreeDefault(tdv);
            }
            //ApplicationState appState = ApplicationState.GetHandle();

            //TreeDefaultValueDO initialState = new TreeDefaultValueDO(tdv);
            //CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault dialog = new CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault(SetupService.Instance.GetProductCodes());
            //if (dialog.ShowDialog(tdv) == DialogResult.OK)
            //{
            //    try
            //    {
            //        tdv.Save();
            //    }
            //    catch (Exception)
            //    {
            //        tdv.SetValues(tdv);
            //    }
            //}
        }

        private void _deleteTDVBTN_Click(object sender, EventArgs e)
        {
            this._BS_TreeDefaults.RemoveCurrent();
            //TreeDefaultValueDO tdv = this._BS_TreeDefaults.Current as TreeDefaultValueDO;
            //if (tdv != null)
            //{
            //    this._BS_TreeDefaults.RemoveCurrent();
            //    tdv.Delete();
            //}
        }
        #endregion

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

        private void _reportsDGV_VisibleChanged(object sender, EventArgs e)
        {
            ViewPresenter.HandleReportsLoad();
        }

        public void UpdateReports()
        {
            _BS_Reports.DataSource = ViewPresenter.Reports;
        }
        #endregion


    }
}
