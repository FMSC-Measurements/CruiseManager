using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CruiseManager.Core.CommandModel
{
    public class BindableActionCommand : BindableCommand
    {
        public Action Action { get; protected set; }

        public BindableActionCommand(String name, Action action, bool enabled = true, IExceptionHandler exceptionHandler = null)
            : base(name, enabled, exceptionHandler)
        {
            Debug.Assert(action != null);
            Action = action;
        }

        public override void Execute()
        {
            Debug.Assert(this.Action != null);
            this.Action();
        }

    }
}
