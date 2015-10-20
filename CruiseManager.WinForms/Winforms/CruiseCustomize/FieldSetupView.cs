using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.CruiseCustomize.ViewInterfaces;
using CruiseDAL.DataObjects;
using System.Linq;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class FieldSetupView : CruiseManager.WinForms.UserControlView, IFieldSetupView
    {
        public FieldSetupView(FieldSetupPresenter presenter)
        {
            this.ViewPresenter = presenter;
            presenter.View = this;
            InitializeComponent();
        }

        public new FieldSetupPresenter ViewPresenter
        {
            get { return (FieldSetupPresenter)base.ViewPresenter; }
            set { base.ViewPresenter = value; }
        }

        public void UpdateFieldSetupViews()
        {
            if (this.ViewPresenter.IsLogGradingEnabled)
            {
                if (!this._fieldSetup_Child_TabControl.TabPages.Contains(this._logField_TabPage))
                {
                    this._fieldSetup_Child_TabControl.TabPages.Add(this._logField_TabPage);
                }
            }
            else
            {
                this._fieldSetup_Child_TabControl.TabPages.Remove(this._logField_TabPage);
            }
            _strataLB.DataSource = ViewPresenter.FieldSetupStrata;
        }

        private void _strataLB_SelectedValueChanged(object sender, EventArgs e)
        {
            FieldSetupStratum stratum = _strataLB.SelectedValue as FieldSetupStratum;
            if (stratum == null) { return; }
            HandleFieldSetupSelectedStratumChanged(stratum);
        }

        private void HandleFieldSetupSelectedStratumChanged(FieldSetupStratum stratum)
        {
            if (stratum != null)
            {
                this._treeFieldWidget.SelectedItemsDataSource = stratum.SelectedTreeFields;
                this._treeFieldWidget.DataSource = stratum.UnselectedTreeFields;

                this._logFieldWidget.SelectedItemsDataSource = stratum.SelectedLogFields;
                this._logFieldWidget.DataSource = stratum.UnselectedLogFields;
            }
        }


        private void _treeFieldWidget_SelectionMoved(object sender, FMSC.Controls.ItemMovedEventArgs e)
        {
            UpdateTreeFieldOrder();
            //TreeFieldSetupDO tf = e.Item as TreeFieldSetupDO;
            //IList<TreeFieldSetupDO> list = (IList<TreeFieldSetupDO>)_treeFieldWidget.SelectedItemsDataSource;
            //TreeFieldSetupDO othertf = list[e.PreviousIndex];
            //tf.FieldOrder = e.NewIndex;
            //othertf.FieldOrder = e.PreviousIndex;
        }

        private void _treeFieldWidget_SelectionAdded(object sender, object item, int index)
        {
            UpdateTreeFieldOrder();
            //TreeFieldSetupDO tf = item as TreeFieldSetupDO;
            //if (tf == null) { return; }
            ////tf.Stratum = FieldSetup_CurrentStratum;
            //tf.FieldOrder = index;
            ////tf.DAL = Presenter.Controller.Database;
            ////tf.Save();
        }

        private void _logFieldWidget_SelectionAdded(object sender, object item, int index)
        {
            UpdateLogFieldOrder();
            //LogFieldSetupDO lf = item as LogFieldSetupDO;
            //if (lf == null) { return; }
            ////lf.Stratum = FieldSetup_CurrentStratum;
            //lf.FieldOrder = index;
            ////lf.DAL = Presenter.Controller.Database;
            ////lf.Save();
        }

        private void _logFieldWidget_SelectionMoved(object sender, FMSC.Controls.ItemMovedEventArgs e)
        {
            UpdateLogFieldOrder();
            //LogFieldSetupDO lf = e.Item as LogFieldSetupDO;
            //IList<LogFieldSetupDO> list = (IList<LogFieldSetupDO>)_logFieldWidget.SelectedItemsDataSource;
            //LogFieldSetupDO otherlf = list[e.PreviousIndex];
            //lf.FieldOrder = e.NewIndex;
            //otherlf.FieldOrder = e.PreviousIndex;
            ////lf.Save();
            ////otherlf.Save();
        }



        //refreshes the field order on all items
        //item's fieldOrder = item's list position + 1
        private void UpdateLogFieldOrder()
        {
            IList<LogFieldSetupDO> list = (IList<LogFieldSetupDO>)_logFieldWidget.SelectedItemsDataSource;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FieldOrder = i + 1;
            }
        }

        //refreshes the field order on all items
        //item's fieldOrder = item's list position + 1
        private void UpdateTreeFieldOrder()
        {
            IList<TreeFieldSetupDO> list = (IList<TreeFieldSetupDO>)_treeFieldWidget.SelectedItemsDataSource;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FieldOrder = i + 1;
            }
        }

        private void _logFieldWidget_SelectedValueChanged(object sender, EventArgs e, object selectedValue)
        {
            if (selectedValue == null) { return; }
            this._BS_LogField.DataSource = selectedValue;
        }

        private void _treeFieldWidget_SelectedValueChanged(object sender, EventArgs e, object selectedValue)
        {
            if (selectedValue == null) { return; }
            this._BS_TreeField.DataSource = selectedValue;
        }
    }
}
