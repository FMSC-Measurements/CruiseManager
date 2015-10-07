using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CommandModel
{
    public abstract class BindableCommand : Command
    {
        private List<CommandBinding> _bindings = new List<CommandBinding>();


        public BindableCommand(String name, bool enabled = true, IExceptionHandler exceptionHandler = null)
            : base(name, enabled, exceptionHandler)
        {
        }

        public virtual void HandleClick(object sender, EventArgs e)
        {
            this.TryExecute();
        }

        //public void BindTo(Object control)
        //{
        //    CommandBinding binding = GetNewBinding(control);
        //}

        public void AddBinding(CommandBinding binding)
        {
            lock(this._bindings)
            {
                this._bindings.Add(binding);
            }
        }

        public void RemoveBinding(CommandBinding binding)
        {
            lock(_bindings)
            {
                using (binding)
                {
                    this._bindings.Remove(binding);
                }
            }
        }

        public void Unbind(object control)
        {
            var indexOf = this._bindings.FindIndex(x => x.Control.Equals(control));
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


        protected override void OnEnabledChanged()
        {
            lock (this._bindings)
            {
                foreach (CommandBinding binding in this._bindings)
                {
                    binding.OnEnabledChanged(this.Enabled);
                }
            }
        }
    }
}
