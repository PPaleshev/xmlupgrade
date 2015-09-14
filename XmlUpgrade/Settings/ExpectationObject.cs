using System.Xml.Serialization;

namespace XmlUpgrade.Settings
{
    public class ExpectationObject
    {
        [XmlAttribute("Min")]
        public int Min { get; set; }

        [XmlAttribute("Max")]
        public int Max { get; set; }

        [XmlIgnore]
        public bool MinSpecified { get; set; }

        [XmlIgnore]
        public bool MaxSpecified { get; set; }
    }
}
