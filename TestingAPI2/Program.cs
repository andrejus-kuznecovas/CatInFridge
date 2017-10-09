using System;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.IO;

namespace TestingAPI2
{
    public class Program
    {
        public string imageLoc = "D:\\receipts\\r3.jpg";
        public string outputLoc1 = "D:\\output\\check.txt";
        public string outputLoc2 = "D:\\output\\check2.txt";

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.ImageToText();
        }

        public void ImageToText()
        {
            using (var api = OcrApi.Create())
            {
                api.Init(Languages.Lithuanian);
                string receipt = api.GetTextFromImage(filename: @imageLoc);
                Console.WriteLine(receipt);
                
                Console.Read();
            }
        }

        //šitas medotas perrašo tekstinį failą kiekvieną kartą
        public void ToFile(string plainText)
        {
            System.IO.File.WriteAllText(@outputLoc1, plainText);
        }

    }
}