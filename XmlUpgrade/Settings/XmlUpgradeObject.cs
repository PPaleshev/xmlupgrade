using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlUpgrade.Settings
{
    [XmlType("XmlUpgrade")]
    public class XmlUpgradeObject
    {
        static readonly XmlSerializer SERIALIZER = new XmlSerializer(typeof (XmlUpgradeObject));

        [XmlElement("Patch")]
        public List<PatchObject> Patches { get; set; }

        public static XmlUpgradeObject Deserialize(Stream stream)
        {
            return (XmlUpgradeObject) SERIALIZER.Deserialize(stream);
        }
    }
}