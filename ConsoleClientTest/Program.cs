using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClientTest.BLService;

namespace ConsoleClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BLService.BLServiceClient client = new BLService.BLServiceClient();
            
            Bitmap bitmap = new Bitmap("D:/cekis.jpg");

            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bitmapBytes = ms.GetBuffer();

            List<BLService.Product> products = client.GetPrices(bitmapBytes).ToList();
            
            products.ForEach(p => Console.WriteLine(p.Name));
            Console.ReadKey();
        }
    }
}
