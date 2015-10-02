using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Components;
using CruiseManager.Core.Constants;
using CruiseManager.Core.Models;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.WinForms.Components;
using CruiseManager.Utility;
using CruiseManager.Winforms;
using CruiseManager.Winforms.Components;
using CruiseManager.Winforms.CruiseCustomize;
using CruiseManager.Winforms.CruiseWizard;
using CruiseManager.Winforms.Dashboard;
using CruiseManager.Winforms.DataEditor;
using CruiseManager.Winforms.TemplateEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CruiseManager.Core;
using CSM.Winforms.Dashboard;
using CruiseManager.Core.CruiseCustomize;
using CruiseManager.Core.EditDesign;
using CruiseManager.Winforms.EditDesign;
using CruiseManager.Core.EditTemplate;

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






        public new FormCSMMain MainWindow
        {
            get { return base.MainWindow as FormCSMMain; }
            set
            {
                if (base.MainWindow != null)
                {
                    base.MainWindow.Dispose();
                }
                if (value != null)
                {
                    value.FormClosing += new FormClosingEventHandler(this.AppClosingHandler);
                }
                base.MainWindow = value;
            }
        }





        /// <summary>
        /// Called from Program.cs, launches the main window
        /// </summary>
        public override void Run()
        {
            this.MainWindow = new FormCSMMain(this, this.ApplicationController);
            ShowHomeLayout();
            Application.Run(MainWindow);
        }


        #region click event handlers

        

        public void AppClosingHandler(object sender, FormClosingEventArgs e)
        {
            bool cancel = e.Cancel;
            this.ApplicationController.HandleAppClosing(ref cancel);
            e.Cancel = cancel;
        }


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
                if (sfd.ShowDialog(this.MainWindow) == DialogResult.OK)
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

                if (dialog.ShowDialog(this.MainWindow) == DialogResult.OK)
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
                dialog.ShowDialog(this.MainWindow);
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
            if (this.MainWindow.InvokeRequired)
            {
                this.MainWindow.Invoke((Action)this.ShowCruiseLandingLayout);
            }
            else
            {
                //this.MainWindow.ClearNavPanel();
                this.MainWindow.ClearActiveView();
                this.MainWindow.Text = System.IO.Path.GetFileName(this.ApplicationController.Database.Path);

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

                this.MainWindow.SetNavCommands(this.cruiseLandingNavCommands);
                this.ShowCustomizeCruiseLayout();
            }
        }

        private ViewCommand[] cruiseLandingNavCommands;

        private void InitializeCruiseNavOptions()
        {
            this.cruiseLandingNavCommands = new ViewCommand[]
            {
                this.ApplicationController.MakeViewCommand("Design Wizard", this.ShowEditWizard),
                this.ApplicationController.MakeViewCommand("Edit Design", this.ShowEditDesign),
                this.ApplicationController.MakeViewCommand("Customize", this.ShowCustomizeCruiseLayout),
                this.ApplicationController.MakeViewCommand("Field Data", this.ShowDataEditor),
                this.ApplicationController.MakeViewCommand("Create Component Files", this.ShowCreateComponentsLayout),
                this.ApplicationController.MakeViewCommand("Merge Component Files", this.ShowManageComponentsLayout)
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
                view.Owner = MainWindow;


                if (view.ShowDialog() == DialogResult.OK)
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
                view.ShowDialog(this.MainWindow);
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
                view.Owner = MainWindow;

                view.ShowDialog(this.MainWindow);
                
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
            this.MainWindow.SetNavCommands(new ViewCommand[]
            {
                this.ApplicationController.MakeViewCommand("Open File", this.ApplicationController.OpenFile),
                this.ApplicationController.MakeViewCommand("Create New Cruise", this.ApplicationController.CreateNewCruise)
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
                this.MainWindow.ClearActiveView();
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
            this.MainWindow.Text = System.IO.Path.GetFileName(this.ApplicationController.Database.Path);

            
            TemplateEditViewPresenter presenter = new TemplateEditViewPresenter(this.ApplicationController);
            EditTemplateViewWinForms view = new EditTemplateViewWinForms(this, presenter);

            this.ApplicationController.ActiveView = view;

            if(templateLandingNavOptions == null)
            {
                this.InitializeTemplateNavOptions();
            }
            this.MainWindow.SetNavCommands(this.templateLandingNavOptions);

        }

        private ViewCommand[] templateLandingNavOptions;
        private void InitializeTemplateNavOptions()
        {
            this.templateLandingNavOptions = new ViewCommand[]{
                this.ApplicationController.MakeViewCommand("Import From Cruise", this.ShowImportTemplate),
                this.ApplicationController.MakeViewCommand("Close File", this.ShowHomeLayout )
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

        

        public bool Shutdown()
        {
            MainWindow.Close();
            return true;
        }

       



        #region IDisposable Members
        //bool _disposed = false;


        //protected override void Dispose(bool isDisposing)
        //{
        //    base.Dispose();
        //    if (_disposed)
        //    {
        //        return;
        //    }
        //    if (isDisposing)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    _disposed = true;
        //}
        #endregion
    }
}
