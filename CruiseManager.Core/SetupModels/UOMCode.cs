using System;
using System.Xml.Serialization;

namespace CruiseManager.Core.SetupModels
{
    [Serializable]
    public class UOMCode
    {
        public UOMCode()
        {
        }

        public UOMCode(String[] values)
        {
            Code = values[0];
            FriendlyValue = values[1];
        }

        [XmlAttribute]
        public string Code { get; set; }

        [XmlAttribute]
        public String FriendlyValue { get; set; }

        [XmlIgnore]
        public String DisplayValue { get { return string.Format("{0} - {1}", Code, FriendlyValue); } }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Code, FriendlyValue);
        }
    }
}