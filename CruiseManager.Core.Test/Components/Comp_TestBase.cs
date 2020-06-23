using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseDAL.V2.Models;
using CruiseManager.Core.Components;
using CruiseManager.Test;
using FluentAssertions;
using FMSC.ORM.Core;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components
{
    public class Comp_TestBase : TestBase
    {
        public string ComponentsTestFilesDir => Path.Combine(TestFilesDir, "Components");

        protected CuttingUnit[] Units { get; set; }
        protected Stratum[] Strata { get; set; }
        protected CuttingUnitStratum[] UnitStrata { get; set; }
        protected string[] Species { get; set; }
        protected SampleGroup[] SampleGroups { get; set; }
        protected TreeDefaultValue[] TreeDefaults { get; set; }
        protected SampleGroupTreeDefaultValue[] SGTDV { get; set; }
        public Stratum[] PlotStrata { get; set; }
        public Stratum[] NonPlotStrata { get; set; }
        public CountTree[] CountTrees { get; set; }

        public TestMergeLogWriter TestMergeLogWriter { get; }

        public Comp_TestBase(ITestOutputHelper output) : base(output)
        {
            TestMergeLogWriter = new TestMergeLogWriter(output);
        }

        //        protected void CreateCruiseDatabase(DbConnection connection)
        //        {
        //            var units = Units = new CuttingUnit[]
        //            {
        //                new CuttingUnit{Code = "u1"},
        //                new CuttingUnit{Code = "u2"},
        //            };

        //            foreach (var unit in units)
        //            { connection.Insert(unit); }

        //            var plotStrata = PlotStrata = new[]
        //            {
        //                new Stratum{ Code = "st1", Method = "PNT" },
        //                new Stratum{ Code = "st2", Method = "PCM" },
        //            };

        //            var nonPlotStrata = NonPlotStrata = new[]
        //            {
        //                new Stratum{ Code = "st3", Method = "STR" },
        //                new Stratum{ Code = "st4", Method = "STR" },
        //            };

        //            var strata = Strata = plotStrata.Concat(nonPlotStrata).ToArray();

        //            foreach (var st in strata)
        //            { connection.Insert(st); }

        //            UnitStrata = new[]
        //                {
        //                new CuttingUnitStratum {CuttingUnit_CN = units[0].CuttingUnit_CN.Value, Stratum_CN = plotStrata[0].Stratum_CN.Value
        //    },
        //                new CuttingUnitStratum {CuttingUnit_CN = units[0].CuttingUnit_CN.Value, Stratum_CN = plotStrata[1].Stratum_CN.Value
        //},
        //                new CuttingUnitStratum {CuttingUnit_CN = units[1].CuttingUnit_CN.Value, Stratum_CN = plotStrata[1].Stratum_CN.Value},

        //                new CuttingUnitStratum {CuttingUnit_CN = units[0].CuttingUnit_CN.Value, Stratum_CN = nonPlotStrata[0].Stratum_CN.Value },
        //                new CuttingUnitStratum {CuttingUnit_CN = units[0].CuttingUnit_CN.Value, Stratum_CN = nonPlotStrata[1].Stratum_CN.Value},
        //                new CuttingUnitStratum {CuttingUnit_CN = units[1].CuttingUnit_CN.Value, Stratum_CN = nonPlotStrata[1].Stratum_CN.Value},
        //            };

        //            foreach (var us in UnitStrata)
        //            {
        //                connection.Insert(us);
        //            }

        //            var species = Species = new string[] { "sp1", "sp2", "sp3" };

        //            var sgs = SampleGroups = new[]
        //            {
        //                // stratum 1
        //                new SampleGroup {Code = "sg1", Stratum_CN = plotStrata[0].Stratum_CN.Value, SamplingFrequency = 101},
        //                new SampleGroup {Code = "sg2", Stratum_CN = plotStrata[1].Stratum_CN.Value, SamplingFrequency = 102},

        //                // stratum 2
        //                new SampleGroup {Code = "sg1", Stratum_CN = nonPlotStrata[0].Stratum_CN.Value, SamplingFrequency = 101},
        //                new SampleGroup {Code = "sg2", Stratum_CN = nonPlotStrata[1].Stratum_CN.Value, SamplingFrequency = 10},
        //            };

        //            foreach (var sg in sgs)
        //            { connection.Insert(sg); }

        //            var tdvs = TreeDefaults = new[]
        //                        {
        //                new TreeDefaultValue {Species = species[0], LiveDead = "L", PrimaryProduct = "01"},
        //                new TreeDefaultValue {Species = species[0], LiveDead = "D", PrimaryProduct = "01"},
        //                new TreeDefaultValue {Species = species[1], LiveDead = "L", PrimaryProduct = "01"},
        //                new TreeDefaultValue {Species = species[2], LiveDead = "L", PrimaryProduct = "01"},
        //            };

        //            foreach (var tdv in tdvs)
        //            { connection.Insert(tdv); }

        //            SGTDV = new SampleGroupTreeDefaultValue[]
        //            {
        //                // stratum 1
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[0].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[0].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[0].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[1].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[0].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[2].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[0].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[4].TreeDefaultValue_CN.Value },

        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[1].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[1].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[1].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[2].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[1].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[3].TreeDefaultValue_CN.Value },

        //                // stratum 2
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[2].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[0].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[2].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[1].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[2].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[2].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[2].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[4].TreeDefaultValue_CN.Value },

        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[3].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[1].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[3].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[2].TreeDefaultValue_CN.Value },
        //                new SampleGroupTreeDefaultValue{ SampleGroup_CN = sgs[3].SampleGroup_CN.Value, TreeDefaultValue_CN = tdvs[3].TreeDefaultValue_CN.Value },
        //            };

        //            foreach (var sgtdv in SGTDV)
        //            { connection.Insert(sgtdv); }
        //        }

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //public void MakeFiles_Test(int numComps)
        //{
        //    var (master, comps) = MakeFiles("MakeFiles", numComps);

        //    comps.Should().HaveCount(numComps);

        //    ValidateCreateDatabase(master);

        //    foreach (var comp in comps)
        //    {
        //        ValidateCreateDatabase(comp);
        //    }
        //}

        //[Fact]
        //public void TestCreateCruiseDatabase()
        //{
        //    using (var database = new DAL())
        //    {
        //        var connection = database.OpenConnection();

        //        CreateCruiseDatabase(connection);

        //        ValidateCreateDatabase(database);
        //    }
        //}

        protected void ValidateCreateDatabase(DAL database)
        {
            database.GetRowCount("CuttingUnit", null).Should().Be(Units.Length);
            database.GetRowCount("Stratum", null).Should().Be(Strata.Length);
            database.GetRowCount("SampleGroup", null).Should().Be(SampleGroups.Length);
            database.GetRowCount("CountTree", null).Should().Be(CountTrees.Length);

            database.GetRowCount("Tally", null).Should().BeInRange(1, CountTrees.Length);
            database.GetRowCount("CountTree", "WHERE Tally_CN IS NULL").Should().Be(0);
        }

        protected void CreateCruiseDatabase(DbConnection connection,
            string[] unitsCodes = null,
            (string code, string method)[] strata = null,
            (string unit, string st)[] unitStrata = null,
            (string st, string sg, bool tallyBySP)[] sampleGroups = null)
        {
            unitsCodes = unitsCodes ?? new[] { "u1", "u2" };
            strata = strata ?? new[] { ("st1", "STR"), ("st2", "3p") };
            unitStrata = unitStrata ??
                new[] { ("u1", "st1"), ("u1", "st2"), ("u2", "st1"), ("u2", "st2") };

            sampleGroups = sampleGroups ?? new[]
            {
                ("st1", "sg1", false), ("st1", "sg2", true),
                ("st2", "sg1", false), ("st2", "sg2", true),
            };

            CuttingUnit[] units = Units = unitsCodes.Select(x =>
            {
                return new CuttingUnit { Code = x };
            }).ToArray();

            foreach (var unit in units)
            { connection.Insert(unit); }

            var _strata = Strata = strata.Select(x =>
            {
                return new Stratum { Code = x.code, Method = x.method ?? "STR" };
            }).ToArray();

            foreach (var st in _strata)
            { connection.Insert(st); }

            UnitStrata = unitStrata.Select(x =>
            {
                var cu_cn = units.Single(y => y.Code == x.unit).CuttingUnit_CN.Value;
                var st_cn = _strata.Single(y => y.Code == x.st).Stratum_CN.Value;

                return new CuttingUnitStratum { CuttingUnit_CN = cu_cn, Stratum_CN = st_cn };
            }).ToArray();

            foreach (var us in UnitStrata)
            {
                connection.Insert(us);
            }

            var species = Species = new string[] { "sp1", "sp2", "sp3" };

            var sgs = SampleGroups = sampleGroups.Select((sg, i) =>
            {
                var st_cn = _strata.Where(x => x.Code == sg.st).Single().Stratum_CN;

                return new SampleGroup
                {
                    Code = sg.sg,
                    Stratum_CN = st_cn.Value,
                    SamplingFrequency = 100 + i,
                    CutLeave = "C",
                    UOM = "01",
                    PrimaryProduct = "01"
                };
            }).ToArray();

            foreach (var sg in sgs)
            { connection.Insert(sg); }

            var tdvs = TreeDefaults = new[]
            {
                new TreeDefaultValue {Species = species[0], LiveDead = "L", PrimaryProduct = "01"},
                new TreeDefaultValue {Species = species[0], LiveDead = "D", PrimaryProduct = "01"},
                new TreeDefaultValue {Species = species[1], LiveDead = "L", PrimaryProduct = "01"},
                new TreeDefaultValue {Species = species[2], LiveDead = "L", PrimaryProduct = "01"},
            };

            foreach (var tdv in tdvs)
            { connection.Insert(tdv); }

            SGTDV = sgs.Select((sg, i) =>
            {
                return tdvs.Take((i % 2 == 0) ? 2 : 3)
                .Select(tdv =>
                {
                    return new SampleGroupTreeDefaultValue
                    {
                        SampleGroup_CN = sg.SampleGroup_CN.Value,
                        TreeDefaultValue_CN = tdv.TreeDefaultValue_CN.Value
                    };
                });
            }).SelectMany(x => x).ToArray();

            foreach (var sgtdv in SGTDV)
            { connection.Insert(sgtdv); }

            CountTrees = sampleGroups.Select((sg) =>
            {
                var st_cn = _strata.Where(x => x.Code == sg.st).Single().Stratum_CN;

                var sg_cn = sgs.Single(x => x.Code == sg.sg
                && x.Stratum_CN == st_cn).SampleGroup_CN.Value;

                if (sg.tallyBySP)
                {
                    return (IEnumerable<IEnumerable<CountTree>>)SGTDV.Where(x => x.SampleGroup_CN == sg_cn).Select(sgtdv =>
                    {
                        return units.Select(cu =>
                        {
                            return new CountTree
                            {
                                CuttingUnit_CN = cu.CuttingUnit_CN.Value,
                                SampleGroup_CN = sg_cn,
                                TreeDefaultValue_CN = sgtdv.TreeDefaultValue_CN.Value
                            };
                        });
                    });
                }
                else
                {
                    return (IEnumerable<IEnumerable<CountTree>>)new[]
                    {
                        units.Select(cu =>
                        {
                            return new CountTree
                            {
                                CuttingUnit_CN = cu.CuttingUnit_CN.Value,
                                SampleGroup_CN = sg_cn,
                                TreeDefaultValue_CN = null,
                            };
                        })
                    };
                }
            }).SelectMany(x => x).SelectMany(x => x).ToArray();

            foreach (var ct in CountTrees)
            {
                var ctSp = (ct.TreeDefaultValue_CN.HasValue) ? connection.ExecuteScalar<string>("SELECT Species FROM TreeDefaultValue WHERE TreeDefaultValue_CN =  @p1;", new object[] { ct.TreeDefaultValue_CN }) :
                    (string)null;

                var ctSg = connection.ExecuteScalar<string>("SELECT Code FROM SampleGroup WHERE SampleGroup_CN = @p1", new object[] { ct.SampleGroup_CN });

                var ctDescription = $"{ctSp}-{ctSg}";

                var tally_CN = connection.ExecuteScalar<int?>($"SELECT Tally_CN FROM Tally WHERE Description = '{ctDescription}';");

                if (tally_CN.HasValue == false)
                {
                    tally_CN = (int?)connection.Insert(new Tally()
                    {
                        Description = ctDescription,
                        Hotkey = "A",
                    });
                }

                ct.Tally_CN = tally_CN;

                connection.Insert(ct);
            }
        }

        protected (DAL master, IEnumerable<DAL> comps) MakeFiles([CallerMemberName] string baseFileName = null, int numComponents = 1)
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

        protected (DAL master, IEnumerable<ComponentFile> comps) FindFiles(string baseFileName)
        {
            var masterPath = Path.Combine(ComponentsTestFilesDir, baseFileName);
            var searchDir = Path.GetDirectoryName(masterPath);

            Output.WriteLine($"masterPath: {masterPath}");

            var master = new DAL(masterPath);
            var components = new List<ComponentFile>();

            var allComponents = master.From<ComponentFile>().Read().ToArray();

            foreach (ComponentFile comp in allComponents)
            {
                comp.FullPath = System.IO.Path.Combine(searchDir, comp.FileName);

                if (MergeComponentsPresenter.InitializeComponent(comp))//try to initialize component, if initialization fails add to missing file list
                {
                    components.Add(comp);
                }
                else
                {
                    Output.WriteLine($"Component Not Found: {comp.FullPath}");
                }
            }

            return (master, components);


        }
    }
}