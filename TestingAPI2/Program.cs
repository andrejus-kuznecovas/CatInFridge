using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
=======
>>>>>>> api_branch
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace TestingAPI2
{
    public class Program
    {
<<<<<<< HEAD
        public string imageLoc = "C:\\Users\\Benas\\Desktop\\cekis.jpg";
        public string outputLoc1 = "C:\\Users\\Benas\\Desktop\\hocr.html";
        private static readonly string HORC_HTML_ID = "word_1_";
        private static string projectPath;
=======
        public string imageLoc = "D:\\receipts\\r3.jpg";
        public string outputLoc1 = "D:\\output\\check.txt";
        public string outputLoc2 = "D:\\output\\check2.txt";
>>>>>>> api_branch

        static void Main(string[] args)
        {
            projectPath = Path.GetFullPath(@"..\..\");

            Program obj = new Program();
            obj.ImageToText();
        }

        public void ImageToText()
        {
            HtmlDocument html = OcrHtml();
            if (html == null)
                return;
            
            HtmlNode checkmarkLine= GetLineOfPVMSuma(html);

            Dictionary<string, string> prices = GetPrices(checkmarkLine, html);

            Console.Write("DONE");
            Console.Read();

        }

        private Dictionary<string, string> GetPrices(HtmlNode checkmark, HtmlDocument doc)
        {
            Dictionary<string, string> lines = new Dictionary<string, string>();
            HtmlNode lineNode = checkmark.NextSibling.NextSibling;
            string product;
            if (Regex.Matches(lineNode.InnerText, @"[a-zA-Z]")
                .Count == 0)
                lineNode = lineNode.NextSibling.NextSibling;


            while(Regex.Matches(lineNode.InnerText, @"[a-zA-Z]")
                .Count != 0)
            {
<<<<<<< HEAD
                Match match = Regex.Match(lineNode.InnerText, @"\s(\d+).(\d+)");
                product = lineNode.InnerText.Substring(0, match.Index);
                if (!lines.ContainsKey(product))
                    lines.Add(product, match.Value);

                else if (Double.Parse(match.Value) < Double.Parse(lines[product]))
                    lines[product] = match.Value;

                lineNode = lineNode.NextSibling.NextSibling;                
=======
                api.Init(Languages.Lithuanian);
                string receipt = api.GetTextFromImage(filename: @imageLoc);
                Console.WriteLine(receipt);
                
                Console.Read();
>>>>>>> api_branch
            }

            return lines;
        }

        private HtmlDocument OcrHtml()
        {
            HtmlDocument doc = new HtmlDocument();            
            try
            {
                using (var api = OcrApi.Create())
                {
                    api.Init(Languages.Lithuanian, projectPath);
                    api.SetImage(OcrPix.FromFile(imageLoc));
                    string html = api.GetHOCRText(0);
                    ToFile(html, outputLoc1);
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

<<<<<<< HEAD
        private HtmlNode GetLineOfPVMSuma(HtmlDocument doc)
        {            
            List<HtmlNode> items = doc.DocumentNode
                .SelectNodes("//*[text()='pvm']").ToList();

            foreach(HtmlNode node in items)
            {
                HtmlNode nextWord = node.NextSibling.NextSibling.NextSibling.NextSibling;
                if (nextWord.InnerText.Equals("kodas"))
                    return node.ParentNode;
            }
            return null;
        }

        public void ToFile(string plainText, string outputloc)
        {
            System.IO.File.WriteAllText(outputLoc1, plainText);
        }        
=======
>>>>>>> api_branch
    }
}