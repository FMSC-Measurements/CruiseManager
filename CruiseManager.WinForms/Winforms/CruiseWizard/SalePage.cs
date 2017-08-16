using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class SalePage : UserControl, IPage
    {
        #region Constructor

        public SalePage(String Name, CruiseWizardView MasterView)
        {
            InitializeComponent();
            this.MasterView = MasterView;
            base.Name = Name;
            InitializePurposeComboBox();
        }

        #endregion Constructor

        #region Properties

        public CruiseWizardView MasterView { get; set; }
        public CruiseWizardPresenter Presenter { get { return MasterView.Presenter; } }
        string _templatePath = null;

        #endregion Properties

        #region Initialization Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UOMBindingSource.DataSource = Presenter.UOMCodes;
            forestsBindingSource.SuspendBinding();
            RegionForestBindingSource.DataSource = Presenter.Regions;
            forestsBindingSource.ResumeBinding();
            SaleDOBindingSource.DataSource = Presenter.Sale;
        }

        private void InitializePurposeComboBox()
        {
            PurposeComboBox.Items.AddRange(CruiseManager.Core.Constants.Strings.SALE_PURPOSE);
        }

        #endregion Initialization Methods

        #region Button Events

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (!_templatePathTB.Text.Equals(""))
            {
                _templatePathTB.Enabled = false;
                _browseTemplateButton.Enabled = false;
            }

            Presenter.HandleSalePageExit(_templatePath);
            //Presenter.Sale.Validate();
            //if (Presenter.Sale.HasErrors())
            //{
            //    MessageBox.Show(Presenter.Sale.Error, "Warning", MessageBoxButtons.OK);
            //    return;
            //}

            //if (!string.IsNullOrEmpty(_templatePath) && File.Exists(_templatePath))
            //{
            //    FileInfo template = new FileInfo(_templatePath);
            //    Presenter.LoadTemplate(template);
            //}

            //if (CruiseMethods.Count == 0)
            //{
            //    var setupServ = _appStateHandle.SetupServ;
            //    CruiseMethods = setupServ.GetCruiseMethods();
            //}

            //Presenter.ShowCuttingUnits();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MasterView.Close();
        }

        public void SetTemplatePathTextBox(string value, bool enable)
        {
            _templatePathTB.Text = value;
            _templatePathTB.Enabled = enable;
            _browseTemplateButton.Enabled = enable;
        }

        private void _browseTemplateButton_Click(object sender, EventArgs e)
        {
            string filePath = Presenter.WindowPresenter.AskTemplateLocation();
            _templatePath = filePath;
            _templatePathTB.Text = filePath;
        }

        #endregion Button Events

        private void _districtMTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #region IPage Members

        public bool HandleKeypress(System.Windows.Forms.Keys key)
        {
            return false;
        }

        #endregion IPage Members

        private void SaleDOBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Item Changed");
        }

        private void UOMBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UOM Changed");
        }
    }
}