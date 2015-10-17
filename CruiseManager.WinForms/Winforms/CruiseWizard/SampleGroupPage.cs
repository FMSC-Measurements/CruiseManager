using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using CruiseManager.Core.Models;
using CruiseManager.Core.SetupModels;
using CruiseManager.Core.App;

namespace CruiseManager.WinForms.CruiseWizard
{
    public partial class SampleGroupPage : UserControl, IPage
    {
        #region Properties
        public CruiseWizardPresenter Presenter { get { return MasterView.Presenter; } }
        public CruiseWizardView MasterView { get; set; }
        
        public StratumVM CurrentStratum
        {
            get
            {
                return StratumBindingSource.Current as StratumVM;
            }
            set
            {
                StratumBindingSource.Position = StratumBindingSource.IndexOf(value);
            }
        }

        private SampleGroupDO CurrentSampleGroup { get { return SampleGroupBindingSource.Current as SampleGroupDO; } }
        #endregion

        #region Ctor
        public SampleGroupPage(string Name,CruiseWizardView MasterView)
        {
            InitializeComponent();
            base.Name = Name;
            this.MasterView = MasterView;
            BindingNavigatorItemComboBox.ComboBox.DataSource = StratumBindingSource;
            BindingNavigatorItemComboBox.ComboBox.DisplayMember = "Code";
            BindingNavigatorItemComboBox.ComboBox.FormattingEnabled = true;
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeBindings();
        }
        

        #region Initialization Methods
        private void InitializeBindings()
        {
            PrimaryProductBindingSource.DataSource = Presenter.ProductCodes;
            SecondaryProductBindingSource.DataSource = Presenter.ProductCodes;
            UOMBindingSource.DataSource = Presenter.UOMCodes;
            TreeDefaultBindingSource.DataSource = Presenter.TreeDefaults;
            StratumBindingSource.DataSource = Presenter.Strata;
            

        }
        #endregion


        #region Click events
        private void StrataButton_Click(object sender, EventArgs e)
        {
            Presenter.ShowStratum();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MasterView.Close();
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            Presenter.Finish();
        }

        #endregion

