using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components.CommandBuilders
{
    public class StemMergeTableCommandBuilder : MergeTableCommandBuilder
    {
        protected const string STEM_UNIQUE_JOIN_COMMAND =
            @"USING (Tree_CN, Stem_CN) ";

        protected const string STEM_COMPOUND_NATURAL_KEY_EXPRESSION =
            @"quote({0}Tree_CN) || ',' || quote({0}Stem_CN)";

        public StemMergeTableCommandBuilder() : base("Stem")
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

        public StemMergeTableCommandBuilder(DAL master) : this()
        {
            Initialize(master);
        }

        protected override string NaturalJoinCondition => STEM_UNIQUE_JOIN_COMMAND;

        protected override string GetCompoundNaturalKeyExpression(String sqlSourceName)
        {
            if (!string.IsNullOrEmpty(sqlSourceName))
            {
                sqlSourceName = sqlSourceName + ".";
            }

            return string.Format(STEM_COMPOUND_NATURAL_KEY_EXPRESSION, sqlSourceName);
        }
    }
}
