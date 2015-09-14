using System;
using System.Collections.Generic;
using XmlUpgrade.Core;

namespace XmlUpgrade.Commands
{
    public class ChangeAttributesTransformationCommand : IXmlTransformationCommand
    {
        readonly string elementPath;

        readonly IList<KeyValuePair<string, string>> attributes;

        public ChangeAttributesTransformationCommand(string elementPath, IList<KeyValuePair<string, string>> attributes)
        {
            this.elementPath = elementPath;
            this.attributes = attributes;
        }

        public void Execute(IXmlTransformContext context)
        {
            var navigator = context.CreateNavigator();
            var target = navigator.SelectSingleNode(elementPath);
            if (target == null)
                throw new InvalidOperationException("unable to locate element to add attributes: " + elementPath);
            foreach (var attribute in attributes)
            {
                if (target.MoveToAttribute(attribute.Key, ""))
                {
                    target.SetValue(attribute.Value);
                    Console.WriteLine("Attribute '{0}' value was successfully updated", attribute.Key);
                }
            }
        }
    }
}