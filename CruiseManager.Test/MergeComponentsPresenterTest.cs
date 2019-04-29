using CruiseDAL;
using CruiseManager.Core;
using CruiseManager.Core.App;
using CruiseManager.Core.Components;
using FluentAssertions;
using Moq;
using System;
using System.Reflection;
using Xunit;

namespace CruiseManager.Test
{
    public class MergeComponentsPresenterTest
    {
        public DAL GetMaster()
        {
            var codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var codeBasePath = Uri.UnescapeDataString(codeBaseUri);
            var directory = System.IO.Path.GetDirectoryName(codeBasePath);

            var path = System.IO.Path.Combine(directory, "TestFiles\\Components\\Bad\\RedSquirt.M.cruise");

            var dal = new DAL(path);
            CruiseDAL.Updater.UpdateMajorVersion(dal);

            return dal;
        }

        [Fact]
        public void InitializeTest()
        {
            using (var master = GetMaster())
            {
                var appControllerMock = Mock.Of<ApplicationControllerBase>();
                appControllerMock.Database = master;

                var cmPresenter = new MergeComponentsPresenter(appControllerMock);

                cmPresenter.NumComponents.Should().Be(3);
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
            using (var master = GetMaster())
            {
                var appController = Mock.Of<ApplicationControllerBase>();
                appController.Database = master;

                var cmPresenter = new MergeComponentsPresenter(appController);

                cmPresenter.FindComponents(System.IO.Path.GetDirectoryName(master.Path));
                cmPresenter.MissingComponents.Count.Should().Be(0);
                cmPresenter.NumComponents.Should().Be(3);

                var worker = new PrepareMergeWorker(cmPresenter);
                worker.ProgressChanged += HandleProgressChanged;

                worker.BeginWork();

                worker.Wait();
            }
        }

        [Fact]
        public void PerformMergeTest()
        {
            using (var master = GetMaster())
            {
                var appController = Mock.Of<ApplicationControllerBase>();
                appController.Database = master;

                var cmPresenter = new MergeComponentsPresenter(appController);

                cmPresenter.FindComponents(System.IO.Path.GetDirectoryName(master.Path));
                cmPresenter.MissingComponents.Count.Should().Be(0);
                cmPresenter.NumComponents.Should().Be(3);

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

        private void HandleProgressChanged(object sender, WorkerProgressChangedEventArgs e)
        {
            //TestContext.WriteLine("{0} done: {1} Tick:", e.ProgressPercentage * 100.0, e.Message);
        }
    }
}