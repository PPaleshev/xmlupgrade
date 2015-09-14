using System;
using System.Collections.Generic;
using XmlUpgrade.Core;

namespace XmlUpgrade.Commands
{
    public class RemoveAttributesCommand: IXmlTransformationCommand
    {
        readonly string xpath;

        readonly IList<string> attributes;

        public RemoveAttributesCommand(string xpath, IList<string> attributes)
        {
            this.xpath = xpath;
            this.attributes = attributes;
        }

        public void Execute(IXmlTransformContext context)
        {
            var parent = context.CreateNavigator();
            var target = parent.SelectSingleNode(xpath);
            if (target == null)
                throw new InvalidOperationException("unable to find target element by expression: " + xpath);
            if (!target.HasAttributes)
            {
                Console.WriteLine("No attributes to remove in element by xpath: {0}", xpath);
                return;
            }
            foreach (var attribute in attributes)
            {
                var remover = target.Clone();
                if (remover.MoveToAttribute(attribute, ""))
                {
                    Console.WriteLine("Removing attribute: '{0}'", remover.Name);
                    remover.DeleteSelf();
                }
            }
        }
    }
}