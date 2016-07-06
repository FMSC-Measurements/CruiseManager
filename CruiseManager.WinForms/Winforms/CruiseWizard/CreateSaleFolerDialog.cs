using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class CreateSaleFolerDialog : Form
    {
        public CreateSaleFolerDialog()
        {
            InitializeComponent();
        }

        public bool RememberSelection
        {
            get
            {
                return this.checkBox1.Checked;
            }
        }
    }
}