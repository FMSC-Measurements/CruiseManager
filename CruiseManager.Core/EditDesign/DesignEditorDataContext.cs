using System.Collections.Generic;
using System.ComponentModel;
using CruiseDAL.DataObjects;
using CruiseManager.Core.Collections;
using System.Linq;
using CruiseManager.Core.Models;

namespace CruiseManager.Core.EditDesign
{
    public class DesignEditorDataContext
    {
        public bool HasUnsavedChanges
        {
            get
            {
                return Sale.HasChanges
                    || CuttingUnits.HasUnpersistedItems
                    || Strata.HasUnpersistedItems
                    || SampleGroups.HasUnpersistedItems
                    || TreeDefaults.HasUnpersistedItems;
            }

        }

        public SaleVM Sale { get; set; }


        public DataObjectCollection<CuttingUnitDO> CuttingUnits { get; set; }
        public DataObjectCollection<DesignEditorStratum> Strata { get; set; }
        public DataObjectCollection<SampleGroupDO> SampleGroups { get; set; }
        public DataObjectCollection<TreeDefaultValueDO> TreeDefaults { get; set; }
        //public DataObjectCollection<PlotDO> Plots { get; set; }

        public IEnumerable<string> GetCuttingUnitFilterOptions()
        {
            return (new string[] { string.Empty }).Union(
                from unit in CuttingUnits.Items select unit.Code);
        }

        public IEnumerable<string> GetStrataFilterOptions()
        {
            return (new string[] { string.Empty }).Union(
                from stratum in Strata.Items select stratum.Code);
        }

        public IEnumerable<string> GetSampleGroupFilterOptions()
        {
            return (new string[] { string.Empty }).Union(
                from sg in SampleGroups.Items select sg.Code);
        }

        //public IEnumerable<CuttingUnitDO> GetFilteredCuttingUnits(string stratumCode)
        //{
        //    if(string.IsNullOrEmpty(stratumCode))
        //    {
        //        return CuttingUnits.Items;
        //    }

        //    return (from stratum in Strata.Items
        //            where stratum.Code == stratumCode
        //            select stratum).First().CuttingUnits;
        //}

        //public IEnumerable<DesignEditorStratum> GetFilteredStrata(string cuttingUnitCode)
        //{

        //}

        public DesignEditorStratum GetStratumByCode(string code)
        {
            return (from st in Strata.Items
                    where st.Code == code
                    select st).FirstOrDefault();
        }

        public IEnumerable<SampleGroupDO> GetFilteredSampleGroups(string stratumCode)
        {
            return (from st in Strata.Items
                    where st.Code == stratumCode
                    select st.SampleGroups).FirstOrDefault();
        }



        //private List<CuttingUnitDO> _ToBeDeletedCuttingUnits = new List<CuttingUnitDO>();
        //private List<DesignEditorStratum> _ToBeDeletedStrata = new List<DesignEditorStratum>();
        //private List<SampleGroupDO> _ToBeDeletedSampleGroups = new List<SampleGroupDO>();
        //private List<TreeDefaultValueDO> _ToBeDelectedTreeDefaults = new List<TreeDefaultValueDO>();

        //private bool _hasUnsavedChanges = false;
        //public bool HasUnsavedChanges
        //{
        //    get
        //    {
        //        return _hasUnsavedChanges ||
        //            (_ToBeDeletedCuttingUnits.Count > 0) ||
        //            (_ToBeDeletedSampleGroups.Count > 0) ||
        //            (_ToBeDeletedStrata.Count > 0);
        //    }
        //    set
        //    {
        //        _hasUnsavedChanges = value;
        //    }
        //}


        //private SaleDO _Sale;
        //public SaleDO Sale
        //{
        //    get { return _Sale; }
        //    set
        //    {
        //        //remove old proerty changed listener
        //        if (_Sale != null && !object.ReferenceEquals(_Sale, value))
        //        {
        //            _Sale.PropertyChanged -= Sale_PropertyChanged;
        //        }
        //        //add a property changed listener 
        //        if (value != null && !object.ReferenceEquals(_Sale, value))
        //        {
        //            value.PropertyChanged += new PropertyChangedEventHandler(Sale_PropertyChanged);
        //        }

        //        _Sale = value;
        //    }
        //}





        //private BindingList<CuttingUnitDO> _AllCuttingUnits;
        //public BindingList<CuttingUnitDO> AllCuttingUnits
        //{
        //    get { return _AllCuttingUnits; }
        //    set
        //    {
        //        if (_AllCuttingUnits != null && !object.ReferenceEquals(_AllCuttingUnits, value))
        //        {
        //            _AllCuttingUnits.ListChanged -= DataPropertyChanged;
        //        }
        //        if (value != null && !object.ReferenceEquals(_AllCuttingUnits, value))
        //        {
        //            value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
        //        }

        //        _AllCuttingUnits = value;
        //    }
        //}

        //private BindingList<DesignEditorStratum> _AllStrata;
        //public BindingList<DesignEditorStratum> AllStrata
        //{
        //    get { return _AllStrata; }
        //    set
        //    {
        //        if (_AllStrata != null && !object.ReferenceEquals(_AllStrata, value))
        //        {
        //            _AllStrata.ListChanged -= DataPropertyChanged;
        //        }
        //        if (value != null && !object.ReferenceEquals(_AllStrata, value))
        //        {
        //            value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
        //        }

        //        _AllStrata = value;
        //    }
        //}

        //public BindingList<SampleGroupDO> _AllSampleGroups;
        //public BindingList<SampleGroupDO> AllSampleGroups
        //{
        //    get { return _AllSampleGroups; }
        //    set
        //    {
        //        if (_AllSampleGroups != null && !object.ReferenceEquals(_AllSampleGroups, value))
        //        {
        //            _AllSampleGroups.ListChanged -= DataPropertyChanged;
        //        }
        //        if (value != null && !object.ReferenceEquals(_AllSampleGroups, value))
        //        {
        //            value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
        //        }

        //        _AllSampleGroups = value;
        //    }
        //}

        //public BindingList<CuttingUnitDO> CuttingUnitFilterSelectionList { get; set; }
        //public BindingList<DesignEditorStratum> StrataFilterSelectionList { get; set; }



        //private BindingList<TreeDefaultValueDO> _allTreeDefaults;
        //public BindingList<TreeDefaultValueDO> AllTreeDefaults
        //{
        //    get { return _allTreeDefaults; }
        //    set
        //    {
        //        if (_allTreeDefaults != null && !object.ReferenceEquals(_allTreeDefaults, value))
        //        {
        //            _allTreeDefaults.ListChanged -= DataPropertyChanged;
        //        }
        //        if (value != null && !object.ReferenceEquals(_allTreeDefaults, value))
        //        {
        //            value.ListChanged += new ListChangedEventHandler(DataPropertyChanged);
        //        }

        //        _allTreeDefaults = value;
        //    }
        //}

        //public void OnDataModified()
        //{
        //    HasUnsavedChanges = true;
        //}

        //private void Sale_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    OnDataModified();
        //}

        //private void DataPropertyChanged(object sender, ListChangedEventArgs e)
        //{
        //    if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded)
        //    {
        //        OnDataModified();
        //    }
        //}


    }
}
