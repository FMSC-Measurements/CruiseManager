using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.App
{
    public class ExceptionHandler : IExceptionHandler
    {
        public static ExceptionHandler Instance { get; set; }


        public bool Handel(Exception e)
        {
            if(e is UserFacingException)
            {
                WindowPresenter.Instance.ShowMessage(e.Message, null);
                return true;
                 //MessageBox.Show(e.Message);
            }
            else if (e is CruiseDAL.UniqueConstraintException)
            {
                WindowPresenter.Instance.ShowMessage("Record Already Exists", null);
                return true;
                //MessageBox.Show("Record Already Exists");
            }
            else
            {
                return false;
            }
        }
    }
}
