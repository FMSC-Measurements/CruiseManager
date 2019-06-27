using CruiseManager.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class CreateSaleFolderDialog : Form
    {
        public IUserSettings UserSettings { get; }

        public CreateSaleFolderDialog(IUserSettings userSettings)
        {
            UserSettings = userSettings;
            InitializeComponent();
        }

        public bool RememberSelection
        {
            get
            {
                return this.checkBox1.Checked;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            var dialogResult = DialogResult;
            var createSaleFolder = dialogResult == DialogResult.Yes;

            if (RememberSelection)
            {
                UserSettings.CreateSaleFolder = createSaleFolder;
            }
        }


    }
}