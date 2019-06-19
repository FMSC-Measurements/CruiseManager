using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.ViewModel;
using CruiseManager.Services;
using CruiseManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.CruiseCustomize
{
    public class LogMatrixPresenter : ViewModelBase, IViewLoadAware, ISaveHandler
    {
        bool _isInitialized;
        private IList<LogMatrixDO> _logMatrix;

        public DAL Database { get; }

        public bool HasChangesToSave
        {
            get
            {
                return LogMatrix.Any(x => !x.IsPersisted || x.IsChanged);
            }
        }

        public IList<LogMatrixDO> LogMatrix
        {
            get => _logMatrix;
            protected set => SetProperty(ref _logMatrix, value);
        }

        public LogMatrixPresenter(IDatabaseProvider databaseProvider)
        {
            Database = databaseProvider.Database;
        }

        public void OnViewLoad()
        {
            try
            {
                var logMatrix = this.Database
                    .From<LogMatrixDO>().Query().ToList();
                this.LogMatrix = logMatrix;
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(null, ex);
            }
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
                this.Database.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                errorBuilder.AppendFormat("File save error. Log Matrix data was not saved. <Error details: {0}>", ex.ToString());
                this.Database.RollbackTransaction();
                return false;
            }
        }
    }
}