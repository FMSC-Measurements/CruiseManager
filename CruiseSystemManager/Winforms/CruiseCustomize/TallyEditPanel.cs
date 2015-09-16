using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CruiseDAL.DataObjects;

namespace CSM.Winforms.CruiseCustomize
{
    public delegate void TallyModeChangedEventHandler(object sender);
    public delegate TallyDO GetTallyEventHandler(SampleGroupDO sg, TreeDefaultValueDO tdv);
    public delegate void SelectedTallyChangedEventHandler(SampleGroupDO sg, TreeDefaultValueDO tdv, TallyDO tally);
    public delegate void TallyItemChangedEventHandler(TallyDO tally);
    public delegate TallyDO AddNewTallyEventHandler();


    public partial class TallyEditPanel : UserControl
    {
        private bool _changingSampleGroup = false;
        private bool _changingCurrTally = false;

        private TreeDefaultValueDO _currTDV; 

        public TallyEditPanel()
        {
            InitializeComponent();

            //this._hotKeyCB.Items.AddRange(CSM.Utility.R.Strings.HOTKEYS);
            this._behaviorCB.Items.AddRange(CSM.Utility.R.Strings.INDICATOR_TYPES);
        }

        private bool _allowTallyBySp = true; 
        public bool AllowTallyBySpecies 
        {
            get { return _allowTallyBySp; }
            set
            {
                _allowTallyBySp = value;
                this._tallyBySpRB.Enabled = value;
            }
        }

        private bool _allowTallyBySG = true;
        public bool AllowTallyBySG
        {
            get { return _allowTallyBySG; }
            set
            {
                _allowTallyBySG = value;
                this._tallyBySGRB.Enabled = value;
            }
        }

        public void SetHotKeys(string[] hotkeys)
        {
            this._hotKeyCB.Items.Clear();
            //if hotkeys null use empty string array
            this._hotKeyCB.Items.AddRange(hotkeys ?? new String[0]);
        }

        private TallySetupSampleGroup _sampleGroup;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TallySetupSampleGroup SampleGroup 
        {
            get { return _sampleGroup; }
            set
            {
                if (_sampleGroup == value) { return; }

                _sampleGroup = value;
                _changingSampleGroup = true;
                OnTallyModeChanged();
                _changingSampleGroup = false;
            }
        }

