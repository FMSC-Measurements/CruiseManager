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

        public WindowPresenterWinForms()
        {
            
        }

        //public override void Load()
        //{
        //    Bind<MainWindow>().To<FormCSMMain>().InSingletonScope();

        //    Bind<CreateComponentView>().To<CreateComponentViewWinforms>();
        //    Bind<CruiseCustomizeView>().To<CruiseCustomizeViewWinforms>();
        //    Bind<EditDesignView>().To<EditDesignViewWinForms>();
        //    Bind<EditTemplateView>().To<EditTemplateViewWinForms>();
        //    Bind<MergeComponentView>().To<MergeComponentViewWinforms>();

        //    Bind<HomeView>().ToSelf();

        //    Bind<CreateComponentPresenter>().ToSelf();
        //    Bind<CustomizeCruisePresenter>().ToSelf();
        //    Bind<DesignEditorPresentor>().ToSelf();
        //    Bind<TemplateEditViewPresenter>().ToSelf();
        //    Bind<MergeComponentsPresenter>().ToSelf();

        //}












        /// <summary>
        /// Called from Program.cs, launches the main window
        /// </summary>
        


        #region click event handlers

        




        //public void HandleFinishImportTemplateClick(object sender, EventArgs e)
        //{
        //    ImportFromCruiseView view = this._myApplicationController.ActivePresentor as ImportFromCruiseView;
        //    if (view != null)
        //    {
        //        view.Finish();
        //    }
        //    this.ShowTemplateLandingLayout();
        //}

        //public void HandleCancelImportTemplateClick(object sender, EventArgs e)
        //{
        //    this.ShowTemplateLandingLayout();
        //}
        #endregion



        #region UI Methods

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

        //public override void ShowUnimplementedFeatureDialog()
        //{
        //    MessageBox.Show("This Feature has not been implemented yet, check back later");
        //}

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

        public override void ShowCruiseLandingLayout()
        {
            if (((Form)this.ApplicationController.MainWindow).InvokeRequired)
            {
                ((Form)this.ApplicationController.MainWindow).Invoke((Action)this.ShowCruiseLandingLayout);
            }
            else
            {
                //this.MainWindow.ClearNavPanel();
                this.ApplicationController.MainWindow.ClearActiveView();
                this.ApplicationController.MainWindow.Text = System.IO.Path.GetFileName(this.ApplicationController.Database.Path);

                //bool enableManageComponents = this.Database.CruiseFileType == CruiseFileType.Master;
                //bool enableEditDesign = true;//this.Database.CruiseFileType != CruiseFileType.Component;
                //bool enableCreateComponents = this.Database.CruiseFileType != CruiseFileType.Component;
                //bool enableCostomize = true;//this.Database.CruiseFileType != CruiseFileType.Component;

                ////populate navigation buttons, last first
                //this.MainWindow.AddNavButton("Back", this.HandleHomePageClick, true);
                ////this.MainWindow.AddNavButton("Combine Sale Data", this.HandleCombineSaleClick);


                //this.MainWindow.AddNavButton("Merge Component Files", this.HandleManageComponensClick, enableManageComponents);
                //this.MainWindow.AddNavButton("Create Component Files", this.HandleCreateComponentsClick, enableCreateComponents);
                //this.MainWindow.AddNavButton("Field Data", this.HandleExportCruiseClick, true);
                //this.MainWindow.AddNavButton("Customize", this.HandleCruiseCustomizeClick, enableCostomize);
                //this.MainWindow.AddNavButton("Edit Design", this.HandleEditViewCruiseClick, enableEditDesign);
                //this.MainWindow.AddNavButton("Design Wizard", this.HandleEditWizardClick, enableEditDesign);
                if (this.cruiseLandingNavCommands == null)
                {
                    this.InitializeCruiseNavOptions();
                }

                this.ApplicationController.MainWindow.SetNavCommands(this.cruiseLandingNavCommands);
                this.ShowCustomizeCruiseLayout();
            }
        }

        private BindableCommand[] cruiseLandingNavCommands;

        private void InitializeCruiseNavOptions()
        {
            this.cruiseLandingNavCommands = new BindableCommand[]
            {
                new BindableActionCommand("Design Wizard", this.ShowEditWizard),
                new BindableActionCommand("Edit Design", this.ShowEditDesign),
                new BindableActionCommand("Customize", this.ShowCustomizeCruiseLayout),
                new BindableActionCommand("Field Data", this.ShowDataEditor),
                new BindableActionCommand("Create Component Files", this.ShowCreateComponentsLayout),
                new BindableActionCommand("Merge Component Files", this.ShowManageComponentsLayout)
            };
        }

        public override void ShowCreateComponentsLayout()
        {
            CreateComponentPresenter presenter = new CreateComponentPresenter(this.ApplicationController);
            CreateComponentViewWinforms view = new CreateComponentViewWinforms(presenter);

            this.ApplicationController.ActiveView = view;

        }

        public override void ShowCustomizeCruiseLayout()
        {
            CustomizeCruisePresenter presenter = new CustomizeCruisePresenter(this.ApplicationController);
            CruiseCustomizeViewWinforms view = new CruiseCustomizeViewWinforms(presenter);
            this.ApplicationController.ActiveView = view;

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

        public override void ShowEditDesign()
        {
            
            DesignEditorPresentor presenter = new DesignEditorPresentor(this.ApplicationController);
            EditDesignViewWinForms view = new EditDesignViewWinForms(this, presenter);

            this.ApplicationController.ActiveView = view;
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

        public override void ShowHomeLayout()
        {
            var homeView = new HomeView(this.ApplicationController);
            this.ApplicationController.ActiveView = homeView;
            this.ApplicationController.MainWindow.SetNavCommands(new BindableCommand[]
            {
                this.ApplicationController.OpenFileCommand,
                this.ApplicationController.CreateNewCruiseCommand
            });

            //this.MainWindow.ClearNavPanel();
            //this.MainWindow.ViewContentPanel.Controls.Clear();

            //this.MainWindow.Text = R.Strings.HOME_LAYOUT_TITLE_BAR;
            //this.MainWindow.AddNavButton("Open File", this.HandleOpenFileClick);
            //this.MainWindow.AddNavButton("Create New Cruise", this.HandleCreateCruiseClick);

            //var _openFileAction = new CommandBinding("Create New Cruise", this.ShowCruiseWizardDialog);
            //var _createNewCruise = new CommandBinding("Open File", this.ShowOpenCruiseDialog);
            //this.MainWindow.SetNavOptions(new CommandBinding[] { _createNewCruise, _openFileAction });

            //this.ApplicationController.ActivePresentor = null;
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

        public override void ShowManageComponentsLayout()
        {
            
            MergeComponentsPresenter presenter = new MergeComponentsPresenter(this.ApplicationController);
            MergeComponentViewWinforms view = new MergeComponentViewWinforms(presenter);

            this.ApplicationController.ActiveView = view;
        }

        //public override void ShowOpenCruiseDialog()
        //{


        //    OpenFileDialog dialog = new OpenFileDialog();
        //    dialog.AutoUpgradeEnabled = true;
        //    dialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");
        //    dialog.InitialDirectory = this.ApplicationController.UserSettings.CruiseSaveLocation;
        //    dialog.Filter = Strings.OPEN_CRUISE_FILE_DIALOG_FILTER;
        //    if (COConverter.IsInstalled() == true)
        //    {
        //        dialog.Filter += String.Format("| {0}(*{1})|*{1}", Strings.FRIENDLY_LEGACY_CRUISE_FILETYPE_NAME, Strings.LEGACY_CRUISE_FILE_EXTENTION);
        //    }

        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        String fileName = dialog.FileName;
        //        String directroy = System.IO.Path.GetDirectoryName(fileName);
        //        this.ApplicationController.UserSettings.CruiseSaveLocation = directroy;

        //        this.ApplicationController.OpenFile(dialog.FileName);
        //    }
        //}

        //public void ShowCombineSaleLayout()
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            DAL mergeFromDAL = new DAL(ofd.FileName);

        //            this.MainWindow.ClearNavPanel();
        //            this.MainWindow.ViewContentPanel.Controls.Clear();
        //            this.MainWindow.Text = System.IO.Path.GetFileName(this.AppState.Database.Path) + " - Combine Sale";
        //            this.MainWindow.AddNavButton("Back", this.HandleReturnCruiseLandingClick);
        //            CombineCruisePresenter presenter = new CombineCruisePresenter(this, mergeFromDAL);
        //            ComponentSelectPage view = new ComponentSelectPage(presenter);
        //            this.ActivePresentor = presenter;
        //            this.SetActiveView(view);
        //        }
        //        catch
        //        {
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        return;
        //    }

        //}

        //public void ShowCombineSaleSubComponentSelectPage()
        //{

        //}

        public override void ShowTemplateLandingLayout()
        {
            this.ApplicationController.MainWindow.Text = System.IO.Path.GetFileName(this.ApplicationController.Database.Path);

            
            TemplateEditViewPresenter presenter = new TemplateEditViewPresenter(this.ApplicationController);
            EditTemplateViewWinForms view = new EditTemplateViewWinForms(this, presenter);

            this.ApplicationController.ActiveView = view;

            if(templateLandingNavOptions == null)
            {
                this.InitializeTemplateNavOptions();
            }
            this.ApplicationController.MainWindow.SetNavCommands(this.templateLandingNavOptions);

        }

        private BindableCommand[] templateLandingNavOptions;
        private void InitializeTemplateNavOptions()
        {
            this.templateLandingNavOptions = new BindableCommand[]{
                new BindableActionCommand("Import From Cruise", this.ShowImportTemplate),
                new BindableActionCommand("Close File", this.ShowHomeLayout )
            };
        }
        
        //public override Nullable<bool> AskYesNoCancel(String message, String caption)
        //{
        //    return AskYesNoCancel(message, caption, true);
        //}

        //public override Nullable<bool> AskYesNoCancel(String message, String caption, Nullable<bool> defaultOption)
        //{
        //    MessageBoxDefaultButton defaultButton;
        //    switch (defaultOption)
        //    {
        //        case true:
        //            { defaultButton = MessageBoxDefaultButton.Button1; break; }
        //        case false:
        //            { defaultButton = MessageBoxDefaultButton.Button2; break; }
        //        case null:
        //            { defaultButton = MessageBoxDefaultButton.Button3; break; }
        //        default:
        //            { defaultButton = MessageBoxDefaultButton.Button1; break; }
        //    }
        //    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, defaultButton);
        //    return (result == DialogResult.Cancel) ? (Nullable < bool >)null : (result == DialogResult.Yes) ? true : false;
        //}

        //public override void ShowMessage(String message, String caption)
        //{
        //    MessageBox.Show(message, caption);
        //}

        //public override void ShowSimpleErrorMessage(string errorMessage)
        //{
        //    using (ErrorMessageDialog dialog = new ErrorMessageDialog())
        //    {
        //        dialog.ShowDialog(errorMessage, string.Empty);
        //    }
        //}

        //public override void ShowWaitCursor()
        //{
        //    this.MainWindow.Cursor = Cursors.WaitCursor;

        //}
        //public override void ShowDefaultCursor()
        //{
        //    this.MainWindow.Cursor = Cursors.Default;
        //}

        #endregion
    }
}
