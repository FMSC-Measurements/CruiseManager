using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CruiseManager.Core.Components
{
    public interface IMergeLog
    {
        void PostStatus(string message, [CallerMemberName] string method = null);
    }

    public static class IMergeLogExtentions
    {
        public static void StartJob(this IMergeLog @this, [CallerMemberName] string name = "")
        {
            //if (_stopwatch != null) { _stopwatch.Stop(); }
            //_stopwatch = Stopwatch.StartNew();
            @this.PostStatus("Starting" + name);
            Debug.WriteLine("Started job component " + name);
        }

        public static void EndJob(this IMergeLog @this, [CallerMemberName] string name = "")
        {
            //if (_stopwatch != null)
            //{
            //    _stopwatch.Stop();
            //    Debug.WriteLine("Ended job component " + _currentJobName + " in " + _stopwatch.ElapsedMilliseconds + "mSec");
            //}
            @this.PostStatus(name + ": done");
        }

        
    }
}