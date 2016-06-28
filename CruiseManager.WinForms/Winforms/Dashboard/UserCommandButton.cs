using System;
using System.Drawing;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Dashboard
{
    public class UserCommandButton : Button
    {
        public UserCommandButton() : base()
        {
            this.BackColor = Color.Transparent;
            this.ForeColor = SystemColors.ControlText;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;

            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = global::CruiseManager.Properties.Settings.Default.App_NavFont;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            using (Graphics g = CreateGraphics())
            {
                Size s = g.MeasureString(this.Text, this.Font, this.Parent.Width - 10).ToSize();
                this.Height = s.Height + 6;
            }
        }
    }
}