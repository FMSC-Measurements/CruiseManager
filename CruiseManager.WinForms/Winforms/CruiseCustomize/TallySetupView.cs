using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseManager.Core.Constants;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class TallySetupView : CruiseManager.WinForms.UserControlView, ITallySetupView
    {

        BindingList<String> _stratumHotkeys = new BindingList<string>();
        private TallySetupStratum _currentTallySetupStratum;
        bool _currentStratumChanging = false;

        public new TallySetupPresenter ViewPresenter
        {
            get { return (TallySetupPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public TallySetupView(TallySetupPresenter presenter)
        {
            this.ViewPresenter = presenter;
            presenter.View = this;
            InitializeComponent();
            this._tallyEditPanel.GetHotKeys = this._tallyEditPanel_GetHotKeys;
        }

        
        public void EndEdits()
        {
            this._tallyEditPanel.EndEdits();
        }

        

        public void UpdateTallySetupView()
        {
            _BS_strata.DataSource = ViewPresenter.TallySetupStrata;
        }

        private void _BS_strata_CurrentChanged(object sender, EventArgs e)
        {
            _currentStratumChanging = true;
            try
            {
                _currentTallySetupStratum = _BS_strata.Current as TallySetupStratum;

                if (_currentTallySetupStratum != null)
                {
                    _BS_sampleGroups.DataSource = _currentTallySetupStratum.SampleGroups;
                    this._tallyEditPanel.Enabled = CruiseDAL.DataObjects.StratumDO.CanDefineTallys(_currentTallySetupStratum);
                    _stratumHKCB.Text = _currentTallySetupStratum.Hotkey;
                }
                else
                {
                    _BS_sampleGroups.DataSource = new TallySetupSampleGroup { };// empty collection
                    this._tallyEditPanel.Enabled = false;
                    _stratumHKCB.Text = String.Empty;

                }
                _stratumHKCB.Enabled = _currentTallySetupStratum != null;
                _sampleGroupCB.Enabled = _currentTallySetupStratum != null;     
            }
            finally
            {
                _currentStratumChanging = false;
            }
        }

        void UpdateStratumHotKeys()
        {
            if (_currentTallySetupStratum != null)
            {
                var list = this.ViewPresenter.GetAvalibleStratumHotKeys(_currentTallySetupStratum);
                _stratumHKCB.Items.Clear();
                _stratumHKCB.Items.AddRange(list);
            }
        }

        void _stratumHKCB_DropDown(object sender, EventArgs e)
        {
            UpdateStratumHotKeys();
        }

        void _stratumHKCB_TextChanged(object sender, EventArgs e)
        {
            if (_currentTallySetupStratum == null || _currentStratumChanging) { return; }
            else
            {
                _currentTallySetupStratum.Hotkey = _stratumHKCB.Text;
            }
        }


        //private void _strataCB_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (_currentTallySetupStratum != null)
        //    {
        //        _currentTallySetupStratum.Hotkey = _stratumHKCB.Text;
        //        _currentTallySetupStratum.Save();
        //    }
        //    _currentTallySetupStratum = _strataCB.SelectedValue as TallySetupStratum;


        //    if (_currentTallySetupStratum == null) { return; }

        //    //_stratumHKCB.DataSource = this.ViewPresenter.GetAvalibleStratumHotKeys(_currentTallySetupStratum);
        //    _stratumHKCB.Text = _currentTallySetupStratum.Hotkey;



        //    this._tallyEditPanel.Enabled = ViewPresenter.CanDefintTallys(_currentTallySetupStratum);

        //    _sampleGroupCB.DataSource = _currentTallySetupStratum.SampleGroups;
        //}

        private void _BS_sampleGroups_CurrentChanged(object sender, EventArgs e)
        {
            var curSG = _BS_sampleGroups.Current as TallySetupSampleGroup;

            _tallyEditPanel.SampleGroup = curSG;
        }

        //private void _sampleGroupCB_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    //store use systematic sampling option for previously selected sample group, if there was one
        //    if (_currentSG != null && this._systematicOptCB.Enabled)
        //    {
        //        _currentSG.UseSystematicSampling = this._systematicOptCB.Checked;
        //    }

        //    _currentSG = _sampleGroupCB.SelectedValue as TallySetupSampleGroup;
        //    if (_currentSG == null || _tallyEditPanel.Enabled == false)
        //    {
        //        this._systematicOptCB.Enabled = false;
        //        return;
        //    }
        //    else
        //    {
        //        this._systematicOptCB.Enabled = _currentSG.IsSTR && _currentSG.CanChangeSamplerType;
        //        this._systematicOptCB.Checked = _currentSG.UseSystematicSampling;
        //    }

        //    _tallyEditPanel.SampleGroup = _currentSG;
        //   // _tallyEditPanel.SetHotKeys(this.ViewPresenter.GetAvalibleTallyHotKeys(_currentTallySetupStratum));
        //}

        

        private string[] _tallyEditPanel_GetHotKeys(string curHotKey)
        {
            _currentTallySetupStratum = _BS_strata.Current as TallySetupStratum;

            if(_currentTallySetupStratum != null)
            {
                return this.ViewPresenter.GetAvalibleTallyHotKeys(_currentTallySetupStratum, curHotKey);
            }
            return new string[]{ };
        }

        
    }
}
