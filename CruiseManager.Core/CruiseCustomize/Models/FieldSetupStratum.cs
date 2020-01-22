using Backpack.SqlBuilder;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace CruiseManager.Core.CruiseCustomize
{
    public class FieldSetupStratum : StratumDO
    {
        private bool _hasEdits;
        private ObservableCollection<TreeFieldSetupDO> _selectedTreeFields;
        private ObservableCollection<LogFieldSetupDO> _selectedLogFields;

        public string FriendlyStr
        {
            get
            {
                return ToString();
            }
        }

        public ObservableCollection<TreeFieldSetupDO> SelectedTreeFields
        {
            get { return _selectedTreeFields; }
            set
            {
                if (_selectedTreeFields != null) { _selectedTreeFields.CollectionChanged -= this.FieldCollectionChanged; }
                if (value != null) { value.CollectionChanged += this.FieldCollectionChanged; }
                _selectedTreeFields = value;
            }
        }

        public ObservableCollection<LogFieldSetupDO> SelectedLogFields
        {
            get { return _selectedLogFields; }
            set
            {
                if (_selectedLogFields != null) { _selectedLogFields.CollectionChanged -= this.FieldCollectionChanged; }
                if (value != null) { value.CollectionChanged += this.FieldCollectionChanged; }
                _selectedLogFields = value;
            }
        }

        public List<TreeFieldSetupDO> UnselectedTreeFields { get; set; }
        public List<LogFieldSetupDO> UnselectedLogFields { get; set; }

        [IgnoreField]
        public bool HasEdits
        {
            get
            {
                return _hasEdits
                    || SelectedTreeFields.Any(x => x.IsChanged)
                    || SelectedLogFields.Any(x => x.IsChanged)
                    || UnselectedTreeFields.Any(x => x.IsPersisted)
                    || UnselectedLogFields.Any(x => x.IsPersisted);
            }
            protected set
            {
                _hasEdits = value;
            }
        }

        public IEnumerable<TreeFieldSetupDO> GetSelectedTreeFields()
        {
            return this.DAL.From<TreeFieldSetupDO>().Where("Stratum_CN = @p1")
                .OrderBy("FieldOrder").Query(Stratum_CN);
        }

        public IEnumerable<TreeFieldSetupDO> GetSelectedTreeFieldsDefault()
        {
            //select from TreeFieldSetupDefault where method = stratum.method
            var treeFieldDefaults = this.DAL.From<TreeFieldSetupDefaultDO>()
                .Where("Method = @p1")
                .OrderBy("FieldOrder")
                .Query(Method);

            foreach (var tfd in treeFieldDefaults)
            {
                var tfs = new TreeFieldSetupDO();
                tfs.Stratum_CN = Stratum_CN;
                tfs.Field = tfd.Field;
                tfs.FieldOrder = tfd.FieldOrder;
                tfs.ColumnType = tfd.ColumnType;
                tfs.Heading = tfd.Heading;
                tfs.Width = tfd.Width;
                tfs.Format = tfd.Format;
                tfs.Behavior = tfd.Behavior;

                yield return tfs;
            }
        }

        public IEnumerable<LogFieldSetupDO> GetSelectedLogFields()
        {
            return this.DAL.From<LogFieldSetupDO>().Where("Stratum_CN = @p1")
                .OrderBy("FieldOrder").Query(Stratum_CN);
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

        public void SaveFieldSetup()
        {
            //ensure all unselected tree fields are removed
            foreach (TreeFieldSetupDO tf in UnselectedTreeFields)
            {
                if (tf.IsPersisted == true)
                {
                    tf.Delete();
                }
            }

            //ensure all unselected log fields are removed
            foreach (LogFieldSetupDO lf in UnselectedLogFields)
            {
                if (lf.IsPersisted == true)
                {
                    lf.Delete();
                }
            }

            foreach (TreeFieldSetupDO tf in SelectedTreeFields)
            {
                if (tf.IsPersisted == false)
                {
                    tf.DAL = this.DAL;
                    tf.Stratum = this;
                }
                tf.Save();
            }
            foreach (LogFieldSetupDO lf in SelectedLogFields)
            {
                if (lf.IsPersisted == false)
                {
                    lf.DAL = this.DAL;
                    lf.Stratum = this;
                }
                lf.Save();
            }
        }

        public override string ToString()
        {
            return Code + " - " + Method;
        }
    }
}