using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLService
{
    public class OldStats
    {

        private static string[] categories = { "MEAT", "VEGETABLES_FRUITS", "DAIRY", "DRINKS", "ALCOHOL", "BREAD", "SWEETS", "OTHER", "UNRECOGNIZED" };
        private static string[] shops = { "Maxima", "Iki", "Rimi", "Norfa" };

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
        public static Lazy<Dictionary<string, string>> cheapestByShop;

        public OldStats(List<Product> prods) {
            FindSpendingsByCategory(spendingsByCategory, prods);
            FindSpendingsByShop(spendingsByShop, prods);
            FindAvgSpendingsByCategory(prods);
            FindAvgSpendingsByShop(prods);
            FindMostPopularByCategory(prods);
            FindMostPopularByShop(prods);
            FindCheapestByCategory(prods);
            FindCheapestByShop(prods);
        }

        public static void InitDict(Dictionary<string, double> dict, string[] strs)
        {
            foreach (string str in strs)
            {
                dict[str] = 0;
            }
        }

        public static void FindSpendingsByCategory(Dictionary<string, double> dict, List<Product> prods)
        {
            InitDict(dict, categories);
            foreach (Product product in prods)
            {
                foreach (string str in categories)
                {
                    if (product.Category.ToString().Equals(str))
                    {
                        dict[str] += Math.Round(Convert.ToDouble(product.Price), 2);
                    }
                }
            }
        }

        public static void FindSpendingsByShop(Dictionary<string, double> dict, List<Product> prods)
        {
            InitDict(dict, categories);
            foreach (Product product in prods)
            {
                foreach (string str in categories)
                {
                    if (product.Shop.Name.Equals(str))
                    {
                        dict[str] += Math.Round(Convert.ToDouble(product.Price), 2);
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
                    int distinctCount = prods.Count(pr => pr.Category.ToString().Equals(str));
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
                    int distinctCount = prods.Count(pr => pr.Shop.Name.Equals(str));
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
                foreach (string str in categories)
                {
                    //for each category get all products that belong to the category
                    var catprods = prods.FindAll(pr => pr.Category.Equals(str));

                    //look for the most repeated product
                    var mostpop = catprods.OrderByDescending(pr => pr.Name).First();

                    //add to dictionary
                    dict[str] = mostpop.Name;
                }
                return dict;
            });
        }

        public static void FindMostPopularByShop(List<Product> prods)
        {
            mostPopularByCategory = new Lazy<Dictionary<string, string>>(delegate
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string str in shops)
                {
                    //for each category get all products that belong to the shop
                    var catprods = prods.FindAll(pr => pr.Shop.Name.Equals(str));

                    //look for the most repeated product
                    var mostpop = catprods.OrderByDescending(pr => pr.Name).First();

                    //add to the dictionary
                    dict[str] = mostpop.Name;
                }
                return dict;
            });
        }

        public static void FindCheapestByCategory(List<Product> prods)
        {
            cheapestByShop = new Lazy<Dictionary<string, string>>(delegate
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string str in categories)
                {
                    //for each category get all products that belong to the shop
                    var catprods = prods.FindAll(pr => pr.Category.Equals(str));

                    //look for the most repeated (common) product
                    var mostpop = catprods.OrderBy(pr => pr.Price).First();

                    //add to dict
                    dict[str] = mostpop.Name;
                }
                return dict;
            });
        }

        public static void FindCheapestByShop(List<Product> prods)
        {
            cheapestByShop = new Lazy<Dictionary<string, string>>(delegate
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string str in shops)
                {
                    //for each category get all products that belong to the shop
                    var catprods = prods.FindAll(pr => pr.Shop.Name.Equals(str));
                  
                    //look for the most repeated (common) product
                    var mostpop = catprods.OrderBy(pr => pr.Price).First();

                    //add to dict
                    dict[str] = mostpop.Name;
                }
                return dict;
            });

        }
    }
}
