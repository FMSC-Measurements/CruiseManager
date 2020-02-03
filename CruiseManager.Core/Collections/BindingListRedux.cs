using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FMSC.Utility.Collections
{
    public class ItemRemovedEventArgs : EventArgs
    {
        public Object Item { get; set; }

        public ItemRemovedEventArgs(Object item)
        {
            this.Item = item;
        }

    }

    public delegate void ItemRmoveEventHandler(Object sender, ItemRemovedEventArgs e);


    public class BindingListRedux<T> : BindingList<T>
    {


        public BindingListRedux() : base() { }

        public BindingListRedux(IList<T> list) : base(list) { }

        public event ItemRmoveEventHandler ItemRemoved;

        protected void OnItemRemoved(ItemRemovedEventArgs e)
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, e);
            }
        }

        protected override void RemoveItem(int index)
        {
            Object item = base[index];
            base.RemoveItem(index);
            this.OnItemRemoved(new ItemRemovedEventArgs(item));
        }

        
    }
}
