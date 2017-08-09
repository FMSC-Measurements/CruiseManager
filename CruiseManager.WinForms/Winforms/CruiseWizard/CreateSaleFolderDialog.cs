using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class CreateSaleFolderDialog : Form
    {
        public CreateSaleFolderDialog()
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