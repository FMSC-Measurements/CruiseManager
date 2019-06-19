using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Models;
using CruiseManager.Core.ViewModel;
using CruiseManager.Data;
using CruiseManager.Services;
using CruiseManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CruiseManager.Core.CruiseCustomize
{
    public class FieldSetupPresenter : ViewModelBase, IViewLoadAware, ISaveHandler
    {
        bool _isInitialized;
        private List<FieldSetupStratum> _fieldSetupStrata;
        private List<TreeFieldSetupDO> _treeFields;
        private List<LogFieldSetupDO> _logFields;

        public FieldSetupPresenter(ISetupService setupService, IDatabaseProvider databaseProvider)
        {
            var database = databaseProvider.Database;
            SetupService = setupService;

            this.IsLogGradingEnabled = database.From<SaleDO>()
                .Query()
                .FirstOrDefault()?.LogGradingEnabled ?? false;

            Database = database;
        }

        public DAL Database { get; }
        public ISetupService SetupService { get; }

        public List<FieldSetupStratum> FieldSetupStrata
        {
            get => _fieldSetupStrata;
            protected set => SetProperty(ref _fieldSetupStrata, value);
        }

        public List<TreeFieldSetupDO> TreeFields
        {
            get => _treeFields;
            protected set => SetProperty(ref _treeFields, value);
        }

        public List<LogFieldSetupDO> LogFields
        {
            get => _logFields;
            protected set => SetProperty(ref _logFields, value);
        }

        public bool IsLogGradingEnabled { get; protected set; }

        public bool HasChangesToSave
        {
            get
            {
                return FieldSetupStrata.Any(x => x.HasEdits);
            }
        }

        public void OnViewLoad()
        {
            try
            {
                //initialize list of all tree and log fields
                var treeFields = SetupService.GetTreeFieldSetups();
                var logFields = SetupService.GetLogFieldSetups();

                var fieldSetupStrata = this.Database.From<FieldSetupStratum>().Read().ToList();
                
                foreach (FieldSetupStratum st in fieldSetupStrata)
                {
                    //initialize each stratum object
                    st.SelectedLogFields = new ObservableCollection<LogFieldSetupDO>(GetSelectedLogFields(st));
                    st.SelectedTreeFields = new ObservableCollection<TreeFieldSetupDO>(GetSelectedTreeFields(st));
                    if (st.SelectedTreeFields.Count <= 0)
                    {
                        // if blank, use default values for cruise method
                        st.SelectedTreeFields = new ObservableCollection<TreeFieldSetupDO>(GetSelectedTreeFieldsDefault(st));
                    }

                    //compare selected tree/log fields to all tree.log fields to create a list of unselected tree/log fields
                    List<TreeFieldSetupDO> unselectedTreeFields =
                        (from tfs in this.TreeFields.Except(st.SelectedTreeFields, TreeFieldComparer.Instance)
                         select new TreeFieldSetupDO(tfs)).OrderBy(x => x.Heading).ToList();
                    List<LogFieldSetupDO> unselectedLogFields = (
                        from lfs in this.LogFields.Except(st.SelectedLogFields, LogFieldComparer.Instance)
                        select new LogFieldSetupDO(lfs)).OrderBy(x => x.Heading).ToList();

                    st.UnselectedLogFields = unselectedLogFields;
                    st.UnselectedTreeFields = unselectedTreeFields;
                }

                TreeFields = treeFields;
                LogFields = logFields;
                FieldSetupStrata = fieldSetupStrata;
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                _isInitialized = false;
                throw new NotImplementedException(null, ex);
            }
            finally
            {
                //dal.ExitConnectionHold();
            }
        }

        protected List<TreeFieldSetupDO> GetSelectedTreeFields(StratumDO stratum)
        {
            return Database.From<TreeFieldSetupDO>()
                .Where("Stratum_CN = ?").OrderBy("FieldOrder").Read(stratum.Stratum_CN).ToList();
        }

        protected List<TreeFieldSetupDO> GetSelectedTreeFieldsDefault(StratumDO stratum)
        {
            var treeFieldDefaults = Database.From<TreeFieldSetupDefaultDO>()
                .Where("Method = ?").OrderBy("FieldOrder").Read(stratum.Method);

            var treeFields = new List<TreeFieldSetupDO>();

            foreach (TreeFieldSetupDefaultDO tfd in treeFieldDefaults)
            {
                var tfs = new TreeFieldSetupDO
                {
                    Stratum_CN = stratum.Stratum_CN,
                    Field = tfd.Field,
                    FieldOrder = tfd.FieldOrder,
                    ColumnType = tfd.ColumnType,
                    Heading = tfd.Heading,
                    Width = tfd.Width,
                    Format = tfd.Format,
                    Behavior = tfd.Behavior
                };

                treeFields.Add(tfs);
            }
            return treeFields;
        }

        protected List<LogFieldSetupDO> GetSelectedLogFields(StratumDO stratum)
        {
            return Database.From<LogFieldSetupDO>()
                .Where("Stratum_CN = ?").OrderBy("FieldOrder").Read(stratum.Stratum_CN).ToList();
        }

        public bool HandleSave()
        {
            this.Save();
            return true;
        }

        public void Save()
        {
            if (_isInitialized == false) { return; }
            //begin transaction for saving strata and their field set up info
            this.Database.BeginTransaction();
            try
            {
                foreach (FieldSetupStratum stratum in this.FieldSetupStrata)
                {
                    //ensure any changes to stratum are saved
                    stratum.Save();

                    stratum.SaveFieldSetup();
                }
                this.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                this.Database.RollbackTransaction();
                throw new UserFacingException("Field setup didn't save", ex);
            }
        }
    }
}