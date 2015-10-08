using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Components;
using CruiseManager.Core.Constants;
using CruiseManager.Core.Models;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.WinForms.Components;
using CruiseManager.Utility;
using CruiseManager.WinForms;
using CruiseManager.WinForms.CruiseCustomize;
using CruiseManager.WinForms.CruiseWizard;
using CruiseManager.WinForms.Dashboard;
using CruiseManager.WinForms.DataEditor;
using CruiseManager.WinForms.TemplateEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CruiseManager.Core;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.EditDesign;
using CruiseManager.WinForms.EditDesign;
using CruiseManager.Core.EditTemplate;
using CruiseManager.Core.CommandModel;
using CruiseManager.Winforms.Dashboard;

namespace CruiseManager.App
{
    public class WindowPresenterWinForms : WindowPresenter
    {

        public WindowPresenterWinForms(ApplicationController appController)
        {
            this.ApplicationController = appController;
        }


        public override string AskCruiseSaveLocation()
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = Strings.CRUISE_FILE_EXTENTION,
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

        public override void ShowAboutDialog()
        {
            using (AboutDialog dialog = new AboutDialog(this.ApplicationController))
            {
                dialog.ShowDialog((IWin32Window)this.ApplicationController.MainWindow);
            }
        }

        public override TreeDefaultValueDO ShowAddTreeDefult()
        {
            TreeDefaultValueDO newTDV = new TreeDefaultValueDO(this.ApplicationController.Database);

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
                if(!this.ApplicationController.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
                else
                {
                    return null;
                }
            }
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
                        }
                        catch (CruiseDAL.UniqueConstraintException ex)
                        {
                            throw new UserFacingException("Values Conflict With Existing Tree Default", ex);
                        }
                        catch (CruiseDAL.ConstraintException ex)
                        {
                            throw new UserFacingException("Invalid Values", ex);
                        }
                    }
                }           

            }
            catch (Exception ex)
            {
                if(!this.ApplicationController.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
        }

        

        

       

        

        public override void ShowCruiseWizardDialog()
        {
            DAL tempfile = ApplicationController.GetNewOrUnfinishedCruise();
            if (tempfile != null)
            {
                CruiseWizardView view = new CruiseWizardView();
                CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, this.ApplicationController, tempfile);
                p.View = view;


                if (view.ShowDialog((IWin32Window)this.ApplicationController.MainWindow) == DialogResult.OK)
                {
                    ApplicationController.Database = p.Database;
                    this.ShowCruiseLandingLayout();
                    this.ShowCustomizeCruiseLayout();
                }
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

        public override void ShowDataExportDialog(IList<TreeVM> Trees, IList<LogVM> Logs, IList<PlotDO> Plots, IList<CountTreeDO> Counts)
        {
            using (DataExportDialog dialog = new DataExportDialog(this.ApplicationController, Trees, Logs, Plots, Counts))
            {
                //dialog.Owner = DataEditorView; //TODO make data export dialog owned by data editor
                dialog.ShowDialog();
            }
        }



        public override void ShowEditWizard()
        {
            if (ApplicationController.Database.GetRowCount("Tree", null) == 0)
            {
                
                CruiseWizardView view = new CruiseWizardView();
                CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, this.ApplicationController, this.ApplicationController.Database);
                p.View = view;

                view.ShowDialog((IWin32Window)this.ApplicationController.MainWindow);
                
            }
            else
            {
                this.ApplicationController.ActiveView.ShowMessage("Can't edit file with tree data in wizard");
                //MessageBox.Show("Can't edit file with tree data in wizard");
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
                ImportFromCruiseView view = new ImportFromCruiseView( dialog.FileName, this, presenter);

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
