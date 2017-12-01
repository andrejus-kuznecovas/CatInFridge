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
            BLServiceClient client = new BLServiceClient();
            Product[] p = new Product[] {
                new Product() { Name = "AAAAAA", Price = "1" },
                new Product() { Name = "BBBBBB", Price = "2" }
            };

            client.Post(p, new Shop() { Name = "MAXIMA" });

            Console.ReadKey();
        }
    }
}
