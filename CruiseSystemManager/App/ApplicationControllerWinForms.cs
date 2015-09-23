using CruiseDAL;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CSM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.App
{
    public class ApplicationControllerWinForms : ApplicationController 
    {
        protected WindowPresenter _myWindowPresenter;
        //protected UserSettings _myUserSettings;
        private CSM.Utility.COConverter _converter;
        private string _convertedFilePath;

        public ApplicationControllerWinForms() : this(WindowPresenter.Instance, UserSettings.Instance, SetupService.GetHandle()) { }

        public ApplicationControllerWinForms(WindowPresenter windowPresenter, UserSettings userSettings, SetupService setupService) : base(userSettings, setupService)
        {
            _myWindowPresenter = windowPresenter;
            //_myUserSettings = userSettings;
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
                _myWindowPresenter.ShowWaitCursor();
                switch (System.IO.Path.GetExtension(filePath))
                {
                    case Strings.CRUISE_FILE_EXTENTION:
                        {
                            Database = new DAL(filePath);
                            UserSettings.AddRecentFile(filePath);
                            String[] errors;
                            if (this.Database.HasCruiseErrors(out errors))
                            {
                                _myWindowPresenter.ShowMessage(String.Join("\r\n", errors), null);
                            }
                            _myWindowPresenter.ShowCruiseLandingLayout();
                            break;
                        }
                    case Strings.CRUISE_TEMPLATE_FILE_EXTENTION:
                        {
                            this.Database = new DAL(filePath);
                            UserSettings.AddRecentFile(filePath);
                            _myWindowPresenter.ShowTemplateLandingLayout();
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
                        _myWindowPresenter.ShowMessage("Invalid file name", null);
                        return;
                }
            }
            catch (CruiseDAL.DatabaseShareException)
            {
                hasError = true;
                _myWindowPresenter.ShowMessage("File can not be opened in multiple applications");
            }
            catch (CruiseDAL.ReadOnlyException)
            {
                hasError = true;
                _myWindowPresenter.ShowMessage("Unable to open file becaus it is read only");
            }
            catch (CruiseDAL.IncompatibleSchemaException ex)
            {
                hasError = true;
                _myWindowPresenter.ShowMessage("File is not compatible with this version of Cruise Manager: " + ex.Message);
            }
            catch (CruiseDAL.DatabaseExecutionException ex)
            {
                hasError = true;
                _myWindowPresenter.ShowMessage("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.IO.IOException ex)
            {
                hasError = true;
                _myWindowPresenter.ShowMessage("Unable to open file : " + ex.GetType().Name);
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Trace.TraceError(e.ToString());
                throw;
            }
            finally
            {
                if (hasError)
                {
                    _myWindowPresenter.ShowHomeLayout();
                }

                _myWindowPresenter.MainWindow.EnableSaveAs = this.Database != null;

                _myWindowPresenter.ShowDefaultCursor();
            }
        }

        public void HandleConvertDone(IAsyncResult result)
        {
            if (_converter.EndConvert(result))
            {

                this.Database = new DAL(_convertedFilePath);
                this.UserSettings.AddRecentFile(_convertedFilePath);
                this._myWindowPresenter.ShowCruiseLandingLayout();
            }
            else
            {
                this._myWindowPresenter.ShowMessage("error unable to convert file");//TODO better error messages
            }

            _convertedFilePath = null;
            //_convertDialog = null;
            _converter = null;
        }
    }
}
