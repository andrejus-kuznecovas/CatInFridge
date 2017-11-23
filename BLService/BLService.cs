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
using Statistics;

namespace BLService
{
    public class BLService : IBLService
    {

        string IBLService.GetPrices(string imageLoc)
        {
            HtmlDocument html = OcrHtml(imageLoc);
            if (html == null)
                return null;

            HtmlNode checkmark = GetLineOfPVMKodas(html);
            if (checkmark == null)
                return null;

            ArrayList lines = new ArrayList();
            Tuple<string, string, string> newProduct;
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
                    newProduct = new Tuple<string, string ,string>(product, "|" ,match.Value);
                    if (!lines.Contains(newProduct))
                        lines.Add(newProduct);
                }
                lineNode = lineNode.NextSibling.NextSibling;
            }
           
            String listString = String.Join("|", lines.ToArray());
            Console.WriteLine(listString);           
            return listString;
        }

        public static HtmlDocument OcrHtml(string imageLoc)
        {
            HtmlDocument doc = new HtmlDocument();
            try
            {
                using (var api = OcrApi.Create())
                {
                    api.Init(Languages.Lithuanian, Path.GetFullPath(@"..\..\")); //cia luzta, tuoj parodysiu
                    api.SetImage(OcrPix.FromFile(imageLoc));
                    string html = api.GetHOCRText(0);
                    doc.LoadHtml(html);
                    //paversti i string html jei reiktu
                    //string converted = File.ReadAllText(@"D:\testing3000.html");
                    //System.IO.File.WriteAllText(@"D:\crap.txt", converted);

                    //patikrinimui ka nuskaito...
                    //string path = "D:\\test.xml";
                    //XmlTextWriter writer = new XmlTextWriter(path, null);
                    //doc.Save(writer);
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
                    .SelectNodes("//*[text()='PVM']").ToList();

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

        List<Product> IBLService.Search(string itemName, string category, ArrayList itemList)
        {
            Dictionary<Product, int> dict = new Dictionary<Product, int>();
            int points = 0;
            string[] nameWords = Regex.Split(FixStrings(itemName), " ");
            /*itemList.Remove((from Product product in itemList
                             where product.category.type != category
                             select product).ToList());*/       //kolkas neveikia

            foreach (Product p in itemList)
            {
                points = 0;
                foreach (string word in nameWords)
                    if (FixStrings(p.name).Contains(word))
                        points++;
                dict.Add(p, points);
            }
            return (from entry in dict
                    orderby entry.Value
                    descending
                    select entry.Key)
                    .ToList<Product>();
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

        Stats IBLService.GetStats(string command, List<Product> prods)
        {
            return new Stats(command, prods);
        }

    }
}
