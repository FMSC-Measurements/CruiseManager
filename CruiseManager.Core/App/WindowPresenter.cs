using CruiseDAL.DataObjects;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.Models;
using CruiseManager.Core.ViewInterfaces;
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

        public ApplicationControllerBase ApplicationController
        {
            get;
            set;
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
            if (this.ApplicationController.MainWindow.InvokeRequired)
            {
                this.ApplicationController.MainWindow.Invoke((Action)this.ShowCruiseLandingLayout);
            }
            else
            {
                this.ApplicationController.MainWindow.ClearActiveView();
                this.ApplicationController.MainWindow.Text = System.IO.Path.GetFileName(this.ApplicationController.Database.Path);

                if (this.cruiseNavCommands == null)
                {
                    this.InitializeCruiseNavOptions();
                }

                this.ApplicationController.MainWindow.SetNavCommands(this.cruiseNavCommands);
                this.ShowCustomizeCruiseLayout();
            }
        }

        private BindableCommand[] cruiseNavCommands;

        private void InitializeCruiseNavOptions()
        {
            this.cruiseNavCommands = new BindableCommand[]
            {
                new BindableActionCommand( "Design Wizard", this.ShowEditWizard),
                new ViewNavigateCommand(this.ApplicationController, "Edit Design", typeof(EditDesign.ViewInterfaces.IEditDesignView)),
                new ViewNavigateCommand(this.ApplicationController,"Customize", typeof(Core.CruiseCustomize.ViewInterfaces.ICruiseCustomizeContainerView)),
                new BindableActionCommand("Field Data", this.ShowDataEditor),
                new ViewNavigateCommand(this.ApplicationController,"Create Component Files", typeof(Components.ViewInterfaces.ICreateComponentView)),
                new ViewNavigateCommand(this.ApplicationController,"Merge Component Files", typeof(Components.ViewInterfaces.IMergeComponentView)),
                new ViewNavigateCommand(this.ApplicationController, "Create Tvol File", typeof(WinForms.Tvol.CreateTvolView))
            };
        }

        public void ShowCreateComponentsLayout()
        {
            this.ApplicationController.NavigateTo<Components.ViewInterfaces.ICreateComponentView>();
        }

        public void ShowCustomizeCruiseLayout()
        {
            this.ApplicationController.NavigateTo<Core.CruiseCustomize.ViewInterfaces.ICruiseCustomizeContainerView>();
        }

        public void ShowEditDesign()
        {
            this.ApplicationController.NavigateTo(typeof(EditDesign.ViewInterfaces.IEditDesignView));
        }

        public void ShowHomeLayout()
        {
            this.ApplicationController.NavigateTo<IHomeView>();

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.ApplicationController.MainWindow.Text = $"Cruise Manager {version.Major}.{version.Minor:D2}.{version.Build:D2}";

            this.ApplicationController.MainWindow.SetNavCommands(new BindableCommand[]
            {
                this.ApplicationController.OpenFileCommand,
                this.ApplicationController.CreateNewCruiseCommand
            });
        }

        public void ShowManageComponentsLayout()
        {
            this.ApplicationController.NavigateTo<Components.ViewInterfaces.IMergeComponentView>();
        }

        public void ShowTemplateLandingLayout()
        {
            this.ApplicationController.MainWindow.Text = System.IO.Path.GetFileName(this.ApplicationController.Database.Path);

            if (templateNavOptions == null)
            {
                this.InitializeTemplateNavOptions();
            }
            this.ApplicationController.NavigateTo<EditTemplateView>();

            this.ApplicationController.MainWindow.SetNavCommands(this.templateNavOptions);
        }

        private BindableCommand[] templateNavOptions;

        private void InitializeTemplateNavOptions()
        {
            this.templateNavOptions = new BindableCommand[]{
                new ViewNavigateCommand(ApplicationController, "Customize Template", typeof(EditTemplateView)),
                new BindableActionCommand("Import From Cruise", this.ShowImportTemplate),
                new ViewNavigateCommand(this.ApplicationController, "Log Audit Rules", typeof(WinForms.CruiseCustomize.LogGradeAuditRuleView)),
                new BindableActionCommand("Close File", this.ShowHomeLayout )
            };
        }
    }
}