        private List<TallyVM> _tallyPresets;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TallyVM> TallyPresets 
        {
            get { return _tallyPresets; }
            set
            {
                _BS_tallyPresets.DataSource = value;
                _tallyPresets = value;
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CruiseDAL.Enums.TallyMode TallyMode
        {
            get 
            {
                if (_sampleGroup == null) { return CruiseDAL.Enums.TallyMode.Unknown; }
                return _sampleGroup.TallyMethod; 
            }
            set
            {
                if (SampleGroup.TallyMethod == value) { return; }
                SampleGroup.TallyMethod = value;
                OnTallyModeChanged();
            }
        }

        

        private TallyDO _currentTally;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TallyDO CurrentTally
        {
            get { return _currentTally; }
            set
            {
                if (_currentTally == value) { return; }
                _currentTally = value;
                _changingCurrTally = true;
                if (value != null)
                {
                    int index = _BS_tallyPresets.IndexOf(value);
                    _BS_tallyPresets.Position = index;
                    if (index == -1)
                    {
                        _presetCB.Text = "";
                    }
                    if (string.IsNullOrEmpty(value.Hotkey))
                    {
                        _hotKeyCB.Text = "";
                    }
                    if (string.IsNullOrEmpty(value.IndicatorType))
                    {
                        _behaviorCB.Text = "";
                    }
                    _BS_CurTally.DataSource = value;
                    
                    
                }
                else
                {
                    //_BS_CurTally.DataSource = null;
                    //_BS_tallyPresets.Position = -1;
                }
                _changingCurrTally = false;
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (this.Enabled == false)
            {
                _tallyBySGRB.Checked = false;
                _tallyBySpRB.Checked = false;
                _dontTallyRB.Checked = false;
            }
        }

        protected void OnTallyModeChanged()
        {
            if ((this.TallyMode & CruiseDAL.Enums.TallyMode.Locked) == CruiseDAL.Enums.TallyMode.Locked)
            {
                _tallyBySGRB.Enabled = false;
                _tallyBySpRB.Enabled = false;
                _dontTallyRB.Enabled = false;
            }
            else
            {
                _tallyBySGRB.Enabled = this.AllowTallyBySG;
                _tallyBySpRB.Enabled = this.AllowTallyBySpecies;
                _dontTallyRB.Enabled = true;
            }

            if ((this.TallyMode & CruiseDAL.Enums.TallyMode.BySampleGroup) == CruiseDAL.Enums.TallyMode.BySampleGroup)
            {
                _contentPanel.Enabled = true;
                _tallyBySGRB.Checked = true;
                _tallyBySpRB.Checked = false;
                _dontTallyRB.Checked = false;
                _speciesGB.Enabled = false;
                _BS_SPList.DataSource = null;
                CurrentTally = SampleGroup.SgTallie;

            }
            else if ((this.TallyMode & CruiseDAL.Enums.TallyMode.BySpecies) == CruiseDAL.Enums.TallyMode.BySpecies)
            {
                _contentPanel.Enabled = true;
                _tallyBySGRB.Checked = false;
                _tallyBySpRB.Checked = true;
                _dontTallyRB.Checked = false;
                _speciesGB.Enabled = true;
                if (SampleGroup.TreeDefaultValues.IsPopulated == false)
                    { SampleGroup.TreeDefaultValues.Populate(); }
                _BS_SPList.DataSource = SampleGroup.TreeDefaultValues;
            }
            else if ((this.TallyMode & CruiseDAL.Enums.TallyMode.None) == CruiseDAL.Enums.TallyMode.None)
            {
                _contentPanel.Enabled = false;
                _tallyBySGRB.Checked = false;
                _tallyBySpRB.Checked = false;
                _dontTallyRB.Checked = true;
                _speciesGB.Enabled = false;
                //_speciesLB.DataSource = null;
                _BS_SPList.DataSource = null;
            }

            if (!_changingSampleGroup)
            {
                SampleGroup.HasTallyEdits = true;
            }

            //if (TallyModeChanged != null && !_changingSampleGroup)
            //{
            //    TallyModeChanged(this);
            //}
        }


        private void _BS_tallyPresets_CurrentChanged(object sender, EventArgs e)
        {
            if (_changingCurrTally == true) { return; }
            if (this.SampleGroup == null) { return; }
            this.SampleGroup.HasTallyEdits = true;
            
            TallyVM tally = _BS_tallyPresets.Current as TallyVM;
            if (this._currTDV != null)
            {
                this.SampleGroup.Tallies[_currTDV] = tally;
            }
            else
            {
                this.SampleGroup.SgTallie = tally;
            }

            CurrentTally = tally;
        }


        private void _addTallyButton_Click(object sender, EventArgs e)
        {
            //TallyDO tally = OnAddNewTally();
            //if (tally != null)
            //{
            //    CurrentTally = tally;
            //}
        }


        private void _BS_SPList_CurrentChanged(object sender, EventArgs e)
        {
            _currTDV = _BS_SPList.Current as TreeDefaultValueDO;
            if (_currTDV == null) { return; }

            TallyDO tally = this.SampleGroup.Tallies[_currTDV];
            CurrentTally = tally;
        }
        private void _tallyBySGRB_CheckedChanged(object sender, EventArgs e)
        {
            if (!_changingSampleGroup && _tallyBySGRB.Checked == true)
            {
                this.TallyMode = (this.TallyMode & CruiseDAL.Enums.TallyMode.Locked) | CruiseDAL.Enums.TallyMode.BySampleGroup;
            }
        }

        private void _dontTallyRB_CheckedChanged(object sender, EventArgs e)
        {
            if (!_changingSampleGroup && _dontTallyRB.Checked == true)
            {
                this.TallyMode = (this.TallyMode & CruiseDAL.Enums.TallyMode.Locked) | CruiseDAL.Enums.TallyMode.None;
            }
        }

        private void _tallyBySpRB_CheckedChanged(object sender, EventArgs e)
        {
            if (!_changingSampleGroup && _tallyBySpRB.Checked == true)
            {
                this.TallyMode = (this.TallyMode & CruiseDAL.Enums.TallyMode.Locked) | CruiseDAL.Enums.TallyMode.BySpecies;
            }
        }

        private void _BS_CurTally_CurrentItemChanged(object sender, EventArgs e)
        {
            if (!_changingSampleGroup)
            {
                this.SampleGroup.HasTallyEdits = true;
            }
        }


        internal void EndEdits()
        {
            this._BS_CurTally.EndEdit();
        }
    }
}
