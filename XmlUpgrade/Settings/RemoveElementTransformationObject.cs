using System.Xml.Serialization;
using XmlUpgrade.Commands;
using XmlUpgrade.Core;

namespace XmlUpgrade.Settings
{
    public class RemoveElementTransformationObject : BaseTransformationObject
    {
        [XmlAttribute("XPath")]
        public string XPath { get; set; }

        [XmlAttribute("Expected")]
        public int Expected { get; set; }

        [XmlIgnore]
        public bool ExpectedSpecified { get; set; }

        public override IXmlTransformationCommand CreateCommand()
        {
            return new RemoveElementTransformationCommand(XPath, ExpectedSpecified && Expected > 0 ? Expected : (int?) null);
        }
    }
}
