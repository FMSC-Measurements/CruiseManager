using System;
using System.Collections.Generic;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class ViewCommandBinding
    {
        protected ViewCommandBinding(ViewCommand command)
        {
            this.Command = command;
        }

        public Object Control;
        protected ViewCommand Command;

        public event Action<ViewCommandBinding> ControlDisposed; 

        public abstract void OnNameChanged(String name);
        public abstract void OnEnabledChanged(bool Enabled);

        public void OnControlDisposed(Object sender, EventArgs e)
        {
            if(this.ControlDisposed != null)
            this.ControlDisposed(this);
        }
    }
}
