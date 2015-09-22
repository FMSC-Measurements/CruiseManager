using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CruiseManager.Core.SetupModels
{
    [Serializable]
    public class Forest
    {
        [XmlAttribute]
        public String State { get; set; }
        [XmlAttribute]
        public String Name { get; set; }
        [XmlAttribute]
        public String ForestNumber { get; set; }

        [XmlIgnore]
        public Forest Self { get { return this; } }

        
    }
}
