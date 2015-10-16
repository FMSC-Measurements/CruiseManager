using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CommandModel
{
    public class ViewNavigateCommand : BindableCommand
    {
        public ApplicationControllerBase ApplicationController { get; set; }

        public Type ViewType { get; set; }
        //public String ViewName { get; set; }

        public ViewNavigateCommand(ApplicationControllerBase appController, String text, Type viewType, bool enabled = true) : base(text)
        {
            this.ApplicationController = appController;
            this.Name = text;
            this.ViewType = viewType;
            this.Enabled = enabled;
        }

        public override void Execute()
        {
            this.ApplicationController.NavigateTo(ViewType);
        }

    }
}
