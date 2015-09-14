using System;
using System.Xml;

namespace XmlUpgrade.Core
{
    public class DocumentInformation
    {
        public int CurrentVersion { get; private set; }

        public XmlProcessingInstruction Source { get; private set; }

        public DocumentInformation()
        {
            CurrentVersion = 0;
            Source = null;
        }

        public DocumentInformation(XmlProcessingInstruction instruction)
        {
            Source = instruction;
            CurrentVersion = int.Parse(instruction.Value);
        }
    }
}
