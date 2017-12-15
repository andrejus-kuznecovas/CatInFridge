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
using MobileApp.BLService;

namespace MobileApp.Droid
{
    [Activity(Label = "ProductSelectActivity")]
    public class ProductSelectActivity : Activity
    {
        List<string> listItems = new List<string>();
        ArrayAdapter<String> adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SelectList);

            ListView lv = (ListView)FindViewById(Resource.Id.listView);
            adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, listItems);
            lv.Adapter = adapter;

            Button backBtn = (Button)FindViewById(Resource.Id.buttonBack);
            Button nextBtn = (Button)FindViewById(Resource.Id.buttonNext);
            nextBtn.Visibility = ViewStates.Gone;

            backBtn.Click += (e, a) => { StartActivity(typeof(ShopSelectActivity)); };

            foreach (Product p in Main.products)
                adapter.Add(p.Name);

            lv.ItemClick += listView_ItemClick;

        }

        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string item = adapter.GetItem(e.Position);
            Main.productToPost = Main.products.Where(p => p.Name.Equals(item)).First();
            StartActivity(typeof(CategorySelectActivity));
        }
    }
}