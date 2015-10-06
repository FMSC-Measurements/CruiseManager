using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.CommandModel
{
    public abstract class BoundCommand : Command
    {
        private List<CommandBinding> _bindings = new List<CommandBinding>();


        public BoundCommand(String name, bool enabled = true, IExceptionHandler exceptionHandler = null)
            : base(name, enabled, exceptionHandler)
        {
        }

        public virtual void HandleClick(object sender, EventArgs e)
        {
            this.TryExecute();
        }

        public void BindTo(Object control)
        {
            CommandBinding binding = GetNewBinding(control);
            this._bindings.Add(binding);
        }

        protected abstract CommandBinding GetNewBinding(object control);

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

        protected void HandleControlDisposed(CommandBinding binding)
        {
            lock (this._bindings)
            {
                this._bindings.Remove(binding);
            }
        }

    }
}
