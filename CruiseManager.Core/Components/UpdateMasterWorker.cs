using CruiseDAL;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Threading;

namespace CruiseManager.Core.Components
{
    public class TreeKey
    {
        [Field(Name = CruiseDAL.Schema.TREE.TREE_CN)]
        public long? Tree_CN { get; set; }

        [Field(Name = CruiseDAL.Schema.TREE.TREE_GUID)]
        public string Tree_GUID { get; set; }
    }

    public class PlotKey
    {
        [Field(Name = CruiseDAL.Schema.PLOT.PLOT_CN)]
        public long? Plot_CN { get; set; }

        [Field(Name = CruiseDAL.Schema.PLOT.PLOT_GUID)]
        public string Plot_GUID { get; set; }
    }

    public class LogKey
    {
        [Field(Name = CruiseDAL.Schema.LOG.LOG_CN)]
        public long? Log_CN { get; set; }

        [Field(Name = CruiseDAL.Schema.LOG.LOG_GUID)]
        public string Log_GUID { get; set; }
    }

    public class StemKey
    {
        [Field(Name = CruiseDAL.Schema.STEM.STEM_CN)]
        public long? Stem_CN { get; set; }

        [Field(Name = CruiseDAL.Schema.STEM.STEM_GUID)]
        public string Stem_GUID { get; set; }
    }

    public class TreeEstimateKey
    {
        [Field(Name = CruiseDAL.Schema.TREEESTIMATE.TREEESTIMATE_CN)]
        public long? TreeEstimate_CN { get; set; }

        [Field(Name = CruiseDAL.Schema.TREEESTIMATE.TREEESTIMATE_GUID)]
        public string TreeEstimate_GUID { get; set; }
    }

    public class UpdateMasterWorker
    {
        protected static Thread _thread;

        private const string SELECT_TREES = "WHERE Tree_GUID is null OR Tree_GUID LIKE ''";
        private const string SELECT_PLOTS = "WHERE Plot_GUID IS NULL OR Plot_GUID LIKE ''";
        private const string SELECT_LOGS = "WHERE Log_GUID IS NULL OR Log_GUID LIKE ''";
        private const string SELECT_STEMS = "WHERE Stem_GUID IS NULL OR Stem_GUID LIKE ''";
        private const string SELECT_TREEEST = "WHERE TreeEstimate_GUID IS NULL OR TreeEstimate_GUID LIKE ''";

        public static bool HasUnassignedGUIDs(DAL db)
        {
            return db.GetRowCount("Tree", SELECT_TREES) > 0
             || db.GetRowCount("Plot", SELECT_PLOTS) > 0
             || db.GetRowCount("Log", SELECT_LOGS) > 0
             || db.GetRowCount("Stem", SELECT_STEMS) > 0
             || db.GetRowCount("TreeEstimate", SELECT_TREEEST) > 0;
        }

        public static void AssignGuids(DAL db)
        {
            db.BeginTransaction();
            try
            {
                foreach (TreeKey tk in db.Query<TreeKey>($"SELECT * FROM Tree {SELECT_TREES};", (object[])null))
                {
                    tk.Tree_GUID = Guid.NewGuid().ToString();
                    db.Execute("UPDATE Tree SET Tree_GUID = @p1 WHERE Tree_CN = @p2;", tk.Tree_GUID.ToString(), tk.Tree_CN);
                    //db.Execute("UPDATE Log SET Tree_GUID = ? WHERE Tree_CN = ?;", tk.Tree_GUID.ToString(), tk.Tree_CN);
                    //db.Execute("UPDATE Stem SET Tree_GUID = ? WHERE Tree_CN = ?;", tk.Tree_GUID.ToString(), tk.Tree_CN);
                }
                foreach (PlotKey pk in db.Query<PlotKey>($"SELECT * FROM Plot {SELECT_PLOTS};", (object[])null))
                {
                    pk.Plot_GUID = Guid.NewGuid().ToString();
                    db.Execute("UPDATE Plot SET Plot_GUID = @p1 WHERE Plot_CN = @p2;", pk.Plot_GUID.ToString(), pk.Plot_CN);
                    //db.Execute("UPDATE Tree SET Plot_GUID = ? WHERE Plot_CN = ?;", pk.Plot_GUID.ToString(), pk.Plot_CN);
                }
                foreach (LogKey lk in db.Query<LogKey>("SELECT * FROM Log " + SELECT_LOGS + ";", (object[])null))
                {
                    lk.Log_GUID = Guid.NewGuid().ToString();
                    db.Execute("UPDATE Log SET Log_GUID = @p1 WHERE Log_CN = @p2;", lk.Log_GUID.ToString(), lk.Log_CN);
                }
                foreach (TreeEstimateKey tek in db.Query<TreeEstimateKey>($"SELECT * FROM TreeEstimate {SELECT_TREEEST};", (object[])null))
                {
                    tek.TreeEstimate_GUID = Guid.NewGuid().ToString();
                    db.Execute("UPDATE TreeEstimate SET TreeEstimate_GUID = @p1 WHERE TreeEstimate_CN = @p2", tek.TreeEstimate_GUID.ToString(), tek.TreeEstimate_CN);
                }

                db.CommitTransaction();
            }
            catch
            {
                db.RollbackTransaction();
                throw;
            }
        }
    }
}