using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using CSM.Utility.Setup;

namespace CSM.Winforms.CruiseWizard
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

        private void _okBTN_Click(object sender, EventArgs e)
        {
            this._BS_TDV.EndEdit();
            if (this.TreeDefault.Validate() == true)
            {
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(this.TreeDefault.Error);
            }
        }

        private void _cancelBTN_Click(object sender, EventArgs e)
        {
            this.TreeDefault.SetValues(this._initialState);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
