using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components.CommandBuilders
{
    public class TreeMergeTableCommandBuilder : MergeTableCommandBuilder
    {
        protected const string TREE_UNIQUE_JOIN_COMMAND =
            @"ON (lft.CuttingUnit_CN = rgt.CuttingUnit_CN " +
            @"AND lft.Stratum_CN = rgt.Stratum_CN " +
            @"AND ifnull(lft.Plot_CN, 0) = ifnull(rgt.Plot_CN,0) " +
            @"AND lft.TreeNumber = rgt.TreeNumber) ";

        protected const string TREE_COMPOUND_NATURAL_KEY_EXPRESSION = //TODO should Stratum and SampleGroup be part of the natural key?
            @"quote({0}CuttingUnit_CN) || ',' || quote({0}Stratum_CN) || ',' || quote({0}SampleGroup_CN) || ',' || quote({0}Plot_CN) || ',' || quote({0}TreeNumber)";

        public TreeMergeTableCommandBuilder() : base("Tree")
        {
            DoGUIDMatch = true;
            DoKeyMatch = true;
            DoNaturalMatch = true;
            MergeChangesFromComponent = true;
            MergeChangesFromMaster = true;
            RecordsUniqueAccrossComponents = true;
            MergeNewFromComponent = true;
            MergeNewFromMaster = false;
            MergeDeletionsFromComponent = false;
        }

        public TreeMergeTableCommandBuilder(DAL master) : this()
        {
            Initialize(master);
        }

        protected override string NaturalJoinCondition => TREE_UNIQUE_JOIN_COMMAND;

        protected override string GetCompoundNaturalKeyExpression(String sqlSourceName)
        {
            if (!string.IsNullOrEmpty(sqlSourceName))
            {
                sqlSourceName = sqlSourceName + ".";
            }

            return string.Format(TREE_COMPOUND_NATURAL_KEY_EXPRESSION, sqlSourceName);
        }
    }
}
