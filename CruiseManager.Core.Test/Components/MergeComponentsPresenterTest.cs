using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core;
using CruiseManager.Core.App;
using CruiseManager.Core.Components;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components
{
    public class MergeComponentsPresenterTest : TestBase
    {
        public MergeComponentsPresenterTest(ITestOutputHelper output) : base(output)
        {
        }

        const string REDSQUIRT_MASTER = "Bad\\RedSquirt.M.cruise";
        const string VALENTINE_MASTER = "Good\\Valentine.M.cruise";
        const string GOOSEFOOTE_MASTER = "Good\\GooseFoote_7_16\\GooseFoote.M.cruise";
        const string TESTMERGENEWCOUNTS_MASTER = "Good\\testMergeNewCounts\\testMergeNewCounts.M.cruise";
        const string TESTMERGENEWCOUNTS2_MASTER = "Good\\testMergeNewCounts2\\12345 testMergeNewCountTrees TS.M.cruise";
        const string TESTMAXCOMPONENTS_MASTER = "Good\\testMaxComponents\\12345 testMergeMaxComponents TS.M.cruise";

        public DAL GetMaster(string masterPath)
        {
            var codeBaseUri = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var codeBasePath = Uri.UnescapeDataString(codeBaseUri);
            var directory = System.IO.Path.GetDirectoryName(codeBasePath);

            var path = System.IO.Path.Combine(directory, "TestFiles\\Components\\", masterPath);

            var dal = new DAL(path);

            return dal;
        }

        [Theory]
        [InlineData(REDSQUIRT_MASTER, 3)]
        [InlineData(VALENTINE_MASTER, 2)]
        [InlineData(GOOSEFOOTE_MASTER, 3)]
        [InlineData(TESTMERGENEWCOUNTS_MASTER, 2)]
        public void InitializeTest(string masterPath, int numComps)
        {
            using (var master = GetMaster(masterPath))
            {
                AppControllerMock.Setup(x => x.Database)
                .Returns(master);

                var cmPresenter = new MergeComponentsPresenter(AppController);

                cmPresenter.NumComponents.Should().Be(numComps);
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

        [Theory]
        [InlineData(REDSQUIRT_MASTER, 3)]
        [InlineData(VALENTINE_MASTER, 2)]
        [InlineData(GOOSEFOOTE_MASTER, 3)]
        [InlineData(TESTMERGENEWCOUNTS_MASTER, 2)]
        public void PrepareMergeTest(string masterPath, int numComps)
        {
            using (var master = GetMaster(masterPath))
            {
                AppControllerMock.Setup(x => x.Database)
                .Returns(() => master);

                var cmPresenter = new MergeComponentsPresenter(AppController);

                cmPresenter.FindComponents(System.IO.Path.GetDirectoryName(master.Path));
                cmPresenter.MissingComponents.Should().HaveCount(0);
                cmPresenter.NumComponents.Should().Be(numComps);

                var worker = new PrepareMergeWorker(cmPresenter);
                worker.ProgressChanged += HandleProgressChanged;

                worker.BeginWork();

                worker.Wait();
            }
        }

        [Theory]
        [InlineData(REDSQUIRT_MASTER, 3)]
        [InlineData(VALENTINE_MASTER, 2)]
        [InlineData(GOOSEFOOTE_MASTER, 3)]
        [InlineData(TESTMERGENEWCOUNTS_MASTER, 2)]
        [InlineData(TESTMAXCOMPONENTS_MASTER, 21)]
        public void PerformMergeTest(string masterPath, int numComps)
        {
            using (var master = GetMaster(masterPath))
            {
                var appControllerMock = AppControllerMock;
                appControllerMock.Setup(x => x.Database)
                .Returns(master);

                var cmPresenter = new MergeComponentsPresenter(appControllerMock.Object);

                cmPresenter.FindComponents(System.IO.Path.GetDirectoryName(master.Path));
                cmPresenter.MissingComponents.Should().HaveCount(0);
                cmPresenter.NumComponents.Should().Be(numComps);

                var worker = new PrepareMergeWorker(cmPresenter);
                worker.ProgressChanged += HandleProgressChanged;

                worker.BeginWork();

                worker.Wait();

                var syncWorker = new MergeSyncWorker(cmPresenter);
                syncWorker.ProgressChanged += HandleProgressChanged;

                syncWorker.DoWork();

                syncWorker.Wait();
            }
        }

        [Fact]
        // test merging new tally setup added to component one
        // after merge there should be new samplegroups and tally setup in master and component 2
        public void PerformMergeTest_newCountTree2()
        {
            var masterPath = TESTMERGENEWCOUNTS2_MASTER;
            var numComps = 2;

            using (var master = GetMaster(masterPath))
            {
                var appControllerMock = AppControllerMock;
                appControllerMock.Setup(x => x.Database)
                .Returns(master);

                var cmPresenter = new MergeComponentsPresenter(appControllerMock.Object);

                cmPresenter.FindComponents(System.IO.Path.GetDirectoryName(master.Path));
                cmPresenter.MissingComponents.Should().HaveCount(0);
                cmPresenter.NumComponents.Should().Be(numComps);

                var worker = new PrepareMergeWorker(cmPresenter);
                worker.ProgressChanged += HandleProgressChanged;

                worker.BeginWork();

                worker.Wait();

                var syncWorker = new MergeSyncWorker(cmPresenter);
                syncWorker.ProgressChanged += HandleProgressChanged;

                syncWorker.DoWork();

                syncWorker.Wait();

                var comp1 = cmPresenter.ActiveComponents[0];
                var comp2 = cmPresenter.ActiveComponents[1];

                comp2.Database.From<CountTreeDO>().Where("SampleGroup_CN > 1").Query().ToArray();

                var comp1CtCount = comp1.Database.ExecuteScalar<int>("SELECT count(*) FROM CountTree;");
                var comp2CtCount = comp2.Database.ExecuteScalar<int>("SELECT count(*) FROM CountTree;");
                var masterCtCount = master.ExecuteScalar<int>("SELECT count(*) FROM CountTree WHERE Component_CN IS NULL;");

                masterCtCount.Should().Be(comp1CtCount);
                comp2CtCount.Should().Be(comp1CtCount);
            }
        }
        
        public void PerformMergeTest_overTen(string masterPath, int numComps)
        {

        }

        private void HandleProgressChanged(object sender, WorkerProgressChangedEventArgs e)
        {
            Output.WriteLine($"{e.ProgressPercentage * 100.0} done: {e.Message} Tick:");
        }
    }
}