using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BLService
{
    public class Repository
    {
        public static string productPath;
        public static string shopPath;

        public Repository()
        {
            productPath = @"C:\Users\Ben\Desktop\serviceTest\products.xml";
            shopPath = @"C:\Users\Ben\Desktop\serviceTest\shops.xml";
        }

        public bool WriteProductsToXmlFile(List<Product> objs, Shop shop)        //TODO: category
        {
            if(objs == null || shop == null)
                return false;

            ArrayList objectToWrite = new ArrayList();

            foreach (Product obj in objs)
                objectToWrite.Add(obj);

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

        public ArrayList ReadProductsFromXmlFile()
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

        public bool WriteShopToXmlFile(Shop obj)
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

        public ArrayList ReadShopsFromXmlFile()
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
