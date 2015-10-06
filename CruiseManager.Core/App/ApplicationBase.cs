using CruiseManager.Core.ViewInterfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class ApplicationBase
    {
        protected StandardKernel Kernel { get; set; }

        protected abstract void InitializeContext();

        protected IView GetView(Type type)
        {
            var view = this.Kernel.Get<IView>(type.Name);
            return view;
        }

        public void NavigateTo(Type viewType)
        {
            var view = GetView(viewType);
            this.ActiveView = view; 
        }

        public IExceptionHandler ExceptionHandler { get { return this.Kernel.Get<IExceptionHandler>(); } }
        public SetupService SetupService { get { return this.Kernel.Get<SetupService>(); } }
        public IUserSettings UserSettings { get { return this.Kernel.Get<IUserSettings>(); } }
        public IApplicationState AppState { get { return this.Kernel.Get<IApplicationState>(); } }
        public PlatformHelper PlatformHelper { get { return this.Kernel.Get<PlatformHelper>(); } }

        public MainWindow MainWindow { get; set; }

        private IView _activeView;
        public IView ActiveView
        {
            get { return _activeView; }
            set
            {
                if(_activeView == value) { return; }
                var e = new System.ComponentModel.CancelEventArgs();
                OnActiveViewChanging(e);
                if (!e.Cancel)
                {
                    _activeView = value;
                    this.MainWindow.SetActiveView(_activeView);
                }
            }

        }

        protected IPresentor ActivePresentor
        {
            get
            {
                return _activeView?.ViewPresenter;
            }
        }

        protected abstract void OnActiveViewChanging(System.ComponentModel.CancelEventArgs e);
        protected abstract void OnApplicationClosing(System.ComponentModel.CancelEventArgs e);

        protected void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.OnApplicationClosing(e);
        }

    }
}
