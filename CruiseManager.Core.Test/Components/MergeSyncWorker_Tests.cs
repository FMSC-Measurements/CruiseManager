using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseDAL.V2.Models;
using CruiseManager.Core.Components;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Core.Test.Components
{
    public class MergeSyncWorker_Tests : Comp_TestBase
    {
        public MergeSyncWorker_Tests(ITestOutputHelper output) : base(output)
        {
        }

        protected (DAL master, IEnumerable<DAL> comps) MakeFiles(string baseFileName, int numComponents = 1)
        {
            var masterPath = GetCleanFile(baseFileName + ".m.cruise");
            Output.WriteLine($"masterPath: {masterPath}");

            var masterDB = new DAL(masterPath, true);
            var masterConn = masterDB.OpenConnection();
            CreateCruiseDatabase(masterConn);

            var components = new List<DAL>();
            foreach (var i in Enumerable.Range(1, numComponents))
            {
                var compPath = GetCleanFile(baseFileName + ".1.cruise");
                var compInfo = new ComponentDO() { Component_CN = 1 };

                CreateComponentPresenter.CreateComponent(masterDB, 1, compInfo, compPath);

                components.Add(new DAL(compPath));
            }

            return (masterDB, components);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test_MakeFiles(int numComps)
        {
            var (master, comps) = MakeFiles("MakeFiles", numComps);

            comps.Should().HaveCount(numComps);

            ValidateCreateDatabase(master);

            foreach (var comp in comps)
            {
                ValidateCreateDatabase(comp);
            }
        }

        [Fact]
        public void Test_SyncDesign()
        {
            var (master, comps) = MakeFiles("MakeFiles");

            var compVMs = comps.Select((x, i) => { return new ComponentFileVM() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.InitializeMergeTableCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);
            var worker = new MergeSyncWorker(master, compVMs, commandBuilders);
            worker.ProgressChanged += WriteProgressChangedToOutput;

            worker.SyncDesign();
        }

        [Fact]
        public void Test_SyncDesign_PullTreeDefaults()
        {
            var (master, comps) = MakeFiles("MakeFiles", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFileVM() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.InitializeMergeTableCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);
            var worker = new MergeSyncWorker(master, compVMs, commandBuilders);
            worker.ProgressChanged += WriteProgressChangedToOutput;

            var comp1 = comps.First();
            var comp1TDV1 = new TreeDefaultValue()
            {
                TreeDefaultValue_CN = 1000,
                Species = "nsp1",
                PrimaryProduct = "01",
                LiveDead = "L",
            };
            comp1.Insert(comp1TDV1);

            worker.SyncDesign();

            var mastTDV1 = master.From<TreeDefaultValue>().Where($"Species = 'nsp1'").Query().FirstOrDefault();

            mastTDV1.Should().NotBeNull();
            ValidateTDVSame(mastTDV1, comp1TDV1);

            // because there should be no conflict with the CN values between the master and the component
            // the synced tdv should have the same cn value
            mastTDV1.TreeDefaultValue_CN.Should().Be(comp1TDV1.TreeDefaultValue_CN);

            var comp2 = comps.ElementAt(1);
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
        public void Test_SyncDesign_PullTreeDefaults_master_has_cn_conflict()
        {
            var (master, comps) = MakeFiles("MakeFiles", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFileVM() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.InitializeMergeTableCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);
            var worker = new MergeSyncWorker(master, compVMs, commandBuilders);
            worker.ProgressChanged += WriteProgressChangedToOutput;

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

            worker.SyncDesign();

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
        public void TestSyncDesign_PullCountTree()
        {
            var (master, comps) = MakeFiles("MakeFiles", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFileVM() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.InitializeMergeTableCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);
            var worker = new MergeSyncWorker(master, compVMs, commandBuilders);
            worker.ProgressChanged += WriteProgressChangedToOutput;

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
                Tally_CN  = 1,
            };
            comp1.Insert(compCt1);

            worker.SyncDesign();

            var mastCt1 = master.From<CountTree>()
                .Join("SampleGroup", "USING (SampleGroup_CN)")
                .Where("Code = @p1").Query("nsg1").FirstOrDefault();
            mastCt1.Should().NotBeNull();
        }

        [Fact]
        public void Test_SyncDesign_PullSamplegroups()
        {
            var (master, comps) = MakeFiles("MakeFiles", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFileVM() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.InitializeMergeTableCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);
            var worker = new MergeSyncWorker(master, compVMs, commandBuilders);
            worker.ProgressChanged += WriteProgressChangedToOutput;

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

            worker.SyncDesign();

            var mastSg1 = master.From<SampleGroup>().Where("Code = @p1").Query("nsg1").FirstOrDefault();

            ValidateSgSame(mastSg1, comp1Sg1);

            var comp2 = comps.ElementAt(1);
            var comp2Sg2 = comp2.From<SampleGroup>().Where("Code =  @p1").Query("nsg1").FirstOrDefault();

            ValidateSgSame(comp2Sg2, comp1Sg1);
        }

        [Fact]
        public void Test_SyncDesign_PullSamplegroups_with_cn_conflict()
        {
            var (master, comps) = MakeFiles("MakeFiles", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFileVM() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.InitializeMergeTableCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);
            var worker = new MergeSyncWorker(master, compVMs, commandBuilders);
            worker.ProgressChanged += WriteProgressChangedToOutput;

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

            worker.SyncDesign();

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
        public void Test_SyncDesign_PushStratum()
        {
            var (master, comps) = MakeFiles("MakeFiles", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFileVM() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.InitializeMergeTableCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);
            var worker = new MergeSyncWorker(master, compVMs, commandBuilders);
            worker.ProgressChanged += WriteProgressChangedToOutput;

            var mastSt1 = new Stratum()
            {
                Code = "nst1",
                Method = "100",
            };
            master.Insert(mastSt1, keyValue: 1000);

            worker.SyncDesign();

            var comp1 = comps.First();
            var compSt1 = comp1.From<Stratum>().Where("Code = @p1").Query(mastSt1.Code).Single();
            compSt1.Should().NotBeNull();

        }

        [Fact]
        public void Test_SyncDesign_PushStratum_with_cn_conflict()
        {
            var (master, comps) = MakeFiles("MakeFiles", 2);

            var compVMs = comps.Select((x, i) => { return new ComponentFileVM() { Database = x, Component_CN = i }; })
                .ToArray();
            var commandBuilders = MergeComponentsPresenter.InitializeMergeTableCommandBuilders(master)
                .ToDictionary(x => x.ClientTableName);
            var worker = new MergeSyncWorker(master, compVMs, commandBuilders);
            worker.ProgressChanged += WriteProgressChangedToOutput;

            var comp1 = comps.First();

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

            worker.SyncDesign();

            var compSt1 = comp1.From<Stratum>().Where("Code = @p1").Query(mastSt1.Code).Single();
            compSt1.Should().NotBeNull();
            compSt1.Stratum_CN.Should().Be(mastSt1.Stratum_CN);

        }


        private void WriteProgressChangedToOutput(object sender, WorkerProgressChangedEventArgs ea)
        {
            Output.WriteLine(ea.Message);
        }
    }
}