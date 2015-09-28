using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.App;
using CruiseManager.Core;

namespace CruiseManager.Winforms.TemplateEditor
{
    public partial class TemplateEditViewControl : UserControl, IPresentor, IView
    {

        public TemplateEditViewControl(WindowPresenter windowPresenter, ApplicationController applicationController)
        {
            this.ApplicationController = applicationController;
            this.WindowPresenter = windowPresenter;

            this.NavCommands = new ViewCommand[]{
                this.ApplicationController.MakeViewCommand("Close File", this.WindowPresenter.ShowCruiseLandingLayout),
                this.ApplicationController.MakeViewCommand("Import From File", this.WindowPresenter.ShowImportTemplate)
            };

            InitializeComponent();
        }

        protected ApplicationController ApplicationController;
        protected WindowPresenter WindowPresenter { get; set; }
        
        public TemplateEditViewPresenter Presenter { get; set; }
        protected TreeDefaultValueDO TreeAudit_CurrentTDV { get; set; }
        protected CruiseMethodsDO FieldSetup_CurrentMethod { get; set; }

        

        //private void _tallyDGV_VisibleChanged(object sender, EventArgs e)
        //{
        //    Presenter.HandleTallyLoad();
        //}

        private void _volumeEQsDGV_VisibleChanged(object sender, EventArgs e)
        {
            Presenter.HandleVolumeEquLoad();
        }

        private void _reportsDGV_VisibleChanged(object sender, EventArgs e)
        {
            Presenter.HandleReportsLoad();
        }
       
        //public void UpdateTallySetup()
        //{
        //    _BS_Tallies.DataSource = Presenter.Tallies;
        //}

        public void UpdateVolumeEqs()
        {
            _BS_VolEquations.DataSource = Presenter.VolumeEQs;
        }

        public void UpdateReports()
        {
            _BS_Reports.DataSource = Presenter.Reports;
        }

       

#region Tree/Log Field Setup
        public void UpdateFieldSetup()
        {
            if (Presenter.CruiseMethods != null)
            {
                _BS_CruiseMethods.DataSource = Presenter.CruiseMethods;
            }
            this._logFieldWidget.SelectedItemsDataSource = Presenter.SelectedLogFields;
            this._logFieldWidget.DataSource = Presenter.UnselectedLogFields;
            //this._BS_LogField.DataSource = Presenter.SelectedLogFields;
            //this._BS_TreeField.DataSource = Presenter.TreeFields;
        }

        private void _cruiseMethodListBox_VisibleChanged(object sender, EventArgs e)
        {
            Presenter.HandleFieldSetupLoad();
        }

        private void _BS_CruiseMethods_CurrentChanged(object sender, EventArgs e)
        {
            CruiseMethodViewModel method = this._BS_CruiseMethods.Current as CruiseMethodViewModel;
            HandleFieldSetupSelectedCruiseMethodChanged(method);
        }

        private void HandleFieldSetupSelectedCruiseMethodChanged(CruiseMethodViewModel method)
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
            _BS_TreeDefaults.DataSource = Presenter.TreeDefaultValues;
            _BS_treeAudits.DataSource = Presenter.TreeAudits;
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

        private void _treeAuditTDVSelectDGV_VisibleChanged(object sender, EventArgs e)
        {
            Presenter.HandleTreeAuditsLoad();
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
            _BS_TreeDefaults.DataSource = Presenter.TreeDefaultValues;
        }

        private void _treeDefaultDGV_VisibleChanged(object sender, EventArgs e)
        {
            Presenter.HandleTreeDefaultsLoad();
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
            foreach (ReportsDO rpt in this.Presenter.Reports)
            {
                rpt.Selected = true;
            }
        }

        private void _reportsClearSltnBTN_Click(object sender, EventArgs e)
        {
            foreach (ReportsDO rpt in this.Presenter.Reports)
            {
                rpt.Selected = false;
            }
        }
        #endregion

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

        private void _volEq_add_button_Click(object sender, EventArgs e)
        {
            this._BS_VolEquations.Add(new VolumeEquationDO(this.Presenter.Database));
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

        private void _BS_treeAudits_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
           e.NewObject = new TreeAuditValueDO(this.Presenter.Database);
        }



        #region IView Members

        public IPresentor ViewPresenter
        {
            get
            {
                return this;
            }
        }

        public IEnumerable<ViewCommand> NavCommands
        {
            get; set;
        }

        public IEnumerable<ViewCommand> UserCommands
        {
            get; set;
          
        }

        #endregion
    }
}
