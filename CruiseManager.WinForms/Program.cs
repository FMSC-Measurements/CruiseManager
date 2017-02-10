using CruiseManager.Core.App;
using CruiseManager.WinForms.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager
{
    public static class Program
    {
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

            //#if !DEBUG
            NBug.Settings.UIMode = NBug.Enums.UIMode.Full;
            NBug.Settings.StoragePath = NBug.Enums.StoragePath.WindowsTemp;
            NBug.Settings.Destinations.Add(new NBug.Core.Submission.Tracker.Redmine()
            {
                ApiKey = "6cf4343091c7509dbf27d6afd84a267189b9d3b9",
                CustomSubject = "CrashReport",
                Url = "http://fmsc-projects.herokuapp.com/projects/csm/",
                ProjectId = "csm",
                TrackerId = "5",
                PriorityId = "1",
                StatusId = "1"
            });

            NBug.Settings.ReleaseMode = true;//only create error reports if debugger not attached
            NBug.Settings.StopReportingAfter = 60;

            AppDomain.CurrentDomain.UnhandledException += NBug.Handler.UnhandledException;
            Application.ThreadException += NBug.Handler.ThreadException;
            //#endif

            using (ApplicationControllerBase applicationController = new ApplicationController(
                new ViewModule(),
                new CruiseManagerWinformsModule()))
            {
                if (dalPath != null)
                {
                    applicationController.OpenFile(dalPath);
                }
                applicationController.Start();
            }

            System.Diagnostics.Trace.TraceInformation("Application Ended @{0}", DateTime.Now);
            System.Diagnostics.Trace.Close();
        }
    }
}