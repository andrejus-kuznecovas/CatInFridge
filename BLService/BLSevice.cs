using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using HtmlAgilityPack;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;

namespace BLService
{
    public class BLService : IBLService
    {
        Repository repository;
        private static string[] categories = { "MEAT", "VEGETABLES_FRUITS", "DAIRY", "DRINKS", "ALCOHOL", "BREAD", "SWEETS", "OTHER", "UNRECOGNIZED" };
        private static string[] shops = { "Maxima", "Iki", "Rimi", "Norfa" };

        List<Product> IBLService.GetPrices(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);

            /*HtmlDocument html = OcrHtml((Bitmap)Bitmap.FromStream(ms));
            if (html == null)
                return null;*/

            HtmlDocument html = new HtmlDocument();
            html.Load(@"C:\testing.html");

            HtmlNode checkmark = GetLineOfPVMKodas(html);
            if (checkmark == null)
                return null;

            Product newProduct = new Product();
            List<Product> productsList = new List<Product>();
            HtmlNode lineNode = checkmark.NextSibling.NextSibling;
            string product;
            if (Regex.Matches(lineNode.InnerText, @"[a-zA-Z]")
                .Count == 0)
                lineNode = lineNode.NextSibling.NextSibling;

            while (Regex.Matches(lineNode.InnerText, @"[a-zA-Z]")
                .Count != 0)
            {
                Match match = Regex.Match(lineNode.InnerText, @"\s(\d+).(\d+)");
                if (match.Success)
                {
                    product = lineNode.InnerText.Substring(0, match.Index);
                    newProduct.Name = product;
                    newProduct.Price = match.Value;
                    if (!productsList.Contains(newProduct))
                        productsList.Add(new Product() { Name = product, Price = match.Value });
                }
                lineNode = lineNode.NextSibling.NextSibling;
            }

            /*
            productsList.Add(new Product() { Name = "Cukrus", Price = "1,65" });
            productsList.Add(new Product() { Name = "Citrina", Price = "0,35" });
            */

            return productsList;
        }

        List<Shop> IBLService.GetShops()
        {
            List<Shop> shops = new List<Shop>();
            shops.Add(new Shop() { Id = 0, Name = "Iki" });
            shops.Add(new Shop() { Id = 1, Name = "Maxima" });
            shops.Add(new Shop() { Id = 2, Name = "Rimi" });
            shops.Add(new Shop() { Id = 3, Name = "Norfa" });
            return shops;
        }

        List<Product> IBLService.Post(Product product)
        {
            if (repository == null)
                repository = new Repository();

            repository.WriteProductsToXmlFile(product);
            return new List<Product>() { product };
            //return Search(product);
        }

        string IBLService.Test()
        {
            if (repository == null)
                repository = new Repository();

            return Repository.productPath;
        }

