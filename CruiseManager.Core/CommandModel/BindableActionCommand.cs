using CruiseManager.Core.App;
using System;
using System.Diagnostics;

namespace CruiseManager.Core.CommandModel
{
    public class BindableActionCommand : BindableCommand
    {
        public Action Action { get; protected set; }

        public BindableActionCommand(String name, Action action, bool enabled = true, bool visable = true, IExceptionHandler exceptionHandler = null)
            : base(name, enabled, visable, exceptionHandler)
        {
            Debug.Assert(action != null);
            Action = action;
        }

        public override void Execute()
        {
            Debug.Assert(this.Action != null);
            Action();
        }
    }
}