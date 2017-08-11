using System;
using System.Drawing;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Dashboard
{
    public class NavigationButton : Button
    {
        public NavigationButton() : base()
        {
            //this.BackColor = System.Drawing.Color.DarkGreen;
            //this.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            //this.FlatAppearance.BorderSize = 0;
            //this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SaddleBrown;
            //this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.FlatStyle = System.Windows.Forms.FlatStyle.System;//.Flat;
            //this.Font = global::CruiseManager.Properties.Settings.Default.App_NavFont;
            //this.ForeColor = System.Drawing.Color.White;
            //this.UseVisualStyleBackColor = false;
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