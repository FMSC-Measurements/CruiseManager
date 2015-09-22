using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.App
{
    public class ExceptionHandler : IExceptionHandler
    {
        public static ExceptionHandler Instance { get; set; }

        public void Handel(Exception e)
        {
            if(e is UserFacingException)
            {
                WindowPresenter.Instance.ShowMessage(e.Message, null);
                 //MessageBox.Show(e.Message);
            }
            else if (e is CruiseDAL.UniqueConstraintException)
            {
                WindowPresenter.Instance.ShowMessage("Record Already Exists", null);
                //MessageBox.Show("Record Already Exists");
            }
            else
            {
                throw new Exception(string.Empty, e);
            }
        }
    }
}
