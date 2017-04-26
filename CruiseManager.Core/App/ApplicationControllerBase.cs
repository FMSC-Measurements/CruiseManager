using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.Constants;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace CruiseManager.Core.App
{
    public abstract class ApplicationControllerBase : IDisposable, INavigationService
    {
        internal static readonly TreeDefaultValueDO[] EMPTY_SPECIES_LIST = { };

        public Ninject.StandardKernel Kernel { get; set; }

        #region ViewCommands

        public BindableCommand CreateNewCruiseCommand { get; protected set; }
        public BindableCommand SaveCommand { get; protected set; }
        public BindableCommand SaveAsCommand { get; set; }
        public BindableCommand OpenFileCommand { get; protected set; }

        #endregion ViewCommands

        #region properties

        DAL _database;

        public DAL Database
        {
            get { return _database; }
            set
            {
                if (_database == value) { return; }
                //OnDatabaseChanging();
                _database = value;
                OnDatabaseChanged();
            }
        }

        private void OnDatabaseChanged()
        {
            SaveCommand.Enabled = this.SaveAsCommand.Enabled = (this.Database != null);
        }

        public bool InSupervisorMode { get; set; }

        //the current save handler is the active logical component of the program that is
        //responsible for saving the user's data
        public ISaveHandler SaveHandler { get { return ActivePresentor as ISaveHandler; } }

        //private IPresentor _activePresentor;

        private IView _activeView;

        public IView ActiveView
        {
            get { return _activeView; }
            set
            {
                if (!OnActiveViewChanging(_activeView)) { return; }
                _activeView = value;
                this.MainWindow.SetActiveView(_activeView);
            }
        }

        protected IPresentor ActivePresentor
        {
            get
            {
                return _activeView?.ViewPresenter;
            }
        }

        private MainWindow _mainWindow;

        public MainWindow MainWindow
        {
            get { return _mainWindow; }
            set
            {
                if (_mainWindow != null) { _mainWindow.Dispose(); }
                if (value != null)
                {
                    value.Closing += this.MainWindow_Closing;
                }
                _mainWindow = value;
            }
        }

        #endregion properties

        public WindowPresenter WindowPresenter { get { return this.Kernel.Get<WindowPresenter>(); } }
        public IExceptionHandler ExceptionHandler { get { return this.Kernel.Get<IExceptionHandler>(); } }
        public SetupServiceBase SetupService { get { return this.Kernel.Get<SetupServiceBase>(); } }
        public IUserSettings UserSettings { get { return this.Kernel.Get<IUserSettings>(); } }
        public IApplicationState AppState { get { return this.Kernel.Get<IApplicationState>(); } }
        public IPlatformHelper PlatformHelper { get { return this.Kernel.Get<IPlatformHelper>(); } }

        protected ApplicationControllerBase()
        {
            this.SaveCommand = new BindableActionCommand("Save", this.Save, enabled: false);
            this.SaveAsCommand = new BindableActionCommand("SaveAs", this.SaveAs, enabled: false);
            this.OpenFileCommand = new BindableActionCommand("Open File", this.OpenFile);
            this.CreateNewCruiseCommand = new BindableActionCommand("New Cruise", this.CreateNewCruise);

#if DEBUG
            InSupervisorMode = true;
#endif
        }

        protected ApplicationControllerBase(NinjectModule viewModule, NinjectModule coreModule) : this()
        {
            this.Kernel = new StandardKernel(viewModule, coreModule);
        }

        public IView GetView<T>() where T : IView
        {
            try
            {
                return this.Kernel.Get<T>();
            }
            catch (Exception e)
            {
                //TODO throw specific exception indication view could not be created
                throw new NotImplementedException(null, e);
            }
        }

        public IView GetView(Type viewType)
        {
            try
            {
                return (IView)this.Kernel.Get(viewType);
            }
            catch (ActivationException e)
            {
                throw new UserFacingException("View Missing", e);
            }
            catch (Exception e)
            {
                //TODO throw specific exception indication view could not be created
                throw new NotImplementedException(null, e);
            }
        }

        public void NavigateTo<T>() where T : IView
        {
            var view = this.GetView<T>();
            this.ActiveView = view;
        }

        public void NavigateTo(Type viewType)
        {
            var view = this.GetView(viewType);
            this.ActiveView = view;
        }

        public abstract void Start();

        public void CreateNewCruise()
        {
            this.WindowPresenter.ShowCruiseWizardDialog();
        }

        public void OpenFile()
        {
            string location = this.WindowPresenter.AskOpenFileLocation();
            if (location != null)
            {
                this.OpenFile(location);
            }
        }

        protected void InitializeDAL(string path)
        {
            this.ActiveView.ShowWaitCursor();
            try
            {
                Database = new DAL(path);
            }
            finally
            {
                this.ActiveView.ShowDefaultCursor();
            }
        }

        public virtual void OpenFile(String filePath)
        {
            bool hasError = false;
            try
            {
                //start wait cursor in case this takes a long time
                this.ActiveView.ShowWaitCursor();
                switch (System.IO.Path.GetExtension(filePath))
                {
                    case Strings.CRUISE_FILE_EXTENTION:
                        {
                            this.InitializeDAL(filePath);
                            AppState.AddRecentFile(filePath);
                            String directroy = System.IO.Path.GetDirectoryName(filePath);
                            this.UserSettings.CruiseSaveLocation = directroy;
                            String[] errors;
                            if (this.Database.HasCruiseErrors(out errors))
                            {
                                this.ActiveView.ShowMessage(String.Join("\r\n", errors), null);
                            }
                            WindowPresenter.ShowCruiseLandingLayout();
                            break;
                        }
                    case Strings.CRUISE_TEMPLATE_FILE_EXTENTION:
                        {
                            this.InitializeDAL(filePath);
                            AppState.AddRecentFile(filePath);
                            String directroy = System.IO.Path.GetDirectoryName(filePath);
                            this.UserSettings.TemplateSaveLocation = directroy;
                            WindowPresenter.ShowTemplateLandingLayout();
                            break;
                        }
                    default:
                        this.ActiveView.ShowMessage("Invalid file name", null);
                        return;
                }
            }
            catch (CruiseDAL.DatabaseShareException)
            {
                hasError = true;
                this.ActiveView.ShowMessage("File can not be opened in multiple applications");
            }
            catch (FMSC.ORM.ReadOnlyException)
            {
                hasError = true;
                this.ActiveView.ShowMessage("Unable to open file because it is read only");
            }
            catch (FMSC.ORM.IncompatibleSchemaException ex)
            {
                hasError = true;
                this.ActiveView.ShowMessage("File is not compatible with this version of Cruise Manager: " + ex.Message);
            }
            catch (FMSC.ORM.SQLException ex)
            {
                hasError = true;
                this.ActiveView.ShowMessage("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.IO.IOException ex)
            {
                hasError = true;
                this.ActiveView.ShowMessage("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.Exception e)
            {
                if (!ExceptionHandler.Handel(e))
                {
                    throw;
                }
            }
            finally
            {
                if (hasError)
                {
                    WindowPresenter.ShowHomeLayout();
                }
            }
        }

        public void Save()
        {
            try
            {
                if (this.SaveHandler != null)
                {
                    SaveHandler.HandleSave();
                }
            }
            catch (Exception ex)
            {
                if (!this.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
        }

        public void SaveAs()
        {
            var path = WindowPresenter.AskSaveAsLocation(this.Database.Path);
            if (path != null)
            {
                try
                {
                    this.SaveAs(path);
                }
                catch (Exception ex)
                {
                    if (!ExceptionHandler.Handel(ex))
                    {
                        throw;
                    }
                }
            }
        }

        public void SaveAs(String fileName)
        {
            try
            {
                this.Database.CopyAs(fileName, true);
                //save after copying
                this.Save();
                this.MainWindow.Text = System.IO.Path.GetFileName(this.Database.Path);
            }
            catch (Exception ex)
            {
                if (!this.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
        }

        public bool OnActiveViewChanging(IView currentView)
        {
            var saveHandler = currentView?.ViewPresenter as ISaveHandler;
            if (saveHandler != null)
            {
                if (saveHandler.HasChangesToSave)
                {
                    var doSave = currentView.AskYesNoCancel("Would You Like To Save Changes?", "Save Changes?", null);
                    if (doSave == null)//user selects cancel
                    {
                        return false;
                        //return false;//don't change views
                    }
                    else if (doSave == true)
                    {
                        try
                        {
                            return saveHandler.HandleSave();
                        }
                        catch (Exception e)
                        {
                            if (!ExceptionHandler.Handel(e))
                            {
                                throw;
                            }
                            return false;
                        }
                    }
                    else//continue without saving
                    { }
                }
            }
            return true;
        }

        protected void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.SaveHandler != null && this.SaveHandler.HasChangesToSave)
                {
                    var doSave = this.ActiveView.AskYesNoCancel("You Have Unsaved Changes, Would You Like To Save Before Closing?", "Save Changes?", null);
                    if (doSave == true)
                    {
                        SaveHandler.HandleSave();
                    }
                    else if (doSave.HasValue == false)
                    {
                        e.Cancel = true;
                    }
                    else if (doSave == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (!this.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
        }

        public DAL GetNewOrUnfinishedCruise()
        {
            DAL db = null;
            try
            {
                if (HasUnfinishedCruiseFile())
                {
                    Nullable<bool> dialogResult = this.ActiveView.AskYesNoCancel(
                        "Partially created cruise file found, would you like to resume?\r\n" +
                        "Selecting No will discard existing partial cruise.", "?", true);
                    if (dialogResult.HasValue == false)
                    {
                        db = null;
                    }
                    else if (dialogResult.Value == true)
                    {
                        this.ActiveView.ShowWaitCursor();
                        db = new DAL(GetTempCruiseLocation());
                    }
                    else
                    {
                        this.ActiveView.ShowWaitCursor();
                        db = new DAL(GetTempCruiseLocation(), true);
                    }
                    //fall through if false
                }
                else
                {
                    this.ActiveView.ShowWaitCursor();
                    db = new DAL(GetTempCruiseLocation(), true);
                }

                return db;
            }
            finally
            {
                this.ActiveView.ShowDefaultCursor();
            }
        }

        #region Static Methods

        public static bool HasUnfinishedCruiseFile()
        {
            string tempPath = GetTempCruiseLocation();
            return System.IO.File.Exists(tempPath);
        }

        public static string GetTempCruiseLocation()
        {
            return System.IO.Path.GetDirectoryName(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + "\\" + Strings.TEMP_FILENAME;
        }

        public List<FileInfo> GetTemplateFiles()
        {
            DirectoryInfo tDir = PlatformHelper.GetTemplateFolder();
            //filter all files ending in .cut
            List<FileInfo> files = new List<FileInfo>(tDir.GetFiles("*" + Constants.Strings.CRUISE_TEMPLATE_FILE_EXTENTION));
            return files;
        }

        #endregion Static Methods

        #region IDisposable Members

        bool _disposed;

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
                if (Database != null)
                {
                    Database.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion IDisposable Members
    }
}