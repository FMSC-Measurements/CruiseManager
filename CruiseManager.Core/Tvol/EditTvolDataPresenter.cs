using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvol.Data;

namespace CruiseManager.Core.Tvol
{
    public class EditTvolDataPresenter : Presentor, ISaveHandler
    {
        private TvolDatabase _database;

        public TvolDatabase Database
        {
            get { return _database; }
            set
            {
                //OnDatabaseChanging();
                _database = value;
                OnDatabaseChanged();
            }
        }

        public List<Tree> Trees { get; set; }

        public bool HasChangesToSave => throw new NotImplementedException();

        private void OnDatabaseChanged()
        {
            var db = Database;
            if(db != null)
            {
                using (var conn = db.OpenConnection())
                {
                    Trees = conn.Query<Tree>("SELECT * FROM Tree;").ToList();
                }
            }
        }

        public bool HandleSave()
        {
            throw new NotImplementedException();
        }

        public EditTvolDataPresenter(ApplicationControllerBase app)
        {
            Database = app.TVolDatabase;
        }
    }
}
