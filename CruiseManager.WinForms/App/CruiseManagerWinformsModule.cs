using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.App
{
    public class CruiseManagerWinformsModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<UserSettings>().To<UserSettingsWinforms>().InSingletonScope();
            Bind<SetupService>().To<SetupServiceWinForms>().InSingletonScope();
            Bind<PlatformHelper>().To<PlatformHelperWinForms>().InSingletonScope();
            Bind<ExceptionHandler>().To<ExceptionHandlerWinforms>().InSingletonScope();
            Bind<WindowPresenter>().To<WindowPresenterWinForms>().InSingletonScope();
            Bind<ApplicationState>().To<ApplicationState>().InSingletonScope();

            Bind<ApplicationController>().To<ApplicationControllerWinForms>().InSingletonScope();
            
        }
    }
}
