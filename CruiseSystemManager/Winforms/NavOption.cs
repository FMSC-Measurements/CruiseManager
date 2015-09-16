using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSM.Winforms
{
    public class NavOption
    {
        private bool _enabled = true;
        private string _text;
        private Control _control;
        private ToolStripItem _toolStripItem;

        public NavOption(Action clickAction)
        {
            this.ClickAction = clickAction;
        }

        public NavOption(Action clickAction, Control control)
        {
            this.ClickAction = clickAction;
            this.Bind(control);
        }

        public NavOption(Action clickAction, ToolStripItem tsi)
        {
            this.ClickAction = clickAction;
            this.Bind(tsi);
        }

        public NavOption(String text, Action clickAction) : this(clickAction)
        {
            this.Text = text;            
        }
        
        public Action ClickAction { get; set; }

        public bool Enabled
        {
            get { return this._enabled; }
            set
            {
                _enabled = value;
                if (_control != null)
                {
                    _control.Enabled = _enabled;
                }
                if (_toolStripItem != null)
                {
                    _toolStripItem.Enabled = _enabled;
                }
            }
        }

        public String Text
        {
            get { return this._text; }
            set
            {
                this._text = value;
                if (this._text != null && this._control != null)
                {
                    this._control.Text = this._text;
                }
                if (this._text != null && this._toolStripItem != null)
                {
                    this._toolStripItem.Text = this._text;
                }
            }
        }

        public void Bind(Control control)
        {
            this._control = control;
            this._control.Click += this.HandelClick;
            this._control.Enabled = this._enabled;
            this._control.Disposed += this.HandleControlDisposed;
            if (this.Text != null)
            {
                this._control.Text = this.Text;
            }
        }

        public void Bind(ToolStripItem tsi)
        {
            this._toolStripItem = tsi;
            this._toolStripItem.Click += this.HandelClick;
            this._toolStripItem.Enabled = this._enabled;
            this._toolStripItem.Disposed += this.HandleControlDisposed;
            if (this.Text != null)
            {
                this._toolStripItem.Text = this.Text;
            }
        }

        private void HandelClick(object sender, EventArgs e)
        {
            this.ClickAction(); 
        }

        private void HandleControlDisposed(object sender, EventArgs e)
        {
            this._control = null;            
        }

        private void HandleToolStripItemDisposed(object sender, EventArgs e)
        {
            this._toolStripItem = null;
        }
    }
}