        private void StratumBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentStratum != null)
            {
                _stratumDiscriptionLBL.Text = string.Format("{0}: {1} - {2}", CurrentStratum.Code, CurrentStratum.Method, CurrentStratum.Description);

                //grab the list of sample groups atatched to the selected stratum 
                IList<SampleGroupDO> sgList = CurrentStratum.SampleGroups;
                if (sgList != null)
                {
                    SampleGroupBindingSource.DataSource = sgList;
                }
                if (SampleGroupBindingSource.Count == 0)
                {
                    Presenter.GetNewSampleGroup(CurrentStratum,(SampleGroupDO) SampleGroupBindingSource.AddNew());
                }


                if (SampleGroupDO.CanEnableBigBAF(CurrentStratum) == false)
                {
                    this._bigBAFTB.TextBox.Text = "0";
                    this._bigBAFTB.TextBox.Enabled = false;
                }
                else
                {
                    this._bigBAFTB.TextBox.Enabled = true;
                }

                if (SampleGroupDO.CanEnableFrequency(CurrentStratum) == false)
                {
                    _FreqTB.TextBox.Text = "0";
                    _FreqTB.TextBox.Enabled = false;
                }
                else
                {
                    _FreqTB.TextBox.Enabled = true;
                }

                if (SampleGroupDO.CanEnableKZ(CurrentStratum) == false)
                {
                    _kzTB.TextBox.Text = "0";
                    _kzTB.TextBox.Enabled = false;

                    _minKPITB.TextBox.Text = "0";
                    _minKPITB.TextBox.Enabled = false;
                    

                    _maxKPITB.TextBox.Text = "0";
                    _maxKPITB.TextBox.Enabled = false;
                }
                else
                {
                    _kzTB.TextBox.Enabled = true;
                    _minKPITB.TextBox.Enabled = true;
                    _maxKPITB.TextBox.Enabled = true;
                }
                if (SampleGroupDO.CanEnableIFreq(CurrentStratum) == false)
                {
                    _IFreqTB.TextBox.Text = "0";
                    _IFreqTB.TextBox.Enabled = false;
                }
                else
                {
                    _IFreqTB.TextBox.Enabled = true;
                }
            }
            else
            {
                SampleGroupBindingSource.DataSource = null;
            }
        }

        
        private void SampleGroupBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentSampleGroup == null)
            {
                this.panel3.Enabled = false;
                TreeDefaultGridView.SelectedItems = null;
                return;
            }
            else
            {
                this.panel3.Enabled = true;
                this.CodeTextBox.TextBox.Focus();
            }
            TreeDefaultGridView.SelectedItems = CurrentSampleGroup.TreeDefaultValues;
        }


        public void SetSelectedStratum(StratumDO stratrum)
        {
            var index = StratumBindingSource.IndexOf(stratrum);
            StratumBindingSource.Position = index;
        }

        private void ProductCodeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (Presenter == null || CurrentSampleGroup == null) { return; }
            string selectedPP = PrimaryProductComboBox.SelectedValue as string;// get selected primary product  
            var visableTDV = CurrentSampleGroup.TreeDefaultValues.ToList();


            visableTDV.AddRange(from tdv in Presenter.TreeDefaults
                                where visableTDV.Contains(tdv) == false && tdv.PrimaryProduct == selectedPP
                                select tdv);
            TreeDefaultBindingSource.DataSource = visableTDV;
        }

        private void PrimaryProductComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateTDVList();
        }


        protected void UpdateTDVList()
        {
            if (PrimaryProductBindingSource.Current == null) { return; }

            string productCode = ((ProductCode)PrimaryProductBindingSource.Current).Code;
            var visableTDV = (from tdv in Presenter.TreeDefaults
                              where tdv.PrimaryProduct == productCode
                              select tdv).ToList();
            TreeDefaultBindingSource.DataSource = visableTDV;
        }


        private void SampleGroupBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //TODO confusing;
            //its not clear where the samplegroup is being added to the stratum's sampleGroup list;
            //however the sampelgroup does get added because the stratum's samplegroup list is bound to SampleGroupBindingSource
            //
            e.NewObject = Presenter.GetNewSampleGroup(CurrentStratum, null);
        }

        private void _newSubPopBTN_Click(object sender, EventArgs e)
        {
            //TreeDefaultValueDO newTDV = Presenter.GetNewTreeDefaultValue();
            //FormAddTreeDefault dialog = new FormAddTreeDefault(Presenter.ProductCodes);
            //if (dialog.ShowDialog(newTDV) == DialogResult.OK)
            //{
            //    newTDV.Save();
            //    this.Presenter.TreeDefaults.Add(newTDV);
            //    UpdateTDVList();

            //    int i = this.TreeDefaultBindingSource.IndexOf(newTDV);
            //    if (i >= 0)
            //    {
            //        this.TreeDefaultBindingSource.Position = i;
            //    }
            //}

            TreeDefaultValueDO newTDV = new TreeDefaultValueDO(this.Presenter.Database);
            newTDV = this.Presenter.WindowPresenter.ShowAddTreeDefault(newTDV);
            if(newTDV != null)
            {
                this.Presenter.TreeDefaults.Add(newTDV);
                this.UpdateTDVList();

                int i = this.TreeDefaultBindingSource.IndexOf(newTDV);
                if (i >= 0)
                {
                    this.TreeDefaultBindingSource.Position = i;
                }

            }
        }

        private void _editSubPopBtn_Click(object sender, EventArgs e)
        {
            //TreeDefaultValueDO tdv = this.TreeDefaultBindingSource.Current as TreeDefaultValueDO;
            //if (tdv == null) { return; }
            //TreeDefaultValueDO temp = new TreeDefaultValueDO(tdv);
            //ApplicationState appState =  ApplicationState.GetHandle();
            //this.Presenter.WindowPresenter.ShowAddTreeDefult();

            //CruiseManager.Winforms.CruiseWizard.FormAddTreeDefault dialog = new FormAddTreeDefault(SetupService.Instance.GetProductCodes());
            //if (dialog.ShowDialog(tdv) == DialogResult.OK)
            //{
            //    tdv.Save();
            //}
            //else
            //{
            //    tdv.SetValues(temp);
            //}

            var tdv = this.TreeDefaultBindingSource.Current as TreeDefaultValueDO;
            if(tdv != null)
            {
                this.Presenter.WindowPresenter.ShowEditTreeDefault(tdv);
            }
        }



        #region IPage Members


        public bool HandleKeypress(System.Windows.Forms.Keys key)
        {
            if (key == System.Windows.Forms.Keys.F1)
            {
                SampleGroupBindingSource.AddNew();
                this.CodeTextBox.TextBox.Focus();
                return true;
            }
            return false;
        }

        #endregion

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            SampleGroupDO curSG = this.CurrentSampleGroup;
            if (curSG == null) { return; }
            this.SampleGroupBindingSource.Remove(curSG);
            this.Presenter.DeleteSampleGroup(curSG);
        }
    }

        
}
