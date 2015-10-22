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

namespace CruiseManager.WinForms.App
{
    public class ApplicationController : ApplicationControllerBase 
    {
        private CruiseManager.Utility.COConverter _converter;
        private string _convertedFilePath;


        public ApplicationController(NinjectModule viewModule, NinjectModule coreModule)
            :base(viewModule, coreModule)
        {
            Kernel.Bind<ApplicationControllerBase>().ToConstant<ApplicationController>(this);

            this.MainWindow = new FormCSMMain(this);
            this.WindowPresenter.ShowHomeLayout();

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
            
            Application.Run((Form)MainWindow);
        }


        /// <summary>
        /// opens file for use, handles various exceptions that can ocure whild opening file,
        /// determins if a cruise file/template file/or legacy cruise file
        /// </summary>
        /// <param name="filePath"></param>
        public override void OpenFile(String filePath)
        {
            base.OpenFile(filePath);
            var extention = System.IO.Path.GetExtension(filePath);
            if (extention == Strings.LEGACY_CRUISE_FILE_EXTENTION)
            {
                _converter = new COConverter();
                _convertedFilePath = System.IO.Path.ChangeExtension(filePath, Strings.CRUISE_FILE_EXTENTION);

                _converter.BenginConvert(filePath, _convertedFilePath, null, HandleConvertDone);
                return;
            }
        }

        public void HandleConvertDone(IAsyncResult result)
        {
            if (_converter.EndConvert(result))
            {

                base.InitializeDAL(_convertedFilePath);
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
            AppDomain.CurrentDomain.UnhandledException += FMSC.Utility.ErrorHandling.ErrorHandlers.UnhandledException;
            Application.ThreadException += FMSC.Utility.ErrorHandling.ErrorHandlers.ThreadException;


            ApplicationControllerBase applicationController = new ApplicationController(
                new ViewModule(),
                new CruiseManagerWinformsModule());

            if(dalPath != null)
            {
                applicationController.OpenFile(dalPath);
            }
            applicationController.Start();
            applicationController.Dispose();

            //WindowPresenter.Instance.Run();
            //WindowPresenter.Instance.Dispose();

            System.Diagnostics.Trace.TraceInformation("Application Ended @{0}", DateTime.Now);
            System.Diagnostics.Trace.Close();
        }
    }
}
