using CruiseDAL.DataObjects;
using CruiseManager.Core.Models;
using CruiseManager.Core.SetupModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

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

        #endregion Properties

        #region Ctor

        public SampleGroupPage(string Name, CruiseWizardView MasterView)
        {
            InitializeComponent();
            base.Name = Name;
            this.MasterView = MasterView;
            BindingNavigatorItemComboBox.ComboBox.DataSource = StratumBindingSource;
            BindingNavigatorItemComboBox.ComboBox.DisplayMember = "Code";
            BindingNavigatorItemComboBox.ComboBox.FormattingEnabled = true;
        }

        #endregion Ctor

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeBindings();
            StratumBindingSource_CurrentChanged(null, null);
        }

        #region Initialization Methods

        private void InitializeBindings()
        {
            PrimaryProductBindingSource.DataSource = Presenter.ProductCodes;
            SecondaryProductBindingSource.DataSource = Presenter.SecondaryProductCodes.ToList();
            UOMBindingSource.DataSource = Presenter.UOMCodes;
            //TreeDefaultBindingSource.DataSource = Presenter.TreeDefaults;
            StratumBindingSource.DataSource = Presenter.Strata;
        }

        #endregion Initialization Methods

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

        #endregion Click events

        private void StratumBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentStratum != null)
            {
                _stratumDiscriptionLBL.Text = string.Format("{0}: {1} - {2}", CurrentStratum.Code, CurrentStratum.Method, CurrentStratum.Description);

                //grab the list of sample groups attached to the selected stratum
                IList<SampleGroupDO> sgList = CurrentStratum.SampleGroups;
                if (sgList != null)
                {
                    SampleGroupBindingSource.DataSource = sgList;
                }
                if (SampleGroupBindingSource.Count == 0)
                {
                    Presenter.GetNewSampleGroup(CurrentStratum, (SampleGroupDO)SampleGroupBindingSource.AddNew());
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
            panel3.Enabled = CurrentSampleGroup != null;
            UpdateTreeDefaults();
            TreeDefaultGridView.SelectedItems = CurrentSampleGroup?.TreeDefaultValues;

            if (CurrentSampleGroup != null)
            {
                CodeTextBox.TextBox.Focus();
            }
        }

        private void ProductCodeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //UpdateTreeDefaults();
        }

        protected void UpdateTreeDefaults()
        {
            if (CurrentSampleGroup == null) { return; }
            var selectedPP = CurrentSampleGroup.PrimaryProduct;

            TreeDefaultBindingSource.DataSource = Presenter.TreeDefaults.Where(x => x.PrimaryProduct == selectedPP)
                .Union(CurrentSampleGroup.TreeDefaultValues).ToList();
        }

        private void PrimaryProductComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateTreeDefaults();
        }

        //protected void UpdateTDVList()
        //{
        //    if (PrimaryProductBindingSource.Current == null) { return; }

        //    string productCode = ((ProductCode)PrimaryProductBindingSource.Current).Code;
        //    var visableTDV = (from tdv in Presenter.TreeDefaults
        //                      where tdv.PrimaryProduct == productCode
        //                      select tdv).ToList();
        //    TreeDefaultBindingSource.DataSource = visableTDV;
        //}

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
            TreeDefaultValueDO newTDV = new TreeDefaultValueDO(this.Presenter.Database);
            newTDV = this.Presenter.WindowPresenter.ShowAddTreeDefault(newTDV);
            if (newTDV != null)
            {
                this.Presenter.TreeDefaults.Add(newTDV);
                this.UpdateTreeDefaults();

                int i = this.TreeDefaultBindingSource.IndexOf(newTDV);
                if (i >= 0)
                {
                    this.TreeDefaultBindingSource.Position = i;
                }
            }
        }

        private void _editSubPopBtn_Click(object sender, EventArgs e)
        {
            var tdv = this.TreeDefaultBindingSource.Current as TreeDefaultValueDO;
            if (tdv != null)
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

        #endregion IPage Members

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SampleGroupDO curSG = this.CurrentSampleGroup;
            if (curSG == null) { return; }
            this.SampleGroupBindingSource.Remove(curSG);
            this.Presenter.DeleteSampleGroup(curSG);
        }
    }
}