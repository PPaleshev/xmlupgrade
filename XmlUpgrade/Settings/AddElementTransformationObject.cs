using System.Xml.Serialization;
using XmlUpgrade.Commands;
using XmlUpgrade.Core;

namespace XmlUpgrade.Settings
{
    public class AddElementTransformationObject: BaseTransformationObject
    {
        [XmlAttribute("ParentPath")]
        public string ParentPath { get; set; }

        [XmlText]
        public string Content { get; set; }

        public override IXmlTransformationCommand CreateCommand()
        {
            return new AddElementTransformationCommand(ParentPath, Content);
        }
    }
}