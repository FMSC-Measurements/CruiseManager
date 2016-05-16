using CruiseManager.Core.CruiseCustomize;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class FixCNTTallyPopulationRow : UserControl
    {
        public FixCNTTallyPopulationRow()
        {
            InitializeComponent();
        }

        FixCNTTallyPopulation _tallyPopulation;

        public FixCNTTallyPopulation TallyPopulation
        {
            get { return _tallyPopulation; }
            set
            {
                OnTallyPopulationChangeing();
                _tallyPopulation = value;
                OnTallyPopulationChanged();
            }
        }

        public void EndEdits()
        {
            _BS_tallyPop.EndEdit();
        }

        protected void OnTallyPopulationChangeing()
        {
            _sp_LBL.Text = string.Empty;
        }

        protected void OnTallyPopulationChanged()
        {
            if (_tallyPopulation != null)
            {
                _sp_LBL.Text = TallyPopulation.TreeDefaultValue.Species;
                _BS_tallyPop.DataSource = _tallyPopulation;
            }
            else
            {
                _sp_LBL.Text = string.Empty;
            }
        }

        private void _max_CmbB_DropDown(object sender, EventArgs e)
        {
            _max_CmbB.Items.Clear();

            foreach (var opt in _tallyPopulation.EnumerateMaxOptions().Take(10))
            {
                _max_CmbB.Items.Add(opt);
            }
        }
    }
}