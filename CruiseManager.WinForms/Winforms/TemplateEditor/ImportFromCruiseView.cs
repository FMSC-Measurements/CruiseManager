using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.EditTemplate;

namespace CruiseManager.WinForms.TemplateEditor
{
    public partial class ImportFromCruiseView : UserControlView
    {
        public ImportFromCruiseView(WindowPresenter windowPresenter, TemplateEditViewPresenter viewPresenter)
        {
            
            InitializeComponent();
            this.WindowPresenter = windowPresenter;
            this.ApplicationController = viewPresenter.ApplicationController;


            //this.UserCommands = new ViewCommand[]{
            //    ApplicationController.MakeViewCommand("Import", this.Finish ),
            //    ApplicationController.MakeViewCommand("Cancel", this.WindowPresenter.ShowTemplateLandingLayout)
            //};

            this.TreeDefaultsToCopy = new List<TreeDefaultValueDO>();
            this.selectedItemsGridView1.SelectedItems = this.TreeDefaultsToCopy;
        }

        public ImportFromCruiseView(string fileName, WindowPresenter windowPresenter, TemplateEditViewPresenter viewPresenter) : this(windowPresenter, viewPresenter)
        {
            this._copyFromDB = new DAL(fileName);
        }

        public new TemplateEditViewPresenter ViewPresenter
        {
            get { return (TemplateEditViewPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }
        protected WindowPresenter WindowPresenter { get; set; }
        protected ApplicationControllerBase ApplicationController { get; set; }
        public List<TreeDefaultValueDO> TreeDefaults { get; set; }
        public List<TreeDefaultValueDO> TreeDefaultsToCopy { get; set; }

        public string FileName 
        {
            get { return this._copyFromDB.Path; }
        }

        private DAL _copyFromDB; 

        public bool ReplaceExistingVolEq
        {
            get { return _replaceVolEqRB.Checked; }
        }

        

        private void _importVolEqCB_CheckedChanged(object sender, EventArgs e)
        {
            this._volEqOptGB.Enabled = this._importVolEqCB.Checked;
        }

        private void LoadTreeDefaults()
        {
            this.TreeDefaults = this._copyFromDB.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
            this._BS_TDV.DataSource = this.TreeDefaults;
        }

        public void Finish()
        {
            if (this._importVolEqCB.Checked)
            {
                var cOpt = (this.ReplaceExistingVolEq == true) ? FMSC.ORM.Core.SQL.OnConflictOption.Replace : FMSC.ORM.Core.SQL.OnConflictOption.Ignore;
                this.ApplicationController.Database.BeginTransaction();
                try
                {
                    foreach (var volEq in _copyFromDB.From<VolumeEquationDO>().Query())
                    {
                        this.ApplicationController.Database.Insert(volEq, null, FMSC.ORM.Core.SQL.OnConflictOption.Ignore);
                    }
                    this.ApplicationController.Database.CommitTransaction();
                }
                catch
                {
                    this.ApplicationController.Database.RollbackTransaction();
                }

                //this.ApplicationController.Database.DirectCopy(this._copyFromDB, CruiseDAL.Schema.VOLUMEEQUATION._NAME, null, cOpt);
            }

            foreach (TreeDefaultValueDO tdv in TreeDefaultsToCopy)
            {
                tdv.DAL = this.ApplicationController.Database;
                tdv.Save(FMSC.ORM.Core.SQL.OnConflictOption.Ignore);
            }
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

    }
}
