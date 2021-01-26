using CruiseDAL.DataObjects;
using CruiseDAL.V2.Models;
using CruiseManager.Core.Components;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components
{
    public class MergeSyncWorker_Tests : Comp_TestBase
    {
        private const string TESTMERGENEWCOUNTS2_MASTER = "Good\\testMergeNewCounts2\\12345 testMergeNewCountTrees TS.M.cruise";

        public MergeSyncWorker_Tests(ITestOutputHelper output) : base(output)
        {
        }

        

        [Fact]
        public void SyncDesign_Test()
        {
            var (master, comps) = MakeFiles();

            var compVMs = comps.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.MakeCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);

            MergeSyncWorker.SyncDesign(master, compVMs, new System.Threading.CancellationToken(), null, TestMergeLogWriter);
        }

        [Fact]
        public void SyncDesign_Test_PullTreeDefaults()
        {
            var (master, compDbs) = MakeFiles(numComponents: 2);

            var components = compDbs.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.MakeCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);

            var comp1 = compDbs.First();
            var comp1TDV1 = new TreeDefaultValue()
            {
                TreeDefaultValue_CN = 1000,
                Species = "nsp1",
                PrimaryProduct = "01",
                LiveDead = "L",
            };
            comp1.Insert(comp1TDV1);

            MergeSyncWorker.SyncDesign(
                master,
                components,
                new System.Threading.CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);

            var mastTDV1 = master.From<TreeDefaultValue>().Where($"Species = 'nsp1'").Query().FirstOrDefault();

            mastTDV1.Should().NotBeNull();
            ValidateTDVSame(mastTDV1, comp1TDV1);

            // because there should be no conflict with the CN values between the master and the component
            // the synced tdv should have the same cn value
            mastTDV1.TreeDefaultValue_CN.Should().Be(comp1TDV1.TreeDefaultValue_CN);

            var comp2 = compDbs.ElementAt(1);
            var comp2TDV1 = comp2.From<TreeDefaultValue>().Where("Species = 'nsp1'").Query().FirstOrDefault();

            ValidateTDVSame(comp2TDV1, comp2TDV1);
            comp2TDV1.TreeDefaultValue_CN.Should().Be(comp1TDV1.TreeDefaultValue_CN);

            void ValidateTDVSame(TreeDefaultValue tdv1, TreeDefaultValue tdv2)
            {
                tdv1.Species.Should().Be(tdv2.Species);
                tdv1.PrimaryProduct.Should().Be(tdv2.PrimaryProduct);
                tdv1.LiveDead.Should().Be(tdv2.LiveDead);
            }
        }

        [Fact]
        public void SyncDesign_Test_PullTreeDefaults_master_has_cn_conflict()
        {
            var (master, comps) = MakeFiles(numComponents: 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();

            var comp1 = comps.First();
            var comp1TDV1 = new TreeDefaultValue()
            {
                TreeDefaultValue_CN = 1000,
                Species = "nsp1",
                PrimaryProduct = "01",
                LiveDead = "L",
            };
            comp1.Insert(comp1TDV1);

            var mastTDV2 = new TreeDefaultValue()
            {
                TreeDefaultValue_CN = 1000,
                Species = "nsp2",
                PrimaryProduct = "01",
                LiveDead = "L",
            };
            master.Insert(mastTDV2);

            MergeSyncWorker.SyncDesign(
                master,
                compVMs,
                new System.Threading.CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);

            var mastTDV1 = master.From<TreeDefaultValue>().Where($"Species = 'nsp1'").Query().FirstOrDefault();

            mastTDV1.Should().NotBeNull();
            ValidateTDVSame(mastTDV1, comp1TDV1);

            mastTDV1.TreeDefaultValue_CN.Should().NotBe(comp1TDV1.TreeDefaultValue_CN);

            var comp2 = comps.ElementAt(1);
            var comp2TDV1 = comp2.From<TreeDefaultValue>().Where("Species = 'nsp1'").Query().FirstOrDefault();

            ValidateTDVSame(comp2TDV1, comp2TDV1);
            comp2TDV1.TreeDefaultValue_CN.Should().NotBe(comp1TDV1.TreeDefaultValue_CN);

            var comp1TDV1Again = comp1.From<TreeDefaultValue>().Where("Species = 'nsp1'").Query().FirstOrDefault();
            ValidateTDVSame(comp2TDV1, mastTDV1);
            comp1TDV1Again.TreeDefaultValue_CN.Should().Be(mastTDV1.TreeDefaultValue_CN);

            void ValidateTDVSame(TreeDefaultValue tdv1, TreeDefaultValue tdv2)
            {
                tdv1.Species.Should().Be(tdv2.Species);
                tdv1.PrimaryProduct.Should().Be(tdv2.PrimaryProduct);
                tdv1.LiveDead.Should().Be(tdv2.LiveDead);
            }
        }

        [Fact]
        public void SyncDesign_Test_PullCountTree()
        {
            var (master, comps) = MakeFiles(numComponents: 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();

            var comp1 = comps.First();

            var comp1Sg1 = new SampleGroup()
            {
                Code = "nsg1",
                PrimaryProduct = "01",
                CutLeave = "C",
                UOM = "01",
            };
            comp1.Insert(comp1Sg1, keyValue: 1000);

            var compCt1 = new CountTree()
            {
                CuttingUnit_CN = 1,
                SampleGroup_CN = 1000,
                Tally_CN = 1,
            };
            comp1.Insert(compCt1);

            MergeSyncWorker.SyncDesign(
                master,
                compVMs,
                new System.Threading.CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);

            var mastCt1 = master.From<CountTree>()
                .Join("SampleGroup", "USING (SampleGroup_CN)")
                .Where("Code = @p1").Query("nsg1").FirstOrDefault();
            mastCt1.Should().NotBeNull();
        }

        [Fact]
        public void SyncDesign_Test_PullSamplegroups()
        {
            var (master, comps) = MakeFiles(numComponents: 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();

            var comp1 = comps.First();

            var comp1Sg1 = new SampleGroup()
            {
                Stratum_CN = 1,
                Code = "nsg1",
                PrimaryProduct = "01",
                CutLeave = "C",
                UOM = "01",
            };
            comp1.Insert(comp1Sg1, keyValue: 1000);

            MergeSyncWorker.SyncDesign(
                master,
                compVMs,
                new System.Threading.CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);

            var mastSg1 = master.From<SampleGroup>().Where("Code = @p1").Query("nsg1").FirstOrDefault();

            ValidateSgSame(mastSg1, comp1Sg1);

            var comp2 = comps.ElementAt(1);
            var comp2Sg2 = comp2.From<SampleGroup>().Where("Code =  @p1").Query("nsg1").FirstOrDefault();

            ValidateSgSame(comp2Sg2, comp1Sg1);
        }

        [Fact]
        public void SyncDesign_Test_PullSamplegroups_with_cn_conflict()
        {
            var (master, comps) = MakeFiles(numComponents: 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();

            var comp1 = comps.First();

            var comp1Sg1 = new SampleGroup()
            {
                SampleGroup_CN = 1000,
                Code = "nsg1",
                Stratum_CN = 1,
                PrimaryProduct = "01",
                CutLeave = "C",
                UOM = "01",
            };
            comp1.Insert(comp1Sg1, keyValue: 1000);

            var mastSg2 = new SampleGroup()
            {
                SampleGroup_CN = 1000,
                Code = "nsg2",
                Stratum_CN = 1,
                PrimaryProduct = "01",
                CutLeave = "C",
                UOM = "01",
            };
            master.Insert(mastSg2, keyValue: 1000);

            MergeSyncWorker.SyncDesign(
                master,
                compVMs,
                new System.Threading.CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);

            var mastSg1 = master.From<SampleGroup>().Where("Code = @p1").Query("nsg1").FirstOrDefault();

            ValidateSgSame(mastSg1, comp1Sg1, false);

            var comp2 = comps.ElementAt(1);
            var comp2Sg2 = comp2.From<SampleGroup>().Where("Code =  @p1").Query("nsg1").FirstOrDefault();

            ValidateSgSame(comp2Sg2, comp1Sg1, false);
        }

        private void ValidateSgSame(SampleGroup sg1, SampleGroup sg2, bool validateCNSame = true)
        {
            sg1.Code.Should().Be(sg2.Code);

            if (validateCNSame)
            {
                sg1.SampleGroup_CN.Should().Be(sg2.SampleGroup_CN);
            }
            else
            {
                sg1.SampleGroup_CN.Should().NotBe(sg2.SampleGroup_CN);
            }
        }

        [Fact]
        public void SyncDesign_Test_PushStratum()
        {
            var (master, compDbs) = MakeFiles(numComponents: 2);

            var components = compDbs.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();

            var mastSt1 = new Stratum()
            {
                Code = "nst1",
                Method = "100",
            };
            master.Insert(mastSt1, keyValue: 1000);

            MergeSyncWorker.SyncDesign(
                master,
                components,
                new System.Threading.CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);

            var comp1 = compDbs.First();
            var compSt1 = comp1.From<Stratum>().Where("Code = @p1").Query(mastSt1.Code).Single();
            compSt1.Should().NotBeNull();
            compSt1.Stratum_CN.Should().Be(mastSt1.Stratum_CN);
        }

        [Fact]
        public void SyncDesign_Test_PushStratum_with_cn_conflict()
        {
            var (master, compDbs) = MakeFiles(numComponents: 2);

            var components = compDbs.Select((x, i) => { return new ComponentFile() { Database = x, Component_CN = i }; })
                .ToArray();

            var comp1 = compDbs.First();

            var mastSt1 = new Stratum()
            {
                Code = "nst1",
                Method = "100",
            };
            master.Insert(mastSt1, keyValue: 1000);

            var compSt2 = new Stratum()
            {
                Code = "nst2",
                Method = "100",
            };
            comp1.Insert(compSt2, keyValue: 1000);

            MergeSyncWorker.SyncDesign(
                master,
                components,
                new System.Threading.CancellationToken(),
                (IProgress<int>)null,
                TestMergeLogWriter);

            var compSt1 = comp1.From<Stratum>().Where("Code = @p1").Query(mastSt1.Code).Single();
            compSt1.Should().NotBeNull();
            compSt1.Stratum_CN.Should().Be(mastSt1.Stratum_CN);
        }

        [Fact]
        public void SyncFieldData_Pull_Plots_Insert()
        {
            var cancelation = new System.Threading.CancellationToken();
            var (master, compDbs, components, commandBuilders) = Setup();

            var comp1 = compDbs.First();
            var newPlot = new Plot()
            {
                Stratum_CN = 1,
                CuttingUnit_CN = 1,
                PlotNumber = 1,
                Plot_GUID = Guid.NewGuid().ToString().ToUpper(),
            };
            comp1.Insert(newPlot);

            PrepareMergeWorker.DoWork(
                master,
                components,
                commandBuilders.Values,
                cancelation,
                (IProgress<int>)null,
                TestMergeLogWriter);

            MergeSyncWorker.SyncFieldData(
               master,
               components,
               commandBuilders,
               cancelation,
               (IProgress<int>)null,
               TestMergeLogWriter);

            var masterNewPlot = master.From<Plot>().Query().First();

            newPlot.Plot_CN.Should().Be(masterNewPlot.Plot_CN);
            newPlot.Stratum_CN.Should().Be(masterNewPlot.Stratum_CN);
            newPlot.CuttingUnit_CN.Should().Be(masterNewPlot.CuttingUnit_CN);
            newPlot.Plot_GUID.Should().Be(masterNewPlot.Plot_GUID);
        }

        [Fact]
        public void SyncFieldData_Pull_Tree_Insert()
        {
            var cancelation = new System.Threading.CancellationToken();
            var (master, compDbs, components, commandBuilders) = Setup();

            var comp1 = compDbs.First();
            var newTree = new Tree()
            {
                Stratum_CN = 1,
                CuttingUnit_CN = 1,
                SampleGroup_CN = 1,
                Tree_GUID = Guid.NewGuid().ToString().ToUpper(),
                TreeNumber = 1,
            };
            comp1.Insert(newTree);

            PrepareMergeWorker.DoWork(
                master,
                components,
                commandBuilders.Values,
                cancelation,
                (IProgress<int>)null,
                TestMergeLogWriter);

            MergeSyncWorker.SyncFieldData(
               master,
               components,
               commandBuilders,
               cancelation,
               (IProgress<int>)null,
               TestMergeLogWriter);

            var masterNewTree = master.From<Tree>().Query().First();

            newTree.Tree_CN.Should().Be(masterNewTree.Tree_CN);
            newTree.CuttingUnit_CN.Should().Be(masterNewTree.CuttingUnit_CN);
            newTree.Stratum_CN.Should().Be(masterNewTree.Stratum_CN);
            newTree.SampleGroup_CN.Should().Be(masterNewTree.SampleGroup_CN);
            newTree.Tree_GUID.Should().Be(masterNewTree.Tree_GUID);
        }


        [Fact]
        // test merging new tally setup added to component one
        // after merge there should be new samplegroups and tally setup in master and component 2
        public void PerformMergeTest_newCountTree2()
        {
            var masterPath = TESTMERGENEWCOUNTS2_MASTER;
            var numComps = 2;

            var (master, components) = FindFiles(masterPath);
            using (master)
            {
                var commandBuilders = MergeComponentsPresenter.MakeCommandBuilders(master);
                var commandBuilderDict = commandBuilders.ToDictionary(x => x.ClientTableName);
                var mergeLog = new TestMergeLogWriter(Output);

                PrepareMergeWorker.DoWork(master, components, commandBuilders, new System.Threading.CancellationToken(), (IProgress<int>)null, TestMergeLogWriter);

                MergeSyncWorker.DoMerge(master, components, commandBuilderDict, new System.Threading.CancellationToken(),
                    (IProgress<int>)null, 
                    TestMergeLogWriter);

                var comp1 = components.ElementAt(0);
                var comp2 = components.ElementAt(1);

                comp2.Database.From<CountTreeDO>().Where("SampleGroup_CN > 1").Query().ToArray();

                var comp1CtCount = comp1.Database.ExecuteScalar<int>("SELECT count(*) FROM CountTree;");
                var comp2CtCount = comp2.Database.ExecuteScalar<int>("SELECT count(*) FROM CountTree;");
                var masterCtCount = master.ExecuteScalar<int>("SELECT count(*) FROM CountTree WHERE Component_CN IS NULL;");

                masterCtCount.Should().Be(comp1CtCount);
                comp2CtCount.Should().Be(comp1CtCount);
            }
        }
    }
}