using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using CruiseManager.WinForms.App;
using System;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class CustomizeCruiseContainerView : CruiseManager.WinForms.UserControlContainerView, Core.CruiseCustomize.ViewInterfaces.ICruiseCustomizeContainerView
    {
        ExceptionHandler _exceptionHandler = new ExceptionHandler();

        public CustomizeCruiseContainerView(ApplicationControllerBase appController) : base(appController)
        {
            InitializeComponent();

            this.ViewLinks = new ViewNavigateCommand[]
            {
                new ViewNavigateCommand(this,
                "Field Setup",
                typeof(CruiseManager.Core.CruiseCustomize.ViewInterfaces.IFieldSetupView))
                { ExceptionHandler = _exceptionHandler },

                new ViewNavigateCommand(this,
                "Tally Setup",
                typeof (CruiseManager.Core.CruiseCustomize.ViewInterfaces.ITallySetupView))
                { ExceptionHandler = _exceptionHandler },

                new ViewNavigateCommand(this,
                "Tree Audit Rules",
                typeof(Core.CruiseCustomize.ViewInterfaces.ITreeAuditView))
                { ExceptionHandler = _exceptionHandler },

                new ViewNavigateCommand(this,
                "Log Grade Rules",
                typeof(Core.CruiseCustomize.ViewInterfaces.ILogGradeAuditView))
                { ExceptionHandler = _exceptionHandler },

                new ViewNavigateCommand(this,
                "Log Matrix",
                typeof(Core.CruiseCustomize.ViewInterfaces.ILogMatrixView))
                { ExceptionHandler = _exceptionHandler, Enabled = ApplicationController.InSupervisorMode }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.NavigateTo(typeof(Core.CruiseCustomize.ViewInterfaces.IFieldSetupView));
        }
    }
}