using CruiseDAL;
using CruiseDAL.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Validation
{
    public static class DatabaseValidator
    {
        public static bool HasCruiseErrors(CruiseDatastore dal, out string[] errors)
        {
            bool hasErrors = false;
            var errorList = new List<string>();

            if (dal.HasForeignKeyErrors(null))
            {
                errorList.Add("File contains Foreign Key errors");
                hasErrors = true;
            }

            if (HasMismatchSpecies(dal))
            {
                errorList.Add("Tree table has mismatch species codes");
                hasErrors = true;
            }

            if (HasSampleGroupUOMErrors(dal))
            {
                errorList.Add("Sample Group table has invalid mix of UOM");
                hasErrors = true;
            }

            if (HasBlankCountOrMeasure(dal))
            {
                errorList.Add("Tree table has record(s) with blank Count or Measure value");
                hasErrors = true;
            }
            if (HasBlankDefaultLiveDead(dal))
            {
                errorList.Add("Sample Group table has record(s) with blank default live dead vaule");
                hasErrors = true;
            }
            if (HasBlankLiveDead(dal))
            {
                errorList.Add("Tree table has record(s) with blank Live Dead value");
                hasErrors = true;
            }
            if (HasBlankSpeciesCodes(dal))
            {
                dal.Execute(
                @"Update Tree
                SET Species =
                    (Select Species FROM TreeDefaultValue
                        WHERE TreeDefaultValue.TreeDefaultValue_CN = Tree.TreeDefaultValue_CN)
                WHERE ifnull(Tree.Species, '') = ''
                AND ifnull(Tree.TreeDefaultValue_CN, 0) != 0;");
                if (HasBlankSpeciesCodes(dal))
                {
                    errorList.Add("Tree table has record(s) with blank species or no tree default");
                    hasErrors = true;
                }
            }

            if (HasOrphanedStrata(dal))
            {
                errorList.Add("Stratum table has record(s) that have not been assigned to a cutting unit");
                hasErrors = true;
            }
            if (HasStrataWithNoSampleGroups(dal))
            {
                errorList.Add("Stratum table has record(s) that have not been assigned any sample groups");
                hasErrors = true;
            }

            errors = errorList.ToArray();
            return hasErrors;
        }

        public static bool HasCruiseErrors(CruiseDatastore dal)
        {
            string[] errors;
            return dal.HasCruiseErrors(out errors);
        }

        private static bool HasBlankSpeciesCodes(CruiseDatastore dal)
        {
            return dal.GetRowCount(TREE._NAME, "WHERE ifnull(Species, '') = ''") > 0;
        }

        private static bool HasBlankLiveDead(CruiseDatastore dal)
        {
            return dal.GetRowCount(TREE._NAME, "WHERE ifnull(LiveDead, '') = ''") > 0;
        }

        private static bool HasBlankCountOrMeasure(CruiseDatastore dal)
        {
            return dal.GetRowCount(TREE._NAME, "WHERE ifnull(CountOrMeasure, '') = ''") > 0;
        }

        private static bool HasBlankDefaultLiveDead(CruiseDatastore dal)
        {
            return dal.GetRowCount(SAMPLEGROUP._NAME, "WHERE ifnull(DefaultLiveDead, '') = ''") > 0;
        }

        private static bool HasMismatchSpecies(CruiseDatastore dal)
        {
            return dal.GetRowCount("Tree", "JOIN TreeDefaultValue AS tdv USING (TreeDefaultValue_CN) WHERE Tree.Species != tdv.Species;") > 0;
        }

        private static bool HasSampleGroupUOMErrors(this CruiseDatastore dal)
        {
            return (dal.ExecuteScalar<long>("Select Count(DISTINCT UOM) FROM SampleGroup WHERE UOM != '04';")) > 1L;
            //return this.GetRowCount("SampleGroup", "WHERE UOM != '04' GROUP BY UOM") > 1;
        }

        private static bool HasOrphanedStrata(CruiseDatastore dal)
        {
            return dal.GetRowCount("Stratum", "LEFT JOIN CuttingUnitStratum USING (Stratum_CN) WHERE CuttingUnitStratum.Stratum_CN IS NULL") > 0;
        }

        private static bool HasStrataWithNoSampleGroups(CruiseDatastore dal)
        {
            return dal.GetRowCount("Stratum", "LEFT JOIN SampleGroup USING (Stratum_CN) WHERE SampleGroup.Stratum_CN IS NULL") > 0;
        }
    }
}
