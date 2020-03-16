using Backpack.SqlBuilder;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Util;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CruiseManager.Core.EditTemplate
{
    public class TemplateEditViewPresenter : Presentor, ISaveHandler
    {
        private FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO> _treeDefaultValues;
        //private List<TreeDefaultValueDO> _toBeDeletedTreeDefaults = new List<TreeDefaultValueDO>();

        public new IEditTemplateView View { get; set; }
        public DAL Database { get; }
        public SetupServiceBase SetupService { get; }

        public BindingList<EditTemplateCruiseMethod> CruiseMethods { get; set; }

        public FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO> TreeDefaultValues
        {
            get { return _treeDefaultValues; }
            set
            {
                if (value == _treeDefaultValues) { return; }
                if (_treeDefaultValues != null)
                {
                    _treeDefaultValues.ItemRemoved -= this.TreeDefaults_ItemRemoved;//unwire item removed
                }
                if (value != null)
                {
                    value.ItemRemoved += this.TreeDefaults_ItemRemoved;
                }
                _treeDefaultValues = value;
            }
        }

        //public BindingList<TallyDO> Tallies {get; set; }
        public BindingList<VolumeEquationDO> VolumeEQs { get; set; }

        public BindingList<ReportsDO> Reports { get; set; }
        public List<TreeAuditValueDO> TreeAudits { get; set; }

        public List<TreeFieldSetupDefaultDO> TreeFields { get; set; }

        public List<LogFieldSetupDefaultDO> LogFields { get; set; }
        public BindingList<LogFieldSetupDefaultDO> SelectedLogFields { get; set; }
        public BindingList<LogFieldSetupDefaultDO> UnselectedLogFields { get; set; }



        public TemplateEditViewPresenter(IApplicationController applicationController)
        {
            this.ApplicationController = applicationController;
            Database = applicationController.Database ?? throw new ArgumentNullException(nameof(Database));
            SetupService = applicationController.SetupService ?? throw new ArgumentNullException(nameof(SetupService));

            //read TreeFiedleSetup info from .setup file and convert the data to TreeFieldSetupDefault
            //it may be posible to simplify this task by asking for the data in the form of a TreeFieldSetupDefault object
            //the xmlSerializer may beable to handle this conversion

            TreeFields = SetupService.GetTreeFieldSetups().Select(tf =>
            {
                return new TreeFieldSetupDefaultDO()
                {
                    Field = tf.Field,
                    Heading = tf.Heading,
                    Format = tf.Format,
                    ColumnType = tf.ColumnType,
                    Behavior = tf.Behavior,
                };
            }).ToList();

            LogFields = SetupService.GetLogFieldSetups().Select(lf =>
            {
                return new LogFieldSetupDefaultDO()
                {
                    Field = lf.Field,
                    Heading = lf.Heading,
                    Format = lf.Format,
                    ColumnType = lf.ColumnType,
                    Behavior = lf.Behavior,
                };
            }).ToList();

        }

        /// <summary>
        /// Handels the initialization of the Field setups, creating a list of cruise methods and
        /// </summary>
        public void HandleFieldSetupLoad()
        {

            var allTreeFields = TreeFields;

            //check to see if Cruise method list has been initialized
            if (CruiseMethods == null)
            {
                try
                {
                    var methods = Database.From<EditTemplateCruiseMethod>().Read().ToList();
                    foreach (var method in methods)
                    {
                        var treeFields = Database.From<TreeFieldSetupDefaultDO>()
                            .Where("Method = @p1").OrderBy("FieldOrder").Read(method.Code).ToList();

                        method.TreeFields = new BindingList<TreeFieldSetupDefaultDO>(treeFields);

                        var unselectedTreeFields = allTreeFields.Except(treeFields, TreeFieldDefaultComparer.Instance)
                            .Select(tfs => new TreeFieldSetupDefaultDO(tfs) { Method = method.Code })
                            .ToList();
                        method.UnselectedTreeFields = new BindingList<TreeFieldSetupDefaultDO>(unselectedTreeFields);
                    }
                    CruiseMethods = new BindingList<EditTemplateCruiseMethod>(methods);
                }
                catch { }
            }

            if (SelectedLogFields == null)
            {
                try
                {
                    var logFields = Database.From<LogFieldSetupDefaultDO>()
                        .OrderBy("FieldOrder").Read().ToList();
                    SelectedLogFields = new BindingList<LogFieldSetupDefaultDO>(logFields);
                    var unselectedLogFields = LogFields.Except(logFields, LogFieldDefaultComparer.Instance)
                                              .Select(lfs => new LogFieldSetupDefaultDO(lfs)).ToList();
                    UnselectedLogFields = new BindingList<LogFieldSetupDefaultDO>(unselectedLogFields);
                }
                catch
                {
                    SelectedLogFields = null;
                }

                View.UpdateFieldSetup();
            }
        }

        public void HandleTreeDefaultsLoad()
        {
            if (TreeDefaultValues == null)
            {
                var defaults = Database.From<TreeDefaultValueDO>().Read().ToList();
                TreeDefaultValues = new FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO>(defaults);
            }

            View.UpdateTreeDefaults();
        }

        //public void HandleTallyLoad()
        //{
        //    if (this.Tallies == null)
        //    {
        //        List<TallyDO> tallies = this.Controller.Database.Read<TallyDO>("Tally", null);
        //        this.Tallies = new BindingList<TallyDO>(tallies);
        //        this.View.UpdateTallySetup();
        //    }
        //}

        public void HandleVolumeEquLoad()
        {
            if (VolumeEQs == null)
            {
                var volumeEQs = Database.From<VolumeEquationDO>()
                    .Read().ToList();
                VolumeEQs = new BindingList<VolumeEquationDO>(volumeEQs);
                View.UpdateVolumeEqs();
            }
        }

        public void HandleReportsLoad()
        {
            if (Reports == null)
            {
                var reports = Database.From<ReportsDO>()
                    .Read().ToList();
                Reports = new BindingList<ReportsDO>(reports);
                View.UpdateReports();
            }
        }

        public void HandleTreeAuditsLoad()
        {
            if (TreeDefaultValues == null)
            {
                var defaults = Database.From<TreeDefaultValueDO>()
                    .Read().ToList();
                TreeDefaultValues = new FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO>(defaults);
            }

            if (TreeAudits == null)
            {
                TreeAudits = Database.From<TreeAuditValueDO>().OrderBy("Field")
                    .Read().ToList();
            }

            View.UpdateTreeAudit();
        }

        private void TreeDefaults_ItemRemoved(object sender, FMSC.Utility.Collections.ItemRemovedEventArgs e)
        {
            var rTDV = e.Item as TreeDefaultValueDO;
            rTDV?.Delete();
        }

        public List<TreeFieldSetupDefaultDO> GetSelectedTreeFields(CruiseMethodsDO method)
        {
            return Database.From<TreeFieldSetupDefaultDO>()
                .Where("Method = @p1").OrderBy("FieldOrder")
                .Read(method.Code).ToList();
        }

        public List<LogFieldSetupDefaultDO> GetSelectedLogFields()
        {
            return Database.From<LogFieldSetupDefaultDO>()
                .OrderBy("FieldOrder").Read().ToList();
        }

        public void Save()
        {
            if (CruiseMethods != null)
            {
                foreach (var method in CruiseMethods)
                {
                    foreach (var tfs in method.UnselectedTreeFields)
                    {
                        if (tfs.IsPersisted == true)
                        {
                            tfs.Delete();
                        }
                    }

                    foreach (var tfs in method.TreeFields)
                    {
                        if (tfs.DAL == null || tfs.IsPersisted == false)
                        {
                            tfs.DAL = Database;
                            tfs.Save(OnConflictOption.Replace);
                        }
                        else if (tfs.IsChanged == true)
                        {
                            tfs.Save(OnConflictOption.Replace);
                        }
                    }
                }
            }

            foreach (var lfs in UnselectedLogFields)
            {
                if (lfs.IsPersisted == true)
                {
                    lfs.Delete();
                }
            }

            foreach (var lfs in SelectedLogFields)
            {
                if (lfs.DAL == null || lfs.IsPersisted == false)
                {
                    lfs.DAL = Database;
                    lfs.Save(OnConflictOption.Replace);
                }
                else if (lfs.IsChanged == true)
                {
                    lfs.Save(OnConflictOption.Replace);
                }
            }

            if (TreeDefaultValues != null)
            {
                foreach (var tdv in TreeDefaultValues)
                {
                    if (tdv.DAL == null)
                    {
                        tdv.DAL = Database;
                    }
                    tdv.Save(OnConflictOption.Replace);
                }
            }

            //if (Tallies != null)
            //{
            //    foreach (TallyDO tally in Tallies)
            //    {
            //        if (tally.DAL == null)
            //        {
            //            tally.DAL = this.Controller.Database;
            //        }
            //        tally.Save();
            //    }
            //}

            if (VolumeEQs != null)
            {
                foreach (var volEQ in VolumeEQs)
                {
                    if (volEQ.DAL == null)
                    {
                        volEQ.DAL = Database;
                    }
                    volEQ.Save(OnConflictOption.Replace);
                }
            }

            if (Reports != null)
            {
                foreach (var report in Reports)
                {
                    if (report.DAL == null)
                    {
                        report.DAL = Database;
                    }
                    report.Save(OnConflictOption.Replace);
                }
            }

            if (TreeAudits != null)
            {
                foreach (var tav in TreeAudits)
                {
                    if (tav.DAL == null)
                    {
                        tav.DAL = Database;
                    }
                    tav.Save();
                    tav.TreeDefaultValues.Save();
                }
            }
        }

        #region ISaveHandler Members

        public bool HasChangesToSave
        {
            get
            {
                return CruiseMethods.AnyAndNotNull(cm => cm.UnselectedTreeFields.Any(x => x.IsPersisted)
                                                        || cm.TreeFields.Any(x => x.IsChanged || x.IsPersisted == false))
                    || UnselectedLogFields.Any(lf => lf.IsPersisted)
                    || SelectedLogFields.Any(lf => lf.IsChanged || lf.IsPersisted == false)
                    || TreeDefaultValues.AnyAndNotNull(tdv => tdv.IsChanged || tdv.IsPersisted == false)
                    || VolumeEQs.AnyAndNotNull(eq => eq.IsChanged || eq.IsPersisted == false)
                    || Reports.AnyAndNotNull(r => r.IsChanged || r.IsPersisted == false)
                    || TreeAudits.AnyAndNotNull(ta => ta.IsChanged || ta.IsPersisted == false || ta.TreeDefaultValues.HasChanges);

            }
        }

        public bool HandleSave()
        {
            this.Save();
            return true;
        }

        public void HandleAppClosing(ref bool cancel)
        {
            this.Save();
        }

        #endregion ISaveHandler Members
    }

    //a worker class for comparing TreeFieldSetupDO
    public class TreeFieldDefaultComparer : IEqualityComparer<TreeFieldSetupDefaultDO>, IComparer<TreeFieldSetupDefaultDO>
    {
        private static TreeFieldDefaultComparer _instance;

        public static TreeFieldDefaultComparer Instance
        {
            get
            {
                if (_instance == null) { _instance = new TreeFieldDefaultComparer(); }
                return _instance;
            }
        }

        #region IEqualityComparer<TreeFieldSetupDO> Members

        public bool Equals(TreeFieldSetupDefaultDO x, TreeFieldSetupDefaultDO y)
        {
            return x.Field == y.Field;
        }

        public int GetHashCode(TreeFieldSetupDefaultDO obj)
        {
            return obj.Field.GetHashCode();
        }

        #endregion IEqualityComparer<TreeFieldSetupDO> Members

        #region IComparer<TreeFieldSetupDO> Members

        public int Compare(TreeFieldSetupDefaultDO x, TreeFieldSetupDefaultDO y)
        {
            return string.Compare(x.Field, y.Field, StringComparison.Ordinal);
        }

        #endregion IComparer<TreeFieldSetupDO> Members
    }

    //a worker class for comparing LogFieldSetupDO
    public class LogFieldDefaultComparer : IEqualityComparer<LogFieldSetupDefaultDO>, IComparer<LogFieldSetupDefaultDO>
    {
        private static LogFieldDefaultComparer _instance;

        public static LogFieldDefaultComparer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogFieldDefaultComparer();
                }
                return _instance;
            }
        }

        #region IEqualityComparer<LogFieldSetupDO> Members

        public bool Equals(LogFieldSetupDefaultDO x, LogFieldSetupDefaultDO y)
        {
            return x.Field == y.Field;
        }

        public int GetHashCode(LogFieldSetupDefaultDO obj)
        {
            return obj.Field.GetHashCode();
        }

        #endregion IEqualityComparer<LogFieldSetupDO> Members

        #region IComparer<LogFieldSetupDO> Members

        public int Compare(LogFieldSetupDefaultDO x, LogFieldSetupDefaultDO y)
        {
            return string.Compare(x.Field, y.Field, StringComparison.Ordinal);
        }

        #endregion IComparer<LogFieldSetupDO> Members
    }
}