using CruiseManager.Core.CommandModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CommandModel
{
    public class ControlCommandBinding : CommandBinding
    {
        public ControlCommandBinding(BindableCommand command, Control control) : base(command)
        {
            this.Control = control;
        }

        public new Control Control
        {
            get { return (Control)base.Control; }
            set
            {
                if (value != null)
                {
                    value.Enabled = Command.Enabled;
                    value.Text = Command.Name;
                    value.Click += Command.HandleClick;
                    value.Disposed += this.Control_Disposed;
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

        protected void Control_Disposed(Object sender, EventArgs e)
        {
            this.Command.RemoveBinding(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                this.Control.Click -= Command.HandleClick;
                this.Control.Disposed -= Control_Disposed;
            }
        }
    }
}
