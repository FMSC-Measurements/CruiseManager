using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using System.IO;
using CruiseManager.Core.App;

namespace CruiseManager.Winforms.CruiseWizard
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

        #endregion

        #region Properties 
        public CruiseWizardView MasterView { get; set; }
        public CruiseWizardPresenter Presenter { get { return MasterView.Presenter; } }
        string _templatePath = null;
        #endregion 

        #region Initialization Methods
        protected override void  OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UOMBindingSource.DataSource = Presenter.UOMCodes;
            this.forestsBindingSource.SuspendBinding();
            this.RegionForestBindingSource.DataSource = this.Presenter.Regions;
            this.forestsBindingSource.ResumeBinding();
            this.SaleDOBindingSource.DataSource = this.Presenter.Sale;
            //var localFiles = Presenter.LocalTemplateFiles;
            //SelectTemplateComboBox.DataSource = localFiles;
            //SelectTemplateComboBox.SelectedIndex = -1;

            //RegionForestBindingSource.DataSource = Presenter.Regions;
        }

        //public void BindData()
        //{
        //    errorProvider1.DataSource = SaleDOBindingSource;
        //    SaleDOBindingSource.DataSource = Presenter.Sale;
        //}


        private void InitializePurposeComboBox()
        {
            //PurposeComboBox.DataSource = CSM.Utility.Constants.SALE_PURPOSE;
            PurposeComboBox.Items.AddRange(CruiseManager.Core.Constants.Strings.SALE_PURPOSE);
        }

        #endregion

        #region Button Events
        private void NextButton_Click(object sender, EventArgs e)
        {
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
            this._templatePathTB.Text = value;
            this._templatePathTB.Enabled = enable;
            this._browseTemplateButton.Enabled = enable;
        }

        private void _browseTemplateButton_Click(object sender, EventArgs e)
        {
            
            string filePath = WindowPresenter.Instance.AskTemplateLocation();
            _templatePath = filePath;
            _templatePathTB.Text = filePath;
        }
        #endregion

        private void _districtMTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        #region IPage Members


        public bool HandleKeypress(System.Windows.Forms.Keys key)
        {
            return false;
        }

        #endregion

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
