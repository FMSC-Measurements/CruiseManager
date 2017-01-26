using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Utility;
using CruiseManager.WinForms.Dashboard;
using Ninject.Modules;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.App
{
    public class ApplicationController : ApplicationControllerBase
    {
        private CruiseManager.Utility.COConverter _converter;
        private string _convertedFilePath;

        public ApplicationController(NinjectModule viewModule, NinjectModule coreModule)
            : base(viewModule, coreModule)
        {
            Kernel.Bind<ApplicationControllerBase>().ToConstant<ApplicationController>(this);

            this.MainWindow = new FormCSMMain(this);
            this.WindowPresenter.ShowHomeLayout();
        }

        public override void Start()
        {
            Application.Run((Form)MainWindow);
        }

        /// <summary>
        /// opens file for use, handles various exceptions that can occur while opening file,
        /// determines if a cruise file/template file/or legacy cruise file
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
    }
}