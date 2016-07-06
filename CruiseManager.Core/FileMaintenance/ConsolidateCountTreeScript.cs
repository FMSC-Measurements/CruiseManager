using CruiseDAL;

namespace CruiseManager.Core.FileMaintenance
{
    public class ConsolidateCountTreeScript : ISimpleSQLScript
    {
        public string Description
        {
            get
            {
                return "Removes Duplicate Entries in the count tree table by combining their tree counts and kpi totals";
            }
        }

        public bool CheckCanExecute(DAL database)
        {
            long numDups = (long)database.ExecuteScalar(
                @"SELECT count(1) FROM (
                    SELECT * FROM (
                        SELECT count(1) as cnt FROM
                        CountTree
                        GROUP BY CuttingUnit_CN, SampleGroup_CN, ifnull(TreeDefaultValue_CN,0), ifnull(Component_CN,0)
                    )
                    WHERE cnt > 1
                );");
            return numDups > 0;
        }

        public void Execute(DAL database)
        {
            database.Execute(
                @"BEGIN;

            ALTER TABLE CountTree RENAME TO TempCountTree;

            CREATE TABLE CountTree(
                CountTree_CN INTEGER PRIMARY KEY AUTOINCREMENT,
                SampleGroup_CN INTEGER REFERENCES SampleGroup NOT NULL,
                CuttingUnit_CN INTEGER REFERENCES CuttingUnit NOT NULL,
                Tally_CN INTEGER REFERENCES Tally,
                TreeDefaultValue_CN INTEGER REFERENCES TreeDefaultValue,
                Component_CN INTEGER REFERENCES Component,
                TreeCount INTEGER Default 0,
                SumKPI INTEGER Default 0,
                CreatedBy TEXT NOT NULL,
                CreatedDate DATETIME,
                ModifiedBy TEXT,
                ModifiedDate DATETIME,
                UNIQUE(SampleGroup_CN, CuttingUnit_CN, TreeDefaultValue_CN, Component_CN));

            INSERT INTO CountTree
            (CountTree_CN, SampleGroup_CN, CuttingUnit_CN, Tally_CN, TreeDefaultValue_CN, Component_CN,
            TreeCount, SumKPI,
            CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
                SELECT CountTree_CN, SampleGroup_CN, CuttingUnit_CN, Tally_CN, TreeDefaultValue_CN, Component_CN,
                Sum(TreeCount), Sum(SumKPI),
                CreatedBy, CreatedDate, ModifiedBy, ModifiedDate
                FROM TempCountTree
                GROUP BY SampleGroup_CN, CuttingUnit_CN,
                ifnull(TreeDefaultValue_CN, 0), ifnull(Component_CN, 0);

            DROP TABLE TempCountTree;

            CREATE TRIGGER OnNewCountTree AFTER INSERT ON CountTree BEGIN
            UPDATE CountTree SET CreatedDate = datetime(current_timestamp, 'localtime') WHERE rowID = new.rowID; END;

            CREATE TRIGGER OnUpdateCountTree UPDATE ON CountTree BEGIN
                        UPDATE CountTree SET ModifiedDate = datetime(current_timestamp, 'localtime') WHERE rowID = new.rowID; END;

            COMMIT;"
                );
        }
    }
}