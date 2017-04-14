using CruiseDAL;
using CruiseDAL.DataObjects;
using System.Collections.Generic;
using System;
using Moq;
using CruiseManager.Core.App;
using CruiseManager.Core.Components;
using FluentAssertions;
using Xunit;
using CruiseManager.Core;

namespace CSMTest
{
    public class MergeComponentsPresenterTest
    {
        public DAL GetMaster()
        {
            return new DAL(".\\Components\\Bad\\RedSquirt.M.cruise");
        }

        [Fact]
        public void InitializeTest()
        {
            var appController = Mock.Of<ApplicationControllerBase>();
            using (var master = GetMaster())
            {
                var cmPresenter = new MergeComponentsPresenter(appController);

                cmPresenter.MissingComponents.Count.ShouldBeEquivalentTo(0);
            }
        }

        //[TestMethod]
        //public void UpdateAndMergeTest()
        //{
        //    WindowPresenterStub wPresenter = new WindowPresenterStub();
        //    using (DAL master = GetMaster())
        //    {
        //        wPresenter.Database = master;
        //        MergeComponentsPresenter cmPresenter = new MergeComponentsPresenter(wPresenter);

        //        List<String> missingFiles = new List<String>();
        //        cmPresenter.FindComponents(out missingFiles);
        //        Assert.IsTrue(missingFiles.Count == 0);

        //        cmPresenter.ReadyComponents();
        //        cmPresenter.BuildMergeTables();

        //        cmPresenter.ProcessMergeTables();
        //    }

        //}

        [Fact]
        public void PrepareMergeTest()
        {
            var appController = Mock.Of<ApplicationControllerBase>();
            using (var master = GetMaster())
            {
                var cmPresenter = new MergeComponentsPresenter(appController);

                cmPresenter.MissingComponents.Count.ShouldBeEquivalentTo(0);

                var worker = new PrepareMergeWorker(cmPresenter);
                worker.ProgressChanged += HandleProgressChanged;

                worker.BeginWork();

                worker.Wait();
            }
        }

        [Fact]
        public void PerformMergeTest()
        {
            var appController = Mock.Of<ApplicationControllerBase>();
            using (var master = GetMaster())
            {
                var cmPresenter = new MergeComponentsPresenter(appController);
                cmPresenter.MissingComponents.Count.ShouldBeEquivalentTo(0);

                var worker = new PrepareMergeWorker(cmPresenter);
                worker.ProgressChanged += HandleProgressChanged;

                worker.BeginWork();

                worker.Wait();

                var syncWorker = new MergeSyncWorker(cmPresenter);
                syncWorker.ProgressChanged += HandleProgressChanged;

                syncWorker.BeginWork();

                syncWorker.Wait();
            }
        }

        public void HandleProgressChanged(object sender, WorkerProgressChangedEventArgs e)
        {
            //TestContext.WriteLine("{0} done: {1} Tick:", e.ProgressPercentage * 100.0, e.Message);
        }
    }
}