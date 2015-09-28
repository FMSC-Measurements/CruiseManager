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

namespace CruiseManager.Core.App
{
    public abstract class ApplicationController : IDisposable
    {
        internal static readonly TreeDefaultValueDO[] EMPTY_SPECIES_LIST = new TreeDefaultValueDO[] { };

        

        #region ViewCommands
        public ViewCommand CreateNewCruiseCommand { get; protected set; }
        public ViewCommand SaveCommand { get; protected set; }
        public ViewCommand SaveAsCommand { get; set; }
        public ViewCommand OpenFileCommand { get; protected set; }
        #endregion


        public DAL Database { get; set; }
        public bool InSupervisorMode { get; set; }

        //the current save handler is the active locical component of the program that is 
        //responceable for saving the user's data 
        public ISaveHandler SaveHandler { get { return ActivePresentor as ISaveHandler; } }
        private IPresentor _activePresentor;
        public IPresentor ActivePresentor
        {
            get
            {
                return _activePresentor;
            }
            set
            {
                if (SaveHandler != null)
                {
                    SaveHandler.HandleSave();
                }
                if (_activePresentor != null)
                {
                    //_activePresentor.Dispose();
                }

                _activePresentor = value;
                if (SaveHandler == null)
                {
                    this.SaveAsCommand.Enabled = this.SaveCommand.Enabled = false;
                    //this.WindowPresenter.MainWindow.EnableSave = false;
                }
                else
                {
                    this.SaveAsCommand.Enabled = this.SaveCommand.Enabled = SaveHandler.CanHandleSave;
                    //this.WindowPresenter.MainWindow.EnableSave = SaveHandler.CanHandleSave;
                }
            }
        }

        //public static ApplicationController Instance { get; set; }

        #region Constructor Properties

        public WindowPresenter WindowPresenter { get; protected set; }
        public ExceptionHandler ExceptionHandler { get; protected set; }
        public SetupService SetupService { get; set; }
        public UserSettings UserSettings { get; set; }
        public ApplicationState AppState { get; protected set; }
        public PlatformHelper PlatformHelper { get; protected set; }
        #endregion

        protected ApplicationController(WindowPresenter windowPresenter, 
            ExceptionHandler exceptionHandler, 
            UserSettings userSettings, 
            SetupService setupService, 
            ApplicationState applicationState,
            PlatformHelper platformHelper)
        {
            this.WindowPresenter = windowPresenter;
            this.WindowPresenter.ApplicationController = this;
            this.ExceptionHandler = exceptionHandler;
            this.UserSettings = userSettings;
            this.SetupService = setupService;
            this.AppState = applicationState;
            this.PlatformHelper = platformHelper;

            this.SaveCommand = MakeViewCommand("Save", this.Save);
            this.SaveAsCommand = MakeViewCommand("SaveAs", this.SaveAs);
            this.OpenFileCommand = MakeViewCommand("Open File", this.OpenFile);
            this.CreateNewCruiseCommand = MakeViewCommand("New Cruise", this.CreateNewCruise);
#if DEBUG
            InSupervisorMode = true;
#endif
        }

        

        public abstract ViewCommand MakeViewCommand(String name, Action action);


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
                    WindowPresenter.MainWindow.Text = System.IO.Path.GetFileName(this.Database.Path);
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

        public void HandleAppClosing(ref bool cancel)
        {
            try
            {
                if (this.SaveHandler != null)
                {
                    SaveHandler.HandleAppClosing(ref cancel);
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
        

        public DAL GetNewOrUnfinishedCruise()
        {
            if(HasUnfinishedCruiseFile())
            {
                Nullable<bool> dialogResult = WindowPresenter.AskYesNoCancel("Partially created cruise file found, would you like to resume?\r\nSelecting No will discard existing partial cruise.", "?");
                if(dialogResult.HasValue && dialogResult.Value == true) { return new DAL(GetTempCruiseLocation()); }
                else if (dialogResult.HasValue == false)
                { return null; }
                //fall through if false
            }
            return new DAL(GetTempCruiseLocation(), true);
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
