using CruiseManager.Core.App;
using System;

namespace CruiseManager.Core.CommandModel
{
    public abstract class Command
    {
        private string _name;
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

        public Command(String name, IExceptionHandler exceptionHandler = null)
        {
            this._name = name;
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

        protected virtual void OnExceptionHandlerChanged()
        {
        }
    }
}