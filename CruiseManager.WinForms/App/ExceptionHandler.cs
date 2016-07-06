﻿using CruiseManager.Core.App;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.App
{
    public class ExceptionHandler : IExceptionHandler
    {
        public bool Handel(Exception e)
        {
            if (e is UserFacingException)
            {
                //WindowPresenter.Instance.ShowMessage(e.Message, null);
                //return true;
                MessageBox.Show(e.Message);
                return true;
            }
            else if (e is FMSC.ORM.UniqueConstraintException)
            {
                //WindowPresenter.Instance.ShowMessage("Record Already Exists", null);
                MessageBox.Show("Record Already Exists");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}