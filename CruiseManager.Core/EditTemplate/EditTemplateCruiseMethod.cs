using CruiseDAL.DataObjects;
using FMSC.ORM.EntityModel.Attributes;
using System.ComponentModel;

namespace CruiseManager.Core.EditTemplate
{
    [Table("CruiseMethods")]
    public class EditTemplateCruiseMethod
    {
        public string Code { get; set; }
        public string FriendlyValue { get; set; }

        public BindingList<TreeFieldSetupDefaultDO> TreeFields { get; set; }
        public BindingList<TreeFieldSetupDefaultDO> UnselectedTreeFields { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}