using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TestingAPI2.Entities;

namespace TestingAPI2
{
    public static class Repository
    {
        public static string path { get; set; }

        public static void WriteToXmlFile(ArrayList objectToWrite)      //neveikia
        {
            XmlWriter writer = null;
            XmlDocument doc;

            if (!File.Exists(path))
            {
                doc = new XmlDocument();
                doc.LoadXml("<Products></Products>");
                writer = XmlWriter.Create(path, new XmlWriterSettings() {
                    Indent = true,
                    NamespaceHandling = NamespaceHandling.OmitDuplicates,
                    OmitXmlDeclaration = true
                    });
                doc.Save(writer);
                writer.Close();
            }

            doc = new XmlDocument();
            doc.Load(path);
            XmlNode rootNode = doc.FirstChild;
            var nav = rootNode.CreateNavigator();
            writer = nav.AppendChild();

            var serializer = new XmlSerializer(typeof(Product));
            try
            {
                foreach (Product singleObject in objectToWrite)
                    serializer.Serialize(writer, singleObject);

            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

        }

        public static Product[] ReadFromXmlFile()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(Product[]));
                reader = new StreamReader(Path.GetFullPath(@"..\..\") + "Products.xml");
                return (Product[])serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
