using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class TallySetupView : CruiseManager.WinForms.UserControlView, ITallySetupView
    {
        private TallySetupStratum _currentTallySetupStratum;
        private TallySetupSampleGroup _currentSG;

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
            if (_currentSG != null && this._systematicOptCB.Enabled)
            {
                _currentSG.UseSystematicSampling = this._systematicOptCB.Checked;
            }
            if (_currentTallySetupStratum != null)
            {
                _currentTallySetupStratum.Hotkey = _stratumHKCB.Text;
            }

            this._tallyEditPanel.EndEdits();
        }

        public void UpdateTallySetupView()
        {
            _strataCB.DataSource = ViewPresenter.TallySetupStrata;
            //_tallyEditPanel.TallyPresets = Presenter.TallyPresets;
        }

        private void _strataCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_currentTallySetupStratum != null)
            {
                _currentTallySetupStratum.Hotkey = _stratumHKCB.Text;
                _currentTallySetupStratum.Save();
            }
            _currentTallySetupStratum = _strataCB.SelectedValue as TallySetupStratum;


            if (_currentTallySetupStratum == null) { return; }

            //_stratumHKCB.DataSource = this.ViewPresenter.GetAvalibleStratumHotKeys(_currentTallySetupStratum);
            _stratumHKCB.Text = _currentTallySetupStratum.Hotkey;

            this._tallyEditPanel.Enabled = ViewPresenter.CanDefintTallys(_currentTallySetupStratum);

            _sampleGroupCB.DataSource = _currentTallySetupStratum.SampleGroups;
        }

        private void _sampleGroupCB_SelectedValueChanged(object sender, EventArgs e)
        {
            //store use systematic sampleing option for previously selected sample group, if there was one
            if (_currentSG != null && this._systematicOptCB.Enabled)
            {
                _currentSG.UseSystematicSampling = this._systematicOptCB.Checked;
            }

            _currentSG = _sampleGroupCB.SelectedValue as TallySetupSampleGroup;
            if (_currentSG == null || _tallyEditPanel.Enabled == false)
            {
                this._systematicOptCB.Enabled = false;
                return;
            }
            else
            {
                this._systematicOptCB.Enabled = _currentSG.IsSTR && _currentSG.CanChangeSamplerType;
                this._systematicOptCB.Checked = _currentSG.UseSystematicSampling;
            }

            _tallyEditPanel.SampleGroup = _currentSG;
           // _tallyEditPanel.SetHotKeys(this.ViewPresenter.GetAvalibleTallyHotKeys(_currentTallySetupStratum));
        }

        private void _stratumHKCB_DropDown(object sender, EventArgs e)
        {
            _stratumHKCB.DataSource = this.ViewPresenter.GetAvalibleStratumHotKeys(_currentTallySetupStratum);
        }

        private string[] _tallyEditPanel_GetHotKeys(string curHotKey)
        {
            if(_currentTallySetupStratum != null)
            {
                return this.ViewPresenter.GetAvalibleTallyHotKeys(this._currentTallySetupStratum, curHotKey);
            }
            return new string[]{ };
        }
    }
}
