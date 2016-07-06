using System;

namespace CruiseManager.Core.CommandModel
{
    public abstract class CommandBinding : IDisposable
    {
        protected BindableCommand Command { get; set; }

        protected CommandBinding(BindableCommand command)
        {
            this.Command = command;
        }

        public abstract bool IsBoundTo(object value);

        public abstract void OnNameChanged(String name);

        public abstract void OnEnabledChanged(bool enabled);

        public abstract void OnVisableChanged(bool visable);

        #region IDisposable Support

        protected bool _isDisposed = false; // To detect redundant calls

        protected abstract void Dispose(bool disposing);

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing).
            Dispose(true);
        }

        #endregion IDisposable Support
    }

    public abstract class CommandBinding<T> : CommandBinding, IDisposable where T : class
    {
        T _target;

        protected CommandBinding(BindableCommand command)
            : base(command)
        { }

        public T Target
        {
            get { return _target; }
            set
            {
                if (_target != null)
                { UnWireTarget(); }
                _target = value;
                if (_target != null)
                { WireTarget(); }
            }
        }

        public override bool IsBoundTo(object value)
        {
            if (_target == null || value == null) { return false; }
            return object.ReferenceEquals(_target, value);
        }

        protected abstract void WireTarget();

        protected abstract void UnWireTarget();
    }
}