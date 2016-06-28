namespace CruiseManager.Core.Constants
{
    public static class SQL
    {
        public static string CLEAR_FIELD_DATA = @"
UPDATE CountTree Set TreeCount = 0, SumKPI = 0;
UPDATE SampleGroup Set SampleSelectorState = '';
DELETE FROM Log;
DELETE FROM Stem;
DELETE FROM LogStock;
DELETE FROM TreeCalculatedValues;
DELETE FROM Tree;
DELETE FROM Plot;
DELETE FROM ErrorLog WHERE TableName IN ('Tree', 'Plot', 'Log', 'Stem');
UPDATE CuttingUnit Set TallyHistory = NULL;
";

        public static string MAKE_COUNTS_FOR_COMPONENTS = @"INSERT OR IGNORE INTO CountTree (Component_CN, SampleGroup_CN, CuttingUnit_CN, Tally_CN, TreeDefaultValue_CN, CreatedBy)
SELECT Component.Component_CN, CountTree.SampleGroup_CN, CountTree.CuttingUnit_CN, Tally_CN, CountTree.TreeDefaultValue_CN, CountTree.CreatedBy
FROM CountTree JOIN Component ON CountTree.Component_CN = Component.Component_CN
UNION ALL
SELECT Component.Component_CN, CountTree.SampleGroup_CN, CountTree.CuttingUnit_CN, Tally_CN, CountTree.TreeDefaultValue_CN, CountTree.CreatedBy
FROM COMPONENT JOIN CountTree
WHERE CountTree.Component_CN IS NULL;";
    }
}