using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileApp.ServiceReference1;

namespace MobileApp.Droid
{
    [Activity(Label = "ProductResultActivity")]
    public class ProductResultActivity : Activity
    {
        List<string> listItems = new List<string>();
        ArrayAdapter<String> adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShopSelect);

            ListView lv = (ListView)FindViewById(Resource.Id.listViewShop);
            adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, listItems);
            lv.Adapter = adapter;

            Button backBtn = (Button)FindViewById(Resource.Id.buttonBack);

            backBtn.Click += (e, a) => StartActivity(typeof(ProductSelectActivity));

            Main.wcf.SearchCompleted += (s, e) => {
                foreach(Product p in e.Result)
                    adapter.Add(p.Name + "|" + p.Price); };
        }
    }
}