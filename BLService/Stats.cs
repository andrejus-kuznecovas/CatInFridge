

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
            FindAllSpendings(spendingsByCategory, prods, categories);

            spendingsByShop = new Dictionary<string, double>();
            //Set spendings in all shops to zeroes
            InitDict(spendingsByShop, shops);
            //Find all spendings by shop
            FindAllSpendings(spendingsByShop, prods, shops);

            int distinctCount2 = prods.Count(pr => pr.category.ToString().Equals("DRINKS"));
            Console.WriteLine(distinctCount2);


            averageByCategory = new Lazy<Dictionary<string, double>>(delegate
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                foreach (string str in categories)
                {
                    int distinctCount = prods.Count(pr => pr.category.ToString().Equals(str));
                    double avg = Math.Round(spendingsByCategory[str] / distinctCount, 2);
                    if (Double.IsNaN(avg)) avg = 0;
                    dict[str] = avg;
                }
                return dict;
            });

            averageByShop = new Lazy<Dictionary<string, double>>(delegate
            {
                Dictionary<string, double> dict = new Dictionary<string, double>();
                foreach (string str in categories)
                {
                    int distinctCount = prods.Count(pr => pr.shop.ToString().Equals(str));
                    double avg = Math.Round(spendingsByCategory[str] / distinctCount, 2);
                    if (Double.IsNaN(avg)) avg = 0;
                    dict[str] = avg;
                }
                return dict;
            });
        }

        public static void InitDict(Dictionary<string, double> dict, string[] strs)
        {
            foreach (string str in strs)
            {
                dict[str] = 0;
            }
        }

        public static void FindAllSpendings(Dictionary<string, double> dict, List<Product> prods, string[] strs)
        {
            foreach (Product product in prods)
            {
                //Console.WriteLine("Product category: " + product.category.ToString() );
                foreach (string str in strs)
                {
                    if (product.category.ToString().Equals(str))
                    {
                        dict[str] += Convert.ToDouble(product.price);
                    }
                }
            }
        }
    }
}




