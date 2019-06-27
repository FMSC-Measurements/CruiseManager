using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.Constants;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using CruiseManager.Services;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace CruiseManager.Core.App
{
    public abstract class ApplicationControllerBase : IDisposable//, INavigationService
    {
        internal static readonly TreeDefaultValueDO[] EMPTY_SPECIES_LIST = { };

        public Ninject.StandardKernel Kernel { get; private set; } = new StandardKernel();


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
                if (OnDatabaseChanging(_database, value))
                {
                    _database = value;
                    OnDatabaseChanged();
                }
            }
        }

        protected bool OnDatabaseChanging(DAL oldValue, DAL newValue)
        {
            //if (CruiseDAL.Updater.CheckNeedsMajorUpdate(newValue))
            //{
            //    var dialogResult = ActiveView.AskYesNoCancel("Cruise file can be updated. Updating this cruise file will allow it to work with FScruiser on Android.\r\n" +
            //        "However, file will no longer open in older versions of Cruise Manager or FScruiser", "Update Cruise File?");

            //    if (dialogResult.HasValue == false) { return false; }
            //    else if (dialogResult.Value == true)
            //    {
            //        try
            //        {
            //            CruiseDAL.Updater.UpdateMajorVersion(newValue);
            //        }
            //        catch (FMSC.ORM.IncompatibleSchemaException ex)
            //        {
            //            this.ActiveView.ShowMessage("File is not compatible with this version of Cruise Manager: " + ex.Message);
            //            return false;
            //        }
            //        catch (FMSC.ORM.SQLException ex)
            //        {
            //            this.ActiveView.ShowMessage("Unable to open file : " + ex.GetType().Name);
            //            return false;
            //        }
            //    }
            //}

            return true;
        }

        protected void OnDatabaseChanged()
        {
            var database = Database;
            var filePath = database.Path;

            if (database.CruiseFileType.HasFlag(CruiseFileType.Cruise))
            {
                String directroy = System.IO.Path.GetDirectoryName(filePath);
                UserSettings.CruiseSaveLocation = directroy;
                if (database.HasCruiseErrors(out var errors))
                {
                    this.ActiveView.ShowMessage(String.Join("\r\n", errors), null);
                }
                WindowPresenter.ShowCruiseLandingLayout();
            }
            else if (database.CruiseFileType.HasFlag(CruiseFileType.Template))
            {
                String directroy = System.IO.Path.GetDirectoryName(filePath);
                UserSettings.TemplateSaveLocation = directroy;
                WindowPresenter.ShowTemplateLandingLayout();
            }

            AppState.AddRecentFile(filePath);
            SaveCommand.Enabled = this.SaveAsCommand.Enabled = (database != null);
        }

        public bool InSupervisorMode { get; set; }

        //the current save handler is the active logical component of the program that is
        //responsible for saving the user's data
        public ISaveHandler SaveHandler { get { return ActivePresentor as ISaveHandler; } }

        //private IPresentor _activePresentor;



        private IWindow _window;

        public IWindow Window
        {
            get { return _window; }
            set
            {
                _window = value;
            }
        }

        protected INavigationService NavigationService => Window.NavigationService;

        protected IDialogService DialogService => Window.DialogService;

        #endregion properties

        public IExceptionHandler ExceptionHandler { get { return this.Kernel.Get<IExceptionHandler>(); } }
        public SetupServiceBase SetupService { get { return this.Kernel.Get<SetupServiceBase>(); } }
        public IUserSettings UserSettings { get { return this.Kernel.Get<IUserSettings>(); } }
        public IApplicationState AppState { get { return this.Kernel.Get<IApplicationState>(); } }
        public IPlatformHelper PlatformHelper { get { return this.Kernel.Get<IPlatformHelper>(); } }

        protected ApplicationControllerBase()
        {
            RegisterTypes(Kernel);

            Window = CreateWindow();

            this.SaveCommand = new BindableActionCommand("Save", this.Save, enabled: false);
            this.SaveAsCommand = new BindableActionCommand("SaveAs", this.SaveAs, enabled: false);
            this.OpenFileCommand = new BindableActionCommand("Open File", this.OpenFile);
            this.CreateNewCruiseCommand = new BindableActionCommand("New Cruise", this.CreateNewCruise);

#if DEBUG
            InSupervisorMode = true;
#endif
        }

        public abstract void RegisterTypes(StandardKernel kernel);

        public abstract IWindow CreateWindow();


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
            //start wait cursor in case this takes a long time
            try
            {
                Database = new DAL(path);
            }
            //catch (CruiseDAL.DatabaseShareException)
            //{
            //    ActiveView.ShowMessage("File can not be opened in multiple applications");
            //}
            catch (FMSC.ORM.ReadOnlyException)
            {
                DialogService.ShowMessage("Unable to open file because it is read only");
            }
            catch (FMSC.ORM.IncompatibleSchemaException ex)
            {
                DialogService.ShowMessage("File is not compatible with this version of Cruise Manager: " + ex.Message);
            }
            catch (FMSC.ORM.SQLException ex)
            {
                DialogService.ShowMessage("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.IO.IOException ex)
            {
                DialogService.ShowMessage("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.Exception e)
            {
                if (!ExceptionHandler.Handel(e))
                {
                    throw;
                }
            }
        }

        public virtual void OpenFile(String filePath)
        {
            var extension = System.IO.Path.GetExtension(filePath).ToLowerInvariant();

            if (extension == Strings.CRUISE_FILE_EXTENTION
                || extension == Strings.CRUISE_TEMPLATE_FILE_EXTENTION)
            {
                InitializeDAL(filePath);
            }
            else
            {
                ActiveView.ShowMessage("Invalid file name", null);
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
            var fullPath = Path.GetFullPath(fileName);

            FileAttributes atts = File.GetAttributes(fileName);
            if ((atts & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                ActiveView.ShowMessage("This file is read only.");
            }
            else
            {
                //if file path is the same as our current path, skip creating new file and just save
                if (String.Compare(
                    Path.GetFullPath(Database.Path),
                    fullPath,
                    StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    this.Database.CopyAs(fileName, true);
                }

                //save after copying
                this.Save();
                this.MainWindow.Text = System.IO.Path.GetFileName(this.Database.Path);
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
                        "Selecting No will discard existing partial cruise.", "Resume?", true);
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