using CruiseDAL.DataObjects;
using CruiseManager.Core.SetupModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class FormAddTreeDefault : Form
    {
        public FormAddTreeDefault(List<ProductCode> codeList)
        {
            InitializeComponent();
            this._PProdCB.DataSource = codeList;
        }

        public TreeDefaultValueDO TreeDefault
        {
            get { return this._BS_TDV.DataSource as TreeDefaultValueDO; }
            set
            {
                this._BS_TDV.DataSource = value;
            }
        }

        private TreeDefaultValueDO _initialState = new TreeDefaultValueDO();

        public DialogResult ShowDialog(TreeDefaultValueDO tdv)
        {
            this.TreeDefault = tdv;
            this._initialState.SetValues(tdv);
            return this.ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (DialogResult == DialogResult.OK)
            {
                this._BS_TDV.EndEdit();
                if (!TreeDefault.Validate() == true)
                {
                    MessageBox.Show(this.TreeDefault.Error);
                    e.Cancel = true;
                }
            }
            else if (DialogResult == DialogResult.Cancel)
            {
                this.TreeDefault.SetValues(this._initialState);
            }
        }
    }
}