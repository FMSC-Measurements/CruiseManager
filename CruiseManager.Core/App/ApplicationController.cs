using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.Models;
using System.Xml.Serialization;
using System.IO;
using CruiseManager.Core.Constants;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.ViewInterfaces;
using System.ComponentModel;

namespace CruiseManager.Core.App
{
    public abstract class ApplicationController : IDisposable
    {
        internal static readonly TreeDefaultValueDO[] EMPTY_SPECIES_LIST = new TreeDefaultValueDO[] { };

        

        #region ViewCommands
        public BindableCommand CreateNewCruiseCommand { get; protected set; }
        public BindableCommand SaveCommand { get; protected set; }
        public BindableCommand SaveAsCommand { get; set; }
        public BindableCommand OpenFileCommand { get; protected set; }
        #endregion

        #region properties
        public DAL Database { get; set; }
        public bool InSupervisorMode { get; set; }

        //the current save handler is the active locical component of the program that is 
        //responceable for saving the user's data 
        public ISaveHandler SaveHandler { get { return ActivePresentor as ISaveHandler; } }
        //private IPresentor _activePresentor;

        private IView _activeView;
        public IView ActiveView
        {
            get { return _activeView;  }
            set
            {
                //if(SaveHandler != null)
                if (_activeView != null && _activeView.ViewPresenter is ISaveHandler)
                {
                    if (SaveHandler.HasChangesToSave)
                    {
                        var doSave = _activeView.AskYesNoCancel("You Have Unsaved Changes, Would You Like To Save Before Closing?", "Save Changes?", null);
                        if (doSave == null)//user selects cancel
                        {
                            return;
                            //return false;//don't change views
                        }
                        else if (doSave == true)
                        {
                            SaveHandler.HandleSave();
                        }
                        else//continue without saving
                        { }
                    }
                }
                //this.ActivePresentor = view.ViewPresenter;
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
            //set
            //{
            //    _activePresentor = value;
            //    if (SaveHandler == null)
            //    {
            //        this.SaveAsCommand.Enabled = this.SaveCommand.Enabled = false;
            //        //this.WindowPresenter.MainWindow.EnableSave = false;
            //    }
            //    else
            //    {
            //        this.SaveAsCommand.Enabled = this.SaveCommand.Enabled = true;
            //        //this.WindowPresenter.MainWindow.EnableSave = SaveHandler.CanHandleSave;
            //    }
            //}
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
        #endregion

        #region Constructor Properties

        public WindowPresenter WindowPresenter { get; protected set; }
        public ExceptionHandler ExceptionHandler { get; protected set; }
        public SetupService SetupService { get; set; }
        public IUserSettings UserSettings { get; set; }
        public IApplicationState AppState { get; protected set; }
        public PlatformHelper PlatformHelper { get; protected set; }
        #endregion

        protected ApplicationController(WindowPresenter windowPresenter, 
            ExceptionHandler exceptionHandler, 
            IUserSettings userSettings, 
            SetupService setupService, 
            IApplicationState applicationState,
            PlatformHelper platformHelper)
        {
            this.WindowPresenter = windowPresenter;
            this.WindowPresenter.ApplicationController = this;
            this.ExceptionHandler = exceptionHandler;
            this.UserSettings = userSettings;
            this.SetupService = setupService;
            this.AppState = applicationState;
            this.PlatformHelper = platformHelper;

            this.SaveCommand = new BindableActionCommand("Save", this.Save);
            this.SaveAsCommand = new BindableActionCommand("SaveAs", this.SaveAs);
            this.OpenFileCommand = new BindableActionCommand("Open File", this.OpenFile);
            this.CreateNewCruiseCommand = new BindableActionCommand("New Cruise", this.CreateNewCruise);
#if DEBUG
            InSupervisorMode = true;
#endif
        }


        //public bool ChangeView(IView view)
        //{
        //    if (SaveHandler != null)
        //    {
        //        if (SaveHandler.HasChangesToSave)
        //        {
        //            var doSave = this.WindowPresenter.AskYesNoCancel("You Have Unsaved Changes, Would You Like To Save Before Closing?", "Save Changes?", null);
        //            if (doSave == null)//user selects cancel
        //            {
        //                return false;//don't change views
        //            }
        //            else if (doSave == true)
        //            {
        //                SaveHandler.HandleSave();
        //            }
        //            else//continue without saving
        //            { }
        //        }
        //    }
        //    this.ActivePresentor = view.ViewPresenter;
        //    this.WindowPresenter.MainWindow.SetActiveView(view);
        //    return true;
        //}

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

        public abstract void OpenFile(String filePath);

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
                if(!this.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
                
            }
        }

        public void SaveAs()
        {
            var path = WindowPresenter.AskCruiseSaveLocation();
            if(path != null)
            {
                this.SaveAs(path);
            }
        }

        public void SaveAs(String fileName)
        {
            try
            {
                if (this.Database.CopyAs(fileName))
                {
                    //save after copying 
                    this.Save();
                    this.MainWindow.Text = System.IO.Path.GetFileName(this.Database.Path);
                }
            }
            catch (Exception ex)
            {
                if(!this.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
        }

        protected void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.SaveHandler != null)
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
                    if (dialogResult.HasValue && dialogResult.Value == true)
                    {
                        this.ActiveView.ShowWaitCursor();
                        db = new DAL(GetTempCruiseLocation());
                    }
                    else if (dialogResult.HasValue == false)
                    {
                        return db = null;
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


        #region Common Database methods

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
            if (tree == null) { return EMPTY_SPECIES_LIST; }
            if (tree.Stratum == null)
            {
                if (this.Database.GetRowCount("CuttingUnitStratum", "WHERE CuttingUnit_CN = ?", tree.CuttingUnit_CN) == 1)
                {
                    tree.Stratum = this.Database.ReadSingleRow<StratumVM>("Stratum", "JOIN CuttingUnitStratum USING (Stratum_CN) WHERE CuttingUnit_CN = ?", tree.CuttingUnit_CN);
                }
                else
                {
                    return EMPTY_SPECIES_LIST;
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
                    return EMPTY_SPECIES_LIST;
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
        #endregion

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
        #endregion

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
                if (Database != null)
                {
                    Database.Dispose();
                }
            }

            _disposed = true;
        }
        #endregion

    }
}
