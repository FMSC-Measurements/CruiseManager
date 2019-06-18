using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class TallySetupView : CruiseManager.WinForms.UserControlView, ITallySetupView
    {
        private TallySetupStratum_Base _currentStratum;
        private bool _currentStratumChanging;
        FixCNTTallyEditPanel _myfixCNTTallyEditPanel;
        TallyEditPanel _standardTallyEditPanel;
        private BindingList<String> _stratumHotkeys = new BindingList<string>();

        public TallySetupView(TallySetupPresenter presenter)
        {
            this.ViewPresenter = presenter;
            presenter.PropertyChanged += Presenter_PropertyChanged;
            presenter.View = this;
            InitializeComponent();
        }

        private void Presenter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            if(propertyName == nameof(TallySetupPresenter.TallySetupStrata))
            {
                UpdateTallySetupView();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TallySetupPresenter ViewPresenter
        {
            get { return (TallySetupPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected ITallyEditPanel TallyEditPanel
        {
            get
            {
                try
                {
                    return _tallyEditContainer.Controls[0] as ITallyEditPanel;
                }
                catch (IndexOutOfRangeException)
                {
                    return null;
                }
            }
            set
            {
                _tallyEditContainer.Controls.Clear();
                var ctrl = value as Control;
                if (ctrl != null)
                {
                    _tallyEditContainer.Controls.Add(ctrl);
                }
            }
        }

        public override void EndEdits()
        {
            TallyEditPanel.EndEdits();
        }

        protected void UpdateTallySetupView()
        {
            _BS_strata.DataSource = ViewPresenter.TallySetupStrata;
        }

        protected ITallyEditPanel GetEditView(TallySetupStratum_Base stratum)
        {
            if (stratum == null) { return null; }
            if (stratum is TallySetupStratum)
            {
                if (_standardTallyEditPanel == null)
                {
                    _standardTallyEditPanel = new TallyEditPanel();
                    _standardTallyEditPanel.GetHotKeys = this._tallyEditPanel_GetHotKeys;
                    _standardTallyEditPanel.Dock = DockStyle.Fill;
                }

                _standardTallyEditPanel.Stratum = (TallySetupStratum)stratum;
                return _standardTallyEditPanel;
            }
            else if (stratum is FixCNTTallySetupStratum)
            {
                if (_myfixCNTTallyEditPanel == null)
                {
                    _myfixCNTTallyEditPanel = new FixCNTTallyEditPanel();
                    _myfixCNTTallyEditPanel.Dock = DockStyle.Fill;
                }
                _myfixCNTTallyEditPanel.Stratum = (FixCNTTallySetupStratum)stratum;
                return _myfixCNTTallyEditPanel;
            }
            else
            {
                throw new InvalidOperationException();
            }
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
                _stratumHKCB.Enabled = _currentStratum != null;
                _stratumHKCB.Text = _currentStratum?.Hotkey ?? string.Empty;

                var tallyEditPanel = GetEditView(_currentStratum);
                TallyEditPanel = tallyEditPanel;
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