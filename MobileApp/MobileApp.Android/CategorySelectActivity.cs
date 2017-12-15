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
    [Activity(Label = "CategorySelectActivity")]
    public class CategorySelectActivity : Activity
    {
        List<string> listItems = new List<string>();
        ArrayAdapter<String> adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShopSelect);

            ListView lv = (ListView)FindViewById(Resource.Id.listViewCategory);
            adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, listItems);
            lv.Adapter = adapter;

            Button backBtn = (Button)FindViewById(Resource.Id.buttonBack2);

            backBtn.Click += delegate
            {
                StartActivity(typeof(ProductResultActivity));
            };

            /*foreach (Cat category in Main.categories)
                adapter.Add(category);

            lv.ItemClick += listView_ItemClick;*/
        }

        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string item = adapter.GetItem(e.Position);
            Main.wcf.PostAsync(Main.products, new Shop() { Name = item });
            StartActivity(typeof(ProductSelectActivity));
        }
    }
}