using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Core.EditTemplate;
using CruiseManager.Core.Models;
using CruiseManager.Core.Services;
using CruiseManager.Core.ViewModel;
using CruiseManager.Data;
using CruiseManager.Navigation;
using CruiseManager.Services;
using CruiseManager.Utility;
using CruiseManager.WinForms.CruiseWizard;
using CruiseManager.WinForms.DataEditor;
using CruiseManager.WinForms.TemplateEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms.App
{
    public class WindowPresenterWinForms : WindowPresenter
    {
        IContainerService Container { get; }
        IDialogService DialogService { get; }
        ISetupService SetupService { get; }
        IUserSettings UserSettings { get; }
        IExceptionHandler ExceptionHandler { get; }
        IDatabaseProvider DatabaseProvider { get; }

        public WindowPresenterWinForms(INavigationService navigationService, 
            IDatabaseProvider databaseProvider,
            IDialogService dialogService,
            ISetupService setupService, 
            IUserSettings userSettings, 
            IExceptionHandler exceptionHandler, 
            IWindow window, 
            IContainerService container)
            : base(navigationService, window)
        {
            Container = container;
            DialogService = dialogService;
            SetupService = setupService;
            UserSettings = userSettings;
            ExceptionHandler = exceptionHandler;
            DatabaseProvider = databaseProvider;
        }

        public override void ShowAboutDialog()
        {
            NavigationService.ShowDialog(typeof(AboutDialog));
        }

        public override string AskSaveAsLocation(string originalPath)
        {
            var extention = System.IO.Path.GetExtension(originalPath).ToLower();

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                //DefaultExt = extention,
                Filter = string.Format("*{0}|*{0}", extention)
            })
            {
                if (sfd.ShowDialog((Form)Window) == System.Windows.Forms.DialogResult.OK)
                {
                    return sfd.FileName;
                }
                else
                {
                    return null;
                }
            }
        }

        public override string AskOpenFileLocation()
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                AutoUpgradeEnabled = true,
                InitialDirectory = UserSettings.CruiseSaveLocation,
                Filter = Strings.OPEN_CRUISE_FILE_DIALOG_FILTER
            })
            {
                dialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");

                if (COConverter.IsInstalled() == true)
                {
                    dialog.Filter += String.Format("| {0}(*{1})|*{1}", Strings.FRIENDLY_LEGACY_CRUISE_FILETYPE_NAME, Strings.LEGACY_CRUISE_FILE_EXTENTION);
                }

                if (dialog.ShowDialog((Form)Window) == System.Windows.Forms.DialogResult.OK)
                {
                    return dialog.FileName;
                    //String fileName = dialog.FileName;
                    //String directroy = System.IO.Path.GetDirectoryName(fileName);
                    //this.ApplicationController.UserSettings.CruiseSaveLocation = directroy;
                    //this.ApplicationController.OpenFile(dialog.FileName);
                }
                else
                {
                    return null;
                }
            }
        }

        public override string AskTemplateLocation()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.AutoUpgradeEnabled = true;
                dialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");

                dialog.InitialDirectory = UserSettings.TemplateSaveLocation;

                dialog.Multiselect = false;
                dialog.Filter = String.Format("Template Files ({0})|*{0}", Strings.CRUISE_TEMPLATE_FILE_EXTENTION);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    string dir = System.IO.Path.GetDirectoryName(filePath);

                    UserSettings.TemplateSaveLocation = dir;

                    return filePath;
                }
                else
                {
                    return null;
                }
            }
        }

        protected String AskSavePath(SaleDO sale)
        {
            bool createSaleFolder = false;
            if (UserSettings.CreateSaleFolder == null)
            {
                NavigationService.ShowDialog(typeof(CreateSaleFolderDialog));

                createSaleFolder = UserSettings.CreateSaleFolder ?? createSaleFolder;
            }
            else
            {
                createSaleFolder = UserSettings.CreateSaleFolder.Value;
            }

            using (var saveFileDialog = new System.Windows.Forms.SaveFileDialog())
            {
                var purposeShort = Strings.PURPOSE_SHORT_MAP.GetValueOrDefault(sale.Purpose, string.Empty);

                saveFileDialog.AutoUpgradeEnabled = true;
                saveFileDialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");
                saveFileDialog.InitialDirectory = UserSettings.CruiseSaveLocation;
                saveFileDialog.DefaultExt = "cruise";
                saveFileDialog.FileName = $"{ sale.SaleNumber} {sale.Name} {purposeShort}.cruise";
                saveFileDialog.Filter = "Cruise files(*.cruise)|*.cruise";
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    string dir = System.IO.Path.GetDirectoryName(fileName);
                    UserSettings.CruiseSaveLocation = dir;

                    if (createSaleFolder)
                    {
                        dir += $"\\{sale.SaleNumber}{sale.Name}\\";
                        if (!System.IO.Directory.Exists(dir))
                        {
                            System.IO.Directory.CreateDirectory(dir);
                        }
                        else { return dir + System.IO.Path.GetFileName(saveFileDialog.FileName); }
                    }
                    return saveFileDialog.FileName;
                }
                return null;
            }
        }

        

        public override TreeDefaultValueDO ShowAddTreeDefault(TreeDefaultValueDO newTDV)
        {
            try
            {
                FormAddTreeDefault dialog = new FormAddTreeDefault(SetupService.GetProductCodes());
                if (dialog.ShowDialog(newTDV) == System.Windows.Forms.DialogResult.OK)
                {
                    newTDV.Save();
                    return newTDV;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (!ExceptionHandler.Handel(ex))
                {
                    throw;
                }
                else
                {
                    return null;
                }
            }
        }

        public override TreeDefaultValueDO ShowAddTreeDefault()
        {
            TreeDefaultValueDO newTDV = new TreeDefaultValueDO(Database);

            return this.ShowAddTreeDefault(null);
        }

        public override void ShowEditTreeDefault(TreeDefaultValueDO tdv)
        {
            var tdvNavParams = (tdv == null) ? null 
                : new CruiseManagerNavigationParamiters()
            {
                Species = tdv.Species,
                LiveDead = tdv.LiveDead,
                PrimaryProduct = tdv.PrimaryProduct,
                };

            NavigationService.ShowDialog("EditTreeDefault", tdvNavParams);

            // TODO find a way to pass back new/edited tree default
        }

        private bool ShowWizardDialog(DAL database, out SaleDO sale)
        {
            CruiseWizardView view = new CruiseWizardView();
            CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, this.NavigationService, database);
            DialogResult result = view.ShowDialog((IWin32Window)Window);
            sale = p.Sale;
            if (result == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ShowCruiseWizardDialog()
        {
            DAL database = null;
            var databaseProvider = DatabaseProvider;
            if(databaseProvider.HasIncompleteCruise
                // TODO START HERE
                && DialogService.AskYesNoCancel( )
            {
                database = databaseProvider.GetIncompleteCruise();
            }
            else
            { database = databaseProvider.GetNewCruiseAsync().Result; }

            DAL tempfile = DatabaseProvider.GetNewOrUnfinishedCruise();
            if (tempfile != null)
            {
                SaleDO sale;
                if (this.ShowWizardDialog(tempfile, out sale))
                {
                    var destPath = AskSavePath(sale);
                    if (destPath == null)
                    {
                        return;
                    }
                    else
                    {
                        tempfile.Dispose();
                        if (System.IO.File.Exists(destPath))
                        {
                            System.IO.File.Replace(tempfile.Path, destPath, null);
                        }
                        else
                        {
                            System.IO.File.Move(tempfile.Path, destPath);
                        }
                        this.NavigationService.Database = new DAL(destPath);
                    }

                    this.ShowCruiseLandingLayout();
                }
                else
                {
                    tempfile.Dispose();
                }
            }
        }

        public override void ShowEditWizard()
        {
            if (NavigationService.Database.GetRowCount("Tree", null) == 0)
            {
                SaleDO sale;
                this.ShowWizardDialog(this.NavigationService.Database, out sale);
            }
            else
            {
                this.NavigationService.ActiveView.ShowMessage("Can't edit file with tree data in wizard");
                //MessageBox.Show("Can't edit file with tree data in wizard");
            }
        }

        public override void ShowDataEditor()
        {
            NavigationService.Save();
            using (DataEditorView view = new DataEditorView(this, this.NavigationService))
            {
                view.ShowDialog((IWin32Window)this.NavigationService.MainWindow);
            }
        }

        public override void ShowDataExportDialog(IEnumerable<TreeVM> Trees, IEnumerable<LogVM> Logs, IEnumerable<PlotDO> Plots, IEnumerable<CountVM> Counts)
        {
            using (DataExportDialog dialog = new DataExportDialog(this.NavigationService, Trees, Logs, Plots, Counts))
            {
                //dialog.Owner = DataEditorView; //TODO make data export dialog owned by data editor
                dialog.ShowDialog();
            }
        }

        public override void ShowImportTemplate()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = Strings.OPEN_CRUISE_FILE_DIALOG_FILTER;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //this.MainWindow.ClearNavPanel();
                this.NavigationService.MainWindow.ClearActiveView();
                //this.MainWindow.AddNavButton("Finish", this.HandleFinishImportTemplateClick);
                //this.MainWindow.AddNavButton("Cancel", this.HandleCancelImportTemplateClick);
                TemplateEditViewPresenter presenter = new TemplateEditViewPresenter(this.NavigationService);
                ImportFromCruiseView view = new ImportFromCruiseView(dialog.FileName, this, presenter);

                this.NavigationService.ActiveView = view;
            }
            // find table to import
            // open dialog box
            // select cruise
            //Form form = new Form();
            //form.Size = new System.Drawing.Size(400, 400);
            //CSM.NavPages.COConverterPage convertPage = new CSM.NavPages.COConverterPage();
            //form.Controls.Add(convertPage);
            //form.ShowDialog();
        }
    }
}