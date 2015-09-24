using CruiseDAL;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.App
{
    public class ApplicationControllerWinForms : ApplicationController 
    {
        protected WindowPresenter _myWindowPresenter;
        private CruiseManager.Utility.COConverter _converter;
        private string _convertedFilePath;

        //public ApplicationControllerWinForms() : this(WindowPresenter.Instance, UserSettings.Instance, SetupService.Instance) { }

        public ApplicationControllerWinForms(WindowPresenter windowPresenter, ExceptionHandler exceptionHandler, UserSettings userSettings, SetupService setupService) : base(windowPresenter, exceptionHandler, userSettings, setupService)
        {

        } 



        /// <summary>
        /// opens file for use, handles various exceptions that can ocure whild opening file,
        /// determins if a cruise file/template file/or legacy cruise file
        /// </summary>
        /// <param name="filePath"></param>
        public override void OpenFile(String filePath)
        {
            bool hasError = false;
            try
            {
                //start wait cursor incase this takes a long time 
                WindowPresenter.ShowWaitCursor();
                switch (System.IO.Path.GetExtension(filePath))
                {
                    case Strings.CRUISE_FILE_EXTENTION:
                        {
                            Database = new DAL(filePath);
                            UserSettings.AddRecentFile(filePath);
                            String[] errors;
                            if (this.Database.HasCruiseErrors(out errors))
                            {
                                WindowPresenter.ShowMessage(String.Join("\r\n", errors), null);
                            }
                            WindowPresenter.ShowCruiseLandingLayout();
                            break;
                        }
                    case Strings.CRUISE_TEMPLATE_FILE_EXTENTION:
                        {
                            this.Database = new DAL(filePath);
                            UserSettings.AddRecentFile(filePath);
                            WindowPresenter.ShowTemplateLandingLayout();
                            break;
                        }
                    case Strings.LEGACY_CRUISE_FILE_EXTENTION:
                        {
                            _converter = new COConverter();
                            _convertedFilePath = System.IO.Path.ChangeExtension(filePath, Strings.CRUISE_FILE_EXTENTION);

                            _converter.BenginConvert(filePath, _convertedFilePath, null, HandleConvertDone);

                            break;
                        }
                    default:
                        WindowPresenter.ShowMessage("Invalid file name", null);
                        return;
                }
            }
            catch (CruiseDAL.DatabaseShareException)
            {
                hasError = true;
                WindowPresenter.ShowMessage("File can not be opened in multiple applications");
            }
            catch (CruiseDAL.ReadOnlyException)
            {
                hasError = true;
                WindowPresenter.ShowMessage("Unable to open file becaus it is read only");
            }
            catch (CruiseDAL.IncompatibleSchemaException ex)
            {
                hasError = true;
                WindowPresenter.ShowMessage("File is not compatible with this version of Cruise Manager: " + ex.Message);
            }
            catch (CruiseDAL.DatabaseExecutionException ex)
            {
                hasError = true;
                WindowPresenter.ShowMessage("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.IO.IOException ex)
            {
                hasError = true;
                WindowPresenter.ShowMessage("Unable to open file : " + ex.GetType().Name);
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

                WindowPresenter.ShowDefaultCursor();
            }
        }

        public void HandleConvertDone(IAsyncResult result)
        {
            if (_converter.EndConvert(result))
            {

                this.Database = new DAL(_convertedFilePath);
                this.UserSettings.AddRecentFile(_convertedFilePath);
                this.WindowPresenter.ShowCruiseLandingLayout();
            }
            else
            {
                this.WindowPresenter.ShowMessage("error unable to convert file");//TODO better error messages
            }

            _convertedFilePath = null;
            //_convertDialog = null;
            _converter = null;
        }
    }
}
