using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSM.UI.CombineCruise
{
    public partial class MergeCruiseView : Form, IView
    {
        public CombineCruisePresenter Presenter { get; set; }

        public MergeCruiseView(CombineCruisePresenter presenter)
        {
            this.Presenter = presenter;
            this.Presenter.View = this;
            InitializeComponent();

            ComponentSelectPage = new ComponentSelectPage(this, Presenter);
            SubComponentSelectPage = new SubComponentSelectPage(this, Presenter);

            //ComponentSelectPage.CuttingUnitBindingSource.DataSource = Presenter.AllCuttingUnits;
            //ComponentSelectPage.StrataBindingSource.DataSource = Presenter.AllStrata;

            //presenter.ComponentSelectPage = ComponentSelectPage;
            //presenter.SubComponentSelectPage = SubComponentSelectPage;

            //SubComponentSelectPage.SubComponentGridView.AutoGenerateColumns = false;

            pageHost1.Add(ComponentSelectPage);
            pageHost1.Add(SubComponentSelectPage);
        }

        public ComponentSelectPage ComponentSelectPage { get; set; }

        public SubComponentSelectPage SubComponentSelectPage { get; set; }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GoToComponentPage();
        }

        public void GoToSubComponentPage()
        {
            if (Presenter.IsSelectionCuttingUnit)
            {
                var codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Code",
                    HeaderText = "Code",
                    Name = "codeDataGridViewTextBoxColumn",
                    ReadOnly = true
                };

                var descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Description",
                    ReadOnly = true,
                    Name = "descriptionDataGridViewTextBoxColumn",
                    HeaderText = "Description"
                };

                var methodDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Method",
                    ReadOnly = true,
                    Name = "methodDataGridViewTextBoxColumn",
                    HeaderText = "Method"
                };

                var basalAreaFactorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "BasalArea",
                    HeaderText = "Basal Area",
                    Name = "basalAreaFactorDataGridViewTextBoxColumn",
                    ReadOnly = true
                };

                var fixedPlotSizeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "FixedPlotSize",
                    ReadOnly = true,
                    Name = "fixedPlotSizeDataGridViewTextBoxColumn",
                    HeaderText = "Fixed Plot Size"
                };

                var monthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Month",
                    HeaderText = "Month",
                    Name = "monthDataGridViewTextBoxColumn",
                    ReadOnly = true
                };

                var yearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Year",
                    ReadOnly = true,
                    Name = "yearDataGridViewTextBoxColumn",
                    HeaderText = "Year"
                };


                SubComponentSelectPage.SubComponentGridView.Columns.Clear();
                SubComponentSelectPage.SubComponentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                    codeDataGridViewTextBoxColumn,
                    descriptionDataGridViewTextBoxColumn,
                    methodDataGridViewTextBoxColumn,
                    basalAreaFactorDataGridViewTextBoxColumn,
                    fixedPlotSizeDataGridViewTextBoxColumn,
                    monthDataGridViewTextBoxColumn,
                    yearDataGridViewTextBoxColumn});

                //SubComponentSelectPage.SubComponentGridView.DataSource = Presenter.SubSelectionStrata;
                //SubComponentSelectPage.SubComponentGridView.SelectedItems = Presenter.SelectedSubSelectionStrata;
                SubComponentSelectPage.SubSelectionTypeLabel.Text = "Strata";


            }
            else
            {
                var codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Code",
                    HeaderText = "Code",
                    Name = "codeDataGridViewTextBoxColumn",
                    ReadOnly = true
                };

                var areaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Area",
                    HeaderText = "Area",
                    Name = "areaDataGridViewTextBoxColumn",
                    ReadOnly = true
                };

                var descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Description",
                    ReadOnly = true,
                    Name = "descriptionDataGridViewTextBoxColumn",
                    HeaderText = "Description"
                };

                var loggingMethodDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "LoggingMethod",
                    HeaderText = "Logging Method",
                    Name = "loggingMethodDataGridViewTextBoxColumn",
                    ReadOnly = true
                };

                var paymentUnitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "PaymentUnit",
                    ReadOnly = true,
                    Name = "paymentUnitDataGridViewTextBoxColumn",
                    HeaderText = "Payment Unit"
                };


                SubComponentSelectPage.SubComponentGridView.Columns.Clear();
                SubComponentSelectPage.SubComponentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                    codeDataGridViewTextBoxColumn,
                    areaDataGridViewTextBoxColumn,
                    descriptionDataGridViewTextBoxColumn,
                    loggingMethodDataGridViewTextBoxColumn,
                    paymentUnitDataGridViewTextBoxColumn});

                //SubComponentSelectPage.SubComponentGridView.DataSource = Presenter.SubSelectionCuttingUnits;
                //SubComponentSelectPage.SubComponentGridView.SelectedItems = Presenter.SelectedSubSelectionCuttingUnits;
                SubComponentSelectPage.SubSelectionTypeLabel.Text = "Cutting Units";
            }

            SubComponentSelectPage.SubComponentGridView.DataSource = Presenter.AvalableSubSelection;
            SubComponentSelectPage.SubComponentGridView.SelectedItems = Presenter.SelectedSubSelection;
            pageHost1.Display(SubComponentSelectPage);
        }

        public void GoToComponentPage()
        {
            pageHost1.Display(ComponentSelectPage);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult != DialogResult.OK) { DialogResult = DialogResult.Cancel; }
        }

    }
}
