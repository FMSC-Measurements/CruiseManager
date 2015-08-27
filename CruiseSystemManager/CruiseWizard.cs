using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseDAL; 
using CruiseDAL.DataObjects;
using CruiseSystemManager.CruiseWizardPages;
using System.Diagnostics;

namespace CruiseSystemManager
{
    public partial class CruiseWizard : Form
    {

        #region Fields
        //private DAL cruiseDAL = null;
        private DAL setupDAL = null;
        private SalePage salePage = null;
        private CuttingUnitsPage cuttingUnitPage = null;
        private StrataPage strataPage = null;
        private SampleGroupPage sampleGroupPage = null;


        #endregion 

        #region Constructor 
        public CruiseWizard()
        {
            InitializeData();
            InitializeComponent();
            InitializePages();
        }



        #endregion

        #region Properties 
        public string SetupPath { get; set; }
        public SaleDO Sale { get; set; }
        public BindingList<CuttingUnitDO> CuttingUnits { get; set; }
        public BindingList<StratumDO> Strata { get; set; }
        public BindingList<SampleGroupDO> SampleGroups { get; set; }
        public BindingList<TreeDefaultValueDO> TreeDefaults { get; set; }

        #endregion 

        #region Initialization Methods 
        private void InitializePages()
        {

            salePage = new SalePage(this);
            pageHost.Add(salePage);

            cuttingUnitPage = new CuttingUnitsPage(this);
            pageHost.Add(cuttingUnitPage);

            strataPage = new StrataPage(this);
            pageHost.Add(strataPage);

            sampleGroupPage = new SampleGroupPage(this);
            pageHost.Add(sampleGroupPage);

            this.DialogResult = DialogResult.Cancel;
        }


        private void InitializeData()
        {
            //initialize cruise data properties and create containers to hold our data
            Sale = new SaleDO();
            CuttingUnits = new BindingList<CuttingUnitDO>();
            Strata = new BindingList<StratumDO>();
            SampleGroups = new BindingList<SampleGroupDO>();
            TreeDefaults = new BindingList<TreeDefaultValueDO>();

            //fills curise data objects with dummy data
            //only called when in debug build mode 
            FillTestData();
        }



        #endregion 

        #region Paging Methods 
        public void GoToCuttingUnits()
        {
            pageHost.Display(cuttingUnitPage);
        }

        public void GoToStrata()
        {
            pageHost.Display(strataPage);
        }

        public void GoToSampleGroups()
        {
            pageHost.Display(sampleGroupPage);
        }

        public void GoToSampleGroups(StratumDO stratrum)
        {
            sampleGroupPage.SetSelectedStratum(stratrum);
            pageHost.Display(sampleGroupPage);
        }

        #endregion 


        #region Methods
        [Conditional("DEBUG")]
        private void FillTestData()
        {
            this.Sale.SaleNumber = "123456Test";
            this.Sale.Region = "RegionTest";
            this.Sale.Forest = "ForestTest";
            this.Sale.District = "DistrictTest";

            var num = 0;
            CuttingUnitDO newCU = null;
            while (num < 4)
            {
                newCU = new CuttingUnitDO();
                newCU.Code = "CodeTest" + num;
                newCU.Area = num;
                num++;

                this.CuttingUnits.Add(newCU);
            }

            num = 0;
            StratumDO newST = null;
            while (num < 4)
            {
                newST = new StratumDO();
                newST.Code = "TestCode" + num;
                newST.Method = "TestMethod" + num;
                newST.Tag = new List<SampleGroupDO>();
                var numSG = 0;
                while (numSG < 3)
                {
                    var newSG = new SampleGroupDO();
                    newSG.Code = "CodeTest" + numSG + num;
                    newSG.UOM = "UOMTest";
                    newSG.PrimaryProduct = (numSG + num).ToString();
                    newSG.CutLeave = "C";
                    (newST.Tag as List<SampleGroupDO>).Add(newSG);
                    numSG++;
                }

                num++;

                this.Strata.Add(newST);
            }

        }

        private void SetSetupDAL(string path)
        {
            setupDAL = new DAL(path);
        }

        public void LoadTDV()
        {
            if (!string.IsNullOrEmpty(SetupPath))
            {
                SetSetupDAL(SetupPath);
                var tdvService = new Services.TreeDefaultService(setupDAL);
                foreach (TreeDefaultValueDO t in tdvService.GetAll())
                {
                    TreeDefaults.Add(t);
                }
            }
        }

        //prompts the user with a save file diolog 
        //to get the path for the file to be created 
        public string AskSavePath()
        {
            saveFileDialog.DefaultExt = "cruise";
            saveFileDialog.Filter = "Cruise files(*.cruise)|*.cruise";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            return null;
        }

        public string AskSetupPath()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SetupPath = openFileDialog1.FileName;
                return SetupPath;
            }
            return null;
        }

        //cancels the cruise wizard diolog and discards all resorurces
        public void Cancel()
        {
            if (MessageBox.Show("Are you sure you want to cancel? Entered information will not be saved", "Warning", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        //saves information and exits diolog
        public void Finish()
        {
            var path = AskSavePath();
            if (path == null)
            {
                return;
            }
            var dal = new DAL(path, true);//create new file, overwirite if one exists 

            //save sale
            this.Sale.DAL = dal;
            this.Sale.Save();

            //save cutting units
            foreach (CuttingUnitDO c in this.CuttingUnits)
            {
                c.DAL = dal;
                c.Save();
            }

            //save TreeDefaults 
            foreach (TreeDefaultValueDO td in TreeDefaults)
            {
                td.DAL = dal;
                td.Save();
            }

            //save strata and sample groups
            foreach (StratumDO s in this.Strata)
            {
                s.DAL = dal;
                s.Save();
                s.CuttingUnits.Save();

                //set the strata forgen key on all sample groups and save
                foreach (SampleGroupDO sg in s.Tag as List<SampleGroupDO>)
                {
                    sg.Stratum = s;
                    sg.DAL = dal;
                    sg.Save();
                    sg.TreeDefaultValues.Save();
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        #endregion



       
    }
}
