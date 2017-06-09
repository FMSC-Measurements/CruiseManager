using System;
using System.Xml.Serialization;

namespace CruiseManager.Core.SetupModels
{
    [Serializable]
    public class ProductCode
    {
        public static ProductCode Empty = new ProductCode()
        {
            Code = string.Empty,
            FriendlyValue = string.Empty
        };

        [XmlAttribute]
        public String Code { get; set; }

        [XmlAttribute]
        public String FriendlyValue { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}