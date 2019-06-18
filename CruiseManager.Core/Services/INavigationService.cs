using CruiseManager.Core.ViewModel;
using System;

namespace CruiseManager.Services
{
    public interface INavigationService
    {
        void NavigateTo(Type view);

        void NavigateTo<T>() where T : IView;
    }
}