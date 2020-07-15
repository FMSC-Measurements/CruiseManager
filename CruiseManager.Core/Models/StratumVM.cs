using CruiseDAL;
using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;
using System;
using System.Collections.Generic;

namespace CruiseManager.Core.Models
{
    [Table("Stratum")]
    public class StratumVM : StratumDO
    {
        private string _fields;
        private string[] _fieldsArray;

        [IgnoreField]
        public IList<SampleGroupDO> SampleGroups { get; set; }

        [Field(Alias = "Fields", SQLExpression = "(Select group_concat(Field) From TreeFieldSetup AS TFS WHERE TFS.Stratum_CN = Stratum.Stratum_CN)", PersistanceFlags = PersistanceFlags.Never)]
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
                return _fieldsArray ?? new string[0];
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