        public static HtmlDocument OcrHtml(Bitmap image)
        {
            HtmlDocument doc = new HtmlDocument();
            try
            {
                using (var api = OcrApi.Create())
                {
                    api.Init(Languages.Lithuanian, Path.GetFullPath(@".\.\"));
                    api.SetImage(OcrPix.FromBitmap(image));
                    string html = api.GetHOCRText(0);
                    doc.LoadHtml(html);
                    return doc;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled error occured: " + e);
                return null;
            }
        }

        HtmlNode GetLineOfPVMKodas(HtmlDocument doc)
        {
            if (doc == null)
            {
                return null;
            }

            try
            {
                List<HtmlNode> items = doc.DocumentNode
                    .SelectNodes("//*[text()='pvm']").ToList();

                foreach (HtmlNode node in items)
                {
                    HtmlNode nextWord = node.NextSibling.NextSibling.NextSibling.NextSibling;
                    if (nextWord.InnerText.Equals("kodas"))
                    {
                        return node.ParentNode;
                    }
                }
                return null;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Nebuvo nuskaityta jokia preke! " + e);
                return null;
            }
        }

        public List<Product> Search(Product product)
        {
            ArrayList itemList = repository.ReadProductsFromXmlFile();

            Dictionary<Product, int> dict = new Dictionary<Product, int>();
            int points = 0;
            string[] nameWords = Regex.Split(FixStrings(product.Name), " ");

            foreach (Product p in itemList)
            {
                points = 0;
                foreach (string word in nameWords)
                    if (FixStrings(p.Name).Contains(word))
                        points++;
                dict.Add(p, points);
            }
           
            return (from entry in dict
                    orderby entry.Value
                    descending
                    select entry.Key)
                    .ToList();
        }

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

        public Stats GetStats(List<Product> prods)
        {
            Stats st = new Stats();
            st.spendingsByCategory   = FindSpendingsByCategory(prods);     
            st.spendingsByShop       = FindSpendingsByShop(prods);
            st.averageByCategory     = FindAvgSpendingsByCategory(prods, st.spendingsByCategory);
            st.averageByShop         = FindAvgSpendingsByShop(prods, st.spendingsByShop);
            //st.mostPopularByCategory = FindMostPopularByCategory(prods);
            //st.mostPopularByShop     = FindMostPopularByShop(prods);
            st.cheapestByCategory    = FindCheapestByCategory(prods);
            st.cheapestByShop        = FindCheapestByShop(prods);
            return st;
        }

        // METHODS FOR CALCULATING STATISTICS
        public static void InitDict(Dictionary<string, double> dict, string[] strs)
        {
            foreach (string str in strs)
            {
                dict[str] = 0;
            }
        }

        public static Dictionary<string, double> FindSpendingsByCategory(List<Product> prods)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
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
            return dict;
        }

        public static Dictionary<string, double> FindSpendingsByShop(List<Product> prods)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            InitDict(dict, shops);
            foreach (Product product in prods)
            {
                foreach (string str in shops)
                {
                    if (product.Shop.Name.Equals(str))
                    {
                        dict[str] += Math.Round(Convert.ToDouble(product.Price), 2);
                    }
                }
            }
            return dict;
        }

        public static Dictionary<string, double> FindAvgSpendingsByCategory(List<Product> prods, Dictionary<string, double> spendsByCat)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            foreach (string str in categories)
            {
                int distinctCount = prods.Count(pr => pr.Category.ToString().Equals(str));
                double avg = Math.Round(spendsByCat[str] / distinctCount, 2);
                if (Double.IsNaN(avg)) avg = 0; //prevent division by zero
                dict[str] = avg;
            }
            return dict;
        }

        public static Dictionary<string, double> FindAvgSpendingsByShop(List<Product> prods, Dictionary<string, double> spendingsByShop)
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
        }

        public static Dictionary<string, string> FindMostPopularByCategory(List<Product> prods)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string str in categories)
            {
              //for each category get all products that belong to the category
              var catprods = prods.FindAll(pr => pr.Category.ToString().Equals(str));

              //look for the most repeated product
              var mostpop = catprods.GroupBy(pr => pr.Name).Where(x => x.Count() > 1).SelectMany(pr => pr).ToList();

              //add to dictionary
              dict[str] = mostpop.FirstOrDefault().Name;
            }
            return dict;
        }

        public static Dictionary<string, string> FindMostPopularByShop(List<Product> prods)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string str in shops)
            {
              //for each category get all products that belong to the shop
              var shopprods = prods.FindAll(pr => pr.Shop.Name.Equals(str));

              //look for the most repeated product
              var mostpop = shopprods.GroupBy(pr => pr.Name).Where(x => x.Count() > 1).SelectMany(pr => pr).ToList();

                //add to the dictionary
                //dict[str] = mostpop.FirstOr().Name;
                dict[str] = mostpop.DefaultIfEmpty(new Product() { Name = "Nera tokiu elementu" }).First().Name;

            }
            return dict;
        }

        public static Dictionary<string, Product> FindCheapestByCategory(List<Product> prods)
        {
            Dictionary<string, Product> dict = new Dictionary<string, Product>();
            foreach (string str in categories)
                {
                    //for each category get all products that belong to the shop
                    var catprods = prods.FindAll(pr => pr.Category.ToString().Equals(str));

                    //look for the most repeated (common) product
                    var mostpop = catprods.OrderBy(pr => pr.Price).DefaultIfEmpty(new Product() {Name = "N/A", Price = "0" }).First();

                    //add to dict
                    dict[str] = mostpop;
                }
            return dict;
        }

        public static Dictionary<string, Product> FindCheapestByShop(List<Product> prods)
        {
            Dictionary<string, Product> dict = new Dictionary<string, Product>();
            foreach (string str in shops)
                {
                //for each category get all products that belong to the shop
                var catprods = prods.FindAll(pr => pr.Shop.Name.Equals(str));

                //look for the most cheapest
                var mostpop = catprods.OrderBy(pr => pr.Price).DefaultIfEmpty(new Product() { Name = "N/A", Price = "0" }).First();
          
                //add to dict
                dict[str] = mostpop;
                }
            return dict;
        }
    }
}
