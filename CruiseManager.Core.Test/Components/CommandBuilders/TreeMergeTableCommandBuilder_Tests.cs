using CruiseDAL;
using CruiseManager.Core.Components.CommandBuilders;
using CruiseManager.Test;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components.CommandBuilders
{
    public class TreeMergeTableCommandBuilder_Tests : TestBase
    {
        public TreeMergeTableCommandBuilder_Tests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void MakeMergeTableCommand()
        {
            using (var database = new DAL())
            {
                var commandBuilder = new TreeMergeTableCommandBuilder(database);

                var commandText = commandBuilder.MakeMergeTableCommand;

                Output.WriteLine(commandText);
                database.Invoking(x => x.Execute(commandText)).Should().NotThrow();
            }
        }
    }
}
