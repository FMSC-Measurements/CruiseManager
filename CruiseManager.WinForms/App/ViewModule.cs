using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Winforms.Dashboard;
using CruiseManager.WinForms.Dashboard;
using CruiseManager.WinForms.EditDesign;
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
            Bind<IEditDesignView>().To<EditDesignViewWinForms>();
            Bind<CreateComponentView>().To<WinForms.Components.CreateComponentViewWinforms>();
            Bind<CruiseCustomizeView>().To<WinForms.CruiseCustomize.CruiseCustomizeViewWinforms>();
            Bind<EditTemplateView>().To<WinForms.TemplateEditor.EditTemplateViewWinForms>();
            Bind<MergeComponentView>().To<WinForms.Components.MergeComponentViewWinforms>();
            //Bind<MainWindow>().To<FormCSMMain>();
        }
    }
}
