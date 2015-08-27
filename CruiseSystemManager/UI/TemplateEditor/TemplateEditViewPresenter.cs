﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using System.ComponentModel;
using CSM.Logic;
using System.Windows.Forms;
using CruiseDAL;

namespace CSM.UI.TemplateEditor
{

    public class CruiseMethodViewModel
    {
        public CruiseMethodViewModel(CruiseMethodsDO method)
        {
            this.CruiseMethod = method;
        }

        public CruiseMethodsDO CruiseMethod { get; set; }
        public BindingList<TreeFieldSetupDefaultDO> TreeFields { get; set; }
        public BindingList<TreeFieldSetupDefaultDO> UnselectedTreeFields { get; set; }

        public override string ToString()
        {
            return CruiseMethod.Code;
        }
    }



    public class TemplateEditViewPresenter : IPresentor
    {
        private FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO> _treeDefaultValues;
        //private List<TreeDefaultValueDO> _toBeDeletedTreeDefaults = new List<TreeDefaultValueDO>();

        public IWindowPresenter Controller { get; set; }
        public TemplateEditViewControl View { get; set; }


        public BindingList<CruiseMethodViewModel> CruiseMethods { get; set; }
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


        public TemplateEditViewPresenter(IWindowPresenter controller, TemplateEditViewControl view)
        {
            this.Controller = controller;
            this.View = view;

            //read TreeFiedleSetup info from .setup file and convert the data to TreeFieldSetupDefault
            //it may be posible to simplify this task by asking for the data in the form of a TreeFieldSetupDefault object
            //the xmlSerializer may beable to handle this conversion
            this.TreeFields = new List<TreeFieldSetupDefaultDO>();
            foreach (TreeFieldSetupDO tf in this.Controller.AppState.SetupServ.GetTreeFieldSetups())
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
            foreach(LogFieldSetupDO lf in this.Controller.AppState.SetupServ.GetLogFieldSetups())
            {
                LogFieldSetupDefaultDO newLF = new LogFieldSetupDefaultDO();
                newLF.Field = lf.Field;
                newLF.Heading = lf.Heading; 
                newLF.Format = lf.Format;
                newLF.ColumnType = lf.ColumnType;
                newLF.Behavior = lf.Behavior;

                this.LogFields.Add(newLF);
            }
        }

        /// <summary>
        /// Handels the initialization of the Field setups, creating a list of cruise methods and 
        /// </summary>
        public void HandleFieldSetupLoad()
        {
            //check to see if Cruise method list has been initialized
            if (this.CruiseMethods == null)
            {
                try
                {
                    CruiseMethods = new BindingList<CruiseMethodViewModel>();
                    List<CruiseMethodsDO> methods = this.Controller.Database.Read<CruiseMethodsDO>("CruiseMethods", null);
                    foreach (CruiseMethodsDO method in methods)
                    {
                        CruiseMethodViewModel vm = new CruiseMethodViewModel(method);
                        List<TreeFieldSetupDefaultDO> treeFields = this.Controller.Database.Read<TreeFieldSetupDefaultDO>("TreeFieldSetupDefault", "WHERE Method = ? ORDER BY FieldOrder", method.Code);

                        vm.TreeFields = new BindingList<TreeFieldSetupDefaultDO>(treeFields);


                        List<TreeFieldSetupDefaultDO> unselectedTreeFields = (from tfs in this.TreeFields.Except(treeFields, new CSM.Logic.TypeComparers.TreeFieldDefaultComparer()) 
                                                                              select new TreeFieldSetupDefaultDO(tfs)).ToList();



                        vm.UnselectedTreeFields = new BindingList<TreeFieldSetupDefaultDO>(unselectedTreeFields);

                        CruiseMethods.Add(vm);
                    }
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
                    List<LogFieldSetupDefaultDO> logFields = this.Controller.Database.Read<LogFieldSetupDefaultDO>("LogFieldSetupDefault", "ORDER BY FieldOrder");
                    SelectedLogFields = new BindingList<LogFieldSetupDefaultDO>(logFields);
                    List<LogFieldSetupDefaultDO> unselectedLogFields = (from lfs in this.LogFields.Except(logFields, new CSM.Logic.TypeComparers.LogFieldDefaultComparer()) 
                                                                        select new LogFieldSetupDefaultDO(lfs)).ToList();
                    UnselectedLogFields = new BindingList<LogFieldSetupDefaultDO>(unselectedLogFields);
                }
                catch
                {
                    this.SelectedLogFields = null;
                }

                this.View.UpdateFieldSetup();
            }
        }

