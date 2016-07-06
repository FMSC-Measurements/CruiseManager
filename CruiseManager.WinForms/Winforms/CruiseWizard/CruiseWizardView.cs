using CruiseDAL.DataObjects;
using CruiseManager.Core.Models;
using CruiseManager.Core.SetupModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class CruiseWizardView : Form, IPagingView
    {
        #region Fields

        private SalePage salePage = null;
        private CuttingUnitsPage cuttingUnitPage = null;
        private StrataPage strataPage = null;
        public SampleGroupPage sampleGroupPage = null;

        #endregion Fields



        #region CTor

        public CruiseWizardView()
        {
            //this.Presenter = Presenter;
            //InitializeData();
            InitializeComponent();
            InitializePages();

            this.DialogResult = DialogResult.Cancel;
        }

        #endregion CTor

        #region Properties

        public CruiseWizardPresenter Presenter { get; set; }

        public PageHost PageHost
        {
            get
            {
                return pageHost;
            }
            set
            {
                pageHost = value;
            }
        }

        #endregion Properties

        #region Initialization Methods

        private void InitializePages()
        {
            salePage = new SalePage("Sale", this) { Dock = DockStyle.Fill };
            pageHost.Add(salePage);

            cuttingUnitPage = new CuttingUnitsPage("CuttingUnits", this) { Dock = DockStyle.Fill };
            pageHost.Add(cuttingUnitPage);

            strataPage = new StrataPage("Strata", this) { Dock = DockStyle.Fill };
            pageHost.Add(strataPage);

            sampleGroupPage = new SampleGroupPage("SampleGroups", this) { Dock = DockStyle.Fill };
            pageHost.Add(sampleGroupPage);
        }

        #endregion Initialization Methods

        #region data update methods

        public void UpdateSale(SaleDO obj)
        {
            salePage.SaleDOBindingSource.DataSource = obj;
        }

        public void UpdateCuttingUnits(IList<CuttingUnitDO> list)
        {
            cuttingUnitPage.CuttingUnitBindingSource.DataSource = list;
            strataPage.CuttingUnitBindingSource.DataSource = list;
        }

        public void UpdateStrata(IList<StratumVM> list)
        {
            strataPage.StrataBindingSource.DataSource = list;
            sampleGroupPage.StratumBindingSource.DataSource = list;
        }

        public void UpdateSampleGroups(IList<SampleGroupDO> list)
        {
            sampleGroupPage.SampleGroupBindingSource.DataSource = list;
        }

        public void UpdateTreeDefaults(IList<TreeDefaultValueDO> list)
        {
            sampleGroupPage.TreeDefaultBindingSource.DataSource = list;
        }

        public void UpdateCruiseMethods(IList<string> list)
        {
            strataPage.UpdateCruiseMethods(list);
        }

        public void UpdateProduectCodes(IList<ProductCode> list)
        {
            sampleGroupPage.PrimaryProductBindingSource.DataSource = list;
            sampleGroupPage.SecondaryProductBindingSource.DataSource = list;
        }

        public void UpdateLoggingMethods(IList<LoggingMethod> list)
        {
            cuttingUnitPage.LoggingMethodBindingSource.DataSource = list;
        }

        public void UpdateUOMCodes(IList<UOMCode> list)
        {
            sampleGroupPage.UOMBindingSource.DataSource = list;
        }

        public void UpdateRegions(IList<CruiseManager.Core.SetupModels.Region> list)
        {
            salePage.RegionForestBindingSource.DataSource = list;
        }

        #endregion data update methods

        public void SetTemplatePathTextBox(string value, bool enable)
        {
            this.salePage.SetTemplatePathTextBox(value, enable);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Presenter.OnViewLoad();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Presenter.HandleViewClosing(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Handled == true) { return; }
            e.Handled = this.PageHost.CurrentPage.HandleKeypress(e.KeyData);
        }

        ////#region Paging Methods
        ////public void ShowCuttingUnits()
        ////{
        ////    Presenter.ShowCuttingUnits
        ////    pageHost.Display(cuttingUnitPage);
        ////}

        ////public void GoToStrata()
        ////{
        ////    pageHost.Display(strataPage);
        ////}

        ////public void GoToSampleGroups()
        ////{
        ////    pageHost.Display(sampleGroupPage);
        ////}

        ////public void GoToSampleGroups(StratumDO stratrum)
        ////{
        ////    sampleGroupPage.SetSelectedStratum(stratrum);
        ////    pageHost.Display(sampleGroupPage);
        ////}

        ////#endregion

        //#region Methods

        ////prompts the user with a save file diolog
        ////to get the path for the file to be created
        ////public string AskSavePath()
        ////{
        ////    saveFileDialog.DefaultExt = "cruise";
        ////    saveFileDialog.Filter = "Cruise files(*.cruise)|*.cruise";
        ////    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        ////    {
        ////        return saveFileDialog.FileName;
        ////    }
        ////    return null;
        ////}

        ////public string AskSetupPath()
        ////{
        ////    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        ////    {
        ////        SetupPath = openFileDialog1.FileName;
        ////        return SetupPath;
        ////    }
        ////    return null;
        ////}

        #region IPagingView Members

        public void Display(string Name)
        {
            this.PageHost.Display(Name);
        }

        public void Display(IPage Page)
        {
            this.PageHost.Display(Page);
        }

        #endregion IPagingView Members

        #region IView Members

        public void HandleLoad()
        {
        }

        #endregion IView Members
    }
}