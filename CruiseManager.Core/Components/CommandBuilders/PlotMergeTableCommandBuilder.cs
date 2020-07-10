using CruiseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components.CommandBuilders
{
    public class PlotMergeTableCommandBuilder : MergeTableCommandBuilder
    {
        protected const string PLOT_UNIQUE_JOIN_COMMAND =
            @"USING (Stratum_CN, CuttingUnit_CN, PlotNumber) ";

        protected const string PLOT_COMPOUND_NATURAL_KEY_EXPRESSION =
            @"quote({0}Stratum_CN) || ',' || quote({0}CuttingUnit_CN) || ',' || quote({0}PlotNumber)";

        public PlotMergeTableCommandBuilder() : base("Plot")
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

        public PlotMergeTableCommandBuilder(DAL master) : this()
        {
            Initialize(master);
        }

        protected override string NaturalJoinCondition => PLOT_UNIQUE_JOIN_COMMAND;

        protected override string GetCompoundNaturalKeyExpression(String sqlSourceName)
        {
            if (!string.IsNullOrEmpty(sqlSourceName))
            {
                sqlSourceName = sqlSourceName + ".";
            }

            return string.Format(PLOT_COMPOUND_NATURAL_KEY_EXPRESSION, sqlSourceName);
        }
    }
}
