using System;
using XmlUpgrade.Core;

namespace XmlUpgrade.Commands
{
    public class AddElementTransformationCommand : IXmlTransformationCommand
    {
        readonly string parentPath;

        readonly string content;

        public AddElementTransformationCommand(string parentPath, string content)
        {
            this.parentPath = parentPath;
            this.content = content;
        }

        public void Execute(IXmlTransformContext context)
        {
            var navigator = context.CreateNavigator();
            var target = navigator.SelectSingleNode(parentPath);
            if (target == null)
                throw new InvalidOperationException("unable to locate parent node to append element: " + parentPath);
            target.AppendChild(content);
            Console.WriteLine("Content added");
        }
    }
}