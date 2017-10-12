using System;
using TestingAPI2;
using System.Xml;

namespace ConsoleApp2
{
    class SearchEngine
    {
        static void Main(string[] args)
        {
            Item item = new Item("Pzpz", 3.14);
            Console.WriteLine(item);

            /** XML TEST*/
            FindByCategory(item, "D:\\products.xml");
            Console.Read();
        }
        public static void LoadIntoXML(Item item, string XmlLoc)
        {
            XmlDocument doc = new XmlDocument();

            /* Check if location XmlLoc is empty or null*/
            if (String.IsNullOrEmpty(XmlLoc)) { XmlLoc = "D:\\products.xml"; }

            /* Load item info into xml file */
            doc.LoadXml(("<Product>" +
                         "<Price>" + item.Price + "</Price>" +
                         "<Shop>" + item.Shop + "</Shop>" +
                         "<Name>" + item.ProductName + "</Name>" +
                         "<Category>" + item.Category + "</Category>" +
                         "</Product>"));
            //Save the document to a file.  
            doc.Save("D:\\products.xml");
        }

        public static void FindByCategory(Item item, string Xmloc)
        {
            XmlTextReader textReader = new XmlTextReader(Xmloc);
            string _price = null; // extracted price
            string _category = null; // extracted category
            string _name = null; // extracted name
            string _shop = null; // extracted shop

            while (textReader.Read())
            {
                XmlNodeType nType = textReader.NodeType;

                /* if node type is an element */
                if (nType == XmlNodeType.Element)
                {
                    switch (textReader.Name.ToString())
                    {
                        case "Price":
                            /* Element named <Price> found here*/
                            textReader.Read();
                            if (textReader.NodeType == XmlNodeType.Text)
                            {
                                /* Extract price from .xml file */
                                _price = textReader.ReadString();
                            }
                            break;

                        case "Shop":
                            /* Element named <Shop> found here*/
                            textReader.Read();
                            if (textReader.NodeType == XmlNodeType.Text)
                            {
                                /* Extract shop from .xml file */
                                _shop = textReader.ReadString();
                            }
                            break;
                        case "Name":
                            /* Element named <Name> found here*/
                            textReader.Read();
                            if (textReader.NodeType == XmlNodeType.Text)
                            {
                                /* Extract shop from .xml file */
                                _name = textReader.ReadString();

                            }
                            break;
                        case "Category":
                            /* Element named <Category> found here*/
                            textReader.Read();
                            if (textReader.NodeType == XmlNodeType.Text)
                            {
                                /* Extract category from .xml file */
                                _category = textReader.ReadString();
                                /* Check if category matches */
                                if (_category.Equals(item.Category.ToString()))
                                {
                                    /* Category matches; Element text found here*/
                                    Console.WriteLine("Product Found");
                                    Console.WriteLine("Name: " + _name +
                                                      ", price: " + _price +
                                                      ", shop: " + _shop +
                                                      ", category: " + _category + ".");

                                    double storedPrice = XmlConvert.ToDouble(_price);
                                    // Do price checks here
                                    if (item.Price > storedPrice)
                                    {
                                        //Product in the database is cheaper
                                        Console.WriteLine("Product in the database is cheaper");
                                    }
                                    else if (item.Price < storedPrice)
                                    {
                                        //Scanned item is cheaper
                                        Console.WriteLine("Scanned item is cheaper");
                                    }
                                    else
                                    {
                                        //Scanned item is of equal value to found item
                                        Console.WriteLine("Scanned item is of equal value to found item");
                                    }
                                    Console.WriteLine("***********************************");
                                }
                            }
                            break;
                        default:
                            break;





                    }
                }


            }
        }
        public static void FindByName(Item item, string Xmloc)
        {
            /* A function to find elements with the name exact to item's name */
        }
    }
}
