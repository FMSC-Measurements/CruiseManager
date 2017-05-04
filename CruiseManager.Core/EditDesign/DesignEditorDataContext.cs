using CruiseDAL.DataObjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace CruiseManager.Core.EditDesign
{
    public class DesignEditorDataContext
    {
        private List<CuttingUnitDO> _ToBeDeletedCuttingUnits = new List<CuttingUnitDO>();
        private List<DesignEditorStratum> _ToBeDeletedStrata = new List<DesignEditorStratum>();
        private List<DesignEditorSampleGroup> _ToBeDeletedSampleGroups = new List<DesignEditorSampleGroup>();
        private List<TreeDefaultValueDO> _ToBeDelectedTreeDefaults = new List<TreeDefaultValueDO>();

        private bool _hasUnsavedChanges;

        public bool HasUnsavedChanges
        {
            get
            {
                return _hasUnsavedChanges ||
                    (_ToBeDeletedCuttingUnits.Count > 0) ||
                    (_ToBeDeletedSampleGroups.Count > 0) ||
                    (_ToBeDeletedStrata.Count > 0);
            }
            set
            {
                _hasUnsavedChanges = value;
            }
        }

        private SaleDO _Sale;

        public SaleDO Sale
        {
            get { return _Sale; }
            set
            {
                //remove old property changed listener
                if (_Sale != null && !object.ReferenceEquals(_Sale, value))
                {
                    _Sale.PropertyChanged -= Sale_PropertyChanged;
                }
                //add a property changed listener
                if (value != null && !object.ReferenceEquals(_Sale, value))
                {
                    value.PropertyChanged += new PropertyChangedEventHandler(Sale_PropertyChanged);
                }

                _Sale = value;
            }
        }

        public BindingList<CuttingUnitDO> CuttingUnits { get; set; }
        public BindingList<DesignEditorStratum> Strata { get; set; }
        public BindingList<DesignEditorSampleGroup> SampleGroups { get; set; }

        public List<CuttingUnitDO> DeletedCuttingUnits
        {
            get
            {
                return _ToBeDeletedCuttingUnits;
            }
        }

        public List<DesignEditorStratum> DeletedStrata
        {
            get
            {
                return _ToBeDeletedStrata;
            }
        }

        public List<DesignEditorSampleGroup> DeletedSampleGroups
        {
            get
            {
                return _ToBeDeletedSampleGroups;
            }
        }

        public List<TreeDefaultValueDO> DeletedTreeDefaults
        {
            get
            {
                return _ToBeDelectedTreeDefaults;
            }
        }

        private BindingList<CuttingUnitDO> _AllCuttingUnits;

        public BindingList<CuttingUnitDO> AllCuttingUnits
        {
            get { return _AllCuttingUnits; }
            set
            {
                if (_AllCuttingUnits != null && !object.ReferenceEquals(_AllCuttingUnits, value))
                {
                    _AllCuttingUnits.ListChanged -= DataPropertyChanged;
                }
                if (value != null && !object.ReferenceEquals(_AllCuttingUnits, value))
                {
                    value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
                }

                _AllCuttingUnits = value;
            }
        }

        private BindingList<DesignEditorStratum> _AllStrata;

        public BindingList<DesignEditorStratum> AllStrata
        {
            get { return _AllStrata; }
            set
            {
                if (_AllStrata != null && !object.ReferenceEquals(_AllStrata, value))
                {
                    _AllStrata.ListChanged -= DataPropertyChanged;
                }
                if (value != null && !object.ReferenceEquals(_AllStrata, value))
                {
                    value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
                }

                _AllStrata = value;
            }
        }

        public BindingList<DesignEditorSampleGroup> _AllSampleGroups;

        public BindingList<DesignEditorSampleGroup> AllSampleGroups
        {
            get { return _AllSampleGroups; }
            set
            {
                if (_AllSampleGroups != null && !object.ReferenceEquals(_AllSampleGroups, value))
                {
                    _AllSampleGroups.ListChanged -= DataPropertyChanged;
                }
                if (value != null && !object.ReferenceEquals(_AllSampleGroups, value))
                {
                    value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
                }

                _AllSampleGroups = value;
            }
        }

        public BindingList<CuttingUnitDO> CuttingUnitFilterSelectionList { get; set; }
        public BindingList<DesignEditorStratum> StrataFilterSelectionList { get; set; }

        private BindingList<TreeDefaultValueDO> _allTreeDefaults;

        public BindingList<TreeDefaultValueDO> AllTreeDefaults
        {
            get { return _allTreeDefaults; }
            set
            {
                if (_allTreeDefaults != null && !object.ReferenceEquals(_allTreeDefaults, value))
                {
                    _allTreeDefaults.ListChanged -= DataPropertyChanged;
                }
                if (value != null && !object.ReferenceEquals(_allTreeDefaults, value))
                {
                    value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
                }

                _allTreeDefaults = value;
            }
        }

        public void OnDataModified()
        {
            HasUnsavedChanges = true;
        }

        private void Sale_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnDataModified();
        }

        private void DataPropertyChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded)
            {
                OnDataModified();
            }
        }
    }
}