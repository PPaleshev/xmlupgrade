using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using XmlUpgrade.Commands;
using XmlUpgrade.Core;

namespace XmlUpgrade.Settings
{
    public class ChangeAttributesTransformationObject: BaseTransformationObject
    {
        [XmlAttribute("ElementPath")]
        public string ElementPath { get; set; }

        [XmlElement("Attribute")]
        public List<AttributeValueObject> Attributes { get; set; }

        public override IXmlTransformationCommand CreateCommand()
        {
            if (Attributes == null || Attributes.Count == 0)
                throw new ArgumentNullException("Attributes are not specified");
            return new ChangeAttributesTransformationCommand(ElementPath, Attributes.Select(o => new KeyValuePair<string, string>(o.Name, o.Value)).ToList());
        }
    }
}