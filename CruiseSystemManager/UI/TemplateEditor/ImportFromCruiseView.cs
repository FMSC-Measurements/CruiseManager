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

namespace CSM.UI.TemplateEditor
{
    public partial class ImportFromCruiseView : UserControl, IPresentor 
    {
        public ImportFromCruiseView(IWindowPresenter controller, string fileName)
        {
            InitializeComponent();
            this.Controller = controller;
            this.FileName = fileName;

            this.TreeDefaultsToCopy = new List<TreeDefaultValueDO>();
            this.selectedItemsGridView1.SelectedItems = this.TreeDefaultsToCopy;
            this.TreeDefaults = this._copyFromDB.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
            this._BS_TDV.DataSource = this.TreeDefaults;
            
        }

        public IWindowPresenter Controller { get; set; }
        public List<TreeDefaultValueDO> TreeDefaults { get; set; }
        public List<TreeDefaultValueDO> TreeDefaultsToCopy { get; set; }

        public string FileName 
        {
            get { return this._copyFromDB.Path; }
            set 
            {
                this._copyFromDB = new DAL(value);
            }
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

        public void Finish()
        {
            if (this._importVolEqCB.Checked)
            {
                OnConflictOption cOpt = (this.ReplaceExistingVolEq == true) ? OnConflictOption.Replace : OnConflictOption.Ignore;
                this.Controller.Database.DirectCopy(this._copyFromDB, CruiseDAL.Schema.VOLUMEEQUATION._NAME, null, cOpt);
            }

            foreach (TreeDefaultValueDO tdv in TreeDefaultsToCopy)
            {
                tdv.DAL = this.Controller.Database;
                tdv.Save(OnConflictOption.Ignore);
            }
        }

        #region ISaveHandler Members

        public void HandleSave()
        {
            
        }

        public void HandleAppClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public bool CanHandleSave
        {
            get
            {
                return false;
            }
        }

        #endregion

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
    }
}
