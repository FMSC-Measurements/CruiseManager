using CruiseManager.Core.Components;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;

namespace CruiseManager.Test.Components
{
    public class TestMergeLogWriter : IMergeLog
    {
        public ITestOutputHelper Output { get; set; }

        public TestMergeLogWriter(ITestOutputHelper output)
        {
            Output = output;
        }

        public void PostStatus(string message, [CallerMemberName] string method = null)
        {
            Output.WriteLine($"method: {method}, {message} ");
        }
    }
}