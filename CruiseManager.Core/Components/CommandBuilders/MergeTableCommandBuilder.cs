using Backpack.SqlBuilder;
using Backpack.SqlBuilder.Sqlite;
using CruiseDAL;
using CruiseDAL.DataObjects;
using CruiseManager.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseManager.Core.Components
{
    public abstract class MergeTableCommandBuilder
    {
        public const string COMP_ALIAS = "comp";

        public MergeTableCommandBuilder(String clientTableName)
        {
            this.ClientTableName = clientTableName;
            this.MergeTableName = "Merge" + this.ClientTableName;
        }

        public MergeTableCommandBuilder(DAL masterDB, String clientTableName)
        {
            this.ClientTableName = clientTableName;
            this.MergeTableName = "Merge" + this.ClientTableName;

            Initialize(masterDB);
        }

        protected void Initialize(DAL master)
        {
            var targetTableName = ClientTableName;

            var allClientColumns = AllClientColumns = master.GetTableInfo(targetTableName).ToList();
            ClientUniqueFieldNames = master.GetTableUniques(targetTableName).ToArray();

            ClientGUIDKeyField = allClientColumns.Where(ci => ci.Name == this.ClientTableName + "_GUID")
                .FirstOrDefault();

            ClientPrimaryKey = allClientColumns.Where(ci => ci.IsPK == true).FirstOrDefault() ?? new ColumnInfo() { Name = "RowID" };

            var hasRowVersion = HasRowVersion = allClientColumns.Any(x => x.Name == "RowVersion");

            InitializeCommonColumns(HasGUIDKey, HasRowVersion);

            
        }

        void InitializeCommonColumns(bool hasGuidKey, bool hasRowVersion)
        {
            List<ColumnInfo> cList = new List<ColumnInfo>();
            cList.Add(new ColumnInfo() { Name = "MergeRowID", Type = "INTEGER", IsPK = true });
            cList.Add(new ColumnInfo() { Name = "ComponentRowID", Type = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "ComponentID", Type = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "NaturalMatch", Type = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "RowIDMatch", Type = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "GUIDMatch", Type = "INTEGER" });

            cList.Add(new ColumnInfo() { Name = "MatchRowID", Type = "INTEGER" });
            cList.Add(new ColumnInfo() { Name = "PartialMatch", Type = "TEXT" });

            //cList.Add(new ColumnInfo() { Name = "ComponentConflict", Type = "TEXT" });
            //cList.Add(new ColumnInfo() { Name = "MatchConflict", Type = "TEXT" });
            cList.Add(new ColumnInfo() { Name = "NaturalSiblings", Type = "TEXT" });
            cList.Add(new ColumnInfo() { Name = "SiblingRecords", Type = "TEXT" });

            //cList.Add(new ColumnInfo() { Name = "MasterConflict", Type = "TEXT" });
            cList.Add(new ColumnInfo() { Name = "IsDeleted", Type = "BOOL", Default = "0" });

            //cList.Add(new ColumnInfo() { Name = "MasterRowID", Type = "INTEGER" });

            cList.Add(new ColumnInfo() { Name = "CompoundNaturalKey", Type = "TEXT" });

            if (hasGuidKey)
            {
                cList.Add(new ColumnInfo() { Name = "ComponentRowGUID", Type = "TEXT" });
            }

            if (hasRowVersion)
            {
                cList.Add(new ColumnInfo() { Name = "ComponentRowVersion", Type = "INTEGER" });
                cList.Add(new ColumnInfo() { Name = "MasterRowVersion", Type = "INTEGER" });
            }
            this.CommonMergeTableColumns = cList;
        }

        protected abstract string NaturalJoinCondition { get; }

        public string ClientTableName { get; }
        public string MergeTableName { get; }

        public IEnumerable<ColumnInfo> AllClientColumns { get; protected set; }
        public IEnumerable<string> ClientUniqueFieldNames { get; protected set; }
        public IEnumerable<ColumnInfo> CommonMergeTableColumns { get; protected set; }
        public ColumnInfo ClientGUIDKeyField { get; protected set; }
        public ColumnInfo ClientPrimaryKey { get; protected set; }

        private IEnumerable<String> ClientFieldNames => AllClientColumns
            .Where(x => x.IsPK || ClientUniqueFieldNames.Contains(x.Name))
            .Select(x => x.Name).ToArray();

        public string ClientGUIDFieldName => ClientGUIDKeyField?.Name ?? String.Empty;


        public bool DoNaturalMatch { get; set; }
        public bool DoKeyMatch { get; set; }

        private bool _doGuidMatch;

        public bool DoGUIDMatch
        {
            get => _doGuidMatch && HasGUIDKey;
            set => _doGuidMatch = value;
        }

        public bool HasGUIDKey => ClientGUIDKeyField != null;
        public bool HasRowVersion { get; protected set; }

        public bool RecordsUniqueAccrossComponents { get; set; }
        public bool MergeNewFromComponent { get; set; }
        public bool MergeNewFromMaster { get; set; }
        public bool MergeChangesFromComponent { get; set; }
        public bool MergeChangesFromMaster { get; set; }
        public bool MergeDeletionsFromComponent { get; set; }

        protected abstract string GetCompoundNaturalKeyExpression(String sqlSourceName);


        public string MakeMergeTableCommand
        {
            get
            {
                var sb = new StringBuilder();

                var createTableBuilder = new CreateTable(new SqliteDialect())
                { 
                    TableName = MergeTableName,
                    Columns = AllClientColumns.Where((c) => c.IsPK || ClientUniqueFieldNames.Contains(c.Name))
                    .Select(c => new ColumnInfo(c.Name, c.Type))
                    .Concat(CommonMergeTableColumns).ToArray(),
                };
                sb.Append(createTableBuilder.ToString()).AppendLine(";");

                sb.AppendLine($"CREATE INDEX {MergeTableName}_componentRowID ON {MergeTableName} (ComponentRowID);");
                sb.AppendLine($"CREATE INDEX {MergeTableName}_NaturalMatch ON {MergeTableName} (NaturalMatch);");
                sb.AppendLine($"CREATE INDEX {MergeTableName}_MatchRowID ON {MergeTableName} (MatchRowID);");
                sb.AppendLine($"CREATE INDEX {MergeTableName}_CompoundNaturalKey ON {MergeTableName} (CompoundNaturalKey);");

                return sb.ToString();
            }
        }

        public string SelectNaturalMatches
        {
            get
            {
                return
                    "SELECT mrg.MergeRowID, client.RowID AS NaturalMatch " +
                    "FROM " + MergeTableName + " AS mrg " +
                    "INNER JOIN main." + ClientTableName + " AS client " +
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
                    "FROM " + MergeTableName + " AS lft " +
                    "INNER JOIN main." + ClientTableName + " AS rgt " +
                    "ON (lft.ComponentRowID = rgt." + ClientPrimaryKey.Name + ");";
            }
        }

        public string SelectGUIDMatches
        {
            get
            {
                return
                @"SELECT lft.MergeRowID, rgt.RowID AS GUIDMatch " +
                @"FROM " + MergeTableName + " AS lft " +
                @"INNER JOIN main." + ClientTableName + " AS rgt " +
                @"ON rgt." + ClientGUIDFieldName + " = lft.ComponentRowGUID;";
            }
        }

        public string SelectInvalidMatchs => $"SELECT MergeRowID FROM {MergeTableName} {FindInvalidMatchs}";

        public string SelectSiblingRecords =>
                "SELECT PartialMatch, SiblingRecords FROM (" +
                " SELECT PartialMatch, group_concat(ComponentRowID || ' in ' || ComponentID, ', ') AS SiblingRecords, count(1) as size" +
                $" FROM {MergeTableName} WHERE PartialMatch IS NOT NULL" +
                " GROUP BY PartialMatch)" +
                " WHERE size > 1;";

        public string SelectMissingMatches(ComponentFile comp)
        {
            return
                $"SELECT client.{ClientPrimaryKey.Name} AS MatchRowID FROM {ClientTableName} AS client " +
                $"LEFT JOIN {MergeTableName} AS mrg " +
                $"ON (client.{ClientPrimaryKey.Name} = mrg.MatchRowID AND ComponentID = {comp.Component_CN.ToString()}) " +
                $"WHERE mrg.MatchRowID IS NULL;";
        }

        public string SelectMasterRowVersion =>
            "SELECT client.RowID AS MasterRowID, client.RowVersion AS MasterRowVersion " +
            $"FROM {ClientTableName} AS client;";

        private string FindInvalidMatchs
        {
            get
            {
                //Conflicts will exist only if two comparison methods are selected
                //in the case of guid matching guid match

                List<string> conditions = new List<string>(3);

                if (DoGUIDMatch && this.DoNaturalMatch)
                {
                    conditions.Add("((GuidMatch IS NOT NULL AND NaturalMatch IS NOT NULL) AND NaturalMatch != GUIDMatch)");
                }
                if (DoGUIDMatch && this.DoKeyMatch)
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

        public string FindAllErrorFilter
        {
            get
            {
                string filter = " WHERE (MatchRowID IS NULL AND PartialMatch IS NOT NULL)";
                //"ComponentConflict IS NOT NULL " +
                //"MatchConflict IS NOT NULL ";
                if (RecordsUniqueAccrossComponents)
                {
                    filter += " OR SiblingRecords IS NOT NULL " +
                    "OR NaturalSiblings IS NOT NULL ";
                }
                return filter;
            }
        }

        public string FindPartialMatchFilter => " WHERE (MatchRowID IS NULL AND PartialMatch IS NOT NULL)";

        public string FindConflictFilter => (RecordsUniqueAccrossComponents) ? " WHERE NaturalSiblings IS NOT NULL"
            : "";

        public string FindRecordIDConflictFilter => (RecordsUniqueAccrossComponents) ? " WHERE SiblingRecords IS NOT NULL"
            : "";

        public string FindNewRecords =>
                " WHERE ComponentRowID IS NOT NULL " +
                "AND NaturalMatch IS NULL " +
                "AND GUIDMatch IS NULL " +
                "AND RowIDMatch IS NULL " +
                "AND MatchRowID IS NULL " +
                "AND (IsDeleted IS NULL OR IsDeleted = 0) ";

        public string FindMasterToCompUpdates => $" WHERE MasterRowVersion > ComponentRowVersion AND {FindMatchesBase}";

        public string FindCompToMasterUpdates => $" WHERE ComponentRowVersion >= MasterRowVersion AND {FindMatchesBase}";

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

        public string SelectFullMatches => $"Select NaturalMatch, RowIDMatch, GUIDMatch, MergeRowID FROM {MergeTableName} {FindFullMatches};";

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

        public string FindMatched => " WHERE MatchRowID IS NOT NULL " +
                    "AND MatchConflict IS NULL " +
                    "AND ComponentConflict IS NULL " +
                    "AND ifnull(IsDeleted, 0) = 0 ";

        public string GetPopulateMergeTableCommand(int component_cn)
        {
            string clientFieldList = string.Empty;
            var clientFieldNames = ClientFieldNames;
            if (clientFieldNames.Count() > 0)
            {
                clientFieldList = ", " + String.Join(", ", this.ClientFieldNames);
            }

            String populateMergetableCMD =
                $"INSERT INTO {MergeTableName} " +
                "(ComponentRowID" +
                (HasGUIDKey ? ", ComponentRowGUID" : String.Empty) +
                ", ComponentID" +
                (HasRowVersion ? ", ComponentRowVersion" : String.Empty) +
                clientFieldList +
                ", CompoundNaturalKey) " +
                $"SELECT {ClientPrimaryKey.Name}" +
                (HasGUIDKey ? ", " + this.ClientGUIDFieldName : String.Empty) +
                $", {component_cn.ToString()} AS ComponentID" +
                (HasRowVersion ? ", RowVersion AS ComponentRowVersion" : String.Empty) +
                clientFieldList +
                $", {GetCompoundNaturalKeyExpression("compSource")} " +
                $"FROM {COMP_ALIAS}.{ClientTableName} as compSource;";

            return populateMergetableCMD;
        }

        public string GetPopulateDeletedRecordsCommand(int component_cn)
        {
            String populateDeletedRecordsCMD =
                $"INSERT INTO {MergeTableName} "
                 + "(ComponentRowID " +
                 (HasGUIDKey ? ", ComponentRowGUID" : String.Empty) +
                 ", IsDeleted, ComponentID) " +
                 "SELECT RecordID " +
                 (this.HasGUIDKey ? ", RecordGUID" : String.Empty) +
                 $", 1 AS IsDeleted, {component_cn} AS ComponentID FROM Util_Tombstone WHERE TableName = '{ClientTableName}';";

            return populateDeletedRecordsCMD;
        }

        public IEnumerable<MergeObject> ListNewRecords(DAL master, ComponentFile comp)
        {
            string selectNewRecordsCommand =
                "SELECT * FROM " + MergeTableName +
                FindNewRecords +
                " AND ComponentID = @p1;";
            return master.Query<MergeObject>(selectNewRecordsCommand, new object[] { comp.Component_CN }).ToArray();
        }

        public IEnumerable<MergeObject> ListComponentUpdates(DAL master, ComponentFile comp)
        {
            string selectPullRecordsCommand = "SELECT * FROM " + MergeTableName +
                FindMasterToCompUpdates +
                " AND ComponentID = @p1;";

            return master.Query<MergeObject>(selectPullRecordsCommand, new object[] { comp.Component_CN }).ToArray();
        }

        public IEnumerable<MergeObject> ListMasterUpdates(DAL master, ComponentFile comp)
        {
            string selectPullRecordsCommand = "SELECT * FROM " + MergeTableName +
                FindCompToMasterUpdates +
                " AND ComponentID = @p1;";

            return master.Query<MergeObject>(selectPullRecordsCommand, new object[] { comp.Component_CN }).ToArray();
        }

        public DataObject ReadSingleRow(DAL source, long rowid)
        {
            switch (this.ClientTableName)
            {
                case "Tree":
                    {
                        return source.From<TreeDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "Log":
                    {
                        return source.From<LogDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "Stem":
                    {
                        return source.From<StemDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "Plot":
                    {
                        return source.From<PlotDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "CountTree":
                    {
                        return source.From<CountTreeDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "CuttingUnit":
                    {
                        return source.From<CuttingUnitDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "Stratum":
                    {
                        return source.From<StratumDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "CuttingUnitStratum":
                    {
                        return source.From<CuttingUnitStratumDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "SampleGroup":
                    {
                        return source.From<SampleGroupDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "SampleGroupTreeDefaultValue":
                    {
                        return source.From<SampleGroupTreeDefaultValueDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                case "TreeDefaultValue":
                    {
                        return source.From<TreeDefaultValueDO>().Where("rowid = @p1").Query(rowid).FirstOrDefault();
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public long GetMatchRowID(MergeObject mRec)
        {
            if (DoGUIDMatch && mRec.GUIDMatch != null)
            {
                return mRec.GUIDMatch.Value;
            }
            if (DoNaturalMatch && mRec.NaturalMatch != null)
            {
                return mRec.NaturalMatch.Value;
            }
            else
            {
                return mRec.RowIDMatch.GetValueOrDefault(0);
            }
        }


    }
}