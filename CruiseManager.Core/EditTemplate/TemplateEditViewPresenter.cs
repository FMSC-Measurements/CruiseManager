using Backpack.SqlBuilder;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using CruiseManager.Data;
using CruiseManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CruiseManager.Core.EditTemplate
{
    public class TemplateEditViewPresenter : ViewModelBase, ISaveHandler
    {
        private FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO> _treeDefaultValues;
        private BindingList<VolumeEquationDO> _volumeEQs;
        private BindingList<ReportsDO> _reports;
        private List<TreeAuditValueDO> _treeAudits;
        private List<TreeFieldSetupDefaultDO> _treeFields;
        private List<LogFieldSetupDefaultDO> _logFields;
        private BindingList<LogFieldSetupDefaultDO> _selectedLogFields;
        private BindingList<LogFieldSetupDefaultDO> _unselectedLogFields;
        private BindingList<EditTemplateCruiseMethod> _cruiseMethods;

        //private List<TreeDefaultValueDO> _toBeDeletedTreeDefaults = new List<TreeDefaultValueDO>();

        protected DAL Database { get; }
        protected ISetupService SetupService { get; }

        #region public props
        public BindingList<EditTemplateCruiseMethod> CruiseMethods
        {
            get => _cruiseMethods;
            set => SetProperty(ref _cruiseMethods, value);
        }

        public FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO> TreeDefaultValues
        {
            get => _treeDefaultValues;
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
                SetProperty(ref _treeDefaultValues, value);
            }
        }

        public BindingList<VolumeEquationDO> VolumeEQs
        {
            get => _volumeEQs;
            set => SetProperty(ref _volumeEQs, value);
        }

        public BindingList<ReportsDO> Reports
        {
            get => _reports;
            set => SetProperty(ref _reports, value);
        }

        public List<TreeAuditValueDO> TreeAudits
        {
            get => _treeAudits;
            set => SetProperty(ref _treeAudits, value);
        }

        public List<TreeFieldSetupDefaultDO> TreeFields
        {
            get => _treeFields;
            set => SetProperty(ref _treeFields, value);
        }

        public List<LogFieldSetupDefaultDO> LogFields
        {
            get => _logFields;
            set => SetProperty(ref _logFields, value);
        }
        public BindingList<LogFieldSetupDefaultDO> SelectedLogFields
        {
            get => _selectedLogFields;
            set => SetProperty(ref _selectedLogFields, value);
        }

        public BindingList<LogFieldSetupDefaultDO> UnselectedLogFields
        {
            get => _unselectedLogFields;
            set => SetProperty(ref _unselectedLogFields, value);
        }
        #endregion public props

        public TemplateEditViewPresenter(IDatabaseProvider databaseProvider, ISetupService setupService)
        {
            Database = databaseProvider.Database;
            

            //read TreeFiedleSetup info from .setup file and convert the data to TreeFieldSetupDefault
            //it may be posible to simplify this task by asking for the data in the form of a TreeFieldSetupDefault object
            //the xmlSerializer may beable to handle this conversion
            this.TreeFields = new List<TreeFieldSetupDefaultDO>();
            foreach (TreeFieldSetupDO tf in setupService.GetTreeFieldSetups())
            {
                TreeFieldSetupDefaultDO newTF = new TreeFieldSetupDefaultDO();
                newTF.Field = tf.Field;
                newTF.Heading = tf.Heading;
                newTF.Format = tf.Format;
                newTF.ColumnType = tf.ColumnType;
                newTF.Behavior = tf.Behavior;

                this.TreeFields.Add(newTF);
            }
            this.LogFields = new List<LogFieldSetupDefaultDO>();
            foreach (LogFieldSetupDO lf in setupService.GetLogFieldSetups())
            {
                LogFieldSetupDefaultDO newLF = new LogFieldSetupDefaultDO();
                newLF.Field = lf.Field;
                newLF.Heading = lf.Heading;
                newLF.Format = lf.Format;
                newLF.ColumnType = lf.ColumnType;
                newLF.Behavior = lf.Behavior;

                this.LogFields.Add(newLF);
            }

            SetupService = setupService;
        }

        /// <summary>
        /// Called when the Field Setup view is displayed
        /// </summary>
        public void HandleFieldSetupLoad()
        {
            //check to see if Cruise method list has been initialized
            if (this.CruiseMethods == null)
            {
                try
                {
                    var cruiseMethods = new BindingList<EditTemplateCruiseMethod>();
                    var methods = Database.From<CruiseMethodsDO>().Read().ToList();
                    foreach (CruiseMethodsDO method in methods)
                    {
                        var vm = new EditTemplateCruiseMethod(method);
                        var treeFields = Database.From<TreeFieldSetupDefaultDO>()
                            .Where("Method = ?").OrderBy("FieldOrder").Read(method.Code).ToList();

                        vm.TreeFields = new BindingList<TreeFieldSetupDefaultDO>(treeFields);

                        var unselectedTreeFields = (from tfs in this.TreeFields.Except(treeFields, new TreeFieldDefaultComparer())
                                                    select new TreeFieldSetupDefaultDO(tfs)).ToList();

                        vm.UnselectedTreeFields = new BindingList<TreeFieldSetupDefaultDO>(unselectedTreeFields);

                        cruiseMethods.Add(vm);
                    }

                    CruiseMethods = cruiseMethods;
                }
                catch
                {
                    this.CruiseMethods = null;
                }
            }

            if (this.SelectedLogFields == null)
            {
                try
                {
                    var logFields = Database.From<LogFieldSetupDefaultDO>()
                        .OrderBy("FieldOrder").Read().ToList();
                    
                    var unselectedLogFields = (from lfs in this.LogFields.Except(logFields, new LogFieldDefaultComparer())
                                               select new LogFieldSetupDefaultDO(lfs)).ToList();

                    UnselectedLogFields = new BindingList<LogFieldSetupDefaultDO>(unselectedLogFields);
                    SelectedLogFields = new BindingList<LogFieldSetupDefaultDO>(logFields);
                }
                catch
                {
                    this.SelectedLogFields = null;
                }
            }
        }

        public void HandleTreeDefaultsLoad()
        {
            if (this.TreeDefaultValues == null)
            {
                var defaults = Database.From<TreeDefaultValueDO>().Read().ToList();
                this.TreeDefaultValues = new FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO>(defaults);
            }
        }


        #region VolumeEQs

        public void HandleVolumeEquLoad()
        {
            if (this.VolumeEQs == null)
            {
                List<VolumeEquationDO> volumeEQs = Database.From<VolumeEquationDO>()
                    .Read().ToList();
                VolumeEQs = new BindingList<VolumeEquationDO>(volumeEQs);
            }
        }

        public void AddVolumeEquation()
        {
            VolumeEQs.Add(new VolumeEquationDO(Database));
        }

        public void DeleteVolumeEquation(VolumeEquationDO volumeEquation)
        {
            if(volumeEquation == null) { throw new ArgumentNullException(nameof(volumeEquation)); }

            VolumeEQs.Remove(volumeEquation);
            volumeEquation.Delete();
        }

        #endregion VolumeEQs 

        #region reports
        public void HandleReportsLoad()
        {
            if (this.Reports == null)
            {
                List<ReportsDO> reports = Database.From<ReportsDO>()
                    .Read().ToList();
                this.Reports = new BindingList<ReportsDO>(reports);
            }
        }


        #endregion reports

        #region TreeAudits
        public void HandleTreeAuditsLoad()
        {
            if (this.TreeDefaultValues == null)
            {
                List<TreeDefaultValueDO> defaults = Database.From<TreeDefaultValueDO>()
                    .Read().ToList();
                this.TreeDefaultValues = new FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO>(defaults);
            }

            if (TreeAudits == null)
            {
                this.TreeAudits = Database.From<TreeAuditValueDO>().OrderBy("Field")
                    .Read().ToList();
            }
        }

        public TreeAuditValueDO MakeTreeAudit()
        {
            return new TreeAuditValueDO(Database);
        }

        public void DeleteTreeAudit(TreeAuditValueDO tav)
        {
            if(tav.IsPersisted)
            {
                Database.Delete(tav);
                TreeAudits.Remove(tav);
            }
        }

        #endregion TreeAudits

        private void TreeDefaults_ItemRemoved(object sender, FMSC.Utility.Collections.ItemRemovedEventArgs e)
        {
            TreeDefaultValueDO rTDV = e.Item as TreeDefaultValueDO;
            if (rTDV != null)
            {
                //this._toBeDeletedTreeDefaults.Add(rTDV);
                rTDV.Delete();
            }
        }

        public List<TreeFieldSetupDefaultDO> GetSelectedTreeFields(CruiseMethodsDO method)
        {
            return Database.From<TreeFieldSetupDefaultDO>()
                .Where("Method = ?").OrderBy("FieldOrder")
                .Read(method.Code).ToList();
        }

        public List<LogFieldSetupDefaultDO> GetSelectedLogFields()
        {
            return Database.From<LogFieldSetupDefaultDO>()
                .OrderBy("FieldOrder").Read().ToList();
        }

        public void Save()
        {
            //foreach(TreeDefaultValueDO tdv in _toBeDeletedTreeDefaults)
            //{
            //    tdv.Delete();
            //}
            //_toBeDeletedTreeDefaults.Clear();

            if (CruiseMethods != null)
            {
                foreach (EditTemplateCruiseMethod method in CruiseMethods)
                {
                    foreach (TreeFieldSetupDefaultDO tfs in method.UnselectedTreeFields)
                    {
                        if (tfs.IsPersisted == true)
                        {
                            tfs.Delete();
                        }
                    }

                    foreach (TreeFieldSetupDefaultDO tfs in method.TreeFields)
                    {
                        if (tfs.DAL == null || tfs.IsPersisted == false)
                        {
                            tfs.DAL = Database;
                            tfs.Method = method.CruiseMethod.Code;
                            tfs.Save();
                        }
                        else if (tfs.IsChanged == true)
                        {
                            tfs.Save();
                        }
                    }
                }
            }

            foreach (LogFieldSetupDefaultDO lfs in UnselectedLogFields)
            {
                if (lfs.IsPersisted == true)
                {
                    lfs.Delete();
                }
            }

            foreach (LogFieldSetupDefaultDO lfs in SelectedLogFields)
            {
                if (lfs.DAL == null || lfs.IsPersisted == false)
                {
                    lfs.DAL = Database;
                    //lfs.Method = method.CruiseMethod.Code;
                    lfs.Save(OnConflictOption.Ignore);
                }
                else if (lfs.IsChanged == true)
                {
                    lfs.Save();
                }
            }

            if (TreeDefaultValues != null)
            {
                foreach (TreeDefaultValueDO tdv in TreeDefaultValues)
                {
                    if (tdv.DAL == null)
                    {
                        tdv.DAL = Database;
                    }
                    tdv.Save();
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
                foreach (VolumeEquationDO volEQ in VolumeEQs)
                {
                    if (volEQ.DAL == null)
                    {
                        volEQ.DAL = Database;
                    }
                    volEQ.Save();
                }
            }

            if (Reports != null)
            {
                foreach (ReportsDO report in Reports)
                {
                    if (report.DAL == null)
                    {
                        report.DAL = Database;
                    }
                    report.Save();
                }
            }

            if (TreeAudits != null)
            {
                foreach (TreeAuditValueDO tav in TreeAudits)
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
                return true;
                //TODO
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

        public static TreeFieldDefaultComparer GetInstance()
        {
            if (_instance == null) { _instance = new TreeFieldDefaultComparer(); }
            return _instance;
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

        public static LogFieldDefaultComparer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LogFieldDefaultComparer();
            }
            return _instance;
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