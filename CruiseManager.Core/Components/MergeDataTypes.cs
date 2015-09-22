using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;

namespace CruiseManager.Core.Components
{
    public class MergeObject 
    {
        [Field(FieldName = "MergeRowID")]
        public long MergeRowID { get; set; }


        //[Field(FieldName = "ComponentConflict")]
        //public string ComponentConflict { get; set; }

        //this field maybe unnessicary if we contatinate the file id with the row id in componentconflict
        //[Field(FieldName = "ComponentConflictFileID")]
        //public long? ComponentConflictFileID { get; set; }

        ////is set to 
        ////is set to a row id when another record in the merge table conflicts with this records matchRowID value
        //[Field(FieldName = "MatchConflict")]
        //public string MatchConflict { get; set; }

        [Field(FieldName = "NaturalSiblings")]
        public string NaturalSiblings { get; set; }

        [Field(FieldName = "SiblingRecords")]
        public string SiblingRecords { get; set; }

        [Field(FieldName = "CompoundNaturalKey")]
        public string CompoundNaturalKey { get; set; }

        //this field is slightly redundent but allows quicker processing
        //it is set after a match is validated 
        [Field(FieldName = "MatchRowID")]
        public long? MatchRowID { get; set; }

        [Field(FieldName = "PartialMatch")]
        public string PartialMatch { get; set; }

        
      
       

        //[Field(FieldName = "MasterRowID")]
        //public long? MasterRowID { get; set; }

        [Field(FieldName = "NaturalMatch")]
        public long? NaturalMatch { get; set; }

        [Field(FieldName = "RowIDMatch")]
        public long? RowIDMatch { get; set; }

        [Field(FieldName = "GUIDMatch")]
        public long? GUIDMatch { get; set; }



        //the component row id of the record
        [Field(FieldName = "ComponentRowID")]
        public long? ComponentRowID { get; set; }

        [Field(FieldName = "ComponentRowGUID")]
        public string ComponentRowGUID { get; set; }

        [Field(FieldName = "ComponentID")]
        public long ComponentID { get; set; }



        [Field(FieldName = "MasterRowVersion")]
        public long MasterRowVersion { get; set; }

        [Field(FieldName = "ComponentRowVersion")]
        public long ComponentRowVersion { get; set; }

        [Field(FieldName = "IsDeleted")]
        public bool IsDeleted { get; set; }

    }

    public class MatchResult
    {
        [Field(FieldName="MergeRowID")]
        public long? MergeRowID { get; set; }

        [Field(FieldName="MatchRowID")]
        public long? MatchRowID { get; set; }
    }

    public class MergeRowIDValue
    {
        [Field(FieldName = "MergeRowID")]
        public long? MergeRowID { get; set; }
    }

    public class PrimaryKey
    {
        [Field(FieldName = "PKvalue")]
        public long? Value { get; set; }
    }

    public class MatchIndexGroup
    {
        public long? GroupID { get; set; }

        public string MatchStatus { get; set; }

    }

    public class OptionGroup
    {


        public string GroupMembers { get; set; }
    }
        
}
