using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace XmlUpgrade
{
    public class DocumentModel
    {
        public const string VERSION_PROPERTY = "version";
        public const string ENV_PROPERTY = "env";

        readonly IDictionary<string, XmlProcessingInstruction> instructionMap;

        /// <summary>
        /// Текущая версия документа.
        /// </summary>
        public int CurrentVersion { get; set; }

        /// <summary>
        /// Текущее окружение, в котором установлен документ.
        /// </summary>
        public string Environment { get; set; }

        public DocumentModel(IEnumerable<XmlProcessingInstruction> instructions)
        {
            instructionMap = instructions.ToDictionary(i => i.Name, StringComparer.InvariantCultureIgnoreCase);
            CurrentVersion = LoadProperty(VERSION_PROPERTY, int.Parse);
            Environment = LoadProperty(ENV_PROPERTY, s => s, "");
        }

        /// <summary>
        /// Сохраняет изменения, сделанные в модели.
        /// </summary>
        public void Save(XmlDocument document)
        {
            WriteProperty(document, VERSION_PROPERTY, CurrentVersion.ToString(CultureInfo.InvariantCulture));
            if (!string.IsNullOrWhiteSpace(Environment))
                WriteProperty(document, ENV_PROPERTY, Environment);
        }

        T LoadProperty<T>(string property, Func<string, T> mapper, T defaultValue = default(T))
        {
            XmlProcessingInstruction instruction;
            return instructionMap.TryGetValue(property, out instruction) ? mapper(instruction.Value) : defaultValue;
        }

        void WriteProperty(XmlDocument document, string property, string value)
        {
            XmlProcessingInstruction instruction;
            if (!instructionMap.TryGetValue(property, out instruction))
            {
                instruction = document.CreateProcessingInstruction(property, value);
                document.InsertBefore(instruction, document.DocumentElement);
            }
            else
                instruction.Value = value;
        }
    }
}