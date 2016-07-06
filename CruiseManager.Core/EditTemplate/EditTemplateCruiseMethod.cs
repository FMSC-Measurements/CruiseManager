using CruiseDAL.DataObjects;
using System.ComponentModel;

namespace CruiseManager.Core.EditTemplate
{
    public class EditTemplateCruiseMethod
    {
        public EditTemplateCruiseMethod(CruiseMethodsDO method)
        {
            this.CruiseMethod = method;
        }

        public CruiseMethodsDO CruiseMethod { get; set; }
        public BindingList<TreeFieldSetupDefaultDO> TreeFields { get; set; }
        public BindingList<TreeFieldSetupDefaultDO> UnselectedTreeFields { get; set; }

        public override string ToString()
        {
            return CruiseMethod.Code;
        }
    }
}