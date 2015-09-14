using System.Collections.Generic;
using System.Xml.Serialization;
using XmlUpgrade.Commands;
using XmlUpgrade.Core;

namespace XmlUpgrade.Settings
{
    public class RemoveAttributeTransformationObject: BaseTransformationObject
    {
        [XmlAttribute("ElementPath")]
        public string XPath { get; set; }

        [XmlElement("Attribute")]
        public List<string> Attributes { get; set; }

        public override IXmlTransformationCommand CreateCommand()
        {
            return new RemoveAttributesCommand(XPath, Attributes);
        }
    }
}