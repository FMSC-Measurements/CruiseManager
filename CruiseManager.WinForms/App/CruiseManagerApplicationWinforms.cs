using CruiseDAL;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Utility;
using CruiseManager.Winforms.Dashboard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager.App
{
    public class CruiseManagerApplicationWinforms : CruiseManagerApplication
    {
        private CruiseManager.Utility.COConverter _converter;
        private string _convertedFilePath;

        protected override void InitializeContext()
        {
            throw new NotImplementedException();
        }

        public new FormCSMMain MainWindow
        {
            get { return (FormCSMMain)base.MainWindow; }
            set { base.MainWindow = value; }
        }

        public override void OpenFile(string filePath)
        {
            var extention = System.IO.Path.GetExtension(filePath);
            if (extention == Strings.LEGACY_CRUISE_FILE_EXTENTION)
            {
                _converter = new COConverter();
                _convertedFilePath = System.IO.Path.ChangeExtension(filePath, Strings.CRUISE_FILE_EXTENTION);

                _converter.BenginConvert(filePath, _convertedFilePath, null, HandleConvertDone);
            }
            else
            {
                base.OpenFile(filePath);
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

        public override void Start()
        {
            Trace.TraceInformation("Application Started @{0}", DateTime.Now);
            var from = (Form)MainWindow;
            Application.Run(from);
            Trace.TraceInformation("Application Ended @{0}", DateTime.Now);
            Trace.Close();
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

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

            CruiseManagerApplication application = new CruiseManagerApplicationWinforms();
            if(dalPath != null)
            {
                application.OpenFile(dalPath);
            }

            application.Start();

        }


    }
}
