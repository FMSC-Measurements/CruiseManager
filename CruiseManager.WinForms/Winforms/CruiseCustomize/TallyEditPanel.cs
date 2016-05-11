using CruiseDAL.DataObjects;
using CruiseManager.Core.Constants;
using CruiseManager.Core.CruiseCustomize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    //public delegate void TallyModeChangedEventHandler(object sender);

    //public delegate TallyDO GetTallyEventHandler(SampleGroupDO sg, TreeDefaultValueDO tdv);

    //public delegate void SelectedTallyChangedEventHandler(SampleGroupDO sg, TreeDefaultValueDO tdv, TallyDO tally);

    //public delegate void TallyItemChangedEventHandler(TallyDO tally);

    //public delegate TallyDO AddNewTallyEventHandler();

    public partial class TallyEditPanel : UserControl
    {
        private static readonly TreeDefaultValueDO[] EMPTY_SPECIES_LIST = new TreeDefaultValueDO[0];
        private bool _changingSampleGroup = false;
        private bool _changingCurrTally = false;

        private TreeDefaultValueDO _currTDV;

        public TallyEditPanel()
        {
            InitializeComponent();

            this._behaviorCB.Items.AddRange(Strings.INDICATOR_TYPES);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<string, string[]> GetHotKeys { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool AllowTallyBySpecies
        {
            get { return this._tallyBySpRB.Enabled; }
            set
            {
                this._tallyBySpRB.Enabled = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool AllowTallyBySG
        {
            get { return this._tallyBySGRB.Enabled; }
            set
            {
                this._tallyBySGRB.Enabled = value;
            }
        }

        private TallyDO _currentTally;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TallyDO CurrentTally
        {
            get { return _currentTally; }
            protected set
            {
                if (_currentTally == value) { return; }
                _currentTally = value;
                _changingCurrTally = true;
                if (value == null || string.IsNullOrEmpty(value.Hotkey))
                {
                    _hotKeyCB.Text = "";
                }
                else
                {
                    _hotKeyCB.Text = value.Hotkey;
                }
                if (value == null || string.IsNullOrEmpty(value.IndicatorType))
                {
                    _behaviorCB.Text = "";
                }
                //if (value != null)
                //{
                //    //int index = _BS_tallyPresets.IndexOf(value);
                //    //_BS_tallyPresets.Position = index;
                //    //if (index == -1)
                //    //{
                //    //    _presetCB.Text = "";
                //    //}
                //}

                _BS_CurTally.DataSource = (object)value ?? (object)typeof(TallyDO);

                _changingCurrTally = false;
            }
        }

        private TallySetupSampleGroup _currentSampleGroup;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TallySetupSampleGroup CurrentSampleGroup
        {
            get { return _currentSampleGroup; }
            set
            {
                if (_currentSampleGroup == value) { return; }

                _currentSampleGroup = value;
                _changingSampleGroup = true;
                OnSampleGroupChanged();
                _changingSampleGroup = false;
            }
        }


        public IList<TallySetupSampleGroup> SampleGroups
        {
            get { return _BS_sampleGroups.DataSource as IList<TallySetupSampleGroup>; }
            set { _BS_sampleGroups.DataSource = value ?? new TallySetupSampleGroup[0]; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CruiseDAL.Enums.TallyMode TallyMode
        {
            get
            {
                if (_currentSampleGroup == null) { return CruiseDAL.Enums.TallyMode.Unknown; }
                return _currentSampleGroup.TallyMethod;
            }
            protected set
            {
                if (CurrentSampleGroup.TallyMethod == value) { return; }
                CurrentSampleGroup.TallyMethod = value;
                OnTallyModeChanged();
            }
        }

        internal void EndEdits()
        {
            this._BS_CurTally.EndEdit();
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

        protected void OnSampleGroupChanged()
        {
            if (this.CurrentSampleGroup != null)
            {
                if (this.CurrentSampleGroup.IsTallyModeLocked)
                {
                    _tallyBySGRB.Enabled = false;
                    _tallyBySpRB.Enabled = false;
                    _dontTallyRB.Enabled = false;
                }
                else
                {
                    _tallyBySGRB.Enabled = this.CurrentSampleGroup.CanTallyBySG;
                    _tallyBySpRB.Enabled = this.CurrentSampleGroup.CanTallyBySpecies;
                    _dontTallyRB.Enabled = true;
                }

                OnTallyModeChanged();
            }
            else
            {
                this._GB_topLevelContainer.Enabled = false;
                _tallyBySGRB.Checked = false;
                _tallyBySpRB.Checked = false;
                _dontTallyRB.Checked = false;
                _BS_SPList.DataSource = EMPTY_SPECIES_LIST;
            }
        }

        protected void OnTallyModeChanged()
        {
            if ((this.TallyMode & CruiseDAL.Enums.TallyMode.BySampleGroup) == CruiseDAL.Enums.TallyMode.BySampleGroup)
            {
                _GB_tallyFields.Enabled = true;
                _tallyBySGRB.Checked = true;
                _tallyBySpRB.Checked = false;
                _dontTallyRB.Checked = false;
                _speciesGB.Enabled = false;
                _BS_SPList.DataSource = EMPTY_SPECIES_LIST;
                CurrentTally = CurrentSampleGroup.SgTallie;
            }
            else if ((this.TallyMode & CruiseDAL.Enums.TallyMode.BySpecies) == CruiseDAL.Enums.TallyMode.BySpecies)
            {
                _GB_tallyFields.Enabled = true;
                _tallyBySGRB.Checked = false;
                _tallyBySpRB.Checked = true;
                _dontTallyRB.Checked = false;
                _speciesGB.Enabled = true;
                _BS_SPList.DataSource = CurrentSampleGroup.TreeDefaultValues;
            }
            else if ((this.TallyMode & CruiseDAL.Enums.TallyMode.None) == CruiseDAL.Enums.TallyMode.None)
            {
                _GB_tallyFields.Enabled = false;
                _tallyBySGRB.Checked = false;
                _tallyBySpRB.Checked = false;
                _dontTallyRB.Checked = true;
                _speciesGB.Enabled = false;
                _BS_SPList.DataSource = EMPTY_SPECIES_LIST;
                CurrentTally = null;
            }

            if (!_changingSampleGroup)
            {
                CurrentSampleGroup.HasTallyEdits = true;
            }

            //if (TallyModeChanged != null && !_changingSampleGroup)
            //{
            //    TallyModeChanged(this);
            //}
        }

        public void SetHotKeys(string[] hotkeys)
        {
            this._hotKeyCB.Items.Clear();
            //if hotkeys null use empty string array
            this._hotKeyCB.Items.AddRange(hotkeys ?? new String[0]);
        }

        #region Event Handlers

        private void _BS_SPList_CurrentChanged(object sender, EventArgs e)
        {
            _currTDV = _BS_SPList.Current as TreeDefaultValueDO;
            if (_currTDV == null) { return; }

            TallyDO tally = this.CurrentSampleGroup.Tallies[_currTDV];
            CurrentTally = tally;
        }

        private void _BS_sampleGroups_CurrentChanged(object sender, EventArgs e)
        {
            var curSG = _BS_sampleGroups.Current as TallySetupSampleGroup;

            CurrentSampleGroup = curSG;
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
            if (!_changingSampleGroup && !_changingCurrTally)
            {
                this.CurrentSampleGroup.HasTallyEdits = true;
            }
        }

        private void _hotKeyCB_TextChanged(object sender, EventArgs e)
        {
            if (_changingCurrTally || this.CurrentTally == null)
            {
                return;
            }
            this.CurrentTally.Hotkey = _hotKeyCB.Text;
        }

        protected void _hotKeyCB_DropedDown(object sender, EventArgs e)
        {
            if (GetHotKeys != null)
            {
                var curHotKey = CurrentTally.Hotkey;

                var avalibleHotKeys = GetHotKeys(curHotKey);
                //this._hotKeyCB.DataSource = avalibleHotKeys;
                this._hotKeyCB.Items.Clear();
                this._hotKeyCB.Items.AddRange(avalibleHotKeys);
            }
        }

        #endregion Event Handlers
    }
}