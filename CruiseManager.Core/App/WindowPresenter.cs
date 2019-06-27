using CruiseDAL.DataObjects;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.Models;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using CruiseManager.Navigation;
using CruiseManager.Services;
using System;
using System.Collections.Generic;

namespace CruiseManager.Core.App
{
    /// <summary>
    /// The purpose of the window presenter is to display all the different forms of the application and
    /// provide a common place to for all the forms to access data and other infomation about the application state.
    /// it is the glue that binds the application together
    /// </summary>
    public abstract class WindowPresenter
    {
        //public static WindowPresenter Instance { get; set; }

        public INavigationService NavigationService { get; }
        public IWindow Window { get; }

        public WindowPresenter(INavigationService navigationService, IWindow window)
        {
            NavigationService = navigationService;
            Window = window;
        }

        public abstract string AskTemplateLocation();

        public abstract String AskSaveAsLocation(string originalPath);

        public abstract string AskOpenFileLocation();

        public abstract void ShowAboutDialog();

        public abstract TreeDefaultValueDO ShowAddTreeDefault();

        public abstract TreeDefaultValueDO ShowAddTreeDefault(TreeDefaultValueDO newTDV);

        public abstract void ShowEditTreeDefault(TreeDefaultValueDO tdv);

        public abstract void ShowImportTemplate();

        public abstract void ShowDataEditor();

        public abstract void ShowDataExportDialog(IEnumerable<TreeVM> Trees, IEnumerable<LogVM> Logs, IEnumerable<PlotDO> Plots, IEnumerable<CountVM> Counts);

        public abstract void ShowEditWizard();

        public abstract void ShowCruiseWizardDialog();

        //public abstract void ShowOpenCruiseDialog();

        public void ShowCruiseLandingLayout()
        {
            if (this.cruiseNavCommands == null)
            {
                this.InitializeCruiseNavOptions();
            }


            this.ShowCustomizeCruiseLayout();
            Window.SetNavCommands(this.cruiseNavCommands);
        }

        private BindableCommand[] cruiseNavCommands;

        private void InitializeCruiseNavOptions()
        {
            this.cruiseNavCommands = new BindableCommand[]
            {
                new BindableActionCommand( "Design Wizard", this.ShowEditWizard),
                new ViewNavigateCommand(this.NavigationService, "Edit Design", typeof(EditDesign.ViewInterfaces.IEditDesignView)),
                new ViewNavigateCommand(this.NavigationService,"Customize", typeof(Core.CruiseCustomize.ViewInterfaces.ICruiseCustomizeContainerView)),
                new BindableActionCommand("Field Data", this.ShowDataEditor),
                new ViewNavigateCommand(this.NavigationService,"Create Component Files", typeof(Components.ViewInterfaces.ICreateComponentView)),
                new ViewNavigateCommand(this.NavigationService,"Merge Component Files", typeof(Components.ViewInterfaces.IMergeComponentView))
            };
        }

        public void ShowCreateComponentsLayout()
        {
            this.NavigationService.NavigateTo<Components.ViewInterfaces.ICreateComponentView>();
        }

        public void ShowCustomizeCruiseLayout()
        {
            this.NavigationService.NavigateTo<Core.CruiseCustomize.ViewInterfaces.ICruiseCustomizeContainerView>();
        }

        public void ShowEditDesign()
        {
            this.NavigationService.NavigateTo(typeof(EditDesign.ViewInterfaces.IEditDesignView));
        }

        public void ShowHomeLayout()
        {
            this.NavigationService.NavigateTo<IHomeView>();

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            // TODO rewire up 
            //this.NavigationService.MainWindow.Text = $"Cruise Manager {version.Major}.{version.Minor:D2}.{version.Build:D2}";

            // TODO
            //this.NavigationService.MainWindow.SetNavCommands(new BindableCommand[]
            //{
            //    this.NavigationService.OpenFileCommand,
            //    this.NavigationService.CreateNewCruiseCommand
            //});
        }

        public void ShowManageComponentsLayout()
        {
            this.NavigationService.NavigateTo<Components.ViewInterfaces.IMergeComponentView>();
        }

        public void ShowTemplateLandingLayout()
        {
            // TODO
            //this.NavigationService.MainWindow.Text = System.IO.Path.GetFileName(this.NavigationService.Database.Path);

            if (templateNavOptions == null)
            {
                this.InitializeTemplateNavOptions();
            }
            this.NavigationService.NavigateTo<IEditTemplateView>();

            Window.SetNavCommands(this.templateNavOptions);
        }

        private BindableCommand[] templateNavOptions;

        private void InitializeTemplateNavOptions()
        {
            this.templateNavOptions = new BindableCommand[]{
                new ViewNavigateCommand(NavigationService, "Customize Template", typeof(IEditTemplateView)),
                new BindableActionCommand("Import From Cruise", this.ShowImportTemplate),
                new ViewNavigateCommand(NavigationService, "Log Audit Rules", typeof(CruiseCustomize.ViewInterfaces.ILogGradeAuditView)),
                new BindableActionCommand("Close File", this.ShowHomeLayout )
            };
        }
    }
}