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
            try
            {
                using (var api = OcrApi.Create())
                {
                    api.Init(Languages.Lithuanian);
                    string plainText = api.GetTextFromImage(imageLoc);
                    Console.WriteLine(plainText);
                    api.InputName = imageLoc;
                    plainText = api.GetHOCRText(0);
                    ToFile(plainText, outputLoc1);
                    string[] coordinates = GetPriceCoordinates(plainText);

                    Console.Read();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled error occured: " + e);
                Console.Read();
            }
            
        }

        private string[] GetPriceCoordinates(string plainText)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(plainText);
            List<HtmlNode> items = new List<HtmlNode>();
            items = doc.DocumentNode
                .SelectNodes("//*[text()='PVM']").ToList();

            foreach(HtmlNode node in items)
            {
                HtmlNode nextWord = node.NextSibling.NextSibling;
                if (nextWord.InnerText.Equals("suma"))
                {
                    string coor = Regex.Replace(
                        Regex.Split(nextWord
                            .GetAttributeValue("title", null), ";")[0], @"[a-zA-Z]", "");
                    return Regex.Split(coor.Substring(1), " ");
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