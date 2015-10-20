using CruiseManager.Core.App;
using CruiseManager.Core.CommandModel;
using CruiseManager.WinForms.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CruiseCustomize
{
    public partial class CustomizeCruiseContainerView : CruiseManager.WinForms.UserControlContainerView, Core.CruiseCustomize.ViewInterfaces.ICruiseCustomizeContainerView
    {
        public CustomizeCruiseContainerView(ApplicationControllerBase appController) : base(appController)
        {
            InitializeComponent();

            this.ViewLinks = new ViewNavigateCommand[]
            {
                new ViewNavigateCommand(this,
                "Field Setup",
                typeof(CruiseManager.Core.CruiseCustomize.ViewInterfaces.IFieldSetupView)),
                new ViewNavigateCommand(this,
                "Tally Setup",
                typeof (CruiseManager.Core.CruiseCustomize.ViewInterfaces.ITallySetupView)),
                new ViewNavigateCommand(this,
                "Tree Audit Rules",
                typeof(Core.CruiseCustomize.ViewInterfaces.ITreeAuditView))
                //,new ViewNavigateCommand(this,
                //"Log Matrix",
                //typeof(Core.CruiseCustomize.ViewInterfaces.ILogMatrixView))
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.NavigateTo(typeof(Core.CruiseCustomize.ViewInterfaces.IFieldSetupView));
        }
    }
}
