using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestingAPI2.Entities;

namespace TestingAPI2
{
    public static class SearchEngine
    {
        public static List<Product> Search(string itemName, string category, ArrayList itemList)
        {
            Dictionary<Product, int> dict = new Dictionary<Product, int>();
            int points = 0;
            string[] nameWords = Regex.Split(FixStrings(itemName), " ");
            /*itemList.Remove((from Product product in itemList
                             where product.category.type != category
                             select product).ToList());*/       //kolkas neveikia

            foreach(Product p in itemList)
            {
                points = 0;
                foreach (string word in nameWords)
                    if (FixStrings(p.name).Contains(word))
                        points++;
                dict.Add(p, points);
            }
            return (from entry in dict
                    orderby entry.Value 
                    descending select entry.Key)
                    .ToList<Product>();            
        }

        private static string FixStrings(string str)
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

