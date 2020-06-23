using CruiseDAL;
using CruiseManager.Core.App;
using CruiseManager.Core.Components.CommandBuilders;
using CruiseManager.Core.Components.ViewInterfaces;
using CruiseManager.Core.ViewModel;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components
{
    /// <summary>
    /// Drives the view, Loads components and orchestrates the multiple steps in the merging process
    /// </summary>
    public class MergeComponentsPresenter : Presentor
    {
        private long _masterTreeCount;
        private string _lastMergeDate;

        private bool _isInitialized;
        private bool _isPrepared;
        private bool _hasPrepareErrors;

        #region Properties

        public Dictionary<String, MergeTableCommandBuilder> CommandBuilders { get; protected set; } = new Dictionary<string, MergeTableCommandBuilder>();


        public CancellationTokenSource CancellationSource { get; } = new CancellationTokenSource();

        public DAL MasterDB => ApplicationController?.Database;
        public IEnumerable<ComponentFile> ActiveComponents { get; set; }
        public IEnumerable<ComponentFile> MissingComponents { get; set; }
        public IEnumerable<ComponentFile> AllComponents { get; set; }

        private int _numComponents;

        public int NumComponents
        {
            get { return _numComponents; }
            set
            {
                SetValue(value, ref _numComponents);
            }
        }

        public long MasterTreeCount
        {
            get { return _masterTreeCount; }
            set { SetValue(value, ref _masterTreeCount); }
        }

        public string LastMergeDate
        {
            get { return _lastMergeDate; }
            set { SetValue(value, ref _lastMergeDate); }
        }

        public MergeLog MergeLog { get; } = new MergeLog();

        public Progress<int> Progress { get; } = new Progress<int>();

        public bool IsPrepared
        {
            get => _isPrepared;
            protected set => SetValue(value, ref _isPrepared);
        }

        public bool HasConflicts => IsPrepared && (GetNumConflicts() > 0);

        public bool CanMerge => IsPrepared && !HasConflicts;

        #endregion Properties

        public MergeComponentsPresenter(IApplicationController applicationController)
            : base(applicationController)
        {
            var master = applicationController.Database;
            Initialize(master);
        }

        private void Initialize(DAL master)
        {
            foreach (var cmd in MakeCommandBuilders(master))
            {
                CommandBuilders.Add(cmd.ClientTableName, cmd);
            }

            try
            {
                var value = master.ReadGlobalValue("Comp", "ChildComponents");
                NumComponents = Convert.ToInt32(value);
            }
            catch
            {
                NumComponents = 0;
            }

            MasterTreeCount = master.GetRowCount("Tree", null, null);

            FindComponents();

            LastMergeDate = String.Empty;
        }

        public static IEnumerable<MergeTableCommandBuilder> MakeCommandBuilders(DAL master)
        {
            return new MergeTableCommandBuilder[]
            {
                new TreeMergeTableCommandBuilder(master),
                new LogMergeTableCommandBuilder(master),
                new StemMergeTableCommandBuilder(master),
                new PlotMergeTableCommandBuilder(master),
            };
        }

        public void FindComponents()
        {
            string searchDir = System.IO.Path.GetDirectoryName(MasterDB.Path);
            this.FindComponents(searchDir);
        }

        public void FindComponents(string searchDir)
        {
            System.Diagnostics.Debug.Assert(MasterDB != null);

            var allComponents = MasterDB.From<ComponentFile>().Read().ToArray();
            var activeComponents = new List<ComponentFile>();
            var missingComponents = new List<ComponentFile>();

            foreach (ComponentFile comp in allComponents)
            {
                comp.FullPath = System.IO.Path.Combine(searchDir, comp.FileName);

                if (InitializeComponent(comp))//try to initialize component, if initialization fails add to missing file list
                {
                    activeComponents.Add(comp);
                }
                else
                {
                    missingComponents.Add(comp);
                }
            }

            AllComponents = allComponents;
            ActiveComponents = activeComponents;
            MissingComponents = missingComponents;
        }

        public static bool InitializeComponent(ComponentFile comp)
        {
            comp.ResetCounts();

            var filePath = comp.FullPath;
            if (!System.IO.File.Exists(filePath))
            {
                comp.Errors = "File not found";
                return false;
            }

            if (File.GetAttributes(filePath).HasFlag(FileAttributes.ReadOnly))
            {
                comp.Errors = "File is Read Only";
                return false;
            }

            try
            {
                var compDB = new DAL(filePath);

                if (compDB.HasCruiseErrors(out var errors))
                {
                    comp.Errors += string.Join("\r\n", errors);
                }

                comp.TreeCount = compDB.ExecuteScalar<long?>("SELECT count(*) FROM Tree;");
                comp.LogCount = compDB.ExecuteScalar<long?>("SELECT count(*) FROM Log;");
                comp.PlotCount = compDB.ExecuteScalar<long?>("SELECT count(*) FROM Plot;");
                comp.StemCount = compDB.ExecuteScalar<long?>("SELECT count(*) FROM Stem;");

                comp.Database = compDB;
                return true;
            }
            catch (Exception e)
            {
                comp.Errors += e.Message;
                return false;
            }
        }

        public async Task<(bool, Exception)> RunPreMerge()
        {
            var master = MasterDB;
            var components = ActiveComponents;
            var progress = Progress;
            var log = MergeLog;

            var prepareTask = PrepareMergeWorker.DoWorkAsync(master, components, CommandBuilders.Values,
                                                             CancellationSource.Token, progress, log);

            await prepareTask;
            if (prepareTask.IsCanceled)
            { return (false, null); }

            var prepareException = prepareTask.Exception;
            if (prepareException == null)
            {
                return (true, null);
            }
            else
            {
                Crashes.TrackError(prepareException, null, log.ToErrorAttachmentLog());
                return (false, prepareException);
            }
        }

        public async Task<(bool, Exception)> RunMerge()
        {
            var master = MasterDB;
            var components = ActiveComponents;
            var progress = Progress;
            var log = MergeLog;

            var processTask = MergeSyncWorker.DoMergeAsync(
                master, components, CommandBuilders, CancellationSource.Token,
                progress, log);

            await processTask;
            if (processTask.IsCanceled)
            { return (false, null); }

            var processExceptions = processTask.Exception;

            if (processExceptions == null)
            {
                return (true, null);
            }
            else
            {
                Crashes.TrackError(processExceptions, null, log.ToErrorAttachmentLog());
                return (false, processExceptions);
            }
        }

        public IEnumerable<PreMergeTableReport> GetPreMergeReports()
        {
            return CommandBuilders.Values.Select(x =>
            {
                return new PreMergeTableReport()
                {
                    TableName = x.ClientTableName,
                    Errors = ListConflicts(x),
                    Matches = ListMatches(x),
                    Additions = ListNew(x),
                };
            }).ToArray();
        }

        public void Cancel()
        {
            CancellationSource?.Cancel();
        }

        public IEnumerable<MergeObject> ListConflicts(MergeTableCommandBuilder cmdBldr)
        {
            return MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + cmdBldr.FindConflictsFilter + ";", (object[])null).ToArray();
        }

        public IEnumerable<MergeObject> ListMatches(MergeTableCommandBuilder cmdBldr)
        {
            return MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + " WHERE " + cmdBldr.FindMatchesBase + ";", (object[])null).ToArray();
        }

        public IEnumerable<MergeObject> ListNew(MergeTableCommandBuilder cmdBldr)
        {
            return MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + cmdBldr.FindNewRecords + ";", (object[])null).ToArray();
        }

        public IEnumerable<MergeObject> ListDeleted(MergeTableCommandBuilder cmdBldr)
        {
            return MasterDB.Query<MergeObject>("SELECT * FROM " + cmdBldr.MergeTableName + " WHERE IsDeleted = 1;", (object[])null).ToArray();
        }

        public int GetNumConflicts()
        {
            long totalConflicts = 0;
            foreach (MergeTableCommandBuilder cmdBldr in this.CommandBuilders.Values)
            {
                totalConflicts += MasterDB.GetRowCount(cmdBldr.MergeTableName, cmdBldr.FindConflictsFilter);
            }

            return (int)totalConflicts;
        }

        public string ExplaneMergeRecord(MergeObject mRec)
        {
            string error = String.Empty;

            //if (mRec.ComponentConflict != null)
            //{
            //    error += "Conflict found with record in component " + mRec.ComponentConflictFileID + " ";
            //    if (mRec.ComponentConflict != mRec.ComponentRowID)
            //    { error += "possibly the same tree entered into different files "; }
            //    else
            //    { error += "possibly because field data from other components was not removed when component file was created "; }
            //}
            //if (mRec.MasterConflict != null)
            //{
            //    error += "Conflict found with record in Master ";
            //    if (mRec.MasterConflict == mRec.ComponentRowID)
            //    {
            //        error += "possibly because another copy of component file made initial merge of this record, please find original component file ";
            //    }
            //    else
            //    {
            //        error += "duplicate record ";
            //    }
            //}

            return error;
        }

        #region Presenter Members

        protected override void OnViewLoad(EventArgs e)
        {
            base.OnViewLoad(e);

            FindComponents();
        }

        #endregion Presenter Members

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            var isDisposed = IsDisposed;
            base.Dispose(disposing);
            if (disposing && !isDisposed)
            {
                if (this.ActiveComponents != null)
                {
                    foreach (ComponentFile comp in this.ActiveComponents)
                    {
                        if (comp.Database != null)
                        {
                            comp.Database.Dispose();
                            comp.Database = null;
                        }
                    }
                }
            }
        }

        #endregion IDisposable Members
    }
}