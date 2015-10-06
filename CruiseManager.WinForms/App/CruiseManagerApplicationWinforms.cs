using CruiseDAL;
using CruiseManager.Core.App;
using CruiseManager.Core.Constants;
using CruiseManager.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.App
{
    public class CruiseManagerApplicationWinforms : CruiseManagerApplication
    {
        private CruiseManager.Utility.COConverter _converter;
        private string _convertedFilePath;

        protected override void InitializeContext()
        {
            throw new NotImplementedException();
        }

        public override void OpenFile(string filePath)
        {
            var extention = System.IO.Path.GetExtension(filePath);
            if (extention == Strings.LEGACY_CRUISE_FILE_EXTENTION)
            {
                _converter = new COConverter();
                _convertedFilePath = System.IO.Path.ChangeExtension(filePath, Strings.CRUISE_FILE_EXTENTION);

                _converter.BenginConvert(filePath, _convertedFilePath, null, HandleConvertDone);
            }
            else
            {
                base.OpenFile(filePath);
            }
        }

        public void HandleConvertDone(IAsyncResult result)
        {
            if (_converter.EndConvert(result))
            {

                this.Database = new DAL(_convertedFilePath);
                this.AppState.AddRecentFile(_convertedFilePath);
                this.WindowPresenter.ShowCruiseLandingLayout();
            }
            else
            {
                this.ActiveView.ShowMessage("error unable to convert file");//TODO better error messages
            }

            _convertedFilePath = null;
            //_convertDialog = null;
            _converter = null;
        }

        
    }
}
