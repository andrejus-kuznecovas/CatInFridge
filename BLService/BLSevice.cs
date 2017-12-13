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

        void IBLService.Post(List<Product> products, Shop shop)
        {
            if (repository == null)
                repository = new Repository();

            repository.WriteProductsToXmlFile(products, shop);
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

        public List<Product> Search(string itemName)
        {
            ArrayList itemList = repository.ReadProductsFromXmlFile();

            Dictionary<Product, int> dict = new Dictionary<Product, int>();
            int points = 0;
            string[] nameWords = Regex.Split(FixStrings(itemName), " ");

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
    }
}
