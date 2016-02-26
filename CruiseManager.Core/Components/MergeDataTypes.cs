using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CruiseDAL;
using FMSC.ORM.EntityModel.Attributes;

namespace CruiseManager.Core.Components
{
    public class MergeObject 
    {
        [Field(Name = "MergeRowID")]
        public long MergeRowID { get; set; }


        //[Field(Name = "ComponentConflict")]
        //public string ComponentConflict { get; set; }

        //this field maybe unnecessary if we concatenate the file id with the row id in componentconflict
        //[Field(Name = "ComponentConflictFileID")]
        //public long? ComponentConflictFileID { get; set; }

        ////is set to 
        ////is set to a row id when another record in the merge table conflicts with this records matchRowID value
        //[Field(Name = "MatchConflict")]
        //public string MatchConflict { get; set; }

        [Field(Name = "NaturalSiblings")]
        public string NaturalSiblings { get; set; }

        [Field(Name = "SiblingRecords")]
        public string SiblingRecords { get; set; }

        [Field(Name = "CompoundNaturalKey")]
        public string CompoundNaturalKey { get; set; }

        //this field is slightly redundant but allows quicker processing
        //it is set after a match is validated 
        [Field(Name = "MatchRowID")]
        public long? MatchRowID { get; set; }

        [Field(Name = "PartialMatch")]
        public string PartialMatch { get; set; }

        
      
       

        //[Field(Name = "MasterRowID")]
        //public long? MasterRowID { get; set; }

        [Field(Name = "NaturalMatch")]
        public long? NaturalMatch { get; set; }

        [Field(Name = "RowIDMatch")]
        public long? RowIDMatch { get; set; }

        [Field(Name = "GUIDMatch")]
        public long? GUIDMatch { get; set; }



        //the component row id of the record
        [Field(Name = "ComponentRowID")]
        public long? ComponentRowID { get; set; }

        [Field(Name = "ComponentRowGUID")]
        public string ComponentRowGUID { get; set; }

        [Field(Name = "ComponentID")]
        public long ComponentID { get; set; }



        [Field(Name = "MasterRowVersion")]
        public long MasterRowVersion { get; set; }

        [Field(Name = "ComponentRowVersion")]
        public long ComponentRowVersion { get; set; }

        [Field(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }

    }

    public class MatchResult
    {
        [Field(Name="MergeRowID")]
        public long? MergeRowID { get; set; }

        [Field(Name="MatchRowID")]
        public long? MatchRowID { get; set; }
    }

    public class MergeRowIDValue
    {
        [Field(Name = "MergeRowID")]
        public long? MergeRowID { get; set; }
    }

    public class PrimaryKey
    {
        [Field(Name = "PKvalue")]
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
