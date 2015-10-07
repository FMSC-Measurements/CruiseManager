using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CruiseManager.WinForms.Dashboard
{
    public class NavigationButton : Button
    {
        public NavigationButton() :base()
        {
            this.BackColor = System.Drawing.Color.ForestGreen;

            this.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = global::CruiseManager.Properties.Settings.Default.App_NavFont;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UseVisualStyleBackColor = false;
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
