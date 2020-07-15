using CruiseManager.Core.App;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CruiseManager.WinForms.App
{
    public class ExceptionHandler : IExceptionHandler
    {
        public bool Handel(Exception e)
        {
            

            if (e is FMSC.ORM.ReadOnlyException)
            {
                MessageBox.Show("File is Read Only");
                Crashes.TrackError(e);
                return true;
            }
            if (e is System.IO.IOException)
            {
                MessageBox.Show($"File Error {e.GetType().Name}");
                Crashes.TrackError(e);
                return true;
            }     
            if (e is UserFacingException)
            {
                //WindowPresenter.Instance.ShowMessage(e.Message, null);
                //return true;
                Microsoft.AppCenter.Analytics.Analytics.TrackEvent("UserFacingException",
                    new Dictionary<string, string>()
                    {
                        {"Message", e.Message},
                    });

                MessageBox.Show(e.Message);
                return true;
            }
            else if (e is FMSC.ORM.UniqueConstraintException)
            {
                //WindowPresenter.Instance.ShowMessage("Record Already Exists", null);
                MessageBox.Show("Record Already Exists");
                Crashes.TrackError(e);
                return true;
            }
            else if (e is FMSC.ORM.ConstraintException)
            {
                MessageBox.Show(e.Message, "Database Check Failed");
                Crashes.TrackError(e);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}