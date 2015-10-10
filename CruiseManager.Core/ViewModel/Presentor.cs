using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.ViewModel
{
    //public enum PresenterStatus { Ready, Initializing, Working }

    public abstract class Presentor : IPresentor, IDisposable
    {
        private IView _view;
        //private PresenterStatus _status = PresenterStatus.Ready; 
        //public WindowPresenter WindowPresenter { get; protected set; }
        public ApplicationController ApplicationController { get; protected set; }
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

        //public PresenterStatus Status
        //{
        //    get { return _status; }
        //    protected set
        //    {
        //        _status = value;
        //        OnStatusChanged(value);
        //    }
        //}

        //public event EventHandler<PresenterStatusChangedEventArgs> StatusChanged; 

        protected virtual void OnViewLoad(EventArgs e)
        {

        }

        //protected void OnStatusChanged(PresenterStatus status)
        //{
        //    this.OnStatusChanged(new PresenterStatusChangedEventArgs()
        //    { Status = status });
        //}

        //protected void OnStatusChanged(PresenterStatusChangedEventArgs e)
        //{
        //    if(this.StatusChanged != null)
        //    {
        //        this.StatusChanged(this, e);
        //    }
        //}

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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.View = null;//unwire and null view
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Presentor() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
