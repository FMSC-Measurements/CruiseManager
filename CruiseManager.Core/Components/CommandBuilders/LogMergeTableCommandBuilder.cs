using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components.CommandBuilders
{
    public class LogMergeTableCommandBuilder : MergeTableCommandBuilder
    {
        protected const string LOG_UNIQUE_JOIN_COMMAND =
            @"USING (Tree_CN, LogNumber) ";

        protected const string LOG_COMPOUND_NATURAL_KEY_EXPRESSION =
            @"quote({0}Tree_CN) || ',' || quote({0}LogNumber)";

        public LogMergeTableCommandBuilder() : base("Log")
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

        public LogMergeTableCommandBuilder(DAL master) : this()
        {
            Initialize(master);
        }

        protected override string NaturalJoinCondition => LOG_UNIQUE_JOIN_COMMAND;

        protected override string GetCompoundNaturalKeyExpression(String sqlSourceName)
        {
            if (!string.IsNullOrEmpty(sqlSourceName))
            {
                sqlSourceName = sqlSourceName + ".";
            }

            return string.Format(LOG_COMPOUND_NATURAL_KEY_EXPRESSION, sqlSourceName);
        }
    }
}
