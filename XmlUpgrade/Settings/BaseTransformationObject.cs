using XmlUpgrade.Core;

namespace XmlUpgrade.Settings
{
    public abstract class BaseTransformationObject
    {
        /// <summary>
        /// Создаёт команду для изменения xml документа.
        /// </summary>
        public abstract IXmlTransformationCommand CreateCommand();
    }
}