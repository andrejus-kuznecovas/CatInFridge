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
            StreamWriter theStreamWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Product) });

                if (File.Exists(path))
                    objectToWrite.AddRange(ReadFromXmlFile());

                theStreamWriter = new StreamWriter(path);
                serializer.Serialize(theStreamWriter, objectToWrite);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { theStreamWriter.Close(); }
            
                        
        }

        public static ArrayList ReadFromXmlFile()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Product) });
                reader = new StreamReader(path);
                return (ArrayList)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
