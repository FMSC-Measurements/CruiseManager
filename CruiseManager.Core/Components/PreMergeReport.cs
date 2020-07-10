using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseManager.Core.Components
{
    public class PreMergeTableReport
    {
        public string TableName { get; set; }

        public IEnumerable<MergeObject> Conflicts { get; set; }

        public IEnumerable<MergeObject> RecordIDConflict { get; set; }

        public IEnumerable<MergeObject> PartialMatch { get; set; }

        public IEnumerable<MergeObject> Matches { get; set; }

        public IEnumerable<MergeObject> Additions { get; set; }
    }
}
