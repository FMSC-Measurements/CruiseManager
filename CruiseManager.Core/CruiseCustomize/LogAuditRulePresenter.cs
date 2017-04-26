using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.CruiseCustomize
{
    public class LogAuditRulePresenter : Presentor, ISaveHandler
    {
        bool _isInitialized;

        public new ILogAuditView View
        {
            get { return (ILogAuditView)base.View; }
            set { base.View = value; }
        }

        public event EventHandler LogAuditsChanged;

        public event EventHandler LogAuditsModified;

        public DAL Database { get { return ApplicationController.Database; } }

        ICollection<LogAuditRuleDO> _logAudits;

        public ICollection<LogAuditRuleDO> LogAudits
        {
            get { return _logAudits; }
            set
            {
                _logAudits = value;
                OnLogAuditsChanged();
            }
        }

        private void OnLogAuditsChanged()
        {
            LogAuditsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnLogAuditsModified()
        {
            LogAuditsModified?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            if (_isInitialized) { return; }

            try
            {
                LogAudits = Database.From<LogAuditRuleDO>().Read().ToList();
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
            }
        }

        public LogAuditRuleDO AddLogAudit()
        {
            var newLogAudit = new LogAuditRuleDO(Database);
            LogAudits.Add(newLogAudit);
            OnLogAuditsModified();
            return newLogAudit;
        }

        public void DeleteLogAudit(LogAuditRuleDO value)
        {
            if (value.IsPersisted)
            {
                value.Delete();
            }
            LogAudits.Remove(value);
            OnLogAuditsModified();
        }

        #region ISaveHandler members

        public bool HasChangesToSave
        {
            get
            {
                return LogAudits.Any(la => la.IsChanged || la.IsPersisted == false);
            }
        }

        public bool HandleSave()
        {
            foreach (var la in LogAudits)
            {
                la.Save();
            }
            return true;
        }

        #endregion ISaveHandler members
    }
}