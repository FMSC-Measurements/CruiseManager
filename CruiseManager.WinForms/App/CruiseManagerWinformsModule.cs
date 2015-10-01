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
            Bind<IUserSettings>().To<UserSettingsWinforms>().InSingletonScope();
            Bind<SetupService>().To<SetupServiceWinForms>().InSingletonScope();
            Bind<PlatformHelper>().To<PlatformHelperWinForms>().InSingletonScope();
            Bind<ExceptionHandler>().To<ExceptionHandlerWinforms>().InSingletonScope();
            Bind<WindowPresenter>().To<WindowPresenterWinForms>().InSingletonScope();
            Bind<IApplicationState>().To<IApplicationState>().InSingletonScope();

            Bind<ApplicationController>().To<ApplicationControllerWinForms>().InSingletonScope();
            
        }
    }
}
