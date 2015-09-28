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
using CruiseManager.Core;
using CruiseManager.Core.App;
using CruiseManager.App;
using CruiseManager.Core.EditTemplate;

namespace CruiseManager.Winforms.TemplateEditor
{
    public partial class ImportFromCruiseView : UserControl, IView
    {
        public ImportFromCruiseView(TemplateEditViewPresenter viewPresenter)
        {
            
            InitializeComponent();
            this.WindowPresenter = viewPresenter.WindowPresenter;
            this.ApplicationController = viewPresenter.ApplicationController;


            this.UserCommands = new ViewCommand[]{
                ApplicationController.MakeViewCommand("Import", this.Finish ),
                ApplicationController.MakeViewCommand("Cancel", this.WindowPresenter.ShowTemplateLandingLayout)
            };

            this.TreeDefaultsToCopy = new List<TreeDefaultValueDO>();
            this.selectedItemsGridView1.SelectedItems = this.TreeDefaultsToCopy;
        }

        public ImportFromCruiseView(string fileName, TemplateEditViewPresenter viewPresenter) : this(viewPresenter)
        {
            this._copyFromDB = new DAL(fileName);
        }

        public TemplateEditViewPresenter ViewPresenter { get; set; }
        protected WindowPresenter WindowPresenter { get; set; }
        protected ApplicationController ApplicationController { get; set; }
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
                OnConflictOption cOpt = (this.ReplaceExistingVolEq == true) ? OnConflictOption.Replace : OnConflictOption.Ignore;
                this.ApplicationController.Database.DirectCopy(this._copyFromDB, CruiseDAL.Schema.VOLUMEEQUATION._NAME, null, cOpt);
            }

            foreach (TreeDefaultValueDO tdv in TreeDefaultsToCopy)
            {
                tdv.DAL = this.ApplicationController.Database;
                tdv.Save(OnConflictOption.Ignore);
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




        #region IView Members

        IPresentor IView.ViewPresenter
        {
            get
            {
                return this.ViewPresenter;
            }
        }

        public IEnumerable<ViewCommand> NavCommands
        {
            get
            {
                return null;
            }
        }

        public IEnumerable<ViewCommand> UserCommands
        {
            get; set;
        }


        #endregion
    }
}
