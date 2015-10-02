using CruiseManager.Core;
using CruiseManager.Core.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager.App
{
    public class ViewCommandWinForms : ViewCommand
    {
        protected class ControlCommandBinging : CommandBinding
        {
            public ControlCommandBinging(ViewCommand command, Control control) : base(command)
            {
                this.Control = control;                
            }

            public new Control Control {
                get { return (Control)base.Control; }
                set
                {
                    if (value != null)
                    {
                        value.Enabled = Command.Enabled;
                        value.Text = Command.Name;
                        value.Click += Command.HandleClick;
                        value.Disposed += this.OnControlDisposed;
                    }
                    base.Control = value;
                }
            }

            public override void OnEnabledChanged(bool enabled)
            {
                this.Control.Enabled = enabled;
            }

            public override void OnNameChanged(string name)
            {
                this.Control.Text = name;
            }
        }

        protected class ToolStripItemCommandBinding : CommandBinding
        {
            public ToolStripItemCommandBinding(ViewCommand command, ToolStripItem control) : base(command)
            {
                this.Control = control;
                
            }

            public new ToolStripItem Control
            {
                get { return (ToolStripItem)base.Control; }
                set {
                    if(value != null)
                    {
                        value.Enabled = Command.Enabled;
                        value.Text = Command.Name;
                        value.Click += Command.HandleClick;
                        value.Disposed += this.OnControlDisposed;
                        value.Disposed += this.OnControlDisposed;
                    }
                    base.Control = value;
                }
            }

            public override void OnEnabledChanged(bool enabled)
            {
                this.Control.Enabled = enabled;
            }

            public override void OnNameChanged(string name)
            {
                this.Control.Text = name;
            }
        }

        public ViewCommandWinForms(String name, Action clickAction, bool enabled = true, IExceptionHandler exceptionHandler = null) 
            : base(name, clickAction, enabled, exceptionHandler)
        { }

        protected override CommandBinding GetNewBinding(object control)
        {
            if(control is Control)
            {
                return GetNewBinding((Control)control);
            }
            else if (control is ToolStripItem)
            {
                return GetNewBinding((ToolStripItem)control);
            }
            else
            {
                throw new InvalidOperationException("Control Type Not supported");
            }
        }

        protected CommandBinding GetNewBinding(Control control)
        {

            return new ControlCommandBinging(this, control);
        }

        protected CommandBinding GetNewBinding(ToolStripItem control)
        {

            return new ToolStripItemCommandBinding(this, control);
        }

        protected override void OnExceptionHandlerChanged()
        {
            throw new NotImplementedException();
        }
    }
}
