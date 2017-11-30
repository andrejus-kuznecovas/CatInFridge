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


        [TestMethod]
        public void AvgSpendingsByCategoryTest()
        {
            List<Product> prods = new List<Product>();
            prods.Add(new Product("jautienos kumpis", "0.55", "RIMI", "MEAT"));
            prods.Add(new Product("vistienos file", "1.09", "RIMI", "MEAT"));
            prods.Add(new Product("kalakutienos file", "4.99", "IKI", "MEAT"));
            prods.Add(new Product("pomidorai", "0.99", "RIMI", "VEGETABLES_FRUITS"));
            prods.Add(new Product("konservuotos darzoves", "0.89", "NORFA", "VEGETABLES_FRUITS"));
            prods.Add(new Product("raudonas vynas", "14.99", "NORFA", "ALCOHOL"));

            Stats st = new Stats("", prods);
            Dictionary<string, double> dict = Stats.averageByCategory.Value;

            Dictionary<string, double> expectedDict = new Dictionary<string, double>()
            {
                { "MEAT", 2.21 },
                { "VEGETABLES_FRUITS", 0.94  },
                { "ALCOHOL", 14.99 },
                { "DAIRY", 0 },
                { "DRINKS", 0 },
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
                else Assert.Fail("expectedDict does not contain key: " + entry.Key + ", entry value: " + entry.Value);
            }
        }


        [TestMethod]
        public void AvgSpendingsByShopTest()
        {
            List<Product> prods = new List<Product>();
            prods.Add(new Product("granatu sultys", "5.49", "IKI", "DRINKS"));
            prods.Add(new Product("graikiskas jogurtas", "1.49", "IKI", "DAIRY"));
            prods.Add(new Product("vistienos broileriu file", "2.63", "IKI", "MEAT"));
            prods.Add(new Product("kalakutienos kepsnys", "7.95", "RIMI", "MEAT"));
            prods.Add(new Product("konservuotos darzoves", "0.89", "NORFA", "VEGETABLES_FRUITS"));
            prods.Add(new Product("raudonas vynas", "14.99", "NORFA", "ALCOHOL"));

            Stats st = new Stats("", prods);
            Dictionary<string, double> dict = Stats.averageByShop.Value;

            Dictionary<string, double> expectedDict = new Dictionary<string, double>()
            {
                { "IKI", 3.20 },
                { "RIMI", 7.95 },
                { "NORFA", 7.94 },
                { "MAXIMA", 0 },
                { "OTHER", 0 },
                { "UNRECOGNIZED", 0 }

            };

            foreach (KeyValuePair<string, double> entry in dict)
            {
                if (expectedDict.ContainsKey(entry.Key))
                {
                    Assert.AreEqual(expectedDict[entry.Key], entry.Value, 0.0000001, "failed at shop: " + entry.Key);
                }
                else Assert.Fail("expectedDict does not contain key: " + entry.Key + ", entry value: " + entry.Value);
            }


        }
    }
}
