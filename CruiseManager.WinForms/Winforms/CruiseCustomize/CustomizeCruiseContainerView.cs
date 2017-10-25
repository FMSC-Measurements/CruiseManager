using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using CruiseManager.WinForms.App;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class CustomizeCruiseContainerView : CruiseManager.WinForms.UserControlContainerView, Core.CruiseCustomize.ViewInterfaces.ICruiseCustomizeContainerView
    {
        ExceptionHandler _exceptionHandler = new ExceptionHandler();
        public FlatStyle FlatStyle { get; set; }

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
                "Log Audit Rules",
                typeof(Core.CruiseCustomize.ViewInterfaces.ILogGradeAuditView))
                { ExceptionHandler = _exceptionHandler },

                new ViewNavigateCommand(this,
                "Log Matrix",
                typeof(Core.CruiseCustomize.ViewInterfaces.ILogMatrixView))
                { ExceptionHandler = _exceptionHandler, Enabled = ApplicationController.InSupervisorMode },

                new ViewNavigateCommand(this,
                "Tree Defaults",
                typeof(Core.CruiseCustomize.ViewInterfaces.ITreeDefaultsView))
                { ExceptionHandler = _exceptionHandler },

                new ViewNavigateCommand(this,
                "Volume Equations",
                typeof(Core.CruiseCustomize.ViewInterfaces.IVolumeEq))
                { ExceptionHandler = _exceptionHandler },

                new ViewNavigateCommand(this,
                "Reports",
                typeof(Core.CruiseCustomize.ViewInterfaces.IReportsView))
                { ExceptionHandler = _exceptionHandler }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.NavigateTo(typeof(Core.CruiseCustomize.ViewInterfaces.IFieldSetupView));
        }
    }
}