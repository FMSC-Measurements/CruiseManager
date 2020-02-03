using CruiseDAL.DataObjects;
using CruiseManager.Core.App;
using CruiseManager.WinForms.DataEditor;
using FluentAssertions;
using Moq;
using System.IO;
using Xunit;

namespace CruiseManager.WinForms.Test
{
    public class DataEditorViewTest
    {
        public static string readTestFile = ".\\TestFiles\\testReadData.Cruise";

        [Fact(Skip = "app controller mock needed")]
        public void ReadTreesTest()
        {
            var path = Path.GetFullPath(readTestFile);
            File.Exists(path).Should().BeTrue(path);

            using (var ds = new CruiseDAL.DAL(readTestFile))
            {
                var wp = Mock.Of<WindowPresenter>();
                var appController = Mock.Of<ApplicationControllerBase>();
                var target = new DataEditorView(wp, appController);

                var cu = new CuttingUnitDO() { rowID = 1 };
                var st = new StratumDO() { rowID = 1 };
                var sg = new SampleGroupDO() { rowID = 1 };
                var tdv = new TreeDefaultValueDO() { rowID = 1 };

                var trees = target.ReadTrees(cu, st, sg, tdv);

                trees.Should().NotBeNullOrEmpty();
            }
        }

        [Fact(Skip = "app controller mock needed")]
        public void ReadPlotsTest()
        {
            using (var ds = new CruiseDAL.DAL(readTestFile))
            {
                var wp = Mock.Of<WindowPresenter>();
                var appController = Mock.Of<ApplicationControllerBase>();
                var target = new DataEditorView(wp, appController);

                var cu = new CuttingUnitDO() { rowID = 1 };
                var st = new StratumDO() { rowID = 1 };

                var plots = target.ReadPlots(cu, st);

                plots.Should().NotBeNullOrEmpty();
            }
        }

        [Fact(Skip = "app controller mock needed")]
        public void ReadLogsTest()
        {
            using (var ds = new CruiseDAL.DAL(readTestFile))
            {
                var wp = Mock.Of<WindowPresenter>();
                var appController = Mock.Of<ApplicationControllerBase>();
                var target = new DataEditorView(wp, appController);

                var cu = new CuttingUnitDO() { rowID = 1 };
                var st = new StratumDO() { rowID = 1 };
                var sg = new SampleGroupDO() { rowID = 1 };
                var tdv = new TreeDefaultValueDO() { rowID = 1 };

                var logs = target.ReadLogs(cu, st, sg, tdv);

                logs.Should().NotBeNullOrEmpty();
            }
        }

        [Fact(Skip = "app controller mock needed")]
        public void ReadCountsTest()
        {
            using (var ds = new CruiseDAL.DAL(readTestFile))
            {
                var wp = Mock.Of<WindowPresenter>();
                var appController = Mock.Of<ApplicationControllerBase>();
                var target = new DataEditorView(wp, appController);

                var cu = new CuttingUnitDO() { rowID = 1 };
                var st = new StratumDO() { rowID = 1 };
                var sg = new SampleGroupDO() { rowID = 1 };

                var counts = target.ReadCounts(cu, st, sg);
                counts.Should().NotBeNullOrEmpty();
            }
        }
    }
}