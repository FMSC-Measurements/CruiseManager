using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CruiseManager.Core.CruiseCustomize;

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

        protected void OnTallyPopulationChangeing()
        {
            _sp_LBL.Text = string.Empty;
        }

        protected void OnTallyPopulationChanged()
        {
            if (_tallyPopulation != null)
            {
                _sp_LBL.Text = TallyPopulation.TreeDefaultValue.Species;
                bindingSource.DataSource = _tallyPopulation;
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
