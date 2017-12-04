using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Tvol.Data;

namespace CruiseManager.Core.Tvol
{
    public class EditTvolPresenter : ViewModel.Presentor, ViewModel.ISaveHandler
    {
        private TvolDatabase _database;

        public Sale Sale { get; set; }

        public List<TreeProfile> TreeProfiles { get; set; }

        public List<Regression> Regressions { get; set; }

        public TvolDatabase Database
        {
            get { return _database; }
            set
            {
                _database = value;
                OnDatabaseChanged();
            }
        }

        private void OnDatabaseChanged()
        {
            using (var conn = Database.OpenConnection())
            {
                Sale = conn.Query<Sale>("SELECT * FROM Sale LIMIT 1;").FirstOrDefault();
                TreeProfiles = conn.Query<TreeProfile>("SELECT * FROM TreeProfile;").ToList();
                Regressions = conn.Query<Regression>("SELECT * FROM Regression;").ToList();
            }
        }

        

        public EditTvolPresenter(App.ApplicationControllerBase app) : base(app)
        {
            Database = app.TVolDatabase;
        }

        #region ISaveHandler

        public bool HasChangesToSave => throw new NotImplementedException();

        public bool HandleSave()
        {
            throw new NotImplementedException();
        }

        #endregion ISaveHandler
    }
}