using CruiseManager.Core.App;
using System;
using System.Collections.Generic;

namespace CruiseManager.Core.CommandModel
{
    public abstract class BindableCommand : Command
    {
        bool _enabled;
        bool _visable;
        List<CommandBinding> _bindings = new List<CommandBinding>();

        public BindableCommand(String name, bool enabled = true, bool visable = true, IExceptionHandler exceptionHandler = null)
            : base(name, exceptionHandler)
        {
            _enabled = enabled;
            _visable = visable;
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

        public bool Visable
        {
            get { return _visable; }
            set
            {
                if (_visable == value) { return; }
                _visable = value;
                OnVisableChanged();
            }
        }

        public virtual void HandleClick(object sender, EventArgs e)
        {
            this.TryExecute();
        }

        public void AddBinding(CommandBinding binding)
        {
            lock (this._bindings)
            {
                this._bindings.Add(binding);
            }
        }

        public void RemoveBinding(CommandBinding binding)
        {
            lock (_bindings)
            {
                using (binding)
                {
                    this._bindings.Remove(binding);
                }
            }
        }

        public void Unbind(object control)
        {
            var indexOf = this._bindings.FindIndex(x => x.IsBoundTo(control));
            if (indexOf != -1)
            {
                using (var item = this._bindings[indexOf])
                {
                    this._bindings.RemoveAt(indexOf);
                }
            }
        }

        //protected abstract CommandBinding GetNewBinding(object control);

        protected override void OnNameChanged()
        {
            lock (this._bindings)
            {
                foreach (CommandBinding binding in this._bindings)
                {
                    binding.OnNameChanged(this.Name);
                }
            }
        }

        protected void OnEnabledChanged()
        {
            lock (this._bindings)
            {
                foreach (CommandBinding binding in this._bindings)
                {
                    binding.OnEnabledChanged(this.Enabled);
                }
            }
        }

        protected void OnVisableChanged()
        {
            lock (_bindings)
            {
                foreach (CommandBinding binding in _bindings)
                {
                    binding.OnVisableChanged(_visable);
                }
            }
        }
    }
}