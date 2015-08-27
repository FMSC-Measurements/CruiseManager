using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CSM.Utility.Setup
{
    [Serializable]
    public class Region
    {
        public Region()
        {
            Forests = new List<Forest>();
        }

        [XmlAttribute]
        public String RegionNumber { get; set; }

        [XmlAttribute]
        public String Name { get; set; }

        [XmlArray]
        public List<Forest> Forests { get; set; }

        [XmlIgnore]
        public Region Self { get { return this; } }

        
    }
}
