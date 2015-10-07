using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CommandModel
{
    public abstract class CommandBinding : IDisposable
    {
        protected CommandBinding(BindableCommand command)
        {
            this.Command = command;
        }

        public Object Control;
        protected BindableCommand Command;

        

        public abstract void OnNameChanged(String name);
        public abstract void OnEnabledChanged(bool Enabled);


        #region IDisposable Support
        protected bool disposedValue = false; // To detect redundant calls

        protected abstract void Dispose(bool disposing);

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
