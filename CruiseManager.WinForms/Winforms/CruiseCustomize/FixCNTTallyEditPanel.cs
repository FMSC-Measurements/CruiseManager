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
    public partial class FixCNTTallyEditPanel : UserControl
    {
        public FixCNTTallyEditPanel()
        {
            InitializeComponent();

            var tallFieldValues = Enum.GetNames(typeof(FixCNTTallyField));
            _tallyField_CmbB.Items.AddRange(tallFieldValues);

        }

        FixCNTTallyClass _tallyClass;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FixCNTTallyClass TallyClass
        {
            get { return _tallyClass; }
            set
            {
                OnTallyClassChanging();
                _tallyClass = value;
                OnTallyClassChanged();
            }
        }

        protected void OnTallyClassChanging()
        {
            _lowerPannel.Controls.Clear();
        }

        protected void OnTallyClassChanged()
        {
            if(TallyClass != null)
            {
                _tallyField_CmbB.SelectedItem = TallyClass.Field.ToString();

                _lowerPannel.SuspendLayout();
                foreach(var tallyPop in TallyClass.TallyPopulations)
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
