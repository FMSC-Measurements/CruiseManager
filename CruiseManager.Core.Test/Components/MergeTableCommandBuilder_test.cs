using CruiseDAL;
using CruiseManager.Core.Components;
using FluentAssertions;
using System.IO;
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
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void MakeMergeTableCommand(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var commandText = commandBuilder.MakeMergeTableCommand;

                Output.WriteLine(commandText);
                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void SelectNaturalMatches(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectNaturalMatches;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void SelectRowIDMatches(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectRowIDMatches;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void SelectGUIDMatches(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectGUIDMatches;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void SelectInValidMatches(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectInvalidMatchs;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void SelectSiblingRecords(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectSiblingRecords;

                database.Execute(commandText);
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void SelectMasterRowVersion(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectMasterRowVersion;

                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void SelectFullMatches(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.SelectFullMatches;

                database.Execute(commandText);
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void GetPopulateMergeTableCommand(string tableName)
        {
            var workingDir = Path.Combine(TestTempPath, tableName);
            TouchDir(workingDir);

            var masterPath = Path.Combine(workingDir, "TEST_POPULATE_MERGE_TABLE.M.cruise");
            var componentPath = Path.Combine(workingDir, "TEST_POPULATE_MERGE_TABLE.1.cruise");

            CleanUpFile(masterPath);
            CleanUpFile(componentPath);

            using (var masterDatabase = new DAL(masterPath, true))
            using (var componentDatabase = new DAL(componentPath, true))
            {
                var commandBuilder = new MergeTableCommandBuilder(masterDatabase, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                masterDatabase.Execute(makeMergeTableCommand);

                masterDatabase.AttachDB(componentDatabase, "compDB");

                var commandText = commandBuilder.GetPopulateMergeTableCommand(1);

                masterDatabase.Execute(commandText);
            }
        }

        [Theory]
        [InlineData("Tree")]
        [InlineData("Plot")]
        [InlineData("Log")]
        [InlineData("Stem")]
        public void GetPopulateDeletedRecordsCommand(string tableName)
        {
            using (var database = new DAL())
            {
                var commandBuilder = new MergeTableCommandBuilder(database, tableName);

                var makeMergeTableCommand = commandBuilder.MakeMergeTableCommand;
                database.Execute(makeMergeTableCommand);

                var commandText = commandBuilder.GetPopulateDeletedRecordsCommand(1);

                database.Execute(commandText);
            }
        }
    }
}