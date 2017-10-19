using System;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class SearchEngine
    {
        static void Main(string[] args)
        {
            Item item = new Item("Ledai plombyras \"Lyginamasis\"", 3.14, "DAIRY", "RIMI");
            ArrayList items = new ArrayList();
            items.Add(new Item("Ledai Plombyras \"Svajonė\"", 3.10, "DAIRY", "IKI"));
            items.Add(new Item("Ledai Plombyras \"Realybė\"", 3.18, "DAIRY", "RIMI"));
            items.Add(new Item("Ledai Plombyras \"Feikinis\"", 3.18, "Other", "RIMI"));
            items.Add(new Item("Dešra \"Medžiotojų\"", 0.99, "MEAT", "RIMI"));
            items.Add(new Item("Alus \"Utenos\"", 4.10, "ALCOHOL", "OTHER"));
            items.Add(new Item("Pienas \"Dvaro\"", 2.04, "DAIRY", "OTHER"));
            //Console.WriteLine(item);
            foreach (Item loopItem in items)
            {
                //  Console.WriteLine(loopItem);
            }

            Search(item.ProductName, items, item.Category.ToString());
            //FindByCategory(item, @"C:\xml\products.xml");

            Console.Read();
        }
        public static void LoadIntoXML(Item item, string XmlLoc)
        {
            XmlDocument doc = new XmlDocument();

            /* Check if location XmlLoc is empty or null*/
            if (String.IsNullOrEmpty(XmlLoc)) { XmlLoc = "C:\\products.xml"; }

            /* Load item info into xml file */
            doc.LoadXml(("<Product>" +
                         "<Price>" + item.Price + "</Price>" +
                         "<Shop>" + item.Shop + "</Shop>" +
                         "<Name>" + item.ProductName + "</Name>" +
                         "<Category>" + item.Category + "</Category>" +
                         "</Product>"));
            //Save the document to a file.  
            doc.Save("C:\\xml\\products.xml");
        }

        public static void FindByCategory(Item item, string Xmloc)
        {
            XmlTextReader textReader = new XmlTextReader(Xmloc);
            string _price = null; // extracted price
            string _category = null; // extracted category
            string _name = null; // extracted name
            string _shop = null; // extracted shop
            bool categoryMatches = false;

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
                                    categoryMatches = true;
                                    /* Category matches; Element text found here*/
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                else if (nType == XmlNodeType.EndElement)
                {
                    if (textReader.Name.ToString().Equals("Product"))
                    {
                        if (categoryMatches)
                        {
                            Console.WriteLine("Product Found");
                            Console.WriteLine("Name: " + _name +
                                              ", price: " + _price +
                                              ", shop: " + _shop +
                                              ", category: " + _category + ".");

                            Regex.Replace(_price, @"\s+", "");
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

                            //reset bool categoryMatches
                            categoryMatches = false;
                        }
                    }
                }

            }
        }

        // A method to find the most similar items in the list according to the itemName
        public static ArrayList Search(string itemName, ArrayList itemList, string category)
        {

            ArrayList results = new ArrayList(); //returned arraylist
            Dictionary<string, int> itemDic = new Dictionary<string, int>(); //dictionary for mapping item names to points
            StringBuilder keyword = new StringBuilder(); //used for building keywords (compare values)

            //Fix itemName string (see fixStrings method)
            itemName = FixStrings(itemName);

            //Splitting itemName by words
            char[] separators = { ' ' }; // separators for spliting itemName 
            String[] itemNameSubs = itemName.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            //Select only items of the given category
            var sameCategoryItems = from Item itemx in itemList
                                    where itemx.Category.ToString() == category
                                    select itemx;

            foreach (Item it in sameCategoryItems)
            {
                //fix the arraylist's product names string (see fixStrings method)
                it.ProductName = FixStrings(it.ProductName);

                //filling the dictionary with existing item names, setting zero points to each
                itemDic.Add(it.ProductName, 0);
                //Console.WriteLine(it);
            }

            for (int i = 0; i < itemNameSubs.Length; i++)
            {

                //build the keyword
                keyword.Append(itemNameSubs[i]);
                //Console.WriteLine(keyword.ToString());
                //Console.WriteLine("Now searching for the keyword: " + keyword.ToString() ); 

                //Search for the keyword in the sameCategoryItems & assign points
                foreach (Item it in sameCategoryItems)
                {
                    if (it.ProductName.Contains(keyword.ToString()))
                    {
                        //Assign a point
                        itemDic[it.ProductName] += 1;
                        //Console.WriteLine("Assigning a point to: '" + it.ProductName + "' points now: " + itemDic[it.ProductName]);
                    }

                }
                //Add a space after the last word
                keyword.Append(" ");
                //Console.WriteLine("**********************************************");
            }

            // retrieving all keys with the maximum values
            var keys = itemDic.Where(pair => pair.Value == itemDic.Values.Max()).Select(pair => pair.Key).ToArray(); // if you want an array of these keys
            foreach (string key in keys)
            {
                //Console.WriteLine(key);
                // search for product/item with the name equal to key
                foreach (Item it in sameCategoryItems)
                {
                    if (it.ProductName == key)
                    {
                        results.Add(it);
                    }
                }
            }
            foreach (Item it in results)
            {
                // Console.WriteLine(it);
            }
            return results;
        }

        //Replace Lithuanian symbols with appropriate latin symbols, sets to lowercase*/
        public static string FixStrings(string str)
        {
            str = str.ToLower();
            str = Regex.Replace(str, "ą", "a");
            str = Regex.Replace(str, "č", "c");
            str = Regex.Replace(str, "ę", "e");
            str = Regex.Replace(str, "ė", "e");
            str = Regex.Replace(str, "į", "i");
            str = Regex.Replace(str, "š", "s");
            str = Regex.Replace(str, "ų", "u");
            str = Regex.Replace(str, "ū", "u");
            return str;
        }
    }
}