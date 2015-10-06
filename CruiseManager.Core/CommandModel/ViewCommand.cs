using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CruiseManager.Core.App
{
    public abstract class ViewCommand : BoundCommand
    {
        public Action Action { get; protected set; }

        public ViewCommand(String name, Action action, bool enabled = true, IExceptionHandler exceptionHandler = null)
            : base(name, enabled, exceptionHandler)
        {
        }

        public override void Execute()
        {
            Debug.Assert(this.Action != null);
            this.Action();
        }

    }
}
