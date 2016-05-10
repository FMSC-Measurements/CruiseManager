using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.ComponentModel;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class TallySetupView : CruiseManager.WinForms.UserControlView, ITallySetupView
    {
        private BindingList<String> _stratumHotkeys = new BindingList<string>();
        private TallySetupStratum _currentTallySetupStratum;
        private bool _currentStratumChanging = false;

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

        void UpdateStratumHotKeys()
        {
            if (_currentTallySetupStratum != null)
            {
                var list = this.ViewPresenter.GetAvalibleStratumHotKeys(_currentTallySetupStratum);
                _stratumHKCB.Items.Clear();
                _stratumHKCB.Items.AddRange(list);
            }
        }

        void _BS_strata_CurrentChanged(object sender, EventArgs e)
        {
            _currentStratumChanging = true;
            try
            {
                _currentTallySetupStratum = _BS_strata.Current as TallySetupStratum;

                if (_currentTallySetupStratum != null)
                {
                    _tallyEditPanel.SampleGroups = _currentTallySetupStratum.SampleGroups;
                    _tallyEditPanel.Enabled = _currentTallySetupStratum.CanDefineTallies;
                    _stratumHKCB.Text = _currentTallySetupStratum.Hotkey;
                }
                else
                {
                    _tallyEditPanel.SampleGroups = null;
                    _tallyEditPanel.Enabled = false;
                    _stratumHKCB.Text = String.Empty;
                }
                _stratumHKCB.Enabled = _currentTallySetupStratum != null;
            }
            finally
            {
                _currentStratumChanging = false;
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

        string[] _tallyEditPanel_GetHotKeys(string curHotKey)
        {
            _currentTallySetupStratum = _BS_strata.Current as TallySetupStratum;

            if (_currentTallySetupStratum != null)
            {
                return this.ViewPresenter.GetAvalibleTallyHotKeys(_currentTallySetupStratum, curHotKey);
            }
            return new string[] { };
        }
    }
}