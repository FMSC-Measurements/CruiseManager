using CruiseManager.Core.App;
using Microsoft.AppCenter.Crashes;
using System;
using System.Windows.Forms;

namespace CruiseManager.WinForms.App
{
    public class ExceptionHandler : IExceptionHandler
    {
        public bool Handel(Exception e)
        {
            Crashes.TrackError(e);

            if (e is FMSC.ORM.ReadOnlyException)
            {
                MessageBox.Show("File is Read Only");
                return true;
            }
            if (e is System.IO.IOException)
            {
                MessageBox.Show($"File Error {e.GetType().Name}");
                return true;
            }     
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