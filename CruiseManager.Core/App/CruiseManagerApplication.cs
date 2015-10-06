using CruiseDAL;
using CruiseManager.Core.Constants;
using CruiseManager.Core.ViewInterfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class CruiseManagerApplication : ApplicationBase
    {
        public ISaveHandler SaveHandler { get { return ActivePresentor as ISaveHandler; } }

        public DAL Database { get; set; }
        public bool InSupervisorMode { get; set; }
        protected WindowPresenter WindowPresenter { get { return this.Kernel.Get<WindowPresenter>(); } }

        public void SaveAs()
        {

            var path = WindowPresenter.AskCruiseSaveLocation();
            if (path != null)
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
                if (!this.ExceptionHandler.Handel(ex))
                {
                    throw;
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

        protected void TrySave(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (this.SaveHandler != null)
                {
                    var doSave = this.ActiveView.AskYesNoCancel("You Have Unsaved Changes, Would You Like To Save Before Closing?", "Save Changes?", null);
                    if (doSave == true)
                    {
                        this.Save();
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

        

        protected override void OnActiveViewChanging(System.ComponentModel.CancelEventArgs e)
        {
            this.TrySave(e);
        }

        protected override void OnApplicationClosing(System.ComponentModel.CancelEventArgs e)
        {
            TrySave(e);
        }

        public void OpenFile()
        {
            string location = this.WindowPresenter.AskOpenFileLocation();
            if (location != null)
            {
                this.OpenFile(location);
            }
        }

        public virtual void OpenFile(String filePath)
        {
            bool hasError = false;
            try
            {
                switch (System.IO.Path.GetExtension(filePath))
                {
                    case Strings.CRUISE_FILE_EXTENTION:
                        {
                            try
                            {
                                this.ActiveView.ShowWaitCursor();
                                Database = new DAL(filePath);                                
                            }
                            finally
                            {
                                this.ActiveView.ShowDefaultCursor();
                            }
                            AppState.AddRecentFile(filePath);
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
                            try
                            {
                                this.ActiveView.ShowWaitCursor();
                                this.Database = new DAL(filePath);
                            }
                            finally
                            {
                                this.ActiveView.ShowDefaultCursor();
                            }
                            AppState.AddRecentFile(filePath);
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
            catch (CruiseDAL.ReadOnlyException)
            {
                hasError = true;
                this.ActiveView.ShowMessage("Unable to open file becaus it is read only");
            }
            catch (CruiseDAL.IncompatibleSchemaException ex)
            {
                hasError = true;
                this.ActiveView.ShowMessage("File is not compatible with this version of Cruise Manager: " + ex.Message);
            }
            catch (CruiseDAL.DatabaseExecutionException ex)
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
                WindowPresenter.MainWindow.EnableSaveAs = this.Database != null;

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
                        db = new DAL(PlatformHelper.GetTempCruiseLocation());
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
                    db = new DAL(PlatformHelper.GetTempCruiseLocation(), true);
                }

                return db;
            }
            finally
            {
                this.ActiveView.ShowDefaultCursor();
            }

        }

        public bool HasUnfinishedCruiseFile()
        {
            string tempPath = PlatformHelper.GetTempCruiseLocation();
            return System.IO.File.Exists(tempPath);
        }
    }
}
