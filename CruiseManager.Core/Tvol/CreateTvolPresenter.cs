using CruiseManager.Core.App;
using CruiseManager.Core.ViewModel;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvol.Data;

namespace CruiseManager.Core.Tvol
{
    public class CreateTvolPresenter : Presentor
    {
        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { SetValue(value, ref _filePath); }
        }



        public CreateTvolPresenter(ApplicationControllerBase app) : base(app)
        {

        }

        public void CreateFile()
        {
            var cruiseDB = base.ApplicationController.Database;
            CreateFile(cruiseDB, FilePath);
        }

        public static void CreateFile(CruiseDAL.DAL cruiseDB, string path)
        {
            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            var db = new TvolDatabase(path);
            db.Create();

            //var sale = cruiseDB.From<CruiseDAL.DataObjects.SaleDO>().Read().FirstOrDefault();

var readTreeProfilesQuery = @"SELECT 
tdv.Species         AS Species,
sg.PrimaryProduct   AS Product,
tdv.LiveDead        AS LiveDead
FROM SampleGroupTreeDefaultValue AS sgtdv
JOIN TreeDefaultValue AS tdv USING (TreeDefaultValue_CN)
JOIN SampleGroup AS sg USING (SampleGroup_CN)
GROUP BY tdv.Species, sg.PrimaryProduct, tdv.LiveDead;";

            var readRegressionsQuery =
@"SELECT 
reg.rSpeices        AS Species,
reg.rProduct        AS Product,
reg.rLiveDead       AS LiveDead,
reg.CoefficientA    AS CoefficientA,
reg.CoefficientB    AS CoefficientB,
reg.CoefficientC    AS CoefficientC,
reg.Rsquared        AS Rsquared,
reg.RegressModel    AS RegressModel,
reg.rMinDbh         AS MinDBH,
reg.rMaxDbh         AS MaxDBH
FROM Regression AS reg;";

            using (var cruiseConn = cruiseDB.CreateConnection())
            using (var tvolConn = db.OpenConnection())
            {
                var sale = cruiseConn.Query<Sale>("SELECT SaleNumber FROM Sale LIMIT 1;").FirstOrDefault();

                tvolConn.Insert(sale);

                var profiles = cruiseConn.Query<TreeProfile>(readTreeProfilesQuery).ToList();

                foreach(var p in profiles)
                {
                    tvolConn.Insert(p);
                }

                var regressions = cruiseConn.Query<Regression>(readRegressionsQuery);

                foreach(var reg in regressions)
                {
                    tvolConn.Insert(reg);
                }
            }

                //var regressions = cruiseDB.Query<Regression>(query);
        }
    }
}
