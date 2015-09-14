using System.Xml;
using System.Xml.XPath;

namespace XmlUpgrade.Core
{
    public class XmlTransformContext : IXmlTransformContext
    {
        readonly XmlDocument document;

        public XmlTransformContext(XmlDocument document, int version)
        {
            this.document = document;
            CurrentVersion = version;
        }

        public int CurrentVersion { get; private set; }

        public XPathNavigator CreateNavigator()
        {
            return document.CreateNavigator();
        }
    }
}
