using System.Collections.Generic;
using MobileApp.BLService;
using Xamarin.Forms;

namespace MobileApp
{
    public static class Main
    {
        public static List<Shop> shops;
        public static List<Product> products;
        static public BLServiceClient wcf;
        

        public static void InitMain()
        {
            wcf = new BLServiceClient();
            wcf.GetShopsCompleted += (s, e) => { shops = e.Result; };
            wcf.GetShopsAsync();
        }

    }
}
