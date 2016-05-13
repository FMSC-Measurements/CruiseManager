using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class FixCNTTallyEditPanel : UserControl, ITallyEditPanel
    {
        public FixCNTTallyEditPanel()
        {
            InitializeComponent();

            var tallFieldValues = Enum.GetNames(typeof(FixCNTTallyField));
            _tallyField_CmbB.Items.AddRange(tallFieldValues);
        }

        FixCNTTallySetupStratum _stratum;

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

        protected void OnStratumChanged()
        {
            var str = _stratum as FixCNTTallySetupStratum;
            TallyClass = str?.TallyClass;
        }

        FixCNTTallyClass _tallyClass;

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
#warning TODO 
        }

        protected void OnTallyClassChanging()
        {
            _lowerPannel.Controls.Clear();
        }

        protected void OnTallyClassChanged()
        {
            if (TallyClass != null)
            {
                _tallyField_CmbB.SelectedItem = TallyClass.Field.ToString();

                _lowerPannel.SuspendLayout();
                foreach (var tallyPop in TallyClass.TallyPopulations)
                {
                    var newPopRow = new FixCNTTallyPopulationRow()
                    {
                        TallyPopulation = tallyPop
                    };

                    _lowerPannel.Controls.Add(newPopRow);
                }
                _lowerPannel.ResumeLayout(true);
            }
        }
    }
}