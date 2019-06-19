using CruiseManager.Core.App;
using System;

namespace CruiseManager.Core.ViewModel
{
    public abstract class ViewModelBase : INPC_Base, IDisposable
    {
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