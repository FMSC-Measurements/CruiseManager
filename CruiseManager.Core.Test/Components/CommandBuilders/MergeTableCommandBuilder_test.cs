using CruiseDAL;
using CruiseManager.Core.Components;
using CruiseManager.Core.Components.CommandBuilders;
using CruiseManager.Test;
using FluentAssertions;
using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components
{
    public class MergeTableCommandBuilder_test : TestBase
    {
        public MergeTableCommandBuilder_test(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void SelectNaturalMatches(Type type)
        {
            using (var database = new DAL())
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { database });


                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectNaturalMatches;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void SelectRowIDMatches(Type type)
        {
            using (var database = new DAL())
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { database });

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectRowIDMatches;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void SelectGUIDMatches(Type type)
        {
            using (var database = new DAL())
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { database });

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectGUIDMatches;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void SelectInValidMatches(Type type)
        {
            using (var database = new DAL())
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { database });

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectInvalidMatchs;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void SelectSiblingRecords(Type type)
        {
            using (var database = new DAL())
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { database });

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectSiblingRecords;

                database.Execute(commandText);
            }
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void SelectMasterRowVersion(Type type)
        {
            using (var database = new DAL())
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { database });

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectMasterRowVersion;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void SelectFullMatches(Type type)
        {
            using (var database = new DAL())
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { database });

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectFullMatches;

                database.Execute(commandText);
            }
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void GetPopulateMergeTableCommand(Type type)
        {
            var workingDir = Path.Combine(TestTempPath, type.Name);
            TouchDir(workingDir);

            var masterPath = Path.Combine(workingDir, "TEST_POPULATE_MERGE_TABLE.M.cruise");
            var componentPath = Path.Combine(workingDir, "TEST_POPULATE_MERGE_TABLE.1.cruise");

            CleanUpFile(masterPath);
            CleanUpFile(componentPath);

            using (var masterDatabase = new DAL(masterPath, true))
            using (var componentDatabase = new DAL(componentPath, true))
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { masterDatabase });

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                masterDatabase.Execute(makeMergeTableCommand);

                masterDatabase.AttachDB(componentDatabase, MergeTableCommandBuilder.COMP_ALIAS);

                var commandText = commandBuilder.GetPopulateMergeTableCommand(1);

                masterDatabase.Execute(commandText);
            }
        }

        [Theory]
        [InlineData(typeof(TreeMergeTableCommandBuilder))]
        [InlineData(typeof(PlotMergeTableCommandBuilder))]
        [InlineData(typeof(LogMergeTableCommandBuilder))]
        [InlineData(typeof(StemMergeTableCommandBuilder))]
        public void GetPopulateDeletedRecordsCommand(Type type)
        {
            using (var database = new DAL())
            {
                var commandBuilder = (MergeTableCommandBuilder)type.GetConstructors()
                    .Where(x => x.GetParameters().Length == 1)
                    .Single().Invoke(new[] { database });

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.GetPopulateDeletedRecordsCommand(1);

                database.Execute(commandText);
            }
        }
    }
}