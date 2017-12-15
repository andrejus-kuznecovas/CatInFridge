using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ConsoleClientTest.BLService;

namespace ConsoleClientTest
{
    [CallbackBehaviorAttribute(
   IncludeExceptionDetailInFaults = true,
    UseSynchronizationContext = true,
    ValidateMustUnderstand = true
  )]
    class Program
    {
        static void Main(string[] args)
        {
            BLServiceClient client = new BLServiceClient();
            /*
            Product[] p = new Product[] {
                new Product() { Name = "AAAAAA", Price = "1" },
                new Product() { Name = "BBBBBB", Price = "2" }
            };

            //client.Post(p, new Shop() { Name = "MAXIMA" });
            Console.WriteLine(client.GetShops().ElementAt(0));
            */
            //client.InsertProduct();
            List<Product> productL = new List<Product>();

            Shop s = new Shop { Id = 4, Name = "Norfa" };

            Product p = new Product();
            //p.ID = 1.ToString();
            p.Name = "Kebabas";
            p.Price = "2,50";
            p.Category = 1;
            p.Date = DateTime.Now;
            p.ShopId = 1;

            productL = client.GetSimilarProducts(p);
            foreach (var item in productL)
            {
                Console.WriteLine(item.Name);
            }
            //kdl itemu neisvede?:D nzn greit suspaudinejai net nespejau paziuret, viskas buvo ten kaip reik
            /*
            if (client.DeleteShop(s) == 1)
            {
                Console.WriteLine("Success");
            }
            */
            /*
            if (client != null)
                client.ShopQuery();
            else Console.WriteLine("too fast");
            */
            
            Console.ReadKey();
        }
    }
}
