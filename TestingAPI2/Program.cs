using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.IO;
using System.Windows.Forms;
using TestingWindowsForms;

namespace TestingAPI2
{
    public class Program
    {
        public string imageLoc = "D:\\cekis.jpg";

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Program obj = new Program();
            //obj.ImageToText(imageLoc);
        }

        public string ImageToText(string imageLoc)
        {
            try
            {
                using (var api = OcrApi.Create())
                {
                    api.Init(Languages.Lithuanian);
                    return api.GetTextFromImage(imageLoc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled error occured: " + e);
                Console.Read();
            }
            return null;
        }


    }
}