using CruiseManager.Core.CommandModel;

using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CommandModel
{
    public class ToolStripItemCommandBinding : CommandBinding<ToolStripItem>
    {
        public ToolStripItemCommandBinding(BindableCommand command, ToolStripItem control) : base(command)
        {
            Target = control;
        }

        public override void OnVisableChanged(bool visable)
        {
            Target.Visible = visable;
        }

        public override void OnEnabledChanged(bool enabled)
        {
            Target.Enabled = enabled;
        }

        public override void OnNameChanged(string name)
        {
            Target.Text = name;
        }

        protected override void WireTarget()
        {
            Target.Enabled = Command.Enabled;
            Target.Text = Command.Name;
            Target.Click += Command.HandleClick;
            Target.Disposed += this.Control_Disposed;
        }

        protected override void UnWireTarget()
        {
            Target.Click -= Command.HandleClick;
            Target.Disposed -= Control_Disposed;
        }

        protected void Control_Disposed(Object sender, EventArgs e)
        {
            Command.RemoveBinding(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (Target != null)
            {
                UnWireTarget();
            }
        }
    }
}