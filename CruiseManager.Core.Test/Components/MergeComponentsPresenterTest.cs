using CruiseDAL;
using CruiseManager.Core;
using CruiseManager.Core.Components;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components
{
    public class MergeComponentsPresenterTest : Comp_TestBase
    {
        public MergeComponentsPresenterTest(ITestOutputHelper output) : base(output)
        {
        }

        private const string REDSQUIRT_MASTER = "Bad\\RedSquirt.M.cruise";
        private const string HAYWIRELAKE_MASTER = "Good\\41125HaywireLakeTS_2Strata_08212019\\41125HaywireLakeTS_2Strata_08212019.1.cruise";
        private const string GOOSEFOOTE_MASTER = "Good\\GooseFoote_7_16\\GooseFoote.M.cruise";
        private const string TESTMERGENEWCOUNTS_MASTER = "Good\\testMergeNewCounts\\testMergeNewCounts.M.cruise";
        private const string TESTMAXCOMPONENTS_MASTER = "Good\\testMaxComponents\\12345 testMergeMaxComponents TS.M.cruise";

        public DAL GetMaster(string masterPath)
        {
            var path = System.IO.Path.Combine(ComponentsTestFilesDir, masterPath);
            return new DAL(path);
        }

        [Theory]
        [InlineData(REDSQUIRT_MASTER, 3)]
        [InlineData(HAYWIRELAKE_MASTER, 2)]
        [InlineData(GOOSEFOOTE_MASTER, 3)]
        [InlineData(TESTMERGENEWCOUNTS_MASTER, 2)]
        public void Ctor_Test(string masterPath, int numComps)
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
        [InlineData(GOOSEFOOTE_MASTER, 3)]
        [InlineData(HAYWIRELAKE_MASTER, 2)]
        [InlineData(TESTMERGENEWCOUNTS_MASTER, 2)]
        [InlineData(TESTMAXCOMPONENTS_MASTER, 21)]
        public void RunPreMerge_Test(string masterPath, int numComps)
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
                cmPresenter.IsPrepared.Should().BeFalse();

                cmPresenter.RunPreMerge().Wait();
                cmPresenter.IsPrepared.Should().BeTrue();

                if (masterPath.StartsWith("Good\\"))
                {
                    cmPresenter.GetNumConflicts().Should().Be(0);
                    cmPresenter.HasConflicts.Should().BeFalse();
                }
            }
        }

        [Theory]
        [InlineData(HAYWIRELAKE_MASTER, 2)]
        [InlineData(GOOSEFOOTE_MASTER, 3)]
        [InlineData(TESTMERGENEWCOUNTS_MASTER, 2)]
        [InlineData(TESTMAXCOMPONENTS_MASTER, 21)]
        public void RunMerge_Test(string masterPath, int numComps)
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


                cmPresenter.RunPreMerge().Wait();

                cmPresenter.GetNumConflicts().Should().Be(0);
                cmPresenter.HasConflicts.Should().BeFalse();

                cmPresenter.RunMerge().Wait();
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