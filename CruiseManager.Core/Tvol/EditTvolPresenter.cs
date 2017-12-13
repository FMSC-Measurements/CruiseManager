using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Tvol.Data;

namespace CruiseManager.Core.Tvol
{
    public class EditTvolPresenter : ViewModel.Presentor
    {
        private TvolDatabase _database;
        private Sale _sale;
        private BindingList<TreeProfile> _treeProfiles;
        private BindingList<Regression> _regressions;

        public Sale Sale
        {
            get { return _sale; }
            set { SetValue(value, ref _sale); }
        }

        public BindingList<TreeProfile> TreeProfiles
        {
            get { return _treeProfiles; }
            set { SetValue(value, ref _treeProfiles); }
        }

        public BindingList<Regression> Regressions
        {
            get { return _regressions; }
            set { SetValue(value, ref _regressions); }
        }

        public TvolDatabase Database
        {
            get { return _database; }
            set
            {
                SetValue(value, ref _database);
                OnDatabaseChanged();
            }
        }

        public EditTvolPresenter(App.ApplicationControllerBase app) : base(app)
        {
            Database = app.TVolDatabase;
        }

        private void OnDatabaseChanged()
        {
            using (var conn = Database.OpenConnection())
            {
                Sale = conn.Query<Sale>("SELECT * FROM Sale LIMIT 1;").FirstOrDefault();

                Sale.PropertyChanged += Sale_PropertyChanged;

                TreeProfiles = conn.Query<TreeProfile>("SELECT * FROM TreeProfile;").ToBindingList();
                
                foreach(var treeProfile in TreeProfiles)
                {
                    treeProfile.PropertyChanged += TreeProfile_PropertyChanged;
                }

                Regressions = conn.Query<Regression>("SELECT * FROM Regression;").ToBindingList();

                foreach(var regression in Regressions)
                {
                    regression.PropertyChanged += Regression_PropertyChanged;
                }
            }
        }

        public void AddTreeProfile()
        {
            var newTreeProfile = new TreeProfile();
            
            using (var conn = Database.OpenConnection())
            {
                conn.Execute("PRAGMA foreign_keys = off;");
                conn.Insert(newTreeProfile);
                conn.Execute("PRAGMA foreign_keys = on;");
            }

            newTreeProfile.PropertyChanged += TreeProfile_PropertyChanged;
            TreeProfiles.Add(newTreeProfile);
        }

        public void DeleteTreeProfile(TreeProfile treeProfile)
        {
            if (treeProfile == null) return;

            using (var conn = Database.OpenConnection())
            {
                conn.Delete(treeProfile);
                TreeProfiles.Remove(treeProfile);
            }
        }

        public void AddRegression()
        {
            var newRegression = new Regression();

            using (var conn = Database.OpenConnection())
            {
                conn.Execute("PRAGMA foreign_keys = off;");
                conn.Insert(newRegression);
                conn.Execute("PRAGMA foreign_keys = on;");
            }

            newRegression.PropertyChanged += Regression_PropertyChanged;
            Regressions.Add(newRegression);
        }

        public void DeleteRegression(Regression regression)
        {
            if (regression == null) return;

            using (var conn = Database.OpenConnection())
            {
                conn.Delete(regression);
                Regressions.Remove(regression);
            }
        }

        private void Sale_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var sale = (Sale)sender;

            using (var conn = Database.OpenConnection())
            {
                conn.Update(sale);
            }
        }

        private void Regression_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var regression = (Regression)sender;

            using (var conn = Database.OpenConnection())
            {
                conn.Update(regression);
            }
        }

        private void TreeProfile_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var treeProfile = (TreeProfile)sender;

            using (var conn = Database.OpenConnection())
            {
                conn.Update(treeProfile);
            }
        }

        
    }
}