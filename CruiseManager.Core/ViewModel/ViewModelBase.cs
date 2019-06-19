using CruiseManager.Core.App;
using System;

namespace CruiseManager.Core.ViewModel
{
    public abstract class ViewModelBase : INPC_Base, IDisposable
    {
        private string _title;

        protected virtual void OnViewLoad(EventArgs e)
        {
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

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