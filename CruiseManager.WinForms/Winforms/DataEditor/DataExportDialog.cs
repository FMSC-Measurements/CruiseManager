using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CruiseManager.WinForms.DataEditor
{
    public partial class DataExportDialog : Form
    {
        SetupServiceBase SetupService { get { return ApplicationController.SetupService; } }

        protected ApplicationControllerBase ApplicationController { get; set; }

        #region CTor

        public DataExportDialog()
        {
            InitializeComponent();
        }

        public DataExportDialog(ApplicationControllerBase applicationController, IEnumerable<TreeVM> Trees, IEnumerable<LogVM> Logs, IEnumerable<PlotDO> Plots, IEnumerable<CountVM> Counts)
        {
            ApplicationController = applicationController;

            this.InitializeComponent();
            this.Trees = Trees;
            this.Logs = Logs;
            this.Plots = Plots;
            this.Counts = Counts;

            SetUpFieldWidgets();
        }

        void SetUpFieldWidgets()
        {
            //set up tree field widget
            //get list of tree fields from the setup file

            AllTreeFields = MakeTreeFieldList();

            TreeFields = ApplicationController.Database.From<TreeFieldSetupDO>()
                .GroupBy("Field").OrderBy("FieldOrder").Read().Select(x => new FieldDiscriptor(x)).ToList();

            AllTreeFields = this.AllTreeFields.Except(TreeFields).ToList();

            this.TreeFieldOrderableAddRemoveWidget.DataSource = AllTreeFields;
            this.TreeFieldOrderableAddRemoveWidget.SelectedItemsDataSource = TreeFields;

            //set up log field widget
            //get list of log fields from setup file

            this.LogOrderableAddRemoveWidget.DataSource = AllLogFields = MakeLogFieldList();
            this.LogOrderableAddRemoveWidget.SelectedItemsDataSource = LogFields = new List<FieldDiscriptor>();

            //set up plot field widget
            this.PlotFieldOrderableAddRemoveWidget.DataSource = AllPlotFields = MakePlotFieldList();
            this.PlotFieldOrderableAddRemoveWidget.SelectedItemsDataSource = PlotFields = new List<FieldDiscriptor>();

            //set up count field widget
            this.CountFieldOrderableAddRemoveWidget.DataSource = AllCountFields = MakeCountFiledList();
            this.CountFieldOrderableAddRemoveWidget.SelectedItemsDataSource = CountFields = new List<FieldDiscriptor>();
        }

        List<FieldDiscriptor> MakeTreeFieldList()
        {
            var list = new List<FieldDiscriptor>();

            list.AddRange(SetupService.GetTreeFieldSetups().Select(x => new FieldDiscriptor(x)));

            list.Add(new FieldDiscriptor { Field = "CuttingUnit", Header = "Unit", Format = "[Code]", DataType = typeof(TreeVM) });
            //this.AllTreeFields.Add(new FieldDiscriptor { Field = "Stratum", Header = "Stratum", Format = "[Code]", DataType = typeof(TreeVM) });
            //this.AllTreeFields.Add(new FieldDiscriptor { Field = "SampleGroup", Header = "Sample Group", Format = "[Code]", DataType = typeof(TreeVM) });
            //this.AllTreeFields.Add(new FieldDiscriptor { Field = "TreeDefaultValue", Header = "Default Sp/LD/ProdP", Format = "[Species]/[LiveDead]/[PrimaryProduct]", DataType = typeof(TreeVM) });
            list.Add(new FieldDiscriptor { Field = "Plot", Header = "Plot Number", Format = "[PlotNumber]", DataType = typeof(TreeVM) });
            list.Sort((x, y) => string.Compare(x.Header, y.Header, StringComparison.CurrentCulture));

            return list;
        }

        List<FieldDiscriptor> MakeLogFieldList()
        {
            var list = new List<FieldDiscriptor>();

            list.Add(new FieldDiscriptor { Field = nameof(LogVM.CUCode), Header = "Cutting Unit", DataType = typeof(LogVM) });
            list.Add(new FieldDiscriptor { Field = nameof(LogVM.StratumCode), Header = "Stratum", DataType = typeof(LogVM) });
            list.Add(new FieldDiscriptor { Field = nameof(LogVM.SGCode), Header = "Sample Group", DataType = typeof(LogVM) });
            list.Add(new FieldDiscriptor { Field = nameof(LogVM.TreeSpecies), Header = "Species", DataType = typeof(LogVM) });
            list.Add(new FieldDiscriptor { Field = nameof(LogVM.TreeNumber), Header = "Tree Number", DataType = typeof(LogVM) });
            list.Add(new FieldDiscriptor { Field = nameof(LogVM.PlotNumber), Header = "Plot Number", DataType = typeof(LogVM) });
            list.Sort((x, y) => string.Compare(x.Header, y.Header, StringComparison.CurrentCulture));

            list.AddRange(SetupService.GetLogFieldSetups()
                .OrderBy(x => x.Field)
                .Select(x => new FieldDiscriptor(x)));
            return list;
        }

        List<FieldDiscriptor> MakePlotFieldList()
        {
            return new List<FieldDiscriptor>(new FieldDiscriptor[]
                {
                    new FieldDiscriptor{ Field = "CuttingUnit", Header = "Cutting Unit", Format = "[Code]", DataType = typeof(PlotDO) },
                    new FieldDiscriptor{ Field = "Stratum", Header = "Stratum", Format = "[Code]", DataType = typeof(PlotDO) },
                    new FieldDiscriptor{ Field = "PlotNumber", Header = "Plot Number", DataType = typeof(PlotDO) },
                    new FieldDiscriptor{ Field = "IsEmpty", Header = "Is Empty", DataType = typeof(PlotDO) },
                    new FieldDiscriptor{ Field = "Slope", Header = "Slope", DataType = typeof(PlotDO)},
                    new FieldDiscriptor{ Field = "KPI", Header = "KPI", DataType = typeof(PlotDO)},
                    new FieldDiscriptor{ Field = "Aspect", Header = "Aspect", DataType = typeof(PlotDO)},
                    new FieldDiscriptor{ Field = "Remarks", Header = "Remarks", DataType = typeof(PlotDO)},
                    new FieldDiscriptor{ Field = "XCoordinate", Header = "XCoordinate", DataType = typeof(PlotDO)},
                    new FieldDiscriptor{ Field = "YCoordinate", Header = "YCoordinate", DataType = typeof(PlotDO)},
                    new FieldDiscriptor{ Field = "ZCoordinate", Header = "ZCoordinate", DataType = typeof(PlotDO)}
                });
        }

        List<FieldDiscriptor> MakeCountFiledList()
        {
            return new List<FieldDiscriptor>(new FieldDiscriptor[]
                {
                    new FieldDiscriptor{ Field = nameof(CountVM.UnitCode), Header = "Cutting Unit", DataType = typeof(CountVM) },
                    new FieldDiscriptor{ Field = nameof(CountVM.SGCode), Header = "Sample Group", DataType = typeof(CountVM) },
                    new FieldDiscriptor{ Field = nameof(CountVM.StratumCode), Header = "Stratum", DataType = typeof(CountVM)},
                    new FieldDiscriptor{ Field = nameof(CountVM.Species), Header = "Species", DataType = typeof(CountVM)},
                    new FieldDiscriptor{ Field = nameof(CountVM.TreeCount), Header = "Tree Count", DataType = typeof(CountVM)},
                    new FieldDiscriptor{ Field = nameof(CountVM.SumKPI), Header = "SumKPI", DataType = typeof(CountVM)}
                });
        }

        #endregion CTor

        #region Properties

        private List<FieldDiscriptor> AllPlotFields;

        private List<FieldDiscriptor> AllCountFields;

        private List<FieldDiscriptor> PlotFields;

        private List<FieldDiscriptor> CountFields;

        private List<FieldDiscriptor> AllTreeFields { get; set; }

        private List<FieldDiscriptor> TreeFields { get; set; }

        private List<FieldDiscriptor> AllLogFields { get; set; }

        private List<FieldDiscriptor> LogFields { get; set; }

        public IEnumerable<TreeVM> Trees { get; set; }

        public IEnumerable<LogVM> Logs { get; set; }

        public IEnumerable<PlotDO> Plots { get; set; }

        public IEnumerable<CountVM> Counts { get; set; }

        public bool IsExportTreesSelected
        {
            get
            {
                return this.Trees != null && this.Trees.Count() > 0 && this.TreeFields.Count > 0;
            }
        }

        public bool IsExportLogsSelected
        {
            get
            {
                return this.Logs != null && this.Logs.Count() > 0 && this.LogFields.Count > 0;
            }
        }

        public bool IsExportPlotsSelected
        {
            get
            {
                return this.Plots != null && this.Plots.Count() > 0 && this.PlotFields.Count > 0;
            }
        }

        public bool IsExportCountsSelected
        {
            get
            {
                return this.Counts != null && this.Counts.Count() > 0 && this.CountFields.Count > 0;
            }
        }

        #endregion Properties

        #region Event handlers

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (!this.IsExportCountsSelected && !this.IsExportLogsSelected && !this.IsExportPlotsSelected && !this.IsExportTreesSelected)
            {
                MessageBox.Show(@"You haven't selected any data to export.
                Please select Tree, Log, Plot, or Count fields to export");
                return;
            }

            string exportMethod = ExportMethodComboBox.SelectedItem as string;

            FileInfo file = this.AskExportPath(exportMethod);
            if (file == null) { return; }
            FileStream stream = OpenStream(file);
            if (stream != null)
            {
                using (stream)
                {
                    switch (exportMethod)
                    {
                        case "Printable PDF":
                            {
                                ExportAsPDF(stream);
                                break;
                            }
                        case "Excel Spread Sheet (.xls)":
                            {
                                ExportAsExcel(stream);
                                break;
                            }
                    }
                }
                MessageBox.Show("Done");
            }
        }

        #endregion Event handlers

        protected string GetFieldText(object data, FieldDiscriptor field)
        {
            object value = this.GetFieldValue(data, field);
            if (value != null && !(value is string))
            {
                return value.ToString();
            }
            return value as String ?? string.Empty;
        }

        protected object GetFieldValue(object data, FieldDiscriptor field)
        {
            object obj = field.PropInfo.GetValue(data, null);
            if (obj is IFormattable && !string.IsNullOrEmpty(field.Format))
            {
                return ((IFormattable)obj).ToString(field.Format, System.Globalization.CultureInfo.CurrentCulture);
            }
            else if (obj == null)
            {
                return string.Empty;
            }
            else
            {
                return obj;
            }
        }

        protected FileInfo AskExportPath(String exportMethod)
        {
            String filter = String.Empty;
            switch (exportMethod)
            {
                case "Printable PDF":
                    {
                        filter = "PDF (*.pdf)|*.pdf";
                        break;
                    }
                case "Excel Spread Sheet (.xls)":
                    {
                        filter = "Excel Spread Sheet (*.xlsx)|*.xlsx";
                        break;
                    }
            }
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = filter,
                AddExtension = true
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                return new FileInfo(dialog.FileName);
            }
            else
            {
                return null;
            }
        }

        protected FileStream OpenStream(FileInfo file)
        {
            System.Diagnostics.Debug.Assert(file != null);
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Create, FileAccess.ReadWrite);
            }
            catch (System.IO.IOException ex)
            {
                ApplicationController.ExceptionHandler.Handel(ex);
                //WindowPresenter.HandleNonCriticalError(true, "Unable To Open File");
            }
            return stream;
        }

        public void ExportAsPDF(FileStream stream)
        {
            //set up letter size document,
            //with 36 PT( .5 in) left and right margins
            //and 108PT (1.5in) top and bottom margin
            using (Document document = new Document(PageSize.LETTER, 36, 36, 108, 108))
            //setup writer
            using (PdfWriter writer = PdfWriter.GetInstance(document, stream))
            {
                document.AddHeader(Header.AUTHOR, "FMSC");
                document.AddHeader(Header.CREATIONDATE, DateTime.Today.ToShortDateString());
                document.Open();
                if (IsExportTreesSelected)
                {
                    Chapter chapter = new Chapter("Trees", 0);
                    chapter.NumberDepth = 0;
                    PdfPTable table = new PdfPTable(TreeFields.Count)
                    {
                        WidthPercentage = 100F,
                        HeaderRows = 1,
                        SpacingBefore = 10F,
                        SplitLate = false
                    };

                    //write the headers
                    foreach (FieldDiscriptor field in TreeFields)
                    {
                        table.AddCell(field.Header);
                    }

                    //fill in data
                    foreach (TreeDO tree in Trees)
                    {
                        foreach (FieldDiscriptor field in TreeFields)
                        {
                            String text = GetFieldText(tree, field);
                            table.AddCell(text);
                        }
                    }

                    //add chapter to document

                    chapter.Add(table);
                    document.Add(chapter);
                }

                if (IsExportLogsSelected)
                {
                    Chapter chapter = new Chapter("Logs", 0);
                    chapter.NumberDepth = 0;
                    PdfPTable table = new PdfPTable(LogFields.Count)
                    {
                        HeaderRows = 1,
                        WidthPercentage = 100F,
                        SpacingBefore = 10F
                    };

                    //write headers
                    foreach (FieldDiscriptor field in LogFields)
                    {
                        table.AddCell(field.Header);
                    }

                    foreach (LogDO log in Logs)
                    {
                        foreach (FieldDiscriptor field in LogFields)
                        {
                            String text = GetFieldText(log, field);
                            table.AddCell(text);
                        }
                    }

                    chapter.Add(table);
                    document.Add(chapter);
                }

                if (IsExportPlotsSelected)
                {
                    Chapter chapter = new Chapter("Plots", 0);
                    chapter.NumberDepth = 0;
                    PdfPTable table = new PdfPTable(PlotFields.Count)
                    {
                        HeaderRows = 1,
                        WidthPercentage = 100F,
                        SpacingBefore = 10F
                    };

                    //write headers

                    foreach (FieldDiscriptor field in PlotFields)
                    {
                        table.AddCell(field.Header);
                    }

                    foreach (PlotDO plot in Plots)
                    {
                        foreach (FieldDiscriptor field in PlotFields)
                        {
                            String text = GetFieldText(plot, field);
                            table.AddCell(text);
                        }
                    }

                    chapter.Add(table);
                    document.Add(chapter);
                }

                if (IsExportCountsSelected)
                {
                    Chapter chapter = new Chapter("Counts", 0);
                    chapter.NumberDepth = 0;
                    PdfPTable table = new PdfPTable(CountFields.Count)
                    {
                        WidthPercentage = 100F,
                        HeaderRows = 1,
                        SpacingBefore = 10F
                    };

                    foreach (FieldDiscriptor field in CountFields)
                    {
                        table.AddCell(field.Header);
                    }

                    foreach (CountTreeDO count in Counts)
                    {
                        foreach (FieldDiscriptor field in CountFields)
                        {
                            String text = GetFieldText(count, field);
                            table.AddCell(text);
                        }
                    }

                    chapter.Add(table);
                    document.Add(chapter);
                }
            }
        }

        private void WriteRow(ExcelWorksheet worksheet, int rowNum, IList<FieldDiscriptor> fields, CruiseDAL.DataObject data)
        {
            //populate columns
            for (int j = 0; j < fields.Count; j++)
            {
                FieldDiscriptor field = fields[j];
                object value = GetFieldValue(data, field);
                worksheet.SetValue(rowNum, j + 1, value);
            }
        }

        public void ExportAsExcel(FileStream stream)
        {
            System.Diagnostics.Debug.Assert(stream != null);

            using (ExcelPackage excelFile = new ExcelPackage(stream))
            {
                ExcelWorksheet treeWorkSheet;
                ExcelWorksheet logWorkSheet;
                ExcelWorksheet plotsWorkSheet;
                ExcelWorksheet countsWorkSheet;

                if (IsExportTreesSelected)
                {
                    treeWorkSheet = excelFile.Workbook.Worksheets.Add("Trees");

                    var rowIndex = 1;
                    //Write header values
                    treeWorkSheet.SetValues(TreeFields.Select(x => x.Header), rowIndex++);

                    //populate rows
                    foreach (var tree in Trees)
                    {
                        WriteRow(treeWorkSheet, rowIndex++, TreeFields, tree);
                    }
                }
                if (IsExportLogsSelected)
                {
                    logWorkSheet = excelFile.Workbook.Worksheets.Add("Logs");

                    var rowIndex = 1;
                    //Write header values
                    logWorkSheet.SetValues(LogFields.Select(x => x.Header), rowIndex++);

                    foreach (var log in Logs)
                    {
                        WriteRow(logWorkSheet, rowIndex++, LogFields, log);
                    }
                }
                if (IsExportPlotsSelected)
                {
                    plotsWorkSheet = excelFile.Workbook.Worksheets.Add("Plots");

                    var rowIndex = 1;
                    plotsWorkSheet.SetValues(PlotFields.Select(x => x.Header), rowIndex++);

                    foreach (var plot in Plots)
                    {
                        WriteRow(plotsWorkSheet, rowIndex++, PlotFields, plot);
                    }
                }
                if (IsExportCountsSelected)
                {
                    countsWorkSheet = excelFile.Workbook.Worksheets.Add("Counts");

                    var rowIndex = 1;
                    countsWorkSheet.SetValues(CountFields.Select(x => x.Header), rowIndex++);

                    foreach (var count in Counts)
                    {
                        WriteRow(countsWorkSheet, rowIndex++, CountFields, count);
                    }
                }

                excelFile.Save();
            }
        }

        protected class FieldDiscriptor : IComparable<FieldDiscriptor>
        {
            public FieldDiscriptor()
            {
            }

            public FieldDiscriptor(TreeFieldSetupDO obj)
            {
                this.Field = obj.Field;
                this.Header = obj.Heading;
                this.Format = obj.Format;
                this.DataType = typeof(TreeVM);
            }

            public FieldDiscriptor(LogFieldSetupDO obj)
            {
                this.Field = obj.Field;
                this.Header = obj.Heading;
                this.Format = obj.Format;
                this.DataType = typeof(LogVM);
            }

            private PropertyInfo _propInfo;

            public string Field { get; set; }
            public string Header { get; set; }

            public PropertyInfo PropInfo
            {
                get
                {
                    if (_propInfo == null && !String.IsNullOrEmpty(this.Field))
                    {
                        try
                        {
                            _propInfo = this.DataType.GetProperty(this.Field);
                        }
                        catch (AmbiguousMatchException)//if looking for a property that overrides or hides a base class property, AmbiguousMatchException will be thrown
                        {
                            //use DeclaredOnly to force search for only non-inharited members
                            _propInfo = this.DataType.GetProperty(this.Field, BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                        }
                    }
                    return _propInfo;
                }
            }

            public string Format { get; set; }
            public Type DataType { get; set; }

            #region IComparable<FieldDiscriptor> Members

            public int CompareTo(FieldDiscriptor other)
            {
                return string.Compare(this.Field, other.Field, StringComparison.OrdinalIgnoreCase);
            }

            #endregion IComparable<FieldDiscriptor> Members
        }
    }
}