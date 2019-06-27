using CruiseManager.Core.App;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using CruiseManager.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Services
{
    public class NavigationService : INavigationService
    {
        protected IContainerService Container { get; }
        protected IDialogService DialogService { get; }
        protected IExceptionHandler ExceptionHandler { get; }

        private IView _activeView;

        protected IView ActiveView
        {
            get { return _activeView; }
            set
            {
                if (!OnActiveViewChanging(_activeView)) { return; }
                _activeView = value;
                this.Window.SetActiveView(_activeView);
            }
        }

        protected ViewModelBase AcriveViewModel
        {
            get
            {
                return _activeView?.ViewModel;
            }
        }

        protected ISaveHandler SaveHandler { get { return AcriveViewModel as ISaveHandler; } }

        private IWindow _window;

        public NavigationService(IWindow window, IContainerService container, IDialogService dialogService)
        {
            Window = window ?? throw new ArgumentNullException(nameof(window));
            Container = container ?? throw new ArgumentNullException(nameof(container));
            DialogService = dialogService;
            ExceptionHandler = (IExceptionHandler)container.Get(typeof(IExceptionHandler));
        }

        protected IWindow Window
        {
            get { return _window; }
            set
            {
                if (_window != null) { _window.Dispose(); }
                if (value != null)
                {
                    value.Closing += this.Window_Closing;
                }
                _window = value;
            }
        }

        public IView GetView<T>() where T : IView
        {
            return (T)GetView(typeof(T));
        }

        public IView GetView(Type viewType)
        {
            try
            {
                var view = (IView)Container.Get(viewType);
                return view;
            }
            catch (ActivationException e)
            {
                throw new UserFacingException("View Missing", e);
            }
            catch (Exception e)
            {
                //TODO throw specific exception indication view could not be created
                throw new NotImplementedException(null, e);
            }
        }

        public void NavigateTo<T>() where T : IView
        {
            var view = this.GetView<T>();
            this.ActiveView = view;
        }

        public void NavigateTo(Type viewType)
        {
            var view = this.GetView(viewType);
            this.ActiveView = view;
        }

        public bool OnActiveViewChanging(IView currentView)
        {
            var saveHandler = currentView?.ViewModel as ISaveHandler;
            if (saveHandler != null)
            {
                if (saveHandler.HasChangesToSave)
                {
                    var doSave = DialogService.AskYesNoCancel("Would You Like To Save Changes?", "Save Changes?", null);
                    if (doSave == null)//user selects cancel
                    {
                        return false;
                        //return false;//don't change views
                    }
                    else if (doSave == true)
                    {
                        try
                        {
                            return saveHandler.HandleSave();
                        }
                        catch (Exception e)
                        {
                            if (!ExceptionHandler.Handel(e))
                            {
                                throw;
                            }
                            return false;
                        }
                    }
                    else//continue without saving
                    { }
                }
            }
            return true;
        }

        protected void Window_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.SaveHandler != null && this.SaveHandler.HasChangesToSave)
                {
                    var doSave = DialogService.AskYesNoCancel("You Have Unsaved Changes, Would You Like To Save Before Closing?", "Save Changes?", null);
                    if (doSave == true)
                    {
                        SaveHandler.HandleSave();
                    }
                    else if (doSave.HasValue == false)
                    {
                        e.Cancel = true;
                    }
                    else if (doSave == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (!this.ExceptionHandler.Handel(ex))
                {
                    throw;
                }
            }
        }
    }
}
