using CruiseDAL;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Utility;
using CruiseManager.WinForms.Dashboard;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager.App
{
    public class ApplicationControllerWinForms : ApplicationController 
    {
        private CruiseManager.Utility.COConverter _converter;
        private string _convertedFilePath;


        public ApplicationControllerWinForms(NinjectModule viewModule, NinjectModule coreModule)
            :base(viewModule, coreModule)
        {
            Kernel.Bind<ApplicationController>().ToConstant<ApplicationControllerWinForms>(this);
        }

        //public ApplicationControllerWinForms() : this(WindowPresenter.Instance, UserSettings.Instance, SetupService.Instance) { }

        //public ApplicationControllerWinForms(
        //    WindowPresenter windowPresenter, 
        //    ExceptionHandler exceptionHandler, 
        //    IUserSettings userSettings, 
        //    SetupService setupService, 
        //    IApplicationState applicationState, 
        //    PlatformHelper platformHelper) 
        //    : base(windowPresenter, exceptionHandler, userSettings, setupService, applicationState, platformHelper)
        //{

        //}

        public override void Start()
        {
            this.MainWindow = new FormCSMMain(this.WindowPresenter, this);
            this.WindowPresenter.ShowHomeLayout();
            Application.Run((Form)MainWindow);
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
                this.ActiveView.ShowWaitCursor();
                switch (System.IO.Path.GetExtension(filePath))
                {
                    case Strings.CRUISE_FILE_EXTENTION:
                        {
                            Database = new DAL(filePath);
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
                            this.Database = new DAL(filePath);
                            AppState.AddRecentFile(filePath);
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
                this.ActiveView.ShowDefaultCursor();
                if (hasError)
                {
                    WindowPresenter.ShowHomeLayout();
                }

                this.MainWindow.EnableSaveAs = this.Database != null;

                
            }
        }

        public void HandleConvertDone(IAsyncResult result)
        {
            if (_converter.EndConvert(result))
            {

                this.Database = new DAL(_convertedFilePath);
                this.AppState.AddRecentFile(_convertedFilePath);
                this.WindowPresenter.ShowCruiseLandingLayout();
            }
            else
            {
                this.ActiveView.ShowMessage("error unable to convert file");//TODO better error messages
            }

            _convertedFilePath = null;
            //_convertDialog = null;
            _converter = null;
        }

        [STAThread]
        static void Main()
        {
            //just trying out an alternative to the default trace listener
            //System.Diagnostics.Trace.Listeners.Add(
            //        new System.Diagnostics.XmlWriterTraceListener("CSMLog.xml")
            //    );

            /*side note about Trace Listeners:
             * Tracing is a feature built into .net applications to allow 
             * applications to make logs and can be configured using the app.config 
             * file. 
             */

            System.Diagnostics.Trace.TraceInformation("Application Started @{0}", DateTime.Now);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //read command line arguments 
            var args = Environment.GetCommandLineArgs();
            string dalPath = null;
            if (args.Length > 1)
            {
                dalPath = args[1];
            }

            //Provide event handlers to catch any uncaught exceptions
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //FMSC.Utility.ErrorHandling.ErrorHandlers.SendToAddress = "benjaminjcampbell@fs.fes.us";
            Application.ThreadException += FMSC.Utility.ErrorHandling.ErrorHandlers.ThreadException;


            ApplicationController applicationController = new ApplicationControllerWinForms(
                new ViewModule(),
                new CruiseManagerWinformsModule());
            applicationController.Start();
            applicationController.Dispose();

            //WindowPresenter.Instance.Run();
            //WindowPresenter.Instance.Dispose();

            System.Diagnostics.Trace.TraceInformation("Application Ended @{0}", DateTime.Now);
            System.Diagnostics.Trace.Close();
        }
    }
}
