using System;

namespace CruiseManager.Core.ViewModel
{
    public interface INavigationService
    {
        void NavigateTo(Type view);

        void NavigateTo<T>() where T : IView;
    }
}