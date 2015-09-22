using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.Components;
using CruiseManager.Core.Models;
using CruiseManager.WinForms.Components;
using CSM.Winforms;
using CSM.Winforms.Dashboard;
using CSM.Winforms.DataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSM.App
{
    public class WinFormsWindowPresenter : WindowPresenter
    {
        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }



        public const string Version = "2015.09.01";
        


        #region Ctor

        public WinFormsWindowPresenter()
        {
            this.MainWindow = new FormCSMMain(this);
            ShowHomeLayout();
        }

        public WinFormsWindowPresenter(String dalPath)
            : this()
        {
            ApplicationController.Instance.OpenFile(dalPath);
            //this.OpenFile(dalPath);
        }
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
                    value.FormClosing += new FormClosingEventHandler(this.HandleAppClosing);
                }
                _mainWindow = value;
            }
        }



        protected void SetActiveView(Control view)
        {
            //clear previous content from main view content panel 
            foreach (Control c in this.MainWindow.ViewContentPanel.Controls)
            {
                c.Dispose();
            }
            this.MainWindow.ViewContentPanel.Controls.Clear();

            IView iView = view as IView;
            if (iView != null)
            {
                this.MainWindow.SetNavOptions(iView.NavOptions);
                throw new NotImplementedException();
            }

            //dock new view 
            view.Dock = DockStyle.Fill;
            view.Parent = this.MainWindow.ViewContentPanel;

            //signal view to handle load
            //IView iView = view as IView;
            //if (iView != null)
            //{
            //    iView.HandleLoad();
            //}
        }

        /// <summary>
        /// Called from Program.cs, launches the main window
        /// </summary>
        public override void Run()
        {
            Application.Run(MainWindow);
        }


        



        

        #region click event handlers


        public void SaveAs()
        {
            //show save file dialog
            SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = ApplicationController.Instance.Database.Extension,
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ApplicationController.Instance.SaveAs(sfd.FileName);
            }
        }





        public void HandleAppClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.SaveHandler != null)
                {

                    SaveHandler.HandleAppClosing(e.Cancel);
                }
            }
            catch (Exception ex)
            {
                this.ExceptionHandler.Handel(ex);
            }
        }



        

        

        public void HandleFinishImportTemplateClick(object sender, EventArgs e)
        {
            ImportFromCruiseView view = ActivePresentor as ImportFromCruiseView;
            if (view != null)
            {
                view.Finish();
            }
            this.ShowTemplateLandingLayout();
        }

        public void HandleCancelImportTemplateClick(object sender, EventArgs e)
        {
            this.ShowTemplateLandingLayout();
        }
        #endregion



        #region UI Methods

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
                this.MainWindow.ViewContentPanel.Controls.Clear();
                this.MainWindow.Text = System.IO.Path.GetFileName(this.AppState.Database.Path);

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
            CreateComponentView view = new CreateComponentView();
            CreateComponentPresenter presenter = new CreateComponentPresenter(this);

            view.Presenter = presenter;
            presenter.View = view;

            this.ActivePresentor = presenter;
            SetActiveView(view);
        }

        public override void ShowCustomizeCruiseLayout()
        {
            ActivePresentor = null;
            CustomizeCruisePresenter presenter = new CustomizeCruisePresenter(this);
            CruiseCustomizeView view = new CruiseCustomizeView(presenter);

            SetActiveView(view);

            ActivePresentor = presenter;
        }

        

        public override void ShowCruiseWizardDialog()
        {
            DAL tempfile = ApplicationController.Instance.GetNewOrUnfinishedCruise();
            if (tempfile != null)
            {
                this.ShowWaitCursor();

                CruiseWizardView view = new CruiseWizardView();
                CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, tempfile);
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
            using (DataEditorView view = new DataEditorView(this))
            {
                view.ShowDialog(this.MainWindow);
            }
        }

        public override void ShowDataExportDialog(IList<TreeVM> Trees, IList<LogVM> Logs, IList<PlotDO> Plots, IList<CountTreeDO> Counts)
        {
            DataExportDialog dialog = new DataExportDialog(this, Trees, Logs, Plots, Counts);
            //dialog.Owner = DataEditorView; //TODO make data export dialog ownen by data editor
            dialog.ShowDialog();
        }

        public override void ShowEditDesign()
        {
            ActivePresentor = null;
            DesignEditViewControl view = new DesignEditViewControl(this);
            SetActiveView(view);

            DesignEditorPresentor presenter = new DesignEditorPresentor(this);
            presenter.View = view;
            ActivePresentor = presenter;
        }

        public override void ShowEditWizard()
        {
            if (ApplicationController.Instance.Database.GetRowCount("Tree", null) == 0)
            {
                this.ShowWaitCursor();

                CruiseWizardView view = new CruiseWizardView();
                CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, this.Database);
                p.View = view;
                view.Owner = MainWindow;

                this.ShowDefaultCursor();

                view.ShowDialog(this.MainWindow);
                if (this.ActivePresentor != null) //refresh page in main window after wizard closes 
                {
                    this.ActivePresentor.UpdateView();
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

            var _openFileAction = new NavOption("Create New Cruise", this.ShowCruiseWizardDialog);
            var _createNewCruise = new NavOption("Open File", this.ShowOpenCruiseDialog);
            this.MainWindow.SetNavOptions(new NavOption[] { _createNewCruise, _openFileAction });

            this.ActivePresentor = null;
        }

        public override void ShowImportTemplate()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = R.Strings.OPEN_CRUISE_FILE_DIALOG_FILTER;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //this.MainWindow.ClearNavPanel();
                this.MainWindow.ViewContentPanel.Controls.Clear();
                //this.MainWindow.AddNavButton("Finish", this.HandleFinishImportTemplateClick);
                //this.MainWindow.AddNavButton("Cancel", this.HandleCancelImportTemplateClick);

                ImportFromCruiseView view = new ImportFromCruiseView(this, dialog.FileName);
                view.Dock = DockStyle.Fill;
                this.ActivePresentor = view;
                this.MainWindow.ViewContentPanel.Controls.Add(view);

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
            MergeComponentView view = new MergeComponentView();
            MergeComponentsPresenter presenter = new MergeComponentsPresenter(this, view);

            this.ActivePresentor = presenter;
            SetActiveView(view);
        }

        public override void ShowOpenCruiseDialog()
        {


            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AutoUpgradeEnabled = true;
            dialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");
            dialog.InitialDirectory = this.CruiseSaveLocation;
            dialog.Filter = R.Strings.OPEN_CRUISE_FILE_DIALOG_FILTER;
            if (COConverter.IsInstalled() == true)
            {
                dialog.Filter += String.Format("| {0}(*{1})|*{1}", R.Strings.FRIENDLY_LEGACY_CRUISE_FILETYPE_NAME, R.Strings.LEGACY_CRUISE_FILE_EXTENTION);
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String fileName = dialog.FileName;
                String directroy = System.IO.Path.GetDirectoryName(fileName);
                this.CruiseSaveLocation = directroy;

                OpenFile(dialog.FileName);
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
            this.MainWindow.Text = System.IO.Path.GetFileName(this.AppState.Database.Path);
            //this.MainWindow.AddNavButton("Back", this.HandleHomePageClick);
            //this.MainWindow.AddNavButton("Import From Cruise", this.HandleImportTemplateClick);
            TemplateEditViewControl view = new TemplateEditViewControl(this);
            TemplateEditViewPresenter presenter = new TemplateEditViewPresenter(this, view);
            view.Presenter = presenter;
            ActivePresentor = presenter;
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
