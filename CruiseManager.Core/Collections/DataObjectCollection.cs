using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.Collections
{
    public class DataObjectCollection<T> where T : DataObject
    {
        public List<T> NewItems = new List<T>();
        public List<T> TobeDeleted = new List<T>();
        public List<T> Items;

        public DataObjectCollection()
        {
            this.Items = new List<T>();
        }

        public DataObjectCollection(List<T> items)
        {
            this.Items = items;
        }

        public bool HasUnpersistedItems
        {
            get
            {
                return TobeDeleted.Count > 0 ||
                    NewItems.Count > 0 ||
                    Items.Exists(x => x.IsChanged == true);
            }
        }

        public void Delete(T item)
        {
            if (Items.Remove(item))
            {
                TobeDeleted.Add(item);
            }
            else if(!NewItems.Remove(item))
            {
                throw new NotImplementedException();
            }
        }
    }
}
