using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class Command
    {
        private string _name;
        private bool _enabled = true;
        private IExceptionHandler _exceptionHandler;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) { return; }
                _name = value;
                OnNameChanged();
            }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled == value) { return; }
                _enabled = value;
                OnEnabledChanged();
            }
        }

        public IExceptionHandler ExceptionHandler
        {
            get { return _exceptionHandler; }
            set
            {
                if (_exceptionHandler == value) { return; }
                _exceptionHandler = value;
                OnExceptionHandlerChanged();
            }
        }

        public Command(String name, bool enabled = true, IExceptionHandler exceptionHandler = null)
        {
            this._name = name;
            this._enabled = enabled;
            this._exceptionHandler = exceptionHandler;
        }

        public virtual void TryExecute()
        {
            try
            {
                this.Execute();
            }
            catch (Exception ex)
            {
                if (this.ExceptionHandler != null && this.ExceptionHandler.Handel(ex))
                { }
                else
                {
                    throw;
                }
            }
        }

        public abstract void Execute();

        protected abstract void OnNameChanged();

        protected abstract void OnEnabledChanged();

        protected abstract void OnExceptionHandlerChanged(); 

    }
}
