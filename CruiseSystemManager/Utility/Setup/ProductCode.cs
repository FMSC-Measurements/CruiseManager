using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CSM.Utility.Setup
{
    [Serializable]
    public class ProductCode
    {
        public ProductCode() { }

        public ProductCode(String[] values)
        {
            Code = values[0];
            FriendlyValue = values[1];
        }

        [XmlAttribute]
        public String Code { get; set; }

        [XmlAttribute]
        public String FriendlyValue { get; set; }


    }
}
