using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Winforms.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.App
{
    public class ViewModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IHomeView>().To<HomeView>();

        }
    }
}
