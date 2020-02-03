using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Reflection;

namespace FMSC.Utility.Collections
{
    public class SortableBindingList<T> : BindingList<T>
    {
        public class PropertyComparer<G> : IComparer<G>
        {
            private readonly IComparer comparer;
            private PropertyDescriptor propertyDescriptor;
            private int reverse;

            public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
            {
                this.propertyDescriptor = property;
                Type comparerForPropertyType = typeof(Comparer<>).MakeGenericType(property.PropertyType);
                this.comparer = (IComparer)comparerForPropertyType.InvokeMember("Default", BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public, null, null, null);
                this.SetListSortDirection(direction);
            }

            public PropertyComparer(IComparer comparer, ListSortDirection direction)
            {
                this.comparer = comparer;
                this.SetListSortDirection(direction);
            }


            #region IComparer<G> Members

            public int Compare(G x, G y)
            {
                return this.reverse * this.comparer.Compare(this.propertyDescriptor.GetValue(x), this.propertyDescriptor.GetValue(y));
            }

            #endregion

            private void SetPropertyDescriptor(PropertyDescriptor descriptor)
            {
                this.propertyDescriptor = descriptor;
            }

            private void SetListSortDirection(ListSortDirection direction)
            {
                this.reverse = direction == ListSortDirection.Ascending ? 1 : -1;
            }

            public void SetPropertyAndDirection(PropertyDescriptor descriptor, ListSortDirection direction)
            {
                this.SetPropertyDescriptor(descriptor);
                this.SetListSortDirection(direction);
            }
        }

        private readonly Dictionary<string, PropertyComparer<T>> propertyComparers;
        private readonly Dictionary<Type, PropertyComparer<T>> comparers;
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        public SortableBindingList()
            : base(new List<T>())
        {
            this.comparers = new Dictionary<Type, PropertyComparer<T>>();
            this.propertyComparers = new Dictionary<string, PropertyComparer<T>>();
        }

        public SortableBindingList(IEnumerable<T> enumeration)
            : base(new List<T>(enumeration))
        {
            this.comparers = new Dictionary<Type, PropertyComparer<T>>();
            this.propertyComparers = new Dictionary<string, PropertyComparer<T>>();
        }

        public void SetPropertyComparer(String propertyName, IComparer comparer)
        {
            this.propertyComparers[propertyName] = new PropertyComparer<T>(comparer, this.SortDirectionCore);
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return this.isSorted; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return this.propertyDescriptor; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return this.listSortDirection; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)this.Items;

            PropertyComparer<T> comparer;
            Type propertyType = property.PropertyType;
            if (!this.propertyComparers.TryGetValue(property.Name, out comparer) 
               && !this.comparers.TryGetValue(propertyType, out comparer))
            {                
                comparer = new PropertyComparer<T>(property, direction);
                this.comparers.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndDirection(property, direction);
            itemsList.Sort(comparer);

            this.propertyDescriptor = property;
            this.listSortDirection = direction;
            this.isSorted = true;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            this.isSorted = false;
            this.propertyDescriptor = base.SortPropertyCore;
            this.listSortDirection = base.SortDirectionCore;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = this.Count;
            for (int i = 0; i < count; ++i)
            {
                T element = this[i];
                if (property.GetValue(element).Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}