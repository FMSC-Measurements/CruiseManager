using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class FixCNTTallyEditPanel : UserControl, ITallyEditPanel
    {
        FixCNTTallySetupStratum _stratum;

        FixCNTTallyClass _tallyClass;

        public FixCNTTallyEditPanel()
        {
            InitializeComponent();

            _tallyField_CmbB.DataSource = FixCNTTallyClass.FIXCNT_FIELD_NAMES;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TallySetupStratum_Base Stratum
        {
            get { return _stratum; }
            set
            {
                _stratum = value as FixCNTTallySetupStratum;
                OnStratumChanged();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected FixCNTTallyClass TallyClass
        {
            get { return _tallyClass; }
            set
            {
                OnTallyClassChanging();
                _tallyClass = value;
                OnTallyClassChanged();
            }
        }

        public void EndEdits()
        {
            _BS_TallyClass.EndEdit();

            foreach (var tallyPopRow
                in _lowerPanel.Controls.OfType<FixCNTTallyPopulationRow>())
            {
                tallyPopRow.EndEdits();
            }
        }

        protected void OnStratumChanged()
        {
            var str = _stratum as FixCNTTallySetupStratum;
            TallyClass = str?.TallyClass;
        }

        protected void OnTallyClassChanged()
        {
            _BS_TallyClass.DataSource = TallyClass;

            if (TallyClass != null)
            {
                //_tallyField_CmbB.SelectedItem = TallyClass.Field.ToString();

                _lowerPanel.SuspendLayout();
                foreach (var tallyPop in TallyClass.TallyPopulations)
                {
                    var newPopRow = new FixCNTTallyPopulationRow()
                    {
                        TallyPopulation = tallyPop
                    };

                    _lowerPanel.Controls.Add(newPopRow);
                }
                _lowerPanel.ResumeLayout(true);
            }
        }

        protected void OnTallyClassChanging()
        {
            _lowerPanel.Controls.Clear();
        }
    }
}