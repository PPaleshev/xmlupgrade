using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlUpgrade.Settings
{
    public class PatchObject
    {
        [XmlAttribute("Version")]
        public int Version { get; set; }

        [XmlElement(ElementName = "AddElement", Type = typeof (AddElementTransformationObject))]
        [XmlElement(ElementName = "RemoveElements", Type = typeof (RemoveElementTransformationObject))]
        [XmlElement(ElementName = "AddAttributes", Type = typeof (AddAttributeTransformationObject))]
        [XmlElement(ElementName = "RemoveAttributes", Type = typeof (RemoveAttributeTransformationObject))]
        [XmlElement(ElementName = "ChangeAttributes", Type = typeof (ChangeAttributesTransformationObject))]
        public List<BaseTransformationObject> Transformations { get; set; }
    }
}
