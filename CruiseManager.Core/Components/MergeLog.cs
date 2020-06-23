using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components
{
    public class MergeLog : IMergeLog
    {
        public static SynchronizationContext DefaultContext = new SynchronizationContext();
        List<string> _logEntries = new List<string>();
        SynchronizationContext _syncContext;


        public MergeLog()
        {
            _syncContext = SynchronizationContext.Current ?? DefaultContext;
        }

        public IEnumerable<string> Entries => _logEntries;

        public event EventHandler<string> LogChanged;

        public void PostStatus(string message, [CallerMemberName] string method = null)
        {
            _logEntries.Add(message);
            var changedEvent = LogChanged;
            if(changedEvent != null)
            {
                _syncContext.Post(InvokeLogChanged, message);
            }
        }

        private void InvokeLogChanged(object state)
        {
            var message = (string)state;
            LogChanged?.Invoke(this, message);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var i in Entries)
            {
                sb.AppendLine(i);
            }
            return sb.ToString();
        }

        public byte[] ToBytes()
        {
            var text = ToString();
            return Encoding.ASCII.GetBytes(text);
        }

        public ErrorAttachmentLog ToErrorAttachmentLog()
        {
            var bytes = ToBytes();
            return new ErrorAttachmentLog()
            {
                ContentType = "text/plain",
                Data = bytes,
            };
        }

    }
}
