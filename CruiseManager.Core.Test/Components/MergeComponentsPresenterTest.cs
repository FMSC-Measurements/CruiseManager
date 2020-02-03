using CruiseDAL;
using CruiseManager.Core;
using CruiseManager.Core.App;
using CruiseManager.Core.Components;
using FluentAssertions;
using Moq;
using System;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test
{
    public class MergeComponentsPresenterTest : TestBase
    {
        public MergeComponentsPresenterTest(ITestOutputHelper output) : base(output)
        {
        }

        public DAL GetMaster()
        {
            var codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var codeBasePath = Uri.UnescapeDataString(codeBaseUri);
            var directory = System.IO.Path.GetDirectoryName(codeBasePath);

            var path = System.IO.Path.Combine(directory, "TestFiles\\Components\\Bad\\RedSquirt.M.cruise");

            var dal = new DAL(path);

            return dal;
        }

        [Fact]
        public void InitializeTest()
        {
            using (var master = GetMaster())
            {
                AppControllerMock.Setup(x => x.Database)
                .Returns(master);

                var cmPresenter = new MergeComponentsPresenter(AppController);

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
                AppControllerMock.Setup(x => x.Database)
                .Returns(() => master);

                var cmPresenter = new MergeComponentsPresenter(AppController);

                cmPresenter.FindComponents(System.IO.Path.GetDirectoryName(master.Path));
                cmPresenter.MissingComponents.Should().HaveCount(0);
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
                var appControllerMock = AppControllerMock;
                appControllerMock.Setup(x => x.Database)
                .Returns(master);

                var cmPresenter = new MergeComponentsPresenter(appControllerMock.Object);

                cmPresenter.FindComponents(System.IO.Path.GetDirectoryName(master.Path));
                cmPresenter.MissingComponents.Should().HaveCount(0);
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