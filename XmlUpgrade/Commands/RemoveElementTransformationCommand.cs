using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using XmlUpgrade.Core;

namespace XmlUpgrade.Commands
{
    /// <summary>
    /// Команда для удаления элементов из xml документа.
    /// </summary>
    public class RemoveElementTransformationCommand : IXmlTransformationCommand
    {
        /// <summary>
        /// Выражение для удаления элементов.
        /// </summary>
        readonly string xpath;

        /// <summary>
        /// Ожидаемое количество удаляемых элементов.
        /// </summary>
        readonly int? expectedChanges;

        public RemoveElementTransformationCommand(string xpath, int? expectedChanges)
        {
            this.xpath = xpath;
            this.expectedChanges = expectedChanges;
        }

        public void Execute(IXmlTransformContext context)
        {
            var navigator = context.CreateNavigator();
            var iterator = navigator.Select(xpath);
            if (expectedChanges.HasValue && iterator.Count != expectedChanges.Value)
                throw new InvalidOperationException(string.Format("Expected {0} elements to remove, but {1} elements was found.", expectedChanges.Value, iterator.Count));
            var list = new List<XPathNavigator>(iterator.Cast<XPathNavigator>());
            foreach (var nav in list)
            {
                Console.WriteLine("Deleting element '{0}'", nav.Name);
                nav.DeleteSelf();
            }
        }
    }
}
