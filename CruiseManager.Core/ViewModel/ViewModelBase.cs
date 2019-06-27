using CruiseManager.Core.App;
using CruiseManager.Navigation;
using System;

namespace CruiseManager.Core.ViewModel
{
    public abstract class ViewModelBase : INPC_Base, IDisposable
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public abstract void SetNavParams(NavigationParamiters_Base navParams);

        #region IDisposable Support

        protected bool IsDisposed { get; set; } // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    //ApplicationController = null;
                    //this.View = null;//unwire and null view
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