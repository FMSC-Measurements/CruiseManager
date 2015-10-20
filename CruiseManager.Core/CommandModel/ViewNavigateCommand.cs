using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CommandModel
{
    public class ViewNavigateCommand : BindableCommand
    {
        public INavigationService NavigationService { get; set; }

        public Type ViewType { get; set; }

        public ViewNavigateCommand(INavigationService appController, String text, Type viewType, bool enabled = true) : base(text)
        {
            this.NavigationService = appController;
            this.Name = text;
            this.ViewType = viewType;
            this.Enabled = enabled;
        }

        //protected View_VisableChanged(object sender, EventArgs e)
        //{
        //    foreach(CommandBinding binding in base.b)
        //}

        public override void Execute()
        {
            this.NavigationService.NavigateTo(ViewType);
        }

    }
}
