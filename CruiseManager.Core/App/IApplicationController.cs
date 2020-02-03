using CruiseDAL;
using CruiseManager.Core.CommandModel;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;

namespace CruiseManager.Core.App
{
    public interface IApplicationController : INavigationService
    {
        IView ActiveView { get; set; }
        IApplicationState AppState { get; }
        BindableCommand CreateNewCruiseCommand { get; }
        DAL Database { get; set; }
        IExceptionHandler ExceptionHandler { get; }
        bool InSupervisorMode { get; set; }
        StandardKernel Kernel { get; }
        MainWindow MainWindow { get; set; }
        BindableCommand OpenFileCommand { get; }
        IPlatformHelper PlatformHelper { get; }
        BindableCommand SaveAsCommand { get; set; }
        BindableCommand SaveCommand { get; }
        ISaveHandler SaveHandler { get; }
        SetupServiceBase SetupService { get; }
        IUserSettings UserSettings { get; }
        WindowPresenter WindowPresenter { get; }

        void CreateNewCruise();
        DAL GetNewOrUnfinishedCruise();
        List<FileInfo> GetTemplateFiles();
        IView GetView(Type viewType);
        IView GetView<T>() where T : IView;
        bool OnActiveViewChanging(IView currentView);
        void OpenFile();
        void OpenFile(string filePath);
        void RegisterTypes(StandardKernel kernel);
        void Save();
        void SaveAs();
        void SaveAs(string fileName);
        void Start();
    }
}