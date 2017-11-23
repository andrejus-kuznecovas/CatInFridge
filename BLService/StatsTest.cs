using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class StatsTest
    {
        public static void Main()
        {
            List<Product> prods = new List<Product>();
            prods.Add(new Product("desra", "1.45", "IKI", "MEAT"));
            prods.Add(new Product("jogurtas", "2.19", "IKI", "DAIRY"));
            prods.Add(new Product("desrele", "3.1", "IKI", "MEAT"));
            prods.Add(new Product("obuoliu sultys", "4.99", "IKI", "DRINKS"));
            prods.Add(new Product("rukytas kumpis", "2.69", "IKI", "MEAT"));
            prods.Add(new Product("varskes surelis", "0.99", "IKI", "DAIRY"));

            Stats st = new Stats("not much", prods);
            Dictionary<string, double> dict = Stats.spendingsByCategory;
            foreach (KeyValuePair<string, double> entry in dict)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine(dict["DAIRY"]);

            Console.WriteLine("*****************");
            Dictionary<string, double> dict2 = Stats.averageByCategory.Value;
            foreach (KeyValuePair<string, double> entry in dict2)
            {
                Console.WriteLine(entry);
            }


            Console.ReadKey();

        }

    }
}
