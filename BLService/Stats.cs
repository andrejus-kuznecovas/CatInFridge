

using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    public class Stats
    {
        private static string[] categories = { "MEAT", "VEGETABLES_FRUITS", "DAIRY", "DRINKS", "ALCOHOL", "BREAD", "SWEETS", "OTHER", "UNRECOGNIZED" };
        private static string[] shops = { "MAXIMA", "IKI", "RIMI", "NORFA", "OTHER", "UNRECOGNIZED" };

        //Contains money spent per purchase for each product category and category name
        public static Dictionary<string, double> spendingsByCategory;

        //Contains money spent per purchase for each shop and shop name
        public static Dictionary<string, double> spendingsByShop;

        //Contains the average price of a product for each category and category name
        public static Lazy<Dictionary<string, double>> averageByCategory;

        //Contains the average price of a product for each shop and shop name
        public static Lazy<Dictionary<string, double>> averageByShop;

        //Contains the most popular product for each cateogry and category name
        public static Lazy<Dictionary<string, string>> mostPopularByCategory;

        //Contains the most popular product's name for each shop and shop name
        public static Lazy<Dictionary<string, string>> mostPopularByShop;

        //Contains the cheapest item's name for each category
        public static Lazy<Dictionary<string, string>> cheapestByCategory;

        //Contains the category name the cheapest item's name for that category
        public static Lazy<Dictionary<string, string>> cheapestByByShop;

        public Stats(string command, List<Product> prods)
        {

            spendingsByCategory = new Dictionary<string, double>();
            //Set spendings in all categories to zeroes
            InitDict(spendingsByCategory, categories);
            //Find all spendings by category
            FindSpendings(spendingsByCategory, prods, categories, "category");

            spendingsByShop = new Dictionary<string, double>();
            //Set spendings in all shops to zeroes
            InitDict(spendingsByShop, shops);
            //Find all spendings by shop
            FindSpendings(spendingsByShop, prods, shops, "shop");

            FindAvgSpendingsByCategory(prods);
            FindAvgSpendingsByShop(prods);

            //FindMostPopularByShop(prods);
            //FindMostPopularByCategory(prods);

        }

        public static void InitDict(Dictionary<string, double> dict, string[] strs)
        {
            foreach (string str in strs)
            {
                dict[str] = 0;
            }
        }

        public static void FindSpendings(Dictionary<string, double> dict, List<Product> prods, string[] strs, string command)
        {
            foreach (Product product in prods)
            {
                //Console.WriteLine("Product category (or shop): " + product.category.ToString() );
                foreach (string str in strs)
                {
                    switch (command)
                    {
                        case "category":
                            if (product.category.ToString().Equals(str))
                            {
                                dict[str] += Math.Round(Convert.ToDouble(product.price), 2);
                            }
                            break;
                        case "shop":
                            if (product.shop.ToString().Equals(str))
                            {
                                dict[str] += Math.Round(Convert.ToDouble(product.price), 2);
                            }
                            break;
                        default:
                            Console.WriteLine("wrong command!");
                            break;
                    }
                }
            }
        }

        public static void FindAvgSpendingsByCategory(List<Product> prods)
        {
            averageByCategory = new Lazy<Dictionary<string, double>>(delegate
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                foreach (string str in categories)
                {
                    int distinctCount = prods.Count(pr => pr.category.ToString().Equals(str));
                    double avg = Math.Round(spendingsByCategory[str] / distinctCount, 2);
                    if (Double.IsNaN(avg)) avg = 0; //prevent division by zero
                    dict[str] = avg;
                }
                return dict;
            });
        }

        public static void FindAvgSpendingsByShop(List<Product> prods)
        {
            averageByShop = new Lazy<Dictionary<string, double>>(delegate
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                foreach (string str in shops)
                {
                    int distinctCount = prods.Count(pr => pr.shop.ToString().Equals(str));
                    double avg = Math.Round(spendingsByShop[str] / distinctCount, 2);
                    if (Double.IsNaN(avg)) avg = 0; // prevent division by zero
                    dict[str] = avg;
                }
                return dict;
            });

        }

        public static void FindMostPopularByCategory(List<Product> prods)
        {
            mostPopularByCategory = new Lazy<Dictionary<string, string>>(delegate
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                Dictionary<string, Tuple<int, string>> tempDict = new Dictionary<string,Tuple<int, string>>();

                foreach (Product pr in prods)
                {
                    if (tempDict.ContainsKey(pr.name))
                    {
                        tempDict[pr.name] = new Tuple<int, string>(tempDict[pr.name].Item1+1 , pr.category.ToString());
                    }              
                    else tempDict[pr.name] = new Tuple<int, string>(0, pr.category.ToString());
                }
                
                   var biggest =tempDict.Keys.Max();
                
                return dict;
            });

        }
    }
}
    



