using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.CruiseCustomize.Models;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.CruiseCustomize
{
    public class LogGradeSpecies : List<LogGradeAuditRule>
    {
        string _species = "ANY";

        public string Species
        {
            get { return _species; }
            set
            {
                _species = value;
                OnSpeciesChanged();
            }
        }

        private void OnSpeciesChanged()
        {
            foreach (var item in this)
            {
                item.Species = Species;
            }
        }

        public bool IsChanged => this.Any(x => x.IsChanged);
    }

    public class LogAuditRulePresenter : Presentor, ISaveHandler
    {
        bool _isInitialized;

        public new ILogGradeAuditView View
        {
            get { return (ILogGradeAuditView)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }

        #region LogAudits

        public event Action LogGradeAuditsChanged;//raised when the LogAudits property is changed

        public event Action LogGradeAuditsModified;//raised when the log audits collection is modified i.e. Add, Delete

        //ICollection<LogGradeAuditRuleDO> _logGradeAudits;

        //public ICollection<LogGradeAuditRuleDO> LogGradeAudits
        //{
        //    get { return _logGradeAudits; }
        //    set
        //    {
        //        _logGradeAudits = value;
        //        OnLogGradeAuditsChanged();
        //    }
        //}

        //private void OnLogGradeAuditsChanged()
        //{
        //    LogGradeAuditsChanged?.Invoke();
        //}

        //private void OnLogAuditsModified()
        //{
        //    LogGradeAuditsModified?.Invoke();
        //}

        #endregion LogAudits

        public ICollection<LogGradeSpecies> LogGradeSpecies { get; set; } = new BindingList<LogGradeSpecies>();

        public List<LogGradeAuditRule> DeletedLogGradeAuditRules { get; set; } = new List<LogGradeAuditRule>();

        public IEnumerable<string> SpeciesOptions { get; set; }

        public LogAuditRulePresenter(ApplicationControllerBase appController) : base(appController)
        {
            foreach (var grouping in Database.From<LogGradeAuditRule>().Read().GroupBy(x => x.Species))
            {
                var logGradeSp = new LogGradeSpecies() { Species = grouping.Key };
                logGradeSp.AddRange(grouping);

                LogGradeSpecies.Add(logGradeSp);
            }
            var result = Database.ExecuteScalar<String>("SELECT group_concat(Species) FROM (SELECT distinct [Species] FROM TreeDefaultValue ORDER BY Species);");
            SpeciesOptions = ("ANY," + result).Split(',');

            //LogGradeAudits = Database.From<LogGradeAuditRuleDO>().Read().ToList();
            _isInitialized = true;
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            if (_isInitialized) { return; }
        }

        public LogGradeAuditRule MakeLogGradeAudit()
        {
            var newLogAudit = new LogGradeAuditRule() { DAL = Database };
            return newLogAudit;
        }

        public void DeleteSpecies(LogGradeSpecies sp)
        {
            if (LogGradeSpecies.Remove(sp))
            {
                foreach (var lga in sp)
                {
                    DeletedLogGradeAuditRules.Add(lga);
                }
            }
        }

        public void DeleteLogAudit(LogGradeSpecies sp, LogGradeAuditRule value)
        {
            if (sp.Remove(value))
            {
                DeletedLogGradeAuditRules.Add(value);
            }
        }

        #region ISaveHandler members

        public bool HasChangesToSave
        {
            get
            {
                View.EndEdit();
                return LogGradeSpecies.Any(x => x.IsChanged) || DeletedLogGradeAuditRules.Any();
                //return LogGradeAudits.Any(la => la.IsChanged || la.IsPersisted == false);
            }
        }

        public bool HandleSave()
        {
            View.EndEdit();
            foreach (var la in DeletedLogGradeAuditRules)
            {
                if (la.IsPersisted)
                {
                    la.Delete();
                }
            }

            foreach (var lgs in LogGradeSpecies)
            {
                foreach (var la in lgs)
                {
                    la.Species = lgs.Species;
                    la.Save();
                }
            }

            return true;
        }

        #endregion ISaveHandler members
    }
}