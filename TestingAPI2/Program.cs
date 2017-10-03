using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace TestingAPI2
{
    public class Program
    {
        public string imageLoc = "C:\\Users\\Ben\\Desktop\\cekis.jpg";
        public string outputLoc1 = "C:\\Users\\Ben\\Desktop\\hocr.html";
        public string outputLoc2 = "D:\\output\\check2.txt";
        private static readonly string HORC_HTML_ID = "word_1_";

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.ImageToText();
        }

        public void ImageToText()
        {
            HtmlDocument html = OcrHtml();
            if (html == null)
                return;

            ToFile(html.ToString(), outputLoc1);
            int[] coordinates = GetPriceCoordinates(html);
            string[] prices = GetPrices(GetXPadding(coordinates, 0.07), html);    //todo: add to pref file

            Console.Read();

        }

        private int[] GetXPadding(int[] coordinates, double p)
        {
            int len = coordinates[2] - coordinates[0];
            coordinates[0] -= Convert.ToInt32(len * p);
            coordinates[2] += Convert.ToInt32(len * p);
            return coordinates;
        }

        private string[] GetPrices(int[] coordinates, HtmlDocument doc)
        {
            List<HtmlNode> nodes;
            return null;

        }

        private HtmlDocument OcrHtml()
        {
            HtmlDocument doc = new HtmlDocument();            
            try
            {
                using (var api = OcrApi.Create())
                {
                    api.Init(Languages.Lithuanian);
                    api.InputName = imageLoc;
                    doc.LoadHtml(api.GetHOCRText(0));
                    return doc;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled error occured: " + e);
                return null;
            }
        }

        private int[] GetPriceCoordinates(HtmlDocument doc)
        {            
            List<HtmlNode> items = doc.DocumentNode
                .SelectNodes("//*[text()='PVM']").ToList();

            foreach(HtmlNode node in items)
            {
                HtmlNode nextWord = node.NextSibling.NextSibling;
                if (nextWord.InnerText.Equals("suma"))
                {
                    string coor = Regex.Replace(
                        Regex.Split(nextWord
                            .GetAttributeValue("title", null), ";")[0], @"[a-zA-Z]", "");
                    return Array.ConvertAll(Regex.Split(coor.Substring(1), " "), int.Parse);
                }

            }
            return null;
        }

        public void ToFile(string plainText, string outputloc)
        {
            System.IO.File.WriteAllText(outputLoc1, plainText);
        }        
    }
}