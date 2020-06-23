using CruiseManager.Core.Components;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components
{
    public class PrepareMergeWorker_Test : Comp_TestBase
    {
        private const string REDSQUIRT_MASTER = "Bad\\RedSquirt.M.cruise";
        private const string VALENTINE_MASTER = "Good\\Valentine.M.cruise";
        private const string GOOSEFOOTE_MASTER = "Good\\GooseFoote_7_16\\GooseFoote.M.cruise";
        private const string TESTMERGENEWCOUNTS_MASTER = "Good\\testMergeNewCounts\\testMergeNewCounts.M.cruise";
        private const string TESTMERGENEWCOUNTS2_MASTER = "Good\\testMergeNewCounts2\\12345 testMergeNewCountTrees TS.M.cruise";
        private const string TESTMAXCOMPONENTS_MASTER = "Good\\testMaxComponents\\12345 testMergeMaxComponents TS.M.cruise";

        

        public PrepareMergeWorker_Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void MakeMergeTables_Test()
        {
            var (master, comps) = MakeFiles("MakeMergeTables", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.MakeCommandBuilders(master);

            PrepareMergeWorker.MakeMergeTables(master, commandBuilders, new System.Threading.CancellationToken(), (IProgress<int>)null, TestMergeLogWriter);

            foreach(var cmd in commandBuilders)
            {
                master.CheckTableExists(cmd.MergeTableName).Should().BeTrue();
                Output.WriteLine(master.GetTableSQL(cmd.MergeTableName));
            }
        }

        [Fact]
        public void PopulateMergeTables_Test()
        {
            var (master, comps) = MakeFiles("PopulateMergeTables", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.MakeCommandBuilders(master);

            PrepareMergeWorker.MakeMergeTables(master, commandBuilders, new System.Threading.CancellationToken(), (IProgress<int>)null, TestMergeLogWriter);

            PrepareMergeWorker.PopulateMergeTables(
                master,
                compVMs,
                commandBuilders,
                new CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);
        }

        [Fact] 
        public void ProcessMergeTables_Test()
        {
            var (master, comps) = MakeFiles("ProcessMergeTables", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.MakeCommandBuilders(master);

            PrepareMergeWorker.MakeMergeTables(master, commandBuilders, new System.Threading.CancellationToken(), (IProgress<int>)null, TestMergeLogWriter);

            PrepareMergeWorker.PopulateMergeTables(
                master,
                compVMs,
                commandBuilders,
                new CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);

            PrepareMergeWorker.ProcessMergeTables(
                master,
                compVMs,
                commandBuilders,
                new CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);
        }

        [Theory]
        [InlineData(REDSQUIRT_MASTER, 3)]
        [InlineData(VALENTINE_MASTER, 2)]
        [InlineData(GOOSEFOOTE_MASTER, 3)]
        [InlineData(TESTMERGENEWCOUNTS_MASTER, 2)]
        public void PrepareMerge_Test_With_Files(string masterPath, int numComps)
        {
            var (master, components) = FindFiles(masterPath);
            components.Should().HaveCount(numComps);
            var commandBuilders = MergeComponentsPresenter.MakeCommandBuilders(master);
            using (master)
            {
                PrepareMergeWorker.DoWork(
                    master,
                    components,
                    commandBuilders,
                    new System.Threading.CancellationToken(),
                    null,
                    new TestMergeLogWriter(Output));
            }
        }
    }
}