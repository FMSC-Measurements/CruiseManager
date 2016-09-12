using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManager.Core.App
{
    public static class DatabaseExtentions
    {
        private static TreeDefaultValueDO[] EMPTY_SPECIES_LIST = { };

        public static void SetTreeTDV(TreeVM tree, TreeDefaultValueDO tdv)
        {
            tree.TreeDefaultValue = tdv;
            if (tdv != null)
            {
                tree.Species = tdv.Species;

                tree.LiveDead = tdv.LiveDead;
                tree.Grade = tdv.TreeGrade;
                tree.FormClass = tdv.FormClass;
                tree.RecoverablePrimary = tdv.Recoverable;
                //tree.HiddenPrimary = tdv.HiddenPrimary; //#367
            }
            else
            {
                //tree.Species = string.Empty;
                //tree.LiveDead = string.Empty;
                //tree.Grade = string.Empty;
                //tree.FormClass = 0;
                //tree.RecoverablePrimary = 0;
                //tree.HiddenPrimary = 0;
            }
        }

        public static List<String> GetCruiseMethods(this DAL database, bool reconMethodsOnly)
        {
            if (reconMethodsOnly)
            {
                return new List<string>(CruiseDAL.Schema.CruiseMethods.RECON_METHODS);
            }
            List<string> cruiseMethods = null;
            try
            {
                cruiseMethods = new List<string>(CruiseMethodsDO.ReadCruiseMethodStr(database, reconMethodsOnly));
            }
            catch { }
            if (cruiseMethods == null || cruiseMethods.Count == 0)
            {
                cruiseMethods = new List<string>(CruiseDAL.Schema.CruiseMethods.SUPPORTED_METHODS);
            }

            return cruiseMethods;
        }

        public static object GetTreeTDVList(this DAL database, TreeVM tree)
        {
            if (tree == null) { return EMPTY_SPECIES_LIST; }
            if (tree.Stratum == null)
            {
                if (database.GetRowCount("CuttingUnitStratum", "WHERE CuttingUnit_CN = ?", tree.CuttingUnit_CN) == 1)
                {
                    tree.Stratum = database.From<StratumVM>()
                        .Join("CuttingUnitStratum", "USING (Stratum_CN)").Where("CuttingUnit_CN = ?")
                        .Read(tree.CuttingUnit_CN).FirstOrDefault();
                }
                else
                {
                    return EMPTY_SPECIES_LIST;
                }
            }

            if (tree.SampleGroup == null)
            {
                if (database.GetRowCount("SampleGroup", "WHERE Stratum_CN = ?", tree.Stratum_CN) == 1)
                {
                    tree.SampleGroup = database.From<SampleGroupDO>()
                        .Where("Stratum_CN = ?").Read(tree.Stratum_CN).FirstOrDefault();
                }
                if (tree.SampleGroup == null)
                {
                    return EMPTY_SPECIES_LIST;
                }
            }

            return database.From<TreeDefaultValueDO>()
                .Join("SampleGroupTreeDefaultValue", "USING (TreeDefaultValue_CN)")
                .Where("SampleGroup_CN = ?").Read(tree.SampleGroup_CN).ToArray();
        }

        public static object GetSampleGroupsByStratum(this DAL database, long? st_cn)
        {
            if (st_cn == null)
            {
                return new SampleGroupDO[0];
            }
            return database.Read<SampleGroupDO>("SampleGroup", "WHERE Stratum_CN = ?", st_cn);
        }
    }
}