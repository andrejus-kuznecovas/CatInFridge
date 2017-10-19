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
        public static string productPath { get; set; }
        public static string shopPath { get; set; }

        public static bool WriteProductsToXmlFile(ArrayList objs, Shop shop)        //TODO: category
        {
            if(objs == null || shop == null)
                return false;

            ArrayList objectToWrite = new ArrayList();
            foreach (Tuple<string, string> obj in objs)
                objectToWrite.Add(new Product(obj.Item1, obj.Item2, shop));

            StreamWriter theStreamWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Product) });

                if (File.Exists(productPath))
                    objectToWrite.AddRange(ReadProductsFromXmlFile());

                theStreamWriter = new StreamWriter(productPath);
                serializer.Serialize(theStreamWriter, objectToWrite);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally {
                if (theStreamWriter != null) theStreamWriter.Close(); }

            return true;
        }

        public static ArrayList ReadProductsFromXmlFile()
        {
            TextReader reader = null;
            if (!File.Exists(productPath))
                return null;

            try
            {
                var serializer = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Product) });
                reader = new StreamReader(productPath);
                return (ArrayList)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public static bool WriteShopToXmlFile(Shop obj)
        {
            if (obj == null)
                return false;

            StreamWriter theStreamWriter = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Shop) });
                ArrayList list = ReadShopsFromXmlFile();

                if (File.Exists(productPath))
                    list.Add(obj);

                theStreamWriter = new StreamWriter(shopPath);
                serializer.Serialize(theStreamWriter, list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { if (theStreamWriter != null) theStreamWriter.Close(); }

            return true;
        }

        public static ArrayList ReadShopsFromXmlFile()
        {
            if (!File.Exists(shopPath))
                return new ArrayList();

            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(ArrayList), new Type[] { typeof(Shop) });
                reader = new StreamReader(shopPath);
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
