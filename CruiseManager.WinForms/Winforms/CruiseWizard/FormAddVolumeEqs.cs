using CruiseDAL.DataObjects;
using CruiseManager.Core.SetupModels;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class FormAddVolumeEqs : Form
    {
        public FormAddVolumeEqs(List<ProductCode> codeList)
        {
            InitializeComponent();
            this._PProdCB.DataSource = codeList;
        }

        public VolumeEquationDO VolumeEq
        {
            get { return this._BS_TDV.DataSource as VolumeEquationDO; }
            set
            {
                this._BS_TDV.DataSource = value;
            }
        }

        private VolumeEquationDO _initialState = new VolumeEquationDO();

        public DialogResult ShowDialog(VolumeEquationDO tdv)
        {
            this.VolumeEq = tdv;
            this._initialState.SetValues(tdv);
            return this.ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (DialogResult == DialogResult.OK)
            {
                this._BS_TDV.EndEdit();
                if (!VolumeEq.Validate() == true)
                {
                    MessageBox.Show(this.VolumeEq.Error);
                    e.Cancel = true;
                }
            }
            else if (DialogResult == DialogResult.Cancel)
            {
                this.VolumeEq.SetValues(this._initialState);
            }
        }
    }
}