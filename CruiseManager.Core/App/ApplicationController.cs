using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.Models;

namespace CruiseManager.Core.App
{
    public abstract class ApplicationController : IDisposable
    {
        public static ApplicationController Instance { get; set; }

        public const string Version = "2015.05.01";
        public const int RECENT_FILE_LIST_SIZE = 10;

        public WindowPresenter WindowPresenter { get; protected set; }
        public IExceptionHandler ExceptionHandler { get; protected set; }
        public ApplicationState AppState { get { return ApplicationState.GetHandle(); } }
        public DAL Database { get; set; }

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
                    _activePresentor.Dispose();
                }

                _activePresentor = value;
                if (SaveHandler == null)
                {
                    this.WindowPresenter.MainWindow.EnableSave = false;
                }
                else
                {
                    this.WindowPresenter.MainWindow.EnableSave = SaveHandler.CanHandleSave;
                }
            }
        }

        #region UserSettings
        public abstract string CruiseSaveLocation { get; set; }
        
        public abstract string TemplateSaveLocation { get; set; }
        
        public abstract string[] RecentFiles { get; }

        #endregion 

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
                this.ExceptionHandler.Handel(ex);
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
                this.ExceptionHandler.Handel(ex);
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
                this.ExceptionHandler.Handel(ex);
            }
        }

        public bool HasUnfinishedCruiseFile()
        {

            string tempPath = GetTempCruisePath();
            return System.IO.File.Exists(tempPath);
        }

        public string GetTempCruisePath()
        {
            return System.IO.Path.GetDirectoryName(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + "\\~temp.cruise";

        }

        public DAL GetNewOrUnfinishedCruise()
        {
            if(HasUnfinishedCruiseFile())
            {
                Nullable<bool> dialogResult = WindowPresenter.AskYesNoCancel("Partially created cruise file found, would you like to resume?\r\nSelecting No will discard existing partial cruise.", "?");
                if(dialogResult.HasValue && dialogResult.Value == true) { return new DAL(GetTempCruisePath()); }
                else if (dialogResult.HasValue == false)
                { return null; }
                //fall through if false
            }
            return new DAL(GetTempCruisePath(), true);
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
        #endregion

        #region Static Methods
        public static string GetApplicationDirectory()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
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