        public void HandleTreeDefaultsLoad()
        {
            if (this.TreeDefaultValues == null)
            {
                List<TreeDefaultValueDO> defaults = this.Controller.Database.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
                this.TreeDefaultValues = new FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO>(defaults);
            }

            this.View.UpdateTreeDefaults();
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
            if (this.VolumeEQs == null)
            {
                List<VolumeEquationDO> volumeEQs = this.Controller.Database.Read<VolumeEquationDO>("VolumeEquation", null);
                this.VolumeEQs = new BindingList<VolumeEquationDO>(volumeEQs);
                this.View.UpdateVolumeEqs();
            }
        }

        public void HandleReportsLoad()
        {
            if (this.Reports == null)
            {
                List<ReportsDO> reports = this.Controller.Database.Read<ReportsDO>("Reports", null);
                this.Reports = new BindingList<ReportsDO>(reports);
                this.View.UpdateReports();
            }
        }

        public void HandleTreeAuditsLoad()
        {
            if (this.TreeDefaultValues == null)
            {
                List<TreeDefaultValueDO> defaults = this.Controller.Database.Read<TreeDefaultValueDO>("TreeDefaultValue", null);
                this.TreeDefaultValues = new FMSC.Utility.Collections.BindingListRedux<TreeDefaultValueDO>(defaults);
            }

            if (TreeAudits == null)
            {
                this.TreeAudits = this.Controller.Database.Read<TreeAuditValueDO>("TreeAuditValue", "Order By Field");
            }

            this.View.UpdateTreeAudit();
        }

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
           return this.Controller.Database.Read<TreeFieldSetupDefaultDO>("TreeFieldSetupDefault", "WHERE Method = ? ORDER BY FieldOrder", method.Code);
        }

        public List<LogFieldSetupDefaultDO> GetSelectedLogFields()
        {
            return this.Controller.Database.Read<LogFieldSetupDefaultDO>("LogFieldSetupDefault", "ORDER BY FieldOrder");
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
                foreach (CruiseMethodViewModel method in CruiseMethods)
                {
                    foreach( TreeFieldSetupDefaultDO tfs in method.UnselectedTreeFields)
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
                            tfs.DAL = Controller.Database;
                            tfs.Method = method.CruiseMethod.Code;
                            tfs.Save();
                        }
                        else if (tfs.HasChanges == true)
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
                    lfs.DAL = Controller.Database;
                    //lfs.Method = method.CruiseMethod.Code;
                    lfs.Save(OnConflictOption.Ignore);
                }
                else if( lfs.HasChanges == true)
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
                        tdv.DAL = this.Controller.Database;
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
                        volEQ.DAL = this.Controller.Database;
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
                        report.DAL = this.Controller.Database;
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
                        tav.DAL = this.Controller.Database;
                    }
                    tav.Save();
                    tav.TreeDefaultValues.Save();
                }
            }
        }



        #region ISaveHandler Members

        public void HandleSave()
        {
            this.Save();
        }

        public void HandleAppClosing(object sender, FormClosingEventArgs e)
        {
            this.Save();
        }

        public bool CanHandleSave
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            //Dispose(true);
            //GC.SuppressFinalize(this);
        }

        //protected virtual void Dispose(bool isDisposing)
        //{
        //    UnwireTreeAuditChangedEvents();
        //}

        #endregion

        #region IPresentor Members


        public void UpdateView()
        {
            //do nothing
            //TODO move applicable code here 
        }

        #endregion
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

        #endregion

        #region IComparer<TreeFieldSetupDO> Members

        public int Compare(TreeFieldSetupDefaultDO x, TreeFieldSetupDefaultDO y)
        {
            return string.Compare(x.Field, y.Field);
        }

        #endregion
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

        #endregion

        #region IComparer<LogFieldSetupDO> Members

        public int Compare(LogFieldSetupDefaultDO x, LogFieldSetupDefaultDO y)
        {
            return string.Compare(x.Field, y.Field);
        }

        #endregion
    }
}
