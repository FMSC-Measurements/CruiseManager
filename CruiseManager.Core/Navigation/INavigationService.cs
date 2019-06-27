using CruiseManager.Core.ViewModel;
using System;
using System.Threading.Tasks;

namespace CruiseManager.Navigation
{
    public interface INavigationService
    {
        void NavigateTo(Type view);

        void NavigateTo<T>() where T : IView;

        void NavigateTo(string name, NavigationParamiters_Base navParams);

        MyDialogResult ShowDialog(Type dialogType);

        Task<MyDialogResult> ShowDialogAsync(Type dialogType);


        MyDialogResult ShowDialog(string name, NavigationParamiters_Base navParams);

        Task<MyDialogResult> ShowDialogAsync(string name, NavigationParamiters_Base navParams);
    }

    public enum MyDialogResult { Unknown, Ok, Cancel }
}