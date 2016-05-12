using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.ComponentModel;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class TallySetupView : CruiseManager.WinForms.UserControlView, ITallySetupView
    {
        private BindingList<String> _stratumHotkeys = new BindingList<string>();
        private TallySetupStratum_Base _currentStratum;
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

        private void UpdateStratumHotKeys()
        {
            if (_currentStratum != null)
            {
                var list = this.ViewPresenter.GetAvalibleStratumHotKeys(_currentStratum);
                _stratumHKCB.Items.Clear();
                _stratumHKCB.Items.AddRange(list);
            }
        }

        #region event handlers

        private void _BS_strata_CurrentChanged(object sender, EventArgs e)
        {
            _currentStratumChanging = true;
            try
            {
                _currentStratum = _BS_strata.Current as TallySetupStratum_Base;

                if (_currentStratum != null)
                {
                    var isFixCNT = _currentStratum.Method == CruiseDAL.Schema.CruiseMethods.FIXCNT;

                    _tallyEditPanel.Visible = !isFixCNT;
                    _fixCNTTallyEditPanel.Visible = isFixCNT;

                    if (isFixCNT)
                    {
                        _fixCNTTallyEditPanel.TallyClass = _currentStratum.TallyClass;
                    }
                    else
                    {
                        _tallyEditPanel.SampleGroups = _currentStratum.SampleGroups;
                        _tallyEditPanel.Enabled = _currentStratum.CanDefineTallies;
                        _stratumHKCB.Text = _currentStratum.Hotkey;
                    }
                }
                else
                {
                    _tallyEditPanel.SampleGroups = null;
                    _tallyEditPanel.Enabled = false;
                    _stratumHKCB.Text = String.Empty;
                }
                _stratumHKCB.Enabled = _currentStratum != null;
            }
            finally
            {
                _currentStratumChanging = false;
            }
        }

        private void _stratumHKCB_DropDown(object sender, EventArgs e)
        {
            UpdateStratumHotKeys();
        }

        private void _stratumHKCB_TextChanged(object sender, EventArgs e)
        {
            if (_currentStratum == null || _currentStratumChanging) { return; }
            else
            {
                _currentStratum.Hotkey = _stratumHKCB.Text;
            }
        }

        private string[] _tallyEditPanel_GetHotKeys(string curHotKey)
        {
            var currentStratum = _BS_strata.Current as TallySetupStratum;

            if (_currentStratum != null)
            {
                return this.ViewPresenter.GetAvalibleTallyHotKeys(currentStratum, curHotKey);
            }

            return new string[] { };
        }

        #endregion event handlers
    }
}