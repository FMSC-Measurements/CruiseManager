using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CSM.UI;

namespace CSM
{
    public interface IView
    {
        NavOption[] NavOptions { get; }
        NavOption[] ViewActions { get; }
    }
}
