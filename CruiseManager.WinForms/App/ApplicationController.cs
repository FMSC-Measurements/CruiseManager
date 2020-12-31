using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Utility;
using CruiseManager.WinForms.Components;
using CruiseManager.WinForms.Dashboard;
using CruiseManager.WinForms.EditDesign;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CruiseManager.WinForms.App
{
    public class ApplicationController : ApplicationControllerBase
    {
        private CruiseManager.Utility.COConverter _converter;
        private string _convertedFilePath;

        public ApplicationController()
        {
            this.MainWindow = new FormCSMMain(this);
            this.WindowPresenter.ShowHomeLayout();
        }

        public override void Start()
        {
            Application.Run((Form)MainWindow);
        }

        public override void RegisterTypes(StandardKernel kernel)
        {
            kernel.Bind<IApplicationController>().ToConstant<ApplicationController>(this);

            kernel.Bind<IUserSettings>().To<UserSettings>().InSingletonScope();
            kernel.Bind<SetupServiceBase>().To<SetupService>().InSingletonScope();
            kernel.Bind<IPlatformHelper>().To<PlatformHelper>().InSingletonScope();
            kernel.Bind<IExceptionHandler>().To<ExceptionHandler>().InSingletonScope();
            kernel.Bind<WindowPresenter>().To<WindowPresenterWinForms>().InSingletonScope();
            kernel.Bind<IApplicationState>().To<ApplicationState>().InSingletonScope();

            //bind views
            kernel.Bind<IHomeView>().To<HomeView>();
            kernel.Bind<Core.EditDesign.ViewInterfaces.IEditDesignView>().To<EditDesignView>();
            kernel.Bind<Core.Components.ViewInterfaces.ICreateComponentView>().To<WinForms.Components.CreateComponentView>();
            kernel.Bind<Core.Components.ViewInterfaces.IMergeComponentView>().To<WinForms.Components.MergeComponentView>();
            kernel.Bind<PreMergeReportView>().To<PreMergeReportView>();

            kernel.Bind<IEditTemplateView>().To<WinForms.TemplateEditor.EditTemplateView>();

            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.IFieldSetupView>().To<WinForms.CruiseCustomize.FieldSetupView>();
            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.ITallySetupView>().To<WinForms.CruiseCustomize.TallySetupView>();
            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.ITreeAuditView>().To<WinForms.CruiseCustomize.TreeAuditRulesView>();
            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.ILogGradeAuditView>().To<CruiseCustomize.LogGradeAuditRuleView>();
            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.ILogMatrixView>().To<WinForms.CruiseCustomize.LogMatrixSettingsPage>();
            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.ITreeDefaultsView>().To<WinForms.CruiseCustomize.TreeDefView>();
            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.IVolumeEq>().To<WinForms.CruiseCustomize.VolumeEqView>();
            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.IReportsView>().To<WinForms.CruiseCustomize.ReportsView>();
            kernel.Bind<Core.CruiseCustomize.ViewInterfaces.ICruiseCustomizeContainerView>().To<WinForms.CruiseCustomize.CustomizeCruiseContainerView>();
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
            if (extention.ToLowerInvariant() == Strings.LEGACY_CRUISE_FILE_EXTENTION)
            {
                _converter = new COConverter();
                _convertedFilePath = System.IO.Path.ChangeExtension(filePath, Strings.CRUISE_FILE_EXTENTION);

                Analytics.TrackEvent("COConvert_Start", new Dictionary<string, string>() { { "Path", filePath } });
                _converter.BenginConvert(filePath, _convertedFilePath, null, HandleConvertDone);
                return;
            }
        }

        private void HandleConvertDone(IAsyncResult result)
        {
            try
            {
                if (_converter.EndConvert(result))
                {
                    Analytics.TrackEvent("COConvert_Done", new Dictionary<string, string>() { { "Path", _convertedFilePath} });
                    base.InitializeDAL(_convertedFilePath);
                    this.AppState.AddRecentFile(_convertedFilePath);
                    this.WindowPresenter.ShowCruiseLandingLayout();
                }
                else
                {
                    this.ActiveView.ShowMessage("error unable to convert file");//TODO better error messages
                }
            }
            catch(System.IO.FileNotFoundException e)
            {
                Crashes.TrackError(e);
                MessageBox.Show(e.Message);
            }

            _convertedFilePath = null;
            //_convertDialog = null;
            _converter = null;
        }
    }
}