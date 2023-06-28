using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Core.EditTemplate;
using CruiseManager.Core.Models;
using CruiseManager.Utility;
using CruiseManager.WinForms.CruiseWizard;
using CruiseManager.WinForms.DataEditor;
using CruiseManager.WinForms.TemplateEditor;
using FMSC.ORM.Core;
using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CruiseManager.WinForms.App
{
    public class WindowPresenterWinForms : WindowPresenter
    {
        public WindowPresenterWinForms(IApplicationController appController)
        {
            this.ApplicationController = appController;
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
                if (sfd.ShowDialog((Form)this.ApplicationController.MainWindow) == DialogResult.OK)
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
                InitialDirectory = this.ApplicationController.UserSettings.CruiseSaveLocation,
                Filter = Strings.OPEN_CRUISE_FILE_DIALOG_FILTER
            })
            {
                dialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");

                if (COConverter.IsInstalled() == true)
                {
                    dialog.Filter += String.Format("| {0}(*{1})|*{1}", Strings.FRIENDLY_LEGACY_CRUISE_FILETYPE_NAME, Strings.LEGACY_CRUISE_FILE_EXTENTION);
                }

                if (dialog.ShowDialog((Form)this.ApplicationController.MainWindow) == DialogResult.OK)
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

                dialog.InitialDirectory = ApplicationController.UserSettings.TemplateSaveLocation;

                dialog.Multiselect = false;
                dialog.Filter = String.Format("Template Files ({0})|*{0}", Strings.CRUISE_TEMPLATE_FILE_EXTENTION);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    string dir = System.IO.Path.GetDirectoryName(filePath);

                    ApplicationController.UserSettings.TemplateSaveLocation = dir;

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
            if (ApplicationController.UserSettings.CreateSaleFolder == null)
            {
                using (var dialog = new CreateSaleFolderDialog())
                {
                    createSaleFolder = (dialog.ShowDialog() == DialogResult.Yes);
                    if (dialog.RememberSelection)
                    {
                        ApplicationController.UserSettings.CreateSaleFolder = createSaleFolder;
                        //ApplicationState.GetHandle().Save();
                    }
                }
            }
            else
            {
                createSaleFolder = ApplicationController.UserSettings.CreateSaleFolder.Value;
            }

            using (var saveFileDialog = new System.Windows.Forms.SaveFileDialog())
            {
                var purposeShort = Strings.PURPOSE_SHORT_MAP.GetValueOrDefault(sale.Purpose, string.Empty);
                var saleNumber = SanitizePathPart(sale.SaleNumber);
                var saleName = SanitizePathPart(sale.Name);

                saveFileDialog.AutoUpgradeEnabled = true;
                saveFileDialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");
                saveFileDialog.InitialDirectory = ApplicationController.UserSettings.CruiseSaveLocation;
                saveFileDialog.DefaultExt = "cruise";
                saveFileDialog.FileName = $"{saleNumber} {saleName} {purposeShort}.cruise";
                saveFileDialog.Filter = "Cruise files(*.cruise)|*.cruise";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string userSelectedPath = saveFileDialog.FileName;
                    string dir = System.IO.Path.GetDirectoryName(userSelectedPath);
                    ApplicationController.UserSettings.CruiseSaveLocation = dir;

                    if (createSaleFolder)
                    {
                        try
                        {
                            dir += $"\\{saleNumber}{saleName}\\";
                            if (!System.IO.Directory.Exists(dir))
                            {
                                System.IO.Directory.CreateDirectory(dir);
                            }
                            return dir + System.IO.Path.GetFileName(userSelectedPath);
                        }
                        catch
                        {
                            //do nothing, continue to return userSelectedPath
                        }
                    }
                    return userSelectedPath;
                }
                return null;
            }
        }

        private static readonly Regex SAMITICE_INVALIDCHARS_REGEX = new Regex(@"[^\d\w ]", RegexOptions.None, TimeSpan.FromMilliseconds(10)); // match all non alpha numeric or space characters
        public static string SanitizePathPart(string part)
        {
            return SAMITICE_INVALIDCHARS_REGEX.Replace(part.Trim(), "");// remove all characters that match
        }

        public override void ShowAboutDialog()
        {
            using (AboutDialog dialog = new AboutDialog(this.ApplicationController))
            {
                dialog.ShowDialog((IWin32Window)this.ApplicationController.MainWindow);
            }
        }

        public override TreeDefaultValueDO ShowAddTreeDefault(TreeDefaultValueDO newTDV)
        {
            try
            {
                FormAddTreeDefault dialog = new FormAddTreeDefault(ApplicationController.SetupService.GetProductCodes());
                if (dialog.ShowDialog(newTDV) == DialogResult.OK)
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
                if (!this.ApplicationController.ExceptionHandler.Handel(ex))
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
            TreeDefaultValueDO newTDV = new TreeDefaultValueDO(this.ApplicationController.Database);

            return this.ShowAddTreeDefault(newTDV);
        }

        public static void RealignTreeSpecies(Datastore datastore, long treeDefaultValue_CN)
        {
            datastore.Execute("UPDATE Tree AS t SET Species = (SELECT Species FROM TreeDefaultValue AS tdv WHERE tdv.TreeDefaultValue_CN = @p1) WHERE t.TreeDefaultValue_CN = @p1;", treeDefaultValue_CN);
        }

        public override void ShowEditTreeDefault(TreeDefaultValueDO tdv)
        {
            TreeDefaultValueDO temp = new TreeDefaultValueDO(tdv);

            try
            {
                using (FormAddTreeDefault dialog = new FormAddTreeDefault(this.ApplicationController.SetupService.GetProductCodes()))
                {
                    if (dialog.ShowDialog(temp) == DialogResult.OK)
                    {
                        try
                        {
                            tdv.SetValues(temp);
                            tdv.Save();

                            RealignTreeSpecies(tdv.DAL, tdv.TreeDefaultValue_CN.Value);
                        }
                        catch (FMSC.ORM.UniqueConstraintException ex)
                        {
                            throw new UserFacingException("Values Conflict With Existing Tree Default", ex);
                        }
                        catch (FMSC.ORM.ConstraintException ex)
                        {
                            throw new UserFacingException("Invalid Values", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!this.ApplicationController.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
        }

        private bool ShowWizardDialog(DAL database, out SaleDO sale)
        {
            CruiseWizardView view = new CruiseWizardView();
            CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, this.ApplicationController, database);
            DialogResult result = view.ShowDialog((IWin32Window)this.ApplicationController.MainWindow);
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
            DAL tempfile = ApplicationController.GetNewOrUnfinishedCruise();
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
                        var fileExists = System.IO.File.Exists(destPath);
                        tempfile.CopyAs(destPath, fileExists);

                        this.ApplicationController.Database = tempfile;
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
            if (ApplicationController.Database.GetRowCount("Tree", null) == 0)
            {
                SaleDO sale;
                Analytics.TrackEvent(AnalyticsEvents.FEATURE_EDITCRUISEWIZARD);
                this.ShowWizardDialog(this.ApplicationController.Database, out sale);
            }
            else
            {
                this.ApplicationController.ActiveView.ShowMessage("Can't edit file with tree data in wizard");
                //MessageBox.Show("Can't edit file with tree data in wizard");
            }
        }

        public override void ShowDataEditor()
        {
            ApplicationController.Save();
            using (DataEditorView view = new DataEditorView(this, this.ApplicationController))
            {
                view.ShowDialog((IWin32Window)this.ApplicationController.MainWindow);
            }
        }

        public override void ShowDataExportDialog(IEnumerable<TreeVM> Trees, IEnumerable<LogVM> Logs, IEnumerable<PlotDO> Plots, IEnumerable<CountVM> Counts)
        {
            Analytics.TrackEvent(AnalyticsEvents.FEATURE_DATAEXPORT);
            using (DataExportDialog dialog = new DataExportDialog(this.ApplicationController, Trees, Logs, Plots, Counts))
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
                this.ApplicationController.MainWindow.ClearActiveView();
                //this.MainWindow.AddNavButton("Finish", this.HandleFinishImportTemplateClick);
                //this.MainWindow.AddNavButton("Cancel", this.HandleCancelImportTemplateClick);
                TemplateEditViewPresenter presenter = new TemplateEditViewPresenter(this.ApplicationController);
                ImportFromCruiseView view = new ImportFromCruiseView(dialog.FileName, this, presenter);

                this.ApplicationController.ActiveView = view;
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