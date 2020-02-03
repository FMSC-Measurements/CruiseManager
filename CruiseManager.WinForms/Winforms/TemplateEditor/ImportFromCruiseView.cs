using Backpack.SqlBuilder;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.EditTemplate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManager.WinForms.TemplateEditor
{
    public partial class ImportFromCruiseView : UserControlView
    {
        #region CopyFromDatabase

        private DAL _copyFromDB;

        protected DAL CopyFromDB
        {
            get { return _copyFromDB; }
            set
            {
                _copyFromDB = value;
                OnCopyFromDatabaseChanged();
            }
        }

        private void OnCopyFromDatabaseChanged()
        {
            this._BS_TDV.DataSource = TreeDefaults = CopyFromDB.From<TreeDefaultValueDO>().Read().ToList();
        }

        #endregion CopyFromDatabase

        protected WindowPresenter WindowPresenter { get; set; }

        public IList<TreeDefaultValueDO> TreeDefaults { get; set; }
        public List<TreeDefaultValueDO> TreeDefaultsToCopy { get; set; } = new List<TreeDefaultValueDO>();

        public IApplicationController ApplicationController { get; set; }

        public bool ReplaceExistingVolEq => _replaceVolEqRB.Checked;

        protected ImportFromCruiseView()
        {
            InitializeComponent();

            this.selectedItemsGridView1.SelectedItems = this.TreeDefaultsToCopy;
        }

        public ImportFromCruiseView(string fileName, WindowPresenter windowPresenter, TemplateEditViewPresenter viewPresenter)
            : this()
        {
            this.WindowPresenter = windowPresenter;
            this.ApplicationController = viewPresenter.ApplicationController;

            this.CopyFromDB = new DAL(fileName);
        }

        public new TemplateEditViewPresenter ViewPresenter
        {
            get { return (TemplateEditViewPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public void DoImport()
        {
            if (this._importVolEqCB.Checked)
            {
                var cOpt = (this.ReplaceExistingVolEq == true) ? OnConflictOption.Replace : OnConflictOption.Ignore;
                this.ApplicationController.Database.BeginTransaction();
                try
                {
                    foreach (var volEq in _copyFromDB.From<VolumeEquationDO>().Query())
                    {
                        this.ApplicationController.Database.Insert(volEq, null, OnConflictOption.Ignore);
                    }
                    this.ApplicationController.Database.CommitTransaction();
                }
                catch
                {
                    this.ApplicationController.Database.RollbackTransaction();
                }
            }

            foreach (TreeDefaultValueDO tdv in TreeDefaultsToCopy)
            {
                ApplicationController.Database.Insert(tdv, (object)null, OnConflictOption.Ignore);
            }
        }

        #region event handlers

        private void _importVolEqCB_CheckedChanged(object sender, EventArgs e)
        {
            this._volEqOptGB.Enabled = this._importVolEqCB.Checked;
        }

        private void _selectAllTDVBTN_Click(object sender, EventArgs e)
        {
            foreach (TreeDefaultValueDO tdv in this.TreeDefaults)
            {
                if (!this.TreeDefaultsToCopy.Contains(tdv))
                {
                    this.TreeDefaultsToCopy.Add(tdv);
                }
            }
            this.selectedItemsGridView1.Refresh();
        }

        private void _btn_import_Click(object sender, EventArgs e)
        {
            if (TreeDefaultsToCopy.Count > 0 || _importVolEqCB.Checked == true)
            {
                DoImport();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(this, "nothing selected");
            }
        }

        #endregion event handlers
    }
}