using HtmlAgilityPack;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Services.Description;

namespace ApiService
{
    public class Service1 : IAPIService
    {
        List<Product> IAPIService.GetPrices(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);

            HtmlDocument html = OcrHtml((Bitmap)Bitmap.FromStream(ms));
            if (html == null)
                return null;

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

            return productsList;
        }

        List<Shop> IAPIService.GetShops()
        {
            List<Shop> shops = new List<Shop>();
            shops.Add(new Shop() { Id = 0, Name = "Iki" });
            shops.Add(new Shop() { Id = 1, Name = "Maxima" });
            shops.Add(new Shop() { Id = 2, Name = "Rimi" });
            shops.Add(new Shop() { Id = 3, Name = "Norfa" });
            return shops;
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
                Console.WriteLine("Unhandled error occured: " + OcrApi.PathToEngine);
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
                    if (nextWord != null && nextWord.InnerText.Equals("kodas"))
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
    }
}
