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

        #region CurrentSampleGroup

        SampleGroupDO _currentSampleGroup;

        private SampleGroupDO CurrentSampleGroup
        {
            get { return _currentSampleGroup; }
            set
            {
                if (_currentSampleGroup == value) { return; }
                OnCurrentSampleGroupChanging();
                _currentSampleGroup = value;
                OnCurrentSampleGroupChanged();
            }
        }

        private void OnCurrentSampleGroupChanged()
        {
            if (_currentSampleGroup != null)
            {
                _currentSampleGroup.PropertyChanged += _currentSampleGroup_PropertyChanged;

                CodeTextBox.Focus();
            }

            panel3.Enabled = CurrentSampleGroup != null;
            UpdateTreeDefaults();
            TreeDefaultGridView.SelectedItems = CurrentSampleGroup?.TreeDefaultValues;
        }

        private void OnCurrentSampleGroupChanging()
        {
            if (_currentSampleGroup != null)
            {
                _currentSampleGroup.PropertyChanged -= _currentSampleGroup_PropertyChanged;
            }
        }

        private void _currentSampleGroup_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SampleGroupDO.PrimaryProduct))
            {
                OnPrimaryProductChanged();
            }
        }

        #endregion CurrentSampleGroup

        private void OnPrimaryProductChanged()
        {
            CurrentSampleGroup.TreeDefaultValues.Clear();
            UpdateTreeDefaults();
        }

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
                    _bigBAFTB.Text = "0";
                    _bigBAFTB.Enabled = false;
                }
                else
                {
                    _bigBAFTB.Enabled = true;
                }

                if (SampleGroupDO.CanEnableFrequency(CurrentStratum) == false)
                {
                    _FreqTB.Text = "0";
                    _FreqTB.Enabled = false;
                    _samplingPNL.Visible = false;
                }
                else
                {
                    _FreqTB.Enabled = true;
                    _samplingPNL.Visible = true;
                }

                if (SampleGroupDO.CanEnableKZ(CurrentStratum) == false)
                {
                    _kzTB.Text = "0";
                    _kzTB.Enabled = false;

                    _minKPITB.Text = "0";
                    _minKPITB.Enabled = false;

                    _maxKPITB.Text = "0";
                    _maxKPITB.Enabled = false;

                    _threePSamplingPNL.Visible = false;
                }
                else
                {
                    _kzTB.Enabled = true;
                    _minKPITB.Enabled = true;
                    _maxKPITB.Enabled = true;

                    _threePSamplingPNL.Visible = true;
                }
                if (SampleGroupDO.CanEnableIFreq(CurrentStratum) == false)
                {
                    _IFreqTB.Text = "0";
                    _IFreqTB.Enabled = false;
                }
                else
                {
                    _IFreqTB.Enabled = true;
                }
            }
            else
            {
                SampleGroupBindingSource.DataSource = null;
            }
        }

        private void SampleGroupBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CurrentSampleGroup = SampleGroupBindingSource.Current as SampleGroupDO;
        }

        protected void UpdateTreeDefaults()
        {
            if (CurrentSampleGroup == null) { return; }
            var selectedPP = CurrentSampleGroup.PrimaryProduct;

            TreeDefaultBindingSource.DataSource = Presenter.TreeDefaults.Where(x => x.PrimaryProduct == selectedPP).ToList();
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
            var newTDV = new TreeDefaultValueDO(Presenter.Database);
            newTDV = Presenter.WindowPresenter.ShowAddTreeDefault(newTDV);
            if (newTDV != null)
            {
                Presenter.TreeDefaults.Add(newTDV);
                UpdateTreeDefaults();

                int i = TreeDefaultBindingSource.IndexOf(newTDV);
                if (i >= 0)
                {
                    TreeDefaultBindingSource.Position = i;
                }
            }
        }

        private void _editSubPopBtn_Click(object sender, EventArgs e)
        {
            var tdv = TreeDefaultBindingSource.Current as TreeDefaultValueDO;
            if (tdv != null)
            {
                Presenter.WindowPresenter.ShowEditTreeDefault(tdv);
            }
        }

        #region IPage Members

        public bool HandleKeypress(System.Windows.Forms.Keys key)
        {
            if (key == System.Windows.Forms.Keys.F1)
            {
                SampleGroupBindingSource.AddNew();
                CodeTextBox.Focus();
                return true;
            }
            return false;
        }

        #endregion IPage Members

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            SampleGroupDO curSG = CurrentSampleGroup;
            if (curSG == null) { return; }
            SampleGroupBindingSource.Remove(curSG);
            Presenter.DeleteSampleGroup(curSG);
        }
    }
}