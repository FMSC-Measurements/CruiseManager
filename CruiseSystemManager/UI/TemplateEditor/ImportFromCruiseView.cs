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
using CSM.Logic;
using CSM.Common;

namespace CSM.UI.TemplateEditor
{
    public partial class ImportFromCruiseView : UserControl, IPresentor , IView
    {
        public ImportFromCruiseView(IWindowPresenter windowPresenter)
        {
            
            InitializeComponent();
            this.WindowPresenter = windowPresenter;

            this.NavOptions = null;
            this.ViewActions = new NavOption[]{
                new NavOption("Import", this.Finish),
                new NavOption("Cancel", this.WindowPresenter.ShowTemplateLandingLayout)
            };

            this.TreeDefaultsToCopy = new List<TreeDefaultValueDO>();
            this.selectedItemsGridView1.SelectedItems = this.TreeDefaultsToCopy;
        }

        public ImportFromCruiseView(IWindowPresenter windowPresenter, string fileName) : this(windowPresenter)
        {
            this._copyFromDB = new DAL(fileName);
        }

        public IWindowPresenter WindowPresenter { get; set; }
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
                this.WindowPresenter.Database.DirectCopy(this._copyFromDB, CruiseDAL.Schema.VOLUMEEQUATION._NAME, null, cOpt);
            }

            foreach (TreeDefaultValueDO tdv in TreeDefaultsToCopy)
            {
                tdv.DAL = this.WindowPresenter.Database;
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





        #region IPresentor Members


        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IView Members

        public NavOption[] NavOptions { get; protected set; }


        public NavOption[] ViewActions { get; protected set; }


        #endregion
    }
}
