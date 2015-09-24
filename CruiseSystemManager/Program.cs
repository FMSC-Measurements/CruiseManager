using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Logger;
using System.Diagnostics;
using CruiseManager.App;
using CruiseManager.Core.App;

namespace CruiseManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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

            Trace.TraceInformation("Application Started @{0}", DateTime.Now);
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

            UserSettings.Instance = new UserSettingsWinforms();
            ExceptionHandler.Instance = new ExceptionHandler();
            WindowPresenter.Instance = new WindowPresenterWinForms();
            SetupService.Instance = new SetupServiceWinForms();

            ApplicationController.Instance = new ApplicationControllerWinForms(
                WindowPresenter.Instance,
                ExceptionHandler.Instance,
                UserSettings.Instance,
                SetupService.Instance);


            if(!string.IsNullOrEmpty(dalPath) )
            {
                ApplicationController.Instance.OpenFile(dalPath);
            }


            WindowPresenter.Instance.Run();
            WindowPresenter.Instance.Dispose();

            Trace.TraceInformation("Application Ended @{0}", DateTime.Now);
            Trace.Close();
        }

        //static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    Trace.TraceError(e.ExceptionObject.ToString());
        //}

        //static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        //{
        //    Trace.TraceError(e.Exception.ToString());
        //}
    }
}
