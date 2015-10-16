using CruiseManager.Core.ViewInterfaces;
using CruiseManager.WinForms.Dashboard;
using CruiseManager.WinForms.EditDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.WinForms.App
{
    public class ViewModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IHomeView>().To<HomeView>();
            Bind<Core.EditDesign.ViewInterfaces.IEditDesignView>().To<EditDesignView>();
            Bind<Core.Components.ViewInterfaces.ICreateComponentView>().To<WinForms.Components.CreateComponentView>();            
            Bind<Core.Components.ViewInterfaces.IMergeComponentView>().To<WinForms.Components.MergeComponentView>();

            Bind<CruiseCustomizeView>().To<WinForms.CruiseCustomize.CruiseCustomizeView>();
            Bind<EditTemplateView>().To<WinForms.TemplateEditor.EditTemplateView>();

            //Bind<MainWindow>().To<FormCSMMain>();
        }
    }
}
