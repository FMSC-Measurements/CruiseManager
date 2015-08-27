using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL.DataObjects;
using CruiseDAL;
using CruiseDAL.Schema;
using System.ComponentModel;
using CSM.Utility.Setup;

namespace CSM.UI.SetupEditor
{
    public class SetupPresenter 
    {
        public WindowPresenter WindowPresenter { get; set; }


        //what is to become of this class 
        //there needs to be a way to edit the tree field order 
        //for a cruise that has already been established
        //but this form causes confusion 
        //i dont think it will be obvious enought to the user 
        //that this screen only adjusts the tree field setup for the setup file 
        //
        public SetupPresenter()
        {

            CruiseMethods = _setupServ.GetCruiseMethods();
            LoggingMethods = _setupServ.GetLoggingMethods();
            ProductCodes = _setupServ.GetProductCodes();
            UOMCodes = _setupServ.GetUOMCodes();
            Regions = _setupServ.GetRegions();

            SelectedLogFieldSetups = new BindingList<LogFieldSetupDO>();
            SelectedTreeFieldSetups = new BindingList<TreeFieldSetupDO>();
            AvalableLogFieldSetups = new BindingList<LogFieldSetupDO>();
            AvalableTreeFieldSetups = new BindingList<TreeFieldSetupDO>();

            allLogFields = _setupServ.GetLogFieldSetups();
            allTreeFields = _setupServ.GetTreeFieldSetups();
        }

        public SetupView View { get; set; }

        public bool IsSupervisor { get; set; }

        private SetupService _setupServ = CSM.Utility.Setup.SetupService.GetHandle();
        //private CruiseMethodCollection _CruiseMethCollection;
        public List<LoggingMethod> LoggingMethods { get; set; }
        public List<ProductCode> ProductCodes { get; set; }
        public List<UOMCode> UOMCodes { get; set; }
        public List<Region> Regions { get; set; }
        public List<CruiseMethod> CruiseMethods { get; set; }


        private List<LogFieldSetupDO> allLogFields;
        private List<TreeFieldSetupDO> allTreeFields;

        public BindingList<TreeFieldSetupDO> SelectedTreeFieldSetups { get; private set; }
        public BindingList<TreeFieldSetupDO> AvalableTreeFieldSetups { get; private set; }
        public BindingList<LogFieldSetupDO> SelectedLogFieldSetups { get; private set; }
        public BindingList<LogFieldSetupDO> AvalableLogFieldSetups { get; private set; }


        private CruiseMethod _PreviousCruiseMethod;

        private CruiseMethod _CurrentCruiseMethod;
        public CruiseMethod CurrentCruiseMethod
        {
            get { return _CurrentCruiseMethod; }
            set
            {
                
                _PreviousCruiseMethod = _CurrentCruiseMethod;
                _CurrentCruiseMethod = value;
                OnCurrentCruiseMethodChanged();
            }
        }

        private void OnCurrentCruiseMethodChanged()
        {
            
            if (_PreviousCruiseMethod != null)
            {
                _PreviousCruiseMethod.TreeFieldSetups = SelectedTreeFieldSetups.ToList();
                _PreviousCruiseMethod.LogFieldSetups = SelectedLogFieldSetups.ToList();
            }
            
            SelectedTreeFieldSetups = new BindingList<TreeFieldSetupDO>(CurrentCruiseMethod.TreeFieldSetups);
            SelectedLogFieldSetups = new BindingList<LogFieldSetupDO>(CurrentCruiseMethod.LogFieldSetups);

            AvalableLogFieldSetups = new BindingList<LogFieldSetupDO>(
                allLogFields.Except(SelectedLogFieldSetups, new LogFieldComparer()).ToList());

            AvalableTreeFieldSetups = new BindingList<TreeFieldSetupDO>(
                allTreeFields.Except(SelectedTreeFieldSetups, new TreeFieldComparer()).ToList());

            if (View != null) 
            { 
                View.ResetFieldSelectors();
            }
        }


        public void Save()
        {
            //for (int i = 0; i < SelectedTreeFieldSetups.Count; i++)
            //{
            //    SelectedTreeFieldSetups[i].FieldOrder = i + 1; //+ 1, because 0 represents a hidden field
            //}

            //for (int i = 0; i < SelectedLogFieldSetups.Count; i++)
            //{
            //    SelectedLogFieldSetups[i].FieldOrder = i + 1; //+ 1, because 0 represents a hidden field
            //}

            _setupServ.SaveCruiseMethods(CruiseMethods);
            _setupServ.SaveLoggingMethods(LoggingMethods);
            _setupServ.SaveProductCodes(ProductCodes);
            _setupServ.SaveUOMCodes(UOMCodes);
            _setupServ.SaveRegions(Regions);
        }

        public void RemoveCruiseMethod(CruiseMethod value)
        {

        }

        class TreeFieldComparer : IEqualityComparer<TreeFieldSetupDO>
        {
            #region IEqualityComparer<TreeFieldSetupDO> Members

            public bool Equals(TreeFieldSetupDO x, TreeFieldSetupDO y)
            {
                return x.Field == y.Field;
            }

            public int GetHashCode(TreeFieldSetupDO obj)
            {
                return obj.Field.GetHashCode();
            }

            #endregion
        }

        class LogFieldComparer : IEqualityComparer<LogFieldSetupDO>
        {
            #region IEqualityComparer<LogFieldSetupDO> Members

            public bool Equals(LogFieldSetupDO x, LogFieldSetupDO y)
            {
                return x.Field == y.Field;
            }

            public int GetHashCode(LogFieldSetupDO obj)
            {
                return obj.Field.GetHashCode();
            }

            #endregion
        }
    }
}
