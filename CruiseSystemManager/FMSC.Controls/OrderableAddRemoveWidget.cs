using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Design;

namespace FMSC.Controls
{
    [LookupBindingProperties("DataSource", "DisplayMember","ValueMember", "SelectedValue")]
    public partial class OrderableAddRemoveWidget : UserControl
    {
        public OrderableAddRemoveWidget()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public event ItemMovedEventHandler SelectionMoved;

        [Browsable(true)]
        public event SelectionAddedEventHandler SelectionAdded;

        [Browsable(true)]
        public event SelectionRemovedEventHandler SelectionRemoved;

        
        //private object _dataSource;
        private CurrencyManager _CurrencyManager;
        [Category("Data")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(null)]
        [AttributeProvider(typeof(IListSource))]
        public Object DataSource
        {
            get
            {
                return this.AvailableListBox.DataSource;
            }
            set
            {
                this.AvailableListBox.DataSource = value;
                if (value == null) { return; }
                this._CurrencyManager = this.AvailableListBox.BindingContext[DataSource] as CurrencyManager;
            }
        }


        //private object _selectedItemsDataSource;
        private CurrencyManager _selectedItemsCurrencyManager;
        public object SelectedItemsDataSource
        {
            get
            {
                return this.SelectedListBox.DataSource;
            }

            set
            {
                this.SelectedListBox.DataSource = value;
                if (value == null) { return; }
                this._selectedItemsCurrencyManager = this.SelectedListBox.BindingContext[SelectedItemsDataSource] as CurrencyManager;
            }
        }


        private string _displayMember;
        [Category("Data")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        public string DisplayMember
        {
            get { return _displayMember; }
            set 
            { 
                _displayMember = value;
                this.SelectedListBox.DisplayMember = value;
                this.AvailableListBox.DisplayMember = value;
            }
        }

        private string _ValueMember;
        [Category("Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get
            {
                return _ValueMember;
            }
            set
            {
                _ValueMember = value;
                this.SelectedListBox.ValueMember = value;
                this.AvailableListBox.ValueMember = value;
            }
        }

        public object SelectedValue
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        private void AddAllButton_Click(object sender, EventArgs e)
        {
            IList list = this._CurrencyManager.List;
            IList selList = this._selectedItemsCurrencyManager.List;
            foreach (object obj in list)
            {
                selList.Add(obj);
                OnSelectionAdded(this, obj, selList.Count - 1);
            }
            list.Clear();
            RefreshBindings();
        }

        private void RemoveAllButton_Click(object sender, EventArgs e)
        {
            IList selList = this._selectedItemsCurrencyManager.List;
            IList list = this._CurrencyManager.List;
            foreach (object obj in selList)
            {
                list.Add(obj);
                OnSelectionRemoved(this, obj);
            }
            selList.Clear();
            RefreshBindings();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            object obj = this._CurrencyManager.Current;
            IList selList = this._selectedItemsCurrencyManager.List;
            IList list = this._CurrencyManager.List;
            selList.Add(obj);
            list.Remove(obj);
            RefreshBindings();
            OnSelectionAdded(this, obj, selList.Count - 1);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            object obj = this._selectedItemsCurrencyManager.Current;
            IList list = this._CurrencyManager.List;
            IList selList = this._selectedItemsCurrencyManager.List;
            list.Add(obj);
            selList.Remove(obj);
            RefreshBindings();
            OnSelectionRemoved(this, obj);
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            IList list = this._selectedItemsCurrencyManager.List;
            object item = this._selectedItemsCurrencyManager.Current;
            int index = this._selectedItemsCurrencyManager.Position;
            if (index > 0)
            {
                int newIndex = index - 1;
                Swap(list, index, newIndex);
                this._selectedItemsCurrencyManager.Position = newIndex;
                RefreshBindings();
                OnSelectionMoved(new ItemMovedEventArgs
                { 
                    Direction = Direction.UP, 
                    Item = item, 
                    NewIndex = newIndex, 
                    PreviousIndex = index 
                } );
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            IList list = this._selectedItemsCurrencyManager.List;
            object item = this._selectedItemsCurrencyManager.Current;
            int index = list.IndexOf(item);
            if (index < list.Count - 1)
            {
                int newIndex = index + 1;
                Swap(list, index, newIndex);
                this._selectedItemsCurrencyManager.Position = newIndex;
                RefreshBindings();
                OnSelectionMoved(new ItemMovedEventArgs
                { 
                    Direction = Direction.DOWN, 
                    Item = item, 
                    NewIndex = newIndex, 
                    PreviousIndex = index 
                });
            }
        }

        protected void RefreshBindings()
        {
            _CurrencyManager.Refresh();
            _selectedItemsCurrencyManager.Refresh();
        }


        protected void OnSelectionMoved(ItemMovedEventArgs e)
        {
            if(SelectionMoved != null)
            {
                SelectionMoved(this, e);
            }
        }

         protected void OnSelectionAdded(object sender, object item, int index)
        {
            if(SelectionAdded != null)
            {
                SelectionAdded(this, item, index);
            }
        }

        protected void OnSelectionRemoved(object sender, object item)
        {
            if(SelectionRemoved != null)
            {
                SelectionRemoved(this, item);
            }
        }

        private static void Swap(IList list, int i, int j)
        {
            object temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        

    }

    public delegate void ItemMovedEventHandler(object sender, ItemMovedEventArgs e);

    public delegate void SelectionAddedEventHandler(object sender, object item, int index);

    public delegate void SelectionRemovedEventHandler(object sender, object item); 

    public enum Direction { UP, DOWN };

    public class ItemMovedEventArgs : EventArgs
    {
        public Direction Direction { get; set; }
        public object Item { get; set; }
        public int NewIndex { get; set; }
        public int PreviousIndex { get; set; }
    }
    
}
