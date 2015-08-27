using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using CruiseDAL.DataObjects;

namespace CSM.Utility.Setup
{
    [Serializable]
    public class CruiseMethod : CruiseMethodsDO
    {
        public CruiseMethod() 
        {
            TreeFieldSetups = new List<TreeFieldSetupDO>();
            LogFieldSetups = new List<LogFieldSetupDO>();
        }

        public CruiseMethod(String[] values)
            : this(values[0], values[1])
        { }


        public CruiseMethod(string Code, string FriendlyValue)
        {
            this.Code = Code;
            this.FriendlyValue = FriendlyValue;
        }



        [XmlArray]
        public List<TreeFieldSetupDO> TreeFieldSetups { get; set; }

        [XmlArray]
        public List<LogFieldSetupDO> LogFieldSetups { get; set; }
    }

    //[Serializable]
    //public class CruiseMethodCollection
    //{
    //    public CruiseMethodCollection()
    //    { }

    //    private List<CruiseMethod> _cruiseMethods = new List<CruiseMethod>(); 



    //    [XmlArray]
    //    public List<CruiseMethod> Items
    //    {
    //        get { return _cruiseMethods; }
    //        set { _cruiseMethods = value; }
    //    }

    //    public void Add(CruiseMethod cm)
    //    {
    //        _cruiseMethods.Add(cm);
    //    }
    //}

}
