using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewModel
{
    public interface INavigationService
    {
        void NavigateTo(Type view);
        void NavigateTo<T>() where T : IView;
    }
}
