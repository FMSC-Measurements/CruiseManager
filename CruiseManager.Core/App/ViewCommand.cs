using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class ViewCommand
    {
        public List<ViewCommandBinding> _bindings = new List<ViewCommandBinding>();
        

        public ViewCommand(String name, Action clickAction, ExceptionHandler exceptionHandler)
        {
            this.Name = name;
            this.ClickAction = clickAction;
            this.ExceptionHandler = exceptionHandler;
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if(_enabled == value) { return; }
                _enabled = value;
                this.OnEnabledChanged();
            }
        }

        public ExceptionHandler ExceptionHandler { get; set; }

        public String Name
        {
            get { return _name; }
            set
            {
                if (value == _name) { return; }
                _name = value;
                OnNameChanged();
            }
        }

        public Action ClickAction { get; set; }

        public virtual void HandleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Assert(ClickAction != null);
            try
            {
                this.ClickAction();
            }
            catch (Exception ex)
            {
                if(this.ExceptionHandler != null && this.ExceptionHandler.Handel(ex))
                { }
                else
                {
                    throw;
                }
            }
        }

        public void BindTo(Object control)
        {
            ViewCommandBinding binding = GetNewBinding(control);
            this._bindings.Add(binding);
        }

        protected abstract ViewCommandBinding GetNewBinding(object control);


        protected void OnNameChanged()
        {
            lock(this._bindings)
            {
                foreach (ViewCommandBinding binding in this._bindings)
                {
                    binding.OnNameChanged(this.Name);
                }
            }
        }


        protected void OnEnabledChanged()
        {
            lock(this._bindings)
            {
                foreach (ViewCommandBinding binding in this._bindings)
                {
                    binding.OnEnabledChanged(this.Enabled);
                }
            }
        }

        protected void HandleControlDisposed(ViewCommandBinding binding)
        {
            lock(this._bindings)
            {
                this._bindings.Remove(binding);
            }
        }


        protected bool _enabled = true;
        protected String _name;
    }
}
