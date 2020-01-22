﻿using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;
using System;

namespace CruiseManager.Core.Components
{
    public class ComponentFileVM : ComponentDO
    {
        //public String FileName { get; set; }
        [IgnoreField]
        public String FullPath { get; set; }

        [IgnoreField]
        public DAL Database { get; set; }

        [IgnoreField]
        public String DBAlias { get; set; }

        //public int Edits { get; set; }
        //public string LastMod { get; set; }
        //public int Warnings { get; set; }
        [IgnoreField]
        public string Errors { get; set; }

        [IgnoreField]
        public long? TreeCount
        {
            get
            {
                if (_treeCount == null && this.Database != null)
                {
                    _treeCount = this.Database.GetRowCount("Tree", null);
                }
                return _treeCount;
            }
        }

        [IgnoreField]
        public long? LogCount
        {
            get
            {
                if (_logCount == null && this.Database != null)
                {
                    _logCount = this.Database.GetRowCount("Log", null);
                }
                return _logCount;
            }
        }

        [IgnoreField]
        public long? PlotCount
        {
            get
            {
                if (_plotCount == null && this.Database != null)
                {
                    _plotCount = this.Database.GetRowCount("Plot", null);
                }
                return _plotCount;
            }
        }

        [IgnoreField]
        public long? StemCount
        {
            get
            {
                if (_stemCount == null && this.Database != null)
                {
                    _stemCount = this.Database.GetRowCount("Stem", null);
                }
                return _stemCount;
            }
        }

        public void ResetCounts()
        {
            _treeCount = null;
            _logCount = null;
            _stemCount = null;
            _plotCount = null;
        }

        private long? _treeCount;
        private long? _logCount;
        private long? _stemCount;
        private long? _plotCount;
    }
}