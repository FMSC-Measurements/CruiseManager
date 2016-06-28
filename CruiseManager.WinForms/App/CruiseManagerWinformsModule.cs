using CruiseManager.Core.App;

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