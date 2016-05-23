using CruiseManager.Core.CommandModel;
using System.Windows.Forms;

namespace CruiseManager.WinForms.CommandModel
{
    public static class BindableCommandExtentions
    {
        public static void BindTo(this BindableCommand command, Control control)
        {
            var newBinding = new ControlCommandBinding(command, control);
            command.AddBinding(newBinding);
        }

        public static void BindTo(this BindableCommand command, ToolStripItem tsItem)
        {
            var newBinding = new ToolStripItemCommandBinding(command, tsItem);
            command.AddBinding(newBinding);
        }
    }
}