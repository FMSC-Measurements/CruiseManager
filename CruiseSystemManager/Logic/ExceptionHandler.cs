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
            if(e is CSM.Winforms.UserFacingException)
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
    }
}
