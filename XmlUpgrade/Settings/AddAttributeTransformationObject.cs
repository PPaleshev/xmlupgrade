using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using XmlUpgrade.Commands;
using XmlUpgrade.Core;

namespace XmlUpgrade.Settings
{
    public class AddAttributeTransformationObject: BaseTransformationObject
    {
        [XmlAttribute("ElementPath")]
        public string ElementPath { get; set; }

        [XmlElement("Attribute")]
        public List<AttributeValueObject> Attributes { get; set; }

        public override IXmlTransformationCommand CreateCommand()
        {
            if (Attributes == null || Attributes.Count == 0)
                throw new ArgumentNullException("Attributes are not specified");
            return new AddAttributeTransformationCommand(ElementPath, Attributes.Select(o => new KeyValuePair<string, string>(o.Name, o.Value)).ToList());
        }
    }

    public class AttributeValueObject
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}