using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.Core.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CruiseManager.Core.Components
{
    public class MergeTableCommandBuilder
    {
        public MergeTableCommandBuilder(DAL masterDB, String clientTableName)
        {
            this.ClientTableName = clientTableName;
            this.MergeTableName = "Merge" + this.ClientTableName;

            this.AllClientColumns = masterDB.GetTableInfo(clientTableName).ToList();

            this.ClientGUIDKeyField = (from ColumnInfo ci in this.AllClientColumns
                                       where ci.Name == this.ClientTableName + "_GUID"
                                       select ci).FirstOrDefault();

            this.ClientPrimaryKey = (from ColumnInfo ci in this.AllClientColumns
                                     where ci.IsPK == true
                                     select ci).FirstOrDefault() ?? new ColumnInfo() { Name = "RowID" };

            this.HasRowVersion = this.AllClientColumns.Find(x => x.Name == "RowVersion") != null;

            this.ClientUniqueFieldNames = masterDB.GetTableUniques(clientTableName).ToArray();
            InitializeCommonColumns(this.HasGUIDKey, this.HasRowVersion);
        }

        private void InitializeCommonColumns(bool hasGuidKey, bool hasRowVersion)
        {
            List<ColumnInfo> cList = new List<ColumnInfo>();
            cList.Add(new ColumnInfo() { Name = "MergeRowID", DBType = "INTEGER", IsPK = true });
            cList.Add(new ColumnInfo() { Name = "ComponentRowID", DBType = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "ComponentID", DBType = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "NaturalMatch", DBType = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "RowIDMatch", DBType = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "GUIDMatch", DBType = "INTEGER" });

            cList.Add(new ColumnInfo() { Name = "MatchRowID", DBType = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "PartialMatch", DBType = "TEXT" });

            //cList.Add(new ColumnInfo() { Name = "ComponentConflict", DBType = "TEXT" });
            //cList.Add(new ColumnInfo() { Name = "MatchConflict", DBType = "TEXT" });
            cList.Add(new ColumnInfo() { Name = "NaturalSiblings", DBType = "TEXT" });
            cList.Add(new ColumnInfo() { Name = "SiblingRecords", DBType = "TEXT" });

            //cList.Add(new ColumnInfo() { Name = "MasterConflict", DBType = "TEXT" });
            cList.Add(new ColumnInfo() { Name = "IsDeleted", DBType = "BOOL", Default = "0" });

            //cList.Add(new ColumnInfo() { Name = "MasterRowID", DBType = "INTEGER" });

            cList.Add(new ColumnInfo() { Name = "CompoundNaturalKey", DBType = "TEXT" });

            if (hasGuidKey)
            {
                cList.Add(new ColumnInfo() { Name = "ComponentRowGUID", DBType = "TEXT" });
            }

            if (hasRowVersion)
            {
                cList.Add(new ColumnInfo() { Name = "ComponentRowVersion", DBType = "INTEGER" });
                cList.Add(new ColumnInfo() { Name = "MasterRowVersion", DBType = "INTEGER" });
            }
            this.CommonMergeTableColumns = cList;
        }

        private List<ColumnInfo> AllClientColumns { get; set; }

        public string[] ClientUniqueFieldNames { get; set; }

        private List<ColumnInfo> CommonMergeTableColumns { get; set; }

        private string[] ClientFieldNames
        {
            get
            {
                return (from ColumnInfo ci in this.AllClientColumns
                        where ci.IsPK || this.ClientUniqueFieldNames.Contains(ci.Name)
                        select ci.Name).ToArray();
            }
        }

        private string NaturalJoinCondition
        {
            get
            {
                switch (this.ClientTableName)
                {
                    case "Tree":
                        {
                            return TREE_UNIQUE_JOIN_COMMAND;
                        }
                    case "Log":
                        {
                            return LOG_UNIQUE_JOIN_COMMAND;
                        }
                    case "Stem":
                        {
                            return STEM_UNIQUE_JOIN_COMMAND;
                        }
                    case "Plot":
                        {
                            return PLOT_UNIQUE_JOIN_COMMAND;
                        }
                    case "TreeEstimate":
                        {
                            return TREEESTIMATE_UNIQUE_JOIN_CLAUSE;
                        }
                }
                return string.Empty;
            }
        }

        private ColumnInfo ClientGUIDKeyField { get; set; }
        public ColumnInfo ClientPrimaryKey { get; private set; }

        public string ClientGUIDFieldName
        {
            get
            {
                if (this.ClientGUIDKeyField != null)
                {
                    return this.ClientGUIDKeyField.Name;
                }
                return String.Empty;
            }
        }

        public string ClientTableName { get; private set; }
        public string MergeTableName { get; private set; }

        public bool DoNaturalMatch { get; set; }
        public bool DoKeyMatch { get; set; }

        public bool DoGUIDMatch
        {
            get { return _doGuidMatch && this.HasGUIDKey; }
            set { _doGuidMatch = value; }
        }

        public bool HasGUIDKey
        {
            get { return this.ClientGUIDKeyField != null; }
        }

        public bool HasRowVersion { get; set; }

        public bool RecordsUniqueAccrossComponents { get; set; }
        public bool MergeNewFromComponent { get; set; }
        public bool MergeNewFromMaster { get; set; }
        public bool MergeChangesFromComponent { get; set; }
        public bool MergeChangesFromMaster { get; set; }
        public bool MergeDeletionsFromComponent { get; set; }

        //public List<ColumnInfo> ForeignKeys { get; private set; }

        public string GetCompoundNaturalKeyExpression(String sqlSourceName)
        {
            string formatEpr;
            switch (this.ClientTableName)
            {
                case "Tree":
                    {
                        formatEpr = TREE_COMPOUND_NATURAL_KEY_EXPRESSION;
                        break;
                    }
                case "Log":
                    {
                        formatEpr = LOG_COMPOUND_NATURAL_KEY_EXPRESSION;
                        break;
                    }
                case "Stem":
                    {
                        formatEpr = STEM_NATURAL_KEY_EXPRESSION;
                        break;
                    }
                case "Plot":
                    {
                        formatEpr = PLOT_COMPOUND_NATURAL_KEY_EXPRESSION;
                        break;
                    }
                default:
                    { formatEpr = string.Empty; break; }
            }
            if (!string.IsNullOrEmpty(sqlSourceName))
            {
                sqlSourceName = sqlSourceName + ".";
            }

            return string.Format(formatEpr, sqlSourceName);
        }

        public string MakeMergeTableCommand
        {
            get
            {
                //build array of column definitions for our merge table
                String[] columnDefs = (from ColumnInfo ci in this.AllClientColumns
                                       where ci.IsPK || this.ClientUniqueFieldNames.Contains(ci.Name)
                                       select ci.GetColumnDef(false)).Union(
                                           from ColumnInfo ci in CommonMergeTableColumns
                                           select ci.GetColumnDef(true)).ToArray();

                string mkTbl = "CREATE TABLE " + this.MergeTableName + "\r\n"
                    + " (" + String.Join(",\r\n", columnDefs) + ");";
                return mkTbl;
            }
        }

        //public string SelectNaturalAndCNMatches
        //{
        //    get
        //    {
        //        String whereClause = "WHERE rgt." + this.ClientCNFieldName + " = lft.ComponentRowID";
        //        if (_hasGuidKey)
        //        {
        //            whereClause += " AND rgt." + this.ClientGUIDFieldName + " IS NULL";
        //        }

        //        //match existing records where master doesn't have GUID key, but CN and Natural keys match
        //        return
        //            @"SELECT lft.RowID AS MergeRowID, rgt.RowID AS MasterRowID, rgt.RowVersion AS MasterRowVersion " +
        //            @"FROM " + this.MergeTableName + " AS lft " +
        //            @"INNER JOIN main." + this.ClientTableName + " AS rgt " +
        //            this.NaturalJoinCondition + whereClause + ";";
        //    }
        //}

        public string SelectNaturalMatches
        {
            get
            {
                return
                    "SELECT mrg.MergeRowID, client.RowID AS NaturalMatch " +
                    "FROM " + this.MergeTableName + " AS mrg " +
                    "INNER JOIN main." + this.ClientTableName + " AS client " +
                    " ON ( mrg.CompoundNaturalKey = (" + GetCompoundNaturalKeyExpression("client") + ")) " +
                    "WHERE mrg.ComponentRowID IS NOT NULL;";
            }
        }

        public string SelectRowIDMatches
        {
            get
            {
                return
                    "SELECT lft.MergeRowID, rgt.RowID AS RowIDMatch " +
                    "FROM " + this.MergeTableName + " AS lft " +
                    "INNER JOIN main." + this.ClientTableName + " AS rgt " +
                    "ON (lft.ComponentRowID = rgt." + this.ClientPrimaryKey.Name + ");";
            }
        }

        public string SelectGUIDMatches
        {
            get
            {
                return
                @"SELECT lft.MergeRowID, rgt.RowID AS GUIDMatch " +
                @"FROM " + this.MergeTableName + " AS lft " +
                @"INNER JOIN main." + this.ClientTableName + " AS rgt " +
                @"ON rgt." + this.ClientGUIDFieldName + " = lft.ComponentRowGUID;";
            }
        }

        public string NaturalCrossComponentConflictsCommand
        {
            get
            {
                //find records using across components that conflict on natural key
                return
                @"SELECT lft.MergeRowID, group_concat( rgt.ComponentRowID || ' in ' || rgt.ComponentID, ', ') AS ComponentConflict " +
                @"FROM " + this.MergeTableName + " AS lft " +
                @"INNER JOIN " + this.MergeTableName + " AS rgt " +
                this.NaturalJoinCondition +
                @"WHERE lft.MergeRowID != rgt.MergeRowID " +
                "GROUP BY lft.MergeRowID;";
            }
        }

        public string SelectInvalidMatchs
        {
            get
            {
                return "SELECT MergeRowID FROM " + this.MergeTableName +
                this.FindInvalidMatchs;
            }
        }

        public string SelectSiblingRecords
        {
            get
            {
                return
                    "SELECT PartialMatch, SiblingRecords FROM (" +
                " SELECT PartialMatch, group_concat(ComponentRowID || ' in ' || ComponentID, ', ') AS SiblingRecords, count(1) as size" +
                " FROM " + this.MergeTableName +
                " WHERE PartialMatch IS NOT NULL" +
                " GROUP BY PartialMatch)" +
                " WHERE size > 1;";
            }
        }

        public string SelectMissingMatches(ComponentFileVM comp)
        {
            return
                "SELECT client." + this.ClientPrimaryKey.Name + " AS MatchRowID FROM " + this.ClientTableName + " AS client " +
                "LEFT JOIN " + this.MergeTableName + " AS mrg " +
                "ON (client." + this.ClientPrimaryKey.Name + " = mrg.MatchRowID AND ComponentID = " + comp.Component_CN.ToString() + ") " +
                "WHERE mrg.MatchRowID IS NULL;";
        }

        public string SelectMasterRowVersion
        {
            get
            {
                return
                "SELECT client.RowID AS MasterRowID, client.RowVersion AS MasterRowVersion " +
                "FROM " + this.ClientTableName + " AS client;";
            }
        }

        //public string MasterConflicts
        //{
        //    get
        //    {
        //        //find component records that conflict with natural key
        //        return
        //        @"SELECT lft.RowID AS MergeRowID, rgt.RowID AS MasterConflict " +
        //        @"FROM " + this.MergeTableName + " AS lft " +
        //        @"INNER JOIN main." + this.ClientTableName + " AS rgt " +
        //        this.NaturalJoinCondition +
        //        @"WHERE (rgt." + this.ClientGUIDFieldName + " IS NOT NULL " +
        //        @"AND lft.ComponentRowGUID != rgt." + this.ClientGUIDFieldName + ") " +
        //        @"OR (lft.ComponentRowID != rgt." + this.ClientCNFieldName + ");";
        //    }
        //}

        //public string MissingRecords
        //{
        //    get
        //    {
        //        return
        //        @"SELECT NULL AS MergeRowID, lft." + this.ClientCNFieldName + " AS MasterRowID FROM " + this.ClientTableName + " AS lft " +
        //        @"LEFT JOIN " + this.MergeTableName + " AS rgt " +
        //        this.NaturalJoinCondition +
        //        @"WHERE rgt.RowID IS NULL OR (lft." + this.ClientGUIDFieldName + " NOT NULL AND rgt.ComponentRowGUID != lft." + this.ClientGUIDFieldName + ");";
        //    }
        //}

        private string FindInvalidMatchs
        {
            get
            {
                //Conflicts will exist only if two comparison methods are selected
                //in the case of guid matching guid match

                List<string> conditions = new List<string>(3);

                if (this.DoGUIDMatch && this.DoNaturalMatch)
                {
                    conditions.Add("((GuidMatch IS NOT NULL AND NaturalMatch IS NOT NULL) AND NaturalMatch != GUIDMatch)");
                }
                if (this.DoGUIDMatch && this.DoKeyMatch)
                {
                    conditions.Add("((GuidMatch IS NOT NULL AND RowIDMatch IS NOT NULL) AND RowIDMatch != GUIDMatch)");
                }
                if (this.DoNaturalMatch && this.DoKeyMatch)
                {
                    conditions.Add("((NaturalMatch IS NOT NULL AND RowIDMatch IS NOT NULL) AND NaturalMatch != RowIDMatch)");
                }

                if (conditions.Count == 0)
                {
                    return " ";
                }
                else
                {
                    return " WHERE " + string.Join(" OR ", conditions.ToArray());
                }
            }
        }

        public String FindConflictsFilter
        {
            get
            {
                string filter = " WHERE (MatchRowID IS NULL AND PartialMatch IS NOT NULL)";
                //"ComponentConflict IS NOT NULL " +
                //"MatchConflict IS NOT NULL ";
                if (this.RecordsUniqueAccrossComponents)
                {
                    filter += " OR SiblingRecords IS NOT NULL " +
                    "OR NaturalSiblings IS NOT NULL ";
                }
                return filter;
            }
        }

        public string FindNewRecords
        {
            get
            {
                return " WHERE ComponentRowID IS NOT NULL " +
                "AND NaturalMatch IS NULL " +
                "AND GUIDMatch IS NULL " +
                "AND RowIDMatch IS NULL " +
                "AND MatchRowID IS NULL " +
                "AND (IsDeleted IS NULL OR IsDeleted = 0) ";
            }
        }

        public string FindMasterToCompUpdates
        {
            get
            {
                return " WHERE MasterRowVersion > ComponentRowVersion AND "
                + this.FindMatchesBase;
            }
        }

        public string FindCompToMasterUpdates
        {
            get
            {
                return " WHERE ComponentRowVersion >= MasterRowVersion AND "
                    + this.FindMatchesBase;
            }
        }

        public string FindMatchesBase
        {
            get
            {
                string filter = " MatchRowID IS NOT NULL" +
                    " AND ComponentRowID IS NOT NULL " +
                    " AND ifnull(IsDeleted, 0) = 0";
                if (this.RecordsUniqueAccrossComponents)
                {
                    filter += " AND SiblingRecords IS NULL" +
                        " AND NaturalSiblings IS NULL";
                }

                return filter;
            }
        }

        public string SelectFullMatches
        {
            get
            {
                return "Select NaturalMatch, RowIDMatch, GUIDMatch, MergeRowID FROM " +
                this.MergeTableName +
                this.FindFullMatches + ";";
            }
        }

        private string FindFullMatches
        {
            get
            {
                string condition;
                List<string> conditions = new List<string>(3);

                //if (this.DoGUIDMatch)
                //{
                //    conditions.Add("GUIDMatch IS NOT NULL");
                //}
                if (DoGUIDMatch)
                {
                    condition = " WHERE GUIDMatch IS NOT Null OR RowIDMatch = NaturalMatch";
                }
                else
                {
                    condition = " WHERE (RowIDMatch IS NOT NULL AND RowIDMatch = NaturalMatch)";
                }

                return condition;

                //if (this.DoKeyMatch)
                //{
                //    conditions.Add("RowIDMatch IS NOT NULL");
                //}
                //if (this.DoNaturalMatch)
                //{
                //    conditions.Add("NaturalMatch IS NOT NULL");
                //}
                //if (this.DoGUIDMatch && this.DoNaturalMatch)
                //{
                //    conditions.Add("(GUIDMatch IS NULL OR GUIDMatch = NaturalMatch)");
                //}
                //if (this.DoGUIDMatch && this.DoKeyMatch)
                //{
                //    conditions.Add("(GUIDMatch IS NULL OR RowIDMatch = GUIDMatch)");
                //}
                //if (this.DoNaturalMatch && this.DoKeyMatch)
                //{
                //    conditions.Add("NaturalMatch = RowIDMatch");
                //}

                //return " WHERE " + string.Join(" AND ", conditions.ToArray());
            }
        }

        public string FindMatched
        {
            get
            {
                return " WHERE MatchRowID IS NOT NULL " +
                    "AND MatchConflict IS NULL " +
                    "AND ComponentConflict IS NULL " +
                    "AND ifnull(IsDeleted, 0) = 0 ";
            }
        }

        public String GetPopulateMergeTableCommand(ComponentFileVM component)
        {
            string clientFieldList = string.Empty;
            if (this.ClientFieldNames.Length > 0)
            {
                clientFieldList = ", " + String.Join(", ", this.ClientFieldNames);
            }

            String populateMergetableCMD = String.Format(
                "INSERT INTO {0} " +
                "(ComponentRowID{1}, ComponentID{2}{3}, CompoundNaturalKey) " +
                "SELECT {4}{5}" +
                ", {6} AS ComponentID{7}{3}, {9} " +
                "FROM compDB.{8} as compSource;",
                this.MergeTableName,
                (this.HasGUIDKey) ? ", ComponentRowGUID" : String.Empty,
                (this.HasRowVersion) ? ", ComponentRowVersion" : String.Empty,
                clientFieldList,
                this.ClientPrimaryKey.Name,
                (this.HasGUIDKey) ? ", " + this.ClientGUIDFieldName : String.Empty,
                component.Component_CN.ToString(),
                (this.HasRowVersion) ? ", RowVersion AS ComponentRowVersion" : String.Empty,
                this.ClientTableName,
                this.GetCompoundNaturalKeyExpression("compSource"));

            return populateMergetableCMD;
        }

        public String GetPopulateDeletedRecordsCommand(ComponentFileVM component)
        {
            String populateDeletedRecordsCMD = String.Format(
                "INSERT INTO {0} "
                 + "(ComponentRowID{1}, IsDeleted, ComponentID) "
                 + "SELECT RecordID{2}, 1 AS IsDeleted, {3} AS ComponentID FROM Util_Tombstone WHERE TableName = '{4}';",
                this.MergeTableName,
                (this.HasGUIDKey) ? ", ComponentRowGUID" : String.Empty,
                (this.HasGUIDKey) ? ", RecordGUID" : String.Empty,
                component.Component_CN,
                this.ClientTableName);

            return populateDeletedRecordsCMD;
        }

        public List<MergeObject> ListNewRecords(DAL master, ComponentFileVM comp)
        {
            string selectNewRecordsCommand =
                "SELECT * FROM " + this.MergeTableName +
                this.FindNewRecords +
                " AND ComponentID = ?;";
            return master.Query<MergeObject>(selectNewRecordsCommand, comp.Component_CN);
        }

        public List<MergeObject> ListComponentUpdates(DAL master, ComponentFileVM comp)
        {
            string selectPullRecordsCommand = "SELECT * FROM " + this.MergeTableName +
                this.FindMasterToCompUpdates +
                " AND ComponentID = ?;";

            return master.Query<MergeObject>(selectPullRecordsCommand, comp.Component_CN);
        }

        public List<MergeObject> ListMasterUpdates(DAL master, ComponentFileVM comp)
        {
            string selectPullRecordsCommand = "SELECT * FROM " + this.MergeTableName +
                this.FindCompToMasterUpdates +
                " AND ComponentID = ?;";

            return master.Query<MergeObject>(selectPullRecordsCommand, comp.Component_CN);
        }

        public DataObject ReadSingleRow(DAL source, long rowid)
        {
            switch (this.ClientTableName)
            {
                case "Tree":
                    {
                        return source.From<TreeDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "Log":
                    {
                        return source.From<LogDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "Stem":
                    {
                        return source.From<StemDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "Plot":
                    {
                        return source.From<PlotDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "CountTree":
                    {
                        return source.From<CountTreeDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "CuttingUnit":
                    {
                        return source.From<CuttingUnitDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "Stratum":
                    {
                        return source.From<StratumDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "CuttingUnitStratum":
                    {
                        return source.From<CuttingUnitStratumDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "SampleGroup":
                    {
                        return source.From<SampleGroupDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "SampleGroupTreeDefaultValue":
                    {
                        return source.From<SampleGroupTreeDefaultValueDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                case "TreeDefaultValue":
                    {
                        return source.From<TreeDefaultValueDO>().Where("rowid = ?").Query(rowid).FirstOrDefault();
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public long GetMatchRowID(MergeObject mRec)
        {
            if (this._doGuidMatch && mRec.GUIDMatch != null)
            {
                return mRec.GUIDMatch.Value;
            }
            if (this.DoNaturalMatch && mRec.NaturalMatch != null)
            {
                return mRec.NaturalMatch.Value;
            }
            else
            {
                return mRec.RowIDMatch.GetValueOrDefault(0);
            }
        }

        #region table join commands

        protected const string TREE_UNIQUE_JOIN_COMMAND =
            @"ON (lft.CuttingUnit_CN = rgt.CuttingUnit_CN " +
            @"AND lft.Stratum_CN = rgt.Stratum_CN " +
            @"AND ifnull(lft.Plot_CN, 0) = ifnull(rgt.Plot_CN,0) " +
            @"AND lft.TreeNumber = rgt.TreeNumber) ";

        protected const string LOG_UNIQUE_JOIN_COMMAND =
            @"USING (Tree_CN, LogNumber) ";

        protected const string STEM_UNIQUE_JOIN_COMMAND =
            @"USING (Tree_CN, Stem_CN) ";

        protected const string PLOT_UNIQUE_JOIN_COMMAND =
            @"USING (Stratum_CN, CuttingUnit_CN, PlotNumber) ";

        protected const string TREEESTIMATE_UNIQUE_JOIN_CLAUSE =
            @"USING (TreeEstimate_CN) ";

        protected const string TREE_COMPOUND_NATURAL_KEY_EXPRESSION =
            @"quote({0}CuttingUnit_CN) || ',' || quote({0}Stratum_CN) || ',' || quote({0}SampleGroup_CN) || ',' || quote({0}Plot_CN) || ',' || quote({0}TreeNumber)";

        protected const string LOG_COMPOUND_NATURAL_KEY_EXPRESSION =
            @"quote({0}Tree_CN) || ',' || quote({0}LogNumber)";

        protected const string STEM_NATURAL_KEY_EXPRESSION =
            @"quote({0}Tree_CN) || ',' || quote({0}Stem_CN)";

        protected const string PLOT_COMPOUND_NATURAL_KEY_EXPRESSION =
            @"quote({0}Stratum_CN) || ',' || quote({0}CuttingUnit_CN) || ',' || quote({0}PlotNumber)";

        #endregion table join commands

        private bool _doGuidMatch;
    }
}