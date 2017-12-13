using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel;
using Tvol.Data;

namespace CruiseManager.Core.Tvol
{
    public class EditTvolDataPresenter : Presentor
    {
        private TvolDatabase _database;
        private BindingList<Tree> _trees;

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

        public BindingList<Tree> Trees
        {
            get { return _trees; }
            set { SetValue(value, ref _trees); }
        }

        public EditTvolDataPresenter(ApplicationControllerBase app)
        {
            Database = app.TVolDatabase;
        }

        private void OnDatabaseChanged()
        {
            var db = Database;
            if (db != null)
            {
                using (var conn = db.OpenConnection())
                {
                    Trees = conn.Query<Tree>("SELECT * FROM Tree;").ToBindingList();

                    foreach (var tree in Trees)
                    {
                        tree.PropertyChanged += Tree_PropertyChanged;
                    }
                }
            }
        }

        private void Tree_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == null) { throw new ArgumentNullException(nameof(sender)); }

            var tree = (Tree)sender;

            using (var conn = Database.OpenConnection())
            {
                conn.Update(tree);
            }
        }

        public Tree AddTree()
        {
            var newTree = new Tree() { CreatedDate = DateTime.Now };
            

            using (var conn = Database.OpenConnection())
            {
                conn.Execute("PRAGMA foreign_keys = off;");
                conn.Insert(newTree);
                conn.Execute("PRAGMA foreign_keys = on;");
            }

            newTree.PropertyChanged += Tree_PropertyChanged;
            Trees.Add(newTree);

            return newTree;
        }

        public void DeleteTree(Tree tree)
        {
            if(tree != null)
            {
                using (var conn = Database.OpenConnection())
                {
                    conn.Delete(tree);

                    Trees.Remove(tree);
                }
            }
        }

        
    }
}