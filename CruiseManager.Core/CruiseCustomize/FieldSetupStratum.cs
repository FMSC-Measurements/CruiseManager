using System.Collections.Generic;
using CruiseDAL.DataObjects;
using CruiseDAL;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;

namespace CruiseManager.Core.CruiseCustomize
{
    public class FieldSetupStratum : CruiseDAL.DataObjects.StratumDO
    {
        private bool _hasEdits;
        private ObservableCollection<TreeFieldSetupDO> _selectedTreeFields;
        private ObservableCollection<LogFieldSetupDO> _selectedLogFields; 

        public ObservableCollection<TreeFieldSetupDO> SelectedTreeFields
        {
            get { return _selectedTreeFields; }
            set
            {
                if(_selectedTreeFields != null) { _selectedTreeFields.CollectionChanged -= this.FieldCollectionChanged; }
                if(value != null) { value.CollectionChanged += this.FieldCollectionChanged; }
                _selectedTreeFields = value;
            }
        }

        public ObservableCollection<LogFieldSetupDO> SelectedLogFields
        {
            get { return _selectedLogFields; }
            set
            {
                if(_selectedLogFields != null) { _selectedLogFields.CollectionChanged -= this.FieldCollectionChanged; }
                if(value != null) { value.CollectionChanged += this.FieldCollectionChanged; }
                _selectedLogFields = value;
            }
        }


        public List<TreeFieldSetupDO> UnselectedTreeFields { get; set; }
        public List<LogFieldSetupDO> UnselectedLogFields { get; set; }

        
        public bool HasEdits
        {
            get
            {
                return _hasEdits 
                    || SelectedTreeFields.Any(x => x.HasChanges)
                    || SelectedLogFields.Any(x => x.HasChanges) 
                    || UnselectedTreeFields.Any( x=> x.IsPersisted)
                    || UnselectedLogFields.Any( x => x.IsPersisted);
            }
            protected set { _hasEdits = value; }
        }

        private void FieldCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.HasEdits = true;
        }

        public override void Save(OnConflictOption option)
        {
            base.Save(option);
            this._hasEdits = false;
        }
       
    }
}
