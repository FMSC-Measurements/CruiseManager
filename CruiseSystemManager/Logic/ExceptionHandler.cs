using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSM.Common;

namespace CSM.Logic
{
    public class ExceptionHandler : IExceptionHandler
    {
        public void Handel(Exception e)
        {
            if(e is CSM.UI.UserFacingException)
            {
                 MessageBox.Show(e.Message);
            }
            else if (e is CruiseDAL.UniqueConstraintException)
            {
                MessageBox.Show("Record Already Exists");
            }
            else
            {
                throw new Exception(string.Empty, e);
            }
        }

        public void Handel(CSM.UI.UserFacingException e)
        {
            MessageBox.Show(e.Message);
        }

        public void Handel(CruiseDAL.UniqueConstraintException e)
        {
            MessageBox.Show("Record Already Exists");
        }
    }
}
