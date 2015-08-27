using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CSM
{
    public interface IView
    {
   
        void Update();

        void Show();

        void HandleLoad();
    }
}
