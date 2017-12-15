using MobileApp.BLService;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileApp
{
    public static class Main
    {
        public static List<Shop> shops;
        public static List<Category> categories;
        public static List<Product> products;
        public static List<Product> result;
        static public BLServiceClient wcf;
        public static Product productToPost;
        public static Shop shop;

        public static void InitMain()
        {
            wcf = new BLServiceClient();
            wcf.GetShopsCompleted += (s, e) => { shops = e.Result; };
            //wcf.PostCompleted += ProductResultActivity.SetResult();
                /*(s, e) => {
                StartActivity()
                foreach (Product p in e.Result)
                    adapter.Add(p.Name + "|" + p.Price);
            };*/
            wcf.GetShopsAsync();
        }

    }
}
