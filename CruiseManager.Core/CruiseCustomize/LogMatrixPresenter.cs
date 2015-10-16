using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.Core.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class LogMatrixPresenter : Presentor, ISaveHandler
    {
        bool _isInitialized;

        public new CruiseCustomizeView View
        {
            get { return (CruiseCustomizeView)base.View; }
            set { base.View = value; }
        }

        public DAL Database { get { return ApplicationController.Database; } }

        public bool HasChangesToSave
        {
            get
            {
                return LogMatrix.Any(x => !x.IsPersisted || x.HasChanges);
            }
        }

        public List<LogMatrixDO> LogMatrix { get; protected set; }
        

        public LogMatrixPresenter(ApplicationControllerBase appController)
            : base(appController)
        {
            
        }

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            try
            {
                this.LogMatrix = this.Database.Read<LogMatrixDO>("LogMatrix", null);
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
            }
            this.View.UpdateLogMatrix();
        }

        public bool HandleSave()
        {
            var errorBuilder = new StringBuilder();
            return this.SaveLogMatrix(ref errorBuilder);

        }

        private bool SaveLogMatrix(ref StringBuilder errorBuilder)
        {
            if (!_isInitialized) { return true; }
            try
            {
                this.Database.BeginTransaction();

                foreach (LogMatrixDO lm in this.LogMatrix)
                {
                    if (lm.IsPersisted == false)
                    {
                        lm.DAL = this.Database;
                    }
                    lm.Save();
                }
                this.Database.EndTransaction();
                return true;
            }
            catch (Exception ex)
            {
                errorBuilder.AppendFormat("File save error. Log Matrix data was not saved. <Error details: {0}>", ex.ToString());
                this.Database.CancelTransaction();
                return false;
            }
        }

    }
}
