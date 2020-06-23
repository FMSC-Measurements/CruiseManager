using CruiseDAL;
using FMSC.ORM.EntityModel.Attributes;
using System;

namespace CruiseManager.Core.FileMaintenance
{
    public class AssignGuidsScript : ISimpleSQLScript
    {
        private const string SELECT_TREES = "WHERE Tree_GUID is null OR Tree_GUID LIKE ''";
        private const string SELECT_PLOTS = "WHERE Plot_GUID IS NULL OR Plot_GUID LIKE ''";
        private const string SELECT_LOGS = "WHERE Log_GUID IS NULL OR Log_GUID LIKE ''";
        private const string SELECT_STEMS = "WHERE Stem_GUID IS NULL OR Stem_GUID LIKE ''";
        private const string SELECT_TREEEST = "WHERE TreeEstimate_GUID IS NULL OR TreeEstimate_GUID LIKE ''";

        public string Name => "Assign Guids";

        public string Description => "Sety GUID keys on records where they are null or empty";

        public bool CheckCanExecute(DAL database)
        {
            return database.GetRowCount("Tree", SELECT_TREES) > 0
             || database.GetRowCount("Plot", SELECT_PLOTS) > 0
             || database.GetRowCount("Log", SELECT_LOGS) > 0
             || database.GetRowCount("Stem", SELECT_STEMS) > 0
             || database.GetRowCount("TreeEstimate", SELECT_TREEEST) > 0;
        }

        public void Execute(DAL database)
        {
            database.BeginTransaction();
            try
            {
                foreach (TreeKey tk in database.Query<TreeKey>($"SELECT * FROM Tree {SELECT_TREES};"))
                {
                    tk.Tree_GUID = Guid.NewGuid().ToString();
                    database.Execute("UPDATE Tree SET Tree_GUID = @p1 WHERE Tree_CN = @p2;", tk.Tree_GUID.ToString(), tk.Tree_CN);
                    //db.Execute("UPDATE Log SET Tree_GUID = ? WHERE Tree_CN = ?;", tk.Tree_GUID.ToString(), tk.Tree_CN);
                    //db.Execute("UPDATE Stem SET Tree_GUID = ? WHERE Tree_CN = ?;", tk.Tree_GUID.ToString(), tk.Tree_CN);
                }
                foreach (PlotKey pk in database.Query<PlotKey>($"SELECT * FROM Plot {SELECT_PLOTS};"))
                {
                    pk.Plot_GUID = Guid.NewGuid().ToString();
                    database.Execute("UPDATE Plot SET Plot_GUID = @p1 WHERE Plot_CN = @p2;", pk.Plot_GUID.ToString(), pk.Plot_CN);
                    //db.Execute("UPDATE Tree SET Plot_GUID = ? WHERE Plot_CN = ?;", pk.Plot_GUID.ToString(), pk.Plot_CN);
                }
                foreach (LogKey lk in database.Query<LogKey>("SELECT * FROM Log " + SELECT_LOGS + ";"))
                {
                    lk.Log_GUID = Guid.NewGuid().ToString();
                    database.Execute("UPDATE Log SET Log_GUID = @p1 WHERE Log_CN = @p2;", lk.Log_GUID.ToString(), lk.Log_CN);
                }
                foreach (TreeEstimateKey tek in database.Query<TreeEstimateKey>($"SELECT * FROM TreeEstimate {SELECT_TREEEST};"))
                {
                    tek.TreeEstimate_GUID = Guid.NewGuid().ToString();
                    database.Execute("UPDATE TreeEstimate SET TreeEstimate_GUID = @p1 WHERE TreeEstimate_CN = @p2", tek.TreeEstimate_GUID.ToString(), tek.TreeEstimate_CN);
                }

                database.CommitTransaction();
            }
            catch
            {
                database.RollbackTransaction();
                throw;
            }
        }

        private class TreeKey
        {
            [Field(Name = CruiseDAL.Schema.TREE.TREE_CN)]
            public long? Tree_CN { get; set; }

            [Field(Name = CruiseDAL.Schema.TREE.TREE_GUID)]
            public string Tree_GUID { get; set; }
        }

        private class PlotKey
        {
            [Field(Name = CruiseDAL.Schema.PLOT.PLOT_CN)]
            public long? Plot_CN { get; set; }

            [Field(Name = CruiseDAL.Schema.PLOT.PLOT_GUID)]
            public string Plot_GUID { get; set; }
        }

        private class LogKey
        {
            [Field(Name = CruiseDAL.Schema.LOG.LOG_CN)]
            public long? Log_CN { get; set; }

            [Field(Name = CruiseDAL.Schema.LOG.LOG_GUID)]
            public string Log_GUID { get; set; }
        }

        private class StemKey
        {
            [Field(Name = CruiseDAL.Schema.STEM.STEM_CN)]
            public long? Stem_CN { get; set; }

            [Field(Name = CruiseDAL.Schema.STEM.STEM_GUID)]
            public string Stem_GUID { get; set; }
        }

        private class TreeEstimateKey
        {
            [Field(Name = CruiseDAL.Schema.TREEESTIMATE.TREEESTIMATE_CN)]
            public long? TreeEstimate_CN { get; set; }

            [Field(Name = CruiseDAL.Schema.TREEESTIMATE.TREEESTIMATE_GUID)]
            public string TreeEstimate_GUID { get; set; }
        }
    }
}