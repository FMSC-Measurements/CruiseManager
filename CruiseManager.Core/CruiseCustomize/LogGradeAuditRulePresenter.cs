using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
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

        public new ILogGradeAuditView View
        {
            get { return (ILogGradeAuditView)base.View; }
            set { base.View = value; }
        }

        public event Action LogGradeAuditsChanged;//raised when the LogAudits property is changed

        public event Action LogGradeAuditsModified;//raised when the log audits collection is modified i.e. Add, Delete

        public DAL Database { get { return ApplicationController.Database; } }

        #region LogAudits

        ICollection<LogGradeAuditRuleDO> _logGradeAudits;

        public ICollection<LogGradeAuditRuleDO> LogGradeAudits
        {
            get { return _logGradeAudits; }
            set
            {
                _logGradeAudits = value;
                OnLogGradeAuditsChanged();
            }
        }

        private void OnLogGradeAuditsChanged()
        {
            LogGradeAuditsChanged?.Invoke();
        }

        private void OnLogAuditsModified()
        {
            LogGradeAuditsModified?.Invoke();
        }

        #endregion LogAudits

        public LogAuditRulePresenter(ApplicationControllerBase appController) : base(appController)
        {
            LogGradeAudits = Database.From<LogGradeAuditRuleDO>().Read().ToList();
            _isInitialized = true;
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            if (_isInitialized) { return; }
        }

        public LogGradeAuditRuleDO AddLogAudit()
        {
            var newLogAudit = new LogGradeAuditRuleDO(Database);
            LogGradeAudits.Add(newLogAudit);
            OnLogAuditsModified();
            return newLogAudit;
        }

        public void DeleteLogAudit(LogGradeAuditRuleDO value)
        {
            if (value.IsPersisted)
            {
                value.Delete();
            }
            LogGradeAudits.Remove(value);
            OnLogAuditsModified();
        }

        #region ISaveHandler members

        public bool HasChangesToSave
        {
            get
            {
                return LogGradeAudits.Any(la => la.IsChanged || la.IsPersisted == false);
            }
        }

        public bool HandleSave()
        {
            foreach (var la in LogGradeAudits)
            {
                la.Save();
            }
            return true;
        }

        #endregion ISaveHandler members
    }
}