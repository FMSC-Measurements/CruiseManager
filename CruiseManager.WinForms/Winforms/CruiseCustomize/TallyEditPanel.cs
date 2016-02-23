﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CruiseDAL.DataObjects;
using CruiseManager.Core.Constants;
using CruiseManager.Core.CruiseCustomize;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public delegate void TallyModeChangedEventHandler(object sender);
    public delegate TallyDO GetTallyEventHandler(SampleGroupDO sg, TreeDefaultValueDO tdv);
    public delegate void SelectedTallyChangedEventHandler(SampleGroupDO sg, TreeDefaultValueDO tdv, TallyDO tally);
    public delegate void TallyItemChangedEventHandler(TallyDO tally);
    public delegate TallyDO AddNewTallyEventHandler();

    

    public partial class TallyEditPanel : UserControl
    {
        private static readonly TreeDefaultValueDO[] EMPTY_SPECIES_LIST = new TreeDefaultValueDO[0];
        private bool _changingSampleGroup = false;
        private bool _changingCurrTally = false;

        private TreeDefaultValueDO _currTDV;

        

        public TallyEditPanel()
        {
            InitializeComponent();

            //this._hotKeyCB.Items.AddRange(CSM.Utility.R.Strings.HOTKEYS);
            this._behaviorCB.Items.AddRange(Strings.INDICATOR_TYPES);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<string, string[]> GetHotKeys { get; set; }

        protected bool AllowTallyBySpecies 
        {
            get { return this._tallyBySpRB.Enabled; }
            set
            {
                this._tallyBySpRB.Enabled = value;
            }
        }

        protected bool AllowTallyBySG
        {
            get { return this._tallyBySGRB.Enabled; }
            set
            {
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
                OnSampleGroupChanged();
                _changingSampleGroup = false;
            }
        }

        //private List<TallyVM> _tallyPresets;
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public List<TallyVM> TallyPresets 
        //{
        //    get { return _tallyPresets; }
        //    set
        //    {
        //        _BS_tallyPresets.DataSource = value;
        //        _tallyPresets = value;
        //    }
        //}


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CruiseDAL.Enums.TallyMode TallyMode
        {
            get 
            {
                if (_sampleGroup == null) { return CruiseDAL.Enums.TallyMode.Unknown; }
                return _sampleGroup.TallyMethod; 
            }
            protected set
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

        protected void NotifyHotKeysDropedDown(object sender, EventArgs e)
        {
            if(GetHotKeys != null)
            {
                var curHotKey = CurrentTally.Hotkey; 

                var avalibleHotKeys = GetHotKeys(curHotKey);
                //this._hotKeyCB.DataSource = avalibleHotKeys;
                this._hotKeyCB.Items.Clear();
                this._hotKeyCB.Items.AddRange(avalibleHotKeys);
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

        protected void OnSampleGroupChanged()
        {
            if(this.SampleGroup != null)
            {
                if (this.SampleGroup.IsTallyModeLocked)
                {
                    _tallyBySGRB.Enabled = false;
                    _tallyBySpRB.Enabled = false;
                    _dontTallyRB.Enabled = false;
                }
                else
                {
                    _tallyBySGRB.Enabled = this.SampleGroup.CanTallyBySG;
                    _tallyBySpRB.Enabled = this.SampleGroup.CanTallyBySpecies;
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
                CurrentTally = SampleGroup.SgTallie;

            }
            else if ((this.TallyMode & CruiseDAL.Enums.TallyMode.BySpecies) == CruiseDAL.Enums.TallyMode.BySpecies)
            {
                _GB_tallyFields.Enabled = true;
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
                SampleGroup.HasTallyEdits = true;
            }

            //if (TallyModeChanged != null && !_changingSampleGroup)
            //{
            //    TallyModeChanged(this);
            //}
        }


        //private void _BS_tallyPresets_CurrentChanged(object sender, EventArgs e)
        //{
        //    if (_changingCurrTally == true) { return; }
        //    if (this.SampleGroup == null) { return; }
        //    this.SampleGroup.HasTallyEdits = true;
            
        //    TallyVM tally = _BS_tallyPresets.Current as TallyVM;
        //    if (this._currTDV != null)
        //    {
        //        this.SampleGroup.Tallies[_currTDV] = tally;
        //    }
        //    else
        //    {
        //        this.SampleGroup.SgTallie = tally;
        //    }

        //    CurrentTally = tally;
        //}


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
            if (!_changingSampleGroup && !_changingCurrTally)
            {
                this.SampleGroup.HasTallyEdits = true;
            }
        }


        internal void EndEdits()
        {
            this._BS_CurTally.EndEdit();
        }

        private void _hotKeyCB_TextChanged(object sender, EventArgs e)
        {
            if(_changingCurrTally || this.CurrentTally == null)
            {
                return;
            }
            this.CurrentTally.Hotkey = _hotKeyCB.Text;
        }
    }
}
