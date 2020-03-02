using CruiseManager.Core.App;
using CruiseManager.WinForms;
using CruiseManager.WinForms.App;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Globalization;
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

#if !DEBUG
            var countryCode = RegionInfo.CurrentRegion.TwoLetterISORegionName;
            AppCenter.SetCountryCode(countryCode);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            AppCenter.Start(Secrets.APPCENTER_KEY_WINDOWS,
                               typeof(Analytics), typeof(Crashes));
#endif

            using (var applicationController = new ApplicationController())
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