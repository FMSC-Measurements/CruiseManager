using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;

namespace CruiseManager.Core.Models
{
    [EntitySource(SourceName = "Stratum"
        , JoinCommands = "JOIN (Select Stratum_CN, group_concat(Field) AS Fields From TreeFieldSetup GROUP BY Stratum_cn) USING (Stratum_CN)")]
    public class StratumVM : StratumDO
    {
        private string _fields;
        private string[] _fieldsArray;

        [IgnoreField]
        public IList<SampleGroupDO> SampleGroups { get; set; }

        [Field(Alias = "Fields", PersistanceFlags = PersistanceFlags.Never)]
        public string Fields
        {
            get { return _fields; }
            set
            {
                if (_fields == value) { return; }
                _fields = value;
                _fieldsArray = null;
            }
        }

        [IgnoreField]
        public string[] FieldsArray
        {
            get
            {
                if ((_fieldsArray == null || _fieldsArray.Length == 0)
                    && !String.IsNullOrEmpty(_fields))
                {
                    _fieldsArray = _fields.Split(',');
                }
                return _fieldsArray;
            }
        }

        public StratumVM()
        {
        }

        public StratumVM(DAL db)
            : base(db)
        { }

        public StratumVM(StratumDO st)
            : base(st)
        { }

        //public void LoadTreeFieldNames()
        //{
        //    string command = String.Concat("Select group_concat(distinct Field) FROM TreeFieldSetup WHERE Stratum_CN = ", this.Stratum_CN, ";");
        //    string result = (string)this.DAL.ExecuteScalar(command);
        //    if (!string.IsNullOrEmpty(result))
        //    {
        //        this.TreeFieldNames = result.Split(',');
        //    }
        //}
    }
}