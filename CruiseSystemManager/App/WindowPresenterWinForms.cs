﻿using CruiseDAL;
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
using CruiseManager.Winforms.DesignEditor;
using CruiseManager.Winforms.TemplateEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager.App
{
    public class WindowPresenterWinForms : WindowPresenter
    {

        protected ApplicationController _myApplicationController;


        public const string Version = "2015.09.01";
        


        #region Ctor

        public WindowPresenterWinForms(ApplicationController applicationController) : this()
        {
            _myApplicationController = applicationController;
        }

        public WindowPresenterWinForms()
        {
            this.MainWindow = new FormCSMMain(this, this._myApplicationController);
            ShowHomeLayout();
        }

        //public WindowPresenterWinForms(String dalPath)
        //    : this()
        //{
        //    ApplicationController.Instance.OpenFile(dalPath);
        //    //this.OpenFile(dalPath);
        //}
        #endregion 

        

        private FormCSMMain _mainWindow;
        public FormCSMMain MainWindow
        {
            get { return _mainWindow; }
            set
            {
                if (_mainWindow != null)
                {
                    _mainWindow.Dispose();
                }
                if (value != null)
                {
                    value.FormClosing += new FormClosingEventHandler(this.AppClosingHandler);
                }
                _mainWindow = value;
            }
        }



        protected void SetActiveView(Control view)
        {
            this.MainWindow.SetActiveView(view);

            
        }

        /// <summary>
        /// Called from Program.cs, launches the main window
        /// </summary>
        public override void Run()
        {
            Application.Run(MainWindow);
        }


        #region click event handlers

        public override string AskCruiseSaveLocation()
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = Strings.CRUISE_FILE_EXTENTION,
            })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    return sfd.FileName;
                }
                else
                {
                    return null;
                }
            }

        }

        public void AppClosingHandler(object sender, FormClosingEventArgs e)
        {
            bool cancel = e.Cancel;
            this._myApplicationController.HandleAppClosing(ref cancel);
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

        public override string AskTemplateLocation()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.AutoUpgradeEnabled = true;
                dialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");

                dialog.InitialDirectory = _myApplicationController.UserSettings.TemplateSaveLocation;

                dialog.Multiselect = false;
                dialog.Filter = String.Format("Template Files ({0})|*{0}", Strings.CRUISE_TEMPLATE_FILE_EXTENTION);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = dialog.FileName;
                    string dir = System.IO.Path.GetDirectoryName(filePath);


                    _myApplicationController.UserSettings.TemplateSaveLocation = dir;

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
            using (AboutDialog dialog = new AboutDialog())
            {
                dialog.ShowDialog(this.MainWindow);
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
                this.MainWindow.Text = System.IO.Path.GetFileName(this._myApplicationController.Database.Path);

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
                if (this.cruiseLandingNavOptions == null)
                {
                    this.InitializeCruiseNavOptions();
                }

                this.MainWindow.SetNavOptions(this.cruiseLandingNavOptions);
                this.ShowCustomizeCruiseLayout();
            }
        }

        private CommandBinding[] cruiseLandingNavOptions;

        private void InitializeCruiseNavOptions()
        {
            this.cruiseLandingNavOptions = new CommandBinding[]
            {
                new CommandBinding("Design Wizard", this.ShowEditWizard),
                new CommandBinding("Edit Design", this.ShowEditDesign),
                new CommandBinding("Customize", this.ShowCustomizeCruiseLayout),
                new CommandBinding("Field Data", this.ShowDataEditor),
                new CommandBinding("Create Component Files", this.ShowCreateComponentsLayout),
                new CommandBinding("Merge Component Files", this.ShowManageComponentsLayout)
            };
        }

        public override void ShowCreateComponentsLayout()
        {
            CreateComponentViewWinforms view = new CreateComponentViewWinforms(this);
            CreateComponentPresenter presenter = new CreateComponentPresenter(this, this._myApplicationController);

            view.Presenter = presenter;
            presenter.View = view;

            this._myApplicationController.ActivePresentor = presenter;
            SetActiveView(view);
        }

        public override void ShowCustomizeCruiseLayout()
        {
            this._myApplicationController.ActivePresentor = null;
            CustomizeCruisePresenter presenter = new CustomizeCruisePresenter(this, this._myApplicationController);
            CruiseCustomizeViewWinforms view = new CruiseCustomizeViewWinforms(presenter, this._myApplicationController);

            SetActiveView(view);

            this._myApplicationController.ActivePresentor = presenter;
        }

        

        public override void ShowCruiseWizardDialog()
        {
            DAL tempfile = ApplicationController.Instance.GetNewOrUnfinishedCruise();
            if (tempfile != null)
            {
                this.ShowWaitCursor();

                CruiseWizardView view = new CruiseWizardView();
                CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, this._myApplicationController, tempfile);
                p.View = view;
                view.Owner = MainWindow;

                this.ShowDefaultCursor();

                if (view.ShowDialog() == DialogResult.OK)
                {
                    ApplicationController.Instance.Database = p.Database;
                    this.ShowCruiseLandingLayout();
                    this.ShowCustomizeCruiseLayout();
                }
            }
        }

        public override void ShowDataEditor()
        {
            ApplicationController.Instance.Save();
            using (DataEditorView view = new DataEditorView(this, this._myApplicationController))
            {
                view.ShowDialog(this.MainWindow);
            }
        }

        public override void ShowDataExportDialog(IList<TreeVM> Trees, IList<LogVM> Logs, IList<PlotDO> Plots, IList<CountTreeDO> Counts)
        {
            DataExportDialog dialog = new DataExportDialog(this._myApplicationController, Trees, Logs, Plots, Counts);
            //dialog.Owner = DataEditorView; //TODO make data export dialog ownen by data editor
            dialog.ShowDialog();
        }

        public override void ShowEditDesign()
        {
            this._myApplicationController = null;
            DesignEditViewControl view = new DesignEditViewControl(this, this._myApplicationController, this._myApplicationController.ExceptionHandler);
            SetActiveView(view);

            DesignEditorPresentor presenter = new DesignEditorPresentor(this);
            presenter.View = view;
            this._myApplicationController.ActivePresentor = presenter;
        }

        public override void ShowEditWizard()
        {
            if (ApplicationController.Instance.Database.GetRowCount("Tree", null) == 0)
            {
                this.ShowWaitCursor();

                CruiseWizardView view = new CruiseWizardView();
                CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, this._myApplicationController, this._myApplicationController.Database);
                p.View = view;
                view.Owner = MainWindow;

                this.ShowDefaultCursor();

                view.ShowDialog(this.MainWindow);
                if (this._myApplicationController.ActivePresentor != null) //refresh page in main window after wizard closes 
                {
                    this._myApplicationController.ActivePresentor.UpdateView();
                }
            }
            else
            {
                MessageBox.Show("Can't edit file with tree data in wizard");
            }
        }

        public override void ShowHomeLayout()
        {
            //this.MainWindow.ClearNavPanel();
            //this.MainWindow.ViewContentPanel.Controls.Clear();

            //this.MainWindow.Text = R.Strings.HOME_LAYOUT_TITLE_BAR;
            //this.MainWindow.AddNavButton("Open File", this.HandleOpenFileClick);
            //this.MainWindow.AddNavButton("Create New Cruise", this.HandleCreateCruiseClick);

            var _openFileAction = new CommandBinding("Create New Cruise", this.ShowCruiseWizardDialog);
            var _createNewCruise = new CommandBinding("Open File", this.ShowOpenCruiseDialog);
            this.MainWindow.SetNavOptions(new CommandBinding[] { _createNewCruise, _openFileAction });

            this._myApplicationController.ActivePresentor = null;
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

                ImportFromCruiseView view = new ImportFromCruiseView(this, dialog.FileName);
                view.Dock = DockStyle.Fill;
                this._myApplicationController.ActivePresentor = view;
                this.SetActiveView(view);

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
            MergeComponentViewWinforms view = new MergeComponentViewWinforms();
            MergeComponentsPresenter presenter = new MergeComponentsPresenter(view, this, this._myApplicationController);

            this._myApplicationController.ActivePresentor = presenter;
            SetActiveView(view);
        }

        public override void ShowOpenCruiseDialog()
        {


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AutoUpgradeEnabled = true;
            dialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");
            dialog.InitialDirectory = this._myApplicationController.UserSettings.CruiseSaveLocation;
            dialog.Filter = Strings.OPEN_CRUISE_FILE_DIALOG_FILTER;
            if (COConverter.IsInstalled() == true)
            {
                dialog.Filter += String.Format("| {0}(*{1})|*{1}", Strings.FRIENDLY_LEGACY_CRUISE_FILETYPE_NAME, Strings.LEGACY_CRUISE_FILE_EXTENTION);
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String fileName = dialog.FileName;
                String directroy = System.IO.Path.GetDirectoryName(fileName);
                this._myApplicationController.UserSettings.CruiseSaveLocation = directroy;

                this._myApplicationController.OpenFile(dialog.FileName);
            }
        }

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
            //this.MainWindow.ClearNavPanel();
            //this.MainWindow.ViewContentPanel.Controls.Clear();
            this.MainWindow.Text = System.IO.Path.GetFileName(this._myApplicationController.Database.Path);
            //this.MainWindow.AddNavButton("Back", this.HandleHomePageClick);
            //this.MainWindow.AddNavButton("Import From Cruise", this.HandleImportTemplateClick);
            TemplateEditViewControl view = new TemplateEditViewControl(this, this._myApplicationController);
            TemplateEditViewPresenter presenter = new TemplateEditViewPresenter(this, this._myApplicationController, view);
            view.Presenter = presenter;
            this._myApplicationController.ActivePresentor = presenter;
            this.SetActiveView(view);
            this.MainWindow.SetNavOptions(this.templateLandingNavOptions);

        }

        private CommandBinding[] templateLandingNavOptions;
        private void InitializeTemplateNavOptions()
        {
            this.templateLandingNavOptions = new CommandBinding[]{
                new CommandBinding("Import From Cruise", this.ShowImportTemplate),
                new CommandBinding("Close File", null )
            };

        }
        
        public override Nullable<bool> AskYesNoCancel(String message, String caption)
        {
            return AskYesNoCancel(message, caption, true);
        }

        public override Nullable<bool> AskYesNoCancel(String message, String caption, Nullable<bool> defaultOption)
        {
            MessageBoxDefaultButton defaultButton;
            switch (defaultOption)
            {
                case true:
                    { defaultButton = MessageBoxDefaultButton.Button1; break; }
                case false:
                    { defaultButton = MessageBoxDefaultButton.Button2; break; }
                case null:
                    { defaultButton = MessageBoxDefaultButton.Button3; break; }
                default:
                    { defaultButton = MessageBoxDefaultButton.Button1; break; }
            }
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, defaultButton);
            return (result == DialogResult.Cancel) ? (Nullable < bool >)null : (result == DialogResult.Yes) ? true : false;
        }

        public override void ShowMessage(String message, String caption)
        {
            MessageBox.Show(message, caption);
        }

        public override void ShowSimpleErrorMessage(string errorMessage)
        {
            using (ErrorMessageDialog dialog = new ErrorMessageDialog())
            {
                dialog.ShowDialog(errorMessage, string.Empty);
            }
        }

        public override void ShowWaitCursor()
        {
            this.MainWindow.Cursor = Cursors.WaitCursor;

        }
        public override void ShowDefaultCursor()
        {
            this.MainWindow.Cursor = Cursors.Default;
        }

        #endregion

        

        public bool Shutdown()
        {
            MainWindow.Close();
            return true;
        }

        #region IDisposable Members
        bool _disposed = false;


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (_disposed)
            {
                return;
            }
            if (isDisposing)
            {
                throw new NotImplementedException();
            }

            _disposed = true;
        }
        #endregion
    }
}
