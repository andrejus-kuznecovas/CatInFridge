using System;
using System.Collections.Generic;
using BLService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Statistics
{
    [TestClass]
    public class StatisticsTests
    {
              [TestMethod]
        public void SpendingsByCategoryTest()
        {
            List<Product> prods = new List<Product>();
            prods.Add(new Product("desra", "1.45", "IKI", "MEAT"));
            prods.Add(new Product("jogurtas", "2.19", "IKI", "DAIRY"));
            prods.Add(new Product("desrele", "3.1", "IKI", "MEAT"));
            prods.Add(new Product("obuoliu sultys", "4.99", "IKI", "DRINKS"));
            prods.Add(new Product("rukytas kumpis", "2.69", "IKI", "MEAT"));
            prods.Add(new Product("varskes surelis", "0.99", "IKI", "DAIRY"));

            Stats st = new Stats("", prods);
            Dictionary<string, double> dict = Stats.spendingsByCategory;

            Dictionary<string, double> expectedDict = new Dictionary<string, double>()
            {
                { "MEAT", 7.24 },
                { "VEGETABLES_FRUITS", 0 },
                { "DAIRY", 3.18 },
                { "DRINKS", 4.99 },
                { "ALCOHOL", 0 },
                { "BREAD", 0 },
                { "SWEETS", 0 },
                { "OTHER", 0 },
                { "UNRECOGNIZED", 0 }
            };

            CollectionAssert.AreEquivalent(expectedDict, dict);
        }

        [TestMethod]
        public void SpendingsByShopTest()
        {

        }
    }
}
