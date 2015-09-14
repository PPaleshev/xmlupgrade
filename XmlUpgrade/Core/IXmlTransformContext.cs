using System.Xml.XPath;

namespace XmlUpgrade.Core
{
    /// <summary>
    /// Контекст работы над документом xml.
    /// </summary>
    public interface IXmlTransformContext
    {
        /// <summary>
        /// Текущая версия документа.
        /// </summary>
        int CurrentVersion { get; }

        /// <summary>
        /// Создаёт навигатор для работы с исходным xml.
        /// </summary>
        XPathNavigator CreateNavigator();
    }
}
