using CruiseManager.Core.App;
using System;

namespace CruiseManager.Core.ViewModel
{
    public abstract class Presentor : INPC_Base, IPresentor, IDisposable
    {
        //public WindowPresenter WindowPresenter { get; protected set; }

        #region AppController

        private IApplicationController _appController;

        public IApplicationController ApplicationController
        {
            get { return _appController; }
            protected set
            {
                OnAppControllerChangeing();
                _appController = value;
                OnAppControllerChanged();
            }
        }

        protected virtual void OnAppControllerChangeing()
        {
        }

        protected virtual void OnAppControllerChanged()
        {
            OnPropertyChanged();
        }

        #endregion AppController

        #region View

        private IView _view;

        public IView View
        {
            get { return _view; }
            set
            {
                if (_view == value) { return; }
                if (_view != null) { UnWireView(_view); }
                if (value != null) { WireupView(value); }
                _view = value;
            }
        }

        protected virtual void WireupView(IView view)
        {
            view.Load += this.View_Load;
        }

        protected virtual void UnWireView(IView view)
        {
            view.Load -= this.View_Load;
        }

        private void View_Load(object sender, EventArgs e)
        {
            this.OnViewLoad(e);
        }

        #endregion View

        #region Ctor

        protected Presentor()
        {
        }

        public Presentor(IApplicationController appController) : this()
        {
            ApplicationController = appController;
        }

        #endregion Ctor

        protected virtual void OnViewLoad(EventArgs e)
        {
        }

        #region IDisposable Support

        protected bool IsDisposed { get; set; } // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    ApplicationController = null;
                    this.View = null;//unwire and null view
                }

                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}