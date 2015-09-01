using System;
using System.Linq; 
using System.Collections.Generic;
using System.Windows.Forms;
using CruiseDAL;
using CSM.UI.CruiseWizard;
using CSM.UI.DataEditor;
using CSM.UI.TemplateEditor;
using CSM.UI.DesignEditor;
using CruiseDAL.DataObjects;
using CSM.UI.CombineCruise;
using CSM.UI;
using CSM.Utility;
using CSM.UI.Dashboard;
using CSM.Logic;
using System.Diagnostics;
using CSM.UI.CruiseCustomize;
using CSM.DataTypes;
using CSM.Utility.Setup;
using CSM.Logic.Components;
using CSM.UI.Components;

namespace CSM
{
    /// <summary>
    /// The purpose of the window presenter is to display all the different forms of the application and
    /// provide a common place to for all the forms to access data and other infomation about the application state.
    /// it is the glue that binds the application together
    /// </summary>
    public class WindowPresenter : IWindowPresenter, IDisposable
    {
        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        

        private COConverter _converter;
        //private convertActivityDialog _convertDialog; 
        //private DialogConfigCounts _configCountsDialog;
        private string _convertedFilePath;


        public const string Version = "2015.09.01";
        public const int RECENT_FILE_LIST_SIZE = 10;


        #region Ctor

        public WindowPresenter()
        {
            this.MainWindow = new FormCSMMain(this);
            ShowHomeLayout();
        }

        public WindowPresenter(String dalPath)
            : this()
        {
            //if (string.IsNullOrEmpty(dalPath) == false)
            //{
            //    setDAL(dalPath);
            //}
            MainWindow = new FormCSMMain(this);
            this.OpenFile(dalPath);
        }
        #endregion 

        public FormCSMMain MainWindow { get; set; }

        //the current save handler is the active locical component of the program that is 
        //responceable for saving the user's data 
        public ISaveHandler SaveHandler { get { return ActivePresentor; } }
        private IPresentor _activePresentor;
        public IPresentor ActivePresentor 
        {
            get
            {
                return _activePresentor;
            }
            set
            {
                if (_activePresentor != null)
                {
                    _activePresentor.HandleSave();
                    _activePresentor.Dispose();
                }
                _activePresentor = value;
                if (value == null)
                {
                    this.MainWindow.EnableSave = false;
                }
                else
                {
                    this.MainWindow.EnableSave = value.CanHandleSave;
                }
            }
        }

        #region UserSettings 
        public string CruiseSaveLocation
        {
            get
            {
                if(String.IsNullOrEmpty(Properties.Settings.Default.DefaultCruiseSaveLocation))
                {
                    Properties.Settings.Default.DefaultCruiseSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles";
                    Properties.Settings.Default.Save();
                }
                return Properties.Settings.Default.DefaultCruiseSaveLocation;
            }
            set
            {
                if (Properties.Settings.Default.DefaultCruiseSaveLocation == value) { return; }
                Properties.Settings.Default.DefaultCruiseSaveLocation = value;
                Properties.Settings.Default.Save();
            }
        }

        public string TemplateSaveLocation
        {
            get
            {
                if(String.IsNullOrEmpty(Properties.Settings.Default.DefaultTemplateSaveLocation))
                {
                    Properties.Settings.Default.DefaultTemplateSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CruiseFiles\\Templates";
                    Properties.Settings.Default.Save();
                }
                return Properties.Settings.Default.DefaultTemplateSaveLocation;
            }
            set
            {
                if(Properties.Settings.Default.DefaultTemplateSaveLocation == value) { return; }
                Properties.Settings.Default.DefaultTemplateSaveLocation = value;
                Properties.Settings.Default.Save();
            }
        }

        private string[] _recentFiles; 
        public string[] RecentFiles
        {
            get
            {
                if (_recentFiles == null)
                {
                    string raw = Properties.Settings.Default.RecentFiles ?? string.Empty;
                    _recentFiles = raw.Split(new char[]{';'}, RECENT_FILE_LIST_SIZE, StringSplitOptions.RemoveEmptyEntries);
                }

                return _recentFiles;               
            }
        }

