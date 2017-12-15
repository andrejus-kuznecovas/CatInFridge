using ConsoleClientTest.BLService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;

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

            List<Shop> shops = client.GetShops();

            /*
            List<Product> products = client.Post(new Product() {
                ShopId = 2,
                Category = Category.VEGETABLES_FRUITS,
                Name = "Bananas 3",
                Price = "1.00"
            });
            foreach (Product s in products)
                Console.WriteLine(s.Name);
            */
            Console.ReadKey();
        }
    }
}
