using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.IO;

namespace TestingAPI2
{
    public class Program
    {
        public string imageLoc = "D:\\image05.jpg";
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
                string plainText = api.GetTextFromImage(filename: @imageLoc);
                Console.WriteLine(plainText);
                //ToFile(plainText);
                //ToFileNewLine(plainText);
                Console.Read();
            }
        }

        //šitas medotas perrašo tekstinį failą kiekvieną kartą
        public void ToFile(string plainText)
        {
            System.IO.File.WriteAllText(@outputLoc1, plainText);
        }

        //šitas metodas įrašo stringą į naują eilutę kiekvieną kartą (neperrašo)
        public void ToFileNewLine(string plainText)
        {
            StreamWriter file1 = new StreamWriter(outputLoc2, true);
            file1.WriteLine(plainText);
            file1.Close();
        }

        public void UselessMethodToMakePullRequest(int number) => number++;
    }
}