        protected void AddRecentFile(String path)
        {
            string[] oldRecentFiles = this.RecentFiles;
            string[] newRecentFiles = null;
            if (oldRecentFiles.Length > 0)
            {
                string[] union = new String[oldRecentFiles.Length + 1];
                union[0] = path;
                Array.Copy(oldRecentFiles, 0, union, 1, oldRecentFiles.Length);
                newRecentFiles = union.Distinct().Take(RECENT_FILE_LIST_SIZE).ToArray();
            }
            else
            {
                newRecentFiles = new string[1]{ path };
            }

            this._recentFiles = newRecentFiles;
            Properties.Settings.Default.RecentFiles = String.Join(";", this._recentFiles);
            Properties.Settings.Default.Save();
            

        }

        #endregion

        /// <summary>
        /// Gets the application state
        /// </summary>
        public ApplicationState AppState { get { return ApplicationState.GetHandle(); } }

        public DAL Database
        {
            get
            {
                return AppState.Database;
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
            
            //dock new view 
            view.Dock = DockStyle.Fill;
            view.Parent = this.MainWindow.ViewContentPanel;
            
            //signal view to handle load
            IView iView = view as IView;
            if (iView != null)
            {
                iView.HandleLoad();
            }
        }

        /// <summary>
        /// Called from Program.cs, launches the main window
        /// </summary>
        public void Run()
        {
            Application.Run(MainWindow);
        }


        /// <summary>
        /// opens file for use, handles various exceptions that can ocure whild opening file,
        /// determins if a cruise file/template file/or legacy cruise file
        /// </summary>
        /// <param name="filePath"></param>
        public void OpenFile(String filePath)
        {
            bool hasError = false;
            try
            {
                //start wait cursor incase this takes a long time 
                Cursor.Current = Cursors.WaitCursor;
                switch (System.IO.Path.GetExtension(filePath))
                {
                    case R.Strings.CRUISE_FILE_EXTENTION:
                        {
                            this.AppState.Database = new DAL(filePath);
                            this.AddRecentFile(filePath);
                            String[] errors;
                            if (this.AppState.Database.HasCruiseErrors(out errors))
                            {
                                MessageBox.Show(String.Join("\r\n", errors));
                            }
                            ShowCruiseLandingLayout();
                            break;
                        }
                    case R.Strings.CRUISE_TEMPLATE_FILE_EXTENTION:
                        {
                            this.AppState.Database = new DAL(filePath);
                            this.AddRecentFile(filePath);
                            ShowTemplateLandingLayout();
                            break;
                        }
                    case R.Strings.LEGACY_CRUISE_FILE_EXTENTION:
                        {
                            _converter = new COConverter();
                            _convertedFilePath = System.IO.Path.ChangeExtension(filePath, R.Strings.CRUISE_FILE_EXTENTION);

                            _converter.BenginConvert(filePath, _convertedFilePath, null, HandleConvertDone);

                            break;
                        }
                    default:
                        MessageBox.Show("Invalid file name");
                        return;
                }
            }
            catch (CruiseDAL.DatabaseShareException)
            {
                hasError = true;
                MessageBox.Show("File can not be opened in multiple applications");
            }
            catch (CruiseDAL.ReadOnlyException)
            {
                hasError = true;
                MessageBox.Show("Unable to open file becaus it is read only");
            }
            catch (CruiseDAL.IncompatibleSchemaException ex)
            {
                hasError = true;
                MessageBox.Show("File is not compatible with this version of Cruise Manager: " + ex.Message);
            }
            catch (CruiseDAL.DatabaseExecutionException ex)
            {
                hasError = true;
                MessageBox.Show("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.IO.IOException ex)
            {
                hasError = true;
                MessageBox.Show("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.Exception e)
            {
                Trace.TraceError(e.ToString());
                throw;
            }
            finally
            {
                if (hasError)
                {
                    this.ShowHomeLayout();
                }

                this.MainWindow.EnableSaveAs = this.Database != null;

                Cursor.Current = Cursors.Default;
            }
        }



        public void HandleConvertDone(IAsyncResult result)
        {
            if (_converter.EndConvert(result))
            {

                this.AppState.Database = new DAL(_convertedFilePath);
                this.AddRecentFile(_convertedFilePath); 
                if (MainWindow.InvokeRequired)
                {
                    Action act = this.ShowCruiseLandingLayout;
                    MainWindow.Invoke(act);
                }
                else
                {
                    this.ShowCruiseLandingLayout();
                }
            }
            else
            {
                MessageBox.Show("error unable to convert file");//TODO better error messages
            }

            _convertedFilePath = null;
            //_convertDialog = null;
            _converter = null;
        }

        #region click event handlers
        public void HandleAboutClick(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        

        public void HandleOpenFileClick(object sender, EventArgs e)
        {
            ShowOpenCruiseDialog();
        }

        public void HandleCreateCruiseClick(object sender, EventArgs e)
        {
            ShowCruiseWizardDiolog();
        }

        public void HandleSaveClick(object sender, EventArgs e)
        {
            if (this.SaveHandler != null)
            {
                SaveHandler.HandleSave();
            }
        }

        public void HandleSaveAsClick(object sender, EventArgs e)
        {
            //show save file dialog
            SaveFileDialog sfd = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = this.Database.Extension,
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (this.Database.CopyAs(sfd.FileName))
                {
                    //handle the save after copying 
                    if (this.SaveHandler != null) { this.SaveHandler.HandleSave(); }
                    this.MainWindow.Text = System.IO.Path.GetFileName(this.Database.Path);
                }
            }
        }

        public void HandleAppClosing(object sender, FormClosingEventArgs e)
        {
            if (this.SaveHandler != null)
            {
                SaveHandler.HandleAppClosing(sender, e);
            }
        }

        public void HandleEditViewCruiseClick(object sender, EventArgs e)
        {
            ActivePresentor = null;
            DesignEditViewControl view = new DesignEditViewControl();
            SetActiveView(view);
            
            DesignEditorPresentor presenter = new DesignEditorPresentor(this);
            presenter.View = view;
            ActivePresentor = presenter;
            
        }

        public void HandleExportCruiseClick(object sender, EventArgs e)
        {
            ShowDataEditor();
        }

        public void HandleManageComponensClick(object sender, EventArgs e)
        {
            ShowManageComponentsLayout();
        }

        public void HandleEditWizardClick(object sender, EventArgs e)
        {
            
            this.ShowEditWizard();
            
        }



        public void HandleCreateComponentsClick(object sender, EventArgs e)
        {
            ShowCreateComponentsLayout();
        }



        public void HandleCombineSaleClick(object sender, EventArgs e)
        {
            //ShowCombineSaleLayout();
            ShowUnimplementedFeatureDialog();
        }

        public void HandleCruiseCustomizeClick(object sender, EventArgs e)
        {
           ShowCustomizeCruiseLayout();
        }
        public void HandleHomePageClick(object sender, EventArgs e)
        {
           ShowHomeLayout();
        }

        public void HandleReturnCruiseLandingClick(object sender, EventArgs e)
        {
            ShowCruiseLandingLayout();
        }

        public void HandleImportTemplateClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = R.Strings.OPEN_CRUISE_FILE_DIALOG_FILTER;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.MainWindow.ClearNavPanel();
                this.MainWindow.ViewContentPanel.Controls.Clear();
                this.MainWindow.AddNavButton("Finish", this.HandleFinishImportTemplateClick);
                this.MainWindow.AddNavButton("Cancel", this.HandleCancelImportTemplateClick);

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

        public void ShowWaitCursor()
        {
            this.MainWindow.Cursor = Cursors.WaitCursor;

        }

        public void ShowDefaultCursor()
        {
            this.MainWindow.Cursor = Cursors.Default;
        }

        

        public void ShowEditWizard()
        {
            if (this.Database.GetRowCount("Tree", null) == 0)
            {
                this.ShowWaitCursor();

                CruiseWizardView view = new CruiseWizardView();
                CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, this.Database);
                p.View = view;
                view.Owner = MainWindow;

                this.ShowDefaultCursor();

                view.ShowDialog();
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


        public void ShowUnimplementedFeatureDialog()
        {
            MessageBox.Show("This Feature has not been implemented yet, check back later");
        }

        public void ShowAboutDialog()
        {
            using (AboutDialog dialog = new AboutDialog())
            {
                dialog.ShowDialog();
            }
        }

        public void ShowHomeLayout()
        {
            this.MainWindow.ClearNavPanel();
            this.MainWindow.ViewContentPanel.Controls.Clear();
            //this.MainWindow.ViewContentPanel.Controls.Add(new RecentFilesView(this) { Dock = DockStyle.Right });
            this.MainWindow.Text = R.Strings.HOME_LAYOUT_TITLE_BAR;
            this.MainWindow.AddNavButton("Open File", this.HandleOpenFileClick);
            this.MainWindow.AddNavButton("Create New Cruise", this.HandleCreateCruiseClick);
            this.ActivePresentor = null;
        }

        public void ShowCombineSaleLayout()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DAL mergeFromDAL = new DAL(ofd.FileName);

                    this.MainWindow.ClearNavPanel();
                    this.MainWindow.ViewContentPanel.Controls.Clear();
                    this.MainWindow.Text = System.IO.Path.GetFileName(this.AppState.Database.Path) + " - Combine Sale";
                    this.MainWindow.AddNavButton("Back", this.HandleReturnCruiseLandingClick);
                    CombineCruisePresenter presenter = new CombineCruisePresenter(this, mergeFromDAL);
                    ComponentSelectPage view = new ComponentSelectPage(presenter);
                    this.ActivePresentor = presenter;
                    this.SetActiveView(view);
                }
                catch
                {
                    return;
                }
            }
            else
            {
                return;
            }

        }

        public void ShowCombineSaleSubComponentSelectPage()
        {

        }

        public void ShowCruiseLandingLayout()
        {
            if (this.MainWindow.InvokeRequired)
            {
                this.MainWindow.Invoke((Action)this.ShowCruiseLandingLayout);
            }
            else
            {
                this.MainWindow.ClearNavPanel();
                this.MainWindow.ViewContentPanel.Controls.Clear();
                this.MainWindow.Text = System.IO.Path.GetFileName(this.AppState.Database.Path);

                bool enableManageComponents = this.Database.CruiseFileType == CruiseFileType.Master;
                bool enableEditDesign = true;//this.Database.CruiseFileType != CruiseFileType.Component;
                bool enableCreateComponents = this.Database.CruiseFileType != CruiseFileType.Component;
                bool enableCostomize = true;//this.Database.CruiseFileType != CruiseFileType.Component;

                //populate navigation buttons, last first
                this.MainWindow.AddNavButton("Back", this.HandleHomePageClick, true);
                //this.MainWindow.AddNavButton("Combine Sale Data", this.HandleCombineSaleClick);


                this.MainWindow.AddNavButton("Merge Component Files", this.HandleManageComponensClick, enableManageComponents);
                this.MainWindow.AddNavButton("Create Component Files", this.HandleCreateComponentsClick, enableCreateComponents);
                this.MainWindow.AddNavButton("Field Data", this.HandleExportCruiseClick, true);
                this.MainWindow.AddNavButton("Customize", this.HandleCruiseCustomizeClick, enableCostomize);
                this.MainWindow.AddNavButton("Edit Design", this.HandleEditViewCruiseClick, enableEditDesign);
                this.MainWindow.AddNavButton("Design Wizard", this.HandleEditWizardClick, enableEditDesign);
            }
        }

        public void ShowTemplateLandingLayout()
        {
            this.MainWindow.ClearNavPanel();
            this.MainWindow.ViewContentPanel.Controls.Clear();
            this.MainWindow.Text = System.IO.Path.GetFileName(this.AppState.Database.Path);
            this.MainWindow.AddNavButton("Back", this.HandleHomePageClick);
            this.MainWindow.AddNavButton("Import From Cruise", this.HandleImportTemplateClick);
            TemplateEditViewControl view = new TemplateEditViewControl();
            TemplateEditViewPresenter presenter = new TemplateEditViewPresenter(this, view);
            view.Presenter = presenter;

            view.Dock = DockStyle.Fill;
            view.Parent = this.MainWindow.ViewContentPanel;
            ActivePresentor = presenter;
        }

        public void ShowCustomizeCruiseLayout()
        {
            ActivePresentor = null;
            CustomizeCruisePresenter presenter = new CustomizeCruisePresenter(this);
            CruiseCustomizeView view = new CruiseCustomizeView(presenter);
            
            SetActiveView(view);

            ActivePresentor = presenter;
        }

        public void ShowOpenCruiseDialog()
        {
           

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AutoUpgradeEnabled = true;
            dialog.CustomPlaces.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CruiseFiles");
            dialog.InitialDirectory = this.CruiseSaveLocation;
            dialog.Filter = R.Strings.OPEN_CRUISE_FILE_DIALOG_FILTER;
            if(COConverter.IsInstalled() == true)
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

        public void ShowCruiseWizardDiolog()
        {
            DAL tempfile = GetNewOrUnfinishedCruise();

            this.ShowWaitCursor();

            CruiseWizardView view = new CruiseWizardView();
            CruiseWizardPresenter p = new CruiseWizardPresenter(view, this, tempfile);
            p.View = view;
            view.Owner = MainWindow;

            this.ShowDefaultCursor();

            if (view.ShowDialog() == DialogResult.OK)
            {
                this.AppState.Database = p.Database;
                this.ShowCruiseLandingLayout();
                this.ShowCustomizeCruiseLayout();
            }
        }


        

        private void ShowManageComponentsLayout()
        {
            MergeComponentView view = new MergeComponentView();
            MergeComponentsPresenter presenter = new MergeComponentsPresenter(this, view);
            
            this.ActivePresentor = presenter;
            SetActiveView(view);
            
            //this.MainWindow.AddNavButton("Back", this.HandleReturnCruiseLandingClick);
        }

        public void ShowMessage(String message, String caption)
        {
            MessageBox.Show(message, caption);
        }

        private void ShowCreateComponentsLayout()
        {
            CreateComponentView view = new CreateComponentView();
            CreateComponentPresenter presenter = new CreateComponentPresenter(this);

            view.Presenter = presenter;
            presenter.View = view;

            this.ActivePresentor = presenter;
            SetActiveView(view);
        }

        public void ShowImportParts()
        {
            if (AppState.Database == null) { return; }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DAL exterDB = new DAL(ofd.FileName);

                var presenter = new CombineCruisePresenter(this, exterDB);
                //var view = new MergeCruiseView(presenter);
                //CurrentWindow = view;
                //view.Owner = WindowStack.Last() as Form;
                //view.FormClosed += new FormClosedEventHandler(OnWindowClosed);
                //WindowStack.Push(view);
                //return view.ShowDialog();
            }
      
            //DisplayCurrentWindow();
        }

        public void ShowSimpleErrorMessage(string errorMessage)
        {
            using (ErrorMessageDialog dialog = new ErrorMessageDialog())
            {
                dialog.ShowDialog(errorMessage, string.Empty);
            }
        }

        public void ShowDataEditor()
        {
            if (AppState.Database != null)
            {
                if (this.ActivePresentor != null)
                {
                    this.ActivePresentor.HandleSave();
                }
                using (DataEditorView view = new DataEditorView(this))
                {
                    //CurrentWindow = view;
                    view.Owner = MainWindow;
                    //view.Owner = WindowStack.Last() as Form;
                    //view.FormClosed += new FormClosedEventHandler(OnWindowClosed);
                    //WindowStack.Push(view);
                    //DisplayCurrentWindow();
                    view.ShowDialog();
                }
            }
        }


        public void ShowDataExportDialog(IList<TreeVM> Trees, IList<LogVM> Logs, IList<PlotDO> Plots, IList<CountTreeDO> Counts)
        {
            DataExportDialog dialog = new DataExportDialog(this, Trees, Logs, Plots, Counts);
            //dialog.Owner = DataEditorView; //TODO make data export dialog ownen by data editor
            dialog.ShowDialog();
        }

        #endregion


        public static void HandleNonCriticalError(bool showMessage, string message)
        {
            if (showMessage)
            {
                MessageBox.Show(message, "oops");
            }
            else
            {
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private DAL GetNewOrUnfinishedCruise()
        {
            string tempPath = System.IO.Path.GetDirectoryName(Application.LocalUserAppDataPath) + "\\~temp.cruise";
            if (System.IO.File.Exists(tempPath) &&
               (MessageBox.Show("Partially created cruise file found, would you like to resume?\r\nSelecting No will discard existing partial cruise.", "?", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                DAL newCruise = new DAL(tempPath);
                return newCruise;
            }
            return null;
        }

        private  void setDAL(string fileName)
        {
            if (String.IsNullOrEmpty(fileName)) { return; }
            
            try
            {
                AppState.Database = new DAL(fileName);
            }
            catch (System.IO.IOException e)
            {
                throw e;
            }
            catch (System.Exception e)
            {
                throw e;

            }
        }


        public static void SetTreeTDV(TreeVM tree, TreeDefaultValueDO tdv)
        {
            tree.TreeDefaultValue = tdv;
            if (tdv != null)
            {
                tree.Species = tdv.Species;

                tree.LiveDead = tdv.LiveDead;
                tree.Grade = tdv.TreeGrade;
                tree.FormClass = tdv.FormClass;
                tree.RecoverablePrimary = tdv.Recoverable;
                //tree.HiddenPrimary = tdv.HiddenPrimary; //#367
            }
            else
            {
                //tree.Species = string.Empty;
                //tree.LiveDead = string.Empty;
                //tree.Grade = string.Empty;
                //tree.FormClass = 0;
                //tree.RecoverablePrimary = 0;
                //tree.HiddenPrimary = 0;
            }
        }


        public List<string> GetCruiseMethods(bool reconMethodsOnly)
        {
            return this.GetCruiseMethods(this.Database, reconMethodsOnly);
        }

        public List<String> GetCruiseMethods(DAL database, bool reconMethodsOnly)
        {
            if (reconMethodsOnly)
            {
                return new List<string>(CruiseDAL.Schema.Constants.CruiseMethods.RECON_METHODS);
            }
            List<string> cruiseMethods = null;
            try
            {
                cruiseMethods = new List<string>(CruiseMethodsDO.ReadCruiseMethodStr(database, reconMethodsOnly));
            }
            catch { }
            if (cruiseMethods == null || cruiseMethods.Count == 0)
            {
                cruiseMethods = new List<string>(CruiseDAL.Schema.Constants.CruiseMethods.SUPPORTED_METHODS);
            }
            
            return cruiseMethods;
        }

        public object GetTreeTDVList(TreeVM tree)
        {
            if (tree == null) { return Constants.EMPTY_SPECIES_LIST; }
            if (tree.Stratum == null)
            {
                if (this.Database.GetRowCount("CuttingUnitStratum", "WHERE CuttingUnit_CN = ?", tree.CuttingUnit_CN) == 1)
                {
                    tree.Stratum = this.Database.ReadSingleRow<StratumVM>("Stratum", "JOIN CuttingUnitStratum USING (Stratum_CN) WHERE CuttingUnit_CN = ?", tree.CuttingUnit_CN);
                }
                else
                {
                    return Constants.EMPTY_SPECIES_LIST;
                }
            }

            if (tree.SampleGroup == null)
            {
                if (this.Database.GetRowCount("SampleGroup", "WHERE Stratum_CN = ?", tree.Stratum_CN) == 1)
                {
                    tree.SampleGroup = this.Database.ReadSingleRow<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", tree.Stratum_CN);
                }
                if (tree.SampleGroup == null)
                {
                    return Constants.EMPTY_SPECIES_LIST;
                }
            }



            if (tree.SampleGroup.TreeDefaultValues.IsPopulated == false)
            {
                tree.SampleGroup.TreeDefaultValues.Populate();
            }
            return tree.SampleGroup.TreeDefaultValues;

        }

        public object GetSampleGroupsByStratum(long? st_cn)
        {
            if (st_cn == null)
            {
                return new SampleGroupDO[0];
            }
            return this.Database.Read<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", st_cn);
        }

        //private  void DisplayCurrentWindow()
        //{
        //    CurrentWindow.Show();
        //}

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
                if (AppState.Database != null)
                {
                    AppState.Database.Dispose();
                }
            }

            _disposed = true;
        }
        #endregion
    }
}
