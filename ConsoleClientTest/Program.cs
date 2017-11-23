using ApiService;
using ConsoleClientTest.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            APIServiceClient client = new APIServiceClient();

            Bitmap bitmap = new Bitmap("C://Users//Benas//Desktop//cekis.jpg");

            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bitmapBytes = ms.GetBuffer();

            Product[] products = client.GetPrices(bitmapBytes);
            
            foreach(Product p in products)
            {
                Console.WriteLine(p.Name);
            }
            Console.ReadKey();
        }
    }
}
