using CruiseManager.Core;
using CruiseManager.Core.App;
using CruiseManager.WinForms.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.WinForms.App
{
    public class CruiseManagerWinformsModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IUserSettings>().To<UserSettings>().InSingletonScope();
            Bind<SetupServiceBase>().To<SetupService>().InSingletonScope();
            Bind<IPlatformHelper>().To<PlatformHelper>().InSingletonScope();
            Bind<IExceptionHandler>().To<ExceptionHandler>().InSingletonScope();
            Bind<WindowPresenter>().To<WindowPresenterWinForms>().InSingletonScope();
            Bind<IApplicationState>().To<ApplicationState>().InSingletonScope();
        }
    }
}
