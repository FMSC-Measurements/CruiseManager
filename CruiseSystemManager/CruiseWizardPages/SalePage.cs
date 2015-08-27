using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CruiseDAL.DataObjects;

namespace CruiseSystemManager.CruiseWizardPages
{
    public partial class SalePage : UserControl
    {
        #region Constants 

        String[] purposeValues = new string[] { "1", "2", "3", "..." };

        #endregion

        #region Constructor

        public SalePage(CruiseWizard Owner)
        {
            this.Owner = Owner;
            InitializeComponent();
            InitializeBindings();
            InitializePurposeComboBox();

            
        }

        #endregion

        #region Properties 
        public CruiseWizard Owner { get; set; }
        #endregion 

        #region Initialization Methods
        private void InitializeBindings()
        {
            SetupPathTextBox.DataBindings.Add("Text", Owner, "SetupPath");
            SaleNameTextBox.DataBindings.Add("Text", Owner.Sale, "Name");
            SaleNumberTextBox.DataBindings.Add("Text", Owner.Sale, "SaleNumber");
            SaleRegionTextBox.DataBindings.Add("Text", Owner.Sale, "Region");
            SaleForestTextBox.DataBindings.Add("Text", Owner.Sale, "Forest");
            SaleDistrictTextBox.DataBindings.Add("Text", Owner.Sale, "District");

            PurposeComboBox.DataBindings.Add("SelectedItem", Owner.Sale, "Purpose");
        }

        private void InitializePurposeComboBox()
        {
            PurposeComboBox.Items.AddRange(Enum.GetNames(typeof(SaleDO.PurposeType)));
        }

        #endregion

        #region Button Events
        private void NextButton_Click(object sender, EventArgs e)
        {
            var errorMessage = new StringBuilder();
            var hasErrors = false;
            if (String.IsNullOrEmpty(Owner.Sale.SaleNumber))
            {
                errorMessage.AppendLine("Sale Name can not be empty");
                hasErrors = true;
            }
            if (string.IsNullOrEmpty(Owner.Sale.Region))
            {
                errorMessage.AppendLine("Region can not be empty");
                hasErrors = true;
            }
            if (string.IsNullOrEmpty(Owner.Sale.Forest))
            {
                errorMessage.AppendLine("Forest can not be empty");
                hasErrors = true;

            }
            if (string.IsNullOrEmpty(Owner.Sale.District))
            {
                errorMessage.AppendLine("District can not be empty");
                hasErrors = true;
            }
            if (hasErrors)
            {
                MessageBox.Show(errorMessage.ToString(), "Warning", MessageBoxButtons.OK);
                return;
            }

            Owner.LoadTDV();//call back to owner and tell it to read the Tree Default values from the setup file
            Owner.GoToCuttingUnits();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Owner.Cancel();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            SetupPathTextBox.Text = Owner.AskSetupPath();
        }
        #endregion



      

        



    }
}
