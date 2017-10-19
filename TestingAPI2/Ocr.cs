using System;
using System.Collections.Generic;
using System.Linq;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using TestingAPI2.Entities;
using System.Collections;

namespace TestingAPI2
{
    public static class Ocr
    {
        public static ArrayList GetPrices(string imageLoc)
        {
            HtmlDocument html = OcrHtml(imageLoc);
            if (html == null)
                return null;

            HtmlNode checkmark = GetLineOfPVMKodas(html);

            ArrayList lines = new ArrayList();
            Tuple<string, string> newProduct;
            HtmlNode lineNode = checkmark.NextSibling.NextSibling;
            string product;
            if (Regex.Matches(lineNode.InnerText, @"[a-zA-Z]")
                .Count == 0)
                lineNode = lineNode.NextSibling.NextSibling;
            
            while(Regex.Matches(lineNode.InnerText, @"[a-zA-Z]")
                .Count != 0)
            {
                Match match = Regex.Match(lineNode.InnerText, @"\s(\d+).(\d+)");
                if(match.Success)
                {
                    product = lineNode.InnerText.Substring(0, match.Index);
                    newProduct = new Tuple<string, string>(product, match.Value);
                    if (!lines.Contains(newProduct))
                        lines.Add(newProduct);
                }
                lineNode = lineNode.NextSibling.NextSibling;
            }

            return lines;
        }

        private static HtmlDocument OcrHtml(string imageLoc)
        {
            HtmlDocument doc = new HtmlDocument();            
            try
            {
                using (var api = OcrApi.Create())
                {
                    api.Init(Languages.Lithuanian, Path.GetFullPath(@"..\..\"));
                    api.SetImage(OcrPix.FromFile(imageLoc));
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
        
        private static HtmlNode GetLineOfPVMKodas(HtmlDocument doc)
        {            
            List<HtmlNode> items = doc.DocumentNode
                .SelectNodes("//*[text()='PVM']").ToList();

            foreach(HtmlNode node in items)
            {
                HtmlNode nextWord = node.NextSibling.NextSibling.NextSibling.NextSibling;
                if (nextWord.InnerText.Equals("kodas"))
                    return node.ParentNode;
            }
            return null;
        }
        
    }
}