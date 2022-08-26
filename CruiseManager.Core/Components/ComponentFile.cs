using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;
using System;

namespace CruiseManager.Core.Components
{
    [Table("Component")]
    public class ComponentFile
    {
        [Field]
        public long? Component_CN { get; set; }

        [Field]
        public virtual string FileName { get; set; }

        [IgnoreField]
        public String FullPath { get; set; }

        [IgnoreField]
        public DAL Database { get; set; }

        [IgnoreField]
        public string Errors { get; set; }

        [IgnoreField]
        public long? TreeCount { get; set; }

        [IgnoreField]
        public long? LogCount { get; set; }

        [IgnoreField]
        public long? PlotCount { get; set; }

        [IgnoreField]
        public long? StemCount { get; set; }

        [IgnoreField]
        public Exception MergeException { get; set; }
    }
}