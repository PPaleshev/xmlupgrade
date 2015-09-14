using System;
using System.IO;
using System.Linq;
using System.Xml;
using XmlUpgrade.Core;
using XmlUpgrade.Settings;

namespace XmlUpgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlUpgradeObject settings;
            using (var file = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\Upgrade.xml")))
                settings = XmlUpgradeObject.Deserialize(file);

            var xml = LoadDocument(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\ServerSettings.xml"));
            var model = new DocumentModel(xml.ChildNodes.OfType<XmlProcessingInstruction>());

            Console.WriteLine("Current version: " + model.CurrentVersion);
            Console.WriteLine("Current environment: " + model.Environment);

            var context = new XmlTransformContext(xml, 0);
            bool hasChanges = false;
            foreach (var patch in settings.Patches.OrderBy(p => p.Version))
            {
                if (patch.Version <= model.CurrentVersion)
                {
                    Console.WriteLine("Patch version {0}: skipped", patch.Version);
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Applying patch version " + patch.Version);
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (var transformationObject in patch.Transformations)
                {
                    var command = transformationObject.CreateCommand();
                    command.Execute(context);
                }
                model.CurrentVersion = patch.Version;
                hasChanges = true;
            }
            if (!hasChanges)
            {
                Console.WriteLine("No changes was made.");
                return;
            }
            model.Save(xml);
            xml.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ServerSettings-modified.xml"));
        }

        static XmlDocument LoadDocument(string fileName)
        {
            var document = new XmlDocument();
            using (var file = File.OpenRead(fileName))
                document.Load(file);
            return document;
        }
    }
}
