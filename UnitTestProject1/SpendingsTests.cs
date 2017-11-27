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


            foreach (KeyValuePair<string, double> entry in dict)
            {
                if (expectedDict.ContainsKey(entry.Key))
                {

                    Assert.AreEqual(expectedDict[entry.Key], entry.Value, 0.0000001);

                }
                else Assert.Fail();
            }
        }

        [TestMethod]
        public void SpendingsByShopTest()
        {
            List<Product> prods = new List<Product>();
            prods.Add(new Product("rukytos desreles", "1.45", "IKI", "MEAT"));
            prods.Add(new Product("kefyras", "1.55", "RIMI", "DAIRY"));
            prods.Add(new Product("daktariska desra", "3.1", "IKI", "MEAT"));
            prods.Add(new Product("norfos firminis", "0.89", "NORFA", "ALCOHOL"));
            prods.Add(new Product("geriausi pasaulyje bananai", "2.11", "NORFA", "FRUITS_VEGETABLES"));
            prods.Add(new Product("ozkos pienas", "9.99", "MAXIMA", "DAIRY"));

            Stats st = new Stats("", prods);
            Dictionary<string, double> dict = Stats.spendingsByShop;

            Dictionary<string, double> expectedDict = new Dictionary<string, double>()
            {
                { "MAXIMA", 9.99 },
                { "IKI", 4.55 },
                { "RIMI", 1.55 },
                { "NORFA", 3 },
                { "OTHER", 0 },
                { "UNRECOGNIZED", 0 }
            };

            foreach (KeyValuePair<string, double> entry in dict)
            {
                if (expectedDict.ContainsKey(entry.Key))
                {
                    Assert.AreEqual(expectedDict[entry.Key], entry.Value, 0.0000001);
                }
                else Assert.Fail();
            }
        }
    }
}
