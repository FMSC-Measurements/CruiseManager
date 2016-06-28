using System;
using System.Xml.Serialization;

namespace CruiseManager.Core.SetupModels
{
    [Serializable]
    public class ThreePCode
    {
        public ThreePCode()
        {
        }

        public ThreePCode(String[] values)
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