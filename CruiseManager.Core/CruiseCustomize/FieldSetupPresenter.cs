using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Models;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class FieldSetupPresenter : Presentor, ISaveHandler
    {
        bool _isInitialized; 

        public FieldSetupPresenter(ApplicationController appController)
            : base(appController)
        {
            this.IsLogGradingEnabled = this.Database.ReadSingleRow<SaleDO>("Sale", (String)null).LogGradingEnabled;
        }

        public new CruiseCustomizeView View
        {
            get { return (CruiseCustomizeView)base.View; }
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

                this.FieldSetupStrata = this.Database.Read<FieldSetupStratum>("Stratum", null);
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
                         select new TreeFieldSetupDO(tfs)).ToList();
                    List<LogFieldSetupDO> unselectedLogFields = (
                        from lfs in this.LogFields.Except(st.SelectedLogFields, LogFieldComparer.Instance)
                        select new LogFieldSetupDO(lfs)).ToList();

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
            return this.Database.Read<TreeFieldSetupDO>("TreeFieldSetup", "WHERE Stratum_CN = ? ORDER BY FieldOrder", stratum.Stratum_CN);
        }

        protected List<TreeFieldSetupDO> GetSelectedTreeFieldsDefault(StratumDO stratum)
        {
            //select from TreeFieldSetupDefault where method = stratum.method
            List<TreeFieldSetupDefaultDO> treeFieldDefaults = this.Database.Read<TreeFieldSetupDefaultDO>("TreeFieldSetupDefault", "WHERE Method = ? ORDER BY FieldOrder", stratum.Method);

            List<TreeFieldSetupDO> treeFields = new List<TreeFieldSetupDO>();

            foreach (TreeFieldSetupDefaultDO tfd in treeFieldDefaults)
            {
                TreeFieldSetupDO tfs = new TreeFieldSetupDO();
                tfs.Stratum_CN = stratum.Stratum_CN;
                tfs.Field = tfd.Field;
                tfs.FieldOrder = tfd.FieldOrder;
                tfs.ColumnType = tfd.ColumnType;
                tfs.Heading = tfd.Heading;
                tfs.Width = tfd.Width;
                tfs.Format = tfd.Format;
                tfs.Behavior = tfd.Behavior;

                treeFields.Add(tfs);
            }
            return treeFields;
        }

        protected List<LogFieldSetupDO> GetSelectedLogFields(StratumDO stratum)
        {
            return this.Database.Read<LogFieldSetupDO>("LogFieldSetup", "WHERE Stratum_CN = ? ORDER BY FieldOrder", stratum.Stratum_CN);
        }

        public bool HandleSave()
        {
            this.Save();
            return true;
        }

        public void Save()
        {
            if(_isInitialized == false) { return; }
            try
            {
                //begin transaction for saving strata and their field set up info
                this.Database.BeginTransaction();
                foreach (FieldSetupStratum stratum in this.FieldSetupStrata)
                {

                    //ensure any canges to stratum are saved 
                    stratum.Save();

                    //ensure all unselected tree fields are removed 
                    foreach (TreeFieldSetupDO tf in stratum.UnselectedTreeFields)
                    {
                        if (tf.IsPersisted == true)
                        {
                            tf.Delete();
                        }
                    }

                    //ensure all unselected log fields are removed 
                    foreach (LogFieldSetupDO lf in stratum.UnselectedLogFields)
                    {
                        if (lf.IsPersisted == true)
                        {
                            lf.Delete();
                        }
                    }


                    foreach (TreeFieldSetupDO tf in stratum.SelectedTreeFields)
                    {
                        if (tf.IsPersisted == false)
                        {
                            tf.DAL = this.Database;
                            tf.Stratum = stratum;
                        }
                        tf.Save();
                    }
                    foreach (LogFieldSetupDO lf in stratum.SelectedLogFields)
                    {
                        if (lf.IsPersisted == false)
                        {
                            lf.DAL = this.Database;
                            lf.Stratum = stratum;
                        }
                        lf.Save();
                    }
                }//end foreach
                this.Database.EndTransaction();
            }
            catch (Exception ex)
            {
                //errorBuilder.AppendFormat("Field setup was not saved. <Error details: {0}>", ex.ToString());
                this.Database.CancelTransaction();
                throw new NotImplementedException("Exception Handler not implemented",ex);
            }
        }
    }
}
