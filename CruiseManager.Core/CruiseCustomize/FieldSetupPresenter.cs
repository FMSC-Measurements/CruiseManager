using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Models;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CruiseManager.Core.CruiseCustomize
{
    public class FieldSetupPresenter : Presentor, ISaveHandler
    {
        bool _isInitialized;

        public FieldSetupPresenter(ApplicationControllerBase appController)
            : base(appController)
        {
            this.IsLogGradingEnabled = this.Database.From<SaleDO>()
                .Query()
                .FirstOrDefault()?.LogGradingEnabled ?? false;
        }

        public new ViewInterfaces.IFieldSetupView View
        {
            get { return (ViewInterfaces.IFieldSetupView)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }

        public List<FieldSetupStratum> FieldSetupStrata { get; protected set; }
        public List<TreeFieldSetupDO> TreeFields { get; protected set; }
        public List<LogFieldSetupDO> LogFields { get; protected set; }
        public bool IsLogGradingEnabled { get; protected set; }

        public bool HasChangesToSave
        {
            get
            {
                return FieldSetupStrata.Any(x => x.HasEdits);
            }
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            try
            {
                //initialize list of all tree and log fields
                this.TreeFields = ApplicationController.SetupService.GetTreeFieldSetups();
                this.LogFields = ApplicationController.SetupService.GetLogFieldSetups();

                this.FieldSetupStrata = this.Database.From<FieldSetupStratum>().Read().ToList();
                foreach (FieldSetupStratum st in FieldSetupStrata)
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

            this.View.UpdateFieldSetupViews();
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